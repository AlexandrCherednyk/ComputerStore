using ComputerShop.Web.Areas.Admin.ViewModels;

namespace ComputerShop.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
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
}
