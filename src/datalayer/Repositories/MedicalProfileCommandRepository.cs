using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using datalayer.abstraction.Entities;
using datalayer.abstraction.Repositories;
using OneOf.Types;
using OneOf;

namespace datalayer.Repositories
{
    internal class MedicalProfileCommandRepository : IMedicalProfileCommandRepository
    {
        private readonly CommandDbContext _dbContext;

        public MedicalProfileCommandRepository(CommandDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        async Task<MedicalProfile> IMedicalProfileCommandRepository.CreateAsync(MedicalProfile medicalProfile, CancellationToken cancellationToken)
        {
            _dbContext.MedicalProfile.Add(medicalProfile);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return medicalProfile;
        }
        
        async Task<OneOf<Success, NotFound>> IMedicalProfileCommandRepository.DeleteAsync(long id, CancellationToken cancellationToken)
        {
            var medicalProfile = await _dbContext.MedicalProfile.FindAsync(new object[] { id }, cancellationToken);
            if (medicalProfile is null)
                return new NotFound();
            
            _dbContext.MedicalProfile.Remove(medicalProfile);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return new Success();
        }

        async Task<OneOf<MedicalProfile, NotFound>> IMedicalProfileCommandRepository.UpdateAsync(long id, MedicalProfile medicalProfile, CancellationToken cancellationToken)
        {
            var dbMedicalProfile = await _dbContext.MedicalProfile.FindAsync(new object[] { id }, cancellationToken);
            if (medicalProfile is null)
                return new NotFound();

            dbMedicalProfile.Name = medicalProfile.Name ?? dbMedicalProfile.Name;
            dbMedicalProfile.Description = medicalProfile.Description ?? dbMedicalProfile.Description;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return dbMedicalProfile;
        }
    }
}
