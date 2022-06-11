namespace ComputerShop.Web.Areas.Admin.ViewModels;

public class ManufacturerViewModel
{
    public int ID { get; set; }

    [Required]
    [MaxLength(255)]
    public string Name { get; set; }
}
