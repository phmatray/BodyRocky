using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BodyRocky.Back.Server.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Stock = table.Column<int>(type: "int", nullable: false),
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Customer_UserId",
                        column: x => x.UserId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Customer_UserId",
                        column: x => x.UserId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Customer_UserId",
                        column: x => x.UserId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Customer_UserId",
                        column: x => x.UserId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "Id",
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
                        principalColumn: "Id",
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
                        principalColumn: "Id",
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
                        principalColumn: "Id",
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
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "3834f924-abb2-408b-aad8-fe850032bb01", "Administrator", "ADMINISTRATOR" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "2594e9e6-0891-419b-819b-a4547ada15ca", "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "BasketStatus",
                columns: new[] { "Code", "Description" },
                values: new object[,]
                {
                    { 1, "Basket is empty" },
                    { 2, "Basket is not empty" },
                    { 3, "Basket is paid" }
                });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "BrandID", "BrandLogo", "BrandName" },
                values: new object[,]
                {
                    { new Guid("0bf3561a-9991-29d4-ce39-8263dd0de6f4"), "https://picsum.photos/640/480/?image=202", "Bonnet - Benoit" },
                    { new Guid("0ff7bd5d-7afb-72a0-d8aa-f62c8441cdf7"), "https://picsum.photos/640/480/?image=45", "Picard - Charles" },
                    { new Guid("89acfb10-c061-8721-53b1-d060c8aa0ce0"), "https://picsum.photos/640/480/?image=475", "Moulin - Guillaume" },
                    { new Guid("959badbe-7bad-57b5-cd3c-f92f276eebd5"), "https://picsum.photos/640/480/?image=731", "Jean, Huet and Collet" },
                    { new Guid("963e205d-c089-03f5-23c8-ab1b097901d5"), "https://picsum.photos/640/480/?image=701", "Gonzalez, Remy and Laine" },
                    { new Guid("9ff33aaf-690f-bbc1-2c6f-ce2c728d04a5"), "https://picsum.photos/640/480/?image=932", "Duval EI" },
                    { new Guid("b2c36398-f822-2f8c-9e02-bd1e16f7c55a"), "https://picsum.photos/640/480/?image=433", "Petit SA" },
                    { new Guid("c2bba114-d677-a87e-9248-5a20bead30a8"), "https://picsum.photos/640/480/?image=762", "Vincent, Meunier and Guerin" },
                    { new Guid("cec876ad-01dd-e278-c9a2-a9307cb760db"), "https://picsum.photos/640/480/?image=428", "Dupuy, Lemaire and Royer" },
                    { new Guid("e3e45b65-eda4-a53a-66d0-9b1f8ed98efc"), "https://picsum.photos/640/480/?image=1068", "Carre, Carre and Denis" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "CategoryIcon", "CategoryImage", "CategoryName", "IsFeatured" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "fas fa-heartbeat", "/assets/images/category/category-1.jpg", "Cardio-training", true },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "fas fa-dumbbell", "/assets/images/category/category-2.jpg", "Musculation", true },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "fas fa-gamepad", "/assets/images/category/category-3.jpg", "Jeux et loisirs", true },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "fas fa-running", "/assets/images/category/category-4.jpg", "Fitness", true },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "fas fa-heart", "/assets/images/category/category-5.jpg", "Yoga et bien-être", true },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "fas fa-utensils", "/assets/images/category/category-6.jpg", "Nutrition", true }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("07a1c199-a361-a70c-8d56-5e0be9ab668d"), 0, new DateTime(1958, 11, 28, 9, 4, 53, 939, DateTimeKind.Local).AddTicks(223), "7b403d19-2ddd-4929-924d-e1e2b94c3d71", "Adeodat37@gmail.com", false, "Adéodat", "Charles", false, null, null, null, "f3e683b9d0e1f13c02be6ee37fce868ef2aa937f", "0358462738", false, null, false, null },
                    { new Guid("0bc5c6f3-fc94-95d7-3f60-8dbe5f29a0f3"), 0, new DateTime(1993, 4, 26, 5, 5, 47, 905, DateTimeKind.Local).AddTicks(5330), "5ad5ad05-88d1-43fa-887c-215820abbb94", "Eva55@gmail.com", false, "Eva", "Benoit", false, null, null, null, "a661fa87aa36dcfad6a61e9b6a8243268b0a5624", "+33 697348519", false, null, false, null },
                    { new Guid("3067ce0f-26f5-cbe2-3658-f6e2097985c9"), 0, new DateTime(2001, 5, 11, 10, 58, 14, 979, DateTimeKind.Local).AddTicks(1944), "1c78fff6-05af-456e-a040-957b395448f4", "Noe_Thomas@gmail.com", false, "Noé", "Thomas", false, null, null, null, "4fcc937c27f1afabbf69eab621bd286588f7c125", "0778898580", false, null, false, null },
                    { new Guid("3dc18ca3-d433-46b7-2bb7-fede0541b2e2"), 0, new DateTime(1980, 12, 16, 15, 51, 4, 501, DateTimeKind.Local).AddTicks(608), "65775873-c176-42e6-8438-c7b5a32297a2", "Gontran_Lecomte36@yahoo.fr", false, "Gontran", "Lecomte", false, null, null, null, "b24c3d525424a54dfaaa5bada8a3018e576a04bd", "+33 413889459", false, null, false, null },
                    { new Guid("42149efc-f6bd-fcae-1e25-1c0e19ff98cd"), 0, new DateTime(1996, 5, 14, 16, 24, 49, 732, DateTimeKind.Local).AddTicks(1510), "2594ac47-4a29-476e-996d-b2169ffbd589", "Azeline41@hotmail.fr", false, "Azeline", "Philippe", false, null, null, null, "1ac87b1965702ee5d635fa15a380e90373da051e", "0399349183", false, null, false, null },
                    { new Guid("458a456c-8df9-91d5-5a33-23befbc37dc4"), 0, new DateTime(1983, 3, 5, 23, 21, 59, 410, DateTimeKind.Local).AddTicks(8761), "4b3be0b7-e7d0-46c3-ae7a-93a921e6cda7", "Ismerie19@yahoo.fr", false, "Ismérie", "Dumas", false, null, null, null, "bd40bcce9f9c8d548d3634a989dae05d05d6943c", "+33 271369547", false, null, false, null },
                    { new Guid("561b0442-1aec-9820-ac82-85b2c117c985"), 0, new DateTime(1990, 12, 30, 23, 53, 38, 0, DateTimeKind.Local).AddTicks(7936), "a9076026-244d-46d2-99cf-01b36b7347fb", "Aurian.Lemoine@gmail.com", false, "Aurian", "Lemoine", false, null, null, null, "67c636d823b1e94506d9f1f702e6f1394a7b312f", "0149919088", false, null, false, null },
                    { new Guid("5791f4c3-ec49-99a9-feb9-5e0b4cb47393"), 0, new DateTime(1996, 11, 21, 20, 14, 36, 391, DateTimeKind.Local).AddTicks(730), "54a822ba-e81a-4c5a-9eea-ad1a739f3c9a", "Florestan.Renault@hotmail.fr", false, "Florestan", "Renault", false, null, null, null, "363c866db3b1d54872283b64a857f3e8d67d1286", "0160528989", false, null, false, null },
                    { new Guid("67776164-a3df-0c08-b108-ad5fe2fd2d57"), 0, new DateTime(1959, 1, 11, 19, 51, 31, 255, DateTimeKind.Local).AddTicks(1183), "bd2a7874-a6e3-41d1-a242-d508dde19a52", "Malo71@gmail.com", false, "Malo", "Guillot", false, null, null, null, "351b28b32955b0b6012a4f0acce9acaac2f97b61", "0693520435", false, null, false, null },
                    { new Guid("7167ba7f-98f7-0569-85bb-688c4c0311ab"), 0, new DateTime(1963, 7, 12, 4, 33, 54, 228, DateTimeKind.Local).AddTicks(689), "f16223ad-38fa-4922-9136-63b283e72936", "Arielle_Gauthier24@yahoo.fr", false, "Arielle", "Gauthier", false, null, null, null, "13543eccb3cab5ae822461b1731c19e1bca2e14c", "+33 224545666", false, null, false, null },
                    { new Guid("79221a30-cf83-d7a2-88d1-bf63caadffdb"), 0, new DateTime(1979, 6, 26, 12, 16, 44, 605, DateTimeKind.Local).AddTicks(3290), "e7fcb289-b680-4a49-ab12-0f823e2f76ce", "Francine_Dumont29@yahoo.fr", false, "Francine", "Dumont", false, null, null, null, "36e7d2d9954029fff5432707940ef16dfb476b6b", "0524340546", false, null, false, null },
                    { new Guid("7fc961d3-bcf7-bbe4-874a-3525029cb1a1"), 0, new DateTime(1963, 12, 7, 12, 47, 25, 416, DateTimeKind.Local).AddTicks(7968), "be17d4d8-d6de-44bb-86c7-dddfd3942a03", "Charlaine.Pierre4@yahoo.fr", false, "Charlaine", "Pierre", false, null, null, null, "d7d31d39f0447528657f25be92cc8b1955c98f65", "0704417211", false, null, false, null },
                    { new Guid("80daabae-208a-6346-c660-494b4f860da2"), 0, new DateTime(1999, 9, 10, 12, 54, 3, 664, DateTimeKind.Local).AddTicks(2101), "1dcbc5df-d985-410e-8ed3-a140107c6130", "Tancrede.Gonzalez@gmail.com", false, "Tancrède", "Gonzalez", false, null, null, null, "39127ecead933553b140c5b34e1b0ca7faa64df3", "0326800537", false, null, false, null },
                    { new Guid("81d4d6ef-04c8-dab5-021f-47017c30d4d8"), 0, new DateTime(1964, 4, 13, 21, 28, 7, 947, DateTimeKind.Local).AddTicks(3932), "87f91191-b317-43ab-b05e-ca5f1fdf7f84", "Judicael_Colin94@hotmail.fr", false, "Judicaël", "Colin", false, null, null, null, "6483171ba3999ad79a6fb7f05f9bd3896bd94db8", "0716419105", false, null, false, null },
                    { new Guid("cbf2964d-1bae-ca29-29fb-23c674b782d6"), 0, new DateTime(1991, 9, 6, 19, 58, 46, 582, DateTimeKind.Local).AddTicks(7997), "f6a50788-f6c0-4d62-bcb2-5ce1bda587f2", "Evariste.Marty20@hotmail.fr", false, "Évariste", "Marty", false, null, null, null, "7a2616180b8a78ab54365a382513e123e6409708", "0478662131", false, null, false, null },
                    { new Guid("d28df60d-f13f-18e1-8041-72436935a631"), 0, new DateTime(2002, 9, 23, 11, 36, 57, 710, DateTimeKind.Local).AddTicks(5631), "417f2467-0070-413a-b98f-505e573bc5bc", "Raymond70@hotmail.fr", false, "Raymond", "Berger", false, null, null, null, "78afe545cd2f75a2af7860ffbd93a3e9802d7a88", "0654548210", false, null, false, null },
                    { new Guid("e69b3c8e-90a8-8995-729a-e3f94af4d16e"), 0, new DateTime(1996, 9, 7, 1, 3, 48, 76, DateTimeKind.Local).AddTicks(3797), "6b6b7a6d-a7c7-4ca9-a553-33d9b9889190", "Pascale.Masson@yahoo.fr", false, "Pascale", "Masson", false, null, null, null, "fbd59ee4ecb49a818d8684dc51824814130d82a1", "0549452616", false, null, false, null },
                    { new Guid("f3cf5ea4-97bb-e8ff-251e-6f619b8a825f"), 0, new DateTime(1970, 4, 29, 22, 57, 22, 8, DateTimeKind.Local).AddTicks(1273), "c2a9efa8-1a63-4844-8e8e-7439e417e7c1", "Pepin.Sanchez95@hotmail.fr", false, "Pépin", "Sanchez", false, null, null, null, "53f10ac76c4655e033dd26e7cf26f6cff8231b91", "+33 688744471", false, null, false, null },
                    { new Guid("f6114d70-089e-bb22-de17-5829c4729b41"), 0, new DateTime(1995, 1, 11, 4, 29, 5, 444, DateTimeKind.Local).AddTicks(4955), "b62d1ace-0fe9-45f6-9f35-8be14d25e716", "Isidore_Chevalier@hotmail.fr", false, "Isidore", "Chevalier", false, null, null, null, "31dcb73e0df532ff97e8f1aeeb0afff740259e85", "0264562170", false, null, false, null },
                    { new Guid("fbef4564-7f5d-1879-0db4-fe5568685c0b"), 0, new DateTime(1997, 8, 25, 20, 15, 51, 875, DateTimeKind.Local).AddTicks(9271), "fda41bc0-26a2-4bd3-a2a7-d78b9eebc23a", "Venance_Rolland@yahoo.fr", false, "Venance", "Rolland", false, null, null, null, "36c82a1ac3af2825de9a84e3598701f0f8e0ecd1", "+33 372249350", false, null, false, null }
                });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Code", "Description" },
                values: new object[] { 1, "Order is created" });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Code", "Description" },
                values: new object[,]
                {
                    { 2, "Order is paid" },
                    { 3, "Order is shipped" },
                    { 4, "Order is delivered" },
                    { 5, "Order is cancelled" }
                });

            migrationBuilder.InsertData(
                table: "ZipCode",
                columns: new[] { "ZipCodeID", "Code", "Commune" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), 1000, "Bruxelles" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), 1030, "Schaerbeek" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), 1040, "Etterbeek" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), 1050, "Ixelles" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), 1060, "Saint-Gilles" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), 1070, "Anderlecht" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), 1080, "Molenbeek-Saint-Jean" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), 4000, "Liège" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), 4020, "Liège" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), 4030, "Grivegnée" },
                    { new Guid("00000000-0000-0000-0000-000000000011"), 4040, "Herstal" },
                    { new Guid("00000000-0000-0000-0000-000000000012"), 4050, "Chênée" },
                    { new Guid("00000000-0000-0000-0000-000000000013"), 4060, "Liège" },
                    { new Guid("00000000-0000-0000-0000-000000000014"), 4070, "Leernes" },
                    { new Guid("00000000-0000-0000-0000-000000000015"), 4100, "Seraing" },
                    { new Guid("00000000-0000-0000-0000-000000000016"), 4120, "Neupré" },
                    { new Guid("00000000-0000-0000-0000-000000000017"), 4130, "Esneux" },
                    { new Guid("00000000-0000-0000-0000-000000000018"), 4140, "Sprimont" },
                    { new Guid("00000000-0000-0000-0000-000000000019"), 4150, "Comblain-au-Pont" },
                    { new Guid("00000000-0000-0000-0000-000000000020"), 4160, "Ans" },
                    { new Guid("00000000-0000-0000-0000-000000000021"), 4170, "Faymonville" },
                    { new Guid("00000000-0000-0000-0000-000000000022"), 4180, "Hamoir" },
                    { new Guid("00000000-0000-0000-0000-000000000023"), 4190, "Fexhe-le-Haut-Clocher" },
                    { new Guid("00000000-0000-0000-0000-000000000024"), 4600, "Visé" },
                    { new Guid("00000000-0000-0000-0000-000000000025"), 4620, "Fléron" },
                    { new Guid("00000000-0000-0000-0000-000000000026"), 4630, "Soumagne" },
                    { new Guid("00000000-0000-0000-0000-000000000027"), 4650, "Herve" }
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "AddressID", "AddressFromDate", "AddressToDate", "CustomerID", "Street", "ZipCodeID" },
                values: new object[,]
                {
                    { new Guid("0943f8b1-56d4-45de-bc7f-aeb6583a12be"), new DateTime(2022, 7, 7, 8, 5, 6, 32, DateTimeKind.Local).AddTicks(7959), new DateTime(2022, 11, 27, 21, 26, 31, 724, DateTimeKind.Local).AddTicks(816), new Guid("5791f4c3-ec49-99a9-feb9-5e0b4cb47393"), "204 Rue Montorgueil", new Guid("00000000-0000-0000-0000-000000000015") },
                    { new Guid("0e6689d5-6585-a789-78a2-e14951e6fbf4"), new DateTime(2022, 4, 15, 9, 14, 8, 93, DateTimeKind.Local).AddTicks(1321), new DateTime(2023, 3, 20, 2, 12, 51, 813, DateTimeKind.Local).AddTicks(813), new Guid("3067ce0f-26f5-cbe2-3658-f6e2097985c9"), "4526 Boulevard Du Sommerard", new Guid("00000000-0000-0000-0000-000000000018") },
                    { new Guid("273a921a-6ae7-b355-c222-b844880f8631"), new DateTime(2022, 3, 16, 9, 29, 59, 484, DateTimeKind.Local).AddTicks(9584), new DateTime(2023, 1, 21, 9, 3, 12, 339, DateTimeKind.Local).AddTicks(7026), new Guid("f3cf5ea4-97bb-e8ff-251e-6f619b8a825f"), "4 Allée de Montmorency", new Guid("00000000-0000-0000-0000-000000000023") },
                    { new Guid("284b0e83-f01b-d412-c9c1-89b3635e7a57"), new DateTime(2022, 7, 26, 21, 31, 11, 905, DateTimeKind.Local).AddTicks(3921), new DateTime(2023, 4, 20, 23, 21, 52, 102, DateTimeKind.Local).AddTicks(4910), new Guid("7fc961d3-bcf7-bbe4-874a-3525029cb1a1"), "237 Rue de Tilsitt", new Guid("00000000-0000-0000-0000-000000000016") },
                    { new Guid("325118fe-e3cd-a35d-e1b0-55f32ffcad88"), new DateTime(2021, 11, 20, 8, 46, 9, 378, DateTimeKind.Local).AddTicks(2249), new DateTime(2023, 1, 20, 6, 55, 3, 177, DateTimeKind.Local).AddTicks(9286), new Guid("cbf2964d-1bae-ca29-29fb-23c674b782d6"), "9 Passage de Vaugirard", new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("3c874743-4e21-6771-f701-6b27896fa1a2"), new DateTime(2022, 10, 7, 0, 39, 4, 58, DateTimeKind.Local).AddTicks(2171), new DateTime(2023, 8, 4, 7, 37, 3, 333, DateTimeKind.Local).AddTicks(3024), new Guid("81d4d6ef-04c8-dab5-021f-47017c30d4d8"), "2803 Impasse Marcadet", new Guid("00000000-0000-0000-0000-000000000012") },
                    { new Guid("58769ddb-357c-3227-12c0-95f041fe198a"), new DateTime(2022, 7, 26, 20, 17, 44, 893, DateTimeKind.Local).AddTicks(9077), new DateTime(2023, 10, 14, 21, 49, 47, 704, DateTimeKind.Local).AddTicks(271), new Guid("67776164-a3df-0c08-b108-ad5fe2fd2d57"), "019 Boulevard des Lombards", new Guid("00000000-0000-0000-0000-000000000027") },
                    { new Guid("75cdf11b-2678-f18d-2991-9327789d9d81"), new DateTime(2022, 10, 25, 2, 22, 54, 941, DateTimeKind.Local).AddTicks(6041), new DateTime(2023, 7, 10, 3, 47, 41, 755, DateTimeKind.Local).AddTicks(4562), new Guid("42149efc-f6bd-fcae-1e25-1c0e19ff98cd"), "7 Quai Pastourelle", new Guid("00000000-0000-0000-0000-000000000019") },
                    { new Guid("80daabae-208a-6346-c660-494b4f860da2"), new DateTime(2022, 8, 26, 13, 35, 6, 297, DateTimeKind.Local).AddTicks(3017), new DateTime(2023, 6, 17, 13, 55, 50, 739, DateTimeKind.Local).AddTicks(7581), new Guid("561b0442-1aec-9820-ac82-85b2c117c985"), "9686 Place Saint-Bernard", new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("84c46b8c-7b3a-ec0d-638e-eb028298bdb7"), new DateTime(2022, 2, 26, 16, 21, 20, 813, DateTimeKind.Local).AddTicks(3723), new DateTime(2023, 6, 27, 9, 26, 28, 201, DateTimeKind.Local).AddTicks(3674), new Guid("d28df60d-f13f-18e1-8041-72436935a631"), "0053 Quai Saint-Séverin", new Guid("00000000-0000-0000-0000-000000000027") },
                    { new Guid("8ea0ef5a-9b3c-a8e6-9095-89729ae3f94a"), new DateTime(2022, 4, 5, 6, 3, 59, 616, DateTimeKind.Local).AddTicks(5026), new DateTime(2023, 6, 23, 19, 41, 36, 753, DateTimeKind.Local).AddTicks(6561), new Guid("f6114d70-089e-bb22-de17-5829c4729b41"), "5 Impasse de la Huchette", new Guid("00000000-0000-0000-0000-000000000025") },
                    { new Guid("982b09c2-6472-ef45-fb5d-7f79180db4fe"), new DateTime(2022, 9, 11, 1, 33, 30, 667, DateTimeKind.Local).AddTicks(3481), new DateTime(2023, 3, 29, 23, 12, 21, 549, DateTimeKind.Local).AddTicks(9342), new Guid("458a456c-8df9-91d5-5a33-23befbc37dc4"), "8 Voie Laffitte", new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("a02fc451-2fdd-fec8-4685-9a6a2be27ebf"), new DateTime(2022, 7, 20, 10, 21, 58, 481, DateTimeKind.Local).AddTicks(9209), new DateTime(2023, 2, 27, 20, 5, 47, 355, DateTimeKind.Local).AddTicks(5482), new Guid("07a1c199-a361-a70c-8d56-5e0be9ab668d"), "22 Quai de Richelieu", new Guid("00000000-0000-0000-0000-000000000027") },
                    { new Guid("a51a82ae-0793-ddda-2c7b-3be63576d32f"), new DateTime(2022, 1, 29, 3, 3, 38, 559, DateTimeKind.Local).AddTicks(8138), new DateTime(2023, 3, 21, 1, 10, 22, 593, DateTimeKind.Local).AddTicks(3736), new Guid("7167ba7f-98f7-0569-85bb-688c4c0311ab"), "02 Rue Montorgueil", new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("a5dbdddd-a7a9-6432-5fd7-dcff14e93f2e"), new DateTime(2022, 4, 26, 18, 14, 7, 196, DateTimeKind.Local).AddTicks(2775), new DateTime(2023, 10, 26, 14, 47, 17, 661, DateTimeKind.Local).AddTicks(2485), new Guid("e69b3c8e-90a8-8995-729a-e3f94af4d16e"), "90 Impasse Lepic", new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("b0ccd308-6164-6777-dfa3-080cb108ad5f"), new DateTime(2022, 2, 11, 5, 21, 11, 642, DateTimeKind.Local).AddTicks(4636), new DateTime(2023, 2, 17, 15, 18, 52, 216, DateTimeKind.Local).AddTicks(3479), new Guid("80daabae-208a-6346-c660-494b4f860da2"), "7 Avenue de Paris", new Guid("00000000-0000-0000-0000-000000000015") },
                    { new Guid("b838bbdd-5cbb-5a88-866b-dc757111b9d8"), new DateTime(2022, 3, 1, 21, 10, 14, 988, DateTimeKind.Local).AddTicks(2518), new DateTime(2023, 9, 24, 12, 39, 59, 839, DateTimeKind.Local).AddTicks(7116), new Guid("3dc18ca3-d433-46b7-2bb7-fede0541b2e2"), "4860 Avenue Saint-Honoré", new Guid("00000000-0000-0000-0000-000000000016") },
                    { new Guid("cf5ea489-bbf3-ff97-e825-1e6f619b8a82"), new DateTime(2022, 4, 29, 1, 43, 8, 842, DateTimeKind.Local).AddTicks(1624), new DateTime(2023, 3, 24, 4, 44, 38, 93, DateTimeKind.Local).AddTicks(3838), new Guid("0bc5c6f3-fc94-95d7-3f60-8dbe5f29a0f3"), "7 Allée Pierre Charron", new Guid("00000000-0000-0000-0000-000000000011") },
                    { new Guid("d1b897fc-7777-027f-b858-964806e03621"), new DateTime(2021, 12, 27, 21, 51, 15, 781, DateTimeKind.Local).AddTicks(5160), new DateTime(2023, 9, 7, 21, 54, 28, 469, DateTimeKind.Local).AddTicks(9603), new Guid("fbef4564-7f5d-1879-0db4-fe5568685c0b"), "151 Avenue Royale", new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("e6113381-49ab-9056-a7fe-4f5b3ecdf292"), new DateTime(2022, 1, 27, 17, 30, 55, 686, DateTimeKind.Local).AddTicks(3539), new DateTime(2023, 7, 7, 2, 58, 35, 125, DateTimeKind.Local).AddTicks(6493), new Guid("79221a30-cf83-d7a2-88d1-bf63caadffdb"), "2 Quai Lepic", new Guid("00000000-0000-0000-0000-000000000027") }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductID", "BrandID", "IsFeatured", "ProductDescription", "ProductName", "ProductPrice", "ProductURL", "Stock" },
                values: new object[,]
                {
                    { new Guid("00198edd-5b14-db4d-98d6-46547cdc0fcf"), new Guid("963e205d-c089-03f5-23c8-ab1b097901d5"), false, "The Football Is Good For Training And Recreational Purposes", "Rustic Concrete Keyboard", 96.057952147004200m, "https://picsum.photos/640/480/?image=287", 27 },
                    { new Guid("01f3c360-44c8-fe9c-c2d3-5ad9080c8ee2"), new Guid("b2c36398-f822-2f8c-9e02-bd1e16f7c55a"), true, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Generic Wooden Table", 83.311585468850800m, "https://picsum.photos/640/480/?image=494", 39 },
                    { new Guid("0797f534-fadd-01e0-e3c7-744031a741ff"), new Guid("89acfb10-c061-8721-53b1-d060c8aa0ce0"), true, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Tasty Concrete Mouse", 50.397127284853300m, "https://picsum.photos/640/480/?image=921", 30 },
                    { new Guid("0868ca33-5e9c-2d85-a8a2-c626afb459b9"), new Guid("cec876ad-01dd-e278-c9a2-a9307cb760db"), false, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Incredible Concrete Pants", 48.957409313394400m, "https://picsum.photos/640/480/?image=95", 42 },
                    { new Guid("0aba08bd-d3c8-50fd-da13-e6885f4fe3ef"), new Guid("89acfb10-c061-8721-53b1-d060c8aa0ce0"), true, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Gorgeous Metal Chair", 90.994376219340800m, "https://picsum.photos/640/480/?image=788", 39 },
                    { new Guid("11788f1c-7e70-9973-6f3d-c9ff72df695f"), new Guid("e3e45b65-eda4-a53a-66d0-9b1f8ed98efc"), false, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Small Frozen Pizza", 79.048832170222400m, "https://picsum.photos/640/480/?image=929", 31 },
                    { new Guid("12516d98-b066-c9b3-d192-2d6b8c3aefa9"), new Guid("0ff7bd5d-7afb-72a0-d8aa-f62c8441cdf7"), true, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Awesome Fresh Mouse", 3.1164264786599300m, "https://picsum.photos/640/480/?image=829", 12 },
                    { new Guid("178f0af8-6f57-8317-367e-546d239cc4e4"), new Guid("963e205d-c089-03f5-23c8-ab1b097901d5"), true, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Intelligent Cotton Bacon", 14.598600200656200m, "https://picsum.photos/640/480/?image=751", 17 },
                    { new Guid("18a74a15-fb01-0fcc-ed52-b2e56ed58b61"), new Guid("c2bba114-d677-a87e-9248-5a20bead30a8"), true, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Tasty Cotton Fish", 2.6719768544062900m, "https://picsum.photos/640/480/?image=70", 45 },
                    { new Guid("1ced7148-00cb-5470-b985-9f6e96ac0cd1"), new Guid("b2c36398-f822-2f8c-9e02-bd1e16f7c55a"), false, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Awesome Cotton Table", 1.2579862965540900m, "https://picsum.photos/640/480/?image=941", 14 },
                    { new Guid("1dfb0fba-f84d-f97f-c301-8f9c6294cc89"), new Guid("959badbe-7bad-57b5-cd3c-f92f276eebd5"), true, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Generic Concrete Sausages", 90.101110511506500m, "https://picsum.photos/640/480/?image=311", 10 },
                    { new Guid("20bd175b-c07a-47ef-9d9c-5f5148e00d33"), new Guid("89acfb10-c061-8721-53b1-d060c8aa0ce0"), true, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Ergonomic Fresh Mouse", 53.488236411236300m, "https://picsum.photos/640/480/?image=501", 9 },
                    { new Guid("20c2ce26-a22d-5015-986b-7777c3f0829e"), new Guid("89acfb10-c061-8721-53b1-d060c8aa0ce0"), true, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Sleek Fresh Gloves", 23.144258243564600m, "https://picsum.photos/640/480/?image=363", 47 },
                    { new Guid("21a42ee3-d89d-3a55-1b4a-11ea069ce217"), new Guid("9ff33aaf-690f-bbc1-2c6f-ce2c728d04a5"), true, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Intelligent Concrete Hat", 13.065798540164600m, "https://picsum.photos/640/480/?image=545", 50 },
                    { new Guid("2385d5b6-ce7b-8ea6-ec05-04b4d61de53b"), new Guid("c2bba114-d677-a87e-9248-5a20bead30a8"), false, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Awesome Cotton Computer", 28.704484938040600m, "https://picsum.photos/640/480/?image=729", 8 },
                    { new Guid("262d0f2a-ec33-b582-ffcc-e8d7452f46b8"), new Guid("0ff7bd5d-7afb-72a0-d8aa-f62c8441cdf7"), false, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Handmade Rubber Computer", 94.822335101115700m, "https://picsum.photos/640/480/?image=296", 13 },
                    { new Guid("2a5b0d13-9bb6-bbff-5ded-826351ed5dd2"), new Guid("959badbe-7bad-57b5-cd3c-f92f276eebd5"), false, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Ergonomic Steel Mouse", 31.67996952854100m, "https://picsum.photos/640/480/?image=507", 3 },
                    { new Guid("2d43389b-2dc3-6813-0eb0-49b5dc0a55f1"), new Guid("e3e45b65-eda4-a53a-66d0-9b1f8ed98efc"), true, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Sleek Frozen Pizza", 80.496113505445500m, "https://picsum.photos/640/480/?image=692", 9 },
                    { new Guid("3241e82d-aa2e-7d68-9601-1a198e6f1423"), new Guid("959badbe-7bad-57b5-cd3c-f92f276eebd5"), false, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Handmade Fresh Car", 5.8141218525423300m, "https://picsum.photos/640/480/?image=1004", 34 },
                    { new Guid("3307a7ec-06d3-3386-26a0-6d843ee1e8d3"), new Guid("89acfb10-c061-8721-53b1-d060c8aa0ce0"), true, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Small Concrete Chips", 42.016366050586300m, "https://picsum.photos/640/480/?image=1021", 15 },
                    { new Guid("354cb9a6-8f3a-08b7-0c9a-7a296dc47ddb"), new Guid("0ff7bd5d-7afb-72a0-d8aa-f62c8441cdf7"), true, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Generic Fresh Computer", 8.3224875891220200m, "https://picsum.photos/640/480/?image=918", 43 },
                    { new Guid("357dcc32-5691-5a8d-1205-ac8fdbe918d8"), new Guid("963e205d-c089-03f5-23c8-ab1b097901d5"), true, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Small Cotton Salad", 74.96114833045800m, "https://picsum.photos/640/480/?image=289", 42 }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductID", "BrandID", "IsFeatured", "ProductDescription", "ProductName", "ProductPrice", "ProductURL", "Stock" },
                values: new object[,]
                {
                    { new Guid("367358ba-047b-1a78-a0d8-fdae03ccf60c"), new Guid("89acfb10-c061-8721-53b1-d060c8aa0ce0"), false, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Ergonomic Cotton Chair", 77.314188646764600m, "https://picsum.photos/640/480/?image=193", 8 },
                    { new Guid("397adeec-cba4-814e-bca1-999160bbafad"), new Guid("959badbe-7bad-57b5-cd3c-f92f276eebd5"), true, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Small Fresh Tuna", 70.443084077184600m, "https://picsum.photos/640/480/?image=715", 21 },
                    { new Guid("40281dfc-d3f6-f352-59c9-838cb3b0d9b5"), new Guid("89acfb10-c061-8721-53b1-d060c8aa0ce0"), false, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Licensed Cotton Towels", 40.546636674807700m, "https://picsum.photos/640/480/?image=816", 6 },
                    { new Guid("41e35278-54f7-a421-d0d5-4235826a55d5"), new Guid("0bf3561a-9991-29d4-ce39-8263dd0de6f4"), true, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Ergonomic Granite Pizza", 72.573548961697900m, "https://picsum.photos/640/480/?image=38", 22 },
                    { new Guid("42aa701f-9d67-1932-a0c7-51ef1191c7c7"), new Guid("c2bba114-d677-a87e-9248-5a20bead30a8"), true, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Refined Frozen Keyboard", 98.645073128233200m, "https://picsum.photos/640/480/?image=597", 26 },
                    { new Guid("45eef815-60f0-9d9e-8014-aa33d555ce32"), new Guid("959badbe-7bad-57b5-cd3c-f92f276eebd5"), false, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Incredible Cotton Cheese", 28.445317143781700m, "https://picsum.photos/640/480/?image=315", 38 },
                    { new Guid("46695d51-4ae2-4e69-b541-470c191b19f3"), new Guid("959badbe-7bad-57b5-cd3c-f92f276eebd5"), true, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Rustic Frozen Cheese", 67.607016473825600m, "https://picsum.photos/640/480/?image=1044", 48 },
                    { new Guid("482378f4-84cd-7503-a1a8-559dc4cadbb2"), new Guid("9ff33aaf-690f-bbc1-2c6f-ce2c728d04a5"), false, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Rustic Soft Ball", 3.803041579110100m, "https://picsum.photos/640/480/?image=722", 16 },
                    { new Guid("4a5a0968-b107-c9c2-686c-c11074d864b9"), new Guid("e3e45b65-eda4-a53a-66d0-9b1f8ed98efc"), false, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Fantastic Fresh Car", 63.863633230265100m, "https://picsum.photos/640/480/?image=41", 44 },
                    { new Guid("4ce28354-4f02-fc8e-7f24-9712aca2eb16"), new Guid("0ff7bd5d-7afb-72a0-d8aa-f62c8441cdf7"), false, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Ergonomic Fresh Shoes", 5.2641291195825300m, "https://picsum.photos/640/480/?image=421", 38 },
                    { new Guid("4d0b7f6e-a3b7-07c5-0c4f-0eeffd3e5c2f"), new Guid("b2c36398-f822-2f8c-9e02-bd1e16f7c55a"), false, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Rustic Fresh Salad", 90.681162006538900m, "https://picsum.photos/640/480/?image=639", 48 },
                    { new Guid("50c72d8a-02f3-2ce0-9ed3-00f5d102f243"), new Guid("89acfb10-c061-8721-53b1-d060c8aa0ce0"), true, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Tasty Plastic Gloves", 44.768989758924100m, "https://picsum.photos/640/480/?image=668", 6 },
                    { new Guid("5173998f-e412-7ef4-e58f-5fb68a0a3cb6"), new Guid("9ff33aaf-690f-bbc1-2c6f-ce2c728d04a5"), false, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Tasty Concrete Cheese", 20.966636864918600m, "https://picsum.photos/640/480/?image=83", 7 },
                    { new Guid("536227b5-2b5e-7408-ee52-2920143cc4d2"), new Guid("cec876ad-01dd-e278-c9a2-a9307cb760db"), false, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Fantastic Steel Shirt", 20.333191389373100m, "https://picsum.photos/640/480/?image=545", 2 },
                    { new Guid("559ccb10-47bd-bdf7-38e6-1f55045c5613"), new Guid("9ff33aaf-690f-bbc1-2c6f-ce2c728d04a5"), true, "The Football Is Good For Training And Recreational Purposes", "Small Rubber Car", 1.3081779709589600m, "https://picsum.photos/640/480/?image=630", 26 },
                    { new Guid("56185cda-dce2-0f1f-63bd-c90bcfd46f24"), new Guid("0bf3561a-9991-29d4-ce39-8263dd0de6f4"), false, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Generic Frozen Computer", 43.034367190224300m, "https://picsum.photos/640/480/?image=703", 16 },
                    { new Guid("58c86520-2f99-e425-c7eb-7c659f6f6b00"), new Guid("0bf3561a-9991-29d4-ce39-8263dd0de6f4"), false, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Handmade Metal Mouse", 30.77958046029300m, "https://picsum.photos/640/480/?image=743", 34 },
                    { new Guid("5a7ec381-7fe2-acea-e21f-5c1649fca189"), new Guid("c2bba114-d677-a87e-9248-5a20bead30a8"), false, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Tasty Wooden Car", 91.274773232301100m, "https://picsum.photos/640/480/?image=752", 33 },
                    { new Guid("5a886510-fe25-add2-276c-37e426e25df7"), new Guid("9ff33aaf-690f-bbc1-2c6f-ce2c728d04a5"), false, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Licensed Rubber Pizza", 69.504680004671500m, "https://picsum.photos/640/480/?image=398", 32 },
                    { new Guid("619106ff-ae24-0e2a-863b-52c4ecc94027"), new Guid("cec876ad-01dd-e278-c9a2-a9307cb760db"), false, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Unbranded Metal Fish", 4.3034310007018200m, "https://picsum.photos/640/480/?image=1079", 48 },
                    { new Guid("66a3bdf9-c10d-8be0-2283-e0772d50f146"), new Guid("0ff7bd5d-7afb-72a0-d8aa-f62c8441cdf7"), true, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Incredible Wooden Shirt", 74.111094220593200m, "https://picsum.photos/640/480/?image=924", 11 },
                    { new Guid("6864467e-5f9f-d6c5-b7eb-fa0b2d93e55b"), new Guid("cec876ad-01dd-e278-c9a2-a9307cb760db"), true, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Intelligent Metal Tuna", 28.093349201648200m, "https://picsum.photos/640/480/?image=765", 45 },
                    { new Guid("6b416013-854c-76a2-98e9-976c3da1eaaa"), new Guid("89acfb10-c061-8721-53b1-d060c8aa0ce0"), true, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Practical Soft Computer", 38.488092291396200m, "https://picsum.photos/640/480/?image=90", 43 },
                    { new Guid("6b5005aa-c70b-0b16-6855-917ee7830a5d"), new Guid("0ff7bd5d-7afb-72a0-d8aa-f62c8441cdf7"), false, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Tasty Granite Pizza", 27.538426792034200m, "https://picsum.photos/640/480/?image=1021", 41 },
                    { new Guid("6f8885d6-9bd1-f04d-f830-d75185fd6a9c"), new Guid("0ff7bd5d-7afb-72a0-d8aa-f62c8441cdf7"), true, "The Football Is Good For Training And Recreational Purposes", "Generic Plastic Shoes", 40.849673487641700m, "https://picsum.photos/640/480/?image=76", 25 },
                    { new Guid("73565ff8-60ad-f71d-ae1b-20cd4c67d4e4"), new Guid("959badbe-7bad-57b5-cd3c-f92f276eebd5"), true, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Awesome Granite Bike", 99.846159014779200m, "https://picsum.photos/640/480/?image=630", 11 },
                    { new Guid("7d155bd8-a4f7-bbfd-6622-91c135655075"), new Guid("89acfb10-c061-8721-53b1-d060c8aa0ce0"), false, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Ergonomic Frozen Towels", 39.105017128915100m, "https://picsum.photos/640/480/?image=273", 45 },
                    { new Guid("7da87366-4777-20a1-1cd2-8b582f1dab88"), new Guid("963e205d-c089-03f5-23c8-ab1b097901d5"), true, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Incredible Metal Salad", 56.220618521897400m, "https://picsum.photos/640/480/?image=778", 8 },
                    { new Guid("7dd70de1-b007-f0ba-b4af-b26d7650c8cf"), new Guid("c2bba114-d677-a87e-9248-5a20bead30a8"), true, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Gorgeous Wooden Keyboard", 73.315584367753700m, "https://picsum.photos/640/480/?image=922", 48 },
                    { new Guid("80c15b10-7c9a-4573-7aa6-8c1fc9c44355"), new Guid("9ff33aaf-690f-bbc1-2c6f-ce2c728d04a5"), false, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Unbranded Soft Hat", 36.422369133877700m, "https://picsum.photos/640/480/?image=1011", 18 },
                    { new Guid("85b6e154-074f-7b3e-6b24-96c9c21b39dc"), new Guid("e3e45b65-eda4-a53a-66d0-9b1f8ed98efc"), true, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Incredible Cotton Pizza", 2.4969059985582300m, "https://picsum.photos/640/480/?image=983", 37 },
                    { new Guid("87bb8a54-1311-fa41-a38c-f778d4cc2c00"), new Guid("e3e45b65-eda4-a53a-66d0-9b1f8ed98efc"), true, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Awesome Rubber Chair", 48.725120094011100m, "https://picsum.photos/640/480/?image=90", 26 },
                    { new Guid("88597dd9-b521-ed3a-99bf-694ea5199fb4"), new Guid("b2c36398-f822-2f8c-9e02-bd1e16f7c55a"), true, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Ergonomic Plastic Bacon", 1.2980640406245700m, "https://picsum.photos/640/480/?image=401", 31 },
                    { new Guid("8b50b158-7de2-1932-7fe2-5b45970bd08b"), new Guid("e3e45b65-eda4-a53a-66d0-9b1f8ed98efc"), false, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Refined Steel Bike", 69.411961720051200m, "https://picsum.photos/640/480/?image=748", 42 },
                    { new Guid("8b66cc42-6fa1-4b1c-a9a2-4f70a75779f5"), new Guid("89acfb10-c061-8721-53b1-d060c8aa0ce0"), false, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Awesome Plastic Sausages", 70.220573418876400m, "https://picsum.photos/640/480/?image=984", 39 },
                    { new Guid("8d793b7f-66cb-b6da-d0d6-d3e980fdc719"), new Guid("9ff33aaf-690f-bbc1-2c6f-ce2c728d04a5"), false, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Tasty Wooden Table", 87.3586162865900m, "https://picsum.photos/640/480/?image=730", 32 },
                    { new Guid("8d96b92c-fd82-57dc-7b38-add8e1c205c3"), new Guid("0ff7bd5d-7afb-72a0-d8aa-f62c8441cdf7"), false, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Generic Wooden Bacon", 23.710091609372800m, "https://picsum.photos/640/480/?image=520", 31 },
                    { new Guid("93e2b54b-aa79-15ec-31c3-ac145b9452a9"), new Guid("89acfb10-c061-8721-53b1-d060c8aa0ce0"), false, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Unbranded Wooden Soap", 97.489312383108400m, "https://picsum.photos/640/480/?image=693", 9 },
                    { new Guid("94262d4a-6ea3-b560-00e2-0611f72d9d4e"), new Guid("0ff7bd5d-7afb-72a0-d8aa-f62c8441cdf7"), false, "The Football Is Good For Training And Recreational Purposes", "Tasty Wooden Hat", 61.311507719248300m, "https://picsum.photos/640/480/?image=129", 36 },
                    { new Guid("951d5f89-e612-e4b6-2d5c-1a7304c14439"), new Guid("0bf3561a-9991-29d4-ce39-8263dd0de6f4"), true, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Intelligent Concrete Towels", 25.920053304135800m, "https://picsum.photos/640/480/?image=66", 7 },
                    { new Guid("9934347b-daf1-f79d-a538-5c619f6df048"), new Guid("963e205d-c089-03f5-23c8-ab1b097901d5"), false, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Generic Steel Computer", 47.637881500477800m, "https://picsum.photos/640/480/?image=344", 17 },
                    { new Guid("997fcf29-6d3a-0bf5-1a26-cb5299b64088"), new Guid("b2c36398-f822-2f8c-9e02-bd1e16f7c55a"), false, "The Football Is Good For Training And Recreational Purposes", "Unbranded Soft Chips", 31.185486275323400m, "https://picsum.photos/640/480/?image=283", 3 }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductID", "BrandID", "IsFeatured", "ProductDescription", "ProductName", "ProductPrice", "ProductURL", "Stock" },
                values: new object[,]
                {
                    { new Guid("a345a6cf-47e6-ef94-09c6-a848e9de1f90"), new Guid("89acfb10-c061-8721-53b1-d060c8aa0ce0"), true, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Handmade Granite Car", 48.363655781542700m, "https://picsum.photos/640/480/?image=688", 39 },
                    { new Guid("a4614cd6-cf56-c697-074d-02290cec4cca"), new Guid("963e205d-c089-03f5-23c8-ab1b097901d5"), true, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Ergonomic Cotton Computer", 80.735048270195300m, "https://picsum.photos/640/480/?image=1079", 3 },
                    { new Guid("a4e63818-3d6f-b63f-8141-f98d98b6b6a1"), new Guid("963e205d-c089-03f5-23c8-ab1b097901d5"), true, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Awesome Fresh Chair", 54.216184352625200m, "https://picsum.photos/640/480/?image=389", 3 },
                    { new Guid("a4fc61a1-e319-b704-4017-da743337b2b1"), new Guid("89acfb10-c061-8721-53b1-d060c8aa0ce0"), false, "The Football Is Good For Training And Recreational Purposes", "Gorgeous Concrete Shoes", 90.381531925118300m, "https://picsum.photos/640/480/?image=230", 28 },
                    { new Guid("a880f9ef-524a-f373-c109-4a8ea5a1ac4f"), new Guid("9ff33aaf-690f-bbc1-2c6f-ce2c728d04a5"), false, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Ergonomic Granite Shoes", 67.692539499929400m, "https://picsum.photos/640/480/?image=762", 23 },
                    { new Guid("a8927254-d684-205a-4b3e-86ec605d3bbb"), new Guid("cec876ad-01dd-e278-c9a2-a9307cb760db"), true, "The Football Is Good For Training And Recreational Purposes", "Handmade Wooden Fish", 9.6679049589056100m, "https://picsum.photos/640/480/?image=521", 16 },
                    { new Guid("ab090248-64bb-0b80-905d-eaaf307a704f"), new Guid("963e205d-c089-03f5-23c8-ab1b097901d5"), false, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Rustic Cotton Towels", 68.505734842506100m, "https://picsum.photos/640/480/?image=48", 50 },
                    { new Guid("acdcabd1-e7ec-0c11-9ad4-28fc36c62e4e"), new Guid("9ff33aaf-690f-bbc1-2c6f-ce2c728d04a5"), false, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Practical Fresh Towels", 0.84484284783007700m, "https://picsum.photos/640/480/?image=831", 37 },
                    { new Guid("acf72f1c-0ba0-6ee6-8799-8163be933871"), new Guid("e3e45b65-eda4-a53a-66d0-9b1f8ed98efc"), false, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Rustic Concrete Mouse", 85.878553328047800m, "https://picsum.photos/640/480/?image=1079", 25 },
                    { new Guid("b07c78ef-69f5-c1a1-c16b-8a89532e9cc3"), new Guid("963e205d-c089-03f5-23c8-ab1b097901d5"), false, "The Football Is Good For Training And Recreational Purposes", "Licensed Granite Shoes", 62.005672213624100m, "https://picsum.photos/640/480/?image=733", 26 },
                    { new Guid("b80442f7-f928-1fcc-9d47-ad55e06f9c79"), new Guid("e3e45b65-eda4-a53a-66d0-9b1f8ed98efc"), true, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Licensed Soft Sausages", 60.254187630607800m, "https://picsum.photos/640/480/?image=259", 19 },
                    { new Guid("b8f5e25e-08be-5d9f-8b7f-ad247e439b4d"), new Guid("89acfb10-c061-8721-53b1-d060c8aa0ce0"), false, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Tasty Metal Hat", 69.810464172535800m, "https://picsum.photos/640/480/?image=1046", 29 },
                    { new Guid("ba5dee9a-f07e-d630-d219-8ca3a0c6ebab"), new Guid("9ff33aaf-690f-bbc1-2c6f-ce2c728d04a5"), true, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Unbranded Fresh Chips", 53.662096920265900m, "https://picsum.photos/640/480/?image=551", 39 },
                    { new Guid("bd40f82c-8de4-9084-ec2c-20da1effb972"), new Guid("e3e45b65-eda4-a53a-66d0-9b1f8ed98efc"), true, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Rustic Concrete Table", 11.224380327027500m, "https://picsum.photos/640/480/?image=414", 15 },
                    { new Guid("bfb1410e-b36f-8ea6-42bf-822770deb57a"), new Guid("89acfb10-c061-8721-53b1-d060c8aa0ce0"), false, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Incredible Concrete Towels", 6.8890052879643600m, "https://picsum.photos/640/480/?image=592", 24 },
                    { new Guid("c334080c-037a-04c3-26dd-83f7845ad906"), new Guid("89acfb10-c061-8721-53b1-d060c8aa0ce0"), true, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Awesome Granite Keyboard", 81.241056360882300m, "https://picsum.photos/640/480/?image=43", 10 },
                    { new Guid("c48d9ab4-7f88-06e1-5914-4c46ca2655bd"), new Guid("cec876ad-01dd-e278-c9a2-a9307cb760db"), true, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Handmade Steel Gloves", 37.648282729856800m, "https://picsum.photos/640/480/?image=306", 43 },
                    { new Guid("cb0e852d-e88d-6107-495f-3a42b4bb2298"), new Guid("0ff7bd5d-7afb-72a0-d8aa-f62c8441cdf7"), true, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Intelligent Fresh Pizza", 38.445983193091100m, "https://picsum.photos/640/480/?image=469", 18 },
                    { new Guid("cf5cd576-cc4d-1b76-c021-d06de1bc32a6"), new Guid("89acfb10-c061-8721-53b1-d060c8aa0ce0"), true, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Generic Cotton Pizza", 13.238352915848800m, "https://picsum.photos/640/480/?image=969", 16 },
                    { new Guid("da9a7b35-39a4-60eb-1f9c-7fe717310d6c"), new Guid("b2c36398-f822-2f8c-9e02-bd1e16f7c55a"), false, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Gorgeous Granite Chair", 21.739130151336600m, "https://picsum.photos/640/480/?image=664", 8 },
                    { new Guid("db731e94-01cd-87d6-95dd-b9d854c7d48b"), new Guid("959badbe-7bad-57b5-cd3c-f92f276eebd5"), false, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Fantastic Frozen Ball", 97.21016418058900m, "https://picsum.photos/640/480/?image=922", 2 },
                    { new Guid("dc0062e5-01a3-3ce5-d28e-f02c55473ab6"), new Guid("c2bba114-d677-a87e-9248-5a20bead30a8"), true, "The Football Is Good For Training And Recreational Purposes", "Tasty Steel Chair", 52.794929292423200m, "https://picsum.photos/640/480/?image=268", 7 },
                    { new Guid("dcc5057d-dcfe-0aa7-bbf1-a396b83cefc5"), new Guid("c2bba114-d677-a87e-9248-5a20bead30a8"), false, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Tasty Cotton Gloves", 5.4074056937393800m, "https://picsum.photos/640/480/?image=922", 38 },
                    { new Guid("de5d4dc4-795a-7b16-4b88-2199c9bd37df"), new Guid("89acfb10-c061-8721-53b1-d060c8aa0ce0"), true, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Tasty Cotton Pizza", 42.250279543106600m, "https://picsum.photos/640/480/?image=138", 25 },
                    { new Guid("e541220e-b097-f689-0ae1-9f2fb9985393"), new Guid("cec876ad-01dd-e278-c9a2-a9307cb760db"), true, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Unbranded Rubber Gloves", 72.088482357602800m, "https://picsum.photos/640/480/?image=312", 25 },
                    { new Guid("e8e74b1d-98a2-c64a-e809-aaf81583e48c"), new Guid("e3e45b65-eda4-a53a-66d0-9b1f8ed98efc"), false, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Tasty Steel Chips", 92.933303766387200m, "https://picsum.photos/640/480/?image=53", 30 },
                    { new Guid("e9a3926e-0ffd-ee43-7454-52f6003a8526"), new Guid("cec876ad-01dd-e278-c9a2-a9307cb760db"), true, "The Football Is Good For Training And Recreational Purposes", "Unbranded Concrete Computer", 10.548925171861900m, "https://picsum.photos/640/480/?image=791", 33 },
                    { new Guid("ea74d7a3-ecb8-5d91-ee23-2b903cc5115c"), new Guid("9ff33aaf-690f-bbc1-2c6f-ce2c728d04a5"), false, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Awesome Soft Chair", 55.322217687648800m, "https://picsum.photos/640/480/?image=65", 15 },
                    { new Guid("eb49e933-809f-5b21-0b96-a41ccb6cc507"), new Guid("e3e45b65-eda4-a53a-66d0-9b1f8ed98efc"), false, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Gorgeous Soft Pizza", 77.894140350583100m, "https://picsum.photos/640/480/?image=952", 42 },
                    { new Guid("ec884000-2725-ba32-548e-f6b02e88c718"), new Guid("959badbe-7bad-57b5-cd3c-f92f276eebd5"), false, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Handcrafted Plastic Keyboard", 87.802649889049400m, "https://picsum.photos/640/480/?image=268", 17 },
                    { new Guid("efe163cf-5e65-cf57-92ae-af6d492557c8"), new Guid("c2bba114-d677-a87e-9248-5a20bead30a8"), true, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Licensed Metal Salad", 16.655154440857100m, "https://picsum.photos/640/480/?image=99", 27 },
                    { new Guid("f0e10061-5dfa-1c89-47c1-205ec882018f"), new Guid("0ff7bd5d-7afb-72a0-d8aa-f62c8441cdf7"), true, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Ergonomic Rubber Keyboard", 3.1668612748230200m, "https://picsum.photos/640/480/?image=398", 46 },
                    { new Guid("f1d2a016-dc1c-99aa-a2da-0839bb2d3cf7"), new Guid("9ff33aaf-690f-bbc1-2c6f-ce2c728d04a5"), false, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Sleek Frozen Table", 29.698811345593400m, "https://picsum.photos/640/480/?image=685", 26 },
                    { new Guid("f2e2f601-4cfa-c93f-a28d-6a8d66dee66e"), new Guid("959badbe-7bad-57b5-cd3c-f92f276eebd5"), false, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Rustic Wooden Chips", 39.078262093979100m, "https://picsum.photos/640/480/?image=958", 43 },
                    { new Guid("f2e825f8-0cff-90d7-07a2-31f1ba7e18aa"), new Guid("cec876ad-01dd-e278-c9a2-a9307cb760db"), true, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Incredible Granite Hat", 19.314521513560100m, "https://picsum.photos/640/480/?image=760", 36 },
                    { new Guid("f9fc6035-b68b-4159-bd9f-10f52b831d26"), new Guid("0bf3561a-9991-29d4-ce39-8263dd0de6f4"), false, "The Football Is Good For Training And Recreational Purposes", "Incredible Wooden Pizza", 81.274550259706800m, "https://picsum.photos/640/480/?image=444", 46 }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryID", "ProductID" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00198edd-5b14-db4d-98d6-46547cdc0fcf") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("01f3c360-44c8-fe9c-c2d3-5ad9080c8ee2") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("0797f534-fadd-01e0-e3c7-744031a741ff") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("0868ca33-5e9c-2d85-a8a2-c626afb459b9") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("0aba08bd-d3c8-50fd-da13-e6885f4fe3ef") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("11788f1c-7e70-9973-6f3d-c9ff72df695f") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("12516d98-b066-c9b3-d192-2d6b8c3aefa9") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("178f0af8-6f57-8317-367e-546d239cc4e4") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("18a74a15-fb01-0fcc-ed52-b2e56ed58b61") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("1ced7148-00cb-5470-b985-9f6e96ac0cd1") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("1dfb0fba-f84d-f97f-c301-8f9c6294cc89") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("20bd175b-c07a-47ef-9d9c-5f5148e00d33") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("20c2ce26-a22d-5015-986b-7777c3f0829e") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("21a42ee3-d89d-3a55-1b4a-11ea069ce217") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("2385d5b6-ce7b-8ea6-ec05-04b4d61de53b") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("262d0f2a-ec33-b582-ffcc-e8d7452f46b8") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("2a5b0d13-9bb6-bbff-5ded-826351ed5dd2") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("2d43389b-2dc3-6813-0eb0-49b5dc0a55f1") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("3241e82d-aa2e-7d68-9601-1a198e6f1423") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("3307a7ec-06d3-3386-26a0-6d843ee1e8d3") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("354cb9a6-8f3a-08b7-0c9a-7a296dc47ddb") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("357dcc32-5691-5a8d-1205-ac8fdbe918d8") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("367358ba-047b-1a78-a0d8-fdae03ccf60c") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("397adeec-cba4-814e-bca1-999160bbafad") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("40281dfc-d3f6-f352-59c9-838cb3b0d9b5") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("41e35278-54f7-a421-d0d5-4235826a55d5") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("42aa701f-9d67-1932-a0c7-51ef1191c7c7") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("45eef815-60f0-9d9e-8014-aa33d555ce32") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("46695d51-4ae2-4e69-b541-470c191b19f3") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("482378f4-84cd-7503-a1a8-559dc4cadbb2") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("4a5a0968-b107-c9c2-686c-c11074d864b9") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("4ce28354-4f02-fc8e-7f24-9712aca2eb16") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("4d0b7f6e-a3b7-07c5-0c4f-0eeffd3e5c2f") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("50c72d8a-02f3-2ce0-9ed3-00f5d102f243") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("5173998f-e412-7ef4-e58f-5fb68a0a3cb6") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("536227b5-2b5e-7408-ee52-2920143cc4d2") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("559ccb10-47bd-bdf7-38e6-1f55045c5613") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("56185cda-dce2-0f1f-63bd-c90bcfd46f24") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("58c86520-2f99-e425-c7eb-7c659f6f6b00") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("5a7ec381-7fe2-acea-e21f-5c1649fca189") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("5a886510-fe25-add2-276c-37e426e25df7") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("619106ff-ae24-0e2a-863b-52c4ecc94027") }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryID", "ProductID" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("66a3bdf9-c10d-8be0-2283-e0772d50f146") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("6864467e-5f9f-d6c5-b7eb-fa0b2d93e55b") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("6b416013-854c-76a2-98e9-976c3da1eaaa") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("6b5005aa-c70b-0b16-6855-917ee7830a5d") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("6f8885d6-9bd1-f04d-f830-d75185fd6a9c") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("73565ff8-60ad-f71d-ae1b-20cd4c67d4e4") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("7d155bd8-a4f7-bbfd-6622-91c135655075") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("7da87366-4777-20a1-1cd2-8b582f1dab88") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("7dd70de1-b007-f0ba-b4af-b26d7650c8cf") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("80c15b10-7c9a-4573-7aa6-8c1fc9c44355") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("85b6e154-074f-7b3e-6b24-96c9c21b39dc") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("87bb8a54-1311-fa41-a38c-f778d4cc2c00") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("88597dd9-b521-ed3a-99bf-694ea5199fb4") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("8b50b158-7de2-1932-7fe2-5b45970bd08b") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("8b66cc42-6fa1-4b1c-a9a2-4f70a75779f5") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("8d793b7f-66cb-b6da-d0d6-d3e980fdc719") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("8d96b92c-fd82-57dc-7b38-add8e1c205c3") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("93e2b54b-aa79-15ec-31c3-ac145b9452a9") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("94262d4a-6ea3-b560-00e2-0611f72d9d4e") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("951d5f89-e612-e4b6-2d5c-1a7304c14439") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("9934347b-daf1-f79d-a538-5c619f6df048") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("997fcf29-6d3a-0bf5-1a26-cb5299b64088") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("a345a6cf-47e6-ef94-09c6-a848e9de1f90") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("a4614cd6-cf56-c697-074d-02290cec4cca") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("a4e63818-3d6f-b63f-8141-f98d98b6b6a1") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("a4fc61a1-e319-b704-4017-da743337b2b1") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("a880f9ef-524a-f373-c109-4a8ea5a1ac4f") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("a8927254-d684-205a-4b3e-86ec605d3bbb") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("ab090248-64bb-0b80-905d-eaaf307a704f") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("acdcabd1-e7ec-0c11-9ad4-28fc36c62e4e") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("acf72f1c-0ba0-6ee6-8799-8163be933871") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("b07c78ef-69f5-c1a1-c16b-8a89532e9cc3") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("b80442f7-f928-1fcc-9d47-ad55e06f9c79") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("b8f5e25e-08be-5d9f-8b7f-ad247e439b4d") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("ba5dee9a-f07e-d630-d219-8ca3a0c6ebab") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("bd40f82c-8de4-9084-ec2c-20da1effb972") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("bfb1410e-b36f-8ea6-42bf-822770deb57a") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("c334080c-037a-04c3-26dd-83f7845ad906") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("c48d9ab4-7f88-06e1-5914-4c46ca2655bd") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("cb0e852d-e88d-6107-495f-3a42b4bb2298") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("cf5cd576-cc4d-1b76-c021-d06de1bc32a6") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("da9a7b35-39a4-60eb-1f9c-7fe717310d6c") }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryID", "ProductID" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("db731e94-01cd-87d6-95dd-b9d854c7d48b") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("dc0062e5-01a3-3ce5-d28e-f02c55473ab6") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("dcc5057d-dcfe-0aa7-bbf1-a396b83cefc5") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("de5d4dc4-795a-7b16-4b88-2199c9bd37df") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("e541220e-b097-f689-0ae1-9f2fb9985393") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("e8e74b1d-98a2-c64a-e809-aaf81583e48c") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("e9a3926e-0ffd-ee43-7454-52f6003a8526") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("ea74d7a3-ecb8-5d91-ee23-2b903cc5115c") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("eb49e933-809f-5b21-0b96-a41ccb6cc507") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("ec884000-2725-ba32-548e-f6b02e88c718") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("efe163cf-5e65-cf57-92ae-af6d492557c8") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("f0e10061-5dfa-1c89-47c1-205ec882018f") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("f1d2a016-dc1c-99aa-a2da-0839bb2d3cf7") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("f2e2f601-4cfa-c93f-a28d-6a8d66dee66e") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("f2e825f8-0cff-90d7-07a2-31f1ba7e18aa") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("f9fc6035-b68b-4159-bd9f-10f52b831d26") }
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

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
                name: "EmailIndex",
                table: "Customer",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Customer",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

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
                name: "AspNetRoles");

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
