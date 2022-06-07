using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            // TODO: duplicate fix
            var result = await _dbContext.MedicalProfile
                .Include(mp => mp.ClinicDoctors
                    .Where(cd => cd.Clinic.Address.CityCode == cityCode))
                .ThenInclude(cd => cd.Clinic)
                .ThenInclude(c => c.DoctorsLink)
                .ThenInclude(cd => cd.Doctor)
                .SingleOrDefaultAsync(m => m.Id == id, cancellationToken);
            return result is null ? new NotFound() : result;
        }

        async Task<IReadOnlyList<MedicalProfileDto.Response.Details>> IMedicalProfileQueryRepository.GetListAsync(string cityCode, CancellationToken cancellationToken)
        {
            return await _dbContext.MedicalProfile
                .Select(mp => new MedicalProfileDto.Response.Details(
                    mp.Id,
                    mp.Name,
                    mp.Description,
                    mp.Doctors.Count(d => d.ClinicsLink.Any(c => c.Clinic.Address.CityCode == cityCode))))
                .ToListAsync(cancellationToken);
        }

        async Task<IReadOnlyList<MedicalProfile>> IMedicalProfileQueryRepository.GetListAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.MedicalProfile.ToListAsync(cancellationToken);
        }
    }
}
