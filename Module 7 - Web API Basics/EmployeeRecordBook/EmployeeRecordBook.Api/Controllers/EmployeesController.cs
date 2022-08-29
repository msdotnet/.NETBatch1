using AutoMapper;
using EmployeeRecordBook.Core.Dtos;
using EmployeeRecordBook.Core.Entities;
using EmployeeRecordBook.Core.Infrastructure.Repositories;
using EmployeeRecordBook.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmployeeRecordBook.Api.Controllers
{
   [Route("[controller]")]
   [ApiController]
   public class EmployeesController : ControllerBase
   {
      private readonly IEmployeeRepository _employeeRepository;
      private readonly ILogger<EmployeesController> _logger;
      private readonly IMapper _mapper;

      public EmployeesController(IEmployeeRepository employeeRepository, ILogger<EmployeesController> logger, IMapper mapper)
      {
         _employeeRepository = employeeRepository;
         _logger = logger;
         _mapper = mapper;
      }


      [HttpGet]
      [ProducesResponseType((int)HttpStatusCode.OK)]
      [ProducesResponseType((int)HttpStatusCode.NotFound)]
      public async Task<ActionResult<IEnumerable<EmployeeDto>>> Get()
      {
         _logger.LogInformation("Getting list of all employees");
         var result = await _employeeRepository.GetEmployeesAsync();
         if (!result.Any())
            return NotFound();
         return Ok(result);
      }

      [HttpGet("{id}")]
      [ProducesResponseType((int)HttpStatusCode.OK)]
      [ProducesResponseType((int)HttpStatusCode.NotFound)]
      public async Task<ActionResult<IEnumerable<Employee>>> Get(int id)
      {
         _logger.LogInformation("Getting list of employee by ID: {id}", id);
         var result = await _employeeRepository.GetEmployeeAsync(id);
         if (result is null)
            return NotFound();
         return Ok(result);
      }


      [HttpPost]
      [ProducesResponseType((int)HttpStatusCode.Created)]
      [ProducesResponseType((int)HttpStatusCode.BadRequest)]
      public async Task<ActionResult<Employee>> Post([FromBody] EmployeeVm employeeVm)
      {
         var employee = _mapper.Map<Employee>(employeeVm);
         var result = await _employeeRepository.CreateAsync(employee);
         return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
      }

      [HttpPut("{id}")]
      [ProducesResponseType((int)HttpStatusCode.NoContent)]
      [ProducesResponseType((int)HttpStatusCode.BadRequest)]
      [ProducesResponseType((int)HttpStatusCode.NotFound)]
      public async Task<ActionResult> Put(int id, [FromBody] EmployeeVm employeeVm)
      {
         if (id <= 0 || id != employeeVm.Id)
         {
            return BadRequest();
         }
         var employee = _mapper.Map<Employee>(employeeVm);
         var result = await _employeeRepository.UpdateAsync(id, employee);
         if (!result)
            return NotFound();
         return NoContent();
      }


      [HttpDelete("{id}")]
      [ProducesResponseType((int)HttpStatusCode.NoContent)]
      [ProducesResponseType((int)HttpStatusCode.NotFound)]
      public async Task<ActionResult> Delete(int id)
      {
         var result = await _employeeRepository.DeleteAsync(id);
         if (!result)
            return NotFound();
         return NoContent();
      }
   }
}
