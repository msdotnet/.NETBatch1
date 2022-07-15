﻿using Qualminds.Ems.Core.Entities;

namespace Qualminds.Ems.Core.Contracts.Infrastructure
{
   public interface IEmployeeService
   {
      public bool InitializeEmployeeService();

      public Employee AddEmployee(Employee employee);

      public IEnumerable<Employee> AddEmployees(IEnumerable<Employee> employees);

      public IEnumerable<Employee> GetEmployees();

      public void DeleteEmployees();
   }
}
