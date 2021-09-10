using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooBook.Application.Commands;

namespace ZooBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController<EmployeeController>
    {
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] CreateEmployeeCommand employee)
        {
            var data = await _mediator.Send(employee);
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid Id )
        {
            var data = await _mediator.Send(new DeleteEmployeeCommand { Id = Id }) ;
            return Ok(data);
        }
    }
}
