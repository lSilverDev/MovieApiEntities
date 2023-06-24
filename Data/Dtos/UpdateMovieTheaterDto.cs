using System.ComponentModel.DataAnnotations;

namespace moviesAPI___Entities.Data.Dtos
{
    public class UpdateMovieTheaterDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}
