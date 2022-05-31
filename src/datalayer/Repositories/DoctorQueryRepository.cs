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

        async Task<OneOf<Doctor, NotFound>> IDoctorQueryRepository.GetByIdAsync(long id, CancellationToken cancellationToken)
        {
           var doctor = await _dbContext.Doctor.FindAsync(new object[] { id }, cancellationToken);
            return doctor is null ? new NotFound() : doctor;
        }
    }
}
