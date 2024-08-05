using System.Text;
using BackendApp.Data;
using BackendApp.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        $"Server=tcp:neebooh-school-project-ap-server.database.windows.net,1433;Initial Catalog=school-project-neeboh-api-server;Persist Security Info=False;User ID=admin_user_muyi;Password=fedgac11451;",
        new MySqlServerVersion(new Version(8, 0, 26)),
        mySqlOptions => mySqlOptions.EnableRetryOnFailure()
    )
);


builder.Services.AddScoped<IPasswordHasher<UserModel>, PasswordHasher<UserModel>>();

builder.Services.AddAuthorization();
builder.Services.AddScoped<PostService>();
builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<UsersService>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<IFileUploadService, FileUploadService>();

builder
    .Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])
            )
        };
    });

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

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
// testing