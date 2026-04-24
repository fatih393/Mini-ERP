using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mini_ERP.Application.Abstractions.Services;
using Mini_ERP.Persistence.Services;

namespace Mini_ERP.API.Controllers
{
    public class SupplierRequest
    {
        public string SupplierName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
   
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }


        [HttpPost]
        public async Task<IActionResult> AddSupplier([FromBody] SupplierRequest request)
        {
            var result = await _supplierService.AddSupplierAsync(
                request.SupplierName,
                request.Phone,
                request.Address,
                request.Location
            );

            if (!result)
                return BadRequest("Supplier already exists");

            return Ok("Added");
        }




    }
}
