using System.Net;
using datalayer.abstraction.Entities;
using Microsoft.EntityFrameworkCore;

namespace datalayer
{
    public sealed class ApplicationDbContext : DbContext
    {
        DbSet<Doctor> Doctor { get; set; }
        DbSet<Clinic> Clinic { get; set; }
        DbSet<MedicalProfile> MedicalProfile { get; set; }
        DbSet<Address> Address { get; set; }
        DbSet<Person> PersonInformation { get; set; }


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

            modelBuilder.Entity<Clinic>()
                .HasOne(clinic => clinic.Address)
                .WithOne(address => address.Clinic)
                .HasForeignKey<Address>(address => address.Id);

            modelBuilder.Entity<Doctor>()
                .HasOne(doctor => doctor.PersonInformation)
                .WithOne(personInformation => personInformation.Doctor)
                .HasForeignKey<Person>(personInformation => personInformation.DoctorId);
        }
    }
}
