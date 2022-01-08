using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Animal_Medicine
    {
        public int Id { get; set; }

        public int AnimalId { get; set; }
        public int MedicineId { get; set; }

        //virtual properties
        public virtual Animal Animal { get; set; }
        public virtual Medicine Medicine { get; set; }
    }
}
