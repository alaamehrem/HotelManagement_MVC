using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelManagement_MVC.Migrations
{
    /// <inheritdoc />
    public partial class editDining : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "Dinings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Dinings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TimeOfDay",
                table: "Dinings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Dinings",
                columns: new[] { "Description", "Duration", "Images", "Name", "Price", "TimeOfDay" },
                values: new object[,]
                {
                    {  "Picture an elegant table for two, sheltered by palm trees and serenaded by gentle ocean waves. Our team of chefs will prepare a special menu, paired with fine wines and served by your own private attendant. Toes in the sand, glimmering candles and tiki torches make for an incredibly romantic evening.", "3 HOURS", "KOH_1450_original.jpg", "ONCE IN A BLUE MOON", 5000, "EVENING" },
                    {  "Framed by towering palm trees, pristine white sand and the gentle waves of the Pacific Ocean, linger over creative cocktails while the sun sinks gently into the ocean. Then dine barefoot with the sand between your toes, at your very own private table on the beach.", "4 HOURS", "COS_2047_original.jpg", "VIRADOR EXPERIENCE", 7000, "MORNING, AFTERNOON, EVENING" },
                    {  "An intimate dining experience for couples who wish to spend a special evening with toes in the sand as the sun sets and the stars come out. The scene is set for romance with Ruinart Rose, flowers and a private server, as you enjoy a personally curated four course menu highlighting local ingredients.", "2 HOURS", "KON_1192_original.jpg", "COUPLES DINING EXPERIENCE", 6000, "EVENING" },
                    {  "Before the sun begins to set, take a seat at a private table for two overlooking Hulopoe Bay. As evening descends, enjoy a Champagne welcome followed by a customized menu prepared just for you in consultation with our expert chefs.", "3 HOURS", "KON_1192_original.jpg", "DINING UNDER THE STARS", 8000, "EVENING" },
                    {  "A custom gourmet dinner prepared exclusively by our chef, with cocktails or wines selected by our sommelier and served by your own personal waiter on a private grassy knoll overlooking Wailea Beach.", "3 HOURS", "MAU_2025_original.jpg", "WAILEA POINT PRIVATE DINING", 8000, "EVENING" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dinings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Dinings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Dinings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Dinings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Dinings",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Dinings");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Dinings");

            migrationBuilder.DropColumn(
                name: "TimeOfDay",
                table: "Dinings");
        }
    }
}
