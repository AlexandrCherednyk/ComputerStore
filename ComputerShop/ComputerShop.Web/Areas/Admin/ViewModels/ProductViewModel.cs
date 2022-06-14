namespace ComputerShop.Web.Areas.Admin.ViewModels
{
    public class ProductViewModel
    {
        [Required(ErrorMessage = "Please enter product name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter product description.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter product type.")]
        public int TypeID { get; set; }

        [Required(ErrorMessage = "Please enter product manufacturer.")]
        public int ManufacturerID { get; set; }

        [Required(ErrorMessage = "Please enter product price.")]

        [Range(0, double.MaxValue, ErrorMessage = "The number cannot be less than 0.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please enter product count.")]
        [Range(0, double.MaxValue, ErrorMessage = "The number cannot be less than 0.")]
        public int Count { get; set; }

        [Required(ErrorMessage = "Please load product image.")]
        public IFormFile Image { get; set; }

        //public IEnumerable<Characteristic> Characteristics { get; set; }

    }
}
