using System.ComponentModel.DataAnnotations;

namespace moviesAPI___Entities.Data.Dtos
{
    public class ReadAddressDto
    {
        public int Id { get; set; }
        public string PublicPlace { get; set; }
        public int Number { get; set; }
    }
}
