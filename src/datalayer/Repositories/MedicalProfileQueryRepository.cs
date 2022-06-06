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

        async Task<OneOf<MedicalProfile, NotFound>> IMedicalProfileQueryRepository.GetAsync(long id,
                                                                                            string cityCode,
                                                                                            CancellationToken cancellationToken)
        {
            var result = await _dbContext.MedicalProfile.Include(mp => mp.Doctors.Where(d => d.ClinicsLink.Any(cd => cd.Clinic.Address.CityCode == cityCode)))
                                                        .SingleOrDefaultAsync(m => m.Id == id, cancellationToken);
            return result is null ? new NotFound() : result;
        }

        async Task<IReadOnlyList<(MedicalProfile, int doctorsCount)>> IMedicalProfileQueryRepository.GetListAsync(string cityCode, CancellationToken cancellationToken)
        {
            return await _dbContext.MedicalProfile
                .Select(mp => new ValueTuple<MedicalProfile, int>(
                    mp,
                    mp.Doctors.Count(d => d.ClinicsLink.Any(c => c.Clinic.Address.CityCode == cityCode))))
                .ToListAsync(cancellationToken);
        }

        async Task<IReadOnlyList<MedicalProfile>> IMedicalProfileQueryRepository.GetListAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.MedicalProfile.ToListAsync(cancellationToken);
        }
    }
}
