using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Medicine
{
    public class MedicineDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class MedicineWithAnimalsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> Animals { get; set; }
    }
}
