using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using businesslogic.abstraction.Dto;
using datalayer.abstraction.Entities;
using datalayer.abstraction.Repositories;
using Microsoft.EntityFrameworkCore;
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

        async Task<IReadOnlyList<ClinicDto.Response.CityCode>> IClinicQueryRepository.GetAvailableCitiesAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Clinic.Select(c => new ClinicDto.Response.CityCode(c.Address.City, c.Address.CityCode)).Distinct().ToListAsync(cancellationToken);
        }

        async Task<OneOf<Clinic, NotFound>> IClinicQueryRepository.GetAsync(long id, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Clinic.Include(c => c.DoctorsLink)
                                                .ThenInclude(cd => cd.MedicalProfiles)
                                                .ThenInclude(cd => cd.Doctors)
                                                .SingleOrDefaultAsync(c => c.Id == id, cancellationToken);
            return result is null ? new NotFound() : result;
        }
    }
}
