using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businesslogic.abstraction.TinyTypes
{
    public record PersonName
    {
        public string Name { get; set; }

        public PersonName(string name)
        {
            Name = name;
        }
    }
}
