using EmployeeRecordBook.Core.Dtos;
using EmployeeRecordBook.Core.Entities;
using EmployeeRecordBook.Core.Infrastructure.Repositories;
using EmployeeRecordBook.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRecordBook.Infrastructure.Repositories.EntityFramework
{
   public class EmployeeRepository : IEmployeeRepository
   {
      private readonly EmployeeContext _employeeContext;
      public EmployeeRepository(EmployeeContext employeeContext)
      {
         _employeeContext = employeeContext;
      }
      public async Task<Employee> CreateAsync(Employee employee)
      {
         _employeeContext.Employees.Add(employee);
         await _employeeContext.SaveChangesAsync();
         return employee;
      }
      public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync()
      {
         var employeeQuery = (from employee in _employeeContext.Employees.Include(e => e.Department)
                              select new EmployeeDto
                              {
                                 Id = employee.Id,
                                 Name = employee.Name,
                                 Salary = employee.Salary,
                                 DepartmentName = employee.Department.Name
                              }).AsNoTracking();
         //return await _employeeContext.Employees.ToListAsync();
         return await employeeQuery.ToListAsync();  // Executes DB Query in DB and Get results.
      }
      public async Task<Employee> GetEmployeeAsync(int employeeId) => await _employeeContext.Employees.FindAsync(employeeId);
      public async Task<bool> UpdateAsync(int employeeId, Employee employee)
      {
         var employeeToBeUpdated = await GetEmployeeAsync(employeeId);
         if (employeeToBeUpdated is null)
            return false;
         //var employeeToBeUpdated = new Employee { Id = employeeId };
         employeeToBeUpdated.Name = employee.Name;
         employeeToBeUpdated.Email = employee.Email;
         employeeToBeUpdated.Salary = employee.Salary;
         employeeToBeUpdated.DepartmentId = employee.DepartmentId;
         //_employeeContext.Entry(employeeToBeUpdated).State = EntityState.Modified;
         _employeeContext.Employees.Update(employeeToBeUpdated);
         var result = _employeeContext.SaveChanges();  // Actual execution of the command happens here with DB.
         return result > 0;
      }
      public async Task<bool> DeleteAsync(int employeeId)
      {
         var employeeToBeDeleted = await GetEmployeeAsync(employeeId);
         if(employeeToBeDeleted is null)
            return false;
         _employeeContext.Employees.Remove(employeeToBeDeleted);
         var result = await _employeeContext.SaveChangesAsync();
         return result > 0;
      }
   }
}
