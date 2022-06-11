namespace ComputerShop.Web.Areas.Identity.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "No email specified")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Тo password specified")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password entered incorrectly")]
        public string ConfirmPassword { get; set; }
    }
}
