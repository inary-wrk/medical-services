﻿using datalayer.abstraction.Entities;
using Microsoft.EntityFrameworkCore;

namespace datalayer
{
    public abstract class BaseDbContext : DbContext
    {
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Clinic> Clinic { get; set; }
        public DbSet<MedicalProfile> MedicalProfile { get; set; }

        protected BaseDbContext(DbContextOptions contextOptions)
           : base(contextOptions)
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
                .OwnsOne(clinic => clinic.Address);
            modelBuilder.Entity<Clinic>()
                .OwnsOne(clinic => clinic.MapPoint);
        }
    }
}