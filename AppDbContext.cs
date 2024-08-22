using BackendApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
// what is going
namespace BackendApp.Data
{
    public class AppDbContext : IdentityDbContext<UserModel>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<PostModel> PostModel { get; set; }
        // public DbSet<TestModel> TestModel { get; set; }
        public DbSet<UserModel> UserModel { get; set; }
        public DbSet<CategoryModel> CategoryModel { get; set; }
        public DbSet<LocationModel> LocationModel { get; set; }

        // public DbSet<TestOptions> TestOptions {get ;set;}
        public DbSet<TestModel> QuestionModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure cascading delete for TestOptions when a PostModel is deleted
            modelBuilder
                .Entity<PostModel>()
                .HasMany(p => p.Options)
                .WithOne(o => o.PostModel)
                .HasForeignKey(o => o.PostModelId)
                .OnDelete(DeleteBehavior.Cascade);

            // Other model configurations...
        }
    }
}
