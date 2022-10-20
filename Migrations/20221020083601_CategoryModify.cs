using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieProject.Migrations
{
    public partial class CategoryModify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Categories_CategoryID",
                table: "Films");

            migrationBuilder.DropIndex(
                name: "IX_Films_CategoryID",
                table: "Films");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Films_CategoryID",
                table: "Films",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Categories_CategoryID",
                table: "Films",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
