using API.Errors;
using API.Middlewares;
using API.ServicesExtension;
using API.Settings;
using Core.Entities.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Identity;

#region Update Database Problems And Solution
// To Update Database You Should Do Two Things 
// 1. Create Object From DbContext
//StoreDbContext _storeDbContext = new StoreDbContext();
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

// Add Identity Configurations
builder.Services.AddIdentityConfigurations(builder.Configuration);

// Add JWT Configurations
builder.Services.AddJWTConfigurations(builder.Configuration);

// This Method Has All Application Services
builder.Services.AddApplicationServices();

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

#region Validation Error - Bad Request
// -- Validation Error (Bad Request) 
// --- First: We need to bring options which have InvalidModelState
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    // --- then we need all data (actionContext) of action has validation error
    options.InvalidModelStateResponseFactory = (actionContext) =>
    {
        // --- then we bring ModelState: Dictionary key/value pair for each parameter, and value has property Errors Array have all errors
        // --- and we use where to bring dictionary key/value pair which is value has errors 
        var errors = actionContext.ModelState.Where(P => P.Value.Errors.Count() > 0)
        // --- then we use SelectMany to make one array of all errors  
        .SelectMany(P => P.Value.Errors)
        // --- then we use Select to bring from errors just ErrorMessages
        .Select(E => E.ErrorMessage)
        .ToArray();
        // --- then we insert this errors to the class we made
        var validationErrorResponse = new ApiValidationErrorResponse()
        {
            Errors = errors
        };
        // then return it :)
        return new BadRequestObjectResult(validationErrorResponse);
    };
});
#endregion

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
// --> Bring Object Of UserManager
var _userManager = services.GetRequiredService<UserManager<AppUser>>();
// --> Bring Object Of RoleManager
var _roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
// --> Bring Object Of ILoggerFactory For Good Show Error In Console    
var loggerFactory = services.GetRequiredService<ILoggerFactory>();

try
{
    // Migrate IdentityContext
    await _identiyContext.Database.MigrateAsync();
    // Seeding Data For IdentityContext
    await IdentityContextSeeding.SeedIdentityData(_userManager, _roleManager);
}
catch (Exception ex)
{
    var logger = loggerFactory.CreateLogger<Program>();
    logger.LogError(ex, "an error has been occured during apply the migration!");
}

#endregion

#region Configure the Kestrel pipeline

// -- Server Error Middleware (we catch it in class ExceptionMiddleware)
app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    // -- Add Swagger Middelwares In Extension Method
    app.UseSwaggerMiddleware();
}

// -- To this application can resolve on any static file like (html, wwwroot, etc..)
app.UseStaticFiles();

// -- To Redirect Any Http Request To Https
app.UseHttpsRedirection();

// -- Error Not Found End Point: Here When This Error Thrown: It Redirect To This End Point in (Controller: Errors)
app.UseStatusCodePagesWithReExecute("/error/{0}");

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

app.UseAuthentication();

app.UseAuthorization();

#endregion

app.Run();