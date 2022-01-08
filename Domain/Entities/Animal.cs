using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Animal
    {
        public int Id { get; set; }
        public string AnimalType { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public string Gender { get; set; }
        public int OwnerId { get; set; }

        //virtual properties
        public virtual ICollection<Visit> Visits { get; set; }
        public virtual ICollection<Animal_Medicine> Animals_Medicines { get; set; }
        public virtual Owner Owner { get; set; }
    }
}
