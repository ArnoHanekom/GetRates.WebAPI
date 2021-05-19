using Microsoft.EntityFrameworkCore.Migrations;

namespace GetRates.DAL.Migrations
{
    public partial class RelationshipUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cryptoOnlies");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Cryptos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Cryptos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Symbol",
                table: "Cryptos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Cryptos");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Cryptos");

            migrationBuilder.DropColumn(
                name: "Symbol",
                table: "Cryptos");

            migrationBuilder.CreateTable(
                name: "cryptoOnlies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiRefId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cryptoOnlies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cryptoOnlies_Cryptos_ApiRefId",
                        column: x => x.ApiRefId,
                        principalTable: "Cryptos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cryptoOnlies_ApiRefId",
                table: "cryptoOnlies",
                column: "ApiRefId");
        }
    }
}
