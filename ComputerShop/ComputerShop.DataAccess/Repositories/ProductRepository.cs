namespace ComputerShop.DataAccess.Repositories;

public class ProductRepository : IProductRepository
{
    public async Task<Product> GetProductByIDAsync(int ID)
    {
        Product product = new();

        string procedure = StoredProcedures.GET_PRODUCT;

        using (MySqlConnection connection = new(DbContext.CONNECTION))
        {
            await connection.OpenAsync();

            MySqlCommand command = new(procedure, connection);

            command.CommandType = CommandType.StoredProcedure;

            MySqlParameter IDParam = new()
            {
                ParameterName = "ID",
                Value = ID
            };

            command.Parameters.Add(IDParam);

            MySqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                //Read the first record in db.
                reader.Read();

                int productID = (int)reader.GetValue(0);
                string name = (string)reader.GetValue(1);
                string description = (string)reader.GetValue(2);
                int typeID = (int)reader.GetValue(3);
                string typeName = (string)reader.GetValue(4);
                int manufacturerID = (int)reader.GetValue(5);
                string manufacturerName = (string)reader.GetValue(6);
                decimal price = (decimal)reader.GetValue(7);
                int count = (int)reader.GetValue(8);
                string pathToFile = (string)reader.GetValue(9);

                ProductType type = new()
                {
                    ID = typeID,
                    Name = typeName,
                };

                Manufacturer manufacturer = new()
                {
                    ID = manufacturerID,
                    Name = manufacturerName,
                };

                product = new()
                {
                    ID = productID,
                    Name = name,
                    Description = description,
                    Type = type,
                    Manufacturer = manufacturer,
                    Price = price,
                    Count = count,
                    PathToFile = pathToFile,
                };

            }

            reader.Close();
        }

