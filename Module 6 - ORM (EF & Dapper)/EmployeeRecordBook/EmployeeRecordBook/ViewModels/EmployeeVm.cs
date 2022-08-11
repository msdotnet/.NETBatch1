﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecordBook.ViewModels
{
   internal class EmployeeVm
   {
      public int Id { get; set; }
      public string Name { get; set; } = null!;
      public string Email { get; set; } = null!;
      public decimal Salary { get; set; }
      public int DepartmentId { get; set; }
   }
}
