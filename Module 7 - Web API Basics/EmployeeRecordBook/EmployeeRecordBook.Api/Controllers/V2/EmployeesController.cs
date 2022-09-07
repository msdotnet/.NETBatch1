using AutoMapper;
using EmployeeRecordBook.Api.Specs;
using EmployeeRecordBook.Core.AppSettings;
using EmployeeRecordBook.Core.Dtos;
using EmployeeRecordBook.Core.Entities;
using EmployeeRecordBook.Core.Infrastructure.Repositories;
using EmployeeRecordBook.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;


namespace EmployeeRecordBook.Api.Controllers.V2
{
   [ApiVersion("2.0")]
   [ApiConventionType(typeof(DefaultApiConventions))]
   public class EmployeesController : ApiControllerBase
   {
      private readonly IEmployeeRepository _employeeRepository;
      private readonly ILogger<EmployeesController> _logger;

      public EmployeesController(IEmployeeRepository employeeRepository, ILogger<EmployeesController> logger)
      {
         _employeeRepository = employeeRepository;
         _logger = logger;
      }
      // GET employees
      [HttpGet]
      [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
      public async Task<ActionResult<IEnumerable<EmployeeDto>>> Get(string? name = null)
      {
         _logger.LogInformation("Getting list of all employees");
         var result = await _employeeRepository.GetEmployeesAsync(name);
         if (!result.Any())
            return NotFound();
         return Ok(result);
      }
   }
}
