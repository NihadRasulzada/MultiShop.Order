using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiShop.Order.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orderings_AddressId",
                table: "Orderings");

            migrationBuilder.CreateIndex(
                name: "IX_Orderings_AddressId",
                table: "Orderings",
                column: "AddressId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orderings_AddressId",
                table: "Orderings");

            migrationBuilder.CreateIndex(
                name: "IX_Orderings_AddressId",
                table: "Orderings",
                column: "AddressId");
        }
    }
}
