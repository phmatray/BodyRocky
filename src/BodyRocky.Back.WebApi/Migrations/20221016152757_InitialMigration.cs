﻿using System;
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
                    CategoryImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryIcon = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ProductURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false),
                    BrandID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Product_Brand_BrandID",
                        column: x => x.BrandID,
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
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                        name: "FK_Basket_Customer_CustomerID",
                        column: x => x.CustomerID,
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
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ZipCodeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressID);
                    table.ForeignKey(
                        name: "FK_Address_Customer_CustomerID",
                        column: x => x.CustomerID,
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
                name: "ProductCategories",
                columns: table => new
                {
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductID, x.CategoryID });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImage",
                columns: table => new
                {
                    ProductImageID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.ProductImageID);
                    table.ForeignKey(
                        name: "FK_ProductImage_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID");
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReviewRating = table.Column<int>(type: "int", nullable: false),
                    ReviewText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewID);
                    table.ForeignKey(
                        name: "FK_Review_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Review_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasketProducts",
                columns: table => new
                {
                    BasketID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketProducts", x => new { x.BasketID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_BasketProducts_Basket_BasketID",
                        column: x => x.BasketID,
                        principalTable: "Basket",
                        principalColumn: "BasketID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketProducts_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
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
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BillingAddressID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveryAddressID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderStatusCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Order_Address_BillingAddressID",
                        column: x => x.BillingAddressID,
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Address_DeliveryAddressID",
                        column: x => x.DeliveryAddressID,
                        principalTable: "Address",
                        principalColumn: "AddressID");
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerID",
                        column: x => x.CustomerID,
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
                    OrderedProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderedProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderedProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderedProductPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderedProduct", x => x.OrderedProductID);
                    table.ForeignKey(
                        name: "FK_OrderedProduct_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderedProduct_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "BrandID", "BrandLogo", "BrandName" },
                values: new object[,]
                {
                    { new Guid("0136a8be-afc5-e0cc-f28b-6c79d99c9320"), "https://picsum.photos/640/480/?image=338", "Rutherford - Hirthe" },
                    { new Guid("0506fb2f-86b6-b93c-348f-d4f2697be09a"), "https://picsum.photos/640/480/?image=365", "Crooks Inc" },
                    { new Guid("0680f4bc-ea50-98f6-7504-6a63414cdf42"), "https://picsum.photos/640/480/?image=496", "Bogan, Hammes and Gorczany" },
                    { new Guid("0bd7df94-02a8-b034-5c45-1dfb54b1f529"), "https://picsum.photos/640/480/?image=618", "Aufderhar, Johnson and Conn" },
                    { new Guid("0bf3561a-9991-29d4-ce39-8263dd0de6f4"), "https://picsum.photos/640/480/?image=202", "Denesik - Schulist" },
                    { new Guid("0ff7bd5d-7afb-72a0-d8aa-f62c8441cdf7"), "https://picsum.photos/640/480/?image=45", "Mueller - Prosacco" },
                    { new Guid("102c15a0-6464-7616-6d88-01236ecd42b5"), "https://picsum.photos/640/480/?image=119", "Hessel LLC" },
                    { new Guid("33734837-1227-5085-ded5-1b373c300fe9"), "https://picsum.photos/640/480/?image=533", "Ortiz, Corwin and Halvorson" },
                    { new Guid("3bc6573e-7be9-adf6-82f4-32bcb4b0f1b2"), "https://picsum.photos/640/480/?image=504", "Lind, Bernier and Muller" },
                    { new Guid("3bf480d3-cb4e-a040-56e8-a8186acdfd9b"), "https://picsum.photos/640/480/?image=706", "Gleichner, Sipes and Reynolds" },
                    { new Guid("3d77c624-9356-3068-8f30-0bb85651729c"), "https://picsum.photos/640/480/?image=831", "Lang - Halvorson" },
                    { new Guid("41c09f22-e462-eec2-b236-046951f599dd"), "https://picsum.photos/640/480/?image=847", "Monahan Inc" },
                    { new Guid("4700fa3f-5a0e-779f-9a1d-3561e7579c43"), "https://picsum.photos/640/480/?image=313", "Beier, Ruecker and Weimann" },
                    { new Guid("490c6622-bbea-0234-2100-e37d6a9bb082"), "https://picsum.photos/640/480/?image=32", "Robel Group" },
                    { new Guid("4c9ea98f-1208-8361-8f5f-ccf4b179ff89"), "https://picsum.photos/640/480/?image=385", "Schmidt - Feil" },
                    { new Guid("4d70da6f-141a-62ce-cc33-9a5596935366"), "https://picsum.photos/640/480/?image=707", "Bergstrom and Sons" },
                    { new Guid("5b1fd012-2199-dab9-e58b-92bd68d0fa17"), "https://picsum.photos/640/480/?image=383", "Bauch Group" },
                    { new Guid("68fbb9a4-cd27-aa9f-7ae6-4281bda59a71"), "https://picsum.photos/640/480/?image=932", "Batz, Reinger and Cummerata" },
                    { new Guid("7834298a-c5eb-188f-c4b8-7b2e59525a8c"), "https://picsum.photos/640/480/?image=764", "Hamill - Murphy" },
                    { new Guid("7c04d23b-019f-8a60-3710-6edd8e2bd064"), "https://picsum.photos/640/480/?image=538", "Cartwright - O'Keefe" },
                    { new Guid("801abe43-31c6-11d5-ac49-5c10586c790b"), "https://picsum.photos/640/480/?image=864", "Shanahan - Bogan" },
                    { new Guid("89acfb10-c061-8721-53b1-d060c8aa0ce0"), "https://picsum.photos/640/480/?image=475", "Romaguera - Renner" },
                    { new Guid("8d3443d6-7c48-9e89-a8bb-e145421d90c2"), "https://picsum.photos/640/480/?image=443", "Carroll, Hauck and Waelchi" },
                    { new Guid("93a16dfd-ab85-04b9-fd40-0ecea27f8448"), "https://picsum.photos/640/480/?image=451", "Mayer, Larson and Collins" },
                    { new Guid("959badbe-7bad-57b5-cd3c-f92f276eebd5"), "https://picsum.photos/640/480/?image=731", "Kling, Turner and Stroman" },
                    { new Guid("963e205d-c089-03f5-23c8-ab1b097901d5"), "https://picsum.photos/640/480/?image=701", "Rosenbaum, Wilkinson and Wehner" },
                    { new Guid("9cb19bf8-afde-ddc7-db50-e2ad897154d2"), "https://picsum.photos/640/480/?image=394", "Ryan - Okuneva" },
                    { new Guid("9dee3a3f-f243-4328-71f1-e8ffc3e39632"), "https://picsum.photos/640/480/?image=936", "Fritsch Inc" },
                    { new Guid("9ff33aaf-690f-bbc1-2c6f-ce2c728d04a5"), "https://picsum.photos/640/480/?image=932", "Howe Group" },
                    { new Guid("b2c36398-f822-2f8c-9e02-bd1e16f7c55a"), "https://picsum.photos/640/480/?image=433", "Bauch Inc" },
                    { new Guid("bb2b43b4-bdc4-6ac7-c2ee-9c850c9c4d75"), "https://picsum.photos/640/480/?image=248", "Schroeder, Crona and Auer" },
                    { new Guid("c2bba114-d677-a87e-9248-5a20bead30a8"), "https://picsum.photos/640/480/?image=762", "Cassin, Kilback and Feil" },
                    { new Guid("c75e8db1-a293-6c21-daa0-4d8d3f9bc259"), "https://picsum.photos/640/480/?image=742", "Cremin, Klocko and Wintheiser" },
                    { new Guid("c7b3305f-9bdb-472c-95c4-51184dd2aa8d"), "https://picsum.photos/640/480/?image=474", "Lang, Shanahan and Mraz" },
                    { new Guid("cbae5d6d-972f-22f0-58bf-b9d0ee21d8ed"), "https://picsum.photos/640/480/?image=955", "Sporer, Hamill and Armstrong" },
                    { new Guid("cc4236f3-8909-7940-c61f-66e5915e05ad"), "https://picsum.photos/640/480/?image=700", "Willms and Sons" },
                    { new Guid("cec3aa34-f966-56f0-4664-0aaf516dc3be"), "https://picsum.photos/640/480/?image=927", "Weissnat - Hettinger" },
                    { new Guid("cec876ad-01dd-e278-c9a2-a9307cb760db"), "https://picsum.photos/640/480/?image=428", "Von, Hintz and Treutel" },
                    { new Guid("e39c64d3-fd29-e24f-16a6-8e0134a19954"), "https://picsum.photos/640/480/?image=301", "Gleichner Group" },
                    { new Guid("e3e45b65-eda4-a53a-66d0-9b1f8ed98efc"), "https://picsum.photos/640/480/?image=1068", "Weissnat, West and Hills" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "CategoryIcon", "CategoryImage", "CategoryName", "IsFeatured" },
                values: new object[,]
                {
                    { new Guid("09683532-3346-4f2e-8998-414895ee2810"), "fas fa-utensils", "https://picsum.photos/200/300", "Nutrition", true },
                    { new Guid("50b89a6e-e798-4ddd-a719-d953c1d49b9c"), "fas fa-heart", "https://picsum.photos/200/300", "Yoga et bien-être", true }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "CategoryIcon", "CategoryImage", "CategoryName", "IsFeatured" },
                values: new object[,]
                {
                    { new Guid("54efda68-a4bf-44b1-81a2-e2cee41b52c2"), "fas fa-gamepad", "https://picsum.photos/200/300", "Jeux et loisirs", true },
                    { new Guid("593e1831-d5d6-4b19-9c24-996006b5f22f"), "fas fa-running", "https://picsum.photos/200/300", "Fitness", true },
                    { new Guid("7e3a05a1-85d8-4480-bdd7-7e093e9b1014"), "fas fa-heartbeat", "https://picsum.photos/200/300", "Cardio-training", true },
                    { new Guid("cf0c2839-aa0d-4b2e-8c89-8c4a635f8a65"), "fas fa-dumbbell", "https://picsum.photos/200/300", "Musculation", true }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerID", "BirthDate", "EmailAddress", "FirstName", "LastName", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("09a1ceff-6067-cfcc-eeee-51e27ad836cf"), new DateTime(2018, 7, 8, 11, 29, 13, 258, DateTimeKind.Local).AddTicks(9444), "Laurence40@yahoo.com", "Laurence", "Orn", "6bb86560998d073a1b9ba1d5b931af91266d6ddd", "(236) 432-2476 x6727" },
                    { new Guid("09cf3630-e958-88ab-34f5-562947070a64"), new DateTime(2011, 4, 4, 1, 51, 32, 476, DateTimeKind.Local).AddTicks(4735), "Miranda_Kautzer@yahoo.com", "Miranda", "Kautzer", "61e9b6a8243268b0a562447f3add7326a534cdab", "773.504.2410 x607" },
                    { new Guid("0a135eb3-695a-2cd4-c170-213222bcdd0e"), new DateTime(2016, 8, 28, 15, 48, 55, 595, DateTimeKind.Local).AddTicks(4978), "Santos.Mosciski@yahoo.com", "Santos", "Mosciski", "8a399cd1fd098f0a8c0228ba23c7d86461fdfb41", "749-945-8869" },
                    { new Guid("0e006fa9-de45-528c-0bae-9dd6207620e7"), new DateTime(2008, 2, 5, 13, 29, 47, 703, DateTimeKind.Local).AddTicks(9108), "Joyce.Breitenberg@yahoo.com", "Joyce", "Breitenberg", "c9ec82fae34791da1559cdb081ddb3797e0ce2e5", "318-923-3924" },
                    { new Guid("0efd67fc-9c2a-914b-66c4-f73f17803c80"), new DateTime(2005, 9, 28, 8, 11, 46, 660, DateTimeKind.Local).AddTicks(155), "Kim.Ruecker83@hotmail.com", "Kim", "Ruecker", "c04c18d317124d158a699d63a058af9378dd65b2", "(316) 420-1209 x9740" },
                    { new Guid("16b4c4a0-2f35-237d-681b-bd453093a236"), new DateTime(2005, 6, 14, 7, 3, 44, 81, DateTimeKind.Local).AddTicks(1043), "Harold.Bogan@gmail.com", "Harold", "Bogan", "2aa937f9a85d813e69f69c15af86c16802d692cb", "(613) 923-3761 x211" },
                    { new Guid("17577a5e-f5e7-ef5f-e697-f2ace5c8e0c2"), new DateTime(2010, 2, 20, 15, 43, 25, 498, DateTimeKind.Local).AddTicks(6758), "Archie.Hahn@gmail.com", "Archie", "Hahn", "957157e78391aaa4af9916108bbfcbd03b6c7ea0", "813-979-0238 x51606" },
                    { new Guid("23390a56-c1d1-1d60-1c75-2fa24374999a"), new DateTime(2013, 10, 1, 2, 10, 58, 2, DateTimeKind.Local).AddTicks(3040), "Annie_Feil@hotmail.com", "Annie", "Feil", "64299fd04c627ec243ade12519e1f9a9ffd1ddb5", "1-715-969-4911 x17592" },
                    { new Guid("241fdd79-d370-d294-5ba2-4214bf51b015"), new DateTime(2006, 3, 25, 18, 9, 14, 303, DateTimeKind.Local).AddTicks(9288), "Clay_Abshire@yahoo.com", "Clay", "Abshire", "c1130528318f54711024ffa98df995bf925e5304", "663.744.5518" },
                    { new Guid("24a86f6c-5977-f46f-67dd-dddba5a9a732"), new DateTime(2010, 9, 10, 22, 7, 0, 499, DateTimeKind.Local).AddTicks(7286), "Glenda.Miller55@hotmail.com", "Glenda", "Miller", "c2f97b613f85667f540a1ab347f59196eb9912e5", "501-919-5456 x91797" },
                    { new Guid("370d7448-f7f8-fe75-2c48-ac7cd88f0347"), new DateTime(2016, 12, 28, 7, 17, 59, 275, DateTimeKind.Local).AddTicks(3724), "Olive97@hotmail.com", "Olive", "Hickle", "a382513e123e640970820b27036340be38d694c4", "1-576-378-1925" },
                    { new Guid("3c5d782e-c346-d1a4-ea87-956078911a78"), new DateTime(2011, 3, 22, 1, 21, 19, 684, DateTimeKind.Local).AddTicks(656), "Becky42@yahoo.com", "Becky", "Jenkins", "10604579c6d7de9cf245bf6248b3c11ff1ea1dc1", "375-796-3358" },
                    { new Guid("4c3865c2-4fa0-2030-ee84-adc09a2380c0"), new DateTime(2009, 10, 20, 15, 7, 35, 782, DateTimeKind.Local).AddTicks(8805), "Monica_Toy9@yahoo.com", "Monica", "Toy", "eff466ec72b71f1089bb20eb4a759cc6edeafcf7", "472.363.9783 x0777" },
                    { new Guid("4ff0a3f7-1b7e-b61c-4dc4-04965e1306c6"), new DateTime(2013, 6, 12, 12, 1, 11, 799, DateTimeKind.Local).AddTicks(9522), "Lloyd_Murphy@yahoo.com", "Lloyd", "Murphy", "0ce1e8101f9d3178d882f7060b08148a061b39dc", "400-844-7911 x196" },
                    { new Guid("54515b47-693f-f4da-e89f-9862d69a44ab"), new DateTime(2011, 3, 7, 12, 25, 11, 607, DateTimeKind.Local).AddTicks(773), "Marcia_Blick47@yahoo.com", "Marcia", "Blick", "95ee6b9b17ccfd4fa44d4f2e4d52037573b4c3f8", "1-477-419-8185 x7652" },
                    { new Guid("547a3a2a-9746-f1f7-0dc1-9f411376967d"), new DateTime(2007, 9, 24, 0, 9, 42, 322, DateTimeKind.Local).AddTicks(8032), "Jeannie.Erdman98@yahoo.com", "Jeannie", "Erdman", "15e7b22540b89b81c33920eb1cde27f631f52e51", "(887) 331-9600 x582" },
                    { new Guid("5c2b4042-627b-9bd8-71c2-8a4b10ba2dc3"), new DateTime(2022, 10, 10, 20, 29, 17, 933, DateTimeKind.Local).AddTicks(5041), "Moses_Orn98@yahoo.com", "Moses", "Orn", "f6dd88a12ff0d731b9d97f95f6c49efd2b5e8575", "337.591.0174 x05854" },
                    { new Guid("5cfc8e08-5314-1ffe-852b-cf7695022774"), new DateTime(2013, 3, 5, 18, 45, 36, 179, DateTimeKind.Local).AddTicks(1104), "Teri_Gleichner72@gmail.com", "Teri", "Gleichner", "e6f37227df1cfff027e5fd0a9129e478759a3156", "840-924-2437" },
                    { new Guid("639e22a8-ebb5-9b66-f18f-64bce6951b54"), new DateTime(2005, 6, 20, 8, 32, 29, 378, DateTimeKind.Local).AddTicks(7296), "Ebony35@gmail.com", "Ebony", "White", "b09ea9aa65cfbd7cb24c3d525424a54dfaaa5bad", "658-849-9321" },
                    { new Guid("64b4e5c0-6541-cdce-487f-d0cf5e41bcdd"), new DateTime(2019, 3, 10, 6, 1, 16, 743, DateTimeKind.Local).AddTicks(7947), "Gregory.Gibson@yahoo.com", "Gregory", "Gibson", "4b9c633ebd15025786d1696936cf719fe755c9ee", "(235) 878-4897 x002" },
                    { new Guid("64bb2e44-3584-aec1-ee15-f67e8b1fe2d8"), new DateTime(2014, 8, 18, 15, 47, 50, 79, DateTimeKind.Local).AddTicks(2346), "Vanessa.Lindgren4@yahoo.com", "Vanessa", "Lindgren", "0626d7d31d39f0447528657f25be92cc8b1955c9", "544.217.2112 x7292" },
                    { new Guid("6569e4a5-16d0-f2e7-efd6-d481c804b5da"), new DateTime(2006, 3, 19, 0, 46, 25, 394, DateTimeKind.Local).AddTicks(6468), "Jacob.Zboncak27@gmail.com", "Jacob", "Zboncak", "57e1d6e7af3ed32bfe76dbb6a2440572be4ce9a1", "(725) 766-6845" },
                    { new Guid("771b2a2f-d9a0-2f46-b75e-94585589f127"), new DateTime(2013, 7, 8, 3, 18, 42, 997, DateTimeKind.Local).AddTicks(2322), "Owen.Kutch81@gmail.com", "Owen", "Kutch", "79c39c51c08e3db58556321310d4705d719c781c", "1-533-638-9063" },
                    { new Guid("8e09c622-cfa5-b448-898b-fcdeeaed3264"), new DateTime(2006, 1, 1, 15, 54, 45, 346, DateTimeKind.Local).AddTicks(216), "Molly47@hotmail.com", "Molly", "Connelly", "1ca15085de48bdac3363c866db3b1d54872283b6", "287-431-0605 x289" },
                    { new Guid("9a2731a6-8052-7fba-e7d5-859847ce1ba1"), new DateTime(2007, 3, 7, 4, 43, 40, 319, DateTimeKind.Local).AddTicks(2969), "Beverly95@yahoo.com", "Beverly", "Pfeffer", "3f3a3b3b666a4c77c6eb2253b33fb31dcb73e0df", "785-350-1846" },
                    { new Guid("9f9b9048-2e80-a16c-f77a-e0a6fe86ef5e"), new DateTime(2005, 12, 16, 5, 7, 46, 197, DateTimeKind.Local).AddTicks(6740), "Alfredo_Conroy@gmail.com", "Alfredo", "Conroy", "7e6cadf7a519fabbd27bac9815c623c4dffa6781", "(902) 950-3406" },
                    { new Guid("a20d864f-6e74-3fdf-6542-3bc4a7cc8183"), new DateTime(2022, 4, 22, 17, 19, 27, 85, DateTimeKind.Local).AddTicks(6955), "Wesley1@gmail.com", "Wesley", "Heidenreich", "4a71661c3378db86f754d2e9fefb4b4fcc937c27", "(970) 276-4966" },
                    { new Guid("bbe74b8f-4d35-5124-de8a-c572b6c207fe"), new DateTime(2016, 11, 12, 11, 19, 56, 112, DateTimeKind.Local).AddTicks(3822), "Stacy_Effertz@hotmail.com", "Stacy", "Effertz", "d742462ecf3fc4d9d9e00bf5e9786fa48d422160", "(535) 793-4002" },
                    { new Guid("c4919c93-3b57-f555-d360-0930100173c3"), new DateTime(2016, 9, 5, 21, 5, 47, 769, DateTimeKind.Local).AddTicks(7268), "Bethany24@gmail.com", "Bethany", "Hills", "b230ee58f7932edfd30b14d40052ea88b9e76299", "842.390.8806 x3055" },
                    { new Guid("d1b897fc-7777-027f-b858-964806e03621"), new DateTime(2016, 6, 27, 1, 57, 38, 427, DateTimeKind.Local).AddTicks(8135), "Mable.Rolfson58@yahoo.com", "Mable", "Rolfson", "e033dd26e7cf26f6cff8231b914bbe0303ba850e", "408-259-3567 x43796" },
                    { new Guid("d3a3a7af-ddc4-4ae6-f3f6-ce0e100862f8"), new DateTime(2022, 6, 18, 3, 5, 21, 267, DateTimeKind.Local).AddTicks(9162), "Christian_Paucek38@yahoo.com", "Christian", "Paucek", "61e51ff968d560adc3ddf7ed1b8a12f0699907a2", "898.987.7942 x003" },
                    { new Guid("d7eee062-cbfe-cb53-056f-5ba3e656b6a2"), new DateTime(2007, 1, 27, 10, 50, 56, 637, DateTimeKind.Local).AddTicks(7758), "Glen.Carter@gmail.com", "Glen", "Carter", "9954029fff5432707940ef16dfb476b6bc8caa33", "208-921-5192 x8048" },
                    { new Guid("d94b91d5-6c77-2434-c3df-919814170af1"), new DateTime(2009, 6, 14, 11, 50, 41, 989, DateTimeKind.Local).AddTicks(674), "Regina_Schinner@yahoo.com", "Regina", "Schinner", "1722ef008e510b639af0f2e6d29ef7a8f32a662b", "487-376-4865 x995" },
                    { new Guid("e4d782a2-c14b-bfc5-cee8-432a323314b8"), new DateTime(2011, 2, 7, 12, 25, 13, 358, DateTimeKind.Local).AddTicks(5031), "Myrtle.Tremblay@yahoo.com", "Myrtle", "Tremblay", "213a3fffc29dcfdf60eeb7a98ad9a5a81a61cf13", "(431) 650-9030" },
                    { new Guid("e5d8d983-cc47-c0ad-a4e4-3223e8c09803"), new DateTime(2016, 10, 17, 13, 58, 8, 562, DateTimeKind.Local).AddTicks(6379), "Mable_Conn@yahoo.com", "Mable", "Conn", "0db5458ac49aca27fc5734013543eccb3cab5ae8", "422.982.7599" },
                    { new Guid("e9bfd8b1-5a52-3800-6862-2b734d40cd00"), new DateTime(2014, 8, 29, 11, 41, 42, 183, DateTimeKind.Local).AddTicks(6670), "Kate_Wiegand@gmail.com", "Kate", "Wiegand", "dd63b5ae0f3751ccaa157021025c871051051412", "1-449-983-0589 x903" },
                    { new Guid("ef5a7cad-8ea0-9b3c-e6a8-909589729ae3"), new DateTime(2015, 8, 15, 19, 41, 9, 211, DateTimeKind.Local).AddTicks(2206), "Duane_Moore37@hotmail.com", "Duane", "Moore", "b7359b9627fa8b91b712c73d06f712aae57b0f75", "1-825-765-0585 x45387" },
                    { new Guid("f517f468-6424-0fe9-b705-96e2bddd731f"), new DateTime(2012, 4, 20, 7, 19, 21, 722, DateTimeKind.Local).AddTicks(9083), "Micheal1@hotmail.com", "Micheal", "Fay", "f1cf0567c636d823b1e94506d9f1f702e6f1394a", "(604) 399-1908 x8432" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerID", "BirthDate", "EmailAddress", "FirstName", "LastName", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("f6bd4214-fcae-251e-1c0e-19ff98cd05d9"), new DateTime(2012, 6, 11, 22, 15, 43, 236, DateTimeKind.Local).AddTicks(6087), "Nina.Kshlerin@yahoo.com", "Nina", "Kshlerin", "f04574552ee7ffdbef231961a7dcf2eeb25a1a19", "823.596.1362" },
                    { new Guid("f6d2645c-d118-86e3-b4d6-dead790666a7"), new DateTime(2020, 3, 12, 14, 31, 24, 695, DateTimeKind.Local).AddTicks(1621), "Otis42@yahoo.com", "Otis", "Carter", "a4036c10959e443503e7c9b14a46f279163a02ce", "749.362.8114 x436" }
                });

            migrationBuilder.InsertData(
                table: "ZipCode",
                columns: new[] { "ZipCodeID", "Code", "Commune" },
                values: new object[,]
                {
                    { new Guid("015a6590-7325-373f-d12e-edcf12ee40ba"), 4332, "Shawnatown" },
                    { new Guid("1a5a3102-0f88-5b77-38e5-f158bf7735a0"), 2516, "Pfannerstillville" },
                    { new Guid("1b1dad0b-a3e9-a159-0373-c09337b99331"), 4017, "Stokesview" },
                    { new Guid("24e067a5-bcba-a64b-89a1-f492864098c2"), 8414, "Guiseppeport" },
                    { new Guid("2c7254c6-cbae-3bff-8407-d6e27ce6fd7b"), 4172, "Kaliview" },
                    { new Guid("2fe62252-a708-551d-a9ff-d8833d091197"), 2696, "East Vilma" },
                    { new Guid("3336805e-5e4e-7318-2b02-2a6e5d2e4c82"), 6997, "Rooseveltfurt" },
                    { new Guid("3d669649-f46a-4191-51a1-e414fdbff9d4"), 8569, "Kanebury" },
                    { new Guid("42fd0dfe-7c0b-d282-ffd4-9aa835798a96"), 6608, "South Roslyn" },
                    { new Guid("44c2e0e3-fcc3-c27a-538e-6e49455116ee"), 4914, "North Kylee" },
                    { new Guid("4512512b-b75e-50e5-5cd8-935662d92b94"), 4469, "McCulloughhaven" },
                    { new Guid("4daf4f17-6d5f-21b8-39a6-0ff24f2dbe33"), 9370, "New Howellton" },
                    { new Guid("5d5ffc88-e4f6-01ab-0532-6152d5ffcb6c"), 3678, "North Danaburgh" },
                    { new Guid("5d685d57-9862-1a84-6e13-4d70783ecdb6"), 7172, "Treview" },
                    { new Guid("643ac5d4-ffe7-49d2-742f-876c820ee45f"), 5380, "South Eliseofort" },
                    { new Guid("680db309-2788-0074-c91e-a37e6489184b"), 7129, "Lake Tanya" },
                    { new Guid("730db6da-ba29-d493-4d84-d392155f232c"), 7460, "Nathanport" },
                    { new Guid("7580cc87-11c1-a621-aba2-0a883df7ca02"), 5326, "West Hunterburgh" },
                    { new Guid("7fac8958-fa7b-9218-e34e-281a7af20ba2"), 7308, "Schroedermouth" },
                    { new Guid("81a57a50-52d8-6f5d-4097-8ca4a5e5e0ef"), 6688, "South Onie" },
                    { new Guid("84055676-829f-acbf-c9d6-b79993a498e7"), 4904, "Lake Laverna" },
                    { new Guid("9265e15e-9a3e-a359-8ec8-7d38f873209c"), 5493, "Sheilaside" },
                    { new Guid("976214a1-7077-ce1f-00ac-8a33e9aab7f2"), 5273, "Port Madelynchester" },
                    { new Guid("a4557396-d4b4-fe51-6f92-cf74bde8d96e"), 2932, "Howeburgh" },
                    { new Guid("a6d330d7-4ff6-f3ac-25af-09fbc7ec62e6"), 8856, "Fayton" },
                    { new Guid("a94e249e-e8b1-4d4a-15d1-9088d70cdf2c"), 2361, "North Cale" },
                    { new Guid("b4bdc68a-a64a-4419-adf0-9e436f8be5d7"), 2043, "North Alexisville" },
                    { new Guid("b54eb4ee-32ee-fc1f-c447-44df61a9aaaf"), 1009, "Pollichville" },
                    { new Guid("c0467670-83c8-6512-81c3-bac4147f19f3"), 1209, "Greenfelderville" },
                    { new Guid("c9561e0a-1f45-5b40-7880-2e31a96a7c21"), 9681, "Port Devynburgh" },
                    { new Guid("cb4a4c65-09a3-144d-5784-81af4891ac19"), 9303, "South Brooklynmouth" },
                    { new Guid("df2f14ef-c938-d65f-3e40-c107a46206d2"), 5556, "East Tiana" },
                    { new Guid("e0d40144-b685-3d33-9bd7-1a5f54eee82d"), 7475, "Sabrynamouth" },
                    { new Guid("f2c62a4b-4ba0-9d30-c599-cd107c3efb98"), 6857, "Hyattburgh" },
                    { new Guid("f6f92f29-bbdd-a651-2aca-3fff896eb8da"), 7444, "Audreanneborough" },
                    { new Guid("f80d38a0-7dc7-8150-d72e-2ba23835462f"), 9442, "Port Amina" },
                    { new Guid("f9aa6132-ad53-fc43-3b30-65e4b3dd050c"), 1702, "Felixport" },
                    { new Guid("fc6d7cd8-0cca-eee7-890e-829ae57858fd"), 9637, "East Wilber" },
                    { new Guid("fde18f58-a54d-1b84-fa91-d96002983e36"), 3713, "Port Ally" },
                    { new Guid("ff0a3fb9-1dae-3232-89ed-a47d796b61cd"), 2361, "Deborahton" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductID", "BrandID", "IsFeatured", "ProductDescription", "ProductName", "ProductPrice", "ProductURL" },
                values: new object[,]
                {
                    { new Guid("006b6f9f-201f-5753-5921-921a302cf840"), new Guid("3d77c624-9356-3068-8f30-0bb85651729c"), false, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Handmade Soft Towels", 12.984628236379800m, "https://picsum.photos/640/480/?image=533" },
                    { new Guid("04e319a4-40b7-da17-7433-37b2b1636675"), new Guid("0bd7df94-02a8-b034-5c45-1dfb54b1f529"), false, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Awesome Fresh Bike", 55.440436143167500m, "https://picsum.photos/640/480/?image=307" },
                    { new Guid("0a8dc3ec-ec0a-1644-a0d2-f11cdcaa99a2"), new Guid("4d70da6f-141a-62ce-cc33-9a5596935366"), false, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Generic Wooden Bacon", 93.218626730711500m, "https://picsum.photos/640/480/?image=515" },
                    { new Guid("0de12714-7dd7-b007-baf0-b4afb26d7650"), new Guid("9cb19bf8-afde-ddc7-db50-e2ad897154d2"), false, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Handmade Wooden Bike", 15.758120601884100m, "https://picsum.photos/640/480/?image=889" },
                    { new Guid("0fba7993-1dfb-f84d-7ff9-c3018f9c6294"), new Guid("e3e45b65-eda4-a53a-66d0-9b1f8ed98efc"), false, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Sleek Rubber Soap", 93.439952793270300m, "https://picsum.photos/640/480/?image=898" },
                    { new Guid("15a2a433-a74a-0118-fbcc-0fed52b2e56e"), new Guid("959badbe-7bad-57b5-cd3c-f92f276eebd5"), true, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Intelligent Plastic Car", 43.849628159706300m, "https://picsum.photos/640/480/?image=779" },
                    { new Guid("1b13565c-8345-ec4e-2cd7-1e6f2de84132"), new Guid("102c15a0-6464-7616-6d88-01236ecd42b5"), false, "The Football Is Good For Training And Recreational Purposes", "Incredible Cotton Chips", 7.9470227509490300m, "https://picsum.photos/640/480/?image=1025" },
                    { new Guid("201baef7-4ccd-d467-e49a-f8db2be1f689"), new Guid("8d3443d6-7c48-9e89-a8bb-e145421d90c2"), false, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Intelligent Steel Pizza", 56.449809929565400m, "https://picsum.photos/640/480/?image=356" },
                    { new Guid("23146f8e-cbb6-24db-e476-8fff758f9973"), new Guid("cc4236f3-8909-7940-c61f-66e5915e05ad"), false, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Generic Frozen Shirt", 19.54252115429500m, "https://picsum.photos/640/480/?image=906" },
                    { new Guid("24ad7f8b-437e-4d9b-f005-a5992e164e06"), new Guid("c75e8db1-a293-6c21-daa0-4d8d3f9bc259"), true, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Gorgeous Concrete Sausages", 66.958027503899300m, "https://picsum.photos/640/480/?image=167" },
                    { new Guid("345ec5ef-db05-4d11-e0e1-151360416b4c"), new Guid("33734837-1227-5085-ded5-1b373c300fe9"), true, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Refined Soft Salad", 47.683690929638100m, "https://picsum.photos/640/480/?image=559" },
                    { new Guid("36db7add-c7b7-7366-a87d-7747a1201cd2"), new Guid("0506fb2f-86b6-b93c-348f-d4f2697be09a"), true, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Ergonomic Plastic Bacon", 33.834000459794900m, "https://picsum.photos/640/480/?image=575" },
                    { new Guid("3c0a8ab6-d7b6-5a6e-3bfa-8cd56e2b3560"), new Guid("89acfb10-c061-8721-53b1-d060c8aa0ce0"), false, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Incredible Fresh Pants", 6.9035452357044200m, "https://picsum.photos/640/480/?image=809" },
                    { new Guid("470229c1-b92c-8d96-82fd-dc577b38add8"), new Guid("c7b3305f-9bdb-472c-95c4-51184dd2aa8d"), false, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Unbranded Wooden Ball", 63.62331568432200m, "https://picsum.photos/640/480/?image=161" },
                    { new Guid("5a7ec381-7fe2-acea-e21f-5c1649fca189"), new Guid("bb2b43b4-bdc4-6ac7-c2ee-9c850c9c4d75"), false, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Tasty Wooden Car", 91.274773232301100m, "https://picsum.photos/640/480/?image=752" },
                    { new Guid("5e09d651-6441-feff-661c-8f7811707e73"), new Guid("3bc6573e-7be9-adf6-82f4-32bcb4b0f1b2"), false, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Incredible Rubber Shoes", 22.209727727905700m, "https://picsum.photos/640/480/?image=916" },
                    { new Guid("6298315f-a8a8-97d4-bbd8-895f1d9512e6"), new Guid("7c04d23b-019f-8a60-3710-6edd8e2bd064"), true, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Intelligent Concrete Ball", 89.520610631220300m, "https://picsum.photos/640/480/?image=935" },
                    { new Guid("74082b5e-52ee-2029-143c-c4d2c1540165"), new Guid("4700fa3f-5a0e-779f-9a1d-3561e7579c43"), false, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Intelligent Granite Soap", 87.955784047001900m, "https://picsum.photos/640/480/?image=132" },
                    { new Guid("7dcc32a6-9135-8d56-5a12-05ac8fdbe918"), new Guid("7834298a-c5eb-188f-c4b8-7b2e59525a8c"), true, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Small Steel Shirt", 70.295350239749700m, "https://picsum.photos/640/480/?image=813" },
                    { new Guid("832bf510-261d-a99b-dfb5-6c2cc19e6d0c"), new Guid("cec876ad-01dd-e278-c9a2-a9307cb760db"), false, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Handmade Soft Fish", 14.977932122991400m, "https://picsum.photos/640/480/?image=752" },
                    { new Guid("84a89272-5ad6-4b20-3e86-ec605d3bbb64"), new Guid("cec3aa34-f966-56f0-4664-0aaf516dc3be"), true, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Rustic Metal Hat", 48.107952786659800m, "https://picsum.photos/640/480/?image=506" },
                    { new Guid("84f783dd-d95a-7406-cc6b-2bc0aceb3d15"), new Guid("cbae5d6d-972f-22f0-58bf-b9d0ee21d8ed"), true, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Unbranded Frozen Sausages", 58.316251569574800m, "https://picsum.photos/640/480/?image=973" },
                    { new Guid("90fc49db-ce26-20c2-2da2-1550986b7777"), new Guid("9ff33aaf-690f-bbc1-2c6f-ce2c728d04a5"), true, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Small Soft Tuna", 47.668922155941300m, "https://picsum.photos/640/480/?image=977" },
                    { new Guid("9587d601-b9dd-54d8-c7d4-8bde42a12b9b"), new Guid("9dee3a3f-f243-4328-71f1-e8ffc3e39632"), true, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Refined Soft Car", 26.211186743439700m, "https://picsum.photos/640/480/?image=66" },
                    { new Guid("9be586f7-4338-c32d-2d13-680eb049b5dc"), new Guid("e39c64d3-fd29-e24f-16a6-8e0134a19954"), false, "The Football Is Good For Training And Recreational Purposes", "Licensed Concrete Towels", 99.497796920825600m, "https://picsum.photos/640/480/?image=918" },
                    { new Guid("a1173ec7-7e44-cd99-33aa-7d05c5dcfedc"), new Guid("93a16dfd-ab85-04b9-fd40-0ecea27f8448"), false, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Unbranded Soft Salad", 23.57375189828400m, "https://picsum.photos/640/480/?image=709" },
                    { new Guid("a12cdf19-5b03-bd17-207a-c0ef479d9c5f"), new Guid("0ff7bd5d-7afb-72a0-d8aa-f62c8441cdf7"), false, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Rustic Soft Bacon", 69.409277462125400m, "https://picsum.photos/640/480/?image=121" },
                    { new Guid("a3bdf92f-0d66-e0c1-8b22-83e0772d50f1"), new Guid("490c6622-bbea-0234-2100-e37d6a9bb082"), false, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Handcrafted Plastic Keyboard", 78.844258970974100m, "https://picsum.photos/640/480/?image=804" },
                    { new Guid("a89c88dd-9e4a-4b1d-e7e8-a2984ac6e809"), new Guid("c2bba114-d677-a87e-9248-5a20bead30a8"), false, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Refined Rubber Shoes", 33.854745530455700m, "https://picsum.photos/640/480/?image=309" },
                    { new Guid("b9ff1eda-8872-b676-6e44-45e634231065"), new Guid("963e205d-c089-03f5-23c8-ab1b097901d5"), false, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Ergonomic Steel Sausages", 42.445562147742900m, "https://picsum.photos/640/480/?image=362" },
                    { new Guid("bb4d2353-9387-b44b-9a8d-c4887fe10659"), new Guid("0680f4bc-ea50-98f6-7504-6a63414cdf42"), true, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Small Granite Towels", 7.5096863356929700m, "https://picsum.photos/640/480/?image=747" },
                    { new Guid("c609ef94-48a8-dee9-1f90-2ccf277b7fa4"), new Guid("0bf3561a-9991-29d4-ce39-8263dd0de6f4"), true, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Ergonomic Soft Ball", 47.714508999006100m, "https://picsum.photos/640/480/?image=408" },
                    { new Guid("cf6e93a4-78a4-e352-41f7-5421a4d0d542"), new Guid("3bf480d3-cb4e-a040-56e8-a8186acdfd9b"), true, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Practical Rubber Gloves", 91.227636761603700m, "https://picsum.photos/640/480/?image=100" },
                    { new Guid("db820e2c-2735-54f3-4bb5-e29379aaec15"), new Guid("5b1fd012-2199-dab9-e58b-92bd68d0fa17"), false, "The Football Is Good For Training And Recreational Purposes", "Handcrafted Concrete Fish", 87.607566820274800m, "https://picsum.photos/640/480/?image=37" },
                    { new Guid("dca9725f-7852-b0e3-cb1f-70aa42679d32"), new Guid("b2c36398-f822-2f8c-9e02-bd1e16f7c55a"), false, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Awesome Rubber Gloves", 23.267161065371300m, "https://picsum.photos/640/480/?image=745" },
                    { new Guid("dce25618-0f1f-bd63-c90b-cfd46f2469d3"), new Guid("801abe43-31c6-11d5-ac49-5c10586c790b"), false, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Ergonomic Wooden Table", 94.013108170597400m, "https://picsum.photos/640/480/?image=346" },
                    { new Guid("ddaa6099-6e78-51b8-548a-bb87111341fa"), new Guid("68fbb9a4-cd27-aa9f-7ae6-4281bda59a71"), false, "The Football Is Good For Training And Recreational Purposes", "Unbranded Soft Chicken", 97.784135722454700m, "https://picsum.photos/640/480/?image=665" },
                    { new Guid("e4aaeaa1-a055-3024-86db-b17f2065c858"), new Guid("4c9ea98f-1208-8361-8f5f-ccf4b179ff89"), false, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Ergonomic Fresh Keyboard", 9.2919680798854500m, "https://picsum.photos/640/480/?image=269" },
                    { new Guid("ec7b3944-8856-dfaa-f6a0-fe10cb9c55bd"), new Guid("0136a8be-afc5-e0cc-f28b-6c79d99c9320"), true, "The Football Is Good For Training And Recreational Purposes", "Tasty Soft Keyboard", 56.527720697469900m, "https://picsum.photos/640/480/?image=748" },
                    { new Guid("f2e2f601-4cfa-c93f-a28d-6a8d66dee66e"), new Guid("41c09f22-e462-eec2-b236-046951f599dd"), false, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Rustic Wooden Chips", 39.078262093979100m, "https://picsum.photos/640/480/?image=958" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CustomerID",
                table: "Address",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Address_ZipCodeID",
                table: "Address",
                column: "ZipCodeID");

            migrationBuilder.CreateIndex(
                name: "IX_Basket_BasketStatusCode",
                table: "Basket",
                column: "BasketStatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_Basket_CustomerID",
                table: "Basket",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_BasketProducts_ProductID",
                table: "BasketProducts",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_BillingAddressID",
                table: "Order",
                column: "BillingAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerID",
                table: "Order",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_DeliveryAddressID",
                table: "Order",
                column: "DeliveryAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderStatusCode",
                table: "Order",
                column: "OrderStatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedProduct_OrderID",
                table: "OrderedProduct",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedProduct_ProductID",
                table: "OrderedProduct",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandID",
                table: "Product",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryID",
                table: "ProductCategories",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_ProductID",
                table: "ProductImage",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_CustomerID",
                table: "Review",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ProductID",
                table: "Review",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ZipCode_Code_Commune",
                table: "ZipCode",
                columns: new[] { "Code", "Commune" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketProducts");

            migrationBuilder.DropTable(
                name: "OrderedProduct");

            migrationBuilder.DropTable(
                name: "ProductCategories");

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