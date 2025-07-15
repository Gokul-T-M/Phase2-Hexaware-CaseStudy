using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmazeCare.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RenamedSymptomsToPreviousMedicalRecordsinPatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Symptoms",
                table: "Patients",
                newName: "PreviousMedicalRecords");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PreviousMedicalRecords",
                table: "Patients",
                newName: "Symptoms");
        }
    }
}
