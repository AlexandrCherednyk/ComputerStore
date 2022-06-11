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

                int roleID = (int)reader.GetValue(3);
                string roleName = (string)reader.GetValue(4);

                user = new()
                {
                    ID = userID,
                    Email = userEmail,
                    PasswordHash = userPasswordHash,
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

            command.Parameters.Add(emailParam);
            command.Parameters.Add(passwordHashParam);

            await command.ExecuteScalarAsync();
        }
    }
}
