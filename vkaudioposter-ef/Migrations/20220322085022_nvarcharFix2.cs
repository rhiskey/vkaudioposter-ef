using Microsoft.EntityFrameworkCore.Migrations;

namespace vkaudioposter_ef.Migrations
{
    public partial class nvarcharFix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Trackname",
                schema: "public",
                table: "FoundTracks",
                type: "text",
                nullable: true,
                comment: "Fulltrackname",
                oldClrType: typeof(string),
                oldType: "text",
                oldMaxLength: 1024,
                oldNullable: true,
                oldComment: "Fulltrackname");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Trackname",
                schema: "public",
                table: "FoundTracks",
                type: "text",
                maxLength: 1024,
                nullable: true,
                comment: "Fulltrackname",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldComment: "Fulltrackname");
        }
    }
}
