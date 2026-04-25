using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Mini_ERP.Application.Features.Commands.Employee.CreateEmployee;
using Mini_ERP.Application.Features.Queries.Employee.GetEmployee;
using Mini_ERP.Application.Features.Commands.Employee.UpdateEmployee;
using Mini_ERP.Application.Features.Commands.Employee.RemoveEmployee;
namespace Mini_ERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(CreateEmployeeCommandRequest createEmployeeCommandRequest)
        {
            var response = await _mediator.Send(createEmployeeCommandRequest);
            if(response.Success)
                return Ok(response);
            return BadRequest(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployees([FromQuery] GetEmployeeQueryRequest getEmployeeQueryRequest)
        {
            var response = await _mediator.Send(getEmployeeQueryRequest);
            if (response.Success)
                return Ok(response);
            return BadRequest(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmployees(UpdateEmployeeCommandRequest updateEmployeeCommandRequest)
        {
            var response = await _mediator.Send(updateEmployeeCommandRequest);
            if (response.Success)
                return Ok(response);
            return BadRequest(response);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveEmployee([FromQuery] RemoveEmployeeCommandRequest removeEmployeeCommandRequest)
        {
            var response = await _mediator.Send(removeEmployeeCommandRequest);
            if (response.Success)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
