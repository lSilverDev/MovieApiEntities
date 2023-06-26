using System.ComponentModel.DataAnnotations;

namespace moviesAPI___Entities.Data.Dtos
{
    public class ReadMovieTheaterDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ReadAddressDto ReadAddressDto { get; set; }

        public ICollection<ReadSessionDto> Sessions { get; set; }
    }
}
