namespace ComputerShop.DataAccess.Abstracts.IRepositories;

public interface IUserRepository
{
    Task<User?> GetUserByEmailAsync(string email);
    Task AddUserAsync(User user);
}
