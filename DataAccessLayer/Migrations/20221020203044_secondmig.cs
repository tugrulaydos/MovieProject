using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class secondmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmArtist");

            migrationBuilder.DropTable(
                name: "FilmCategory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FilmArtist",
                columns: table => new
                {
                    FilmID = table.Column<int>(type: "int", nullable: false),
                    ArtistID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmArtist", x => new { x.FilmID, x.ArtistID });
                    table.ForeignKey(
                        name: "FK_FilmArtist_Artists_ArtistID",
                        column: x => x.ArtistID,
                        principalTable: "Artists",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmArtist_Films_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Films",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmCategory",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    FilmID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmCategory", x => new { x.CategoryID, x.FilmID });
                    table.ForeignKey(
                        name: "FK_FilmCategory_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmCategory_Films_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Films",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmArtist_ArtistID",
                table: "FilmArtist",
                column: "ArtistID");

            migrationBuilder.CreateIndex(
                name: "IX_FilmCategory_FilmID",
                table: "FilmCategory",
                column: "FilmID");
        }
    }
}
