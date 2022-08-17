// See https://aka.ms/new-console-template for more information
using AutoMapper;
using EmployeeRecordBook.Configurations;
using EmployeeRecordBook.Core.Infrastructure.Repositories;
using EmployeeRecordBook.Infrastructure.Data;
using EmployeeRecordBook.Infrastructure.Repositories.Dapper;
using EmployeeRecordBook.Infrastructure.Repositories.EntityFramework;
using Microsoft.Data.SqlClient;

Console.WriteLine("Hello, World!");

#region Configure and Register AutoMapper
var config = new MapperConfiguration(config => config.AddProfile(new AutoMapperProfile()));
IMapper mapper = config.CreateMapper();

#endregion



//IDepartmentRepository departmentRepository = new DepartmentRepository();
//await departmentRepository.CreateAsync(new Department() { Id = 1, Name = "HR"});


//await departmentRepository.CreateRangeAsync(
//   new List<Department>
//   {
//      new Department() { Id = 2, Name =  "IT" },
//      new Department() { Id = 3, Name = "Accounting" }
//   }
//   );

//using (var employeeContext = new EmployeeContext())
using (var dbConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EmployeeDb"))
{
   //IEmployeeRepository employeeRepository = new EmployeeRepository(employeeContext);
   IEmployeeRepository employeeRepository = new EmployeeDapperRepository(dbConnection);
   //var anilVm = new EmployeeVm
   //{
   //   Name = "Anil Kumar",
   //   Email = "anil@global.com",
   //   Salary = 10000m,
   //   DepartmentId = 1
   //};
   //// Do validation and other formatting on View Model received from UI.

   //// Transform your VM to Entity which can be saved to DB.
   //var amilEntity = mapper.Map<EmployeeVm, Employee>(anilVm);

   //var anil = await employeeRepository.CreateAsync(amilEntity);
   //var sunil = await employeeRepository.CreateAsync(new Employee
   //{
   //   Name = "Sunil Kumar",
   //   Email = "sunil@global.com",
   //   Salary = 10600m,
   //   DepartmentId = 2
   //});
   //Console.WriteLine($"Created Employees: {anil.Id} {anil.Name}, {sunil.Id} {sunil.Name}");

   var employees = await employeeRepository.GetEmployeesAsync();
   Console.WriteLine($"Total Employee Records: {employees.Count()}");

   //var updatedAnilData = new Employee
   //{
   //   Name = "Anil Kumar",
   //   Email = "anil@email.com",
   //   Salary = 12000m,
   //   DepartmentId = 1
   //};
   //var udatedEmployee = await employeeRepository.UpdateAsync(anil.Id, updatedAnilData);
   //Console.WriteLine($"Updated Employee: {udatedEmployee.Id} {udatedEmployee.Name} {udatedEmployee.Email} {udatedEmployee.Salary}");

  // await employeeRepository.DeleteAsync(1);

   var deletedRecord = await employeeRepository.GetEmployeeAsync(1);
   Console.WriteLine($"Was record deleted successfully? {deletedRecord == null: true ? false}");
}
