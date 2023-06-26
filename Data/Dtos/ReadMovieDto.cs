using System.ComponentModel.DataAnnotations;

namespace moviesAPI___Entities.Data.Dtos
{
    public class ReadMovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
        public DateTime TimeOfConsult { get; set; } = DateTime.Now;

        public ICollection<ReadSessionDto> Sessions { get; set; }
    }
}
