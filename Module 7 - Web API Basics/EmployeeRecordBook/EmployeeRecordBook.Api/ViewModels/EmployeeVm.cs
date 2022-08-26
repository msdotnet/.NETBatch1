using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecordBook.ViewModels
{
   public class EmployeeVm
   {
      public int? Id { get; set; }
      public string Name { get; set; } = null!;
      [Required]
      public string Email { get; set; } = null!;
      public decimal Salary { get; set; }
      public int DepartmentId { get; set; }
   }
}
