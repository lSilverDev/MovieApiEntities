using System.ComponentModel.DataAnnotations;

namespace moviesAPI___Entities.Models
{
    public class Address
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string PublicPlace { get; set; }

        public int Number { get; set; }
    }
}
