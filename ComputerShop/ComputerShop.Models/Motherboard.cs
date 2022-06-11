namespace ComputerShop.Models
{
    public class Motherboard
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string Socket { get; set; } = null!;
        public string MemorySupport { get; set; } = null!;
        public string FormFactor { get; set; } = null!;
    }
}
