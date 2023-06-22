using Microsoft.AspNetCore.Mvc;
using moviesAPI___Entities.Models;

namespace moviesAPI___Entities.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class MovieController : ControllerBase
    {

        private static List<Movie> _movies = new List<Movie>();

        public MovieController()
        {
            
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            _movies.Add(movie);

            return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
        }

        [HttpGet]
        public IActionResult GetMovies([FromQuery] int skip = 0, [FromQuery] int take = 25)
        {
            return Ok(_movies.Skip(skip).Take(take));
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            var movie = _movies.FirstOrDefault(movie => movie.Id == id);

            if(movie == null) return NotFound();

            return Ok(movie);
        }
    }
}
