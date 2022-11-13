using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WowBoatApi.Migrations
{
    /// <inheritdoc />
    public partial class AddBoatLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "BoatsInformation");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "BoatsInformation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BoatLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoatLocations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoatsInformation_LocationId",
                table: "BoatsInformation",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_BoatsInformation_BoatLocations_LocationId",
                table: "BoatsInformation",
                column: "LocationId",
                principalTable: "BoatLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoatsInformation_BoatLocations_LocationId",
                table: "BoatsInformation");

            migrationBuilder.DropTable(
                name: "BoatLocations");

            migrationBuilder.DropIndex(
                name: "IX_BoatsInformation_LocationId",
                table: "BoatsInformation");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "BoatsInformation");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "BoatsInformation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
