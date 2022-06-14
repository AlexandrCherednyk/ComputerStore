namespace ComputerShop.DataAccess.Abstracts.IRepositories;

public interface IManufacturerRepository
{
    Task AddManufacturer(string name);
    Task<List<Manufacturer>> GetManufacturerList();
}
