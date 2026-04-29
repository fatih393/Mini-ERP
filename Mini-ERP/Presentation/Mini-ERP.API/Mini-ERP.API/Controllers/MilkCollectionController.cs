using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mini_ERP.Application.Features.Commands.MilkCollection.CreateMilkCollection;
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
    }
}
