using ComputerStore.Infastructure.Interfaces.Base;
using ComputerStore.Infastructure.Models.Identity;

namespace ComputerStore.Infastructure.Repositories;
public interface IUserRepository : IRepository<User>
{
    Task<User> GetByEmailAsync(string email);
}
