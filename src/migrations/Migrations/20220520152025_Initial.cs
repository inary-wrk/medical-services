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
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Clinic_Id",
                        column: x => x.Id,
                        principalTable: "Clinic",
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
                name: "PersonInformation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    DoctorId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonInformation_Doctor_DoctorId",
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

            migrationBuilder.CreateIndex(
                name: "IX_PersonInformation_DoctorId",
                table: "PersonInformation",
                column: "DoctorId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "ClinicDoctor");

            migrationBuilder.DropTable(
                name: "ClinicMedicalProfile");

            migrationBuilder.DropTable(
                name: "DoctorMedicalProfile");

            migrationBuilder.DropTable(
                name: "PersonInformation");

            migrationBuilder.DropTable(
                name: "Clinic");

            migrationBuilder.DropTable(
                name: "MedicalProfile");

            migrationBuilder.DropTable(
                name: "Doctor");
        }
    }
}
