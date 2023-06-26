using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using moviesAPI___Entities.Data;
using moviesAPI___Entities.Data.Dtos;
using moviesAPI___Entities.Models;

namespace moviesAPI___Entities.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionController : ControllerBase
    {
        private MovieContext _context;
        private IMapper _mapper;

        public SessionController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddSession(CreateSessionDto SessionDto)
        {
            Session session = _mapper.Map<Session>(SessionDto);

            _context.Session.Add(session);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetSessionById),
                new { 
                    movieId = session.MovieId,
                    movieTheaterId = session.MovieTheaterId,
                },
                session);
        }

        [HttpGet]
        public IEnumerable<ReadSessionDto> GetSessions()
        {
            return _mapper.Map<List<ReadSessionDto>>(_context.Session.ToList());
        }

        [HttpGet("{movieId}/{movieTheaterId}")]
        public IActionResult GetSessionById(int movieId, int movieTheaterId)
        {
            Session session = _context.Session.FirstOrDefault(session => session.MovieId == movieId && session.MovieTheaterId == movieTheaterId);

            if (session != null)
            {
                ReadSessionDto sessionDto = _mapper.Map<ReadSessionDto>(session);

                return Ok(session);
            }

            return NotFound();
        }
    }
}
