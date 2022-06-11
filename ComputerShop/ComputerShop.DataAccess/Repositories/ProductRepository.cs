﻿namespace ComputerShop.DataAccess.Repositories;

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

                product.ID = productID;
                product.Name = name;
                product.Description = description;
                product.Type.ID = typeID;
                product.Type.Name = typeName;
                product.Manufacturer.ID = manufacturerID;
                product.Manufacturer.Name = manufacturerName;
                product.Price = price;
                product.Count = count;
            }

            reader.Close();
        }

        return product;
    }

    public async Task AddProductAsync(Product product)
    {
        string procedure = StoredProcedures.ADD_PRODUCT;

        using (MySqlConnection connection = new(DbContext.CONNECTION))
        {
            await connection.OpenAsync();

            MySqlCommand command = new(procedure, connection);

            command.CommandType = CommandType.StoredProcedure;

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

            command.Parameters.Add(nameParam);
            command.Parameters.Add(descriptionParam);
            command.Parameters.Add(typeIDParam);
            command.Parameters.Add(manufacturerIDParam);
            command.Parameters.Add(priceParam);
            command.Parameters.Add(countParam);

            await command.ExecuteScalarAsync();
        }
    }

    public async Task<List<Product>> GetProductsRangeAsync(int from = 0, int to = 14)
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

            command.Parameters.Add(fromParam);
            command.Parameters.Add(toParam);

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
}
