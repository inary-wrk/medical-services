using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using datalayer.abstraction.Entities;
using datalayer.abstraction.Repositories;

namespace datalayer.Repositories
{
    public class DoctorQueryRepository : IQueryRepository<long, Doctor>
    {
        async Task<Doctor> IQueryRepository<long, Doctor>.GetByIdAsync(long arg, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
