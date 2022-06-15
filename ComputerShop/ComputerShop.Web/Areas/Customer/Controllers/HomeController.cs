using ComputerShop.Web.Areas.Customer.ViewModels;

namespace ComputerShop.Web.Areas.Customer.Controllers;

[Authorize(Roles = "admin, user")]
public class HomeController : Controller
{
    private readonly IProductRepository _productRepository;
    private readonly IReportRepository _reportRepository;
    private readonly IUserRepository _userRepository;

    public HomeController(
        IProductRepository productRepository,
        IReportRepository reportRepository,
        IUserRepository userRepository)
    {
        _productRepository = productRepository;
        _reportRepository = reportRepository;
        _userRepository = userRepository;
    }
    public async Task<IActionResult> Index(int page = 1)
    {
        int pageSize = 3;
        List<Product> productsPerPages = await _productRepository.GetProductsRangeAsync((page - 1) * pageSize, pageSize);

        PageInfo pageInfo = new()
        {
            PageNumber = page,
            PageSize = pageSize,
            TotalItems = await _productRepository.GetProductsCountAsync(),
        };

        IndexViewModel ivm = new()
        {
            PageInfo = pageInfo,
            Products = productsPerPages
        };

        return View(ivm);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int ID)
    {
        Product product = await _productRepository.GetProductByIDAsync(ID);

        product.Characteristics = await _productRepository.GetCharactericticsAsync(product.ID);

        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> Buy(
        [Required]
        int productID,
        [Required(ErrorMessage = "Please enter count.")]
        [Range(1, int.MaxValue, ErrorMessage = "Count cannot be less than 1")]
        int quantity)
    {
        Product product = await _productRepository.GetProductByIDAsync(productID);

        if (ModelState.IsValid && quantity <= product.Count)
        {
            User? user = await _userRepository.GetUserByEmailAsync(User.Identity.Name);

            if (user is not null)
            {
                decimal totalPrice = quantity * product.Price;

                await _reportRepository.AddSalesAsync(productID, quantity, totalPrice, user.ID);
            }

            product.Count -= quantity;

            await _productRepository.UpdateProductAsync(product);

            return RedirectToAction("Index", "Home", new { area = "Customer" });
        }
        else
        {
            ModelState.AddModelError("", "Buying error.");
        }

        return View("Details", product);
    }
}
