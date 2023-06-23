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

        [HttpPost]
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
            return Ok(_context.Movies.Skip(skip).Take(take));
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);

            if(movie == null) return NotFound();

            return Ok(movie);
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


    }
}
