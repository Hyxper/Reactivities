using API.Extensions;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("CorsPolicy");
app.UseAuthorization();
app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider; //creates a scope for the services via the service provider object

try
{
    var context = services.GetRequiredService<DataContext>(); //get me my database connection, in this case "DataContext"
    context.Database.Migrate(); //apply any pending migrations to the database
    await Seed.SeedData(context); //seed the database with some data
}
catch (Exception ex)
{
    var logger = services.GetService<ILogger<Program>>();
    if(logger != null)
    {
        logger.LogError(ex, "An error occurred during migration");
    }
}

app.Run();
