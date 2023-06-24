using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using moviesAPI___Entities.Data.Dtos;
using moviesAPI___Entities.Data;
using moviesAPI___Entities.Models;

namespace moviesAPI___Entities.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AddressController : ControllerBase
    {

        private MovieContext _context;
        private IMapper _mapper;

        public AddressController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Adds a movie to the database
        /// </summary>
        /// <param name="AddressDto">Object with the necessary fields to create a movie</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">If the insertion is successful</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddAddress([FromBody] CreateAddressDto AddressDto)
        {
            Address address = _mapper.Map<Address>(AddressDto);

            _context.Address.Add(address);
            _context.SaveChanges();

            return CreatedAtAction(
                nameof(GetAddressById),
                new { id = address.Id },
                address
            );
        }

        [HttpGet]
        public IActionResult GetAddress([FromQuery] int skip = 0, [FromQuery] int take = 25)
        {
            return Ok(_mapper.Map<List<ReadAddressDto>>(_context.Address.Skip(skip).Take(take)));
        }

        [HttpGet("{id}")]
        public IActionResult GetAddressById(int id)
        {
            var address = _context.Address.FirstOrDefault(address => address.Id == id);

            if (address == null) return NotFound();

            var addressDto = _mapper.Map<ReadAddressDto>(address);

            return Ok(addressDto);
        }

        [HttpPut("{id}")]
        public IActionResult PutAddress(int id, [FromBody] UpdateAddressDto addressDto)
        {
            var address = _context.Address.FirstOrDefault(address => address.Id == id);

            if (address == null) return NotFound();

            _mapper.Map(addressDto, address);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchAddress(int id, JsonPatchDocument<UpdateAddressDto> patch)
        {

            //patch ex:
            //{
            //    "op": "replace",
            //    "path": "/titulo",
            //    "value": "Avatar"
            //}

            var address = _context.Movies.FirstOrDefault(address => address.Id == id);

            if (address == null) return NotFound();

            var addressToAtt = _mapper.Map<UpdateAddressDto>(address);

            patch.ApplyTo(addressToAtt, ModelState);

            if (!TryValidateModel(addressToAtt)) return ValidationProblem(ModelState);

            _mapper.Map(addressToAtt, address);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAddressById(int id)
        {
            var address = _context.Address.FirstOrDefault(address => address.Id == id);

            if (address == null) return NotFound();

            _context.Remove(address);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
