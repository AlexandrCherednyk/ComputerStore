namespace ComputerShop.DataAccess.Repositories;

public class ReportRepository : IReportRepository
{
    public async Task AddPurchasesAsync(int productID, int count)
    {
        string procedure = StoredProcedures.ADD_INPUT;

        using (MySqlConnection connection = new(DbContext.CONNECTION))
        {
            await connection.OpenAsync();

            MySqlCommand command = new(procedure, connection);

            command.CommandType = CommandType.StoredProcedure;

            MySqlParameter ProductIDParam = new()
            {
                ParameterName = "productID",
                Value = productID
            };

            MySqlParameter CountParam = new()
            {
                ParameterName = "count",
                Value = count
            };

            command.Parameters.Add(ProductIDParam);
            command.Parameters.Add(CountParam);

            await command.ExecuteScalarAsync();
        }
    }

    public async Task AddSalesAsync(int productID, int count, decimal? totalPrice, int userID)
    {
        string procedure = StoredProcedures.ADD_OUTPUT;

        using (MySqlConnection connection = new(DbContext.CONNECTION))
        {
            await connection.OpenAsync();

            MySqlCommand command = new(procedure, connection);

            command.CommandType = CommandType.StoredProcedure;

            MySqlParameter ProductIDParam = new()
            {
                ParameterName = "productID",
                Value = productID
            };

            MySqlParameter CountParam = new()
            {
                ParameterName = "count",
                Value = count
            };

            MySqlParameter TotalPriceParam = new()
            {
                ParameterName = "totalPrice",
                Value = totalPrice
            };

            MySqlParameter UserIDParam = new()
            {
                ParameterName = "userID",
                Value = userID
            };

            command.Parameters.Add(ProductIDParam);
            command.Parameters.Add(CountParam);
            command.Parameters.Add(TotalPriceParam);
            command.Parameters.Add(UserIDParam);

            await command.ExecuteScalarAsync();
        }
    }

    public async Task<List<Input>> GetPurchasesAsync()
    {
        List<Input> inputs = new();

        string procedure = StoredProcedures.GET_INPUT;

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
                    int? productID = reader.GetValue(1) == DBNull.Value ? null : (int)reader.GetValue(1);
                    int count = (int)reader.GetValue(2);
                    DateTime time = (DateTime)reader.GetValue(3);

                    Input input = new()
                    {
                        ID = ID,
                        ProductID = productID,
                        Count = count,
                        Time = time,
                    };

                    inputs.Add(input);
                }
            }

            reader.Close();
        }

        return inputs;
    }

    public async Task<List<Output>> GetSalesAsync()
    {
        List<Output> outputs = new();

        string procedure = StoredProcedures.GET_OUTPUT;

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
                    int? productID = reader.GetValue(1) == DBNull.Value ? null : (int)reader.GetValue(1);
                    int count = (int)reader.GetValue(2);
                    decimal? totalPrice = reader.GetValue(3) == DBNull.Value ? null : decimal.Parse(reader.GetValue(3).ToString());
                    DateTime time = (DateTime)reader.GetValue(4);
                    int? userID = reader.GetValue(5) == DBNull.Value ? null : (int)reader.GetValue(5);

                    Output output = new()
                    {
                        ID = ID,
                        ProductID = productID,
                        Count = count,
                        TotalPrice = totalPrice,
                        Time = time,
                        UserID = userID,
                    };

                    outputs.Add(output);
                }
            }

            reader.Close();
        }

        return outputs;
    }
}
