using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement_MVC.Migrations
{
    /// <inheritdoc />
    public partial class addFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExperienceId",
                table: "BookingExperiences",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookingExperiences_ExperienceId",
                table: "BookingExperiences",
                column: "ExperienceId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingExperiences_Experiences_ExperienceId",
                table: "BookingExperiences",
                column: "ExperienceId",
                principalTable: "Experiences",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingExperiences_Experiences_ExperienceId",
                table: "BookingExperiences");

            migrationBuilder.DropIndex(
                name: "IX_BookingExperiences_ExperienceId",
                table: "BookingExperiences");

            migrationBuilder.DropColumn(
                name: "ExperienceId",
                table: "BookingExperiences");
        }
    }
}
