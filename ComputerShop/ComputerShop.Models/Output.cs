namespace ComputerShop.Models;

public class Output
{
    public int ID { get; set; }
    public int? ProductID { get; set; }
    public int Count { get; set; }
    public decimal? TotalPrice { get; set; }
    public DateTime Time { get; set; }
    public int? UserID { get; set; }
}
