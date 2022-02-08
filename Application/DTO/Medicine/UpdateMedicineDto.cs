using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Medicine
{
    public class UpdateMedicineDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
