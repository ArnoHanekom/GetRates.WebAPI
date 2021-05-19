using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GetRates.DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    token_address = table.Column<string>(nullable: true),
                    Json_Ref_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cryptos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiRefId = table.Column<int>(nullable: false),
                    Num_Market_Pairs = table.Column<int>(nullable: false),
                    Date_Added = table.Column<DateTime>(nullable: false),
                    Tags = table.Column<string>(nullable: true),
                    Max_Supply = table.Column<decimal>(type: "decimal(38,18)", nullable: true),
                    Circulating_Supply = table.Column<decimal>(type: "decimal(38,18)", nullable: true),
                    Total_Supply = table.Column<decimal>(type: "decimal(38,18)", nullable: true),
                    PlatformId = table.Column<int>(nullable: true),
                    CMC_Rank = table.Column<int>(nullable: false),
                    Last_Updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cryptos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cryptos_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cryptoOnlies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiRefId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(38,18)", nullable: false),
                    Volume_24h = table.Column<decimal>(type: "decimal(38,18)", nullable: false),
                    Percent_Change_1h = table.Column<decimal>(type: "decimal(38,18)", nullable: false),
                    Percent_Change_24h = table.Column<decimal>(type: "decimal(38,18)", nullable: false),
                    Percent_Change_7d = table.Column<decimal>(type: "decimal(38,18)", nullable: false),
                    Percent_Change_30d = table.Column<decimal>(type: "decimal(38,18)", nullable: false),
                    Percent_Change_60d = table.Column<decimal>(type: "decimal(38,18)", nullable: false),
                    Percent_Change_90d = table.Column<decimal>(type: "decimal(38,18)", nullable: false),
                    Market_Cap = table.Column<decimal>(type: "decimal(38,18)", nullable: false),
                    Last_Updated = table.Column<DateTime>(nullable: false),
                    CryptoCMC_Ref_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quotes_Cryptos_CryptoCMC_Ref_id",
                        column: x => x.CryptoCMC_Ref_id,
                        principalTable: "Cryptos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cryptoOnlies_ApiRefId",
                table: "cryptoOnlies",
                column: "ApiRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Cryptos_PlatformId",
                table: "Cryptos",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_CryptoCMC_Ref_id",
                table: "Quotes",
                column: "CryptoCMC_Ref_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cryptoOnlies");

            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.DropTable(
                name: "Cryptos");

            migrationBuilder.DropTable(
                name: "Platforms");
        }
    }
}
