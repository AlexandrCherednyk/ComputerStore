namespace ComputerShop.DataAccess.Abstracts.IRepositories;

public interface IReportRepository
{
    Task AddSalesAsync(int productID, int count, decimal? totalPrice, int userID);
    Task AddPurchasesAsync(int productID, int count);

    Task<List<Output>> GetSalesAsync();
    Task<List<Input>> GetPurchasesAsync();
}

