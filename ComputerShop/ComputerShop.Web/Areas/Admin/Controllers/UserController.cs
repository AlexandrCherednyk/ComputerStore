using ComputerShop.Web.Areas.Admin.ViewModels;

namespace ComputerShop.Web.Areas.Admin.Controllers;

[Authorize (Roles = "admin")]
public class UserController : Controller
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        List<User> users = await _userRepository.GetUsersAsync();

        return View(users);
    }

    [HttpGet]
    public async Task<IActionResult> Remove(int ID)
    {
        await _userRepository.RemoveUserAsync(ID);

        return RedirectToAction("Index", "User", new { area = "Admin" });
    }

    [HttpGet]
    public async Task<IActionResult> Details(string email)
    {
        User? user = await _userRepository.GetUserByEmailAsync(email);

        if(user is null)
        {
            return View("Error");
        }

        UserDetailsViewModel details = new()
        {
            ID = user.ID,
            Address = user.Address,
            FullName = user.FullName,
        };

        return View(details);
    }

    [HttpPost]
    public async Task<IActionResult> Details(UserDetailsViewModel user)
    {
        if (ModelState.IsValid)
        {
            await _userRepository.UpdateUserAsync(user.ID, user.Address, user.FullName);

            return RedirectToAction("Index", "User", new { area = "Admin" });
        }
        else
        {
            ModelState.AddModelError("", "Invalid user");
        }

        return View(user);
    }

}

