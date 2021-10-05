using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DL.Migrations
{
    public partial class fifthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    ShoppingCartId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ShoppingCartCustomerCustomerId = table.Column<int>(type: "integer", nullable: true),
                    ShoppingCartProdProductId = table.Column<int>(type: "integer", nullable: true),
                    ShoppingCartQuantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.ShoppingCartId);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Customers_ShoppingCartCustomerCustomerId",
                        column: x => x.ShoppingCartCustomerCustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Products_ShoppingCartProdProductId",
                        column: x => x.ShoppingCartProdProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_ShoppingCartCustomerCustomerId",
                table: "ShoppingCarts",
                column: "ShoppingCartCustomerCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_ShoppingCartProdProductId",
                table: "ShoppingCarts",
                column: "ShoppingCartProdProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCarts");
        }
    }
}
