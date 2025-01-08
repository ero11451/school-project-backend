using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BackendApp.Models
{
    public class DataBaseContext : IdentityDbContext<UserModel>
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options) { }

        // Define DbSets for your entities
        public DbSet<CourseModel> Courses { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<OptionsModel> Options { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // One-to-many relationship between Category and Courses
            modelBuilder.Entity<CategoryModel>()
                .HasMany(c => c.Courses)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-many relationship between Course and Options
            modelBuilder.Entity<CourseModel>()
                .HasMany(c => c.Options)
                .WithOne(o => o.Course)
                .HasForeignKey(o => o.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Optional logging configuration
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
            }
        }
    }
}
