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
                    Address_CountryISO = table.Column<string>(type: "text", nullable: false),
                    Address_Region = table.Column<string>(type: "text", nullable: false),
                    Address_City = table.Column<string>(type: "text", nullable: false),
                    Address_Street = table.Column<string>(type: "text", nullable: false),
                    Address_HouseNnumber = table.Column<int>(type: "integer", nullable: false),
                    Address_HouseBuilding = table.Column<int>(type: "integer", nullable: false),
                    Address_Appartament = table.Column<int>(type: "integer", nullable: false),
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
                name: "ClinicMedicalProfile",
                columns: table => new
                {
                    ClinicId = table.Column<long>(type: "bigint", nullable: false),
                    MedicalProfileId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicMedicalProfile", x => new { x.ClinicId, x.MedicalProfileId });
                    table.ForeignKey(
                        name: "FK_ClinicMedicalProfile_Clinic_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClinicMedicalProfile_MedicalProfile_MedicalProfileId",
                        column: x => x.MedicalProfileId,
                        principalTable: "MedicalProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorMedicalProfile",
                columns: table => new
                {
                    DoctorsId = table.Column<long>(type: "bigint", nullable: false),
                    MedicalProfileId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorMedicalProfile", x => new { x.DoctorsId, x.MedicalProfileId });
                    table.ForeignKey(
                        name: "FK_DoctorMedicalProfile_Doctor_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorMedicalProfile_MedicalProfile_MedicalProfileId",
                        column: x => x.MedicalProfileId,
                        principalTable: "MedicalProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClinicDoctor_DoctorId",
                table: "ClinicDoctor",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicMedicalProfile_MedicalProfileId",
                table: "ClinicMedicalProfile",
                column: "MedicalProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorMedicalProfile_MedicalProfileId",
                table: "DoctorMedicalProfile",
                column: "MedicalProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClinicDoctor");

            migrationBuilder.DropTable(
                name: "ClinicMedicalProfile");

            migrationBuilder.DropTable(
                name: "DoctorMedicalProfile");

            migrationBuilder.DropTable(
                name: "Clinic");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "MedicalProfile");
        }
    }
}
