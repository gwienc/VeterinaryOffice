﻿using System.Collections.Generic;

namespace Domain.Entities
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
