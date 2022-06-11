namespace ComputerShop.Web.Areas.Customer.ViewModels;

public class AddProduct
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Type { get; set; }
    public int ManufacturerID { get; set; }
    public decimal Price { get; set; }
    public int Count { get; set; }
}
