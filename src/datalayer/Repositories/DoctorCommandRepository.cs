using System.Threading;
using System.Threading.Tasks;
using datalayer.abstraction.Entities;
using datalayer.abstraction.Repositories;
using Microsoft.EntityFrameworkCore;
using OneOf;
using OneOf.Types;
using businesslogic.abstraction.Dto;
using businesslogic.abstraction.Contracts;

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

        async Task<OneOf<Success, NotFound>> IDoctorCommandRepository.DeleteAsync(long id, CancellationToken cancellationToken)
        {
            var doctor = await _dbContext.Doctor.FindAsync(new object[] { id }, cancellationToken);
            if (doctor is null)
                return new NotFound();

            _dbContext.Doctor.Remove(doctor);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return new Success();
        }

        async Task<OneOf<Doctor, NotFound>> IDoctorCommandRepository.UpdateAsync(long id, DoctorDto.Request.Update doctor, CancellationToken cancellationToken)
        {
            var dbDoctor = await _dbContext.Doctor.FindAsync(new object[] { id }, cancellationToken);
            if (dbDoctor is null)
                return new NotFound();

            _mapper.Map(doctor, dbDoctor);

            await _dbContext.SaveChangesAsync(cancellationToken);
            return dbDoctor;
        }
    }
}
