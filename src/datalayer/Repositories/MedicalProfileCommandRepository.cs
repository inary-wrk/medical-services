using System.Threading;
using System.Threading.Tasks;
using datalayer.abstraction.Entities;
using datalayer.abstraction.Repositories;
using OneOf.Types;
using OneOf;
using businesslogic.abstraction.Dto;
using businesslogic.abstraction.Contracts;

namespace datalayer.Repositories
{
    internal class MedicalProfileCommandRepository : IMedicalProfileCommandRepository
    {
        private readonly CommandDbContext _dbContext;
        private readonly IMapper _mapper;

        public MedicalProfileCommandRepository(CommandDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        async Task<MedicalProfile> IMedicalProfileCommandRepository.CreateAsync(MedicalProfileDto.Request.Create medicalProfileDto, CancellationToken cancellationToken)
        {
            var medicalProfileDb = _mapper.Map<MedicalProfileDto.Request.Create, MedicalProfile>(medicalProfileDto);
            _dbContext.MedicalProfile.Add(medicalProfileDb);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return medicalProfileDb;
        }

        async Task<OneOf<MedicalProfile, NotFound>> IMedicalProfileCommandRepository.UpdateAsync(long id, MedicalProfileDto.Request.Update medicalProfileDto, CancellationToken cancellationToken)
        {
            var medicalProfileDb = await _dbContext.MedicalProfile.FindAsync(new object[] { id }, cancellationToken);
            if (medicalProfileDto is null)
                return new NotFound();

            _mapper.Map(medicalProfileDto, medicalProfileDb);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return medicalProfileDb;
        }
    }
}
