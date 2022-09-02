using AutoMapper;
using EmployeeRecordBook.Api.Specs;
using EmployeeRecordBook.Core.AppSettings;
using EmployeeRecordBook.Core.Dtos;
using EmployeeRecordBook.Core.Entities;
using EmployeeRecordBook.Core.Infrastructure.Repositories;
using EmployeeRecordBook.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;


namespace EmployeeRecordBook.Api.Controllers
{
   [ApiConventionType(typeof(DefaultApiConventions))]
   public class EmployeesController : ApiControllerBase
   {
      private readonly IEmployeeRepository _employeeRepository;
      private readonly ILogger<EmployeesController> _logger;
      private readonly IMapper _mapper;
      private readonly CommonOptions _options;

      public EmployeesController(IEmployeeRepository employeeRepository, ILogger<EmployeesController> logger, IMapper mapper, IOptions<CommonOptions> options)
      {
         _employeeRepository = employeeRepository;
         _logger = logger;
         _mapper = mapper;
         _options = options.Value;
      }
      // GET employees
      [HttpGet]
      [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
      public async Task<ActionResult<IEnumerable<EmployeeDto>>> Get()
      {

         _logger.LogInformation("Getting list of all employees");
         var result = await _employeeRepository.GetEmployeesAsync();
         if (!result.Any())
            return NotFound();
         return Ok(result);
      }
      // GET employees/{id}
      [HttpGet("{id}")]
      [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
      public async Task<ActionResult<IEnumerable<Employee>>> Get(int id)
      {
         _logger.LogInformation("Getting list of employee by ID: {id}", id);
         var result = await _employeeRepository.GetEmployeeAsync(id);
         if (result is null)
            return NotFound();
         return Ok(result);
      }

      // POST employees
      [HttpPost]
      [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
      public async Task<ActionResult<Employee>> Post([FromBody] EmployeeVm employeeVm)
      {
         var employee = _mapper.Map<Employee>(employeeVm);
         var result = await _employeeRepository.CreateAsync(employee);
         return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
      }

      // PUT employees/{id}
      [HttpPut("{id}")]
      [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
      public async Task<ActionResult> Put(int id, [FromBody] EmployeeVm employeeVm)
      {
         if (id <= 0 || id != employeeVm.Id)
         {
            _logger.LogError(new ArgumentOutOfRangeException(nameof(id)), "Id field can't be <= zero OR it doesn't match with model's Id.");
            return BadRequest();
         }
         var employee = _mapper.Map<Employee>(employeeVm);
         var result = await _employeeRepository.UpdateAsync(id, employee);
         if (!result)
            return NotFound();
         return NoContent();
      }

      // DELETE employees/{id}
      [HttpDelete("{id}")]
      [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Delete))]
      public async Task<ActionResult> RemoveEmployee(int id)
      {
         if (id <= 0)
         {
            _logger.LogError(new ArgumentOutOfRangeException(nameof(id)), "Id field can't be {id}", id);
            return BadRequest();
         }
         var result = await _employeeRepository.DeleteAsync(id);
         if (!result)
            return NotFound();
         return NoContent();
      }
   }
}
