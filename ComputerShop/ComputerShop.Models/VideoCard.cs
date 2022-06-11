namespace ComputerShop.Models
{
    public class VideoCard
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string GraphicsChip { get; set; } = null!;
        public int VideoCardMemory { get; set; }
        public string VideoCardMemoryType { get; set; } = null!;
    }
}
