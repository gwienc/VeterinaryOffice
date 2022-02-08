using Application.DTO.Animal;
using Application.DTO.Vet;
using System;

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
