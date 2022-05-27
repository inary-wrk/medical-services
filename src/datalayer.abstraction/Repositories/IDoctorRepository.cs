using System.Threading;
using System.Threading.Tasks;
using datalayer.abstraction.Entities;

namespace datalayer.abstraction.Repositories
{
    public interface IDoctorQueryRepository
    {
        public Task<Doctor> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    }

    public interface IDoctorCommandRepository
    {
        public Task<Doctor> AddAsync(Doctor doctor, CancellationToken cancellationToken = default);
        public Task<Doctor> UpdateAsync(Doctor doctor, CancellationToken cancellationToken = default);
        public Task DeleteAsync(long id, CancellationToken cancellationToken = default);
    }
}
