using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrinkingWoteAppAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crewers",
                columns: table => new
                {
                    CrewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CrewStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crewers", x => x.CrewId);
                });

            migrationBuilder.CreateTable(
                name: "Perumahans",
                columns: table => new
                {
                    PerumahanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerumahanName = table.Column<string>(name: "Perumahan_Name", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perumahans", x => x.PerumahanId);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerumahanId = table.Column<int>(type: "int", nullable: true),
                    Block = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RTRW = table.Column<string>(name: "RT_RW", type: "nvarchar(max)", nullable: false),
                    Kelurahan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kecamatan = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Address_Perumahans_PerumahanId",
                        column: x => x.PerumahanId,
                        principalTable: "Perumahans",
                        principalColumn: "PerumahanId");
                });

            migrationBuilder.CreateTable(
                name: "Consumens",
                columns: table => new
                {
                    ConsumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Balance = table.Column<float>(type: "real", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumens", x => x.ConsumentId);
                    table.ForeignKey(
                        name: "FK_Consumens_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId");
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    BillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPaid = table.Column<float>(type: "real", nullable: true),
                    OrderId = table.Column<int>(name: "Order_Id", type: "int", nullable: true),
                    Qty = table.Column<int>(type: "int", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ConsumentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.BillId);
                    table.ForeignKey(
                        name: "FK_Bills_Consumens_ConsumentId",
                        column: x => x.ConsumentId,
                        principalTable: "Consumens",
                        principalColumn: "ConsumentId");
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RatingStar = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderId = table.Column<int>(name: "Order_Id", type: "int", nullable: true),
                    CrewId = table.Column<int>(type: "int", nullable: true),
                    ConsumentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_Consumens_ConsumentId",
                        column: x => x.ConsumentId,
                        principalTable: "Consumens",
                        principalColumn: "ConsumentId");
                    table.ForeignKey(
                        name: "FK_Reviews_Crewers_CrewId",
                        column: x => x.CrewId,
                        principalTable: "Crewers",
                        principalColumn: "CrewId");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(name: "User_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(name: "User_Name", type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConsumentId = table.Column<int>(type: "int", nullable: true),
                    MobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Consumens_ConsumentId",
                        column: x => x.ConsumentId,
                        principalTable: "Consumens",
                        principalColumn: "ConsumentId");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsumentId = table.Column<int>(type: "int", nullable: true),
                    StatusOrder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qty = table.Column<int>(type: "int", nullable: true),
                    TimeOrder = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderDone = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillId = table.Column<int>(type: "int", nullable: true),
                    ReviewId = table.Column<int>(type: "int", nullable: true),
                    CrewId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "BillId");
                    table.ForeignKey(
                        name: "FK_Orders_Consumens_ConsumentId",
                        column: x => x.ConsumentId,
                        principalTable: "Consumens",
                        principalColumn: "ConsumentId");
                    table.ForeignKey(
                        name: "FK_Orders_Crewers_CrewId",
                        column: x => x.CrewId,
                        principalTable: "Crewers",
                        principalColumn: "CrewId");
                    table.ForeignKey(
                        name: "FK_Orders_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "ReviewId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_PerumahanId",
                table: "Address",
                column: "PerumahanId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_ConsumentId",
                table: "Bills",
                column: "ConsumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumens_AddressId",
                table: "Consumens",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BillId",
                table: "Orders",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ConsumentId",
                table: "Orders",
                column: "ConsumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CrewId",
                table: "Orders",
                column: "CrewId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ReviewId",
                table: "Orders",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ConsumentId",
                table: "Reviews",
                column: "ConsumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CrewId",
                table: "Reviews",
                column: "CrewId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ConsumentId",
                table: "Users",
                column: "ConsumentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Consumens");

            migrationBuilder.DropTable(
                name: "Crewers");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Perumahans");
        }
    }
}
