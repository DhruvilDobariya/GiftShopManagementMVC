using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GiftShopManagement.Models.Migrations
{
    public partial class RefineModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Stock",
                newName: "StockDeliveryDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Sell",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "InvoiceWiseGift",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Invoice",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "GiftType",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Gift",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Company",
                newName: "CreationDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Stock",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "Sell",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PricePerPice",
                table: "Sell",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "Sell",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PricePerPice",
                table: "InvoiceWiseGift",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "InvoiceWiseGift",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "Invoice",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PricePerPice",
                table: "Gift",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "AuthorizedPersonName",
                table: "Company",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Sell_InvoiceId",
                table: "Sell",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sell_Invoice_InvoiceId",
                table: "Sell",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sell_Invoice_InvoiceId",
                table: "Sell");

            migrationBuilder.DropIndex(
                name: "IX_Sell_InvoiceId",
                table: "Sell");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Sell");

            migrationBuilder.DropColumn(
                name: "PricePerPice",
                table: "Sell");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Sell");

            migrationBuilder.DropColumn(
                name: "PricePerPice",
                table: "InvoiceWiseGift");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "InvoiceWiseGift");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "PricePerPice",
                table: "Gift");

            migrationBuilder.DropColumn(
                name: "AuthorizedPersonName",
                table: "Company");

            migrationBuilder.RenameColumn(
                name: "StockDeliveryDate",
                table: "Stock",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Sell",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "InvoiceWiseGift",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Invoice",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "GiftType",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Gift",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Company",
                newName: "CreatedDate");
        }
    }
}
