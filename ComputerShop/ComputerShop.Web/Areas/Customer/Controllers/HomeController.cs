using ComputerShop.Web.Areas.Customer.ViewModels;

namespace ComputerShop.Web.Areas.Customer.Controllers;

[Authorize(Roles = "admin, user")]
public class HomeController : Controller
{
    private readonly IProductRepository _productRepository;

    public HomeController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<IActionResult> Index(int page = 1)
    {
        int pageSize = 15;
        List<Product> productsPerPages = await _productRepository.GetProductsRangeAsync(page - 1, (page - 1) + pageSize);

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
}
