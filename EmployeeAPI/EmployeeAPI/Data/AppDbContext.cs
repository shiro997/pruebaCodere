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
            //creación de las tablas y relaciones
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

            //seeding de datos standard
            modelBuilder.Entity<Department>().HasData(
                new Department() { CodeDepartment = 1, NameDepartment="Dirección general"},
                new Department() { CodeDepartment = 2, NameDepartment="Talento Humano"},
                new Department() { CodeDepartment = 3, NameDepartment="Finanzas"},
                new Department() { CodeDepartment = 4, NameDepartment="Marketing"},
                new Department() { CodeDepartment = 5, NameDepartment="Comercial"},
                new Department() { CodeDepartment = 6, NameDepartment="Operaciones"},
                new Department() { CodeDepartment = 7, NameDepartment="Compras y Logística"},
                new Department() { CodeDepartment = 8, NameDepartment="Tecnología"},
                new Department() { CodeDepartment = 9, NameDepartment="Atención al Cliente"});
            

            modelBuilder.Entity<Group>().HasData(
                new Group() { CodeGroup = 1, NameGroup = "Reclutamiento", CodeDepartment = 2},
                new Group() { CodeGroup = 2, NameGroup = "Compensación y beneficios", CodeDepartment = 2},
                new Group() { CodeGroup = 3, NameGroup = "Capacitación", CodeDepartment = 2},
                new Group() { CodeGroup = 4, NameGroup = "Relaciones Laborales", CodeDepartment = 2},
                new Group() { CodeGroup = 5, NameGroup = "Nominas", CodeDepartment = 2},
                new Group() { CodeGroup = 6, NameGroup = "Gestión de desempeño", CodeDepartment = 2},
                new Group() { CodeGroup = 7, NameGroup = "Contabilidad", CodeDepartment = 3},
                new Group() { CodeGroup = 8, NameGroup = "Tesorería", CodeDepartment = 3},
                new Group() { CodeGroup = 9, NameGroup = "Planificación", CodeDepartment = 3},
                new Group() { CodeGroup = 10, NameGroup = "Gestión de riesgo", CodeDepartment = 3},
                new Group() { CodeGroup = 11, NameGroup = "Impuestos", CodeDepartment = 3},
                new Group() { CodeGroup = 12, NameGroup = "Marketing digital", CodeDepartment = 4},
                new Group() { CodeGroup = 13, NameGroup = "Estrategia de marca", CodeDepartment = 4},
                new Group() { CodeGroup = 14, NameGroup = "Redes sociales", CodeDepartment = 4},
                new Group() { CodeGroup = 15, NameGroup = "Ventas", CodeDepartment = 5},
                new Group() { CodeGroup = 16, NameGroup = "Producción", CodeDepartment = 6},
                new Group() { CodeGroup = 17, NameGroup = "Infraestructura y redes", CodeDepartment = 8},
                new Group() { CodeGroup = 18, NameGroup = "Ciber seguridad", CodeDepartment = 8},
                new Group() { CodeGroup = 19, NameGroup = "Desarrollo e I+D", CodeDepartment = 8},
                new Group() { CodeGroup = 20, NameGroup = "Soporte y helpdesk", CodeDepartment = 8},
                new Group() { CodeGroup = 21, NameGroup = "Data", CodeDepartment = 8},
                new Group() { CodeGroup = 22, NameGroup = "Gestión de proyectos", CodeDepartment = 8},
                new Group() { CodeGroup = 23, NameGroup = "Atención al cliente", CodeDepartment = 9});
        }
    }
}
