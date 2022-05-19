using datalayer.abstraction.Entities;
using Microsoft.EntityFrameworkCore;

namespace datalayer
{
    public sealed class ApplicationDbContext : DbContext
    {
        DbSet<Doctor> Doctors { get; set; }
        DbSet<Clinic> Clinics { get; set; }
        DbSet<MedicalProfile> MedicalProfiles { get; set; }
        DbSet<Address> Addresss { get; set; }
        DbSet<PersonInformation> PersonInformation { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicalProfile>()
                .HasMany(medicalProfile => medicalProfile.Clinic)
                .WithMany(clinic => clinic.MedicalProfile);

            modelBuilder.Entity<MedicalProfile>()
                .HasMany(medicalProfile => medicalProfile.Doctors)
                .WithMany(doctor => doctor.MedicalProfile);

            modelBuilder.Entity<Clinic>()
                .HasMany(clinic => clinic.Doctor)
                .WithMany(doctor => doctor.Clinic);

            modelBuilder.Entity<Doctor>()
                .HasOne(doctor => doctor.PersonInformation)
                .WithOne(personInformation => personInformation.Doctor)
                .HasForeignKey<PersonInformation>(personInformation => personInformation.DoctorId)
                .IsRequired();

            modelBuilder.Entity<Clinic>()
                .HasOne(clinic => clinic.Address)
                .WithOne(address => address.Clinic)
                .HasForeignKey<Address>(address => address.ClinicId)
                .IsRequired();
        }
    }
}
