using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businesslogic.abstraction.TinyTypes
{
    public record MedicalProfileName
    {
        public string Name { get; set; }

        public MedicalProfileName(string name)
        {
            Name = name;
        }
    }
}
