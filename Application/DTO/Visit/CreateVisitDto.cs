using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Visit
{
    public class CreateVisitDto
    {
        [Required]
        [MaxLength(100)]
        public string VisitType { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
        [Required]
        public DateTime? VisitDate { get; set; }        
        [Required]
        public int AnimalId { get; set; }
        [Required]
        public int VetId { get; set; }
    }
}
