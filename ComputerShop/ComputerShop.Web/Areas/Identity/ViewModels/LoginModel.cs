namespace ComputerShop.Web.Areas.Identity.ViewModels;

public class LoginModel
{
    [Required(ErrorMessage = "No email specified")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Тo password specified")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
