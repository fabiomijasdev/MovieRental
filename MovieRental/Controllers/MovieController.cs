using Microsoft.AspNetCore.Mvc;
using MovieRental.Movie;

namespace MovieRental.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {

        private readonly IMovieFeatures _features;

        public MovieController(IMovieFeatures features)
        {
            _features = features;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsyncWithPagination([FromQuery] int page, int pageSize)
        {
            return Ok(await _features.GetAllAsyncWithPagination(page, pageSize));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Movie.Movie movie)
        {
            return Ok(_features.SaveAsync(movie));
        }
    }
}
