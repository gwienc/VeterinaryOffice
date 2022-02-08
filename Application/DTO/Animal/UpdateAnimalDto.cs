using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Animal
{
    public class UpdateAnimalDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string AnimalType { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Breed { get; set; }
        [Required]
        public int? Age { get; set; }
        [Required]
        public double? Weight { get; set; }
        [Required]
        [MaxLength(30)]
        public string Gender { get; set; }
        [Required]
        public int OwnerId { get; set; }
    }
}
