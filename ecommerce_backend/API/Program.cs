using API.ServicesExtension;
using Microsoft.EntityFrameworkCore;
using Repository.Data;

var builder = WebApplication.CreateBuilder(args);

// Register API Controller
builder.Services.AddControllers();

// Register Required Services For Swagger In Extension Method
builder.Services.AddSwaggerServices();

// Identity Store Context
builder.Services.AddDbContext<IdentityContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
});

// Register Database Connection
builder.Services.AddDatabaseConnections();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // -- Add Swagger Middelwares In Extension Method
    app.UseSwaggerMiddleware();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();