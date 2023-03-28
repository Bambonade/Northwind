using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Northwind.Migrations
{
    public partial class CreateCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_Products_ProductId",
                table: "Discounts");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Discounts",
                newName: "ProductID");

            migrationBuilder.RenameColumn(
                name: "DiscountId",
                table: "Discounts",
                newName: "DiscountID");

            migrationBuilder.RenameIndex(
                name: "IX_Discounts_ProductId",
                table: "Discounts",
                newName: "IX_Discounts_ProductID");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountPercent",
                table: "Discounts",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,4)");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_Products_ProductID",
                table: "Discounts",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_Products_ProductID",
                table: "Discounts");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "Discounts",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "DiscountID",
                table: "Discounts",
                newName: "DiscountId");

            migrationBuilder.RenameIndex(
                name: "IX_Discounts_ProductID",
                table: "Discounts",
                newName: "IX_Discounts_ProductId");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountPercent",
                table: "Discounts",
                type: "decimal(4,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_Products_ProductId",
                table: "Discounts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
