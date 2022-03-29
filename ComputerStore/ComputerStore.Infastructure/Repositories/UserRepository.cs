using ComputerStore.Infastructure.DAOs.Identity;

namespace ComputerStore.Infastructure.Repositories;
public class UserRepository : IUserRepository
{
    public Task<UserDao> AddAsync(UserDao entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(UserDao entity)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<UserDao>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UserDao> GetByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<UserDao> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UserDao entity)
    {
        throw new NotImplementedException();
    }
}
