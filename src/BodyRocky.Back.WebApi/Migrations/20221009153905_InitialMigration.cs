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
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false),
                    ParentCategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                    table.ForeignKey(
                        name: "FK_Category_Category_ParentCategoryID",
                        column: x => x.ParentCategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
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
                    OrderedProductPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
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
                table: "Category",
                columns: new[] { "CategoryID", "CategoryName", "IsFeatured", "ParentCategoryID" },
                values: new object[,]
                {
                    { new Guid("2eca204c-7f46-85a6-734c-5fcac10767d4"), "System.String[]", false, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("a825c26a-dc51-1f8f-27ca-3da2e35eabf7"), "System.String[]", false, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("ba9b08af-e42a-b3df-f584-2e4c6d6cfda4"), "System.String[]", false, new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerID", "BirthDate", "EmailAddress", "FirstName", "LastName", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("01b86bb5-6715-e0b4-40ff-f9d2387bb286"), new DateTime(2014, 2, 2, 5, 0, 21, 438, DateTimeKind.Local).AddTicks(2575), "Kristin_Connelly96@gmail.com", "Kristin", "Connelly", "9503aca712b117af5f31ca2f3614d24d6d738039", "1-656-727-5064" },
                    { new Guid("02de17d4-6f81-7b42-c462-a57575bbe608"), new DateTime(2009, 12, 13, 7, 51, 36, 559, DateTimeKind.Local).AddTicks(2279), "Lula_Brown63@hotmail.com", "Lula", "Brown", "b2c6aa4d54c6cef5e4bf9ccb6819e1a9dfc77691", "871.533.5356 x019" },
                    { new Guid("035e7866-3aa7-1652-135d-e01887f92c05"), new DateTime(2022, 5, 11, 21, 28, 40, 868, DateTimeKind.Local).AddTicks(2064), "Jimmy.Hayes@yahoo.com", "Jimmy", "Hayes", "d70cd115ec2fcb207fd7a94e90032530da232b12", "615.357.5577 x30361" },
                    { new Guid("04a655d7-65df-fb84-4919-507d083470c0"), new DateTime(2011, 4, 25, 10, 56, 5, 860, DateTimeKind.Local).AddTicks(826), "Joel.Toy92@yahoo.com", "Joel", "Toy", "197d5179a4e98de4e93d858e908a152eb0579f90", "1-238-649-1124 x59417" },
                    { new Guid("06226c88-d66d-c73b-71a5-8e3db55da1e3"), new DateTime(2010, 7, 29, 21, 56, 21, 165, DateTimeKind.Local).AddTicks(8829), "Ella.Tremblay99@gmail.com", "Ella", "Tremblay", "9e19e92979a8f002f8e51a495a605571d0da5ee8", "962.979.5213" },
                    { new Guid("0b216413-796e-d10b-38c6-61605ef423df"), new DateTime(2005, 7, 10, 8, 58, 29, 25, DateTimeKind.Local).AddTicks(7632), "Bruce85@yahoo.com", "Bruce", "Goyette", "12ddaec7cfbddf97f33cb2f76861aec30acad741", "(587) 555-4184" },
                    { new Guid("0c031c25-af61-f060-f6d4-f34fd242a3f3"), new DateTime(2016, 12, 20, 9, 8, 22, 837, DateTimeKind.Local).AddTicks(2178), "Emily_Homenick1@gmail.com", "Emily", "Homenick", "c0d7e2d56a36ac6cfc424deac3694feee002dfd3", "1-273-973-4016 x28010" },
                    { new Guid("0c8118a2-d42d-d146-9fab-abac610b2644"), new DateTime(2012, 1, 20, 13, 46, 17, 405, DateTimeKind.Local).AddTicks(7932), "Jason.Moen@yahoo.com", "Jason", "Moen", "3162614a641ce59e29b9fcb3b890e6fc9942cc76", "247-901-4979 x6423" },
                    { new Guid("112a324a-5037-1c70-7661-d3f2bc239249"), new DateTime(2021, 12, 23, 18, 12, 45, 788, DateTimeKind.Local).AddTicks(8818), "Lynda.Zemlak52@yahoo.com", "Lynda", "Zemlak", "4e26e95ef1f1e959e2c341e3b760c854164a6dca", "1-594-335-0994 x39038" },
                    { new Guid("16d8dc6a-df56-eb87-2d85-47810a4bf11e"), new DateTime(2006, 12, 27, 9, 44, 32, 107, DateTimeKind.Local).AddTicks(1502), "Veronica.Boyer16@yahoo.com", "Veronica", "Boyer", "95e1ec9e98c20021b68202d731aeeaf6ae198e6d", "681.213.0386 x0302" },
                    { new Guid("17109f43-9961-8417-fc39-18a7db0884b9"), new DateTime(2011, 8, 15, 4, 25, 55, 389, DateTimeKind.Local).AddTicks(8124), "Bernadette_Schneider2@hotmail.com", "Bernadette", "Schneider", "5144c4b954eef3204b7f8acea0817a815733bdfb", "254.719.1773 x2397" },
                    { new Guid("183ea680-678f-81bc-93f7-bd52e1358c2b"), new DateTime(2018, 1, 25, 6, 58, 31, 481, DateTimeKind.Local).AddTicks(3146), "Charlotte.Schiller76@yahoo.com", "Charlotte", "Schiller", "81df1daef1267712e7323af224c42a6eabf97c7c", "1-912-220-1677 x3986" },
                    { new Guid("198b6824-2370-7aee-3997-f07ca9692dfd"), new DateTime(2014, 9, 26, 23, 1, 1, 665, DateTimeKind.Local).AddTicks(6577), "Gwen.Stanton@hotmail.com", "Gwen", "Stanton", "66bc501a4c4282567380cdd9f98f705db9cd5d2f", "216-716-4654" },
                    { new Guid("1a6ba1f2-f341-2775-0b48-1747452d4301"), new DateTime(2020, 7, 18, 16, 17, 57, 240, DateTimeKind.Local).AddTicks(5214), "Lynda_Douglas87@yahoo.com", "Lynda", "Douglas", "eeaf7583a2410f2e1acf9dc81d887c6be750a3ab", "(610) 346-4390" },
                    { new Guid("1b50c483-4054-739d-9eb6-7b1a753e18f3"), new DateTime(2008, 4, 23, 7, 49, 45, 206, DateTimeKind.Local).AddTicks(9074), "Dave_Emard@hotmail.com", "Dave", "Emard", "983d1c2f4f52fffbcc9d472b83e0d33e717b879e", "(911) 666-7233 x17926" },
                    { new Guid("1df4b05e-34ba-84fb-5116-ddec6ef1dcb8"), new DateTime(2007, 7, 2, 0, 43, 56, 405, DateTimeKind.Local).AddTicks(4313), "Hubert81@yahoo.com", "Hubert", "VonRueden", "b8100af888e0a017f4090a3704872b9ee59d3967", "845-510-2653" },
                    { new Guid("229abf9b-25e9-3504-0742-21d5d81dbf2f"), new DateTime(2012, 9, 5, 13, 42, 41, 831, DateTimeKind.Local).AddTicks(7112), "Lloyd.Hamill92@yahoo.com", "Lloyd", "Hamill", "b1a7dd6230129c4b3d32358c582cc853d39a3131", "1-829-277-9179" },
                    { new Guid("25f44f6b-6b4d-c33e-b4d7-62c1e3b88180"), new DateTime(2018, 11, 23, 2, 33, 20, 131, DateTimeKind.Local).AddTicks(2581), "Cecelia71@yahoo.com", "Cecelia", "Kemmer", "12e79e994924ff9801357c984d9ba5e6f627164d", "(786) 206-8295 x33976" },
                    { new Guid("26282fa9-92b6-e633-52ae-1cf10cc1f9d2"), new DateTime(2018, 8, 21, 0, 17, 33, 48, DateTimeKind.Local).AddTicks(2412), "Dewey.Howell@yahoo.com", "Dewey", "Howell", "6b65823243d566f8ab0899cb496ae0ed4344a558", "506.504.3438" },
                    { new Guid("26d855eb-aeaf-596e-3604-8a7350ff8d9b"), new DateTime(2020, 9, 6, 5, 49, 33, 688, DateTimeKind.Local).AddTicks(5075), "Carl58@gmail.com", "Carl", "Jacobs", "60be40ce571d2f8cf20d487f2cc8852c9f834ce8", "276.247.3020 x706" },
                    { new Guid("2837f375-cb6b-89aa-8a99-b1e3177c1fc2"), new DateTime(2005, 7, 6, 15, 19, 44, 193, DateTimeKind.Local).AddTicks(4261), "Max.Koch57@yahoo.com", "Max", "Koch", "8f2ecec7dad223befcb1e9f6724da32bdd1090be", "1-770-593-3072 x2628" },
                    { new Guid("2bb71798-2874-7d0e-7bb4-91108197a9cb"), new DateTime(2012, 7, 10, 5, 11, 27, 611, DateTimeKind.Local).AddTicks(6649), "Nicole.Botsford86@gmail.com", "Nicole", "Botsford", "49c75605af8053061f3a18e2fffe4aef85d3df63", "(233) 721-4706 x8066" },
                    { new Guid("2c1f529b-992f-9830-836e-6f8a642108a7"), new DateTime(2015, 2, 16, 0, 49, 47, 744, DateTimeKind.Local).AddTicks(422), "Darryl.Deckow@yahoo.com", "Darryl", "Deckow", "a9af7e4e748d4c23962b3e61076cee66f5afc1ab", "964.702.2613" },
                    { new Guid("2f9101d8-c2ff-4ba2-ba99-2c16c807b576"), new DateTime(2013, 10, 4, 14, 0, 58, 649, DateTimeKind.Local).AddTicks(7064), "Frances.Kilback45@gmail.com", "Frances", "Kilback", "537ef5ccd0db8f9743ee464b5ba765c2778f6db0", "1-931-219-6153" },
                    { new Guid("389dd9c2-cc3c-c553-e335-8b4fbc1e6dd8"), new DateTime(2014, 1, 5, 20, 39, 48, 492, DateTimeKind.Local).AddTicks(4164), "Alejandro.Haley61@gmail.com", "Alejandro", "Haley", "4e7389b1e6388bb796c1db47413d5b55e450f6bd", "1-673-222-9441" },
                    { new Guid("3a5df9d9-cb0c-3ea2-a184-bf49c2157d53"), new DateTime(2016, 9, 10, 14, 47, 0, 798, DateTimeKind.Local).AddTicks(7373), "Fernando.Franecki@gmail.com", "Fernando", "Franecki", "da71509c0837c4a5560c1f122e0f665450b94559", "534.225.5340 x037" },
                    { new Guid("3d82ce02-caad-45d4-3d2b-060343a42c5b"), new DateTime(2010, 9, 28, 2, 32, 43, 257, DateTimeKind.Local).AddTicks(7689), "Wesley.Kessler@yahoo.com", "Wesley", "Kessler", "1739d7774fa7914dcc785bd1d83abdb6ef1aa3f4", "1-857-452-4961 x3423" },
                    { new Guid("3de3c8e0-047c-ca07-d289-cf179114c8c5"), new DateTime(2012, 8, 10, 3, 16, 2, 332, DateTimeKind.Local).AddTicks(1914), "Terry.Boyle@yahoo.com", "Terry", "Boyle", "6a089f00322a26015023cb410e715a6d8ce4864f", "926.247.0821 x5290" },
                    { new Guid("3e46080f-82e9-307c-2fe7-3be6e061cb0a"), new DateTime(2017, 2, 27, 5, 38, 38, 277, DateTimeKind.Local).AddTicks(5651), "Michael_Schmitt@yahoo.com", "Michael", "Schmitt", "675e6595c8f96127b06370d31bd6aacf0e8c8de4", "255.449.1947 x2795" },
                    { new Guid("45390373-1324-ddf7-6b88-c0d5ce2fca23"), new DateTime(2020, 12, 4, 5, 45, 35, 922, DateTimeKind.Local).AddTicks(4903), "Jody_Mueller@yahoo.com", "Jody", "Mueller", "c63d3f8335efecea32561e9cad0f9b873fc52744", "(424) 328-1046 x95242" },
                    { new Guid("47cfe6a8-6c23-bbb7-c082-64c55631d04b"), new DateTime(2005, 11, 12, 6, 51, 21, 321, DateTimeKind.Local).AddTicks(7840), "Roberto.Romaguera@gmail.com", "Roberto", "Romaguera", "ebdb0ecd6cb8f3ef644579073a89043856095d53", "740.222.3759" },
                    { new Guid("4e9e0416-5dcc-eaaf-e4ea-f564653c840e"), new DateTime(2010, 6, 21, 14, 54, 41, 756, DateTimeKind.Local).AddTicks(3047), "Agnes.Grady51@gmail.com", "Agnes", "Grady", "c450ce99b7d5d7dd96188c4611d7d108aed63ccd", "(629) 840-0971" },
                    { new Guid("4f3ea6b4-5f51-a64e-dddb-25b7075f7a1a"), new DateTime(2009, 5, 1, 11, 36, 17, 92, DateTimeKind.Local).AddTicks(3788), "Karla75@gmail.com", "Karla", "Labadie", "d0ef90042089056e33e1e6f56c2ac1ef8be0c1c9", "374-462-0766" },
                    { new Guid("500675fb-7f19-246f-c025-c2e1a4ce0c85"), new DateTime(2016, 5, 10, 11, 8, 48, 419, DateTimeKind.Local).AddTicks(40), "Michelle_Stokes@hotmail.com", "Michelle", "Stokes", "08b7bba1f0af843a0eb465e50a76a4eb8ae47c43", "(474) 466-9343 x0807" },
                    { new Guid("508de087-eab6-cd66-3024-4ed6af3e7c96"), new DateTime(2007, 1, 30, 4, 18, 30, 982, DateTimeKind.Local).AddTicks(7686), "Penny53@hotmail.com", "Penny", "Maggio", "5d5d6305bdec8383bf6b8f27e016a12dbf13fbe9", "621-489-5079" },
                    { new Guid("5136745f-480c-ffec-5d8a-4dff4ce334d2"), new DateTime(2008, 3, 6, 7, 22, 2, 260, DateTimeKind.Local).AddTicks(6079), "Lamar_Botsford14@yahoo.com", "Lamar", "Botsford", "69a94234008dcda05a0159733478c4824eb215f0", "1-432-524-5607" },
                    { new Guid("515470bf-01c1-72e9-c6e8-69be5ca69965"), new DateTime(2019, 11, 11, 0, 26, 11, 203, DateTimeKind.Local).AddTicks(7364), "Mathew_Wiegand82@yahoo.com", "Mathew", "Wiegand", "35fa9a13a5966edd05f6ec107ed3172bbf9058ef", "704-334-2785" },
                    { new Guid("5252bb61-ebac-91f5-956d-b4aaafafdb09"), new DateTime(2008, 1, 18, 0, 37, 23, 68, DateTimeKind.Local).AddTicks(8725), "Gwen.Mitchell@yahoo.com", "Gwen", "Mitchell", "a4ae1a12fa5127f317e5123c216ddd8d28430865", "389-528-5652 x8814" },
                    { new Guid("52679878-f629-3086-d672-dd521987cc60"), new DateTime(2007, 6, 18, 2, 59, 34, 47, DateTimeKind.Local).AddTicks(486), "Juan_Grimes50@hotmail.com", "Juan", "Grimes", "377fbb4eadc9058801cb06febc316aac9d8e6956", "377-839-1976 x705" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerID", "BirthDate", "EmailAddress", "FirstName", "LastName", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("536e3b06-bcf1-9f9b-a3d1-85f21ace8a5c"), new DateTime(2013, 5, 8, 21, 5, 42, 436, DateTimeKind.Local).AddTicks(4807), "Joan.Haley@gmail.com", "Joan", "Haley", "5da6cbda9e5f5d6474e1b9cd00c3e204d73b7700", "773.393.8364" },
                    { new Guid("59b07ad8-4da2-fb4b-1110-d2f0e76ec241"), new DateTime(2020, 12, 8, 10, 57, 28, 97, DateTimeKind.Local).AddTicks(181), "Willis_Bosco@hotmail.com", "Willis", "Bosco", "24f6902767a4b7ac3ce218a0a47770b03d149e1a", "965-631-8349 x7150" },
                    { new Guid("5f9e1db4-6ac0-c4e7-79fd-f1e1c6da7a7a"), new DateTime(2020, 12, 21, 8, 24, 2, 459, DateTimeKind.Local).AddTicks(8249), "Bill_Effertz36@gmail.com", "Bill", "Effertz", "358b1e3621b69cb77cf49cd97aae0d1c531052f9", "1-642-502-1850" },
                    { new Guid("600b1c2e-50d1-2994-3e82-e8f32a0690d7"), new DateTime(2015, 5, 19, 15, 35, 28, 657, DateTimeKind.Local).AddTicks(6625), "Olivia56@gmail.com", "Olivia", "Cummings", "ed77f296d7a62bbe483c6e9c1ddbb9d7e84eaade", "500.869.4335" },
                    { new Guid("6592ffa4-9582-f7d3-e5ee-11b3f21aa4c9"), new DateTime(2010, 3, 1, 7, 59, 41, 989, DateTimeKind.Local).AddTicks(7959), "Bessie.Stark34@yahoo.com", "Bessie", "Stark", "147334a96edad735e6ef32f9bf88d960a826dbdc", "627-497-3899 x58330" },
                    { new Guid("692368b1-47d7-6322-70e2-d6fd0d46bdb2"), new DateTime(2019, 3, 10, 19, 35, 7, 142, DateTimeKind.Local).AddTicks(5318), "Al_Schmidt@yahoo.com", "Al", "Schmidt", "25869e79f20b2b7a344f9b9e5fe64bce248c7a11", "1-571-463-2230" },
                    { new Guid("6bb6c4f8-0ecf-206a-81e4-a31a1ec334e1"), new DateTime(2021, 7, 14, 0, 49, 4, 237, DateTimeKind.Local).AddTicks(975), "Gustavo4@hotmail.com", "Gustavo", "Hodkiewicz", "1f48b70e9028591e05cf4854a80bd9d7f0bcd278", "534-270-0322 x0989" },
                    { new Guid("6cf24796-c5a3-36cf-efcb-1060857f7dce"), new DateTime(2013, 2, 14, 3, 57, 9, 384, DateTimeKind.Local).AddTicks(6628), "Ray13@yahoo.com", "Ray", "Robel", "27a29c745c52899edd01d99db102d08058f69d7e", "(815) 213-1167" },
                    { new Guid("6d509eb9-41b3-3d9a-8d91-043e42827cc5"), new DateTime(2021, 2, 11, 17, 25, 13, 681, DateTimeKind.Local).AddTicks(789), "Nancy_MacGyver@gmail.com", "Nancy", "MacGyver", "b7984651309a47a502ecb94356994926ca99f171", "891-964-1521" },
                    { new Guid("78b97b97-1796-c86c-5ad4-57f7ac31302f"), new DateTime(2008, 12, 2, 22, 4, 27, 822, DateTimeKind.Local).AddTicks(8135), "Floyd.Harris52@hotmail.com", "Floyd", "Harris", "d30c8e295c4d854f9cc4f47ef21649f0fdeb2ba6", "1-624-432-6348 x44889" },
                    { new Guid("7ae9f6d0-749d-78c0-f8fb-db34bb7389f3"), new DateTime(2021, 5, 5, 14, 32, 52, 462, DateTimeKind.Local).AddTicks(8895), "Lee_Veum7@hotmail.com", "Lee", "Veum", "0a207ed38dca752ab4d363e870148d6de73b0bf3", "711-377-2040" },
                    { new Guid("7b9c6565-7910-ff63-bf75-f0040d8a08a6"), new DateTime(2008, 2, 4, 2, 21, 49, 716, DateTimeKind.Local).AddTicks(8325), "Samuel_Heathcote@hotmail.com", "Samuel", "Heathcote", "ca6f5476a4cdcaa9d46e88eee89751a26656ae45", "498.268.0324 x3402" },
                    { new Guid("7bf6490b-813e-49eb-7e82-7e6024043deb"), new DateTime(2011, 5, 30, 7, 37, 38, 972, DateTimeKind.Local).AddTicks(9897), "Leslie_Mills79@gmail.com", "Leslie", "Mills", "0273c3609bd9f678b2a8a765ade9b24156b63f99", "1-422-618-8837 x46754" },
                    { new Guid("7fa6a726-e3ae-b21a-479b-a9f72918574f"), new DateTime(2010, 8, 5, 8, 47, 20, 219, DateTimeKind.Local).AddTicks(8550), "Eduardo.Trantow4@gmail.com", "Eduardo", "Trantow", "d164ad13d25600e4dceec3212ebf1d8795711795", "466.781.3188" },
                    { new Guid("83e031c8-dd84-e831-4e3e-69bb8b267696"), new DateTime(2013, 2, 14, 10, 42, 2, 328, DateTimeKind.Local).AddTicks(3418), "Genevieve.Beatty50@hotmail.com", "Genevieve", "Beatty", "edfbc8bc179d2caeaaa932f5ccab60b0a01eee34", "1-773-960-6793 x9063" },
                    { new Guid("85eb59e6-7ca5-81f3-caf5-f024eda79d7e"), new DateTime(2012, 11, 18, 20, 15, 25, 116, DateTimeKind.Local).AddTicks(6966), "Leroy20@hotmail.com", "Leroy", "Dicki", "a23f757ecf7db3289359cb6276979e56c32c9c62", "423.288.3543" },
                    { new Guid("87fb0313-c4e6-ae65-f72f-e949511a21b2"), new DateTime(2012, 11, 27, 2, 30, 55, 298, DateTimeKind.Local).AddTicks(1988), "Stella5@hotmail.com", "Stella", "Kuvalis", "d959e2a25896b1e67cf397edd02c358cf04dfa1d", "851-988-1444" },
                    { new Guid("8a8979d5-cbe9-b414-c8f1-583a95f521d2"), new DateTime(2008, 4, 17, 4, 4, 9, 407, DateTimeKind.Local).AddTicks(9948), "Jonathan.Halvorson8@hotmail.com", "Jonathan", "Halvorson", "1aacb1fc7328dfaf594ddf7edcafcdc3b3b794c4", "619-224-1555" },
                    { new Guid("91825a1c-3110-e286-0b5f-9beddfc43c1d"), new DateTime(2008, 12, 10, 23, 32, 38, 158, DateTimeKind.Local).AddTicks(1562), "Johnnie_Klein28@hotmail.com", "Johnnie", "Klein", "56b88daf1dcd386baa509d7a43f043fecc018e11", "(565) 884-5733 x737" },
                    { new Guid("93f1478c-50ac-ff0b-8fbf-fc1b8277c496"), new DateTime(2010, 12, 16, 21, 29, 31, 986, DateTimeKind.Local).AddTicks(2272), "Amelia.Hayes@gmail.com", "Amelia", "Hayes", "0d67dd3607d016baf0ae0a4584c42b264ec0f2c3", "(462) 463-3764 x6178" },
                    { new Guid("9485a118-95b8-8dc6-b9d2-d01778da3ba3"), new DateTime(2010, 3, 14, 0, 52, 52, 699, DateTimeKind.Local).AddTicks(9295), "Delbert74@hotmail.com", "Delbert", "Renner", "39decd5fa7857b97d26aa43492ba3139921ead43", "630-648-0666 x221" },
                    { new Guid("96b8ed26-d1aa-6c09-e3bc-301d54567d82"), new DateTime(2017, 11, 23, 1, 17, 34, 164, DateTimeKind.Local).AddTicks(3259), "Diane.Morissette@yahoo.com", "Diane", "Morissette", "502d91e53517b1d711ec356d04f783827ad033f9", "933-465-4014" },
                    { new Guid("a12ac9a0-4edb-9179-578e-1ad141fdb19a"), new DateTime(2020, 12, 1, 7, 33, 0, 96, DateTimeKind.Local).AddTicks(6282), "Clifford.Hirthe@hotmail.com", "Clifford", "Hirthe", "276a322b048ce37cb8606ac45e645c45dd685748", "1-453-571-4931 x15580" },
                    { new Guid("a1bd737e-1d28-920e-5b11-692f3a17da32"), new DateTime(2015, 9, 14, 1, 14, 19, 228, DateTimeKind.Local).AddTicks(2594), "Lena_Rosenbaum95@hotmail.com", "Lena", "Rosenbaum", "2fae416f79d5e1bd4fbe2be87112059013030378", "673.734.5409" },
                    { new Guid("a55269bb-3263-14b3-14bf-a68a747f8c3d"), new DateTime(2017, 1, 16, 18, 6, 18, 343, DateTimeKind.Local).AddTicks(5886), "Rochelle25@gmail.com", "Rochelle", "Bogan", "32a7c86092c186751506d18b0a79a07bb62f6b7f", "1-509-757-8224" },
                    { new Guid("a5bdf4d6-90b1-23c2-06b0-5bd772d0abb5"), new DateTime(2021, 12, 17, 14, 44, 42, 102, DateTimeKind.Local).AddTicks(6020), "Israel74@yahoo.com", "Israel", "Deckow", "508559f33acafe8546ec3299613b182837c31cb8", "1-773-524-0594 x502" },
                    { new Guid("a9199329-f35a-2f36-41e6-f37f054ec807"), new DateTime(2010, 9, 21, 13, 23, 39, 847, DateTimeKind.Local).AddTicks(9560), "Penny_Kessler@hotmail.com", "Penny", "Kessler", "e4c4b9d7474fde0170700aeb40d25226cdae7ff4", "252.206.8247" },
                    { new Guid("a9fade29-defb-def1-7af0-0972a708ecee"), new DateTime(2018, 1, 8, 3, 27, 50, 741, DateTimeKind.Local).AddTicks(8615), "Bernadette40@yahoo.com", "Bernadette", "Boyle", "6221dd1fd6def571d6368833a696e69742c3d220", "640.543.4842" },
                    { new Guid("aa100e0b-ce46-c414-e1d0-61ef71ce9f3f"), new DateTime(2017, 8, 25, 11, 56, 22, 768, DateTimeKind.Local).AddTicks(1365), "Roberta_Heathcote32@gmail.com", "Roberta", "Heathcote", "1855ded151b8ade5c02b68fe55037aed315176ae", "821.766.8022 x0778" },
                    { new Guid("ad53a40c-fd81-737c-2baa-179ca4555b3c"), new DateTime(2009, 5, 31, 3, 15, 17, 138, DateTimeKind.Local).AddTicks(2712), "Kim.Cremin@yahoo.com", "Kim", "Cremin", "8a21dbbece0db960a581cf77fe754e975e299352", "1-921-624-6620 x3924" },
                    { new Guid("b26eefbe-0062-a41e-25eb-7991a8a088b5"), new DateTime(2012, 1, 9, 5, 22, 58, 73, DateTimeKind.Local).AddTicks(890), "Mamie5@gmail.com", "Mamie", "Dietrich", "dc1562e3c2b2000effa24b0258eefb98613246ba", "1-775-380-0056 x892" },
                    { new Guid("b56e658d-4598-d556-2dac-578d3b49ae4f"), new DateTime(2005, 4, 26, 0, 32, 24, 953, DateTimeKind.Local).AddTicks(3293), "Lula.Hammes@gmail.com", "Lula", "Hammes", "0cc6a7c90316a16438e055809e9b8c053ca55732", "291-236-6065" },
                    { new Guid("b5717ef0-ecfb-e7c2-0039-5e4cc8ec96bd"), new DateTime(2019, 3, 24, 5, 26, 10, 481, DateTimeKind.Local).AddTicks(5109), "Rolando_Ratke38@gmail.com", "Rolando", "Ratke", "a46104d04b419e56348e2b9e4e13d3b28e443f3b", "1-315-411-8407" },
                    { new Guid("ba53d8e6-5d79-a4c4-155e-aba5f151b659"), new DateTime(2005, 2, 15, 5, 25, 42, 625, DateTimeKind.Local).AddTicks(2870), "Steven94@yahoo.com", "Steven", "Rempel", "21c5ed813abae2ffad70b24a72f330f80c292023", "(618) 666-4879 x688" },
                    { new Guid("bc472b35-582e-fc63-dbe0-f3598871e189"), new DateTime(2015, 12, 25, 9, 40, 3, 850, DateTimeKind.Local).AddTicks(5016), "Wilbert95@hotmail.com", "Wilbert", "Wisoky", "7e6eed1d9c042074dae3fde6f63467360b59e289", "(517) 445-1446" },
                    { new Guid("bc4bc437-55aa-8b62-8c2b-18e0cd5c9bfc"), new DateTime(2013, 1, 3, 23, 58, 50, 476, DateTimeKind.Local).AddTicks(2664), "Leo.Erdman@yahoo.com", "Leo", "Erdman", "6696cd5ca33499534cd45b3b847c9c2cf14f4e46", "(990) 777-9693" },
                    { new Guid("be554221-800d-9ad8-5223-59ddc35f14c5"), new DateTime(2019, 1, 11, 1, 15, 33, 620, DateTimeKind.Local).AddTicks(3544), "Rudolph_Hoeger@hotmail.com", "Rudolph", "Hoeger", "f6c5b3d2b99b5403aa0f02a5b79b406186af3982", "(548) 522-4428" },
                    { new Guid("c4db5247-873b-a367-a696-4e3381d554fb"), new DateTime(2021, 7, 11, 4, 2, 41, 425, DateTimeKind.Local).AddTicks(7844), "Cornelius_Fritsch@gmail.com", "Cornelius", "Fritsch", "39c1fc4e7b5da570acade9281feb21dafb7cac48", "(728) 643-9623" },
                    { new Guid("c575c606-a34e-fd44-7e82-af826ac81c9f"), new DateTime(2022, 8, 6, 11, 35, 41, 833, DateTimeKind.Local).AddTicks(4776), "Melissa.Murphy19@gmail.com", "Melissa", "Murphy", "3e36f56340eac144197b34d457eee1ebea75eb36", "278-710-3919 x5763" },
                    { new Guid("c6c40add-8950-d07c-8035-85a24a774bbd"), new DateTime(2009, 1, 25, 7, 15, 16, 840, DateTimeKind.Local).AddTicks(275), "Rosie74@gmail.com", "Rosie", "Gottlieb", "a530852e57cf06dd7f35907298452085f44f98f3", "903.623.5171" },
                    { new Guid("c99faa7a-7cf4-63ef-ffc2-cbae2e49fb5e"), new DateTime(2016, 10, 27, 21, 39, 6, 583, DateTimeKind.Local).AddTicks(6152), "Stella_Veum4@gmail.com", "Stella", "Veum", "b7599e4fa2472f9c5dd4f96259ae997791e8e0bd", "829.353.3532" },
                    { new Guid("cbcc4709-fb18-4e92-be3f-e4776e1d33d2"), new DateTime(2011, 9, 10, 23, 35, 33, 908, DateTimeKind.Local).AddTicks(59), "Luke89@yahoo.com", "Luke", "Luettgen", "cb7c609cf9e39835d3e7aa7aa9454c841023d14f", "323.293.2489 x80858" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerID", "BirthDate", "EmailAddress", "FirstName", "LastName", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("cbd535a9-1a80-0ba8-c153-5a2e84f9f7de"), new DateTime(2008, 5, 26, 12, 45, 33, 782, DateTimeKind.Local).AddTicks(5327), "Lela_Smitham10@gmail.com", "Lela", "Smitham", "ec028d9864a0d0c3251fab9dbea9c43d90dd4dec", "1-980-532-9383" },
                    { new Guid("cde74099-fcfc-8fb7-2840-5935e2f5f8f0"), new DateTime(2007, 3, 28, 4, 15, 38, 619, DateTimeKind.Local).AddTicks(199), "Hope73@yahoo.com", "Hope", "Cummerata", "bfe4c1e21ac82170fc72de3180e47f923fdbf2bb", "1-553-407-4508" },
                    { new Guid("d0bcf422-3628-e72f-9351-e8b379128887"), new DateTime(2011, 3, 19, 2, 47, 21, 655, DateTimeKind.Local).AddTicks(3386), "Deanna.Stamm@hotmail.com", "Deanna", "Stamm", "6e1ddc14bb43b9468cb55dad9645a03033588283", "608-455-9087 x9648" },
                    { new Guid("d19441e0-72d6-a5bd-de53-4e3e027bfd56"), new DateTime(2012, 12, 22, 2, 2, 50, 932, DateTimeKind.Local).AddTicks(3502), "Kevin_Bauch@yahoo.com", "Kevin", "Bauch", "78dd4ec7dfffc677b38b9095c7326a4c97ac344b", "1-331-573-5161 x2016" },
                    { new Guid("d89c3929-883c-c907-e7cf-caae44cc636f"), new DateTime(2008, 11, 11, 13, 12, 5, 332, DateTimeKind.Local).AddTicks(3964), "Gayle.Bergnaum39@hotmail.com", "Gayle", "Bergnaum", "6be2294785c48cf4c881834b6fc1b98cf51de0e6", "810-360-2760 x553" },
                    { new Guid("dbb4dee9-5dcf-9328-d65a-c756511704cd"), new DateTime(2009, 4, 15, 2, 26, 55, 701, DateTimeKind.Local).AddTicks(8626), "Louise.Schinner@gmail.com", "Louise", "Schinner", "b1038b8c873fd877d0570adb0bb131f6107ae8b3", "(614) 301-3537" },
                    { new Guid("dbf5e900-8387-a592-66d6-49adbe48af83"), new DateTime(2016, 6, 23, 15, 33, 9, 46, DateTimeKind.Local).AddTicks(1605), "Cecilia.Okuneva@yahoo.com", "Cecilia", "Okuneva", "ac3755aedb138a9318ab1095447b0a36b94a38ab", "(438) 419-7689" },
                    { new Guid("df38650f-ce29-4c95-2e6d-a19b7340b9dc"), new DateTime(2021, 4, 5, 10, 35, 0, 751, DateTimeKind.Local).AddTicks(2069), "Ebony40@yahoo.com", "Ebony", "Bergnaum", "818624c5be4494432905eed667c85838a535c5d2", "1-986-404-1163" },
                    { new Guid("df9fb879-69ea-6a80-a1bc-0dd90ae51595"), new DateTime(2016, 7, 31, 14, 26, 57, 961, DateTimeKind.Local).AddTicks(4881), "Damon.Rogahn@gmail.com", "Damon", "Rogahn", "c152f1a9e545adcc52ed2f1e0a06586b05e4f3df", "958.703.1093 x14990" },
                    { new Guid("e0cc2552-7d05-0481-e223-37e03bfc9b3d"), new DateTime(2014, 8, 26, 5, 44, 28, 277, DateTimeKind.Local).AddTicks(1133), "Otis95@gmail.com", "Otis", "Nicolas", "f409cbc2551d26483a7b6def8339c44c529903ca", "714-699-0424" },
                    { new Guid("e385b60f-9bb7-6e04-28da-f5794b87077e"), new DateTime(2019, 5, 26, 23, 24, 58, 547, DateTimeKind.Local).AddTicks(2368), "Dorothy.Monahan24@yahoo.com", "Dorothy", "Monahan", "a1d26d62c5c7aa68616e7dcb9a68e639ef1e26ab", "595.926.7122" },
                    { new Guid("e631c0a4-2a4b-e936-886a-fb966aaa326e"), new DateTime(2019, 9, 28, 9, 38, 37, 206, DateTimeKind.Local).AddTicks(8895), "Becky.Wuckert95@yahoo.com", "Becky", "Wuckert", "3029ca80e769651864293da1fb26d74409d62595", "513-782-2233 x4444" },
                    { new Guid("e71c640d-36b4-1771-1522-4146833e0ab4"), new DateTime(2005, 5, 8, 18, 32, 51, 746, DateTimeKind.Local).AddTicks(3176), "Betty11@hotmail.com", "Betty", "Carroll", "5e199dea95da4fb7db3f11d8963bfc3604b41c7e", "(785) 613-0336" },
                    { new Guid("e9dc3518-cf04-8aba-2a25-2a3d8d41346d"), new DateTime(2012, 10, 23, 4, 56, 35, 816, DateTimeKind.Local).AddTicks(2256), "Kim_Medhurst38@hotmail.com", "Kim", "Medhurst", "2f46e6563ebab651513afa7cfc46939e582b8d38", "(261) 265-4344" },
                    { new Guid("f3747a63-d233-29be-5f35-8cd3f4618339"), new DateTime(2018, 8, 14, 7, 2, 0, 106, DateTimeKind.Local).AddTicks(2787), "Lawrence_Cummerata@gmail.com", "Lawrence", "Cummerata", "22f248bcb3774f3a932c422f1a220ffb699833a1", "1-778-399-3332 x41925" },
                    { new Guid("f3abb846-e323-701f-d0d4-71f618b7e13c"), new DateTime(2022, 3, 19, 12, 3, 0, 835, DateTimeKind.Local).AddTicks(9913), "Tim.Beatty0@gmail.com", "Tim", "Beatty", "7171a32feeddc100c3b45d9495a3e2b1bb582bbc", "(626) 832-4082 x12227" },
                    { new Guid("f5a65cc2-e0b4-9241-95be-679d44c02e6d"), new DateTime(2008, 9, 13, 3, 18, 0, 968, DateTimeKind.Local).AddTicks(5057), "Arturo_Hermann57@hotmail.com", "Arturo", "Hermann", "2be88aef4bee4d9b6a3d8f65af8b4094e559437b", "1-976-567-4057" },
                    { new Guid("f6e62421-573b-7e52-eb61-0e42f8525d73"), new DateTime(2013, 3, 17, 0, 41, 49, 942, DateTimeKind.Local).AddTicks(9335), "Jeannette11@gmail.com", "Jeannette", "Gibson", "d57ac23121eb69872474f2784ca4c52011fa3e26", "233.734.9333 x532" },
                    { new Guid("fa3ed639-6cd8-cde8-661e-558592b894e9"), new DateTime(2022, 2, 12, 8, 27, 38, 284, DateTimeKind.Local).AddTicks(8191), "Sylvester.Barrows67@yahoo.com", "Sylvester", "Barrows", "c452385f44122d41e517ec8cc3ab3dd5cdefd1a2", "418-419-3076 x7227" }
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
                name: "IX_Category_ParentCategoryID",
                table: "Category",
                column: "ParentCategoryID");

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
