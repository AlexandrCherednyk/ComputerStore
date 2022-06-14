using ComputerShop.Web.Areas.Admin.ViewModels;

namespace ComputerShop.Web.Areas.Admin.Controllers;

[Authorize(Roles = "admin")]
public class ManufacturerController : Controller
{
    private readonly IManufacturerRepository _manufacturerRepository;

    public ManufacturerController(IManufacturerRepository manufacturerRepository)
    {
        _manufacturerRepository = manufacturerRepository;
    }

    [HttpGet]
    public IActionResult AddManufacturer()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddManufacturer(ManufacturerViewModel manufacturer)
    {
        if (ModelState.IsValid)
        {
            await _manufacturerRepository.AddManufacturer(manufacturer.Name);

            return RedirectToAction("Index", "Home", new { area = "Customer" });
        }
        else
        {
            ModelState.AddModelError("", "Invalid manufacturer");
        }
        return View(manufacturer);
    }
}
