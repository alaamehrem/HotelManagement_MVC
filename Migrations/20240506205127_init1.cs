using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement_MVC.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HotelRoomTypes",
                columns: new[] { "Id", "Area", "BathCount", "BedCount", "BedType", "Decor", "Description", "Images", "MaxGuestCount", "Name", "Price", "UniqueFeatures", "View" },
                values: new object[] { 6, 250, 1, 1, "Panel bed with plush Frette Linens", "Modern decor with elegant touches", "Experience luxury and comfort in our Premium King Room, a corner room offering unparalleled views and deluxe amenities. Relax in a spacious environment featuring one King-size bed adorned with Frette Linens, a separate sitting area, and floor-to-ceiling windows showcasing breathtaking vistas. Stay productive with a full-size work desk and stay entertained with a large screen HDTV equipped with Google Chromecast. Pamper yourself in the luxurious marble shower and indulge in C.O Bigelow bath amenities. Perfect for discerning travelers seeking the ultimate in sophistication and relaxation.", "PremiumKingRoom.jpg", 2, "Premium King Room", 6000, "Spacious corner room with abundant natural light, High-end furnishings and decor, Marble bathroom with luxurious jacuzzi bathtub, Complimentary high-speed Wi-Fi, In-room dining available 24/7, Personalized concierge service for all your needs.", "Spectacular sea view from floor-to-ceiling windows" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HotelRoomTypes",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
