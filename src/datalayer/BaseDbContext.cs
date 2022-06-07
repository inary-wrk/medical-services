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
                .HasMany(medicalProfile => medicalProfile.Doctors)
                .WithMany(doctor => doctor.MedicalProfiles);

            modelBuilder.Entity<ClinicDoctor>()
                .HasKey(cd => new { cd.ClinicId, cd.DoctorId });
            modelBuilder.Entity<ClinicDoctor>()
                .HasOne(cd => cd.Clinic)
                .WithMany(c => c.DoctorsLink)
                .HasForeignKey(cd => cd.ClinicId);
            modelBuilder.Entity<ClinicDoctor>()
                .HasOne(cd => cd.Doctor)
                .WithMany(d => d.ClinicsLink)
                .HasForeignKey(cd => cd.DoctorId);
            modelBuilder.Entity<ClinicDoctor>()
                .HasMany(cd => cd.MedicalProfiles)
                .WithMany(mp => mp.ClinicDoctors);

            modelBuilder.Entity<Clinic>()
                .OwnsOne(clinic => clinic.Address)
                .HasIndex(a => a.CityCode);
            modelBuilder.Entity<Clinic>()
                .OwnsOne(clinic => clinic.MapPoint);
        }
    }
}
