using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement_MVC.Migrations
{
    /// <inheritdoc />
    public partial class price : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingDinings_Dinings_DiningId",
                table: "BookingDinings");


            migrationBuilder.AddColumn<int>(
                name: "TotalPrice",
                table: "BookingRooms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "BookingExperiences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "DiningId",
                table: "BookingDinings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingDinings_Dinings_DiningId",
                table: "BookingDinings",
                column: "DiningId",
                principalTable: "Dinings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingDinings_Dinings_DiningId",
                table: "BookingDinings");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "BookingRooms");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "BookingExperiences");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "HotelRooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "DiningId",
                table: "BookingDinings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingDinings_Dinings_DiningId",
                table: "BookingDinings",
                column: "DiningId",
                principalTable: "Dinings",
                principalColumn: "Id");
        }
    }
}
