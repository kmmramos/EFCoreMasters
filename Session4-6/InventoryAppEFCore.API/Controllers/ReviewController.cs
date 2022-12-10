using InventoryAppEFCore.Application;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAppEFCore.API.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService _service;
        public ReviewController(IReviewService service)
        {
            _service = service;
        }

        [HttpGet("getReviews")]
        public async Task<IActionResult> GetReviews()
        {
            var result = await _service.GetAllReviews();

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
