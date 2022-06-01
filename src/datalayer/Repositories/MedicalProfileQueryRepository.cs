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

        async Task<IReadOnlyList<(MedicalProfile, int doctorsCount)>> IMedicalProfileQueryRepository.GetListAsync(string city, CancellationToken cancellationToken)
        {
            return await _dbContext.MedicalProfile
                .Select(prof => new ValueTuple<MedicalProfile, int>(prof, prof.Clinics.Count(c => c.Address.City == city)))
                .ToListAsync(cancellationToken);
        }
    }
}
