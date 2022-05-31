using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using datalayer.abstraction.Entities;
using datalayer.abstraction.Repositories;
using OneOf;
using OneOf.Types;

namespace datalayer.Repositories
{
    internal class ClinicQueryRepository : IClinicQueryRepository
    {

        private readonly QueryDbContext _dbContext;

        public ClinicQueryRepository(QueryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        async Task<OneOf<Clinic, NotFound>> IClinicQueryRepository.GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Clinic.FindAsync(new object[] {id}, cancellationToken);
            return result is null ? new NotFound() : result;
        }
    }
}
