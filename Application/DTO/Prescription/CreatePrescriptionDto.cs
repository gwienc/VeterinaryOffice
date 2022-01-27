using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Prescription
{
    public class CreatePrescriptionDto
    {
        [Required]
        public DateTime? ValidityPeriod { get; set; }
        [Required]
        public int AnimalId { get; set; }
        [Required]
        public int MedicineId { get; set; }
    }
}
