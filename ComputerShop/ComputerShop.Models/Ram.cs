namespace ComputerShop.Models
{
    public class Ram
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int Memory { get; set; }
        public string MemoryType { get; set; } = null!;
        public int MemoryFrequency { get; set; }
    }
}
