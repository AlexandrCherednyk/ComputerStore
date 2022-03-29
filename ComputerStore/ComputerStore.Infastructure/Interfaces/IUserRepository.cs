using ComputerStore.Infastructure.DAOs.Identity;
using ComputerStore.Infastructure.Interfaces.Base;

namespace ComputerStore.Infastructure.Repositories;
public interface IUserRepository : IRepository<UserDao>
{
    Task<UserDao> GetByEmailAsync(string email);
}
