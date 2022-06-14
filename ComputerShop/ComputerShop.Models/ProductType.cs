namespace ComputerShop.Models;

public class ProductType
{
    public int ID { get; set; }

    [Required]
    [MaxLength(255)]
    public string Name { get; set; }
}
