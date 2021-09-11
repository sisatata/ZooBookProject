using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooBook.Application.Commands;
using ZooBook.Application.Queries;

namespace ZooBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController<EmployeeController>
    {
        #region Queries

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _mediator.Send(new GetAllEmployeesQuery { });
            return Ok(data);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var data = await _mediator.Send(new GetEmployeeByIdQuery { Id = Id }); ;
            return Ok(data);
        }
        #endregion

        #region Commands
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] CreateEmployeeCommand employee)
        {
            var data = await _mediator.Send(employee);
            return Ok(data);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeCommand employee)
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
        #endregion

    }
}
