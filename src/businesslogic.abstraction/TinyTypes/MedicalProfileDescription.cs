using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businesslogic.abstraction.TinyTypes
{
    public record MedicalProfileDescription
    {
        public string Description { get; set; }

        public MedicalProfileDescription(string description)
        {
            Description = description;
        }
    }
}
