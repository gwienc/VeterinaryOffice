﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //virtual properties
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
