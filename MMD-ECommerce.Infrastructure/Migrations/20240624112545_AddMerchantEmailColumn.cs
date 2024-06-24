using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MMD_ECommerce.Infrastructure.Migrations
{
    public partial class AddMerchantEmailColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MerchantEmail",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MerchantEmail",
                table: "Products");
        }
    }
}
