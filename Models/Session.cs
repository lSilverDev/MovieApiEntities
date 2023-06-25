using System.ComponentModel.DataAnnotations;

namespace moviesAPI___Entities.Models
{
    public class Session
    {
        [Key]
        [Required]
        public int Id { get; set; }
    }
}
