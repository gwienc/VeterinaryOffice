using System.Collections.Generic;

namespace Domain.Entities
{
    public class Owner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public virtual ICollection<Animal> Animals { get; set; }
    }
}
