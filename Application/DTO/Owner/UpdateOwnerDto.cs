using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Owner
{
    public class UpdateOwnerDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Street { get; set; }
        [Required]
        [MaxLength(6)]
        public string PostCode { get; set; }
        [Required]
        [MaxLength(100)]
        public string City { get; set; }
    }
}
