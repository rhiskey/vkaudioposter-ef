using Microsoft.EntityFrameworkCore.Migrations;

namespace vkaudioposter_ef.Migrations
{
    public partial class appsettingssecondtext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdTextSecond",
                schema: "public",
                table: "AppSettings",
                type: "text",
                nullable: true,
                comment: "Ad text on card");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdTextSecond",
                schema: "public",
                table: "AppSettings");
        }
    }
}
