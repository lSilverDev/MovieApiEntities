using System.ComponentModel.DataAnnotations;

namespace moviesAPI___Entities.Models
{
    public class Movie
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Duration is required")]
        [Range(70, 600)]
        public int Duration { get; set; }
    }
}
