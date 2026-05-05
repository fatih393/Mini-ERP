using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mini_ERP.Application.Features.Queries.Stock.GetStock;

namespace Mini_ERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        IMediator _mediator;

        public StockController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetStockAll([FromQuery] GetStockQueryRequest getStockQueryRequest)
        {
            var response = await _mediator.Send(getStockQueryRequest);
            if(response.Success) 
                return Ok(response);
            return BadRequest(response);
        }
    }
}
