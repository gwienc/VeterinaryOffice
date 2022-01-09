using Application.DTO.Animal;
using Application.DTO.Vet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Visit
{
    public class VisitDto
    {
        public int Id { get; set; }
        public string VisitType { get; set; }
        public string Description { get; set; }
        public DateTime VisitDate { get; set; }
        public DateTime LastModifiedVisit { get; set; }
        public AnimalDto Animal { get; set; }
        public VetDto Vet { get; set; }
    }
}
