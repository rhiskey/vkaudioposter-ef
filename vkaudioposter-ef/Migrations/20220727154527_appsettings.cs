using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace vkaudioposter_ef.Migrations
{
    public partial class appsettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppSettings",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DefaultUri = table.Column<string>(type: "text", nullable: false, comment: "Spotify Uri to play if no playing context"),
                    AdImageUrl = table.Column<string>(type: "text", nullable: true, comment: "Ad image url to load in card"),
                    AdUrl = table.Column<string>(type: "text", nullable: true, comment: "Ad link, on tap open"),
                    AdText = table.Column<string>(type: "text", nullable: true, comment: "Ad text on card")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSettings", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppSettings",
                schema: "public");
        }
    }
}
