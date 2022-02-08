using System;
using System.ComponentModel.DataAnnotations;

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
