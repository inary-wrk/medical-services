using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businesslogic.abstraction.TinyTypes
{
    public record ClinicDescription
    {
        public string Description { get; set; }

        public ClinicDescription(string description)
        {
            Description = description;
        }
    }
}
