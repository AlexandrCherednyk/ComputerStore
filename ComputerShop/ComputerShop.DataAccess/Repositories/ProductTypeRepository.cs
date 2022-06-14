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

    public async Task<List<ProductType>> GetProductTypeList()
    {
        List<ProductType> types = new();

        string procedure = StoredProcedures.GET_TYPE;

        using (MySqlConnection connection = new(DbContext.CONNECTION))
        {
            await connection.OpenAsync();

            MySqlCommand command = new(procedure, connection);

            command.CommandType = CommandType.StoredProcedure;

            MySqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int ID = (int)reader.GetValue(0);
                    string name = (string)reader.GetValue(1);

                    ProductType type = new()
                    {
                        ID = ID,
                        Name = name,
                    };

                    types.Add(type);
                }
            }

            reader.Close();
        }

        return types;
    }
}
