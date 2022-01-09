using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Visit
{
    public class UpdateVisitDto
    {
        public int Id { get; set; }
        public string VisitType { get; set; }
        public string Description { get; set; }
        public DateTime VisitDate { get; set; }
        public DateTime LastModifiedVisit { get; set; }
        public int AnimalId { get; set; }
        public int VetId { get; set; }
    }
}
