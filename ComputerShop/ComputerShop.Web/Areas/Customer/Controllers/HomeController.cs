namespace ComputerShop.Web.Areas.Customer.Controllers
{
    [Authorize(Roles = "admin, user")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
