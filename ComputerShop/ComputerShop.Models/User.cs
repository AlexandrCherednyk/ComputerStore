namespace ComputerShop.Models;

public class User
{
    public int ID { get; set; }
    public string Email { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public Role? Role { get; set; }
}
