namespace ComputerStore.Infastructure.DAOs.Identity;
public class UserDao
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string PasswordSalt { get; set; }
    public RoleDao Role { get; set; }
}
