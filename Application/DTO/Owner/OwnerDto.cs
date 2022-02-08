using Application.DTO.Animal;
using System.Collections.Generic;

namespace Application.DTO.Owner
{
    public class OwnerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public List<AnimalShortDto> Animals { get; set; }
    }
}
