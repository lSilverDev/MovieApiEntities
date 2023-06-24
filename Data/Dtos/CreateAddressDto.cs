using System.ComponentModel.DataAnnotations;

namespace moviesAPI___Entities.Data.Dtos
{
    public class CreateAddressDto
    {
        [Required]
        public string PublicPlace { get; set; }

        public int Number { get; set; }
    }
}
