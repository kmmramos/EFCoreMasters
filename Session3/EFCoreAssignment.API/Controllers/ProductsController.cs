using EFCoreAssignment.Data.Services;
using EFCoreAssignment.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreAssignment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            var result = await _service.GetProducts();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var result = await _service.GetProduct(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductApiModel vm)
        {
            try
            {
                var result = await _service.CreateProduct(new CreateProductDto(vm.Name, vm.ShopId));

                return Ok(result);
            }
            catch(NotFoundException)
            {
                return NotFound();
            }

        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductApiModel vm)
        {
            try
            {
                await _service.UpdateProduct(new UpdateProductDto(vm.Id, vm.Name, vm.ShopId));
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await _service.DeleteProduct(id);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }

    public record CreateProductApiModel(string Name, int ShopId);
    public record UpdateProductApiModel(int Id, string Name, int ShopId);
}
