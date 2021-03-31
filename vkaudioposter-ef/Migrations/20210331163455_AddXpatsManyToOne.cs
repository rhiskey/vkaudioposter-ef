using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace vkaudioposter_ef.Migrations
{
    public partial class AddXpatsManyToOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Xpath",
                table: "console_Photostocks");

            migrationBuilder.DropColumn(
                name: "XpathInner",
                table: "console_Photostocks");

            migrationBuilder.AddColumn<int>(
                name: "ParserXpathId",
                table: "console_Photostocks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ParserXpath",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Xpath = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: true),
                    XpathInner = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParserXpath", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_console_Photostocks_ParserXpathId",
                table: "console_Photostocks",
                column: "ParserXpathId");

            migrationBuilder.AddForeignKey(
                name: "FK_console_Photostocks_ParserXpath_ParserXpathId",
                table: "console_Photostocks",
                column: "ParserXpathId",
                principalTable: "ParserXpath",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_console_Photostocks_ParserXpath_ParserXpathId",
                table: "console_Photostocks");

            migrationBuilder.DropTable(
                name: "ParserXpath");

            migrationBuilder.DropIndex(
                name: "IX_console_Photostocks_ParserXpathId",
                table: "console_Photostocks");

            migrationBuilder.DropColumn(
                name: "ParserXpathId",
                table: "console_Photostocks");

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
    }
}
