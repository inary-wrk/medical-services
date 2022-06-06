using System.Threading;
using System.Threading.Tasks;
using businesslogic.abstraction.Dto;
using datalayer.abstraction.Entities;
using OneOf;
using OneOf.Types;

namespace datalayer.abstraction.Repositories
{
    public interface IDoctorQueryRepository
    {
        public Task<OneOf<Doctor, NotFound>> GetAsync(long id, CancellationToken cancellationToken = default);
    }

    public interface IDoctorCommandRepository
    {
        public Task<Doctor> CreateAsync(DoctorDto.Request.Create doctor, CancellationToken cancellationToken = default);
        public Task<OneOf<Doctor, NotFound>> UpdateAsync(long id, DoctorDto.Request.Update doctor, CancellationToken cancellationToken = default);
        public Task<OneOf<Success, NotFound>> DeleteAsync(long id, CancellationToken cancellationToken = default);
    }
}
