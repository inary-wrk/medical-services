using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OneOf.Types;
using OneOf;
using datalayer.abstraction.Entities;

namespace datalayer.abstraction.Repositories
{
    public interface IClinicQueryRepository
    {
        public Task<OneOf<Clinic, NotFound>> GetByIdAsync(long id, CancellationToken cancellationToken = default);        
    }

    public interface IClinicCommandRepository
    {
        public Task<Clinic> CreateAsync(Clinic clinic, CancellationToken cancellationToken = default);
        public Task<OneOf<Clinic, NotFound>> UpdateAsync(long id, Clinic clinic, CancellationToken cancellationToken = default);
        public Task<OneOf<Success, NotFound>> DeleteAsync(long id, CancellationToken cancellationToken = default);
    }    
}
