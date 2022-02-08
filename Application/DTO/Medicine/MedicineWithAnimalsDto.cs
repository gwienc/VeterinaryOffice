using System.Collections.Generic;

namespace Application.DTO.Medicine
{
    public class MedicineWithAnimalsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> Animals { get; set; }
    }
}
