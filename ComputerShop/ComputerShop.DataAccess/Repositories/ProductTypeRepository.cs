namespace ComputerShop.DataAccess.Repositories;

public class ProductTypeRepository : IProductTypeRepository
{
    public async Task AddProductType(string name)
    {
        string procedure = StoredProcedures.ADD_TYPE;

        using (MySqlConnection connection = new(DbContext.CONNECTION))
        {
            await connection.OpenAsync();

            MySqlCommand command = new(procedure, connection);

            command.CommandType = CommandType.StoredProcedure;

            MySqlParameter NameParam = new()
            {
                ParameterName = "name",
                Value = name
            };

            command.Parameters.Add(NameParam);

            await command.ExecuteScalarAsync();
        }
    }
}
