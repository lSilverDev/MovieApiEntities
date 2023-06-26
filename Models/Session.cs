using System.ComponentModel.DataAnnotations;

namespace moviesAPI___Entities.Models
{
    public class Session
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        public int? MovieTheaterId { get; set; }

        public virtual MovieTheater MovieTheater { get; set; }
    }
}
