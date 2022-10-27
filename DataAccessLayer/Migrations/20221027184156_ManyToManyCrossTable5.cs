using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class ManyToManyCrossTable5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Films_FilmID",
                table: "Artists");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Films_FilmID",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_FilmID",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Artists_FilmID",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "FilmID",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "FilmID",
                table: "Artists");

            migrationBuilder.CreateTable(
                name: "ArtistFilms",
                columns: table => new
                {
                    ArtistID = table.Column<int>(type: "int", nullable: false),
                    FilmID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistFilms", x => new { x.ArtistID, x.FilmID });
                    table.ForeignKey(
                        name: "FK_ArtistFilms_Artists_ArtistID",
                        column: x => x.ArtistID,
                        principalTable: "Artists",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistFilms_Films_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Films",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryFilms",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    FilmID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryFilms", x => new { x.CategoryID, x.FilmID });
                    table.ForeignKey(
                        name: "FK_CategoryFilms_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryFilms_Films_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Films",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistFilms_FilmID",
                table: "ArtistFilms",
                column: "FilmID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryFilms_FilmID",
                table: "CategoryFilms",
                column: "FilmID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistFilms");

            migrationBuilder.DropTable(
                name: "CategoryFilms");

            migrationBuilder.AddColumn<int>(
                name: "FilmID",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FilmID",
                table: "Artists",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_FilmID",
                table: "Categories",
                column: "FilmID");

            migrationBuilder.CreateIndex(
                name: "IX_Artists_FilmID",
                table: "Artists",
                column: "FilmID");

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Films_FilmID",
                table: "Artists",
                column: "FilmID",
                principalTable: "Films",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Films_FilmID",
                table: "Categories",
                column: "FilmID",
                principalTable: "Films",
                principalColumn: "ID");
        }
    }
}
