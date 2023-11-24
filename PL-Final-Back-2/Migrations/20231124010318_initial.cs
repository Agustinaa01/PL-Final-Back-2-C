using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PLFinalBack2.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rol = table.Column<int>(type: "int", nullable: false),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PedidoId = table.Column<int>(type: "int", nullable: true),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Producto_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Name", "Password", "Rol", "state" },
                values: new object[,]
                {
                    { 1, "ericaGomez@gmail.com", "Erica", "123abc", 0, 0 },
                    { 2, "danaMolina@gmail.com", "Dana", "456def", 1, 0 },
                    { 3, "agus@back.com", "Agus", "user123", 2, 0 },
                    { 4, "bren@back.com", "Bren", "user123", 2, 0 },
                    { 5, "lucho@back.com", "Lucho", "user123", 2, 0 }
                });

            migrationBuilder.InsertData(
                table: "Pedido",
                columns: new[] { "Id", "Date", "State", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shipping", 3 },
                    { 2, new DateTime(2023, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered", 3 }
                });

            migrationBuilder.InsertData(
                table: "Producto",
                columns: new[] { "Id", "Brand", "Category", "Description", "ImageUrl", "Name", "PedidoId", "Price", "state" },
                values: new object[,]
                {
                    { 1, "HP", "Computadora", "gagagagab", "https://i.pinimg.com/564x/5a/62/1e/5a621e11a8cc9fd152d6805cd5f67724.jpg", "Computadora", 1, 1515, 0 },
                    { 2, "HP", "Auriculares", "gagagagab", "https://i.pinimg.com/564x/f2/99/42/f29942dc13ba97a29d27ff47f83ec36e.jpg", "Auriculares", 2, 1545, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_UserId",
                table: "Pedido",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_PedidoId",
                table: "Producto",
                column: "PedidoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
