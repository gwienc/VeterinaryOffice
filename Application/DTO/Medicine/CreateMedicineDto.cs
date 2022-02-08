using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Medicine
{
    public class CreateMedicineDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
