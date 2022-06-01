using System.Threading;
using System.Threading.Tasks;
using datalayer.abstraction.Entities;
using datalayer.abstraction.Repositories;
using Microsoft.EntityFrameworkCore;
using OneOf;
using OneOf.Types;

namespace datalayer.Repositories
{
    internal class DoctorCommandRepository : IDoctorCommandRepository
    {
        private readonly CommandDbContext _dbContext;

        public DoctorCommandRepository(CommandDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        async Task<Doctor> IDoctorCommandRepository.CreateAsync(Doctor doctor, CancellationToken cancellationToken)
        {
            _dbContext.Doctor.Add(doctor);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return doctor;
        }

        async Task<OneOf<Success, NotFound>> IDoctorCommandRepository.DeleteAsync(long id, CancellationToken cancellationToken)
        {
            var doctor = await _dbContext.Doctor.FindAsync(new object[] { id }, cancellationToken);
            if (doctor is null)
                return new NotFound();

            _dbContext.Doctor.Remove(doctor);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return new Success();
        }

        async Task<OneOf<Doctor, NotFound>> IDoctorCommandRepository.UpdateAsync(long id, Doctor doctor, CancellationToken cancellationToken)
        {
            var dbDoctor = await _dbContext.Doctor.FindAsync(new object[] { id }, cancellationToken);
            if (dbDoctor is null)
                return new NotFound();

            dbDoctor.FirstName = doctor.FirstName ?? dbDoctor.FirstName;
            dbDoctor.LastName = doctor.LastName ?? dbDoctor.LastName;
            dbDoctor.Surname = doctor.Surname ?? dbDoctor.Surname;
            dbDoctor.Description = doctor.Description ?? dbDoctor.Description;
            dbDoctor.PhotoUrl = doctor.PhotoUrl ?? dbDoctor.PhotoUrl;
            dbDoctor.MedicalProfile = doctor.MedicalProfile ?? dbDoctor.MedicalProfile;
            dbDoctor.Clinics = doctor.Clinics ?? dbDoctor.Clinics;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return dbDoctor;
        }
    }
}
