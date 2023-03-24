using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductApp.Persistence.Migrations
{
    public partial class AddedProductFieldTableConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_category_fields_categories_CategoryId",
                table: "category_fields");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "category_fields",
                newName: "category_id");

            migrationBuilder.RenameIndex(
                name: "IX_category_fields_CategoryId",
                table: "category_fields",
                newName: "IX_category_fields_category_id");

            migrationBuilder.AddForeignKey(
                name: "FK_category_fields_categories_category_id",
                table: "category_fields",
                column: "category_id",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_category_fields_categories_category_id",
                table: "category_fields");

            migrationBuilder.RenameColumn(
                name: "category_id",
                table: "category_fields",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_category_fields_category_id",
                table: "category_fields",
                newName: "IX_category_fields_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_category_fields_categories_CategoryId",
                table: "category_fields",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
