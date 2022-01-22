using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Prescription
    {
        public int Id { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public DateTime ValidityPeriod { get; set; }

        public int AnimalId { get; set; }
        public int MedicineId { get; set; }

        //virtual properties
        public virtual Animal Animal { get; set; }
        public virtual Medicine Medicine { get; set; }
    }
}
