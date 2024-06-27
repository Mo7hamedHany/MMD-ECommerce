using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MMD_ECommerce.Infrastructure.Migrations
{
    public partial class OrderItem_Product_Relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "orderItemProduct_PictureUrl",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "orderItemProduct_ProductName",
                table: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "orderItemProduct_ProductId",
                table: "OrderItems",
                newName: "productID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_productID",
                table: "OrderItems",
                column: "productID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_productID",
                table: "OrderItems",
                column: "productID",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_productID",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_productID",
                table: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "productID",
                table: "OrderItems",
                newName: "orderItemProduct_ProductId");

            migrationBuilder.AddColumn<string>(
                name: "orderItemProduct_PictureUrl",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "orderItemProduct_ProductName",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
