using Microsoft.EntityFrameworkCore.Migrations;

namespace Pinegas.Migrations
{
    public partial class OrderItemUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Movies_MovieId",
                table: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "OrderItems",
                newName: "Valor");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "OrderItems",
                newName: "ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_MovieId",
                table: "OrderItems",
                newName: "IX_OrderItems_ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Movies_ProdutoId",
                table: "OrderItems",
                column: "ProdutoId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Movies_ProdutoId",
                table: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "OrderItems",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "ProdutoId",
                table: "OrderItems",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_ProdutoId",
                table: "OrderItems",
                newName: "IX_OrderItems_MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Movies_MovieId",
                table: "OrderItems",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
