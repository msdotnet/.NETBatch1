using EmployeeRecordBook.Core.Entities;
using EmployeeRecordBook.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecordBook.Infrastructure.Repositories
{
   public class DepartmentRepository
   {
      public void Create(Department department)
      {
         // Not ideal way to use DB Context instance here, instead use constuctor injection. 
         using (var employeeContext = new EmployeeContext())
         {
            employeeContext.Departments.Add(department);
            employeeContext.SaveChanges();
         }
      }
   }
}
