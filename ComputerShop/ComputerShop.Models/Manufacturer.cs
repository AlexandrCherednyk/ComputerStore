namespace ComputerShop.Models
{
    public class Manufacturer
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
