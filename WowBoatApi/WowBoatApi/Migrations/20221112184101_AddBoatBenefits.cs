using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WowBoatApi.Migrations
{
    /// <inheritdoc />
    public partial class AddBoatBenefits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "BoatImages");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "BoatImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "BoatBenefits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoatInformationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoatBenefits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoatBenefits_BoatsInformation_BoatInformationId",
                        column: x => x.BoatInformationId,
                        principalTable: "BoatsInformation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoatBenefits_BoatInformationId",
                table: "BoatBenefits",
                column: "BoatInformationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoatBenefits");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "BoatImages");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "BoatImages",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
