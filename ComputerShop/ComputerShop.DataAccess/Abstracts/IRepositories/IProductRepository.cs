namespace ComputerShop.DataAccess.Abstracts.IRepositories
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIDAsync(int ID);
        Task<List<Product>> GetProductsRangeAsync(int from, int to);
        Task<long> GetProductsCountAsync();
        Task AddProductAsync(Product product);
    }
}
