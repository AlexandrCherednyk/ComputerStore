var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//Create Db if not exist.
SeedDataBase();

app.Run();

void SeedDataBase()
{
    MySqlConnection connection = new MySqlConnection(builder?.Configuration.GetConnectionString("Sys"));

    string script = File.ReadAllText("Queries/SeedComputerStoreDb.sql");

    MySqlCommand seedCommand = new MySqlCommand(script, connection);

    try
    {
        connection.Open();
        seedCommand.ExecuteNonQuery();
    }
    catch (Exception ex)
    {
        //TODO: logging.
    }
    finally
    {
        if (connection.State == ConnectionState.Open)
        {
            connection.Close();
        }
    }
}
