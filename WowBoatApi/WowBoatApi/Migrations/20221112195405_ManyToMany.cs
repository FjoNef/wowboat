using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WowBoatApi.Migrations
{
    /// <inheritdoc />
    public partial class ManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoatBenefits_BoatsInformation_BoatInformationId",
                table: "BoatBenefits");

            migrationBuilder.DropIndex(
                name: "IX_BoatBenefits_BoatInformationId",
                table: "BoatBenefits");

            migrationBuilder.DropColumn(
                name: "BoatInformationId",
                table: "BoatBenefits");

            migrationBuilder.CreateTable(
                name: "BoatBenefitBoatInformation",
                columns: table => new
                {
                    BenefitsId = table.Column<int>(type: "int", nullable: false),
                    BoatsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoatBenefitBoatInformation", x => new { x.BenefitsId, x.BoatsId });
                    table.ForeignKey(
                        name: "FK_BoatBenefitBoatInformation_BoatBenefits_BenefitsId",
                        column: x => x.BenefitsId,
                        principalTable: "BoatBenefits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoatBenefitBoatInformation_BoatsInformation_BoatsId",
                        column: x => x.BoatsId,
                        principalTable: "BoatsInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoatBenefitBoatInformation_BoatsId",
                table: "BoatBenefitBoatInformation",
                column: "BoatsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoatBenefitBoatInformation");

            migrationBuilder.AddColumn<int>(
                name: "BoatInformationId",
                table: "BoatBenefits",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoatBenefits_BoatInformationId",
                table: "BoatBenefits",
                column: "BoatInformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_BoatBenefits_BoatsInformation_BoatInformationId",
                table: "BoatBenefits",
                column: "BoatInformationId",
                principalTable: "BoatsInformation",
                principalColumn: "Id");
        }
    }
}
