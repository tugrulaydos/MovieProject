using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieProject.Migrations
{
    public partial class FilmCategoryModify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmCategories_Artists_FilmFKID",
                table: "FilmCategories");

            migrationBuilder.DropIndex(
                name: "IX_FilmCategories_FilmFKID",
                table: "FilmCategories");

            migrationBuilder.DropColumn(
                name: "FilmFKID",
                table: "FilmCategories");

            migrationBuilder.CreateIndex(
                name: "IX_FilmCategories_CategoryID",
                table: "FilmCategories",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmCategories_Categories_CategoryID",
                table: "FilmCategories",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmCategories_Categories_CategoryID",
                table: "FilmCategories");

            migrationBuilder.DropIndex(
                name: "IX_FilmCategories_CategoryID",
                table: "FilmCategories");

            migrationBuilder.AddColumn<int>(
                name: "FilmFKID",
                table: "FilmCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FilmCategories_FilmFKID",
                table: "FilmCategories",
                column: "FilmFKID");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmCategories_Artists_FilmFKID",
                table: "FilmCategories",
                column: "FilmFKID",
                principalTable: "Artists",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
