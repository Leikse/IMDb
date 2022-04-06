using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projektarbete_ASP.NET.Data.Migrations
{
    public partial class FixedDecimalLengthOfRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Rating",
                table: "Movie",
                type: "decimal(2,1)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Rating",
                table: "Movie",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,1)");
        }
    }
}
