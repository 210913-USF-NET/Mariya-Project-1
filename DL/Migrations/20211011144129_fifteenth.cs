using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class fifteenth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Inventories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<List<string>>(
                name: "Genre",
                table: "Inventories",
                type: "text[]",
                nullable: true);
        }
    }
}
