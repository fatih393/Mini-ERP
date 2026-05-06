using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mini_ERP.Application.Features.Commands.Production.CreateProduction;
using Mini_ERP.Application.Features.Commands.Production.UpdateProduction;
using Mini_ERP.Application.Features.Queries.Production.GetProduction;

namespace Mini_ERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionController : ControllerBase
    {
        readonly IMediator _mediator;

        public ProductionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetProductionAll([FromQuery] GetProductionQueryRequest getProductionQueryRequest)
        {
            var response = await _mediator.Send(getProductionQueryRequest);
            if(response.Success)
                return Ok(response);
            return BadRequest(response);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduction(CreateProductionCommandRequest createProductionCommandRequest)
        {
            var response = await _mediator.Send(createProductionCommandRequest);
            if (response.Success)
                return Ok(response);
            return BadRequest(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduction(UpdateProductionCommandRequest updateProductionCommandRequest)
        {
            var response = await _mediator.Send(updateProductionCommandRequest);
            if (response.Success)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
