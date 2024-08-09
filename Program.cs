using BackendApp.Data;
using BackendApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BackendApp.Models;
using backend_app.Service;
using BackendApp.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
  
    options.AddPolicy(
        "CorsPolicy",
        corsPolicyBuilder =>
        {
            corsPolicyBuilder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
        }
    );
});
// this 
// var connectionString = "Server=schooldb.mysql.database.azure.com;User=admin_user_muyi;Password=fedgac11451...;Database=neebohdb;";
// Configure DbContext with MySQL
// Console.Write(builder.Configuration["DBConnectionStrings:Connection"]);

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseMySql(
        builder.Configuration["DBConnectionStrings:Connection"],
        new MySqlServerVersion(new Version(8, 0, 26)),
        mySqlOptions => mySqlOptions.EnableRetryOnFailure(
            maxRetryCount: 2,
            maxRetryDelay: TimeSpan.FromSeconds(30),
            errorNumbersToAdd: null
        )
    )
);

builder.Services.AddScoped<IPasswordHasher<UserModel>, PasswordHasher<UserModel>>();

builder.Services.AddAuthorization();
builder.Services.AddScoped<PostService>();
builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<UsersService>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<IFileUploadService, FileUploadService>();

builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorizationBuilder();

builder.Services.AddIdentity<UserModel, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders()
    .AddApiEndpoints();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseCors("CorsPolicy");
app.MapIdentityApi<UserModel>();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


