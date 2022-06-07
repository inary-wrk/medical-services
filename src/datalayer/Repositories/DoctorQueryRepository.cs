using System.Threading;
using System.Threading.Tasks;
using datalayer.abstraction.Entities;
using datalayer.abstraction.Repositories;
using Microsoft.EntityFrameworkCore;
using OneOf;
using OneOf.Types;

namespace datalayer.Repositories
{
    internal class DoctorQueryRepository : IDoctorQueryRepository
    {
        private readonly QueryDbContext _dbContext;

        public DoctorQueryRepository(QueryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        async Task<OneOf<Doctor, NotFound>> IDoctorQueryRepository.GetAsync(long doctorId, CancellationToken cancellationToken)
        {
            var doctor = await _dbContext.Doctor.Include(d => d.ClinicsLink)
                                                .ThenInclude(cd => cd.MedicalProfiles)
                                                .Include(d => d.MedicalProfiles)
                                                .SingleOrDefaultAsync(d => d.Id == doctorId, cancellationToken);
            return doctor is null ? new NotFound() : doctor;
        }
    }
}
