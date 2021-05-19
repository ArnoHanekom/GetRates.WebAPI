using Microsoft.EntityFrameworkCore.Migrations;

namespace GetRates.DAL.Migrations
{
    public partial class DecimalColumnSizeChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Volume_24h",
                table: "Quotes",
                type: "decimal(18,5)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,18)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Quotes",
                type: "decimal(18,5)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,18)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Percent_Change_90d",
                table: "Quotes",
                type: "decimal(18,5)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,18)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Percent_Change_7d",
                table: "Quotes",
                type: "decimal(18,5)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,18)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Percent_Change_60d",
                table: "Quotes",
                type: "decimal(18,5)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,18)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Percent_Change_30d",
                table: "Quotes",
                type: "decimal(18,5)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,18)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Percent_Change_24h",
                table: "Quotes",
                type: "decimal(18,5)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,18)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Percent_Change_1h",
                table: "Quotes",
                type: "decimal(18,5)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,18)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Market_Cap",
                table: "Quotes",
                type: "decimal(18,5)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,18)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Volume_24h",
                table: "Quotes",
                type: "decimal(38,18)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,5)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Quotes",
                type: "decimal(38,18)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,5)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Percent_Change_90d",
                table: "Quotes",
                type: "decimal(38,18)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,5)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Percent_Change_7d",
                table: "Quotes",
                type: "decimal(38,18)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,5)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Percent_Change_60d",
                table: "Quotes",
                type: "decimal(38,18)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,5)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Percent_Change_30d",
                table: "Quotes",
                type: "decimal(38,18)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,5)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Percent_Change_24h",
                table: "Quotes",
                type: "decimal(38,18)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,5)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Percent_Change_1h",
                table: "Quotes",
                type: "decimal(38,18)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,5)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Market_Cap",
                table: "Quotes",
                type: "decimal(38,18)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,5)",
                oldNullable: true);
        }
    }
}
