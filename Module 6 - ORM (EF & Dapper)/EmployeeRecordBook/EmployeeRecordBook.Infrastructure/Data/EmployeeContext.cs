using EmployeeRecordBook.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRecordBook.Infrastructure.Data
{
   public class EmployeeContext : DbContext
   {
      public DbSet<Employee> Employees { get; set; }
      public DbSet<Department> Departments { get; set; }

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
         optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=EmployeeDb;Trusted_Connection=True;");
      }
   }
}
