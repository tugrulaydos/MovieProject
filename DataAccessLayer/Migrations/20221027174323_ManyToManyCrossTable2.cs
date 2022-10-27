using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class ManyToManyCrossTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CategoryFilms_CategoryID",
                table: "CategoryFilms");

            migrationBuilder.DropIndex(
                name: "IX_ArtistFilms_ArtistID",
                table: "ArtistFilms");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryFilms",
                table: "CategoryFilms",
                columns: new[] { "CategoryID", "FilmID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArtistFilms",
                table: "ArtistFilms",
                columns: new[] { "ArtistID", "FilmID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryFilms",
                table: "CategoryFilms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArtistFilms",
                table: "ArtistFilms");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryFilms_CategoryID",
                table: "CategoryFilms",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistFilms_ArtistID",
                table: "ArtistFilms",
                column: "ArtistID");
        }
    }
}
