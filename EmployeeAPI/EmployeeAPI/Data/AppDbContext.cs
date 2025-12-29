using EmployeeAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Department> Departments { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasKey(e => e.CodeEmployee);
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Leader)
                .WithMany()
                .HasForeignKey(e => e.CodeLeader)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Employee>()
                .Property(e => e.Salary)
                .HasColumnType("decimal(18,2)");


            modelBuilder.Entity<Group>().HasKey(g => g.CodeGroup);
            modelBuilder.Entity<Group>()
                .HasMany(g => g.Employees)
                .WithOne(e => e.Group)
                .HasForeignKey(e => e.CodeGroup);
            modelBuilder.Entity<Group>()
                .HasOne(g => g.Department)
                .WithMany()
                .HasForeignKey(g => g.CodeDepartment);
            
            
            modelBuilder.Entity<Department>().HasKey(d => d.CodeDepartment);
        }
    }
}
