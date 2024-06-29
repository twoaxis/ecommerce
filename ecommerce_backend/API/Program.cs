using API.ServicesExtension;
using Microsoft.EntityFrameworkCore;
using Repository.Data;

#region Update Database Problems And Solution
// To Update Database You Should Do Two Things 
// 1. Create Object From DbContext
//--- StoreDbContext _storeDbContext = new StoreDbContext();
// 2. Migrate It
//--- await _storeDbContext.Database.MigrateAsync();
// But To Create Instanse From DbContext You Should Have Non Parameterized Constructor In StoreContext Class
// But We Not Work With Non Parameterized constractor because if we do it we should override on configuring
// And Then We Not Working With Dependency Injection So That Solution Not Working !!
// And We Try Another Solution Like Ask Clr To Create This Instance Implicitly Also This Solution Not Working !!
// Because To Ask Clr You Need Constractor And If We Use Normal Program Constractor Not Working
// Because Normal Constractor Work If You Need Object From Class 
// And Function Main Is Static, So We Need To Ask Clr In Static Consractor
// And If We Used Program Static Constractor (Static Constractor Work Just One Time: Before The First Using Of Class)
// So Static Constractor Work Before Main
// And We Configure DbContext Services In Main Function 
// So The Only Solution Is: (I Written It Below)
#endregion

var builder = WebApplication.CreateBuilder(args);

#region Add services to the container

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

#endregion

var app = builder.Build();

#region Update Database With Using Way And Seeding Data

// We Said To Update Database You Should Do Two Things (1. Create Instance From DbContext 2. Migrate It)

// To Ask Clr To Create Instance Explicitly From Any Class
//    1 ->  Create Scope (Life Time Per Request)
using var scope = app.Services.CreateScope();
//    2 ->  Bring Service Provider Of This Scope
var services = scope.ServiceProvider;

// --> Bring Object Of IdentityContext For Update His Migration
var _identiyContext = services.GetRequiredService<IdentityContext>();
// --> Bring Object Of ILoggerFactory For Good Show Error In Console    
var loggerFactory = services.GetRequiredService<ILoggerFactory>();

try
{
    // Migrate IdentityContext
    await _identiyContext.Database.MigrateAsync();
}
catch (Exception ex)
{
    var logger = loggerFactory.CreateLogger<Program>();
    logger.LogError(ex, "an error has been occured during apply the migration!");
}

#endregion

#region Configure the Kestrel pipeline

if (app.Environment.IsDevelopment())
{
    // -- Add Swagger Middelwares In Extension Method
    app.UseSwaggerMiddleware();
}

// -- To this application can resolve on any static file like (html, wwwroot, etc..)
app.UseStaticFiles();

// -- To Redirect Any Http Request To Https
app.UseHttpsRedirection();

/// -- In MVC We Used This Way For Routing
///app.UseRouting(); // -> we use this middleware to match request to an endpoint
///app.UseEndpoints  // -> we use this middleware to excute the matched endpoint
///(endpoints =>  
///{
///    endpoints.MapControllerRoute(
///        name: "default",
///        pattern: "{controller}/{action}"
///        );
///});
/// -- But We Use MapController Instead Of It Because We Create Routing On Controller Itself
app.MapControllers(); // -> we use this middleware to talk program that: your routing depend on route written on the controller

#endregion

app.Run();