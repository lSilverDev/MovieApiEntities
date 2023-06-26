using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using moviesAPI___Entities.Data;
using moviesAPI___Entities.Data.Dtos;
using moviesAPI___Entities.Models;

namespace moviesAPI___Entities.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class MovieController : ControllerBase
    {

        private MovieContext _context;
        private IMapper _mapper;

        public MovieController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Adds a movie to the database
        /// </summary>
        /// <param name="filmeDto">Object with the necessary fields to create a movie</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">If the insertion is successful</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddMovie([FromBody] CreateMovieDto movieDto)
        {
            Movie movie = _mapper.Map<Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            return CreatedAtAction(
                nameof(GetMovieById),
                new { id = movie.Id },
                movie
            );
        }

        [HttpGet]
        public IActionResult GetMovies([FromQuery] int skip = 0, [FromQuery] int take = 25)
        {
            return Ok(_mapper.Map<List<ReadMovieDto>>(_context.Movies.Skip(skip).Take(take).ToList()));
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);

            if(movie == null) return NotFound();

            var movieDto = _mapper.Map<ReadMovieDto>(movie);

            return Ok(movieDto);
        }

        [HttpPut("{id}")]
        public IActionResult PutMovie(int id, [FromBody] UpdateMovieDto movieDto) 
        {
            var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);

            if (movie == null) return NotFound();

            _mapper.Map(movieDto, movie);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchMovie(int id, JsonPatchDocument<UpdateMovieDto> patch)
        {

            //patch ex:
            //{
            //    "op": "replace",
            //    "path": "/titulo",
            //    "value": "Avatar"
            //}

            var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);

            if (movie == null) return NotFound();

            var movieToAtt = _mapper.Map<UpdateMovieDto>(movie);

            patch.ApplyTo(movieToAtt, ModelState);

            if(!TryValidateModel(movieToAtt)) return ValidationProblem(ModelState);

            _mapper.Map(movieToAtt, movie);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovieById(int id)
        {
            var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);

            if (movie == null) return NotFound();

            _context.Remove(movie);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
