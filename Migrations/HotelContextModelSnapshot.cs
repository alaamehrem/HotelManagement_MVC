﻿// <auto-generated />
using System;
using HotelManagement_MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelManagement_MVC.Migrations
{
    [DbContext(typeof(HotelContext))]
    partial class HotelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HotelManagement_MVC.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("HotelManagement_MVC.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Fname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("HotelManagement_MVC.Models.BookingDining", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("CartId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DiningId")
                        .HasColumnType("int");

                    b.Property<int>("NumAdults")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("SpecialRequest")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CartId");

                    b.HasIndex("DiningId");

                    b.ToTable("BookingDinings");
                });

            modelBuilder.Entity("HotelManagement_MVC.Models.BookingExperience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("CartId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ExperienceId")
                        .HasColumnType("int");

                    b.Property<int>("NumAdults")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("SpecialRequest")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CartId");

                    b.HasIndex("ExperienceId");

                    b.ToTable("BookingExperiences");
                });

            modelBuilder.Entity("HotelManagement_MVC.Models.BookingRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("CartId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOutDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("HotelRoomId")
                        .HasColumnType("int");

                    b.Property<int>("NumAdults")
                        .HasColumnType("int");

                    b.Property<int>("NumChildren")
                        .HasColumnType("int");

                    b.Property<int?>("NumOfRooms")
                        .HasColumnType("int");

                    b.Property<int>("OfferId")
                        .HasColumnType("int");

                    b.Property<string>("SpecialRequest")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TotalDays")
                        .HasColumnType("int");

                    b.Property<int?>("TotalPrice")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CartId");

                    b.HasIndex("HotelRoomId");

                    b.HasIndex("OfferId");

                    b.ToTable("BookingRooms");
                });

            modelBuilder.Entity("HotelManagement_MVC.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ShippingPrice")
                        .HasColumnType("int");

                    b.Property<int>("paymentMethod")
                        .HasColumnType("int");

                    b.Property<int>("paymentStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("HotelManagement_MVC.Models.Dining", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Images")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("TimeOfDay")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Dinings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Picture an elegant table for two, sheltered by palm trees and serenaded by gentle ocean waves. Our team of chefs will prepare a special menu, paired with fine wines and served by your own private attendant. Toes in the sand, glimmering candles and tiki torches make for an incredibly romantic evening.",
                            Duration = "3 HOURS",
                            Images = "KOH_1450_original.jpg",
                            Name = "ONCE IN A BLUE MOON",
                            Price = 5000,
                            TimeOfDay = "EVENING"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Framed by towering palm trees, pristine white sand and the gentle waves of the Pacific Ocean, linger over creative cocktails while the sun sinks gently into the ocean. Then dine barefoot with the sand between your toes, at your very own private table on the beach.",
                            Duration = "4 HOURS",
                            Images = "COS_2047_original.jpg",
                            Name = "VIRADOR EXPERIENCE",
                            Price = 7000,
                            TimeOfDay = "MORNING, AFTERNOON, EVENING"
                        },
                        new
                        {
                            Id = 3,
                            Description = "An intimate dining experience for couples who wish to spend a special evening with toes in the sand as the sun sets and the stars come out. The scene is set for romance with Ruinart Rose, flowers and a private server, as you enjoy a personally curated four course menu highlighting local ingredients.",
                            Duration = "2 HOURS",
                            Images = "KON_1192_original.jpg",
                            Name = "COUPLES DINING EXPERIENCE",
                            Price = 6000,
                            TimeOfDay = "EVENING"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Before the sun begins to set, take a seat at a private table for two overlooking Hulopoe Bay. As evening descends, enjoy a Champagne welcome followed by a customized menu prepared just for you in consultation with our expert chefs.",
                            Duration = "3 HOURS",
                            Images = "KON_1192_original.jpg",
                            Name = "DINING UNDER THE STARS",
                            Price = 8000,
                            TimeOfDay = "EVENING"
                        },
                        new
                        {
                            Id = 5,
                            Description = "A custom gourmet dinner prepared exclusively by our chef, with cocktails or wines selected by our sommelier and served by your own personal waiter on a private grassy knoll overlooking Wailea Beach.",
                            Duration = "3 HOURS",
                            Images = "MAU_2025_original.jpg",
                            Name = "WAILEA POINT PRIVATE DINING",
                            Price = 8000,
                            TimeOfDay = "EVENING"
                        });
                });

            modelBuilder.Entity("HotelManagement_MVC.Models.Experience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CoverImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Requirements")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<string>("instructions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Experiences");
                });

            modelBuilder.Entity("HotelManagement_MVC.Models.ExperienceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ExperienceTypes");
                });

            modelBuilder.Entity("HotelManagement_MVC.Models.HotelFloor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FloorNum")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("HotelFloors");
                });

            modelBuilder.Entity("HotelManagement_MVC.Models.HotelReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DatePosted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Review")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("HotelReviews");
                });

            modelBuilder.Entity("HotelManagement_MVC.Models.HotelRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HotelFloorId")
                        .HasColumnType("int");

                    b.Property<int>("HotelRoomTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelFloorId");

                    b.HasIndex("HotelRoomTypeId");

                    b.ToTable("HotelRooms");
                });

            modelBuilder.Entity("HotelManagement_MVC.Models.HotelRoomType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Area")
                        .HasColumnType("int");

                    b.Property<int>("BathCount")
                        .HasColumnType("int");

                    b.Property<int>("BedCount")
                        .HasColumnType("int");

                    b.Property<string>("BedType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Decor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Images")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxGuestCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("UniqueFeatures")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("View")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HotelRoomTypes");

                    b.HasData(
                        new
                        {
                            Id = 6,
                            Area = 250,
                            BathCount = 1,
                            BedCount = 1,
                            BedType = "Panel bed with plush Frette Linens",
                            Decor = "Modern decor with elegant touches",
                            Description = "Experience luxury and comfort in our Premium King Room, a corner room offering unparalleled views and deluxe amenities. Relax in a spacious environment featuring one King-size bed adorned with Frette Linens, a separate sitting area, and floor-to-ceiling windows showcasing breathtaking vistas. Stay productive with a full-size work desk and stay entertained with a large screen HDTV equipped with Google Chromecast. Pamper yourself in the luxurious marble shower and indulge in C.O Bigelow bath amenities. Perfect for discerning travelers seeking the ultimate in sophistication and relaxation.",
                            Images = "PremiumKingRoom.jpg",
                            MaxGuestCount = 2,
                            Name = "Premium King Room",
                            Price = 6000,
                            UniqueFeatures = "Spacious corner room with abundant natural light, High-end furnishings and decor, Marble bathroom with luxurious jacuzzi bathtub, Complimentary high-speed Wi-Fi, In-room dining available 24/7, Personalized concierge service for all your needs.",
                            View = "Spectacular sea view from floor-to-ceiling windows"
                        });
                });

            modelBuilder.Entity("HotelManagement_MVC.Models.Offer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("OfferDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OfferImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OfferName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OfferPrice")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Offers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OfferDescription = "Start your day with our mouthwatering breakfast options",
                            OfferImage = "breakfast.jpg",
                            OfferName = "Breakfast Only",
                            OfferPrice = 250
                        },
                        new
                        {
                            Id = 2,
                            OfferDescription = "Indulge in our savory lunch specials that will tantalize your taste buds",
                            OfferImage = "lunch.jpg",
                            OfferName = "Lunch Only",
                            OfferPrice = 300
                        },
                        new
                        {
                            Id = 3,
                            OfferDescription = "Experience the ultimate culinary journey with our delicious breakfast and lunch combo",
                            OfferImage = "combo.jpg",
                            OfferName = "Both Breakfast and Lunch",
                            OfferPrice = 500
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("HotelManagement_MVC.Models.BookingDining", b =>
                {
                    b.HasOne("HotelManagement_MVC.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelManagement_MVC.Models.Cart", null)
                        .WithMany("BookingDinings")
                        .HasForeignKey("CartId");

                    b.HasOne("HotelManagement_MVC.Models.Dining", "Dining")
                        .WithMany("BookingDinings")
                        .HasForeignKey("DiningId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Dining");
                });

            modelBuilder.Entity("HotelManagement_MVC.Models.BookingExperience", b =>
                {
                    b.HasOne("HotelManagement_MVC.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelManagement_MVC.Models.Cart", null)
                        .WithMany("BookingExperiences")
                        .HasForeignKey("CartId");

                    b.HasOne("HotelManagement_MVC.Models.Experience", null)
                        .WithMany("BookingExperiences")
                        .HasForeignKey("ExperienceId");

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("HotelManagement_MVC.Models.BookingRoom", b =>
                {
                    b.HasOne("HotelManagement_MVC.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelManagement_MVC.Models.Cart", null)
                        .WithMany("BookingRooms")
                        .HasForeignKey("CartId");

                    b.HasOne("HotelManagement_MVC.Models.HotelRoom", "HotelRoom")
                        .WithMany("BookingRoom")
                        .HasForeignKey("HotelRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelManagement_MVC.Models.Offer", "Offer")
                        .WithMany()
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("HotelRoom");

                    b.Navigation("Offer");
                });

            modelBuilder.Entity("HotelManagement_MVC.Models.Cart", b =>
                {
                    b.HasOne("HotelManagement_MVC.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("HotelManagement_MVC.Models.Experience", b =>
                {
                    b.HasOne("HotelManagement_MVC.Models.ExperienceType", "Type")
                        .WithMany("Experiences")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("HotelManagement_MVC.Models.HotelReview", b =>
                {
                    b.HasOne("HotelManagement_MVC.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("HotelManagement_MVC.Models.HotelRoom", b =>
                {
                    b.HasOne("HotelManagement_MVC.Models.HotelFloor", "HotelFloor")
                        .WithMany()
                        .HasForeignKey("HotelFloorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelManagement_MVC.Models.HotelRoomType", "HotelRoomType")
                        .WithMany()
                        .HasForeignKey("HotelRoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HotelFloor");

                    b.Navigation("HotelRoomType");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("HotelManagement_MVC.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HotelManagement_MVC.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelManagement_MVC.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("HotelManagement_MVC.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HotelManagement_MVC.Models.Cart", b =>
                {
                    b.Navigation("BookingDinings");

                    b.Navigation("BookingExperiences");

                    b.Navigation("BookingRooms");
                });

            modelBuilder.Entity("HotelManagement_MVC.Models.Dining", b =>
                {
                    b.Navigation("BookingDinings");
                });

            modelBuilder.Entity("HotelManagement_MVC.Models.Experience", b =>
                {
                    b.Navigation("BookingExperiences");
                });

            modelBuilder.Entity("HotelManagement_MVC.Models.ExperienceType", b =>
                {
                    b.Navigation("Experiences");
                });

            modelBuilder.Entity("HotelManagement_MVC.Models.HotelRoom", b =>
                {
                    b.Navigation("BookingRoom");
                });
#pragma warning restore 612, 618
        }
    }
}
