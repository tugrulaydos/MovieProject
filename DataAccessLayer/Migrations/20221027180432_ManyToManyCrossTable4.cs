using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class ManyToManyCrossTable4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistFilm");

            migrationBuilder.DropTable(
                name: "CategoryFilm");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "ArtistFilm",
                columns: table => new
                {
                    ArtistsID = table.Column<int>(type: "int", nullable: false),
                    FilmsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistFilm", x => new { x.ArtistsID, x.FilmsID });
                    table.ForeignKey(
                        name: "FK_ArtistFilm_Artists_ArtistsID",
                        column: x => x.ArtistsID,
                        principalTable: "Artists",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistFilm_Films_FilmsID",
                        column: x => x.FilmsID,
                        principalTable: "Films",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryFilm",
                columns: table => new
                {
                    CategoriesID = table.Column<int>(type: "int", nullable: false),
                    FilmsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryFilm", x => new { x.CategoriesID, x.FilmsID });
                    table.ForeignKey(
                        name: "FK_CategoryFilm_Categories_CategoriesID",
                        column: x => x.CategoriesID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryFilm_Films_FilmsID",
                        column: x => x.FilmsID,
                        principalTable: "Films",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistFilm_FilmsID",
                table: "ArtistFilm",
                column: "FilmsID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryFilm_FilmsID",
                table: "CategoryFilm",
                column: "FilmsID");
        }
    }
}
