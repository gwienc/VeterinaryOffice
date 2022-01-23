using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Animal
{
    public class AnimalShortDto
    {
        public int Id { get; set; }
        public string AnimalType { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public string Gender { get; set; }
        public List<int> Medicines { get; set; }
    }
}
