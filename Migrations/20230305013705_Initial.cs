using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auction_House.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinimumBid = table.Column<double>(type: "float", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuctionStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuctionEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ItemCondition = table.Column<int>(type: "int", nullable: false),
                    ItemCategory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sellers_Items",
                columns: table => new
                {
                    SellerId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers_Items", x => new { x.SellerId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_Sellers_Items_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sellers_Items_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "AuctionEnd", "AuctionStart", "Description", "ImageURL", "ItemCategory", "ItemCondition", "MinimumBid", "Name" },
                values: new object[,]
                {
                    { -6, new DateTime(2023, 3, 7, 20, 37, 5, 395, DateTimeKind.Local).AddTicks(2163), new DateTime(2023, 3, 4, 20, 37, 5, 395, DateTimeKind.Local).AddTicks(2162), "Stay comfortable and stylish with this grey hoodie. Made with high-quality materials, this hoodie is soft, warm, and perfect for everyday wear. The classic design features a comfortable fit, drawstring hood, and kangaroo pocket for added convenience. The neutral grey color is perfect for pairing with any outfit, and the hoodie is available in various sizes to suit individual preferences. Whether you're lounging at home or running errands, this grey hoodie is the perfect choice for comfort and style. Shop now to upgrade your wardrobe!", "/img/hoodie.jpg", 2, 0, 29.5, "Hoodie" },
                    { -5, new DateTime(2023, 3, 7, 20, 37, 5, 395, DateTimeKind.Local).AddTicks(2159), new DateTime(2023, 3, 4, 20, 37, 5, 395, DateTimeKind.Local).AddTicks(2158), "Illuminate your workspace with this stylish and functional desk lamp. Featuring adjustable brightness levels and color temperature, this lamp provides the perfect lighting for any task. The sleek design is perfect for modern or traditional decor, and the lamp is made with high-quality materials for durability and long-lasting use. Whether you're working late into the night or need a focused light for reading, this desk lamp is the perfect solution. Shop now to enhance your productivity and workspace!", "/img/desklamp.jpg", 6, 0, 29.5, "Desk Lamp" },
                    { -4, new DateTime(2023, 3, 7, 20, 37, 5, 395, DateTimeKind.Local).AddTicks(2155), new DateTime(2023, 3, 4, 20, 37, 5, 395, DateTimeKind.Local).AddTicks(2154), "Experience exceptional sound quality and stylish design with these Beats headphones. The headphones feature high-quality sound drivers, noise-cancelling technology, and Bluetooth connectivity for seamless wireless use. The sleek design is available in various colors to suit individual preferences, and the headphones come with a convenient carrying case for on-the-go use. Whether you're listening to music or taking calls, these Beats headphones deliver exceptional sound and style. Shop now to experience the ultimate in headphone technology!", "/img/beats.jpg", 0, 2, 29.5, "Beats" },
                    { -3, new DateTime(2023, 3, 7, 20, 37, 5, 395, DateTimeKind.Local).AddTicks(2151), new DateTime(2023, 3, 4, 20, 37, 5, 395, DateTimeKind.Local).AddTicks(2150), "This high-quality backpack is an essential accessory for anyone on-the-go. It boasts durable materials, multiple compartments, and specialized features such as padded straps or water-resistant materials. Available in various styles, colors, and patterns to suit individual preferences, this backpack is a practical and stylish choice for everyday use or outdoor adventures. Shop now to experience the comfort and convenience of this versatile accessory!", "/img/backpack.jpg", 2, 0, 29.5, "Backpack" },
                    { -2, new DateTime(2023, 3, 7, 20, 37, 5, 395, DateTimeKind.Local).AddTicks(2147), new DateTime(2023, 3, 4, 20, 37, 5, 395, DateTimeKind.Local).AddTicks(2145), " specialized chair designed for gamers who spend long hours playing video games. These chairs are typically designed with comfort and support in mind, and are often highly adjustable to fit the needs of individual users.", "/img/gamerchair.jpg", 6, 2, 29.5, "Gaming Chair" },
                    { -1, new DateTime(2023, 3, 14, 20, 37, 5, 395, DateTimeKind.Local).AddTicks(2142), new DateTime(2023, 2, 22, 20, 37, 5, 395, DateTimeKind.Local).AddTicks(2102), "The controller features a predominantly white color scheme, with black accents and a green Xbox logo button in the center. It has two thumbsticks, a directional pad, four face buttons, two triggers, two bumpers, and a set of menu buttons. The controller connects wirelessly to the Xbox console or PC using Bluetooth technology, and it requires two AA batteries for power. The white Xbox controller is a popular accessory for gamers who prefer a classic design and a comfortable, responsive gaming experience.", "/img/xboxcontroller.jpg", 0, 0, 39.5, "Xbox Controller" }
                });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "Id", "Bio", "FullName" },
                values: new object[,]
                {
                    { -2, "This is the Bio of the second seller", "John Wick" },
                    { -1, "This is the Bio of the first seller", "Billy Butcher" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_Items_ItemId",
                table: "Sellers_Items",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Sellers_Items");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Sellers");
        }
    }
}
