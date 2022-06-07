using System.Threading;
using System.Threading.Tasks;
using datalayer.abstraction.Entities;
using datalayer.abstraction.Repositories;
using Microsoft.EntityFrameworkCore;
using OneOf;
using OneOf.Types;
using businesslogic.abstraction.Dto;
using businesslogic.abstraction.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace datalayer.Repositories
{
    internal class DoctorCommandRepository : IDoctorCommandRepository
    {
        private readonly CommandDbContext _dbContext;
        private readonly IMapper _mapper;

        public DoctorCommandRepository(CommandDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        async Task<Doctor> IDoctorCommandRepository.CreateAsync(DoctorDto.Request.Create doctorDto, CancellationToken cancellationToken)
        {
            var doctor = _mapper.Map<DoctorDto.Request.Create, Doctor>(doctorDto);
            _dbContext.Doctor.Add(doctor);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return doctor;
        }

        async Task<OneOf<Success, NotFound>> IDoctorCommandRepository.DeleteAsync(long doctorId, CancellationToken cancellationToken)
        {
            var existingDoctor = await _dbContext.Doctor.FindAsync(new object[] { doctorId }, cancellationToken);
            if (existingDoctor is null)
                return new NotFound();

            _dbContext.Doctor.Remove(existingDoctor);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return new Success();
        }

        async Task<OneOf<Doctor, NotFound>> IDoctorCommandRepository.UpdateAsync(long doctorId,
                                                                                 DoctorDto.Request.Update doctor,
                                                                                 CancellationToken cancellationToken)
        {
            var existingDoctor = await _dbContext.Doctor.FindAsync(new object[] { doctorId }, cancellationToken);
            if (existingDoctor is null)
                return new NotFound();

            _mapper.Map(doctor, existingDoctor);

            await _dbContext.SaveChangesAsync(cancellationToken);
            return existingDoctor;
        }

        async Task<OneOf<Doctor, NotFound>> IDoctorCommandRepository.UpdateMedicalProfilesAsync(long doctorId,
                                                                                                IReadOnlyList<long> medicalProfileIds,
                                                                                                CancellationToken cancellationToken)
        {
            var existingDoctor = await _dbContext.Doctor.Include(d => d.MedicalProfiles).SingleOrDefaultAsync(d => d.Id == doctorId, cancellationToken);
            if (existingDoctor is null)
                return new NotFound();

            existingDoctor.MedicalProfiles = await _dbContext.MedicalProfile.Where(mp => medicalProfileIds.Contains(mp.Id)).ToListAsync(cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return existingDoctor;
        }
    }
}
