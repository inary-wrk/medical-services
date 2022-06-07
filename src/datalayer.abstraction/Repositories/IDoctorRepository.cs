using System.Collections.Generic;
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
        public Task<OneOf<Doctor, NotFound>> GetAsync(long doctorId, CancellationToken cancellationToken = default);
    }

    public interface IDoctorCommandRepository
    {
        public Task<Doctor> CreateAsync(DoctorDto.Request.Create doctor, CancellationToken cancellationToken = default);
        public Task<OneOf<Doctor, NotFound>> UpdateAsync(long doctorId, DoctorDto.Request.Update doctor, CancellationToken cancellationToken = default);
        public Task<OneOf<Doctor, NotFound>> UpdateMedicalProfilesAsync(long doctorId, IReadOnlyList<long> medicalProfileIds, CancellationToken cancellationToken = default);
        public Task<OneOf<Success, NotFound>> DeleteAsync(long doctorId, CancellationToken cancellationToken = default);
    }
}
