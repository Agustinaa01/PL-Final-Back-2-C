using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLFinalBack2.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePedidoProductoRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Pedido_PedidoId",
                table: "Producto");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Pedido_PedidoId",
                table: "Producto",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Pedido_PedidoId",
                table: "Producto");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Pedido_PedidoId",
                table: "Producto",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
