﻿using Application.DTO.Owner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Animal
{
    public class AnimalVisitDto
    {
        public int Id { get; set; }
        public string AnimalType { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public string Gender { get; set; }
        public OwnerVisitDto Owner { get; set; }
        public List<string> Medicines { get; set; }
    }
}