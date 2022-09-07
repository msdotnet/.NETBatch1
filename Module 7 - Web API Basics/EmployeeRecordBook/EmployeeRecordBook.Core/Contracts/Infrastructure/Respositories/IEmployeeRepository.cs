using EmployeeRecordBook.Core.Dtos;
using EmployeeRecordBook.Core.Entities;

namespace EmployeeRecordBook.Core.Infrastructure.Repositories
{
   public interface IEmployeeRepository
   {
      Task<Employee> CreateAsync(Employee employee);
      Task<bool> DeleteAsync(int employeeId);
      Task<Employee> GetEmployeeAsync(int employeeId);
      Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(string? name = null);
      Task<bool> UpdateAsync(int employeeId, Employee employee);
   }
}