namespace ComputerShop.Web.Areas.Admin.Controllers;

[Authorize(Roles = "admin")]
public class InputController : Controller
{
    private readonly IProductRepository _productRepository;
    private readonly IReportRepository _reportRepository;

    public InputController(
        IProductRepository productRepository,
        IReportRepository reportRepository)
    {
        _productRepository = productRepository;
        _reportRepository = reportRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        List<Input> purshases = await _reportRepository.GetPurchasesAsync();

        return View(purshases);
    }

    [HttpPost]
    public async Task<IActionResult> AddPurchase(
        [Required]
        int productID,
        [Required(ErrorMessage = "Please enter count.")]
        [Range(1, int.MaxValue, ErrorMessage = "Count cannot be less than 1")]
        int quantity)
    {
        Product product = await _productRepository.GetProductByIDAsync(productID);

        if (ModelState.IsValid && quantity > 0)
        {
            await _reportRepository.AddPurchasesAsync(productID, quantity);

            product.Count += quantity;

            await _productRepository.UpdateProductAsync(product);

            return RedirectToAction("Index", "Home", new { area = "Customer" });
        }
        else
        {
            ModelState.AddModelError("", "Purchasing error.");
        }

        return View("../../Areas/Customer/HomeController/Details.cshtml", product);
    }
}
