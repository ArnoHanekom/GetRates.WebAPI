using Microsoft.EntityFrameworkCore.Migrations;

namespace GetRates.DAL.Migrations
{
    public partial class DecimalColumnSizeChangeMissed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Total_Supply",
                table: "Cryptos",
                type: "decimal(18,5)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,18)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Max_Supply",
                table: "Cryptos",
                type: "decimal(18,5)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,18)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Circulating_Supply",
                table: "Cryptos",
                type: "decimal(18,5)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,18)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Total_Supply",
                table: "Cryptos",
                type: "decimal(38,18)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,5)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Max_Supply",
                table: "Cryptos",
                type: "decimal(38,18)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,5)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Circulating_Supply",
                table: "Cryptos",
                type: "decimal(38,18)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,5)",
                oldNullable: true);
        }
    }
}
