﻿using EmployeeRecordBook.Core.Entities;
using EmployeeRecordBook.Core.Infrastructure.Repositories;
using EmployeeRecordBook.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRecordBook.Infrastructure.Repositories
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
      public async Task<IEnumerable<Employee>> GetEmployeesAsync()
      {
         //return await _employeeContext.Employees.ToListAsync();
         var employeeQuery = from employee in _employeeContext.Employees
                             select employee;
         return await employeeQuery.ToListAsync();  // Executes DB Query in DB and Get results.
      }
      public async Task<Employee> GetEmployeeAsync(int employeeId)
      {
         return await _employeeContext.Employees.Where(e => e.EmployeeId == employeeId).FirstOrDefaultAsync();
      }
      public async Task<Employee> UpdateAsync(int employeeId, Employee employee)
      {
         var employeeToBeUpdated = await GetEmployeeAsync(employeeId);
         employeeToBeUpdated.Name = employee.Name;
         employeeToBeUpdated.Email = employee.Email;
         employeeToBeUpdated.Salary = employee.Salary;
         employeeToBeUpdated.DepartmentId = employee.DepartmentId;
         _employeeContext.Employees.Update(employeeToBeUpdated);
         _employeeContext.SaveChanges();  // Actual execution of the command happens here with DB.
         return employeeToBeUpdated;
      }
      public async Task DeleteAsync(int employeeId)
      {
         var employeeToBeDeleted = await GetEmployeeAsync(employeeId);
         _employeeContext.Employees.Remove(employeeToBeDeleted);
         await _employeeContext.SaveChangesAsync();
      }
   }
}