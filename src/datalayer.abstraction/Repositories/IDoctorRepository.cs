using System.Threading;
using System.Threading.Tasks;
using datalayer.abstraction.Entities;
using OneOf;
using OneOf.Types;

namespace datalayer.abstraction.Repositories
{
    public interface IDoctorQueryRepository
    {
        public Task<OneOf<Doctor, NotFound>> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    }

    public interface IDoctorCommandRepository
    {
        public Task<Doctor> CreateAsync(Doctor doctor, CancellationToken cancellationToken = default);
        public Task<OneOf<Doctor, NotFound>> UpdateAsync(long id, Doctor doctor, CancellationToken cancellationToken = default);
        public Task<OneOf<Success, NotFound>> DeleteAsync(long id, CancellationToken cancellationToken = default);
    }
}
