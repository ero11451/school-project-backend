using Microsoft.EntityFrameworkCore;
using BackendApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BackendApp.Data
{
    public class AppDbContext : IdentityDbContext<UserModel>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<PostModel> PostModel { get; set; }
        public DbSet<TestModel> TestModel { get; set; }
        public DbSet<UserModel> UserModel { get; set; }
        public DbSet<CategoryModel> CategoryModel {get ;set;}
        public DbSet<LocationModel> LocationModel {get ;set;}
        // public DbSet<TestOptions> TestOptions {get ;set;}
        public DbSet<TestModel> QuestionModel {get ;set;}
    }
}
