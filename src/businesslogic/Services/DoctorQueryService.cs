using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using businesslogic.abstraction.Dto;
using businesslogic.abstraction.Services;
using businesslogic.abstraction.TinyTypes;

namespace businesslogic.Services
{
    public class DoctorQueryService : IQueryService<Id, Doctor>
    {
        async Task<Doctor> IQueryService<Id, Doctor>.GetByIdAsync(Id arg, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
