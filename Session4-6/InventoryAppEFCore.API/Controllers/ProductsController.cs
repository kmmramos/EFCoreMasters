using InventoryAppEFCore.Application;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAppEFCore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _service.GetAllProducts();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("getNonDeleted")]
        public async Task<IActionResult> GetNonDeletedProducts()
        {
            var result = await _service.GetNonDeletedProducts();

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
