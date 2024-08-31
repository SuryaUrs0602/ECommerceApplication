using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceCompanyApplication.Migrations
{
    /// <inheritdoc />
    public partial class OrderTableUpdatedWithForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.RenameColumn(
                name: "OrderType",
                table: "Orders",
                newName: "ProductName");

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "OrderPrice",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "CustomerOrder",
                columns: table => new
                {
                    CustomersCustomerID = table.Column<int>(type: "int", nullable: false),
                    OrdersOrderID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOrder", x => new { x.CustomersCustomerID, x.OrdersOrderID });
                    table.ForeignKey(
                        name: "FK_CustomerOrder_Customers_CustomersCustomerID",
                        column: x => x.CustomersCustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerOrder_Orders_OrdersOrderID",
                        column: x => x.OrdersOrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrder_OrdersOrderID",
                table: "CustomerOrder",
                column: "OrdersOrderID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerOrder");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderPrice",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Orders",
                newName: "OrderType");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    ProductCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                });
        }
    }
}
