using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kirilanatur.Server.Migrations
{
    /// <inheritdoc />
    public partial class UsersAndShoppingCarts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Country_CountryId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Address_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryTranslation_Country_CountryId",
                table: "CountryTranslation");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItem_ProductItems_ProductItemId",
                table: "ShoppingCartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItem_ShoppingCart_ShoppingCartId",
                table: "ShoppingCartItem");

            migrationBuilder.DropTable(
                name: "ShoppingCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartItem",
                table: "ShoppingCartItem");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartItem_ShoppingCartId",
                table: "ShoppingCartItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CountryTranslation",
                table: "CountryTranslation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Country",
                table: "Country");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "ShoppingCartItem");

            migrationBuilder.RenameTable(
                name: "ShoppingCartItem",
                newName: "ShoppingCartItems");

            migrationBuilder.RenameTable(
                name: "CountryTranslation",
                newName: "CountryTranslations");

            migrationBuilder.RenameTable(
                name: "Country",
                newName: "Countries");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartItem_ProductItemId",
                table: "ShoppingCartItems",
                newName: "IX_ShoppingCartItems_ProductItemId");

            migrationBuilder.RenameIndex(
                name: "IX_CountryTranslation_CountryId",
                table: "CountryTranslations",
                newName: "IX_CountryTranslations_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_CountryId",
                table: "Addresses",
                newName: "IX_Addresses_CountryId");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ShoppingCartItems",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartItems",
                table: "ShoppingCartItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CountryTranslations",
                table: "CountryTranslations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "OrderStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderStatusType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentMethodOption = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShippingMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShippingMethodOption = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatusTranslation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatusTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderStatusTranslation_OrderStatuses_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethodTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethodTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentMethodTranslations_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShippingMethodTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingMethodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingMethodTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingMethodTranslations_ShippingMethods_ShippingMethodId",
                        column: x => x.ShippingMethodId,
                        principalTable: "ShippingMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShopOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderTotal = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    ShippingMethodId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopOrders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopOrders_OrderStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "OrderStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShopOrders_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShopOrders_ShippingMethods_ShippingMethodId",
                        column: x => x.ShippingMethodId,
                        principalTable: "ShippingMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ProductItemId = table.Column<int>(type: "int", nullable: false),
                    ShopOrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderLines_ProductItems_ProductItemId",
                        column: x => x.ProductItemId,
                        principalTable: "ProductItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderLines_ShopOrders_ShopOrderId",
                        column: x => x.ShopOrderId,
                        principalTable: "ShopOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_UserId",
                table: "ShoppingCartItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_ProductItemId",
                table: "OrderLines",
                column: "ProductItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_ShopOrderId",
                table: "OrderLines",
                column: "ShopOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderStatusTranslation_OrderStatusId",
                table: "OrderStatusTranslation",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethodTranslations_PaymentMethodId",
                table: "PaymentMethodTranslations",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingMethodTranslations_ShippingMethodId",
                table: "ShippingMethodTranslations",
                column: "ShippingMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopOrders_PaymentMethodId",
                table: "ShopOrders",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopOrders_ShippingMethodId",
                table: "ShopOrders",
                column: "ShippingMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopOrders_StatusId",
                table: "ShopOrders",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopOrders_UserId",
                table: "ShopOrders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Countries_CountryId",
                table: "Addresses",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId",
                table: "AspNetUsers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryTranslations_Countries_CountryId",
                table: "CountryTranslations",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_AspNetUsers_UserId",
                table: "ShoppingCartItems",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_ProductItems_ProductItemId",
                table: "ShoppingCartItems",
                column: "ProductItemId",
                principalTable: "ProductItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Countries_CountryId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryTranslations_Countries_CountryId",
                table: "CountryTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_AspNetUsers_UserId",
                table: "ShoppingCartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_ProductItems_ProductItemId",
                table: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "OrderLines");

            migrationBuilder.DropTable(
                name: "OrderStatusTranslation");

            migrationBuilder.DropTable(
                name: "PaymentMethodTranslations");

            migrationBuilder.DropTable(
                name: "ShippingMethodTranslations");

            migrationBuilder.DropTable(
                name: "ShopOrders");

            migrationBuilder.DropTable(
                name: "OrderStatuses");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "ShippingMethods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartItems",
                table: "ShoppingCartItems");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartItems_UserId",
                table: "ShoppingCartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CountryTranslations",
                table: "CountryTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ShoppingCartItems");

            migrationBuilder.RenameTable(
                name: "ShoppingCartItems",
                newName: "ShoppingCartItem");

            migrationBuilder.RenameTable(
                name: "CountryTranslations",
                newName: "CountryTranslation");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "Country");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartItems_ProductItemId",
                table: "ShoppingCartItem",
                newName: "IX_ShoppingCartItem_ProductItemId");

            migrationBuilder.RenameIndex(
                name: "IX_CountryTranslations_CountryId",
                table: "CountryTranslation",
                newName: "IX_CountryTranslation_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_CountryId",
                table: "Address",
                newName: "IX_Address_CountryId");

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartId",
                table: "ShoppingCartItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartItem",
                table: "ShoppingCartItem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CountryTranslation",
                table: "CountryTranslation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Country",
                table: "Country",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCart_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_ShoppingCartId",
                table: "ShoppingCartItem",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_UserId",
                table: "ShoppingCart",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Country_CountryId",
                table: "Address",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Address_AddressId",
                table: "AspNetUsers",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CountryTranslation_Country_CountryId",
                table: "CountryTranslation",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItem_ProductItems_ProductItemId",
                table: "ShoppingCartItem",
                column: "ProductItemId",
                principalTable: "ProductItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItem_ShoppingCart_ShoppingCartId",
                table: "ShoppingCartItem",
                column: "ShoppingCartId",
                principalTable: "ShoppingCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
