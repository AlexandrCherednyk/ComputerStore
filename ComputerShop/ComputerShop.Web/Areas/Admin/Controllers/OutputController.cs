namespace ComputerShop.Web.Areas.Admin.Controllers;

[Authorize(Roles = "admin")]
public class OutputController : Controller
{
    private readonly IReportRepository _reportRepository;

    public OutputController(IReportRepository reportRepository)
    {
        _reportRepository = reportRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        List<Output> sales = await _reportRepository.GetSalesAsync();

        return View(sales);
    }
}
