namespace ComputerStore.Infastructure.DAOs.Identity;
public class UserDao
{
    public int Id { get; set; }
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string PasswordSalt { get; set; } = null!;
    public RoleDao Role { get; set; } = null!;
}
