using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Animal
{
    public class CreateAnimalDto
    {
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
