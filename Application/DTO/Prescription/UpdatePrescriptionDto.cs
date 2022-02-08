using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Prescription
{
    public class UpdatePrescriptionDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime? ValidityPeriod { get; set; }
        [Required]
        public int AnimalId { get; set; }
        [Required]
        public int MedicineId { get; set; }
    }
}
