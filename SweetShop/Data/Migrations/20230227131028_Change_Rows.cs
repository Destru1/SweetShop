using Microsoft.EntityFrameworkCore.Migrations;

namespace SweetShop.Data.Migrations
{
    public partial class Change_Rows : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Allergens_AllergenId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_AllergenId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AllergenId",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AllergenId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_AllergenId",
                table: "Products",
                column: "AllergenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Allergens_AllergenId",
                table: "Products",
                column: "AllergenId",
                principalTable: "Allergens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
