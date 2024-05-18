using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement_MVC.Migrations
{
    /// <inheritdoc />
    public partial class AddCartModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "BookingRooms");

            migrationBuilder.DropColumn(
                name: "paymentStatus",
                table: "BookingExperiences");

            migrationBuilder.DropColumn(
                name: "paymentStatus",
                table: "BookingDinings");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "BookingRooms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "BookingExperiences",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "BookingDinings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    paymentMethod = table.Column<int>(type: "int", nullable: false),
                    ShippingPrice = table.Column<int>(type: "int", nullable: false),
                    paymentStatus = table.Column<int>(type: "int", nullable: false),
                    GuestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingRooms_CartId",
                table: "BookingRooms",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingExperiences_CartId",
                table: "BookingExperiences",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingDinings_CartId",
                table: "BookingDinings",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_GuestId",
                table: "Carts",
                column: "GuestId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingDinings_Carts_CartId",
                table: "BookingDinings",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingExperiences_Carts_CartId",
                table: "BookingExperiences",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingRooms_Carts_CartId",
                table: "BookingRooms",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingDinings_Carts_CartId",
                table: "BookingDinings");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingExperiences_Carts_CartId",
                table: "BookingExperiences");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingRooms_Carts_CartId",
                table: "BookingRooms");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_BookingRooms_CartId",
                table: "BookingRooms");

            migrationBuilder.DropIndex(
                name: "IX_BookingExperiences_CartId",
                table: "BookingExperiences");

            migrationBuilder.DropIndex(
                name: "IX_BookingDinings_CartId",
                table: "BookingDinings");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "BookingRooms");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "BookingExperiences");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "BookingDinings");

            migrationBuilder.AddColumn<int>(
                name: "PaymentStatus",
                table: "BookingRooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "paymentStatus",
                table: "BookingExperiences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "paymentStatus",
                table: "BookingDinings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
