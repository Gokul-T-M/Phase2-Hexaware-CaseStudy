using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmazeCare.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddConsultingFieldsToAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Prescriptions",
                table: "Appointments",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecommendedTests",
                table: "Appointments",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Symptoms",
                table: "Appointments",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prescriptions",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "RecommendedTests",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Symptoms",
                table: "Appointments");
        }
    }
}
