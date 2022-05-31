using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using datalayer.abstraction.Entities;
using datalayer.abstraction.Repositories;
using Microsoft.EntityFrameworkCore;
using OneOf;
using OneOf.Types;

namespace datalayer.Repositories
{
    internal class MedicalProfileQueryRepository : IMedicalProfileQueryRepository
    {
        private readonly QueryDbContext _dbContext;

        public MedicalProfileQueryRepository(QueryDbContext context)
        {
            _dbContext = context;
        }

        async Task<OneOf<MedicalProfile, NotFound>> IMedicalProfileQueryRepository.GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            var result = await _dbContext.MedicalProfile.FindAsync(new object[]{id}, cancellationToken);
            
            return result is null ? new NotFound() : result;
        }
    }
}
