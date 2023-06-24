using System.ComponentModel.DataAnnotations;

namespace moviesAPI___Entities.Models
{
    public class MovieTheater
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
