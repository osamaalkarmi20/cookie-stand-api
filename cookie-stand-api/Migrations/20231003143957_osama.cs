using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cookie_stand_api.Migrations
{
    /// <inheritdoc />
    public partial class osama : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CookieStands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinimumCustomersPerHour = table.Column<int>(type: "int", nullable: false),
                    MaximumCustomersPerHour = table.Column<int>(type: "int", nullable: false),
                    AverageCookiesPerSale = table.Column<double>(type: "float", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookieStands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "oneHourSales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hour = table.Column<int>(type: "int", nullable: false),
                    CookieStandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oneHourSales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_oneHourSales_CookieStands_CookieStandId",
                        column: x => x.CookieStandId,
                        principalTable: "CookieStands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_oneHourSales_CookieStandId",
                table: "oneHourSales",
                column: "CookieStandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "oneHourSales");

            migrationBuilder.DropTable(
                name: "CookieStands");
        }
    }
}
