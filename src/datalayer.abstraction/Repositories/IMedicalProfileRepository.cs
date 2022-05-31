using datalayer.abstraction.Entities;
using OneOf.Types;
using OneOf;
using System.Threading;
using System.Threading.Tasks;

namespace datalayer.abstraction.Repositories
{
    public interface IMedicalProfileQueryRepository
    {
        public Task<OneOf<MedicalProfile, NotFound>> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    }

    public interface IMedicalProfileCommandRepository
    {
        public Task<MedicalProfile> CreateAsync(MedicalProfile medicalProfile, CancellationToken cancellationToken = default);
        public Task<OneOf<MedicalProfile, NotFound>> UpdateAsync(long id, MedicalProfile medicalProfile, CancellationToken cancellationToken = default);
        public Task<OneOf<Success, NotFound>> DeleteAsync(long id, CancellationToken cancellationToken = default);
    }
}
