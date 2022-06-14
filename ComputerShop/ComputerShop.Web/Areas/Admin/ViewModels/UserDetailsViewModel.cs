namespace ComputerShop.Web.Areas.Admin.ViewModels;

public class UserDetailsViewModel
{
    public int ID { get; set; }

    [Required(ErrorMessage = "Please enter address.")]
    public string Address { get; set; }

    [Required(ErrorMessage = "Please enter full name.")]
    public string FullName { get; set; }
}
