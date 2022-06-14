using ComputerShop.Web.Areas.Admin.ViewModels;

namespace ComputerShop.Web.Areas.Admin.Controllers;

[Authorize(Roles = "admin")]
public class ProductTypeController : Controller
{
    private readonly IProductTypeRepository _productTypeRepository;

    public ProductTypeController(IProductTypeRepository productTypeRepository)
    {
        _productTypeRepository = productTypeRepository;
    }

    [HttpGet]
    public IActionResult AddProductType()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddProductType(ProductTypeViewModel productType)
    {
        if (ModelState.IsValid)
        {
            await _productTypeRepository.AddProductType(productType.Name);

            return RedirectToAction("Index", "Home", new { area = "Customer" });
        }
        else
        {
            ModelState.AddModelError("", "Invalid product type");
        }
        return View(productType);
    }
}
