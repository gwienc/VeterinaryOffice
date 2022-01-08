using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Visit
    {
        public int Id { get; set; }
        public string VisitType { get; set; }
        public string Description { get; set; }
        public DateTime VisitDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime LastModifiedVisit { get; set; }
        public int AnimalId { get; set; }
        public int VetId { get; set; }

        //virtual properties
        public virtual Animal Animal { get; set; }
        public virtual Vet Vet { get; set; }

    }
}
