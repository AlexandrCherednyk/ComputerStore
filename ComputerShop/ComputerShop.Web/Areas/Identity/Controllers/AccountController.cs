namespace ComputerShop.Web.Areas.Identity.Controllers;

[AllowAnonymous]
public class AccountController : Controller
{
    private readonly UserRepository _userRepository;

    public AccountController()
    {
        _userRepository = new UserRepository();
    }

    [HttpGet]
    public IActionResult Register()
    {
        ViewBag.IsSignIn = false;

        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        if (ModelState.IsValid)
        {
            User? user = await _userRepository.GetUserByEmailAsync(model.Email);

            if (user == null)
            {
                SecurePasswordHasher hasher = new();

                user = new()
                {
                    Email = model.Email.ToLower(),
                    PasswordHash = hasher.HashToString(model.Password),
                    Address = model.Address,
                    FullName = model.FullName,
                };

                user.Role = new()
                {
                    Name = "user",
                };

                await _userRepository.AddUserAsync(user);

                await Authenticate(user);

                return RedirectToAction("Index", "Home", new { area = "Customer" });
            }
        }
        else
        {
            ModelState.AddModelError("", "Invalid Email and(or) password");
        }
        return View(model);
    }
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginModel model)
    {
        if (ModelState.IsValid)
        {
            User? user = await _userRepository.GetUserByEmailAsync(model.Email.ToLower());

            if (user != null)
            {
                SecurePasswordHasher hasher = new();

                if (hasher.Verify(model.Password, user.PasswordHash))
                {
                    await Authenticate(user);

                    return RedirectToAction("Index", "Home", new { area = "Customer" });
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Email and(or) password");

                    return View(model);
                }
            }
            ModelState.AddModelError("", "Invalid Email and(or) password");
        }
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        return RedirectToAction("Login", "Account");
    }

    private async Task Authenticate(User user)
    {
        var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };

        ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
            ClaimsIdentity.DefaultRoleClaimType);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
    }
}
