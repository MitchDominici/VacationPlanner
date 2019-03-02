using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VacationPlanner.Data.Migrations
{
    public partial class Events : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Itinerary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CityDates",
                table: "CityDates");

            migrationBuilder.RenameTable(
                name: "CityDates",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "City",
                newName: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Location = table.Column<string>(maxLength: 450, nullable: true),
                    CityID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Events_City_CityID",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_CityID",
                table: "Events",
                column: "CityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.RenameTable(
                name: "City",
                newName: "CityDates");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "CityDates",
                newName: "City");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CityDates",
                table: "CityDates",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Itinerary",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Location = table.Column<string>(maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itinerary", x => x.ID);
                });
        }
    }
}
