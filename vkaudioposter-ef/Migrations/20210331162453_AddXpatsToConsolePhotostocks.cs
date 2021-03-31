using Microsoft.EntityFrameworkCore.Migrations;

namespace vkaudioposter_ef.Migrations
{
    public partial class AddXpatsToConsolePhotostocks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Xpath",
                table: "console_Photostocks",
                type: "varchar(1024)",
                maxLength: 1024,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "XpathInner",
                table: "console_Photostocks",
                type: "varchar(1024)",
                maxLength: 1024,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Xpath",
                table: "console_Photostocks");

            migrationBuilder.DropColumn(
                name: "XpathInner",
                table: "console_Photostocks");
        }
    }
}
