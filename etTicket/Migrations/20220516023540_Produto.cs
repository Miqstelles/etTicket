using Microsoft.EntityFrameworkCore.Migrations;

namespace etTicket.Migrations
{
    public partial class Produto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_Movies_MovieId",
                table: "ShoppingCartItems");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "ShoppingCartItems",
                newName: "ProdutosId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartItems_MovieId",
                table: "ShoppingCartItems",
                newName: "IX_ShoppingCartItems_ProdutosId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_Movies_ProdutosId",
                table: "ShoppingCartItems",
                column: "ProdutosId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_Movies_ProdutosId",
                table: "ShoppingCartItems");

            migrationBuilder.RenameColumn(
                name: "ProdutosId",
                table: "ShoppingCartItems",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartItems_ProdutosId",
                table: "ShoppingCartItems",
                newName: "IX_ShoppingCartItems_MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_Movies_MovieId",
                table: "ShoppingCartItems",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
