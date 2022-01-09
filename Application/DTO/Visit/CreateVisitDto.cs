using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Visit
{
    public class CreateVisitDto
    {
        public string VisitType { get; set; }
        public string Description { get; set; }
        public DateTime VisitDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int AnimalId { get; set; }
        public int VetId { get; set; }
    }
}
