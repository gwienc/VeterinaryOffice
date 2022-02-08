using System.Collections.Generic;

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
        public virtual ICollection<Visit> Visits { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
        public virtual Owner Owner { get; set; }
    }
}
