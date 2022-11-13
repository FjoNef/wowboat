using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WowBoatApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoatsInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxCapacity = table.Column<int>(type: "int", nullable: false),
                    RoomsCount = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaptainAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoatsInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BoatImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    BoatInformationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoatImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoatImages_BoatsInformation_BoatInformationId",
                        column: x => x.BoatInformationId,
                        principalTable: "BoatsInformation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoatImages_BoatInformationId",
                table: "BoatImages",
                column: "BoatInformationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoatImages");

            migrationBuilder.DropTable(
                name: "BoatsInformation");
        }
    }
}
