using System.Threading;
using System.Threading.Tasks;
using datalayer.abstraction.Entities;
using datalayer.abstraction.Repositories;
using Microsoft.EntityFrameworkCore;

namespace datalayer.Repositories
{
    public class DoctorQueryRepository : IDoctorQueryRepository
    {
        private readonly QueryDbContext _dbContext;

        public DoctorQueryRepository(QueryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        async Task<Doctor> IDoctorQueryRepository.GetByIdAsync(long id, CancellationToken cancellationToken)
        {
           return await _dbContext.Doctor.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
