using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WowBoatApi.Migrations
{
    /// <inheritdoc />
    public partial class AddBoatType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BoatTypeId",
                table: "BoatsInformation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "BoatsInformation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "BoatTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoatTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoatsInformation_BoatTypeId",
                table: "BoatsInformation",
                column: "BoatTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BoatsInformation_BoatTypes_BoatTypeId",
                table: "BoatsInformation",
                column: "BoatTypeId",
                principalTable: "BoatTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoatsInformation_BoatTypes_BoatTypeId",
                table: "BoatsInformation");

            migrationBuilder.DropTable(
                name: "BoatTypes");

            migrationBuilder.DropIndex(
                name: "IX_BoatsInformation_BoatTypeId",
                table: "BoatsInformation");

            migrationBuilder.DropColumn(
                name: "BoatTypeId",
                table: "BoatsInformation");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "BoatsInformation");
        }
    }
}
