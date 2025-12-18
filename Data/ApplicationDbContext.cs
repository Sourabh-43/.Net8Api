using EmployeManagementApi1.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeManagementApi1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<AppUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fix decimal precision warning for Salary
            modelBuilder.Entity<AppUser>()
                .Property(u => u.Salary)
                .HasPrecision(18, 2); // (precision, scale)

            // Optional but recommended
            modelBuilder.Entity<AppUser>()
                .Property(u => u.YearsOfExperience)
                .HasColumnType("int");
        }
    }
}
