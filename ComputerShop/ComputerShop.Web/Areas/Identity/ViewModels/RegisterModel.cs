namespace ComputerShop.Web.Areas.Identity.ViewModels;

public class RegisterModel
{
    [Required(ErrorMessage = "Please enter email.")]
    [EmailAddress]
    public string Email { get; set; }

    [Required(ErrorMessage = "Please enter address.")]
    public string Address { get; set; }

    [Required(ErrorMessage = "Please enter full name.")]
    public string FullName { get; set; }

    [Required(ErrorMessage = "Please enter password.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Password entered incorrectly")]
    public string ConfirmPassword { get; set; }
}
