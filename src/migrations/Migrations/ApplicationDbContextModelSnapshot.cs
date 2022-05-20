﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using datalayer;

namespace migrations.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ClinicDoctor", b =>
                {
                    b.Property<long>("ClinicId")
                        .HasColumnType("bigint");

                    b.Property<long>("DoctorId")
                        .HasColumnType("bigint");

                    b.HasKey("ClinicId", "DoctorId");

                    b.HasIndex("DoctorId");

                    b.ToTable("ClinicDoctor");
                });

            modelBuilder.Entity("ClinicMedicalProfile", b =>
                {
                    b.Property<long>("ClinicId")
                        .HasColumnType("bigint");

                    b.Property<long>("MedicalProfileId")
                        .HasColumnType("bigint");

                    b.HasKey("ClinicId", "MedicalProfileId");

                    b.HasIndex("MedicalProfileId");

                    b.ToTable("ClinicMedicalProfile");
                });

            modelBuilder.Entity("DoctorMedicalProfile", b =>
                {
                    b.Property<long>("DoctorsId")
                        .HasColumnType("bigint");

                    b.Property<long>("MedicalProfileId")
                        .HasColumnType("bigint");

                    b.HasKey("DoctorsId", "MedicalProfileId");

                    b.HasIndex("MedicalProfileId");

                    b.ToTable("DoctorMedicalProfile");
                });

            modelBuilder.Entity("datalayer.abstraction.Entities.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<long>("ClinicId")
                        .HasColumnType("bigint");

                    b.Property<string>("CountryISO")
                        .HasColumnType("text");

                    b.Property<int>("HouseBuilding")
                        .HasColumnType("integer");

                    b.Property<int>("HouseNnumber")
                        .HasColumnType("integer");

                    b.Property<double>("NorthLatitude")
                        .HasColumnType("double precision");

                    b.Property<string>("Region")
                        .HasColumnType("text");

                    b.Property<int>("Street")
                        .HasColumnType("integer");

                    b.Property<double>("WesternLongitude")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("ClinicId")
                        .IsUnique();

                    b.ToTable("Addresss");
                });

            modelBuilder.Entity("datalayer.abstraction.Entities.Clinic", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Clinics");
                });

            modelBuilder.Entity("datalayer.abstraction.Entities.Doctor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("datalayer.abstraction.Entities.MedicalProfile", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("MedicalProfiles");
                });

            modelBuilder.Entity("datalayer.abstraction.Entities.PersonInformation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("DoctorId")
                        .HasColumnType("bigint");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId")
                        .IsUnique();

                    b.ToTable("PersonInformation");
                });

            modelBuilder.Entity("ClinicDoctor", b =>
                {
                    b.HasOne("datalayer.abstraction.Entities.Clinic", null)
                        .WithMany()
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("datalayer.abstraction.Entities.Doctor", null)
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClinicMedicalProfile", b =>
                {
                    b.HasOne("datalayer.abstraction.Entities.Clinic", null)
                        .WithMany()
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("datalayer.abstraction.Entities.MedicalProfile", null)
                        .WithMany()
                        .HasForeignKey("MedicalProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DoctorMedicalProfile", b =>
                {
                    b.HasOne("datalayer.abstraction.Entities.Doctor", null)
                        .WithMany()
                        .HasForeignKey("DoctorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("datalayer.abstraction.Entities.MedicalProfile", null)
                        .WithMany()
                        .HasForeignKey("MedicalProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("datalayer.abstraction.Entities.Address", b =>
                {
                    b.HasOne("datalayer.abstraction.Entities.Clinic", "Clinic")
                        .WithOne("Address")
                        .HasForeignKey("datalayer.abstraction.Entities.Address", "ClinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clinic");
                });

            modelBuilder.Entity("datalayer.abstraction.Entities.PersonInformation", b =>
                {
                    b.HasOne("datalayer.abstraction.Entities.Doctor", "Doctor")
                        .WithOne("PersonInformation")
                        .HasForeignKey("datalayer.abstraction.Entities.PersonInformation", "DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("datalayer.abstraction.Entities.Clinic", b =>
                {
                    b.Navigation("Address");
                });

            modelBuilder.Entity("datalayer.abstraction.Entities.Doctor", b =>
                {
                    b.Navigation("PersonInformation");
                });
#pragma warning restore 612, 618
        }
    }
}
