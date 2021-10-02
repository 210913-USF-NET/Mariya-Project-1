using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Products_ProductID",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerID",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "StoreFronts",
                newName: "StoreStreet");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "StoreFronts",
                newName: "StoreState");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "StoreFronts",
                newName: "StoreName");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "StoreFronts",
                newName: "StoreCountry");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "StoreFronts",
                newName: "StoreCity");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "Orders",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "Orders",
                newName: "OrderTotal");

            migrationBuilder.RenameColumn(
                name: "StoreID",
                table: "Orders",
                newName: "OrderStoreID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                newName: "IX_Orders_CustomerId");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "LineItems",
                newName: "LineProductID");

            migrationBuilder.RenameColumn(
                name: "OrderID",
                table: "LineItems",
                newName: "LineOrderID");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "Inventories",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "StoreID",
                table: "Inventories",
                newName: "InvStoreID");

            migrationBuilder.RenameIndex(
                name: "IX_Inventories_ProductID",
                table: "Inventories",
                newName: "IX_Inventories_ProductId");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Orders",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "OrderCustomerID",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Inventories",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "InvProductID",
                table: "Inventories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Products_ProductId",
                table: "Inventories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Products_ProductId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderCustomerID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "InvProductID",
                table: "Inventories");

            migrationBuilder.RenameColumn(
                name: "StoreStreet",
                table: "StoreFronts",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "StoreState",
                table: "StoreFronts",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "StoreName",
                table: "StoreFronts",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "StoreCountry",
                table: "StoreFronts",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "StoreCity",
                table: "StoreFronts",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Orders",
                newName: "CustomerID");

            migrationBuilder.RenameColumn(
                name: "OrderTotal",
                table: "Orders",
                newName: "Total");

            migrationBuilder.RenameColumn(
                name: "OrderStoreID",
                table: "Orders",
                newName: "StoreID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                newName: "IX_Orders_CustomerID");

            migrationBuilder.RenameColumn(
                name: "LineProductID",
                table: "LineItems",
                newName: "ProductID");

            migrationBuilder.RenameColumn(
                name: "LineOrderID",
                table: "LineItems",
                newName: "OrderID");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Inventories",
                newName: "ProductID");

            migrationBuilder.RenameColumn(
                name: "InvStoreID",
                table: "Inventories",
                newName: "StoreID");

            migrationBuilder.RenameIndex(
                name: "IX_Inventories_ProductId",
                table: "Inventories",
                newName: "IX_Inventories_ProductID");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerID",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "Inventories",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Products_ProductID",
                table: "Inventories",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerID",
                table: "Orders",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
