using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MMD_ECommerce.Infrastructure.Migrations
{
    public partial class AddConnection2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "orderItemProductID",
                table: "OrderItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "orderItemProductID",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
