using System;
using System.Threading;
using System.Threading.Tasks;
using datalayer.abstraction.Entities;
using datalayer.abstraction.Repositories;

namespace datalayer.Repositories
{
    public class DoctorCommandRepository : IDoctorCommandRepository
    {

        private readonly CommandDbContext _dbContext;

        public DoctorCommandRepository(CommandDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        async Task<Doctor> IDoctorCommandRepository.AddAsync(Doctor doctor, CancellationToken cancellationToken)
        {
            _dbContext.Doctor.Add(doctor);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return doctor;
        }

        Task IDoctorCommandRepository.DeleteAsync(long id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Doctor> IDoctorCommandRepository.UpdateAsync(Doctor doctor, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