        return product;
    }

    public async Task<int> AddProductAsync(Product product)
    {
        string procedure = StoredProcedures.ADD_PRODUCT;

        int productID = 0;

        using (MySqlConnection connection = new(DbContext.CONNECTION))
        {
            await connection.OpenAsync();

            MySqlCommand command = new(procedure, connection);

            command.CommandType = CommandType.StoredProcedure;

            MySqlParameter IDParam = new()
            {
                ParameterName = "ID",
                DbType = DbType.Int32,
                Direction = ParameterDirection.Output,
            };

            MySqlParameter nameParam = new()
            {
                ParameterName = "name",
                Value = product.Name,
            };

            MySqlParameter descriptionParam = new()
            {
                ParameterName = "description",
                Value = product.Description,
            };

            MySqlParameter typeIDParam = new()
            {
                ParameterName = "typeID",
                Value = product.Type.ID,
            };

            MySqlParameter manufacturerIDParam = new()
            {
                ParameterName = "manufacturerID",
                Value = product.Manufacturer.ID,
            };

            MySqlParameter priceParam = new()
            {
                ParameterName = "price",
                Value = product.Price,
            };

            MySqlParameter countParam = new()
            {
                ParameterName = "count",
                Value = product.Count,
            };

            MySqlParameter pathToFIleParam = new()
            {
                ParameterName = "pathToFile",
                Value = product.PathToFile,
            };

            command.Parameters.Add(IDParam);
            command.Parameters.Add(nameParam);
            command.Parameters.Add(descriptionParam);
            command.Parameters.Add(typeIDParam);
            command.Parameters.Add(manufacturerIDParam);
            command.Parameters.Add(priceParam);
            command.Parameters.Add(countParam);
            command.Parameters.Add(pathToFIleParam);

            await command.ExecuteScalarAsync();

            productID = (int)command.Parameters["ID"].Value;
        }

        return productID;
    }

    public async Task<List<Product>> GetProductsRangeAsync(int from = 0, int to = 14, string search = "")
    {
        List<Product> products = new();

        string procedure = StoredProcedures.GET_PRODUCT_RANGE;

        using (MySqlConnection connection = new(DbContext.CONNECTION))
        {
            await connection.OpenAsync();

            MySqlCommand command = new(procedure, connection);

            command.CommandType = CommandType.StoredProcedure;

            MySqlParameter fromParam = new()
            {
                ParameterName = "from",
                Value = from,
            };

            MySqlParameter toParam = new()
            {
                ParameterName = "to",
                Value = to,
            };

            MySqlParameter searchParam = new()
            {
                ParameterName = "search",
                Value = search,
            };

            command.Parameters.Add(fromParam);
            command.Parameters.Add(toParam);
            command.Parameters.Add(searchParam);

            MySqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int productID = (int)reader.GetValue(0);
                    string name = (string)reader.GetValue(1);
                    string description = (string)reader.GetValue(2);
                    int typeID = (int)reader.GetValue(3);
                    string typeName = (string)reader.GetValue(4);
                    int manufacturerID = (int)reader.GetValue(5);
                    string manufacturerName = (string)reader.GetValue(6);
                    decimal price = (decimal)reader.GetValue(7);
                    int count = (int)reader.GetValue(8);
                    string pathToFile = (string)reader.GetValue(9);

                    ProductType type = new()
                    {
                        ID = typeID,
                        Name = typeName,
                    };

                    Manufacturer manufacturer = new()
                    {
                        ID = manufacturerID,
                        Name = manufacturerName,
                    };

                    Product product = new()
                    {
                        ID = productID,
                        Name = name,
                        Description = description,
                        Type = type,
                        Manufacturer = manufacturer,
                        Price = price,
                        Count = count,
                        PathToFile = pathToFile,
                    };
                    
                    products.Add(product);
                }
            }

            reader.Close();
        }

        return products;
    }

    public async Task<long> GetProductsCountAsync()
    {
        long count = 0;

        string procedure = StoredProcedures.PRODUCT_COUNT;

        using (MySqlConnection connection = new(DbContext.CONNECTION))
        {
            await connection.OpenAsync();

            MySqlCommand command = new(procedure, connection);

            command.CommandType = CommandType.StoredProcedure;

            MySqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();

                count = (long)reader.GetValue(0);

            }

            reader.Close();
        }

        return count;
    }

    public async Task UpdateProductAsync(Product product)
    {
        string procedure = StoredProcedures.UPDATE_PRODUCT;

        using (MySqlConnection connection = new(DbContext.CONNECTION))
        {
            await connection.OpenAsync();

            MySqlCommand command = new(procedure, connection);

            command.CommandType = CommandType.StoredProcedure;

            MySqlParameter IDParam = new()
            {
                ParameterName = "ID",
                Value = product.ID,
            };

            MySqlParameter nameParam = new()
            {
                ParameterName = "name",
                Value = product.Name,
            };

            MySqlParameter descriptionParam = new()
            {
                ParameterName = "description",
                Value = product.Description,
            };

            MySqlParameter typeIDParam = new()
            {
                ParameterName = "typeID",
                Value = product.Type.ID,
            };

            MySqlParameter manufacturerIDParam = new()
            {
                ParameterName = "manufacturerID",
                Value = product.Manufacturer.ID,
            };

            MySqlParameter priceParam = new()
            {
                ParameterName = "price",
                Value = product.Price,
            };

            MySqlParameter countParam = new()
            {
                ParameterName = "count",
                Value = product.Count,
            };

            MySqlParameter pathToFIleParam = new()
            {
                ParameterName = "pathToFile",
                Value = product.PathToFile,
            };

            command.Parameters.Add(IDParam);
            command.Parameters.Add(nameParam);
            command.Parameters.Add(descriptionParam);
            command.Parameters.Add(typeIDParam);
            command.Parameters.Add(manufacturerIDParam);
            command.Parameters.Add(priceParam);
            command.Parameters.Add(countParam);
            command.Parameters.Add(pathToFIleParam);

            await command.ExecuteScalarAsync();
        }
    }

    public async Task RemoveProductAsync(int ID)
    {
        string procedure = StoredProcedures.REMOVE_PRODUCT;

        using (MySqlConnection connection = new(DbContext.CONNECTION))
        {
            await connection.OpenAsync();

            MySqlCommand command = new(procedure, connection);

            command.CommandType = CommandType.StoredProcedure;

            MySqlParameter IDParam = new()
            {
                ParameterName = "ID",
                Value = ID,
            };

            command.Parameters.Add(IDParam);

            await command.ExecuteScalarAsync();
        }
    }

    public async Task AddCharactericticAsync(Characteristic characteristic)
    {
        string procedure = StoredProcedures.ADD_CHARACTERISTIC;

        using (MySqlConnection connection = new(DbContext.CONNECTION))
        {
            await connection.OpenAsync();

            MySqlCommand command = new(procedure, connection);

            command.CommandType = CommandType.StoredProcedure;

            MySqlParameter productIDParam = new()
            {
                ParameterName = "productID",
                Value = characteristic.ProductID,
            };

            MySqlParameter nameParam = new()
            {
                ParameterName = "name",
                Value = characteristic.Name,
            };

            MySqlParameter valueParam = new()
            {
                ParameterName = "value",
                Value = characteristic.Value,
            };

            command.Parameters.Add(productIDParam);
            command.Parameters.Add(nameParam);
            command.Parameters.Add(valueParam);

            await command.ExecuteScalarAsync();
        }
    }

    public async Task<List<Characteristic>> GetCharactericticsAsync(int productID)
    {
        List<Characteristic> characteristics = new();

        string procedure = StoredProcedures.GET_CHARACTERISTICS;

        using (MySqlConnection connection = new(DbContext.CONNECTION))
        {
            await connection.OpenAsync();

            MySqlCommand command = new(procedure, connection);

            command.CommandType = CommandType.StoredProcedure;

            MySqlParameter productIDParam = new()
            {
                ParameterName = "productID",
                Value = productID,
            };

            command.Parameters.Add(productIDParam);

            MySqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int ID = (int)reader.GetValue(0);
                    int characteristicProductID = (int)reader.GetValue(1);
                    string name = (string)reader.GetValue(2);
                    string value = (string)reader.GetValue(3);

                    Characteristic characteristic = new()
                    {
                        ID = ID,
                        ProductID = characteristicProductID,
                        Name = name,
                        Value = value,
                    };

                    characteristics.Add(characteristic);
                }
            }

            reader.Close();
        }

        return characteristics;
    }
}
