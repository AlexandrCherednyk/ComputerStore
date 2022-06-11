namespace ComputerShop.DataAccess.Abstracts.IRepositories;

public interface IProductTypeRepository
{
    Task AddProductType(string name);
}
