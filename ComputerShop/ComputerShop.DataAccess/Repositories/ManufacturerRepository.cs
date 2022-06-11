﻿namespace ComputerShop.DataAccess.Repositories;

public class ManufacturerRepository : IManufacturerRepository
{
    public async Task AddManufacturer(string name)
    {
        string procedure = StoredProcedures.ADD_MANUFACTURER;

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
