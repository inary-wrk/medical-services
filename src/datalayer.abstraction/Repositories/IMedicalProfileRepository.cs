using datalayer.abstraction.Entities;
using OneOf.Types;
using OneOf;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using businesslogic.abstraction.Dto;

namespace datalayer.abstraction.Repositories
{
    public interface IMedicalProfileQueryRepository
    {
        public Task<OneOf<MedicalProfile, NotFound>> GetAsync(long id, string cityCode, CancellationToken cancellationToken = default);
        public Task<IReadOnlyList<MedicalProfileDto.Response.Details>> GetListAsync(string cityCode, CancellationToken cancellationToken = default);
        public Task<IReadOnlyList<MedicalProfile>> GetListAsync(CancellationToken cancellationToken = default);
    }

    public interface IMedicalProfileCommandRepository
    {
        public Task<MedicalProfile> CreateAsync(MedicalProfileDto.Request.Create medicalProfile, CancellationToken cancellationToken = default);
        public Task<OneOf<MedicalProfile, NotFound>> UpdateAsync(long id, MedicalProfileDto.Request.Update medicalProfile, CancellationToken cancellationToken = default);
    }
}
