using System;

namespace Application.DTO.Prescription
{
    public class PrescriptionDto
    {
        public int Id { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public DateTime ValidityPeriod { get; set; }
        public int AnimalId { get; set; }
        public int MedicineId { get; set; }

    }
}
