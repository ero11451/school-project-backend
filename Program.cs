using BackendApp.Models;
using BackendApp.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add essential services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS Configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", corsPolicyBuilder =>
    {
        corsPolicyBuilder.WithOrigins(
                "https://neeboh.com", 
                "http://localhost:5173"
            )
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});


// Add Identity services
builder.Services.AddIdentity<UserModel, IdentityRole>()
    .AddEntityFrameworkStores<DataBaseContext>()
    .AddDefaultTokenProviders();

// Configure JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
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
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});



// Logging Configuration
builder.Services.AddLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
    logging.SetMinimumLevel(LogLevel.Debug);
});

// Add Custom Services
builder.Services.AddScoped<PostService>();
builder.Services.AddScoped<CourseService>();
builder.Services.AddScoped<UsersService>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<IFileUploadService, FileUploadService>();

// Configure JSON Serialization
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

// Configure DbContext with MySQL
builder.Services.AddDbContext<DataBaseContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DevConnection"),
        new MySqlServerVersion(new Version(8, 0, 36))
    )
);





var app = builder.Build();

// Middleware for Development Environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty;
    });
}



// CORS Policy
app.UseCors("CorsPolicy");


app.UseMiddleware<RequestLoggingMiddleware>();

// HTTPS, Static Files, and Routing
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Map Controllers
app.MapControllers();


app.UseAuthentication();
app.UseAuthorization();

app.Run();
