using Microsoft.EntityFrameworkCore.Migrations;

namespace GetRates.DAL.Migrations
{
    public partial class QuotesLayoutChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QuoteCurrency",
                table: "Quotes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuoteCurrency",
                table: "Quotes");
        }
    }
}
