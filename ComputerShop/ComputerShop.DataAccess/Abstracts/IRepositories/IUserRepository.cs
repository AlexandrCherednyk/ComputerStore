namespace ComputerShop.DataAccess.Abstracts.IRepositories;

public interface IUserRepository
{
    Task<List<User>> GetUsersAsync();
    Task<User?> GetUserByEmailAsync(string email);
    Task AddUserAsync(User user);
    Task UpdateUserAsync(int ID, string address, string fullName);
    Task RemoveUserAsync(int ID);
}
