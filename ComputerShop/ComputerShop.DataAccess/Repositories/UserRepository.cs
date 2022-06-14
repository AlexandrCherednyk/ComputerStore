namespace ComputerShop.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    public async Task<User?> GetUserByEmailAsync(string email)
    {
        User? user = null;

        string procedure = StoredProcedures.GET_USER;

        using (MySqlConnection connection = new(DbContext.CONNECTION))
        {
            await connection.OpenAsync();

            MySqlCommand command = new(procedure, connection);

            command.CommandType = CommandType.StoredProcedure;

            MySqlParameter emailParam = new()
            {
                ParameterName = "email",
                Value = email
            };

            command.Parameters.Add(emailParam);

            MySqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                //Read the first record in db.
                reader.Read();

                int userID = (int)reader.GetValue(0);
                string userEmail = (string)reader.GetValue(1);
                string userPasswordHash = (string)reader.GetValue(2);
                string address = (string)reader.GetValue(3);
                string fullName = (string)reader.GetValue(4);
                
                int roleID = (int)reader.GetValue(5);
                string roleName = (string)reader.GetValue(6);

                user = new()
                {
                    ID = userID,
                    Email = userEmail,
                    PasswordHash = userPasswordHash,
                    Address = address,
                    FullName = fullName,
                };

                user.Role = new()
                {
                    ID = roleID,
                    Name = roleName,
                };
            }

            reader.Close();
        }

        return user;
    }

    public async Task AddUserAsync(User user)
    {
        string procedure = StoredProcedures.ADD_USER;

        using (MySqlConnection connection = new(DbContext.CONNECTION))
        {
            await connection.OpenAsync();

            MySqlCommand command = new(procedure, connection);

            command.CommandType = CommandType.StoredProcedure;

            MySqlParameter emailParam = new()
            {
                ParameterName = "email",
                Value = user.Email,
            };

            MySqlParameter passwordHashParam = new()
            {
                ParameterName = "passwordHash",
                Value = user.PasswordHash,
            };

            MySqlParameter addressParam = new()
            {
                ParameterName = "address",
                Value = user.Address,
            };

            MySqlParameter fullNameParam = new()
            {
                ParameterName = "fullName",
                Value = user.FullName,
            };

            command.Parameters.Add(emailParam);
            command.Parameters.Add(passwordHashParam);
            command.Parameters.Add(addressParam);
            command.Parameters.Add(fullNameParam);

            await command.ExecuteScalarAsync();
        }
    }

    public async Task<List<User>> GetUsersAsync()
    {
        List<User> users = new();

        string procedure = StoredProcedures.GET_USER_LIST;

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
                    int userID = (int)reader.GetValue(0);
                    string email = (string)reader.GetValue(1);
                    string passwordHash = (string)reader.GetValue(2);
                    int roleID = (int)reader.GetValue(3);
                    string roleName = (string)reader.GetValue(4);

                    Role role = new()
                    {
                        ID = roleID,
                        Name = roleName,
                    };

                    User user = new()
                    {
                        ID = userID,
                        Email = email,
                        Role = role,
                    };

                    users.Add(user);
                }
            }

            reader.Close();
        }

        return users;
    }

    public async Task UpdateUserAsync(int ID, string address, string fullName)
    {
        string procedure = StoredProcedures.UPDATE_USER;

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

            MySqlParameter addressParam = new()
            {
                ParameterName = "address",
                Value = address,
            };

            MySqlParameter fullNameParam = new()
            {
                ParameterName = "fullName",
                Value = fullName,
            };

            command.Parameters.Add(IDParam);
            command.Parameters.Add(addressParam);
            command.Parameters.Add(fullNameParam);

            await command.ExecuteScalarAsync();
        }
    }

    public async Task RemoveUserAsync(int ID)
    {
        string procedure = StoredProcedures.REMOVE_USER;

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
    
}
