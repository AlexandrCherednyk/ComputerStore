namespace ComputerShop.Web.Areas.Admin.ViewModels;

public class ProductTypeViewModel
{
    public int ID { get; set; }

    [Required(ErrorMessage = "Please enter product type name.")]
    [MaxLength(255)]
    public string Name { get; set; }
}
