using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OneOf.Types;
using OneOf;
using datalayer.abstraction.Entities;
using businesslogic.abstraction.Dto;

namespace datalayer.abstraction.Repositories
{
    public interface IClinicQueryRepository
    {
        public Task<OneOf<Clinic, NotFound>> GetAsync(long clinicId, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<ClinicDto.Response.CityCode>> GetAvailableCitiesAsync(CancellationToken cancellationToken = default);
    }

    public interface IClinicCommandRepository
    {
        public Task<Clinic> CreateAsync(ClinicDto.Request.Create clinic, CancellationToken cancellationToken = default);
        public Task<OneOf<Clinic, NotFound>> UpdateAsync(long clinicId, ClinicDto.Request.Update clinic, CancellationToken cancellationToken = default);
        public Task<OneOf<Success, NotFound>> DeleteAsync(long clinicId, CancellationToken cancellationToken = default);
        public Task<OneOf<Clinic, NotFound>> UpdateClinicDoctorAsync(long clinicId, long doctorId, IReadOnlyList<long> medicalProfileIds, CancellationToken cancellationToken);
        public Task<OneOf<Success, NotFound>> RemoveClinicDoctorAsync(long clinicId, long doctorId, CancellationToken cancellationToken);
    }
}
