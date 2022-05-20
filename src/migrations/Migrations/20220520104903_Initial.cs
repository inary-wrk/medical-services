using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace migrations.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clinics",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    PhotoUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: true),
                    PhotoUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalProfiles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresss",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CountryISO = table.Column<string>(type: "text", nullable: true),
                    Region = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    Street = table.Column<int>(type: "integer", nullable: false),
                    HouseNnumber = table.Column<int>(type: "integer", nullable: false),
                    HouseBuilding = table.Column<int>(type: "integer", nullable: false),
                    NorthLatitude = table.Column<double>(type: "double precision", nullable: false),
                    WesternLongitude = table.Column<double>(type: "double precision", nullable: false),
                    ClinicId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresss_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_ClinicDoctor_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClinicDoctor_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonInformation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    DoctorId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonInformation_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
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
                        name: "FK_ClinicMedicalProfile_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClinicMedicalProfile_MedicalProfiles_MedicalProfileId",
                        column: x => x.MedicalProfileId,
                        principalTable: "MedicalProfiles",
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
                        name: "FK_DoctorMedicalProfile_Doctors_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorMedicalProfile_MedicalProfiles_MedicalProfileId",
                        column: x => x.MedicalProfileId,
                        principalTable: "MedicalProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresss_ClinicId",
                table: "Addresss",
                column: "ClinicId",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_PersonInformation_DoctorId",
                table: "PersonInformation",
                column: "DoctorId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresss");

            migrationBuilder.DropTable(
                name: "ClinicDoctor");

            migrationBuilder.DropTable(
                name: "ClinicMedicalProfile");

            migrationBuilder.DropTable(
                name: "DoctorMedicalProfile");

            migrationBuilder.DropTable(
                name: "PersonInformation");

            migrationBuilder.DropTable(
                name: "Clinics");

            migrationBuilder.DropTable(
                name: "MedicalProfiles");

            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
