using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Vet
{
    public class CreateVetDto
    {
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
    }
}
