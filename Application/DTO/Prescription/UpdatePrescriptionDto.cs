﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Prescription
{
    public class UpdatePrescriptionDto
    {
        public int Id { get; set; }
        public DateTime ValidityPeriod { get; set; }

        public int AnimalId { get; set; }
        public int MedicineId { get; set; }
    }
}