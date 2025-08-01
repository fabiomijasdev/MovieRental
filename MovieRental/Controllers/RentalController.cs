using Microsoft.AspNetCore.Mvc;
using MovieRental.Movie;
using MovieRental.Rental;

namespace MovieRental.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentalController : ControllerBase
    {

        private readonly IRentalFeatures _features;

        public RentalController(IRentalFeatures features)
        {
            _features = features;
        }


        [HttpPost]
        public IActionResult Post([FromBody] Rental.Rental rental)
        {
            return Ok(_features.SaveAsync(rental));
        }

        [HttpGet("by-customer-name")]
        public async Task<IActionResult> GetRentalsByCustomerName([FromQuery] string customerName)
        {
            if (string.IsNullOrWhiteSpace(customerName))
            {
                return BadRequest("Customer name is required.");
            }

            var rentals = await _features.GetRentalsByCustomerNameAsync(customerName);

            if (!rentals.Any())
            {
                return NotFound($"No rentals found for customer name containing '{customerName}'.");
            }

            return Ok(rentals);
        }

    }
}
