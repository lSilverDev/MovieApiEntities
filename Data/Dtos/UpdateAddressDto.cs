using System.ComponentModel.DataAnnotations;

namespace moviesAPI___Entities.Data.Dtos
{
    public class UpdateAddressDto
    {
        [Required]
        public string PublicPlace { get; set; }

        public int Number { get; set; }
    }
}
