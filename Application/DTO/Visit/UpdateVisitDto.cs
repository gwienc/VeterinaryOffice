using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Visit
{
    public class UpdateVisitDto
    {
        public int Id { get; set; }
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
