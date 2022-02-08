using System.Collections.Generic;

namespace Domain.Entities
{
    public class Vet
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
