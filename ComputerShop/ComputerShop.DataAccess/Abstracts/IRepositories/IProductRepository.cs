namespace ComputerShop.DataAccess.Abstracts.IRepositories;

public interface IProductRepository
{
    Task<Product> GetProductByIDAsync(int ID);
    Task<List<Product>> GetProductsRangeAsync(int from, int to, string search);
    Task<long> GetProductsCountAsync();
    Task<int> AddProductAsync(Product product);
    Task UpdateProductAsync(Product product);
    Task RemoveProductAsync(int ID);
    Task AddCharactericticAsync(Characteristic characteristic);
    Task<List<Characteristic>> GetCharactericticsAsync(int productID);
}
