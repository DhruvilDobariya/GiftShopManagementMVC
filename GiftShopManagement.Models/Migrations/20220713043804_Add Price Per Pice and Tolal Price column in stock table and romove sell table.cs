using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GiftShopManagement.Models.Migrations
{
    public partial class AddPricePerPiceandTolalPricecolumninstocktableandromoveselltable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gift_Company_CompanyID",
                table: "Gift");

            migrationBuilder.DropTable(
                name: "Sell");

            migrationBuilder.RenameColumn(
                name: "CompanyID",
                table: "Gift",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Gift_CompanyID",
                table: "Gift",
                newName: "IX_Gift_CompanyId");

            migrationBuilder.AddColumn<decimal>(
                name: "PricePerPice",
                table: "Stock",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "Stock",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_Gift_Company_CompanyId",
                table: "Gift",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gift_Company_CompanyId",
                table: "Gift");

            migrationBuilder.DropColumn(
                name: "PricePerPice",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Stock");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Gift",
                newName: "CompanyID");

            migrationBuilder.RenameIndex(
                name: "IX_Gift_CompanyId",
                table: "Gift",
                newName: "IX_Gift_CompanyID");

            migrationBuilder.CreateTable(
                name: "Sell",
                columns: table => new
                {
                    SellId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GiftId = table.Column<int>(type: "int", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PricePerPice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sell", x => x.SellId);
                    table.ForeignKey(
                        name: "FK_Sell_Gift_GiftId",
                        column: x => x.GiftId,
                        principalTable: "Gift",
                        principalColumn: "GiftId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sell_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sell_GiftId",
                table: "Sell",
                column: "GiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Sell_InvoiceId",
                table: "Sell",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gift_Company_CompanyID",
                table: "Gift",
                column: "CompanyID",
                principalTable: "Company",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
