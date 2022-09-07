using Microsoft.AspNetCore.Mvc;

namespace EmployeeRecordBook.Api.Controllers
{
   [Route("v{version:apiVersion}/[controller]")]
   [ApiController]
   public class ApiControllerBase : ControllerBase
   {

   }
}
