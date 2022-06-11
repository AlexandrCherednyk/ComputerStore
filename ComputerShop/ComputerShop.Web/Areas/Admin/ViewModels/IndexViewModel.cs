namespace ComputerShop.Web.Areas.Admin.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
