using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace newApi.Migrations
{
    public partial class tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_CartStatus",
                columns: table => new
                {
                    CartStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartStatus = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tbl_Cart__031908A81BD04AE9", x => x.CartStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tbl_Cate__19093A0B98B84E79", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_IotUsers",
                columns: table => new
                {
                    IotId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    MemberId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IOT_users", x => x.IotId);
                    table.ForeignKey(
                        name: "FK_IOT_users_Tbl_Members1",
                        column: x => x.MemberId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ShippingDetails",
                columns: table => new
                {
                    ShippingDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Adress = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    City = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    State = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Country = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ZipCode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    AmountPaid = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    PaymentType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tbl_Ship__FBB36851C3557549", x => x.ShippingDetailId);
                    table.ForeignKey(
                        name: "FK__Tbl_Shipp__Membe__3A81B327",
                        column: x => x.MemberId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_SlideImage",
                columns: table => new
                {
                    SlideId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SlideTitle = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    SlideImage = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tbl_Slid__9E7CB650351FDDE7", x => x.SlideId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Description = table.Column<DateTime>(type: "datetime", nullable: true),
                    ProductImage = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tbl_Prod__B40CC6CD13FC4977", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK__Tbl_Produ__Categ__398D8EEE",
                        column: x => x.CategoryId,
                        principalTable: "Tbl_Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Cart",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    MemberId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CartStatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tbl_Cart__51BCD7B7F7E8BC66", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Tbl_Cart_Tbl_CartStatus",
                        column: x => x.CartStatusId,
                        principalTable: "Tbl_CartStatus",
                        principalColumn: "CartStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_Cart_Tbl_Members",
                        column: x => x.MemberId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_Cart_Tbl_Product",
                        column: x => x.ProductId,
                        principalTable: "Tbl_Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Cart_CartStatusId",
                table: "Tbl_Cart",
                column: "CartStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Cart_MemberId",
                table: "Tbl_Cart",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Cart_ProductId",
                table: "Tbl_Cart",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "UQ__Tbl_Cate__8517B2E024832BE2",
                table: "Tbl_Category",
                column: "CategoryName",
                unique: true,
                filter: "[CategoryName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_IotUsers_MemberId",
                table: "Tbl_IotUsers",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Product_CategoryId",
                table: "Tbl_Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "UQ__Tbl_Prod__DD5A978A4FD147D8",
                table: "Tbl_Product",
                column: "ProductName",
                unique: true,
                filter: "[ProductName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ShippingDetails_MemberId",
                table: "Tbl_ShippingDetails",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Cart");

            migrationBuilder.DropTable(
                name: "Tbl_IotUsers");

            migrationBuilder.DropTable(
                name: "Tbl_ShippingDetails");

            migrationBuilder.DropTable(
                name: "Tbl_SlideImage");

            migrationBuilder.DropTable(
                name: "Tbl_CartStatus");

            migrationBuilder.DropTable(
                name: "Tbl_Product");

            migrationBuilder.DropTable(
                name: "Tbl_Category");
        }
    }
}
