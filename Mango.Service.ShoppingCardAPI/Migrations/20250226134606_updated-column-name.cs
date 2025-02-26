using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mango.Service.ShoppingCartAPI.Migrations
{
    /// <inheritdoc />
    public partial class updatedcolumnname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartDetails_CartHeaders_CartHeader",
                table: "CartDetails");

            migrationBuilder.RenameColumn(
                name: "CartHeader",
                table: "CartDetails",
                newName: "CartHeaderId");

            migrationBuilder.RenameColumn(
                name: "CardDetailsId",
                table: "CartDetails",
                newName: "CartDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_CartDetails_CartHeader",
                table: "CartDetails",
                newName: "IX_CartDetails_CartHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartDetails_CartHeaders_CartHeaderId",
                table: "CartDetails",
                column: "CartHeaderId",
                principalTable: "CartHeaders",
                principalColumn: "CartHeaderId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartDetails_CartHeaders_CartHeaderId",
                table: "CartDetails");

            migrationBuilder.RenameColumn(
                name: "CartHeaderId",
                table: "CartDetails",
                newName: "CartHeader");

            migrationBuilder.RenameColumn(
                name: "CartDetailsId",
                table: "CartDetails",
                newName: "CardDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_CartDetails_CartHeaderId",
                table: "CartDetails",
                newName: "IX_CartDetails_CartHeader");

            migrationBuilder.AddForeignKey(
                name: "FK_CartDetails_CartHeaders_CartHeader",
                table: "CartDetails",
                column: "CartHeader",
                principalTable: "CartHeaders",
                principalColumn: "CartHeaderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
