using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quote.Service.Migrations
{
    public partial class Quotes_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuoteID",
                table: "Quotes",
                newName: "QuoteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuoteId",
                table: "Quotes",
                newName: "QuoteID");
        }
    }
}
