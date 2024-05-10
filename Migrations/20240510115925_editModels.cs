using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement_MVC.Migrations
{
    /// <inheritdoc />
    public partial class editModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "BookingExperiences");

            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "Experiences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Experiences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "Experiences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Experiences");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "BookingExperiences",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
