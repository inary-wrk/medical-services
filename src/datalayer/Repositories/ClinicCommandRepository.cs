using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using datalayer.abstraction.Entities;
using datalayer.abstraction.Repositories;
using OneOf;
using OneOf.Types;

namespace datalayer.Repositories
{
    internal class ClinicCommandRepository : IClinicCommandRepository
    {

        private readonly CommandDbContext _dbContext;

        public ClinicCommandRepository(CommandDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        async Task<Clinic> IClinicCommandRepository.CreateAsync(Clinic clinic, CancellationToken cancellationToken)
        {
            _dbContext.Clinic.Add(clinic);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return clinic;
        }

        async Task<OneOf<Success, NotFound>> IClinicCommandRepository.DeleteAsync(long id, CancellationToken cancellationToken)
        {
            var clinic = await _dbContext.Clinic.FindAsync(new object[] { id }, cancellationToken);
            if (clinic is null)
                return new NotFound();

            _dbContext.Clinic.Remove(clinic);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return new Success();
        }

        async Task<OneOf<Clinic, NotFound>> IClinicCommandRepository.UpdateAsync(long id, Clinic clinic, CancellationToken cancellationToken)
        {
            var dbClinic = await _dbContext.Clinic.FindAsync(new object[] { id }, cancellationToken);
            
            if (dbClinic is null)
                return new NotFound();

            if (clinic.Name is not null)
                dbClinic.Name = clinic.Name;

            if (clinic.Address is not null)
                UpdateAddress(dbClinic.Address, clinic.Address);

            if (clinic.MapPoint is not null)
                dbClinic.MapPoint = clinic.MapPoint;

            if (clinic.Description is not null)
                dbClinic.Description = clinic.Description;

            if (clinic.PhotoUrl is not null)
                dbClinic.PhotoUrl = clinic.PhotoUrl;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return dbClinic;
        }

        private void UpdateAddress(Address dbAddress, Address address)
        {
            if (address.CountryISO is not null)
                dbAddress.CountryISO = address.CountryISO;

            if (address.Region is not null)
                dbAddress.Region = address.Region;

            if (address.City is not null)
                dbAddress.City = address.City;

            if (address.Street is not null)
                dbAddress.Street = address.Street;

            if (address.HouseNnumber > 0)
                dbAddress.HouseNnumber = address.HouseNnumber;

            if (address.HouseBuilding is not null)
                dbAddress.HouseBuilding = address.HouseBuilding;

            if (address.Appartament is not null)
                dbAddress.Appartament = address.Appartament;
        }
    }
}
