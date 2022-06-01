using datalayer.abstraction.Entities;
using Microsoft.EntityFrameworkCore;

namespace datalayer
{
    public abstract class BaseDbContext : DbContext
    {
        public DbSet<Doctor> Doctor { get; set; } = null!;
        public DbSet<Clinic> Clinic { get; set; } = null!;
        public DbSet<MedicalProfile> MedicalProfile { get; set; } = null!;

        protected BaseDbContext(DbContextOptions contextOptions)
           : base(contextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicalProfile>()
                .HasMany(medicalProfile => medicalProfile.Clinics)
                .WithMany(clinic => clinic.MedicalProfile);
            modelBuilder.Entity<MedicalProfile>()
                .HasMany(medicalProfile => medicalProfile.Doctors)
                .WithMany(doctor => doctor.MedicalProfile);
            modelBuilder.Entity<MedicalProfile>()
                .Property(p=>p.DoctorCount)
                .HasComputedColumnSql("", true);

            modelBuilder.Entity<Clinic>()
                .HasMany(clinic => clinic.Doctor)
                .WithMany(doctor => doctor.Clinics);
            modelBuilder.Entity<Clinic>()
                .OwnsOne(clinic => clinic.Address);
            modelBuilder.Entity<Clinic>()
                .OwnsOne(clinic => clinic.MapPoint);
        }
    }
}
