using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceCompanyApplication.Migrations
{
    /// <inheritdoc />
    public partial class CorrectOrderTableCreationWithForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerID",
                table: "Orders",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders");

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
    }
}
