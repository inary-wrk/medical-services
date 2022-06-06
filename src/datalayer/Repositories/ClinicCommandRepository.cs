using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using businesslogic.abstraction.Contracts;
using businesslogic.abstraction.Dto;
using datalayer.abstraction.Entities;
using datalayer.abstraction.Repositories;
using Microsoft.EntityFrameworkCore;
using OneOf;
using OneOf.Types;

namespace datalayer.Repositories
{
    internal class ClinicCommandRepository : IClinicCommandRepository
    {
        private readonly CommandDbContext _dbContext;
        private readonly IMapper _mapper;

        public ClinicCommandRepository(CommandDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        async Task<Clinic> IClinicCommandRepository.CreateAsync(ClinicDto.Request.Create clinicDto, CancellationToken cancellationToken)
        {
            var clinic = _mapper.Map<ClinicDto.Request.Create, Clinic>(clinicDto);
            _dbContext.Clinic.Add(clinic);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return clinic;
        }

        async Task<OneOf<Success, NotFound>> IClinicCommandRepository.DeleteAsync(long clinicId, CancellationToken cancellationToken)
        {
            var clinic = await _dbContext.Clinic.FindAsync(new object[] { clinicId }, cancellationToken);
            if (clinic is null)
                return new NotFound();

            _dbContext.Clinic.Remove(clinic);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return new Success();
        }

        async Task<OneOf<Clinic, NotFound>> IClinicCommandRepository.UpdateAsync(long clinicId,
                                                                                 ClinicDto.Request.Update clinicDto,
                                                                                 CancellationToken cancellationToken)
        {
            var dbClinic = await _dbContext.Clinic.FindAsync(new object[] { clinicId }, cancellationToken);
            if (dbClinic is null)
                return new NotFound();

            _mapper.Map(clinicDto, dbClinic);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return dbClinic;
        }

        async Task<OneOf<Clinic, NotFound>> IClinicCommandRepository.UpdateClinicDoctorAsync(long clinicId,
                                                                                             long doctorId,
                                                                                             IReadOnlyList<long> medicalProfileIds,
                                                                                             CancellationToken cancellationToken)
        {
            var existingClinic = await _dbContext.Clinic.Include(c => c.DoctorsLink).SingleOrDefaultAsync(c => c.Id == clinicId, cancellationToken);
            if (existingClinic is null)
                return new NotFound();

            var existingDoctor = await _dbContext.Doctor.Include(d => d.MedicalProfiles.Where(mp => medicalProfileIds.Contains(mp.Id)))
                                                  .SingleOrDefaultAsync(d => d.Id == doctorId, cancellationToken);
            if (existingDoctor is null)
                return new NotFound();

            existingClinic.DoctorsLink.Add(new ClinicDoctor
            {
                Clinic = existingClinic,
                Doctor = existingDoctor,
                MedicalProfiles = existingDoctor.MedicalProfiles
            });

            await _dbContext.SaveChangesAsync(cancellationToken);
            // TODO: compare with requested return errors fo entities not found?
            return existingClinic;
        }

        async Task<OneOf<Success, NotFound>> IClinicCommandRepository.RemoveClinicDoctorAsync(long clinicId,
                                                                                              long doctorId,
                                                                                              CancellationToken cancellationToken)
        {
            var existingClinic = await _dbContext.Clinic.Include(c => c.DoctorsLink).SingleOrDefaultAsync(c => c.Id == clinicId, cancellationToken);
            if (existingClinic is null)
                return new NotFound();

            var linkToRemove = existingClinic.DoctorsLink.SingleOrDefault(cd => cd.DoctorId == doctorId);
            if (linkToRemove is null)
                return new NotFound();

            // TODO: doctor not exist in clinic
            existingClinic.DoctorsLink.Remove(linkToRemove);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return new Success();
        }
    }
}
