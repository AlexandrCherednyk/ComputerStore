namespace ComputerShop.Models
{
    public class Processor
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string ProcessorFamily { get; set; } = null!;
        public int CoresNumber { get; set; }
        public int ClockFrequency { get; set; }
    }
}
