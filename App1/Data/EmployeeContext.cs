using App1.Models;
using Microsoft.EntityFrameworkCore;

namespace App1.Data;
public class EmployeeContext : DbContext
{
    public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var id = 1;
        foreach (var employee in InitialSeed.Seed("en", 25))
        {
            employee.Id = id++;
            modelBuilder.Entity<Employee>().HasData(employee);
        }
    }

    internal DbSet<Employee> Employees { get; set; }
}
