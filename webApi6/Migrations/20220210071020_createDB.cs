using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApi6.Migrations
{
    public partial class createDB : Migration
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
                name: "Tbl_MemberRole",
                columns: table => new
                {
                    MemberRoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    memberId = table.Column<int>(type: "int", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tbl_Memb__673C22CB880685B4", x => x.MemberRoleID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Members",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FristName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    LastName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    EmailId = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Password = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    GroupAdmin = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    UserName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tbl_Memb__0CF04B189EC76C9D", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tbl_Role__8AFACE1A68AA8ABB", x => x.RoleId);
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
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "Tbl_IotUsers",
                columns: table => new
                {
                    IotId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembersId = table.Column<int>(type: "int", nullable: true),
                    SerialNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IOT_users", x => x.IotId);
                    table.ForeignKey(
                        name: "FK_IOT_users_Tbl_Members1",
                        column: x => x.MembersId,
                        principalTable: "Tbl_Members",
                        principalColumn: "MemberId");
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ShippingDetails",
                columns: table => new
                {
                    ShippingDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: true),
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
                        principalTable: "Tbl_Members",
                        principalColumn: "MemberId");
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Cart",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    MemberId = table.Column<int>(type: "int", nullable: true),
                    CartStatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tbl_Cart__51BCD7B7F7E8BC66", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Tbl_Cart_Tbl_CartStatus",
                        column: x => x.CartStatusId,
                        principalTable: "Tbl_CartStatus",
                        principalColumn: "CartStatusId");
                    table.ForeignKey(
                        name: "FK_Tbl_Cart_Tbl_Members",
                        column: x => x.MemberId,
                        principalTable: "Tbl_Members",
                        principalColumn: "MemberId");
                    table.ForeignKey(
                        name: "FK_Tbl_Cart_Tbl_Product",
                        column: x => x.ProductId,
                        principalTable: "Tbl_Product",
                        principalColumn: "ProductId");
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
                name: "IX_Tbl_IotUsers_MembersId",
                table: "Tbl_IotUsers",
                column: "MembersId");

            migrationBuilder.CreateIndex(
                name: "UQ__Tbl_Memb__7449F39903552E4B",
                table: "Tbl_Members",
                column: "LastName",
                unique: true,
                filter: "[LastName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__Tbl_Memb__7ED91ACEDC594EB5",
                table: "Tbl_Members",
                column: "EmailId",
                unique: true,
                filter: "[EmailId] IS NOT NULL");

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
                name: "UQ__Tbl_Role__8A2B6160582CE7B7",
                table: "Tbl_Roles",
                column: "RoleName",
                unique: true,
                filter: "[RoleName] IS NOT NULL");

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
                name: "Tbl_MemberRole");

            migrationBuilder.DropTable(
                name: "Tbl_Roles");

            migrationBuilder.DropTable(
                name: "Tbl_ShippingDetails");

            migrationBuilder.DropTable(
                name: "Tbl_SlideImage");

            migrationBuilder.DropTable(
                name: "Tbl_CartStatus");

            migrationBuilder.DropTable(
                name: "Tbl_Product");

            migrationBuilder.DropTable(
                name: "Tbl_Members");

            migrationBuilder.DropTable(
                name: "Tbl_Category");
        }
    }
}
