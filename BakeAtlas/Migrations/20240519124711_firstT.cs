using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BakeAtlas.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class firstT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Orders",
                newName: "ProductId");

            migrationBuilder.AddColumn<string>(
                name: "BakeryProductId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BakeryProductId",
                table: "Orders",
                column: "BakeryProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_BakeryProducts_BakeryProductId",
                table: "Orders",
                column: "BakeryProductId",
                principalTable: "BakeryProducts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_BakeryProducts_BakeryProductId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BakeryProductId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BakeryProductId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Orders",
                newName: "Description");

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BakeryProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_BakeryProducts_BakeryProductId",
                        column: x => x.BakeryProductId,
                        principalTable: "BakeryProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_BakeryProductId",
                table: "OrderItems",
                column: "BakeryProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");
        }
    }
}
