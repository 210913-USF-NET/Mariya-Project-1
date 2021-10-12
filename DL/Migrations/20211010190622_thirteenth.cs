using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class thirteenth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Inventories_InventoriesInventoryID",
                table: "LineItems");

            migrationBuilder.DropIndex(
                name: "IX_LineItems_InventoriesInventoryID",
                table: "LineItems");

            migrationBuilder.DropColumn(
                name: "InventoriesInventoryID",
                table: "LineItems");

            migrationBuilder.AddColumn<List<string>>(
                name: "Genre",
                table: "Inventories",
                type: "text[]",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Inventories");

            migrationBuilder.AddColumn<int>(
                name: "InventoriesInventoryID",
                table: "LineItems",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_InventoriesInventoryID",
                table: "LineItems",
                column: "InventoriesInventoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_Inventories_InventoriesInventoryID",
                table: "LineItems",
                column: "InventoriesInventoryID",
                principalTable: "Inventories",
                principalColumn: "InventoryID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
