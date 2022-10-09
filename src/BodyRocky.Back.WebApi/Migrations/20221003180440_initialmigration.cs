﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BodyRocky.Back.WebApi.Migrations
{
    public partial class initialmigration : Migration
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
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false),
                    CategoryID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                    table.ForeignKey(
                        name: "FK_Category_Category_CategoryID1",
                        column: x => x.CategoryID1,
                        principalTable: "Category",
                        principalColumn: "CategoryID");
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
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZipCodeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Commune = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZipCode", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                        principalColumn: "BrandID",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Basket_Customer_BasketID",
                        column: x => x.BasketID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
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
                    ZipCodeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressID);
                    table.ForeignKey(
                        name: "FK_Address_Customer_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Address_ZipCode_ZipCodeID",
                        column: x => x.ZipCodeID,
                        principalTable: "ZipCode",
                        principalColumn: "Code",
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
                        name: "FK_ProductImage_Product_ProductImageID",
                        column: x => x.ProductImageID,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_Review_Customer_ReviewID",
                        column: x => x.ReviewID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Review_Product_ReviewID",
                        column: x => x.ReviewID,
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
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderStatusCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Order_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Customer_OrderID",
                        column: x => x.OrderID,
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
                    OrderedProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderedProduct", x => x.OrderedProductId);
                    table.ForeignKey(
                        name: "FK_OrderedProduct_Order_OrderedProductId",
                        column: x => x.OrderedProductId,
                        principalTable: "Order",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderedProduct_Product_OrderedProductId",
                        column: x => x.OrderedProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerID", "BirthDate", "EmailAddress", "FirstName", "LastName", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("025ac509-9494-ae4b-43c3-b8acd09630dd"), new DateTime(2017, 1, 22, 3, 19, 49, 258, DateTimeKind.Local).AddTicks(4142), "Mattie.Dicki40@hotmail.com", "Mattie", "Dicki", "47f13d5d0fe8e21b2b458d496b1320d1df4dc50e", "(223) 985-4184 x8577" },
                    { new Guid("0304c8f5-81d1-8602-1e24-af25677eaf96"), new DateTime(2010, 1, 14, 13, 43, 9, 238, DateTimeKind.Local).AddTicks(9057), "Linda_Hills@yahoo.com", "Linda", "Hills", "94fd7f1139d94bd18e75c0f94c4179afc8e3886c", "1-394-559-7718 x97325" },
                    { new Guid("03a17951-2816-caf5-eb57-e371f98a78d7"), new DateTime(2006, 4, 2, 1, 45, 35, 942, DateTimeKind.Local).AddTicks(4766), "Edmund_Friesen@hotmail.com", "Edmund", "Friesen", "7f85f9def84622527161411290ad8f52bbda428c", "961.850.1938 x938" },
                    { new Guid("05270fe3-9076-02a8-ef16-9439c5a7557b"), new DateTime(2013, 6, 27, 21, 2, 4, 947, DateTimeKind.Local).AddTicks(8034), "Jeannette_Kuhlman23@yahoo.com", "Jeannette", "Kuhlman", "0748da91146867b2ab8b377d0b950d260ade8597", "499.838.6011" },
                    { new Guid("05b09961-1ec2-a867-ebd2-b7c2cf57351d"), new DateTime(2006, 8, 8, 9, 17, 17, 238, DateTimeKind.Local).AddTicks(3762), "George_Friesen@hotmail.com", "George", "Friesen", "4c9e23a0031751c4ec95ff10a1a9a84d1481196b", "837-503-2440" },
                    { new Guid("0979660b-d063-9538-5d29-b95551016a55"), new DateTime(2014, 2, 26, 13, 5, 14, 947, DateTimeKind.Local).AddTicks(8559), "Darnell88@gmail.com", "Darnell", "Hermann", "fbccd1ff998e4e723a773628dbefdd43f5b82ccd", "(292) 580-5114" },
                    { new Guid("0a8d1208-660d-a66e-3e28-a21d32b00824"), new DateTime(2006, 10, 9, 15, 35, 13, 903, DateTimeKind.Local).AddTicks(2877), "Albert_Langworth47@hotmail.com", "Albert", "Langworth", "0bc478df87f6de514c85eb9b36ecd7026b170a00", "979-599-8903" },
                    { new Guid("0c4a1712-ba2f-95a7-56ed-1d994db5c9ad"), new DateTime(2009, 6, 12, 12, 28, 14, 141, DateTimeKind.Local).AddTicks(1971), "Jay.Sawayn@yahoo.com", "Jay", "Sawayn", "b45b3039fc1725e724af621b1c5bf4071cc6abc9", "472.243.6408 x9927" },
                    { new Guid("0dfcd6d6-2c81-8fb4-561d-7f1d66afedf0"), new DateTime(2012, 8, 9, 12, 59, 35, 941, DateTimeKind.Local).AddTicks(8180), "Jan_Cummings@gmail.com", "Jan", "Cummings", "787e1e985e9fceb90de11b241c21f8af3a94f5e2", "1-760-978-0214 x2569" },
                    { new Guid("11a7aefd-2e10-7b3e-f5af-e1a58d341404"), new DateTime(2015, 6, 6, 2, 46, 48, 500, DateTimeKind.Local).AddTicks(9142), "Rosie_Jaskolski79@yahoo.com", "Rosie", "Jaskolski", "55647a769a334032a35eb601f04831058ec10950", "(689) 884-6119" },
                    { new Guid("11aa9066-ef09-86f7-bcd4-fc3bf98cfd05"), new DateTime(2020, 12, 27, 18, 59, 49, 349, DateTimeKind.Local).AddTicks(2007), "Diane.Smith@gmail.com", "Diane", "Smith", "26b61f314aceeba597a4c3fc1147e398210b130c", "(748) 871-7676 x97791" },
                    { new Guid("12756bc8-5812-9d9a-7b83-c802b5f14eb5"), new DateTime(2011, 11, 24, 16, 22, 14, 722, DateTimeKind.Local).AddTicks(3520), "Dianna50@gmail.com", "Dianna", "Blanda", "916e43fc0492d76f6645ed3d561d367e5694913d", "645-854-6147" },
                    { new Guid("127b9c12-2d27-f11a-446e-459ed297ee77"), new DateTime(2017, 4, 13, 6, 48, 38, 796, DateTimeKind.Local).AddTicks(5046), "Juanita54@yahoo.com", "Juanita", "Lindgren", "240066130e00dd3d4a3b55dd34df55cbbcacf448", "1-789-416-3108 x76962" },
                    { new Guid("191696db-8348-9800-ba21-400f377864d7"), new DateTime(2020, 12, 12, 19, 30, 3, 94, DateTimeKind.Local).AddTicks(1359), "Yolanda88@hotmail.com", "Yolanda", "Tromp", "70058c4e31d94c1687fc64dbdf36b2640e385203", "254.810.2055" },
                    { new Guid("195d0198-fd1b-a242-b506-40667d3a9b01"), new DateTime(2007, 2, 10, 14, 51, 0, 452, DateTimeKind.Local).AddTicks(3539), "Hugh58@yahoo.com", "Hugh", "Mohr", "cfd75e8d43f531ce7c1e9dbb8064fde2dffee4e5", "1-604-898-1782" },
                    { new Guid("1eea7fc1-1c79-6ce3-ba6a-35908e24faad"), new DateTime(2005, 3, 26, 7, 9, 48, 303, DateTimeKind.Local).AddTicks(8152), "Enrique.Borer3@yahoo.com", "Enrique", "Borer", "c6b239a090d969f86db45641ad7031724a4e79ce", "(305) 705-9196 x171" },
                    { new Guid("21745374-4d5a-4556-f0f1-c5eba498e294"), new DateTime(2005, 1, 19, 15, 58, 44, 681, DateTimeKind.Local).AddTicks(469), "Lillian.Dooley93@gmail.com", "Lillian", "Dooley", "0c57976049c98edb65c4efa43566ea7a1d81b0d6", "672.317.0395 x560" },
                    { new Guid("26617b2d-f6b3-dc70-668b-7a0e117885a3"), new DateTime(2021, 7, 6, 17, 29, 12, 616, DateTimeKind.Local).AddTicks(5867), "Wilbert.Altenwerth54@hotmail.com", "Wilbert", "Altenwerth", "643dd78efd058570047ece93e2912cbd08cff47f", "318-433-3748 x73806" },
                    { new Guid("2828a8e3-e09b-6942-a3dd-c9bd506a569e"), new DateTime(2009, 3, 31, 18, 52, 52, 375, DateTimeKind.Local).AddTicks(272), "Terri.Krajcik14@hotmail.com", "Terri", "Krajcik", "d2717c9963ba30cc8af8ffc24206c68d10950c36", "1-929-745-9927 x44261" },
                    { new Guid("282cf57d-ac75-eaab-e7c4-96d38d264417"), new DateTime(2005, 6, 30, 13, 27, 0, 855, DateTimeKind.Local).AddTicks(6753), "Wade.Friesen@hotmail.com", "Wade", "Friesen", "42db9e44a12a926a347838834e2d5e068a66b42e", "(862) 366-4780" },
                    { new Guid("2b1d752f-104f-ddf1-4158-7d6b1ea851d6"), new DateTime(2012, 10, 31, 21, 52, 32, 783, DateTimeKind.Local).AddTicks(7571), "Marvin_Oberbrunner@hotmail.com", "Marvin", "Oberbrunner", "0d4f7a73c0f69f2be0ce4d6f1ba7f0390d0bd892", "1-932-844-7206 x981" },
                    { new Guid("2de4ab3c-1d64-395b-9b81-25ee2d14db52"), new DateTime(2010, 12, 20, 15, 29, 54, 909, DateTimeKind.Local).AddTicks(5699), "Pauline.Rodriguez@hotmail.com", "Pauline", "Rodriguez", "d5d035ebb3c05a23bebe008616f031a13bde9f90", "(380) 839-6227 x0580" },
                    { new Guid("34eebd9b-a418-8518-9415-2caa8cd0641c"), new DateTime(2022, 5, 14, 13, 39, 7, 353, DateTimeKind.Local).AddTicks(1235), "Gina_Koch@gmail.com", "Gina", "Koch", "21189e660e6b8a4b9f64a5d0c7b3286b7e16daf2", "517.595.3832" },
                    { new Guid("3a8a0c24-b2f6-04a6-e4b6-d132a1a3cce6"), new DateTime(2013, 3, 8, 18, 57, 43, 484, DateTimeKind.Local).AddTicks(6267), "Marie_Koepp@hotmail.com", "Marie", "Koepp", "3bc1941043bdf248f667dda6480c2a45fbc050f0", "(253) 273-9524 x92023" },
                    { new Guid("3e7bb9d4-a973-26df-c72d-456e21850d9b"), new DateTime(2009, 11, 25, 12, 25, 15, 189, DateTimeKind.Local).AddTicks(7859), "Geraldine.Stokes@hotmail.com", "Geraldine", "Stokes", "6a34248f0ff3b6e3fc67e804177fe7d5b03e8380", "1-874-265-3803 x58381" },
                    { new Guid("3fc90ec9-ef95-ef15-0fe1-8a1666d057df"), new DateTime(2011, 3, 4, 10, 33, 54, 757, DateTimeKind.Local).AddTicks(3725), "Della_McDermott@gmail.com", "Della", "McDermott", "096a2f6cccfc026b4e11687799e8d75f0f2a14c0", "(787) 852-7854 x11291" },
                    { new Guid("403abf25-4f93-2fb9-2b6b-86c65d619e5b"), new DateTime(2010, 10, 13, 11, 7, 25, 43, DateTimeKind.Local).AddTicks(7211), "Harry_Weissnat@gmail.com", "Harry", "Weissnat", "e5bd6f28df367efdf3cd0aad718b094e36fc3e4b", "952.693.4375 x25083" },
                    { new Guid("43d1631e-8758-7468-2e4d-0f6837ffd356"), new DateTime(2019, 3, 4, 8, 30, 31, 87, DateTimeKind.Local).AddTicks(3), "Rosemary_Champlin38@hotmail.com", "Rosemary", "Champlin", "fe34d2e978a76ce58f7306d7b4152c21174d7b79", "(431) 617-2080 x39453" },
                    { new Guid("4557eee8-1eaa-43c2-53a7-ff43ccf17010"), new DateTime(2017, 3, 23, 18, 37, 14, 645, DateTimeKind.Local).AddTicks(3898), "Derrick.Sanford@yahoo.com", "Derrick", "Sanford", "c5f03d2a36c73e83a7b19bc59edfa0257f202be6", "627-890-3101 x643" },
                    { new Guid("48917d11-d1b4-9b4a-540b-48404cab8485"), new DateTime(2013, 4, 12, 4, 16, 7, 529, DateTimeKind.Local).AddTicks(3070), "Louis59@yahoo.com", "Louis", "Breitenberg", "28bbbf348a3b7e0dc014a2ba02b3a6441332e1cd", "345.817.4901 x17149" },
                    { new Guid("496483c8-efe4-1475-59d0-f64a88bc3bd0"), new DateTime(2019, 9, 30, 16, 36, 5, 581, DateTimeKind.Local).AddTicks(2766), "Nadine56@hotmail.com", "Nadine", "Witting", "185e30d16dde5832d6a93c4f9e26f957d74d9e61", "808.246.8917" },
                    { new Guid("4a36c22c-2897-8f4d-a10c-bc2c340f62f1"), new DateTime(2007, 2, 11, 3, 48, 5, 842, DateTimeKind.Local).AddTicks(4878), "Natalie.Torp@yahoo.com", "Natalie", "Torp", "a7d272dbf66d6e16e17ef170fbd3ec8af6e26428", "1-682-586-6088 x800" },
                    { new Guid("4df0476a-913c-fa85-c169-691d56cc2284"), new DateTime(2010, 4, 27, 12, 34, 25, 821, DateTimeKind.Local).AddTicks(8974), "Mark_Becker@hotmail.com", "Mark", "Becker", "f715bf21784d3b06e061ac7bf3092cbfa24684c3", "544-519-8916" },
                    { new Guid("5040e735-f3c0-04b0-a625-c077549e0930"), new DateTime(2009, 7, 26, 12, 17, 14, 151, DateTimeKind.Local).AddTicks(5412), "Sam76@hotmail.com", "Sam", "Heaney", "76bf7652ec4461bc2623f327250613a9f2a41e53", "972.873.2793" },
                    { new Guid("50968c7d-d2ef-41ec-7a95-8228457d38bf"), new DateTime(2017, 11, 1, 21, 25, 53, 663, DateTimeKind.Local).AddTicks(4859), "Taylor.Schinner29@hotmail.com", "Taylor", "Schinner", "7dd2a5f9b3d5642557ed525e49486d52891b76c4", "1-875-393-1764 x5802" },
                    { new Guid("5392b897-664c-e728-b4ee-700e5965c3b2"), new DateTime(2011, 3, 27, 10, 45, 45, 371, DateTimeKind.Local).AddTicks(9580), "Heidi_Rohan96@gmail.com", "Heidi", "Rohan", "5c417181144256687a6f3397182be0ac848f4d93", "899-586-9814 x3972" },
                    { new Guid("5771c454-42c3-b84f-6246-152a36fda1c9"), new DateTime(2008, 12, 15, 14, 2, 0, 336, DateTimeKind.Local).AddTicks(403), "Gary_Bergstrom71@hotmail.com", "Gary", "Bergstrom", "c49d04c35c72aeff4f90878ac849694390569d5f", "(263) 344-8944" },
                    { new Guid("5b4e44b1-315b-36b4-05f2-389c2aff2a93"), new DateTime(2020, 1, 15, 6, 1, 18, 770, DateTimeKind.Local).AddTicks(5056), "Deborah.Kulas@gmail.com", "Deborah", "Kulas", "a948de5ddf2349b9909f00fd737c0159b75588a5", "(976) 796-4908 x9649" },
                    { new Guid("6049a376-3a35-841e-b645-e4f8b88342a3"), new DateTime(2007, 6, 26, 16, 33, 31, 29, DateTimeKind.Local).AddTicks(3162), "Wm25@yahoo.com", "Wm", "Roberts", "ee41defe268ca1c4816b8aca4854c0b69bf8d452", "352-632-3060 x780" },
                    { new Guid("62481078-e4f3-b2c2-5db1-3c4de8320886"), new DateTime(2017, 6, 11, 4, 22, 3, 97, DateTimeKind.Local).AddTicks(639), "Jacquelyn_Dickinson@hotmail.com", "Jacquelyn", "Dickinson", "eb98c8555c97c7874951d3a1de8a8bdad375c5be", "(483) 966-5073 x7742" },
                    { new Guid("62d60c84-ea78-d300-eec8-de672f6d8ffe"), new DateTime(2005, 3, 9, 11, 30, 46, 341, DateTimeKind.Local).AddTicks(6412), "Virginia43@hotmail.com", "Virginia", "Paucek", "712c77c56d6cb4337d95f4752fa4572d3f8a308d", "1-843-275-3536 x9043" },
                    { new Guid("6796a12b-909f-2679-0274-559d17e19e82"), new DateTime(2007, 5, 2, 8, 39, 31, 796, DateTimeKind.Local).AddTicks(2014), "Helen7@hotmail.com", "Helen", "Abbott", "786bded62e144e6f1fef01139c9d171f7fc491b6", "973-618-1160 x3125" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerID", "BirthDate", "EmailAddress", "FirstName", "LastName", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("6e30f396-3e91-5909-72cf-81c53aec0218"), new DateTime(2010, 1, 7, 1, 38, 7, 407, DateTimeKind.Local).AddTicks(3421), "Penny6@hotmail.com", "Penny", "Brakus", "0115495463eb52d241c3f7c76f3ff7804d5035b4", "1-244-861-4727" },
                    { new Guid("705df400-9b4b-935a-6333-fce13eab398c"), new DateTime(2020, 2, 22, 21, 22, 46, 917, DateTimeKind.Local).AddTicks(8153), "Ervin_Jones27@gmail.com", "Ervin", "Jones", "8822b5075dd4a5599f2ec6f0598ab3f223bac651", "(852) 662-9357 x235" },
                    { new Guid("719e77f8-ae99-177f-7e3a-da64abba99cb"), new DateTime(2019, 11, 19, 9, 8, 37, 714, DateTimeKind.Local).AddTicks(742), "Kurt78@hotmail.com", "Kurt", "Bergnaum", "fc55f3f62b7a8e3dd1a8cfb4ef8604af31431ec0", "1-993-903-7742" },
                    { new Guid("7319467b-42d1-4f0e-78f5-11c8529f538d"), new DateTime(2017, 5, 9, 14, 15, 22, 43, DateTimeKind.Local).AddTicks(3158), "Jane_Yundt43@gmail.com", "Jane", "Yundt", "f245349268efcb18f9097b14a90a3c2cc5f3a88d", "(562) 716-4471" },
                    { new Guid("769900ad-f03b-6384-c2dd-1f918407223c"), new DateTime(2011, 3, 30, 7, 16, 3, 311, DateTimeKind.Local).AddTicks(6632), "Natalie25@hotmail.com", "Natalie", "Hessel", "2244a19373725298b8dcdbd4c29596e557a3ee73", "406-734-8591" },
                    { new Guid("8165cccb-9512-679d-47dc-9f4a419f7622"), new DateTime(2017, 4, 30, 23, 48, 52, 808, DateTimeKind.Local).AddTicks(5320), "Janie_Becker99@gmail.com", "Janie", "Becker", "4159abb8c969c840704c43972eb95f20a1b417ea", "1-377-385-5868 x734" },
                    { new Guid("81a8960c-ba9e-9980-c8ce-31485ffe45fd"), new DateTime(2005, 3, 4, 8, 21, 30, 994, DateTimeKind.Local).AddTicks(1010), "Alvin87@yahoo.com", "Alvin", "McDermott", "935dc66c7633b25a82708fd5250d94139bc7619f", "958.891.8557 x3286" },
                    { new Guid("821d8871-dbdf-7ba7-e00d-2f629718c128"), new DateTime(2009, 7, 23, 4, 10, 7, 476, DateTimeKind.Local).AddTicks(3730), "Philip_Heller@hotmail.com", "Philip", "Heller", "aa2e8ab954bd583e47912d092c6c999f92922942", "470-722-1916 x1166" },
                    { new Guid("8258a7c3-0cf8-177d-3750-661bedbf674c"), new DateTime(2019, 2, 11, 12, 45, 18, 388, DateTimeKind.Local).AddTicks(1366), "Stephen.Langosh14@hotmail.com", "Stephen", "Langosh", "ed0072115910a1ce7b1296fccd9fd2c2cb39d570", "880-391-1013 x7817" },
                    { new Guid("8345eceb-1df3-77d2-15a8-5006e008b443"), new DateTime(2015, 9, 26, 14, 38, 38, 394, DateTimeKind.Local).AddTicks(8445), "Lucia32@hotmail.com", "Lucia", "Abbott", "ce28ecea9d644abdc742a0318701bc8de5a4545a", "(383) 764-8191" },
                    { new Guid("83aee390-fd87-ee45-b1fb-be5a84b841be"), new DateTime(2014, 12, 28, 19, 11, 17, 120, DateTimeKind.Local).AddTicks(1143), "Cecelia29@yahoo.com", "Cecelia", "Baumbach", "e4475bb5d6410f12e95f0e412068dd600c2fd084", "850.550.8577" },
                    { new Guid("8a35a685-2d9d-987c-ac65-1159cf0a38d0"), new DateTime(2012, 10, 21, 15, 0, 18, 115, DateTimeKind.Local).AddTicks(572), "Marian11@hotmail.com", "Marian", "Nienow", "eb601ddaa23740865e868f0199b3a876592f83c7", "767-598-9423 x80576" },
                    { new Guid("951d67c9-cb3c-26a5-6649-2eec17dedc16"), new DateTime(2019, 11, 15, 23, 2, 23, 35, DateTimeKind.Local).AddTicks(4894), "Alvin.Champlin@gmail.com", "Alvin", "Champlin", "e87b392133136c6b449a06f5e37b2cbb32a75aa7", "(832) 489-6451" },
                    { new Guid("95d413cc-ad95-eb02-35cb-443a9d3ee243"), new DateTime(2021, 1, 3, 21, 11, 9, 966, DateTimeKind.Local).AddTicks(1087), "Albert37@hotmail.com", "Albert", "Rogahn", "d41d90f3acc420c5130c790ed8ac7df2bb26f77c", "784-640-7127 x9501" },
                    { new Guid("a2587872-5dbf-4b66-995d-d05434450065"), new DateTime(2009, 11, 9, 13, 56, 17, 134, DateTimeKind.Local).AddTicks(5375), "Jeffery_Pollich20@gmail.com", "Jeffery", "Pollich", "9ee1819613e3d375abefdb180bd511c1ed802181", "773-688-3282" },
                    { new Guid("ab71e720-379c-b096-9127-8bf3b9aac4ef"), new DateTime(2012, 1, 20, 11, 42, 48, 203, DateTimeKind.Local).AddTicks(6606), "Lindsay.Hagenes43@yahoo.com", "Lindsay", "Hagenes", "3d050900661e143a553a8745cc2476d0a584645c", "1-671-698-2347 x783" },
                    { new Guid("abb8b5ae-4317-0984-0d4d-89a34e402a2b"), new DateTime(2005, 4, 15, 10, 28, 10, 876, DateTimeKind.Local).AddTicks(8436), "Kimberly.Cormier@hotmail.com", "Kimberly", "Cormier", "08a980e05d0b31ecc4cbf140792b3df77b786ee1", "(273) 282-4223" },
                    { new Guid("ac39a75d-ea57-98fd-7144-9c27abb32977"), new DateTime(2016, 8, 22, 10, 22, 58, 516, DateTimeKind.Local).AddTicks(8925), "Peggy.Lindgren57@yahoo.com", "Peggy", "Lindgren", "cf2347b09d9024ba32bd7ad1842dd5b3e894c30b", "1-633-928-7932 x247" },
                    { new Guid("aca610be-5bee-7787-34ae-90acd7207738"), new DateTime(2015, 7, 19, 18, 21, 6, 267, DateTimeKind.Local).AddTicks(7416), "Evan.Jenkins@gmail.com", "Evan", "Jenkins", "4848f42b5b0fcad6cd7dbff577922ca3bb94b26a", "362.690.8482 x1157" },
                    { new Guid("b1182b58-28fe-dc67-dce7-615faa872b50"), new DateTime(2021, 8, 1, 8, 9, 53, 930, DateTimeKind.Local).AddTicks(3924), "Bryant27@hotmail.com", "Bryant", "Kovacek", "751a015a43fe3aabfe276c4d2c561d387e3cccbe", "268-900-8654 x42396" },
                    { new Guid("b2779556-92f4-4cef-7a42-3514f4e88b65"), new DateTime(2021, 2, 28, 18, 57, 8, 578, DateTimeKind.Local).AddTicks(8395), "Bethany.Ankunding@yahoo.com", "Bethany", "Ankunding", "8a7d0a74a9f9341a2bb5247c3b0d2f25cdddf1ce", "1-732-583-9392 x46938" },
                    { new Guid("b289d761-3b55-844a-e2e3-ccf25267e22e"), new DateTime(2012, 1, 26, 22, 27, 15, 898, DateTimeKind.Local).AddTicks(58), "Jessica_Padberg@gmail.com", "Jessica", "Padberg", "af6c22314e34ae1c063de03f671208e2e4e2bd0a", "1-877-283-2296 x17981" },
                    { new Guid("b295ea13-7ae5-4d22-bbd7-fb06e6f668fd"), new DateTime(2020, 1, 3, 1, 42, 30, 914, DateTimeKind.Local).AddTicks(6049), "Maryann.Kris59@gmail.com", "Maryann", "Kris", "dbcc89db1c7f1d9e6c40fe0c9fbeb6d4c9e93e28", "738.310.1115" },
                    { new Guid("b2f8e256-5edc-d640-5e49-406631adfdb2"), new DateTime(2016, 7, 18, 8, 26, 13, 861, DateTimeKind.Local).AddTicks(8121), "Sherri_Champlin@yahoo.com", "Sherri", "Champlin", "9487919dbbb5ba2a0db04314aa4ff4e0ea6bb905", "1-874-560-7897" },
                    { new Guid("b5b8f8dd-2529-7e65-8db9-9b462658c0a1"), new DateTime(2005, 4, 14, 11, 42, 47, 802, DateTimeKind.Local).AddTicks(2511), "Elaine_Tremblay49@gmail.com", "Elaine", "Tremblay", "cfdd5c7720763f98ab7b129ad92eaf3b3b172f8e", "(423) 612-8234" },
                    { new Guid("b5d47703-7cf6-73fa-9b2e-85a01744f237"), new DateTime(2011, 11, 3, 15, 1, 5, 898, DateTimeKind.Local).AddTicks(3296), "Micheal_Beatty92@gmail.com", "Micheal", "Beatty", "3b60291bb64df59c05a8fcdc9a7203ac5706c115", "366.299.9592 x490" },
                    { new Guid("baa2847c-12eb-2e03-63a2-42e05d41300c"), new DateTime(2005, 10, 20, 8, 23, 43, 178, DateTimeKind.Local).AddTicks(7722), "Brandy.Reichert@yahoo.com", "Brandy", "Reichert", "52a2056a90868024544b98dbbc852ad3f23bcca8", "692-381-4219" },
                    { new Guid("bab19244-a7ed-3754-2496-401c25150999"), new DateTime(2017, 6, 18, 12, 28, 38, 49, DateTimeKind.Local).AddTicks(7726), "Ann_Veum@hotmail.com", "Ann", "Veum", "83c657851980f8c7f0eba0202095ec1757279ce0", "873.504.4550 x075" },
                    { new Guid("bb66de56-ff5a-7121-b605-9776f6907114"), new DateTime(2020, 10, 11, 18, 58, 25, 229, DateTimeKind.Local).AddTicks(6996), "Cary.West@gmail.com", "Cary", "West", "9367f49b32a7ac5a86ebfb20f49a959c1c33325f", "1-215-629-7597 x031" },
                    { new Guid("bcc431ff-467a-ffa8-ddaa-fdd7eb6b23f4"), new DateTime(2019, 9, 17, 10, 8, 47, 684, DateTimeKind.Local).AddTicks(7737), "Karen51@hotmail.com", "Karen", "Reichert", "bff232546abc7d76018d822ea9f353869691442d", "(259) 364-3672 x92530" },
                    { new Guid("bf85ea0d-9c1e-15db-6acc-8a4f51f48df4"), new DateTime(2013, 3, 31, 11, 6, 29, 867, DateTimeKind.Local).AddTicks(9493), "Victor.Gutkowski@gmail.com", "Victor", "Gutkowski", "ba360e6ed7e87998e06c2b16fec359f2714fcb92", "(706) 947-5775 x5210" },
                    { new Guid("c0f929d1-9699-a974-bed6-6f1654691f7a"), new DateTime(2011, 5, 3, 14, 49, 31, 118, DateTimeKind.Local).AddTicks(3582), "Sonya66@hotmail.com", "Sonya", "Herman", "99a0b88b4500853ceb2b7f533c69d82b03e8445a", "778-563-5374" },
                    { new Guid("c14c546a-186f-1a5e-cc35-593ed4acaf36"), new DateTime(2019, 9, 4, 17, 1, 7, 202, DateTimeKind.Local).AddTicks(9684), "Olive.Gutkowski99@yahoo.com", "Olive", "Gutkowski", "755ec3b74723b1a6c67df0050eb084a178690131", "918-407-7990 x1170" },
                    { new Guid("c5457092-c7b4-2b0f-1461-571d97a2be2c"), new DateTime(2008, 6, 28, 13, 8, 0, 375, DateTimeKind.Local).AddTicks(7290), "Lucas_Schamberger@hotmail.com", "Lucas", "Schamberger", "34b32985958d6159ea83cfe3a1bc9b13d1c8fa05", "257.378.3454" },
                    { new Guid("c9b8e881-0cc8-d468-e9e3-512ca9104cec"), new DateTime(2021, 8, 5, 23, 52, 19, 613, DateTimeKind.Local).AddTicks(8693), "Dominick_Quitzon15@yahoo.com", "Dominick", "Quitzon", "6f06bb1022a5e636c03d8608752783746b6bf3c9", "636-692-2193" },
                    { new Guid("cb061464-f7ed-50bf-cd74-558269758589"), new DateTime(2009, 1, 10, 0, 55, 22, 430, DateTimeKind.Local).AddTicks(4073), "Gladys68@yahoo.com", "Gladys", "Cummerata", "93da870730c7f42f933f6475d5ec6b47cbeb23fa", "1-403-941-4179" },
                    { new Guid("cb64c943-8965-b97f-ed76-06d0ad94e001"), new DateTime(2008, 11, 29, 22, 32, 6, 970, DateTimeKind.Local).AddTicks(7111), "Dennis22@yahoo.com", "Dennis", "Donnelly", "71d05498c9e990e3f977dc7a2645c737a7b60f40", "1-360-385-1385 x4330" },
                    { new Guid("cc42a47e-c963-ce42-8adf-a3daf76f2771"), new DateTime(2008, 8, 9, 17, 21, 2, 304, DateTimeKind.Local).AddTicks(953), "Dewey21@yahoo.com", "Dewey", "Bernier", "049a7212b86d693b5e163967735972907ee454fa", "915-245-0165" },
                    { new Guid("cf66575a-3148-8f84-9822-e66859be4a3c"), new DateTime(2006, 6, 1, 11, 38, 44, 845, DateTimeKind.Local).AddTicks(4891), "Karl.Lesch39@hotmail.com", "Karl", "Lesch", "11fe739746e03c7580df8d6455968b2a9beb1e7f", "484.705.7192" },
                    { new Guid("d3db5d6a-e37c-b017-0f38-87e8e794376a"), new DateTime(2012, 12, 15, 0, 59, 14, 186, DateTimeKind.Local).AddTicks(7329), "Claire0@gmail.com", "Claire", "Huel", "d1931b382dc204d6173cb13d4d01ad44c7650024", "218-968-0792" },
                    { new Guid("d6feb393-5416-70f4-4542-ecf4ab2c397e"), new DateTime(2013, 6, 3, 0, 5, 37, 226, DateTimeKind.Local).AddTicks(691), "Alfred_Jast90@hotmail.com", "Alfred", "Jast", "e1773ac489982333a0caf2a02ef8b2d5831e01a5", "1-520-281-3096 x9605" },
                    { new Guid("d9f141e8-fdd8-e92c-b97c-b6c07d47009b"), new DateTime(2006, 8, 19, 16, 57, 39, 473, DateTimeKind.Local).AddTicks(2838), "Emilio_Dietrich12@gmail.com", "Emilio", "Dietrich", "09887ec38528e9029e1ab16324b1cc6d6028048a", "931.722.5414" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerID", "BirthDate", "EmailAddress", "FirstName", "LastName", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("dd9d000b-9d82-34a4-3cda-294a7cae3ae5"), new DateTime(2021, 8, 6, 14, 23, 30, 612, DateTimeKind.Local).AddTicks(2803), "Raul.Gorczany@gmail.com", "Raul", "Gorczany", "1b9c11433f67d27be28a68672aee95481ac404b9", "609-715-8997 x62411" },
                    { new Guid("e13bbc22-f9b8-7cec-639b-a5035479cb71"), new DateTime(2021, 7, 27, 16, 33, 23, 817, DateTimeKind.Local).AddTicks(9974), "Mae_Roob74@yahoo.com", "Mae", "Roob", "429c87cb1a6100a6b8b9a6304d70743056fcf6b7", "(617) 869-0930" },
                    { new Guid("e16286e0-bf45-e0d0-3024-882931918452"), new DateTime(2012, 11, 24, 9, 22, 2, 273, DateTimeKind.Local).AddTicks(6827), "Elizabeth_Brakus2@hotmail.com", "Elizabeth", "Brakus", "41aa487452ea83420b36cf3472f307d53c2a4284", "863.232.9149" },
                    { new Guid("e51d70b6-69ba-bbfe-0863-3559d359da78"), new DateTime(2013, 10, 3, 10, 47, 17, 432, DateTimeKind.Local).AddTicks(8571), "Victoria.Considine@hotmail.com", "Victoria", "Considine", "1704f7d46eded5e97358373b2d33cdb6e0b57102", "1-878-803-5496" },
                    { new Guid("e5c7184d-8927-ab72-a12f-4c0f086c1725"), new DateTime(2018, 11, 7, 10, 33, 49, 814, DateTimeKind.Local).AddTicks(1547), "Frankie88@yahoo.com", "Frankie", "Bogisich", "7d6741450d4b429631bfe86dbfea47ac2cad1a3e", "323-635-0537 x2411" },
                    { new Guid("e7a3d810-910c-905f-ef03-f51e7d0184c3"), new DateTime(2021, 5, 4, 9, 40, 29, 44, DateTimeKind.Local).AddTicks(2112), "Janis60@yahoo.com", "Janis", "Turcotte", "1721ab29d673f58f4d56fcbc6cc53e8ae7a43ea3", "242.384.2540 x339" },
                    { new Guid("ed344573-7ccd-8ca0-b7cd-c0fce5b16d1a"), new DateTime(2009, 12, 22, 9, 36, 9, 886, DateTimeKind.Local).AddTicks(3433), "Jesus_Langworth@gmail.com", "Jesus", "Langworth", "a0efe882e29ecddad1616b8e1f274b57deb13f3e", "1-574-201-8726 x3505" },
                    { new Guid("ef52e961-ff85-f1e2-f700-3daefefa6784"), new DateTime(2006, 7, 10, 8, 24, 33, 401, DateTimeKind.Local).AddTicks(6475), "Roderick51@hotmail.com", "Roderick", "Marks", "48a3fbc953c8c8de1d753e85ab2dd142c56a6c37", "395-286-3996 x40160" },
                    { new Guid("f1bbb77b-7e8e-4c39-3a2e-5c260ec98c00"), new DateTime(2016, 6, 12, 7, 46, 38, 337, DateTimeKind.Local).AddTicks(7012), "Anne_Shanahan@yahoo.com", "Anne", "Shanahan", "bd94ec026b4b882f62d65514a9fc229b4026de4f", "1-714-940-5043" },
                    { new Guid("f1f0533f-bff1-b376-ad05-9e424402a0a0"), new DateTime(2016, 11, 29, 22, 46, 27, 141, DateTimeKind.Local).AddTicks(8983), "Kendra.Wyman@gmail.com", "Kendra", "Wyman", "64f3cdbbc18eca3f02b3f27610ac90fd95c019bc", "594.916.6062 x9365" },
                    { new Guid("f5b9c61e-e15e-56a1-e788-d342008ece9a"), new DateTime(2010, 11, 19, 15, 27, 37, 758, DateTimeKind.Local).AddTicks(3596), "Shelia59@yahoo.com", "Shelia", "Heller", "a134df7b6f96107d1a5f0e06d57d137076c37202", "343.621.4647 x699" },
                    { new Guid("f6878302-3d3e-1df2-0d4e-df08ec040414"), new DateTime(2004, 12, 13, 22, 52, 43, 139, DateTimeKind.Local).AddTicks(2326), "Donna_Bartoletti@yahoo.com", "Donna", "Bartoletti", "92b7c65ad8de467ca61aa1f2f74285fc0b5136bc", "(928) 833-2059 x0107" },
                    { new Guid("f8b4df1b-3789-b21b-9c85-95f919a4ac95"), new DateTime(2016, 8, 11, 18, 9, 26, 523, DateTimeKind.Local).AddTicks(9696), "Whitney13@hotmail.com", "Whitney", "Kassulke", "16e33c02099672a3ae8ee4b63894efaee7d25969", "(625) 795-8541 x198" },
                    { new Guid("fb2954de-c18e-39b3-1838-840621971978"), new DateTime(2006, 11, 20, 12, 18, 1, 7, DateTimeKind.Local).AddTicks(3730), "Miriam_Auer81@yahoo.com", "Miriam", "Auer", "2c937236d4bc8ccba03b828b1ad3049cd2de6a68", "552.936.1067 x53007" },
                    { new Guid("fd14a802-33a2-0988-b689-4695b76ffc52"), new DateTime(2004, 10, 29, 5, 8, 42, 271, DateTimeKind.Local).AddTicks(6370), "Florence_Wilderman16@gmail.com", "Florence", "Wilderman", "85118039380642ad72038e26fa3e7507ec84c14a", "1-213-543-4264" },
                    { new Guid("ff4f338e-addb-6919-08fb-2d8cde070c34"), new DateTime(2008, 4, 21, 16, 31, 50, 436, DateTimeKind.Local).AddTicks(3088), "Martin_Cronin@hotmail.com", "Martin", "Cronin", "87cb5f814c6cefb9c13d963ed7477fbf6745a5b0", "764.357.3348 x60231" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_ZipCodeID",
                table: "Address",
                column: "ZipCodeID");

            migrationBuilder.CreateIndex(
                name: "IX_Basket_BasketStatusCode",
                table: "Basket",
                column: "BasketStatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_BasketProduct_ProductId",
                table: "BasketProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_CategoryID1",
                table: "Category",
                column: "CategoryID1");

            migrationBuilder.CreateIndex(
                name: "IX_Order_AddressId",
                table: "Order",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderStatusCode",
                table: "Order",
                column: "OrderStatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandId",
                table: "Product",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_CategoryId",
                table: "ProductCategory",
                column: "CategoryId");
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
