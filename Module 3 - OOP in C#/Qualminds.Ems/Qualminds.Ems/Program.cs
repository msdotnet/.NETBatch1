using Qualminds.Ems.Core.Contracts.Infrastructure;
using Qualminds.Ems.Core.Entities;
using Qualminds.Ems.Infrastructure.IO;
using System.Text.Json;

string directoryPath = @"D:\Training\.NETBatch1\Module 3 - OOP in C#\Files";
string fileName = "Employee.csv";
IEmployeeService employeeService = new EmployeeService(Path.Combine(directoryPath, fileName));
Console.WriteLine($"Created {fileName} with predefined headers");

Console.WriteLine("\nAdding Employees:\n");
var afroz = employeeService.AddEmployee(new Employee { Name = "Afroz", Designation = "Asst. Programmer" });
var mallika = employeeService.AddEmployee(new Employee { Name = "Mallika", Designation = "Associate Engineer" });
Console.WriteLine($"Employees added successfully. Here are their newly created IDs: {afroz.Name}: {afroz.Id}, {mallika.Name}: {mallika.Id}");

//employeeService.AddEmployees(new List<Employee>()
//{
//   new Employee { Name="Navneet", Designation = "Programmer"},
//   new Employee { Name = "Bhupal", Designation = "Asst. Programmer" },
//   new Employee { Name = "Parmeshwar", Designation = "Associate Engineer" }
//});


var employees = employeeService.GetEmployees();
var stringifiedEmployees = JsonSerializer.Serialize(employees);
Console.WriteLine("\nList of all Employees:\n");
Console.WriteLine(stringifiedEmployees);

//employeeService.DeleteEmployees();
//Console.WriteLine("\nSuccessfully deleted employees record and file.");