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
        public DbSet<TestModel> Tests { get; set; }
        public DbSet<TestOptionModel> TestOptions { get; set; } // Fixed pluralization for consistency
        public DbSet<ContactModel> ContactsUs { get; set; } // Renamed for better clarity
        public DbSet<ClassModel> Classes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define relationships and constraints

            // One-to-Many: Category -> Courses
            modelBuilder.Entity<CategoryModel>()
                .HasMany(c => c.Courses)
                .WithOne(co => co.Category)
                .HasForeignKey(co => co.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-Many: Course -> Classes
            modelBuilder.Entity<ClassModel>()
                .HasOne(c => c.Course)
                .WithMany(co => co.Classes)
                .HasForeignKey(c => c.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-Many: Class -> Tests
            modelBuilder.Entity<TestModel>()
                .HasOne(t => t.Class)
                .WithMany(c => c.Tests)
                .HasForeignKey(t => t.ClassId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-Many: Test -> TestOptions
            modelBuilder.Entity<TestOptionModel>()
                .HasOne(to => to.Test)
                .WithMany(t => t.Options)
                .HasForeignKey(to => to.TestId)
                .OnDelete(DeleteBehavior.Cascade);

            // Many-to-One: Course -> User (Creator)
            modelBuilder.Entity<CourseModel>()
                .HasOne(c => c.Creator)
                .WithMany(u => u.Courses)
                .HasForeignKey(c => c.CreatorId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent deletion of users with courses
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
