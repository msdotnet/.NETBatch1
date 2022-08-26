using System.ComponentModel.DataAnnotations;

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
