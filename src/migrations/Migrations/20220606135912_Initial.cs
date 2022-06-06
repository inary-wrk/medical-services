using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace migrations.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clinic",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address_PostalCode = table.Column<int>(type: "integer", nullable: false),
                    Address_CountryISO = table.Column<string>(type: "text", nullable: false),
                    Address_Region = table.Column<string>(type: "text", nullable: false),
                    Address_City = table.Column<string>(type: "text", nullable: false),
                    Address_CityCode = table.Column<string>(type: "text", nullable: false),
                    Address_Street = table.Column<string>(type: "text", nullable: false),
                    Address_HouseNnumber = table.Column<int>(type: "integer", nullable: false),
                    Address_HouseBuilding = table.Column<int>(type: "integer", nullable: true),
                    Address_Appartament = table.Column<int>(type: "integer", nullable: true),
                    MapPoint_NorthLatitude = table.Column<double>(type: "double precision", nullable: true),
                    MapPoint_WesternLongitude = table.Column<double>(type: "double precision", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    PhotoUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    PhotoUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalProfile",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalProfile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClinicDoctor",
                columns: table => new
                {
                    ClinicId = table.Column<long>(type: "bigint", nullable: false),
                    DoctorId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicDoctor", x => new { x.ClinicId, x.DoctorId });
                    table.ForeignKey(
                        name: "FK_ClinicDoctor_Clinic_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClinicDoctor_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorMedicalProfile",
                columns: table => new
                {
                    DoctorsId = table.Column<long>(type: "bigint", nullable: false),
                    MedicalProfilesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorMedicalProfile", x => new { x.DoctorsId, x.MedicalProfilesId });
                    table.ForeignKey(
                        name: "FK_DoctorMedicalProfile_Doctor_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorMedicalProfile_MedicalProfile_MedicalProfilesId",
                        column: x => x.MedicalProfilesId,
                        principalTable: "MedicalProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClinicDoctorMedicalProfile",
                columns: table => new
                {
                    MedicalProfilesId = table.Column<long>(type: "bigint", nullable: false),
                    ClinicDoctorsClinicId = table.Column<long>(type: "bigint", nullable: false),
                    ClinicDoctorsDoctorId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicDoctorMedicalProfile", x => new { x.MedicalProfilesId, x.ClinicDoctorsClinicId, x.ClinicDoctorsDoctorId });
                    table.ForeignKey(
                        name: "FK_ClinicDoctorMedicalProfile_ClinicDoctor_ClinicDoctorsClinic~",
                        columns: x => new { x.ClinicDoctorsClinicId, x.ClinicDoctorsDoctorId },
                        principalTable: "ClinicDoctor",
                        principalColumns: new[] { "ClinicId", "DoctorId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClinicDoctorMedicalProfile_MedicalProfile_MedicalProfilesId",
                        column: x => x.MedicalProfilesId,
                        principalTable: "MedicalProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clinic_Address_CityCode",
                table: "Clinic",
                column: "Address_CityCode");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicDoctor_DoctorId",
                table: "ClinicDoctor",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicDoctorMedicalProfile_ClinicDoctorsClinicId_ClinicDoct~",
                table: "ClinicDoctorMedicalProfile",
                columns: new[] { "ClinicDoctorsClinicId", "ClinicDoctorsDoctorId" });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorMedicalProfile_MedicalProfilesId",
                table: "DoctorMedicalProfile",
                column: "MedicalProfilesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClinicDoctorMedicalProfile");

            migrationBuilder.DropTable(
                name: "DoctorMedicalProfile");

            migrationBuilder.DropTable(
                name: "ClinicDoctor");

            migrationBuilder.DropTable(
                name: "MedicalProfile");

            migrationBuilder.DropTable(
                name: "Clinic");

            migrationBuilder.DropTable(
                name: "Doctor");
        }
    }
}
