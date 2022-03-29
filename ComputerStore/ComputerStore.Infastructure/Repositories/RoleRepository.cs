using ComputerStore.Infastructure.DAOs.Identity;

namespace ComputerStore.Infastructure.Repositories;
public class RoleRepository : IRoleRepository
{
    public Task<RoleDao> AddAsync(RoleDao entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(RoleDao entity)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<RoleDao>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<RoleDao> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(RoleDao entity)
    {
        throw new NotImplementedException();
    }
}
