using System.Net;
using datalayer.abstraction.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace datalayer
{
    public sealed class CommandDbContext : DbContext
    {

        private readonly IConfiguration _configuration;

        DbSet<Doctor> Doctor { get; set; }
        DbSet<Clinic> Clinic { get; set; }
        DbSet<MedicalProfile> MedicalProfile { get; set; }
        DbSet<Person> Person { get; set; }


        public CommandDbContext(DbContextOptions<CommandDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration["CONNECTION_STRINGS:COMMANDCONNECTION"]);
            base.OnConfiguring(optionsBuilder);
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
                .OwnsOne(clinic => clinic.Address);
            modelBuilder.Entity<Clinic>()
                .OwnsOne(clinic => clinic.MapPoint);

            modelBuilder.Entity<Doctor>()
                .HasOne(doctor => doctor.Person)
                .WithOne(personInformation => personInformation.Doctor)
                .HasForeignKey<Person>(personInformation => personInformation.DoctorId);
        }
    }
}
