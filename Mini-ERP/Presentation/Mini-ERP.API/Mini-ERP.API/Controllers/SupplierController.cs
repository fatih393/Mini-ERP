using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mini_ERP.Application.Abstractions.Services;
using Mini_ERP.Application.Features.Commands.Supplier.CreateSupplier;
using Mini_ERP.Application.Features.Commands.Supplier.RemoveSupplier;
using Mini_ERP.Application.Features.Commands.Supplier.UpdateSupplier;
using Mini_ERP.Application.Features.Queries.Supplier.GetSupplier;
using Mini_ERP.Persistence.Services;

namespace Mini_ERP.API.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
   
    public class SupplierController : ControllerBase
    {
        readonly IMediator _mediator;

        public SupplierController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddSupplier(CreateSupplierCommandRequest createSupplierCommandRequest)
        {
            var response = await _mediator.Send(createSupplierCommandRequest);
            if (response.Success)
                return Ok(response);
            else
                return BadRequest(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetSupplier([FromQuery] GetSupplierQueryRequest getSupplierQueryRequest)
        {
            var response = await _mediator.Send(getSupplierQueryRequest);
            if (response.Success)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveSupplier([FromQuery] RemoveSupplierCommandRequest removeSupplierCommandRequest)
        {
            var response = await _mediator.Send(removeSupplierCommandRequest);
            if (response.Success)
                return Ok(response);
            return BadRequest(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSupplier(UpdateSupplierCommandRequest updateSupplierCommandRequest)
        {
            var response = await _mediator.Send(updateSupplierCommandRequest);
            if(response.Success)
                return Ok(response);
            return BadRequest(response);
        }



    }
}
