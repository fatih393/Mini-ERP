using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mini_ERP.Application.Features.Commands.MilkCollection.CreateMilkCollection;
using Mini_ERP.Application.Features.Queries.MilkCollection.GetByIdCollectorEmployeeId;
using Mini_ERP.Application.Features.Queries.MilkCollection.GetByIdMilkCollection;
using Mini_ERP.Application.Features.Queries.MilkCollection.GetByIdQualityEmployeeId;
using Mini_ERP.Application.Features.Queries.MilkCollection.GetByIdSupplierId;
using Mini_ERP.Application.Features.Queries.MilkCollection.GetMilkCollection;

namespace Mini_ERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MilkCollectionController : ControllerBase
    {
        IMediator _mediator;

        public MilkCollectionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddMilkCollection(CreateMilkCollectionCommandRequest createMilkCollectionCommandRequest)
        {
            var response = await _mediator.Send(createMilkCollectionCommandRequest);
            if(response.Success)
                return Ok(response);
            return BadRequest(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetMilkCollection([FromQuery] GetMilkCollectionRequest getMilkCollectionRequest)
        {
            var response = await _mediator.Send(getMilkCollectionRequest);
            if (response.Success)
                return Ok(response);
            return BadRequest(response);
        }
        [HttpGet ("Collector Employee/id")]
        public async Task<IActionResult> GetByIdCollectorEmployeeId([FromQuery] GetByIdCollectorEmployeeIdRequest getByIdCollectorEmployeeIdRequest)
        {
            var response = await _mediator.Send(getByIdCollectorEmployeeIdRequest);
            if (response.Success)
                return Ok(response);
            return BadRequest(response);
                    
        }
        [HttpGet("Quality Employee/id")]
        public async Task<IActionResult> GetByIdQualityEmployeeId([FromQuery] GetByIdQualityEmployeeIdRequest getByIdQualityEmployeeIdRequest)
        {
            var response = await _mediator.Send(getByIdQualityEmployeeIdRequest);
            if (response.Success)
                return Ok(response);
            return BadRequest(response);
        }
        [HttpGet("Supplier/id")]
        public async Task<IActionResult> GetByIdSupplierId([FromQuery] GetByIdSupplierIdRequest getByIdSupplierIdRequest)
        {
            var response = await _mediator.Send(getByIdSupplierIdRequest);
            if(response.Success)
                return Ok(response);
            return BadRequest(response);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetByIdMilkCollection([FromQuery] GetByIdMilkCollectionRequest getByIdMilkCollectionRequest)
        {
            var response = await _mediator.Send(getByIdMilkCollectionRequest);
            if (response.Success)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
