using System.ComponentModel.DataAnnotations;

namespace moviesAPI___Entities.Models
{
    public class MovieTheater
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public int AddressId { get; set; }

        public virtual Address Address { get; set; }
    }
}
