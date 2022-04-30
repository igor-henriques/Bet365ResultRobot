using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommonDatabase.Migrations
{
    public partial class addedoddnomecompeticao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeCompeticao",
                table: "Odd",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeCompeticao",
                table: "Odd");
        }
    }
}
