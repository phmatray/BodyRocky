using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BodyRocky.Back.WebApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BasketStatus",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketStatus", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    BrandID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandLogo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.BrandID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "ZipCode",
                columns: table => new
                {
                    ZipCodeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Commune = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZipCode", x => x.ZipCodeID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ProductURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "BrandID");
                });

            migrationBuilder.CreateTable(
                name: "Basket",
                columns: table => new
                {
                    BasketID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BasketDateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BasketStatusCode = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basket", x => x.BasketID);
                    table.ForeignKey(
                        name: "FK_Basket_BasketStatus_BasketStatusCode",
                        column: x => x.BasketStatusCode,
                        principalTable: "BasketStatus",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Basket_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressFromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddressToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ZipCodeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressID);
                    table.ForeignKey(
                        name: "FK_Address_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_ZipCode_ZipCodeID",
                        column: x => x.ZipCodeID,
                        principalTable: "ZipCode",
                        principalColumn: "ZipCodeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImage",
                columns: table => new
                {
                    ProductImageID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.ProductImageID);
                    table.ForeignKey(
                        name: "FK_ProductImage_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReviewRating = table.Column<int>(type: "int", nullable: false),
                    ReviewText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewID);
                    table.ForeignKey(
                        name: "FK_Review_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Review_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasketProduct",
                columns: table => new
                {
                    BasketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketProduct", x => new { x.BasketId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_BasketProduct_Basket_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Basket",
                        principalColumn: "BasketID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BillingName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BillingAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveryAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderStatusCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Order_Address_BillingAddressId",
                        column: x => x.BillingAddressId,
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Address_DeliveryAddressId",
                        column: x => x.DeliveryAddressId,
                        principalTable: "Address",
                        principalColumn: "AddressID");
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_OrderStatus_OrderStatusCode",
                        column: x => x.OrderStatusCode,
                        principalTable: "OrderStatus",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderedProduct",
                columns: table => new
                {
                    OrderedProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderedProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderedProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderedProductPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderedProduct", x => x.OrderedProductId);
                    table.ForeignKey(
                        name: "FK_OrderedProduct_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderedProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "CategoryName", "IsFeatured" },
                values: new object[,]
                {
                    { new Guid("14e75b5e-ca71-f7ac-cd1d-fd123cb9c27e"), "System.String[]", true },
                    { new Guid("300ec048-a80d-9e7f-7d4f-6ee79e0446c0"), "System.String[]", false },
                    { new Guid("c3557e91-f0f0-34a8-832a-6b6ab9d4516f"), "System.String[]", false }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerID", "BirthDate", "EmailAddress", "FirstName", "LastName", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("0befa4e5-518e-64e5-13a2-852413c3fc79"), new DateTime(2006, 6, 3, 0, 51, 13, 701, DateTimeKind.Local).AddTicks(2195), "Clifton37@hotmail.com", "Clifton", "Wisozk", "cf21b0d735c47fb5f92defc66b7e20db1f84728a", "(722) 554-2550" },
                    { new Guid("0eaa4c37-888a-1c2e-b2b8-50574e0f4378"), new DateTime(2007, 8, 11, 18, 12, 3, 823, DateTimeKind.Local).AddTicks(58), "Iris.Doyle16@yahoo.com", "Iris", "Doyle", "2283fb5477c8e2e3c77666e933b51c83dfac5591", "(408) 791-4137 x717" },
                    { new Guid("0f05a545-7e3c-110b-56a7-0ba775f6bfef"), new DateTime(2006, 10, 24, 18, 5, 27, 479, DateTimeKind.Local).AddTicks(2605), "Tiffany_Rippin56@yahoo.com", "Tiffany", "Rippin", "c23100418698c0c24995c8554f43525344b8f1d7", "(919) 971-9792 x1466" },
                    { new Guid("130cfdc4-27d3-11c1-cb5e-0737ad9e4e7b"), new DateTime(2009, 8, 19, 13, 11, 15, 966, DateTimeKind.Local).AddTicks(3527), "Ginger_Hyatt60@yahoo.com", "Ginger", "Hyatt", "fb3b9c1baa029a637f6f11c667c95f88ae90c0bd", "1-274-838-1174 x55109" },
                    { new Guid("139abff4-5859-02ca-ce02-8b8bf289569d"), new DateTime(2020, 11, 26, 18, 3, 4, 59, DateTimeKind.Local).AddTicks(2547), "Hugo19@hotmail.com", "Hugo", "Dare", "be248cc0474c0245c233629c7336789e86a7975f", "296-382-0636" },
                    { new Guid("13de6330-6a43-1d18-9bc6-c99553f6c6ea"), new DateTime(2020, 11, 28, 20, 33, 36, 325, DateTimeKind.Local).AddTicks(8089), "Glen_Hettinger@hotmail.com", "Glen", "Hettinger", "6b6d9792d6a186e0e08677aa2b5401aaa8987ed8", "(997) 629-5618" },
                    { new Guid("16212585-a5aa-cf80-69a3-599ad5bb32d6"), new DateTime(2014, 10, 29, 12, 4, 15, 423, DateTimeKind.Local).AddTicks(8977), "Virginia_Kessler13@gmail.com", "Virginia", "Kessler", "00f2822485739c9b0fad922761c799904684003c", "895.616.1373 x36767" },
                    { new Guid("166c722e-215d-d794-0aee-4fb3de5f9a3c"), new DateTime(2020, 10, 23, 6, 26, 44, 436, DateTimeKind.Local).AddTicks(3578), "Sandra.Jenkins65@gmail.com", "Sandra", "Jenkins", "872328c3bb6ca412447d47b4c01d8b5f7b2ca00e", "809.505.1203" },
                    { new Guid("17722116-7666-c310-6064-9033c277cab6"), new DateTime(2006, 1, 31, 13, 26, 28, 798, DateTimeKind.Local).AddTicks(1688), "Florence.Rodriguez56@gmail.com", "Florence", "Rodriguez", "0d2a5c5280df307f336888907d920b1963f13c3d", "1-645-739-8811 x479" },
                    { new Guid("17bee96f-56e3-b67f-7690-ed787f187a4b"), new DateTime(2012, 3, 6, 17, 16, 8, 30, DateTimeKind.Local).AddTicks(9037), "Mark.Collier16@yahoo.com", "Mark", "Collier", "08896a844501c2efabb1134cac8e183bb2b8e76b", "305-846-6384" },
                    { new Guid("1887f5f3-cc26-cfdd-7dd8-5b16058fab89"), new DateTime(2016, 10, 22, 16, 26, 13, 538, DateTimeKind.Local).AddTicks(2263), "Estelle.Crona@gmail.com", "Estelle", "Crona", "f69b6ae6d8379893c6950b787de4114c107d07df", "1-942-599-1006" },
                    { new Guid("1b13bb98-5f3b-fffc-2491-2c8527402e36"), new DateTime(2018, 4, 12, 6, 19, 49, 726, DateTimeKind.Local).AddTicks(4913), "Nellie_Marvin@yahoo.com", "Nellie", "Marvin", "07a56367fbe23aab4a3b647fa2ff3a80a2695998", "514-427-7064 x402" },
                    { new Guid("1e288460-7bfd-6ff7-9a1c-454155552091"), new DateTime(2016, 12, 24, 7, 2, 52, 135, DateTimeKind.Local).AddTicks(8362), "Eleanor35@hotmail.com", "Eleanor", "Price", "607ad7d23a94e0f8413f896d1d088751da943396", "1-308-226-0402 x9929" },
                    { new Guid("1ec6f25f-da03-aa9c-ede1-aae5b188aca0"), new DateTime(2018, 12, 30, 0, 20, 47, 420, DateTimeKind.Local).AddTicks(7717), "Christina.Quitzon40@yahoo.com", "Christina", "Quitzon", "77a7ab35c2d2dbbfca9555b8e71b1bde3e677f91", "232-679-8272" },
                    { new Guid("1fd7a44c-7732-7509-dccc-682dc9114380"), new DateTime(2018, 9, 6, 1, 13, 48, 75, DateTimeKind.Local).AddTicks(8051), "Alexander.Bailey@gmail.com", "Alexander", "Bailey", "3409b392fe8d4feb1d3ab05643dc3b658a7e0e83", "641-534-3591 x99585" },
                    { new Guid("26790b56-e67f-a8a3-d082-101b31879cca"), new DateTime(2017, 10, 13, 6, 14, 12, 160, DateTimeKind.Local).AddTicks(7611), "Charlotte_Durgan2@gmail.com", "Charlotte", "Durgan", "eca6bbd2c785a550f0c0f7598be7b06cdd39d086", "634-200-5716 x3043" },
                    { new Guid("2bd9c2e4-985e-592d-1fa4-bab3891fd488"), new DateTime(2020, 7, 12, 23, 13, 31, 489, DateTimeKind.Local).AddTicks(9607), "Cheryl_Witting44@yahoo.com", "Cheryl", "Witting", "439a88eebff03f72125c27f49cbdc48056a5a369", "(829) 928-0658 x95195" },
                    { new Guid("2c40526e-441b-c5fd-6d89-d6e6a286af8e"), new DateTime(2015, 9, 13, 16, 22, 17, 639, DateTimeKind.Local).AddTicks(9433), "Marta90@yahoo.com", "Marta", "McClure", "165c5d147a376117d7daaa04cf74ec42d1c21c1b", "(285) 991-1620" },
                    { new Guid("2d6fa436-be81-f85b-8d9f-908ad558f401"), new DateTime(2020, 10, 11, 4, 35, 15, 766, DateTimeKind.Local).AddTicks(533), "Jim_Schoen@gmail.com", "Jim", "Schoen", "79c65d8671ce2ae3a096a16bab12d8a309c47092", "(454) 429-9589 x383" },
                    { new Guid("3122cc02-9ddc-1296-6e41-e12608972daa"), new DateTime(2010, 10, 3, 8, 28, 51, 995, DateTimeKind.Local).AddTicks(5173), "Tim.Sanford82@yahoo.com", "Tim", "Sanford", "a3fe5f9e05b8bcac690584043b4c800bb93020dd", "920.902.6132 x00816" },
                    { new Guid("31397f73-5f10-7346-f079-fcf82bbe6e4c"), new DateTime(2008, 5, 12, 2, 23, 49, 122, DateTimeKind.Local).AddTicks(9542), "Daryl.Nolan@gmail.com", "Daryl", "Nolan", "f3ebe446ddf95ba5a5c9b3e9b73861b958a8cddc", "(249) 512-7055" },
                    { new Guid("318cd55c-1244-7af2-af67-3dbde16f1906"), new DateTime(2009, 12, 6, 3, 7, 0, 411, DateTimeKind.Local).AddTicks(9551), "Clifford41@hotmail.com", "Clifford", "Koch", "4ceae2842dea131ce684797fe49dc421fce519a3", "468.203.1172 x9852" },
                    { new Guid("358e5346-3c49-fda6-7d04-7315d16bc4b8"), new DateTime(2015, 2, 5, 16, 2, 14, 835, DateTimeKind.Local).AddTicks(6363), "Israel_Beahan67@gmail.com", "Israel", "Beahan", "3de81b796348eb339bc2392f72e14266033dfde8", "408.608.6193" },
                    { new Guid("3ad8e4c2-f62a-af55-0b18-6b817d9ecd32"), new DateTime(2010, 11, 27, 13, 7, 54, 142, DateTimeKind.Local).AddTicks(2877), "Jermaine_Reilly55@hotmail.com", "Jermaine", "Reilly", "bdaa518797bb0286d20f351e056039a60b140eaf", "1-844-231-3091 x6379" },
                    { new Guid("425edfe9-e507-5774-1f88-556c0879e46c"), new DateTime(2011, 11, 19, 22, 37, 32, 338, DateTimeKind.Local).AddTicks(1312), "Hope.Beier@hotmail.com", "Hope", "Beier", "8126e1baa34601145f5b128498fd20297cf9ea92", "811-341-7564 x65437" },
                    { new Guid("4b59e25c-3b32-840c-9812-774484741577"), new DateTime(2005, 5, 10, 1, 43, 35, 133, DateTimeKind.Local).AddTicks(6559), "Rudy77@hotmail.com", "Rudy", "McCullough", "327f7baf9b7460b11a329aae2502508a3004d001", "1-807-558-0527 x579" },
                    { new Guid("4bfa3efb-aa1b-5616-d1ef-e72799aaf0a0"), new DateTime(2005, 6, 15, 18, 13, 43, 558, DateTimeKind.Local).AddTicks(4239), "Leona_Lowe94@gmail.com", "Leona", "Lowe", "abec71d56a10f3a24e4f2ac0b7f6f6a1f2490987", "325-484-5321" },
                    { new Guid("4da5bdaf-d232-b944-aa4a-dfd426ff3aa3"), new DateTime(2007, 2, 23, 16, 13, 44, 243, DateTimeKind.Local).AddTicks(6330), "Flora_Morar77@hotmail.com", "Flora", "Morar", "902eab78a756c83dc05ee4f0a15343d29245d372", "263-319-2438" },
                    { new Guid("4f98aa83-2133-f94f-4e6e-c3b4a51120b4"), new DateTime(2008, 2, 10, 21, 26, 30, 87, DateTimeKind.Local).AddTicks(4803), "Derrick_Abbott@gmail.com", "Derrick", "Abbott", "9fa18e0a8457c5dc8ad74ef7760565f638bb8ede", "(619) 443-4275 x115" },
                    { new Guid("5d35529f-88cd-71f0-a8c9-7c23594b42a6"), new DateTime(2004, 11, 24, 18, 51, 51, 321, DateTimeKind.Local).AddTicks(2903), "Leonard.Kunze@yahoo.com", "Leonard", "Kunze", "0045be1921a3fe7a7f38f54ea9457d0ae704d33a", "318-363-4381" },
                    { new Guid("5e97d581-e859-e2f5-8644-b18013fefac5"), new DateTime(2006, 1, 2, 2, 57, 37, 894, DateTimeKind.Local).AddTicks(6293), "Allen_Gaylord23@hotmail.com", "Allen", "Gaylord", "340c21308c4d884f375338fcc1ae7d2b9fcac864", "(312) 745-7263 x52653" },
                    { new Guid("60e00bd2-5d3a-d8a1-18ac-ffae0d1997a7"), new DateTime(2011, 1, 5, 7, 27, 49, 792, DateTimeKind.Local).AddTicks(2928), "Leland.Orn60@hotmail.com", "Leland", "Orn", "e0d1c6a3adab7cfb65222a287c4a29297cc8867d", "927.770.0531" },
                    { new Guid("61dc6d3e-9309-313b-3aaa-07d534f58418"), new DateTime(2015, 3, 10, 11, 23, 39, 722, DateTimeKind.Local).AddTicks(6779), "Clint84@yahoo.com", "Clint", "Kertzmann", "2616e6e2949503c09c98239ebd2c569d98d26948", "807-466-3298 x4481" },
                    { new Guid("665236f5-5593-56fb-1fff-cbcbb8cf1676"), new DateTime(2020, 6, 23, 20, 27, 1, 249, DateTimeKind.Local).AddTicks(3769), "Joel.Gerhold@hotmail.com", "Joel", "Gerhold", "dda974875111902205cf590d708e26847f99c4fe", "594-258-3866 x81410" },
                    { new Guid("674338f6-6508-5496-6dad-73ccdc3eb662"), new DateTime(2005, 3, 19, 13, 4, 16, 462, DateTimeKind.Local).AddTicks(1405), "Shawn.Zieme43@hotmail.com", "Shawn", "Zieme", "9277116941f77e140cd2733517a7e59d57548a57", "752.806.4371" },
                    { new Guid("6790061b-6bb5-a46f-d2bf-9ce6f7338fad"), new DateTime(2015, 12, 27, 21, 45, 56, 707, DateTimeKind.Local).AddTicks(4534), "Jane.Jacobs82@hotmail.com", "Jane", "Jacobs", "86573a2270c2903ee8378a2445fe0c62da8e627a", "954-507-6496 x866" },
                    { new Guid("6998dc98-02b8-4b9a-4e45-9d60700ca66e"), new DateTime(2007, 2, 24, 4, 29, 44, 144, DateTimeKind.Local).AddTicks(3464), "Everett91@hotmail.com", "Everett", "Crona", "2237d32ec005f1685efd7e460bbc6ab4a3e9e9ff", "1-834-267-0772 x1485" },
                    { new Guid("6e79f291-87df-03ba-8471-e497f7c04f0c"), new DateTime(2006, 6, 14, 0, 54, 58, 732, DateTimeKind.Local).AddTicks(9031), "Francis_Skiles78@yahoo.com", "Francis", "Skiles", "5ff489e38f3999a2a0185bc5fcb30514a4f59af3", "(923) 520-9976 x7661" },
                    { new Guid("72b14f87-b1b4-e850-9a25-4cdf7afd171c"), new DateTime(2014, 11, 27, 6, 2, 49, 838, DateTimeKind.Local).AddTicks(969), "Kelvin3@gmail.com", "Kelvin", "Bruen", "020a2a287abb1e06a1235bdc4bb91fd700e37bed", "711.719.5093" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerID", "BirthDate", "EmailAddress", "FirstName", "LastName", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("7349a633-7f05-836c-94f3-fea3b4855ded"), new DateTime(2011, 7, 8, 3, 41, 59, 206, DateTimeKind.Local).AddTicks(2550), "Josh.Abshire43@hotmail.com", "Josh", "Abshire", "8fa931853d5940c979a61da0882b062544143f6f", "440.989.1858 x03511" },
                    { new Guid("77b68bdb-d656-3ac3-6d09-52c4097837be"), new DateTime(2015, 11, 6, 14, 0, 4, 496, DateTimeKind.Local).AddTicks(529), "Lora70@hotmail.com", "Lora", "Fahey", "a78860048103de92bbc80343ee30cd4104246b5e", "1-831-498-6465 x0154" },
                    { new Guid("79e20778-3f38-dc35-01af-feee0ce344bb"), new DateTime(2017, 1, 10, 6, 32, 56, 181, DateTimeKind.Local).AddTicks(6602), "Lola_Little@yahoo.com", "Lola", "Little", "2670299ca4a9479951368b0b6e095a3807124f9f", "1-730-832-3442 x747" },
                    { new Guid("7a7f3728-1d53-e7e3-86c6-78a4169e7677"), new DateTime(2006, 1, 12, 1, 44, 19, 405, DateTimeKind.Local).AddTicks(8589), "Leona.Kuhn@yahoo.com", "Leona", "Kuhn", "0190ad71046ff472d47f9cb222db718a24cdd2da", "1-290-289-0323" },
                    { new Guid("7f4392c4-f216-f9e6-cbc8-2a39d0dad87c"), new DateTime(2005, 1, 22, 14, 20, 58, 789, DateTimeKind.Local).AddTicks(9315), "Lyle_Adams77@yahoo.com", "Lyle", "Adams", "1e47a33cceb0075693a9e8b7fe867664b0b69ae0", "(723) 210-3891" },
                    { new Guid("7fe6afbb-a564-0dd3-3645-3305d11ec7c5"), new DateTime(2005, 7, 21, 18, 2, 34, 123, DateTimeKind.Local).AddTicks(329), "Blanca.Kozey@yahoo.com", "Blanca", "Kozey", "e9e48d84cdb4215f70b94019712a3f244c126833", "(380) 430-5156 x4121" },
                    { new Guid("82ff0eb0-5cc8-22c3-a138-0a4c8f4eb707"), new DateTime(2012, 10, 27, 17, 10, 17, 174, DateTimeKind.Local).AddTicks(7644), "Melba.Von@hotmail.com", "Melba", "Von", "a35e7909a296becf77bbd9bfa1ac1dcfb9486775", "209-843-5615 x4112" },
                    { new Guid("8367307b-6e92-29f0-7c4e-869d4a854be5"), new DateTime(2007, 2, 1, 17, 41, 21, 827, DateTimeKind.Local).AddTicks(6145), "Carmen_Bartell74@yahoo.com", "Carmen", "Bartell", "314eaf16119fb20f055afadc3927386efe7da948", "(903) 220-9636" },
                    { new Guid("83cc9d37-21ad-fff9-c5bf-a2ee22939a3d"), new DateTime(2022, 8, 14, 20, 36, 10, 14, DateTimeKind.Local).AddTicks(4758), "Vicki12@hotmail.com", "Vicki", "Kunze", "4704abc5e22d2323021769a034f0b25a00ba21a0", "456.537.8613 x720" },
                    { new Guid("8642178f-49f0-920c-b7a4-7e13b4aa8521"), new DateTime(2007, 4, 7, 8, 4, 2, 826, DateTimeKind.Local).AddTicks(4116), "Clay_Lang@hotmail.com", "Clay", "Lang", "b754bef0d426358523d0bf5603376c6e99264681", "847.459.1965 x94106" },
                    { new Guid("89c2d2dd-b15e-adcf-3b17-0944672ae76c"), new DateTime(2018, 4, 20, 7, 20, 41, 57, DateTimeKind.Local).AddTicks(2484), "Darin_Hoppe@hotmail.com", "Darin", "Hoppe", "bea16bff5c70b5e771d7d15dbc82be166cede0f6", "(371) 901-8737" },
                    { new Guid("8c2b0ab7-554e-42e1-d70f-102cfd4994e4"), new DateTime(2009, 5, 9, 10, 4, 38, 22, DateTimeKind.Local).AddTicks(2539), "Jan_Quitzon@gmail.com", "Jan", "Quitzon", "982ba7fa63252fe2a68abdc716dda37a6c2f6c5e", "658.940.2762" },
                    { new Guid("8c560cbf-eaac-4207-d64b-123ed6b4f014"), new DateTime(2022, 2, 2, 14, 52, 30, 429, DateTimeKind.Local).AddTicks(6510), "Amelia_Hammes@gmail.com", "Amelia", "Hammes", "42a0263fce2c12202359899303908b3d1c5b4a94", "(273) 360-4099" },
                    { new Guid("8e327c2d-9f60-2696-89b8-93e7c092b065"), new DateTime(2020, 11, 15, 3, 0, 28, 827, DateTimeKind.Local).AddTicks(7057), "Eleanor89@yahoo.com", "Eleanor", "Thompson", "e0e6d043e7423c531d34a1165e0911cae67c956e", "(537) 201-8655" },
                    { new Guid("8fa5e7df-28ed-bc9a-964f-7144c47427c0"), new DateTime(2013, 7, 20, 12, 47, 28, 82, DateTimeKind.Local).AddTicks(9737), "Krystal26@hotmail.com", "Krystal", "Leffler", "e4794f55435df18240cc9b11c326372d27dd5611", "(987) 597-0142" },
                    { new Guid("914cf295-3c6b-f005-9a4e-46704cd621bb"), new DateTime(2019, 4, 20, 22, 13, 15, 837, DateTimeKind.Local).AddTicks(4607), "Neil15@yahoo.com", "Neil", "Sauer", "7e21a47b7286a123ea9f332d81dd55c43db25d1b", "(835) 351-4437 x3845" },
                    { new Guid("921b554a-e7e0-30c2-a4fc-7f65362b1239"), new DateTime(2011, 12, 3, 10, 37, 26, 311, DateTimeKind.Local).AddTicks(1203), "Jordan_Macejkovic@gmail.com", "Jordan", "Macejkovic", "e0193abf307d2dd01c424e8ed26f2566868e67bf", "(825) 446-8998 x66145" },
                    { new Guid("923c700d-3098-e3d5-1caf-a2508bb09a91"), new DateTime(2015, 6, 23, 8, 51, 22, 643, DateTimeKind.Local).AddTicks(1190), "Harvey_Mosciski92@yahoo.com", "Harvey", "Mosciski", "bf28b652b6314f4c846a05f9c9028c8d99e9c81b", "(262) 354-6155 x985" },
                    { new Guid("93cec1ad-8cde-c1b2-530c-f5c72fe02d38"), new DateTime(2013, 11, 2, 13, 2, 27, 204, DateTimeKind.Local).AddTicks(742), "Cody87@hotmail.com", "Cody", "Wiegand", "ca60d2b2287a08f8c3f29957c0dc05b141cd69b1", "702.572.1582" },
                    { new Guid("9b5834e3-a26c-1879-69b5-8e8334a65911"), new DateTime(2017, 8, 7, 7, 13, 21, 261, DateTimeKind.Local).AddTicks(5166), "Doug54@yahoo.com", "Doug", "Becker", "b80558efeca5b8f0d8c9259c7690f3e0e11905b7", "842-993-4605" },
                    { new Guid("9b736e17-2297-aef9-c10a-7681432a2e3c"), new DateTime(2019, 2, 17, 3, 31, 39, 624, DateTimeKind.Local).AddTicks(5451), "Jeanette58@gmail.com", "Jeanette", "Swaniawski", "5b1e78d6a9288701a59c46197ea60ef5ba2e724c", "344.292.9046" },
                    { new Guid("a183b39c-9a2f-a4b2-34cc-a02d3c7b3251"), new DateTime(2020, 11, 15, 11, 13, 0, 228, DateTimeKind.Local).AddTicks(3502), "Linda_Schumm@yahoo.com", "Linda", "Schumm", "878b1b3174f715b21fc5786778a14bd1b94aa01c", "703.475.3885" },
                    { new Guid("a35c6d9b-2dd7-f056-1390-a1b92bcbbe18"), new DateTime(2011, 7, 13, 17, 18, 3, 49, DateTimeKind.Local).AddTicks(5839), "Kathryn_Schowalter@gmail.com", "Kathryn", "Schowalter", "4ad1aa6cccc709cba8b7240da37ccff7b254d350", "667-668-3088 x2864" },
                    { new Guid("a522f1ad-d384-4b0c-68de-fa767f4858e8"), new DateTime(2009, 7, 5, 19, 31, 39, 254, DateTimeKind.Local).AddTicks(5115), "Hilda_Larkin64@gmail.com", "Hilda", "Larkin", "7881995e6ce7c1bc326b84e511425266dc42b87b", "(800) 548-7854 x0775" },
                    { new Guid("a8fb8823-658c-fe5c-3bdc-93feaea53cd8"), new DateTime(2021, 12, 13, 10, 25, 14, 234, DateTimeKind.Local).AddTicks(9538), "Desiree78@yahoo.com", "Desiree", "Treutel", "320486a24116786f759f1871811b72e2c0c99e14", "1-704-958-8618" },
                    { new Guid("add1aa11-3482-1e0b-0de5-d10240bd9b5b"), new DateTime(2011, 12, 30, 5, 42, 43, 326, DateTimeKind.Local).AddTicks(7013), "Emanuel_Beatty@hotmail.com", "Emanuel", "Beatty", "cd17bb09049959c224ebddbc49d3b1ea39572afd", "(528) 848-8732" },
                    { new Guid("b38d36e7-d41c-bf07-a5c2-428b367fb425"), new DateTime(2007, 1, 11, 4, 23, 18, 184, DateTimeKind.Local).AddTicks(315), "Terence.Predovic10@yahoo.com", "Terence", "Predovic", "263b633d52cbf183e142f2652e47d7a749335a8f", "472.440.8875" },
                    { new Guid("b44576d2-7324-ebb0-6683-5e48155940a4"), new DateTime(2016, 3, 19, 7, 6, 17, 23, DateTimeKind.Local).AddTicks(5843), "Myrtle60@yahoo.com", "Myrtle", "Stamm", "337762434e53f240219d14592629de3bbe367276", "1-286-952-7726 x4118" },
                    { new Guid("b48b6708-d6c4-d0e8-743a-1d9e15ebb3b8"), new DateTime(2017, 10, 6, 6, 5, 49, 719, DateTimeKind.Local).AddTicks(8534), "Pablo63@gmail.com", "Pablo", "Keebler", "2b183903d2d92a2650976fd79d475716efe8652e", "(821) 966-8992" },
                    { new Guid("b6881f12-1b7d-6c1c-21d0-f8cb221bb57f"), new DateTime(2022, 6, 14, 3, 44, 23, 878, DateTimeKind.Local).AddTicks(7666), "Tyler.Windler28@hotmail.com", "Tyler", "Windler", "707d90dbffad2ef3648c261a9c1a1d38b4e8e8d4", "1-274-578-8682 x714" },
                    { new Guid("c4f5569e-8e92-b165-bd2f-9b235adf5988"), new DateTime(2006, 8, 25, 15, 27, 58, 195, DateTimeKind.Local).AddTicks(511), "Mario_Gleichner@gmail.com", "Mario", "Gleichner", "3206a82a0b1e277092a05b96843b2059774643b1", "(767) 601-8809 x30964" },
                    { new Guid("c5c022f1-cee8-ba08-d3f0-826e3c2ee9ae"), new DateTime(2006, 1, 28, 7, 38, 49, 642, DateTimeKind.Local).AddTicks(7282), "Christina_Pfannerstill@yahoo.com", "Christina", "Pfannerstill", "949865c911ba1467fdabcc294cf719be0f998c61", "822.307.6869 x4635" },
                    { new Guid("c8911711-a236-e640-2b65-f461be60af36"), new DateTime(2011, 6, 14, 6, 31, 18, 471, DateTimeKind.Local).AddTicks(1661), "Calvin_Grady69@gmail.com", "Calvin", "Grady", "ca83647df7ea57d9a28fb19ed9853d78ca5677de", "1-333-749-7040" },
                    { new Guid("cae30d77-523e-0e20-cb21-4b4963033269"), new DateTime(2005, 4, 28, 1, 31, 29, 496, DateTimeKind.Local).AddTicks(9063), "Melody_Cormier@hotmail.com", "Melody", "Cormier", "cba3d7f00e8abe2c1f61d26e42eacce4a3795bf0", "(466) 573-6748" },
                    { new Guid("cd282a1e-18ce-f105-c102-449ffada84d2"), new DateTime(2010, 8, 19, 7, 9, 33, 264, DateTimeKind.Local).AddTicks(9592), "Angel64@gmail.com", "Angel", "Schmitt", "9138d5e81a684f2ffe356568e269b6e4834af4ad", "1-276-476-9385 x03192" },
                    { new Guid("cd984c84-5092-2d6a-647e-4f89a3342dec"), new DateTime(2007, 11, 30, 15, 24, 27, 697, DateTimeKind.Local).AddTicks(3245), "Jared_Langworth@yahoo.com", "Jared", "Langworth", "fc2a065a676cc655ad48abe9987c99f87436ed8e", "1-333-478-1484" },
                    { new Guid("d19eb9df-2bc0-a38b-e4b1-ff657b3fcea3"), new DateTime(2015, 3, 27, 16, 15, 13, 363, DateTimeKind.Local).AddTicks(7568), "Inez_King@hotmail.com", "Inez", "King", "0cf2a69c068512ad5bb56306cba09909104e94b3", "(569) 690-5541 x9563" },
                    { new Guid("d269f076-1dd4-1891-f54b-6b892ecb3fce"), new DateTime(2006, 8, 10, 18, 2, 7, 535, DateTimeKind.Local).AddTicks(6509), "Verna85@hotmail.com", "Verna", "Cremin", "d130a534fc9798b7d2e72eef0eb94ad33205a023", "334.472.5853" },
                    { new Guid("d3d81b43-68d5-aaae-3d07-98bac322e53b"), new DateTime(2017, 11, 29, 21, 58, 3, 889, DateTimeKind.Local).AddTicks(6567), "Michael_Morissette@yahoo.com", "Michael", "Morissette", "0ceb54499b2d68027a7ad5620296f0f700b06bce", "(347) 543-4317 x990" },
                    { new Guid("d6592505-0c71-0b6e-754f-2c537cff6332"), new DateTime(2010, 5, 18, 14, 47, 48, 113, DateTimeKind.Local).AddTicks(1463), "Simon.Klocko36@hotmail.com", "Simon", "Klocko", "db712c3592fb7f823d5a961779ce03e61e54cec6", "1-608-813-4598" },
                    { new Guid("dc6d3f5a-be01-1e67-2087-17f549c11633"), new DateTime(2008, 3, 6, 1, 33, 4, 998, DateTimeKind.Local).AddTicks(8171), "Peggy.Sanford@hotmail.com", "Peggy", "Sanford", "8a203f2255d620234eb51d9766e847dc3cf66d4c", "244.456.1502" },
                    { new Guid("e10d43f7-6953-dad6-f02a-b9ad1bcbfc49"), new DateTime(2020, 8, 9, 8, 39, 16, 483, DateTimeKind.Local).AddTicks(9082), "Rebecca.Abbott@gmail.com", "Rebecca", "Abbott", "3746656bce5dde6cc9c34b05bdfa23e581f5bc4c", "1-566-215-7373" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerID", "BirthDate", "EmailAddress", "FirstName", "LastName", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("e1226f27-c5bd-a3ec-61dc-16570a5931dc"), new DateTime(2019, 8, 1, 10, 10, 25, 135, DateTimeKind.Local).AddTicks(6013), "Shannon.Cummings10@yahoo.com", "Shannon", "Cummings", "6ad8d0ba80f1f2d9d59a174a5d8a13e627026ae8", "822.686.4046" },
                    { new Guid("e4e56dbe-26d1-aa52-7d3c-fc9bb76890d9"), new DateTime(2007, 11, 1, 9, 19, 54, 759, DateTimeKind.Local).AddTicks(5510), "Preston75@yahoo.com", "Preston", "King", "19cae0a6ea3c4fe799756c562d9f36614dfbdbfb", "(765) 922-4641 x8681" },
                    { new Guid("e806f965-9660-fb28-0646-f50ef243adbf"), new DateTime(2020, 6, 15, 23, 28, 22, 83, DateTimeKind.Local).AddTicks(6522), "May.Baumbach59@hotmail.com", "May", "Baumbach", "679c1718acb2b33217319f12541426ea769b6abc", "316.612.7420 x46420" },
                    { new Guid("ec77729e-6676-3656-82d8-de42853fd33a"), new DateTime(2020, 3, 18, 19, 30, 44, 502, DateTimeKind.Local).AddTicks(7010), "Marcia.Keeling24@gmail.com", "Marcia", "Keeling", "04e4cbb2946085c2d6359a4a10f74420a0279be1", "722.422.8499 x442" },
                    { new Guid("edb0576d-d2c2-4d45-ffa4-4c1409c28be5"), new DateTime(2006, 1, 26, 19, 9, 0, 500, DateTimeKind.Local).AddTicks(3170), "Timothy.Buckridge93@yahoo.com", "Timothy", "Buckridge", "bc61ad75642f968231417231d7ca348e3aa19a15", "1-431-403-9425" },
                    { new Guid("f00709f3-8ecf-b810-2b1b-5e86fa2f79a9"), new DateTime(2016, 7, 7, 9, 13, 18, 43, DateTimeKind.Local).AddTicks(6745), "Steve_Kuhn@gmail.com", "Steve", "Kuhn", "03dc9a34023944bb0e36b9886345d22c9513e91e", "1-574-679-2566 x244" },
                    { new Guid("f034bb12-4909-c2f1-adc2-941ef392201e"), new DateTime(2006, 4, 20, 17, 25, 24, 545, DateTimeKind.Local).AddTicks(4038), "Kristopher_Crooks@yahoo.com", "Kristopher", "Crooks", "a78dc22921ac0ee5796e2efef9f700577ab91fd2", "519-655-7666" },
                    { new Guid("f105cf03-64d7-a7af-abc2-fc6510a0769e"), new DateTime(2015, 5, 1, 15, 22, 45, 68, DateTimeKind.Local).AddTicks(8065), "David_Gaylord@gmail.com", "David", "Gaylord", "b736578ace33b459230eba9d2dfec14257faf4eb", "276.595.3664" },
                    { new Guid("f2a7bee5-0f00-1575-c0c5-333d77fa69ab"), new DateTime(2010, 6, 13, 10, 11, 45, 236, DateTimeKind.Local).AddTicks(4256), "Joan29@hotmail.com", "Joan", "Wisozk", "fe7fd4481b34d8a8920b91b3bd39489727d7c4e3", "(328) 576-6124" },
                    { new Guid("f2ef8ca1-7906-a130-4a70-966bf14347f5"), new DateTime(2018, 9, 19, 17, 48, 23, 688, DateTimeKind.Local).AddTicks(8670), "Fredrick0@gmail.com", "Fredrick", "Ondricka", "75658f844f9f7d90ef0a3d79f5143bad5265d2b8", "(583) 764-7407 x002" },
                    { new Guid("f3d5b49c-62e0-db74-c54a-7b17c09d5a47"), new DateTime(2005, 4, 7, 8, 31, 44, 229, DateTimeKind.Local).AddTicks(5834), "Darrel.DAmore97@yahoo.com", "Darrel", "D'Amore", "34983a885aa966e7a3a4d4a53b78cc153da3affe", "269.677.3432" },
                    { new Guid("f57d7f01-282c-7433-3820-021d9e1c578c"), new DateTime(2016, 11, 6, 17, 28, 40, 95, DateTimeKind.Local).AddTicks(2970), "Ruben19@gmail.com", "Ruben", "Hayes", "6039df4e64fcf19fe21d36d3c6707a0c225f73ad", "548-482-3914 x968" },
                    { new Guid("f7163aa1-4ebe-9191-1bd5-e8dd8263ef60"), new DateTime(2020, 10, 19, 4, 26, 33, 720, DateTimeKind.Local).AddTicks(6996), "Tabitha_Stark@yahoo.com", "Tabitha", "Stark", "93f10c182fa04ed21c5f71d08190dca286b20ed4", "605.453.2490" },
                    { new Guid("f91525ba-915d-f8e9-3215-5548c6734221"), new DateTime(2017, 1, 21, 18, 49, 13, 661, DateTimeKind.Local).AddTicks(6273), "Estelle.Kemmer46@hotmail.com", "Estelle", "Kemmer", "174b64975044ac784864a8917edd04b9dddee34b", "1-560-649-4584 x69987" },
                    { new Guid("fa748083-2efe-0c91-cead-91083d6bc187"), new DateTime(2018, 2, 19, 2, 30, 46, 914, DateTimeKind.Local).AddTicks(6472), "Ann.Kunze68@yahoo.com", "Ann", "Kunze", "4f5c9ffed9da0e7d6e3f223c50e63884f58191b6", "275-658-0277" },
                    { new Guid("fba260f4-1221-1adc-3f0c-59fbfd516aad"), new DateTime(2020, 2, 25, 15, 17, 2, 220, DateTimeKind.Local).AddTicks(5442), "Alejandro74@gmail.com", "Alejandro", "Price", "604f258a45dacb1a276ff675dcec01b63c26d8b2", "1-356-249-7643" },
                    { new Guid("fc0c298c-fe98-d672-b7e8-baf6c510d0cc"), new DateTime(2013, 1, 20, 22, 42, 37, 212, DateTimeKind.Local).AddTicks(1526), "Jessica.Heller@gmail.com", "Jessica", "Heller", "0f2662d2fdc4d97af50108ef48516183d828f053", "1-898-921-6036 x50220" },
                    { new Guid("fe773a64-4c63-faf5-925f-7f12383b1a70"), new DateTime(2012, 6, 9, 9, 28, 32, 345, DateTimeKind.Local).AddTicks(3397), "Lucas55@gmail.com", "Lucas", "Towne", "4b400b889d8ced4d42f8becaafa41a947da4e25a", "(280) 624-5600 x155" },
                    { new Guid("ffa97ff7-14e6-9009-05b1-432517ef0dac"), new DateTime(2017, 12, 2, 2, 52, 0, 792, DateTimeKind.Local).AddTicks(8626), "Simon60@yahoo.com", "Simon", "Boyer", "4bcb24df762e443ba259ddfe67aa3206e75d4005", "697-313-2959 x176" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CustomerId",
                table: "Address",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_ZipCodeID",
                table: "Address",
                column: "ZipCodeID");

            migrationBuilder.CreateIndex(
                name: "IX_Basket_BasketStatusCode",
                table: "Basket",
                column: "BasketStatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_Basket_CustomerId",
                table: "Basket",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketProduct_ProductId",
                table: "BasketProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_BillingAddressId",
                table: "Order",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_DeliveryAddressId",
                table: "Order",
                column: "DeliveryAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderStatusCode",
                table: "Order",
                column: "OrderStatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedProduct_OrderId",
                table: "OrderedProduct",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedProduct_ProductId",
                table: "OrderedProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandId",
                table: "Product",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_CategoryId",
                table: "ProductCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_ProductId",
                table: "ProductImage",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_CustomerId",
                table: "Review",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ProductId",
                table: "Review",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ZipCode_Code_Commune",
                table: "ZipCode",
                columns: new[] { "Code", "Commune" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketProduct");

            migrationBuilder.DropTable(
                name: "OrderedProduct");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "ProductImage");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Basket");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "BasketStatus");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "ZipCode");
        }
    }
}
