var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Identity/Account/Login");
        options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Identity/Account/Login");
    });

//DI.
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
builder.Services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area=Customer}/{controller=Home}/{action=Index}"
    );
});

//Create Db if not exist.
CreateDataBaseShemas();
SeedDb();
CreateStoreProcedure();
CreateTriggers();


app.Run();

void CreateDataBaseShemas()
{
    MySqlConnection connection = new MySqlConnection(builder?.Configuration.GetConnectionString("Sys"));

    string script = File.ReadAllText("wwwroot/Queries/CreateComputerStoreDbShemas.sql");

    MySqlCommand command = new MySqlCommand(script, connection);

    try
    {
        connection.Open();
        command.ExecuteNonQuery();
    }
    catch (Exception)
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

void CreateStoreProcedure()
{
    MySqlConnection connection = new MySqlConnection(builder?.Configuration.GetConnectionString("ComputerStore"));

    string script = File.ReadAllText("wwwroot/Queries/CreateStoredProcedures.sql");

    MySqlCommand command = new MySqlCommand(script, connection);

    try
    {
        connection.Open();
        command.ExecuteNonQuery();
    }
    catch (Exception)
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

void CreateTriggers()
{
    MySqlConnection connection = new MySqlConnection(builder?.Configuration.GetConnectionString("ComputerStore"));

    string script = File.ReadAllText("wwwroot/Queries/CreateTriggers.sql");

    MySqlCommand command = new MySqlCommand(script, connection);

    try
    {
        connection.Open();
        command.ExecuteNonQuery();
    }
    catch (Exception)
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

void SeedDb()
{
    MySqlConnection connection = new MySqlConnection(builder?.Configuration.GetConnectionString("ComputerStore"));

    string script = File.ReadAllText("wwwroot/Queries/SeedDb.sql");

    MySqlCommand seedCommand = new MySqlCommand(script, connection);

    try
    {
        connection.Open();
        seedCommand.ExecuteNonQuery();
    }
    catch (Exception)
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