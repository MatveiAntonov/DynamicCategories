using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductApp.Persistence.Migrations
{
    public partial class AddedProductFieldTableConfigurationv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductField_products_ProductId",
                table: "ProductField");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductField",
                table: "ProductField");

            migrationBuilder.RenameTable(
                name: "ProductField",
                newName: "product_fields");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "product_fields",
                newName: "value");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "product_fields",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "product_fields",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "product_fields",
                newName: "product_id");

            migrationBuilder.RenameIndex(
                name: "IX_ProductField_ProductId",
                table: "product_fields",
                newName: "IX_product_fields_product_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product_fields",
                table: "product_fields",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_fields_products_product_id",
                table: "product_fields",
                column: "product_id",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_fields_products_product_id",
                table: "product_fields");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product_fields",
                table: "product_fields");

            migrationBuilder.RenameTable(
                name: "product_fields",
                newName: "ProductField");

            migrationBuilder.RenameColumn(
                name: "value",
                table: "ProductField",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "ProductField",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ProductField",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "ProductField",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_product_fields_product_id",
                table: "ProductField",
                newName: "IX_ProductField_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductField",
                table: "ProductField",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductField_products_ProductId",
                table: "ProductField",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
