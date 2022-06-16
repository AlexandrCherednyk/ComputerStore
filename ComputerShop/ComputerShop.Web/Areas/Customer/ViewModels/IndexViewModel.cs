namespace ComputerShop.Web.Areas.Customer.ViewModels;

public class IndexViewModel
{
    public IEnumerable<Product> Products { get; set; }
    public PageInfo PageInfo { get; set; }
    public string Search { get; set; } = "";
}
