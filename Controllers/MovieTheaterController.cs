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
    public class MovieTheaterController : ControllerBase
    {
        private MovieContext _context;
        private IMapper _mapper;

        public MovieTheaterController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Adds a movie theater to the database
        /// </summary>
        /// <param name="MovieTheaterDto">Object with the necessary fields to create a movie</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">If the insertion is successful</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult addMovieTheater([FromBody] CreateMovieTheaterDto MovieTheaterDto)
        {
            MovieTheater movieTheater = _mapper.Map<MovieTheater>(MovieTheaterDto);

            _context.MovieTheaters.Add(movieTheater);
            _context.SaveChanges();

            return CreatedAtAction(
                nameof(GetMovieTheaterById),
                new { id = movieTheater.Id },
                movieTheater
            );
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieTheaterById(int id) 
        {
            var movieTheater = _context.MovieTheaters.FirstOrDefault(movieTheater => movieTheater.Id == id);

            if (movieTheater == null) return NotFound();

            var movieTheaterDto = _mapper.Map<ReadMovieTheaterDto>(movieTheater);

            return Ok(movieTheaterDto);
        }

        [HttpGet]
        public IActionResult GetAllMovieTheater() 
        {
            return Ok(_mapper.Map<List<ReadMovieTheaterDto>>(_context.MovieTheaters.ToList()));
        }

        [HttpPut("{id}")]
        public IActionResult PutMovieTheater(int id, [FromBody] UpdateMovieTheaterDto movieTheaterDto)
        {
            var movieTheater = _context.MovieTheaters.FirstOrDefault(movieTheater => movieTheater.Id == id);

            if (movieTheater == null) return NotFound();

            _mapper.Map(movieTheaterDto, movieTheater);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult patchMovieTheater(int id, JsonPatchDocument<UpdateMovieTheaterDto> patch) 
        {
            var movieTheater = _context.MovieTheaters.FirstOrDefault(movieTheater => movieTheater.Id == id);

            if(movieTheater == null) return NotFound();

            var movieTheaterToAtt = _mapper.Map<UpdateMovieTheaterDto>(movieTheater);

            patch.ApplyTo(movieTheaterToAtt, ModelState);

            if (!TryValidateModel(movieTheaterToAtt)) return ValidationProblem(ModelState);

            _mapper.Map(movieTheaterToAtt, movieTheater);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovieTheaterById(int id)
        {
            var movieTheater = _context.MovieTheaters.FirstOrDefault(movieTheater => movieTheater.Id == id);

            if (movieTheater == null) return NotFound();

            _context.Remove(movieTheater);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
