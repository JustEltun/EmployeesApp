using EmployeesApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeesApp.Data;

public class DataContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<ProgrammingLang> ProgrammingLangs { get; set; }
    public DbSet<EmployeeWorkExperience> WorkExperiences { get; set; }
    
    
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>().HasData(
            new Department
            {
                ID = 1,
                Name = "Frontend",
                Floor = 1
            },
            new Department
            {
                ID = 2,
                Name = "Backend",
                Floor = 2
            },
            new Department
            {
                ID = 3,
                Name = "DB",
                Floor = 3
            }
        );

        modelBuilder.Entity<ProgrammingLang>().HasData(
            new ProgrammingLang
            {
                ID = 1,
                Name = "C#"
            },
            new ProgrammingLang
            {
                ID = 2,
                Name = "JavaScript"
            },
            new ProgrammingLang
            {
                ID = 3,
                Name = "Python"
            },
            new ProgrammingLang
            {
                ID = 4,
                Name = "T-SQL"
            }
        );
    }
    
}
