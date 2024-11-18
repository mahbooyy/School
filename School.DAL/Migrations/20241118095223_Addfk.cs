using Microsoft.EntityFrameworkCore.Migrations;

namespace School.DAL.Migrations
{
    public partial class Addfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_orders_OrdersDbId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_picture_product_PictureProductDbId",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "PictureProductDbId",
                table: "products",
                newName: "PictureProducId");

            migrationBuilder.RenameColumn(
                name: "OrdersDbId",
                table: "products",
                newName: "OderDbId");

            migrationBuilder.RenameIndex(
                name: "IX_products_PictureProductDbId",
                table: "products",
                newName: "IX_products_PictureProducId");

            migrationBuilder.RenameIndex(
                name: "IX_products_OrdersDbId",
                table: "products",
                newName: "IX_products_OderDbId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_orders_OderDbId",
                table: "products",
                column: "OderDbId",
                principalTable: "orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_products_picture_product_PictureProducId",
                table: "products",
                column: "PictureProducId",
                principalTable: "picture_product",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_orders_OderDbId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_picture_product_PictureProducId",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "PictureProducId",
                table: "products",
                newName: "PictureProductDbId");

            migrationBuilder.RenameColumn(
                name: "OderDbId",
                table: "products",
                newName: "OrdersDbId");

            migrationBuilder.RenameIndex(
                name: "IX_products_PictureProducId",
                table: "products",
                newName: "IX_products_PictureProductDbId");

            migrationBuilder.RenameIndex(
                name: "IX_products_OderDbId",
                table: "products",
                newName: "IX_products_OrdersDbId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_orders_OrdersDbId",
                table: "products",
                column: "OrdersDbId",
                principalTable: "orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_products_picture_product_PictureProductDbId",
                table: "products",
                column: "PictureProductDbId",
                principalTable: "picture_product",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
