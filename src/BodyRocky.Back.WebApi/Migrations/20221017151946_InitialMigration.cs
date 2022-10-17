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
                    { new Guid("00000000-0000-0000-0000-000000000001"), "6ebf93f4-8493-4b1a-81ae-e983972dc65b", "Administrator", "ADMINISTRATOR" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "ebeb65f4-abc1-4062-87cb-a3e91bd29b9f", "Customer", "CUSTOMER" }
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
                    { new Guid("34af17e2-8958-422c-9b45-03d54869212c"), "fas fa-dumbbell", "/assets/images/category/category-2.jpg", "Musculation", true },
                    { new Guid("69f56e45-e95b-4694-b546-6cb76c0facac"), "fas fa-heart", "/assets/images/category/category-5.jpg", "Yoga et bien-être", true },
                    { new Guid("7fb37ecc-2549-4b70-866e-39da204c4bdb"), "fas fa-gamepad", "/assets/images/category/category-3.jpg", "Jeux et loisirs", true },
                    { new Guid("8ceeac06-1e28-4d24-8d56-ac9d1e44cfce"), "fas fa-utensils", "/assets/images/category/category-6.jpg", "Nutrition", true },
                    { new Guid("af32e8f8-1404-46fd-9a70-c1a136985eb9"), "fas fa-running", "/assets/images/category/category-4.jpg", "Fitness", true },
                    { new Guid("ec07b8e2-f9cc-41bd-8101-ad92ddb51ea4"), "fas fa-heartbeat", "/assets/images/category/category-1.jpg", "Cardio-training", true }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("09a1ceff-6067-cfcc-eeee-51e27ad836cf"), 0, new DateTime(2018, 7, 9, 11, 21, 2, 710, DateTimeKind.Local).AddTicks(4864), "70cca966-4bcb-4276-aa88-00d07808f6bf", "Laurence40@yahoo.com", false, "Laurence", "Orn", false, null, null, null, "6bb86560998d073a1b9ba1d5b931af91266d6ddd", "(236) 432-2476 x6727", false, null, false, null },
                    { new Guid("09cf3630-e958-88ab-34f5-562947070a64"), 0, new DateTime(2011, 4, 5, 1, 43, 21, 927, DateTimeKind.Local).AddTicks(9894), "11c6db68-ee93-435d-87ea-71558f800a62", "Miranda_Kautzer@yahoo.com", false, "Miranda", "Kautzer", false, null, null, null, "61e9b6a8243268b0a562447f3add7326a534cdab", "773.504.2410 x607", false, null, false, null },
                    { new Guid("0a135eb3-695a-2cd4-c170-213222bcdd0e"), 0, new DateTime(2016, 8, 29, 15, 40, 45, 47, DateTimeKind.Local).AddTicks(482), "10fed974-f988-44b3-afc2-160571a2d4e8", "Santos.Mosciski@yahoo.com", false, "Santos", "Mosciski", false, null, null, null, "8a399cd1fd098f0a8c0228ba23c7d86461fdfb41", "749-945-8869", false, null, false, null },
                    { new Guid("0e006fa9-de45-528c-0bae-9dd6207620e7"), 0, new DateTime(2008, 2, 6, 13, 21, 37, 155, DateTimeKind.Local).AddTicks(4719), "860c2dd8-a94e-4f26-9fbc-462c0e56fa70", "Joyce.Breitenberg@yahoo.com", false, "Joyce", "Breitenberg", false, null, null, null, "c9ec82fae34791da1559cdb081ddb3797e0ce2e5", "318-923-3924", false, null, false, null },
                    { new Guid("0efd67fc-9c2a-914b-66c4-f73f17803c80"), 0, new DateTime(2005, 9, 29, 8, 3, 36, 111, DateTimeKind.Local).AddTicks(5760), "91b6a4b8-dd61-4c54-bb87-a24dc1424aed", "Kim.Ruecker83@hotmail.com", false, "Kim", "Ruecker", false, null, null, null, "c04c18d317124d158a699d63a058af9378dd65b2", "(316) 420-1209 x9740", false, null, false, null },
                    { new Guid("16b4c4a0-2f35-237d-681b-bd453093a236"), 0, new DateTime(2005, 6, 15, 6, 55, 33, 532, DateTimeKind.Local).AddTicks(6158), "52bf904e-de45-43ff-99d0-b3c05850dd53", "Harold.Bogan@gmail.com", false, "Harold", "Bogan", false, null, null, null, "2aa937f9a85d813e69f69c15af86c16802d692cb", "(613) 923-3761 x211", false, null, false, null },
                    { new Guid("17577a5e-f5e7-ef5f-e697-f2ace5c8e0c2"), 0, new DateTime(2010, 2, 21, 15, 35, 14, 950, DateTimeKind.Local).AddTicks(1622), "3b5a0576-fa29-4412-8e98-10a5be9ad415", "Archie.Hahn@gmail.com", false, "Archie", "Hahn", false, null, null, null, "957157e78391aaa4af9916108bbfcbd03b6c7ea0", "813-979-0238 x51606", false, null, false, null },
                    { new Guid("23390a56-c1d1-1d60-1c75-2fa24374999a"), 0, new DateTime(2013, 10, 2, 2, 2, 47, 453, DateTimeKind.Local).AddTicks(8442), "67a0f6ab-fc9c-41c2-a9ef-2f05ac3136be", "Annie_Feil@hotmail.com", false, "Annie", "Feil", false, null, null, null, "64299fd04c627ec243ade12519e1f9a9ffd1ddb5", "1-715-969-4911 x17592", false, null, false, null },
                    { new Guid("241fdd79-d370-d294-5ba2-4214bf51b015"), 0, new DateTime(2006, 3, 26, 18, 1, 3, 755, DateTimeKind.Local).AddTicks(4603), "b34fa6be-75e2-4504-b320-421a1407b976", "Clay_Abshire@yahoo.com", false, "Clay", "Abshire", false, null, null, null, "c1130528318f54711024ffa98df995bf925e5304", "663.744.5518", false, null, false, null },
                    { new Guid("24a86f6c-5977-f46f-67dd-dddba5a9a732"), 0, new DateTime(2010, 9, 11, 21, 58, 49, 951, DateTimeKind.Local).AddTicks(2131), "b37d2736-d649-4c47-bbd7-b04b3ae136b3", "Glenda.Miller55@hotmail.com", false, "Glenda", "Miller", false, null, null, null, "c2f97b613f85667f540a1ab347f59196eb9912e5", "501-919-5456 x91797", false, null, false, null },
                    { new Guid("370d7448-f7f8-fe75-2c48-ac7cd88f0347"), 0, new DateTime(2016, 12, 29, 7, 9, 48, 726, DateTimeKind.Local).AddTicks(8876), "fa5191de-8976-4a72-9555-e8dd44d44fc1", "Olive97@hotmail.com", false, "Olive", "Hickle", false, null, null, null, "a382513e123e640970820b27036340be38d694c4", "1-576-378-1925", false, null, false, null },
                    { new Guid("3c5d782e-c346-d1a4-ea87-956078911a78"), 0, new DateTime(2011, 3, 23, 1, 13, 9, 135, DateTimeKind.Local).AddTicks(6238), "54d809bd-afcd-4e8f-be4d-cb48a471bf8a", "Becky42@yahoo.com", false, "Becky", "Jenkins", false, null, null, null, "10604579c6d7de9cf245bf6248b3c11ff1ea1dc1", "375-796-3358", false, null, false, null },
                    { new Guid("4c3865c2-4fa0-2030-ee84-adc09a2380c0"), 0, new DateTime(2009, 10, 21, 14, 59, 25, 234, DateTimeKind.Local).AddTicks(3939), "b8068cb1-f3d6-465b-8f12-aebd33da65b9", "Monica_Toy9@yahoo.com", false, "Monica", "Toy", false, null, null, null, "eff466ec72b71f1089bb20eb4a759cc6edeafcf7", "472.363.9783 x0777", false, null, false, null },
                    { new Guid("4ff0a3f7-1b7e-b61c-4dc4-04965e1306c6"), 0, new DateTime(2013, 6, 13, 11, 53, 1, 251, DateTimeKind.Local).AddTicks(4956), "433b2a5b-6a06-4978-bec0-22c132c18c8b", "Lloyd_Murphy@yahoo.com", false, "Lloyd", "Murphy", false, null, null, null, "0ce1e8101f9d3178d882f7060b08148a061b39dc", "400-844-7911 x196", false, null, false, null },
                    { new Guid("54515b47-693f-f4da-e89f-9862d69a44ab"), 0, new DateTime(2011, 3, 8, 12, 17, 1, 58, DateTimeKind.Local).AddTicks(6193), "c955db5b-16b8-4d8c-ae3d-f34c23107368", "Marcia_Blick47@yahoo.com", false, "Marcia", "Blick", false, null, null, null, "95ee6b9b17ccfd4fa44d4f2e4d52037573b4c3f8", "1-477-419-8185 x7652", false, null, false, null },
                    { new Guid("547a3a2a-9746-f1f7-0dc1-9f411376967d"), 0, new DateTime(2007, 9, 25, 0, 1, 31, 774, DateTimeKind.Local).AddTicks(3498), "e48ee5c5-1417-4a3b-bfc3-bdafd814788f", "Jeannie.Erdman98@yahoo.com", false, "Jeannie", "Erdman", false, null, null, null, "15e7b22540b89b81c33920eb1cde27f631f52e51", "(887) 331-9600 x582", false, null, false, null },
                    { new Guid("5c2b4042-627b-9bd8-71c2-8a4b10ba2dc3"), 0, new DateTime(2022, 10, 11, 20, 21, 7, 385, DateTimeKind.Local).AddTicks(491), "258f1d97-8348-4e2c-99d3-520e510a4fab", "Moses_Orn98@yahoo.com", false, "Moses", "Orn", false, null, null, null, "f6dd88a12ff0d731b9d97f95f6c49efd2b5e8575", "337.591.0174 x05854", false, null, false, null },
                    { new Guid("5cfc8e08-5314-1ffe-852b-cf7695022774"), 0, new DateTime(2013, 3, 6, 18, 37, 25, 630, DateTimeKind.Local).AddTicks(6589), "56618e78-dd7f-499f-9e91-50d31a273250", "Teri_Gleichner72@gmail.com", false, "Teri", "Gleichner", false, null, null, null, "e6f37227df1cfff027e5fd0a9129e478759a3156", "840-924-2437", false, null, false, null },
                    { new Guid("639e22a8-ebb5-9b66-f18f-64bce6951b54"), 0, new DateTime(2005, 6, 21, 8, 24, 18, 830, DateTimeKind.Local).AddTicks(2654), "20ded7a1-567d-432d-ae1b-aa45f227bd39", "Ebony35@gmail.com", false, "Ebony", "White", false, null, null, null, "b09ea9aa65cfbd7cb24c3d525424a54dfaaa5bad", "658-849-9321", false, null, false, null },
                    { new Guid("64b4e5c0-6541-cdce-487f-d0cf5e41bcdd"), 0, new DateTime(2019, 3, 11, 5, 53, 6, 195, DateTimeKind.Local).AddTicks(3337), "68f2eef3-c01e-4bed-b511-a436eef70f8c", "Gregory.Gibson@yahoo.com", false, "Gregory", "Gibson", false, null, null, null, "4b9c633ebd15025786d1696936cf719fe755c9ee", "(235) 878-4897 x002", false, null, false, null },
                    { new Guid("64bb2e44-3584-aec1-ee15-f67e8b1fe2d8"), 0, new DateTime(2014, 8, 19, 15, 39, 39, 530, DateTimeKind.Local).AddTicks(7698), "b3bccdec-1ca5-4665-b006-40167bbeaf17", "Vanessa.Lindgren4@yahoo.com", false, "Vanessa", "Lindgren", false, null, null, null, "0626d7d31d39f0447528657f25be92cc8b1955c9", "544.217.2112 x7292", false, null, false, null },
                    { new Guid("6569e4a5-16d0-f2e7-efd6-d481c804b5da"), 0, new DateTime(2006, 3, 20, 0, 38, 14, 846, DateTimeKind.Local).AddTicks(1609), "b587aadd-a05f-4572-8f60-9bdbeedcd66b", "Jacob.Zboncak27@gmail.com", false, "Jacob", "Zboncak", false, null, null, null, "57e1d6e7af3ed32bfe76dbb6a2440572be4ce9a1", "(725) 766-6845", false, null, false, null },
                    { new Guid("771b2a2f-d9a0-2f46-b75e-94585589f127"), 0, new DateTime(2013, 7, 9, 3, 10, 32, 448, DateTimeKind.Local).AddTicks(7754), "7f293e5f-ca1a-4207-ac1a-a7b9c906b440", "Owen.Kutch81@gmail.com", false, "Owen", "Kutch", false, null, null, null, "79c39c51c08e3db58556321310d4705d719c781c", "1-533-638-9063", false, null, false, null },
                    { new Guid("8e09c622-cfa5-b448-898b-fcdeeaed3264"), 0, new DateTime(2006, 1, 2, 15, 46, 34, 797, DateTimeKind.Local).AddTicks(5315), "a494396f-1ee3-4942-9757-511bdfc42a37", "Molly47@hotmail.com", false, "Molly", "Connelly", false, null, null, null, "1ca15085de48bdac3363c866db3b1d54872283b6", "287-431-0605 x289", false, null, false, null },
                    { new Guid("9a2731a6-8052-7fba-e7d5-859847ce1ba1"), 0, new DateTime(2007, 3, 8, 4, 35, 29, 770, DateTimeKind.Local).AddTicks(8178), "47e2ec17-59f2-4238-a5b4-49f6dfa347fc", "Beverly95@yahoo.com", false, "Beverly", "Pfeffer", false, null, null, null, "3f3a3b3b666a4c77c6eb2253b33fb31dcb73e0df", "785-350-1846", false, null, false, null },
                    { new Guid("9f9b9048-2e80-a16c-f77a-e0a6fe86ef5e"), 0, new DateTime(2005, 12, 17, 4, 59, 35, 649, DateTimeKind.Local).AddTicks(2175), "7534cc15-6d0d-4575-baa9-3912bd1cf9b9", "Alfredo_Conroy@gmail.com", false, "Alfredo", "Conroy", false, null, null, null, "7e6cadf7a519fabbd27bac9815c623c4dffa6781", "(902) 950-3406", false, null, false, null },
                    { new Guid("a20d864f-6e74-3fdf-6542-3bc4a7cc8183"), 0, new DateTime(2022, 4, 23, 17, 11, 16, 537, DateTimeKind.Local).AddTicks(2032), "5183d279-4833-462d-a90b-42dd4a0166a6", "Wesley1@gmail.com", false, "Wesley", "Heidenreich", false, null, null, null, "4a71661c3378db86f754d2e9fefb4b4fcc937c27", "(970) 276-4966", false, null, false, null },
                    { new Guid("bbe74b8f-4d35-5124-de8a-c572b6c207fe"), 0, new DateTime(2016, 11, 13, 11, 11, 45, 563, DateTimeKind.Local).AddTicks(9222), "35c64c6a-cf95-4a07-96e6-3801ece1425f", "Stacy_Effertz@hotmail.com", false, "Stacy", "Effertz", false, null, null, null, "d742462ecf3fc4d9d9e00bf5e9786fa48d422160", "(535) 793-4002", false, null, false, null },
                    { new Guid("c4919c93-3b57-f555-d360-0930100173c3"), 0, new DateTime(2016, 9, 6, 20, 57, 37, 221, DateTimeKind.Local).AddTicks(2745), "9b8bae72-8872-49a9-b2a0-2875ac1bc7b1", "Bethany24@gmail.com", false, "Bethany", "Hills", false, null, null, null, "b230ee58f7932edfd30b14d40052ea88b9e76299", "842.390.8806 x3055", false, null, false, null },
                    { new Guid("d1b897fc-7777-027f-b858-964806e03621"), 0, new DateTime(2016, 6, 28, 1, 49, 27, 879, DateTimeKind.Local).AddTicks(3370), "55b9ea0a-d443-4a6f-9040-8810b901958d", "Mable.Rolfson58@yahoo.com", false, "Mable", "Rolfson", false, null, null, null, "e033dd26e7cf26f6cff8231b914bbe0303ba850e", "408-259-3567 x43796", false, null, false, null },
                    { new Guid("d3a3a7af-ddc4-4ae6-f3f6-ce0e100862f8"), 0, new DateTime(2022, 6, 19, 2, 57, 10, 719, DateTimeKind.Local).AddTicks(4530), "6c21a593-7357-4d96-b6a2-eb32c7e9cf20", "Christian_Paucek38@yahoo.com", false, "Christian", "Paucek", false, null, null, null, "61e51ff968d560adc3ddf7ed1b8a12f0699907a2", "898.987.7942 x003", false, null, false, null },
                    { new Guid("d7eee062-cbfe-cb53-056f-5ba3e656b6a2"), 0, new DateTime(2007, 1, 28, 10, 42, 46, 89, DateTimeKind.Local).AddTicks(2869), "f2099306-bd4a-455b-a40e-5e6456ee1475", "Glen.Carter@gmail.com", false, "Glen", "Carter", false, null, null, null, "9954029fff5432707940ef16dfb476b6bc8caa33", "208-921-5192 x8048", false, null, false, null },
                    { new Guid("d94b91d5-6c77-2434-c3df-919814170af1"), 0, new DateTime(2009, 6, 15, 11, 42, 31, 440, DateTimeKind.Local).AddTicks(6158), "f7f0fe1a-2d92-4645-b35f-49e0a407e962", "Regina_Schinner@yahoo.com", false, "Regina", "Schinner", false, null, null, null, "1722ef008e510b639af0f2e6d29ef7a8f32a662b", "487-376-4865 x995", false, null, false, null },
                    { new Guid("e4d782a2-c14b-bfc5-cee8-432a323314b8"), 0, new DateTime(2011, 2, 8, 12, 17, 2, 810, DateTimeKind.Local).AddTicks(513), "678baa36-54c2-413b-bda3-f94e2b125640", "Myrtle.Tremblay@yahoo.com", false, "Myrtle", "Tremblay", false, null, null, null, "213a3fffc29dcfdf60eeb7a98ad9a5a81a61cf13", "(431) 650-9030", false, null, false, null },
                    { new Guid("e5d8d983-cc47-c0ad-a4e4-3223e8c09803"), 0, new DateTime(2016, 10, 18, 13, 49, 58, 14, DateTimeKind.Local).AddTicks(1500), "d136ef25-63ef-465f-ba2a-2fa0211edb6f", "Mable_Conn@yahoo.com", false, "Mable", "Conn", false, null, null, null, "0db5458ac49aca27fc5734013543eccb3cab5ae8", "422.982.7599", false, null, false, null },
                    { new Guid("e9bfd8b1-5a52-3800-6862-2b734d40cd00"), 0, new DateTime(2014, 8, 30, 11, 33, 31, 635, DateTimeKind.Local).AddTicks(2075), "57aa9804-ecc7-4daf-ac2f-3775b29ce66e", "Kate_Wiegand@gmail.com", false, "Kate", "Wiegand", false, null, null, null, "dd63b5ae0f3751ccaa157021025c871051051412", "1-449-983-0589 x903", false, null, false, null }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("ef5a7cad-8ea0-9b3c-e6a8-909589729ae3"), 0, new DateTime(2015, 8, 16, 19, 32, 58, 662, DateTimeKind.Local).AddTicks(7057), "f483d3cf-7231-47b3-86e8-1af4b3ec7742", "Duane_Moore37@hotmail.com", false, "Duane", "Moore", false, null, null, null, "b7359b9627fa8b91b712c73d06f712aae57b0f75", "1-825-765-0585 x45387", false, null, false, null },
                    { new Guid("f517f468-6424-0fe9-b705-96e2bddd731f"), 0, new DateTime(2012, 4, 21, 7, 11, 11, 174, DateTimeKind.Local).AddTicks(4246), "42bb9f9c-1494-4116-8399-b7016dd97f43", "Micheal1@hotmail.com", false, "Micheal", "Fay", false, null, null, null, "f1cf0567c636d823b1e94506d9f1f702e6f1394a", "(604) 399-1908 x8432", false, null, false, null },
                    { new Guid("f6bd4214-fcae-251e-1c0e-19ff98cd05d9"), 0, new DateTime(2012, 6, 12, 22, 7, 32, 688, DateTimeKind.Local).AddTicks(1257), "992729ae-136a-4779-8035-5181e7548316", "Nina.Kshlerin@yahoo.com", false, "Nina", "Kshlerin", false, null, null, null, "f04574552ee7ffdbef231961a7dcf2eeb25a1a19", "823.596.1362", false, null, false, null },
                    { new Guid("f6d2645c-d118-86e3-b4d6-dead790666a7"), 0, new DateTime(2020, 3, 13, 14, 23, 14, 146, DateTimeKind.Local).AddTicks(6963), "86735259-a7c2-416d-9ab9-75a134e98ff2", "Otis42@yahoo.com", false, "Otis", "Carter", false, null, null, null, "a4036c10959e443503e7c9b14a46f279163a02ce", "749.362.8114 x436", false, null, false, null }
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
                    { new Guid("fc6d7cd8-0cca-eee7-890e-829ae57858fd"), 9637, "East Wilber" }
                });

            migrationBuilder.InsertData(
                table: "ZipCode",
                columns: new[] { "ZipCodeID", "Code", "Commune" },
                values: new object[] { new Guid("fde18f58-a54d-1b84-fa91-d96002983e36"), 3713, "Port Ally" });

            migrationBuilder.InsertData(
                table: "ZipCode",
                columns: new[] { "ZipCodeID", "Code", "Commune" },
                values: new object[] { new Guid("ff0a3fb9-1dae-3232-89ed-a47d796b61cd"), 2361, "Deborahton" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductID", "BrandID", "IsFeatured", "ProductDescription", "ProductName", "ProductPrice", "ProductURL", "Stock" },
                values: new object[,]
                {
                    { new Guid("11788f1c-7e70-9973-6f3d-c9ff72df695f"), new Guid("bb2b43b4-bdc4-6ac7-c2ee-9c850c9c4d75"), false, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Small Frozen Pizza", 79.048832170222400m, "https://picsum.photos/640/480/?image=929", 31 },
                    { new Guid("18a74a15-fb01-0fcc-ed52-b2e56ed58b61"), new Guid("c7b3305f-9bdb-472c-95c4-51184dd2aa8d"), true, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Tasty Cotton Fish", 2.6719768544062900m, "https://picsum.photos/640/480/?image=70", 45 },
                    { new Guid("1dfb0fba-f84d-f97f-c301-8f9c6294cc89"), new Guid("e3e45b65-eda4-a53a-66d0-9b1f8ed98efc"), true, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Generic Concrete Sausages", 90.101110511506500m, "https://picsum.photos/640/480/?image=311", 10 },
                    { new Guid("20bd175b-c07a-47ef-9d9c-5f5148e00d33"), new Guid("cc4236f3-8909-7940-c61f-66e5915e05ad"), true, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Ergonomic Fresh Mouse", 53.488236411236300m, "https://picsum.photos/640/480/?image=501", 9 },
                    { new Guid("20c2ce26-a22d-5015-986b-7777c3f0829e"), new Guid("68fbb9a4-cd27-aa9f-7ae6-4281bda59a71"), true, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Sleek Fresh Gloves", 23.144258243564600m, "https://picsum.photos/640/480/?image=363", 47 },
                    { new Guid("2d43389b-2dc3-6813-0eb0-49b5dc0a55f1"), new Guid("7c04d23b-019f-8a60-3710-6edd8e2bd064"), true, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Sleek Frozen Pizza", 80.496113505445500m, "https://picsum.photos/640/480/?image=692", 9 },
                    { new Guid("3241e82d-aa2e-7d68-9601-1a198e6f1423"), new Guid("959badbe-7bad-57b5-cd3c-f92f276eebd5"), false, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Handmade Fresh Car", 5.8141218525423300m, "https://picsum.photos/640/480/?image=1004", 34 },
                    { new Guid("357dcc32-5691-5a8d-1205-ac8fdbe918d8"), new Guid("5b1fd012-2199-dab9-e58b-92bd68d0fa17"), true, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Small Cotton Salad", 74.96114833045800m, "https://picsum.photos/640/480/?image=289", 42 },
                    { new Guid("41e35278-54f7-a421-d0d5-4235826a55d5"), new Guid("4700fa3f-5a0e-779f-9a1d-3561e7579c43"), true, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Ergonomic Granite Pizza", 72.573548961697900m, "https://picsum.photos/640/480/?image=38", 22 },
                    { new Guid("42aa701f-9d67-1932-a0c7-51ef1191c7c7"), new Guid("b2c36398-f822-2f8c-9e02-bd1e16f7c55a"), true, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Refined Frozen Keyboard", 98.645073128233200m, "https://picsum.photos/640/480/?image=597", 26 },
                    { new Guid("5173998f-e412-7ef4-e58f-5fb68a0a3cb6"), new Guid("7834298a-c5eb-188f-c4b8-7b2e59525a8c"), false, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Tasty Concrete Cheese", 20.966636864918600m, "https://picsum.photos/640/480/?image=83", 7 },
                    { new Guid("536227b5-2b5e-7408-ee52-2920143cc4d2"), new Guid("9cb19bf8-afde-ddc7-db50-e2ad897154d2"), false, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Fantastic Steel Shirt", 20.333191389373100m, "https://picsum.photos/640/480/?image=545", 2 },
                    { new Guid("559ccb10-47bd-bdf7-38e6-1f55045c5613"), new Guid("cbae5d6d-972f-22f0-58bf-b9d0ee21d8ed"), true, "The Football Is Good For Training And Recreational Purposes", "Small Rubber Car", 1.3081779709589600m, "https://picsum.photos/640/480/?image=630", 26 },
                    { new Guid("56185cda-dce2-0f1f-63bd-c90bcfd46f24"), new Guid("801abe43-31c6-11d5-ac49-5c10586c790b"), false, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Generic Frozen Computer", 43.034367190224300m, "https://picsum.photos/640/480/?image=703", 16 },
                    { new Guid("58c86520-2f99-e425-c7eb-7c659f6f6b00"), new Guid("0bd7df94-02a8-b034-5c45-1dfb54b1f529"), false, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Handmade Metal Mouse", 30.77958046029300m, "https://picsum.photos/640/480/?image=743", 34 },
                    { new Guid("5a7ec381-7fe2-acea-e21f-5c1649fca189"), new Guid("963e205d-c089-03f5-23c8-ab1b097901d5"), false, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Tasty Wooden Car", 91.274773232301100m, "https://picsum.photos/640/480/?image=752", 33 },
                    { new Guid("5a886510-fe25-add2-276c-37e426e25df7"), new Guid("cec876ad-01dd-e278-c9a2-a9307cb760db"), false, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Licensed Rubber Pizza", 69.504680004671500m, "https://picsum.photos/640/480/?image=398", 32 },
                    { new Guid("66a3bdf9-c10d-8be0-2283-e0772d50f146"), new Guid("0680f4bc-ea50-98f6-7504-6a63414cdf42"), true, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Incredible Wooden Shirt", 74.111094220593200m, "https://picsum.photos/640/480/?image=924", 11 },
                    { new Guid("6b416013-854c-76a2-98e9-976c3da1eaaa"), new Guid("3d77c624-9356-3068-8f30-0bb85651729c"), true, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Practical Soft Computer", 38.488092291396200m, "https://picsum.photos/640/480/?image=90", 43 },
                    { new Guid("73565ff8-60ad-f71d-ae1b-20cd4c67d4e4"), new Guid("c2bba114-d677-a87e-9248-5a20bead30a8"), true, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Awesome Granite Bike", 99.846159014779200m, "https://picsum.photos/640/480/?image=630", 11 },
                    { new Guid("7da87366-4777-20a1-1cd2-8b582f1dab88"), new Guid("33734837-1227-5085-ded5-1b373c300fe9"), true, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Incredible Metal Salad", 56.220618521897400m, "https://picsum.photos/640/480/?image=778", 8 },
                    { new Guid("7dd70de1-b007-f0ba-b4af-b26d7650c8cf"), new Guid("0ff7bd5d-7afb-72a0-d8aa-f62c8441cdf7"), true, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Gorgeous Wooden Keyboard", 73.315584367753700m, "https://picsum.photos/640/480/?image=922", 48 },
                    { new Guid("87bb8a54-1311-fa41-a38c-f778d4cc2c00"), new Guid("93a16dfd-ab85-04b9-fd40-0ecea27f8448"), true, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Awesome Rubber Chair", 48.725120094011100m, "https://picsum.photos/640/480/?image=90", 26 },
                    { new Guid("8d96b92c-fd82-57dc-7b38-add8e1c205c3"), new Guid("e39c64d3-fd29-e24f-16a6-8e0134a19954"), false, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Generic Wooden Bacon", 23.710091609372800m, "https://picsum.photos/640/480/?image=520", 31 },
                    { new Guid("93e2b54b-aa79-15ec-31c3-ac145b9452a9"), new Guid("490c6622-bbea-0234-2100-e37d6a9bb082"), false, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Unbranded Wooden Soap", 97.489312383108400m, "https://picsum.photos/640/480/?image=693", 9 },
                    { new Guid("951d5f89-e612-e4b6-2d5c-1a7304c14439"), new Guid("8d3443d6-7c48-9e89-a8bb-e145421d90c2"), true, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Intelligent Concrete Towels", 25.920053304135800m, "https://picsum.photos/640/480/?image=66", 7 },
                    { new Guid("a345a6cf-47e6-ef94-09c6-a848e9de1f90"), new Guid("3bc6573e-7be9-adf6-82f4-32bcb4b0f1b2"), true, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Handmade Granite Car", 48.363655781542700m, "https://picsum.photos/640/480/?image=688", 39 },
                    { new Guid("a4fc61a1-e319-b704-4017-da743337b2b1"), new Guid("102c15a0-6464-7616-6d88-01236ecd42b5"), false, "The Football Is Good For Training And Recreational Purposes", "Gorgeous Concrete Shoes", 90.381531925118300m, "https://picsum.photos/640/480/?image=230", 28 },
                    { new Guid("a8927254-d684-205a-4b3e-86ec605d3bbb"), new Guid("cec3aa34-f966-56f0-4664-0aaf516dc3be"), true, "The Football Is Good For Training And Recreational Purposes", "Handmade Wooden Fish", 9.6679049589056100m, "https://picsum.photos/640/480/?image=521", 16 },
                    { new Guid("acdcabd1-e7ec-0c11-9ad4-28fc36c62e4e"), new Guid("41c09f22-e462-eec2-b236-046951f599dd"), false, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Practical Fresh Towels", 0.84484284783007700m, "https://picsum.photos/640/480/?image=831", 37 },
                    { new Guid("b8f5e25e-08be-5d9f-8b7f-ad247e439b4d"), new Guid("0136a8be-afc5-e0cc-f28b-6c79d99c9320"), false, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Tasty Metal Hat", 69.810464172535800m, "https://picsum.photos/640/480/?image=1046", 29 },
                    { new Guid("bd40f82c-8de4-9084-ec2c-20da1effb972"), new Guid("c75e8db1-a293-6c21-daa0-4d8d3f9bc259"), true, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Rustic Concrete Table", 11.224380327027500m, "https://picsum.photos/640/480/?image=414", 15 },
                    { new Guid("c334080c-037a-04c3-26dd-83f7845ad906"), new Guid("0bf3561a-9991-29d4-ce39-8263dd0de6f4"), true, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Awesome Granite Keyboard", 81.241056360882300m, "https://picsum.photos/640/480/?image=43", 10 },
                    { new Guid("c48d9ab4-7f88-06e1-5914-4c46ca2655bd"), new Guid("3bf480d3-cb4e-a040-56e8-a8186acdfd9b"), true, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Handmade Steel Gloves", 37.648282729856800m, "https://picsum.photos/640/480/?image=306", 43 },
                    { new Guid("db731e94-01cd-87d6-95dd-b9d854c7d48b"), new Guid("9ff33aaf-690f-bbc1-2c6f-ce2c728d04a5"), false, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Fantastic Frozen Ball", 97.21016418058900m, "https://picsum.photos/640/480/?image=922", 2 },
                    { new Guid("dcc5057d-dcfe-0aa7-bbf1-a396b83cefc5"), new Guid("9dee3a3f-f243-4328-71f1-e8ffc3e39632"), false, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Tasty Cotton Gloves", 5.4074056937393800m, "https://picsum.photos/640/480/?image=922", 38 },
                    { new Guid("e8e74b1d-98a2-c64a-e809-aaf81583e48c"), new Guid("0506fb2f-86b6-b93c-348f-d4f2697be09a"), false, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Tasty Steel Chips", 92.933303766387200m, "https://picsum.photos/640/480/?image=53", 30 },
                    { new Guid("f1d2a016-dc1c-99aa-a2da-0839bb2d3cf7"), new Guid("4d70da6f-141a-62ce-cc33-9a5596935366"), false, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Sleek Frozen Table", 29.698811345593400m, "https://picsum.photos/640/480/?image=685", 26 },
                    { new Guid("f2e2f601-4cfa-c93f-a28d-6a8d66dee66e"), new Guid("89acfb10-c061-8721-53b1-d060c8aa0ce0"), false, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Rustic Wooden Chips", 39.078262093979100m, "https://picsum.photos/640/480/?image=958", 43 },
                    { new Guid("f9fc6035-b68b-4159-bd9f-10f52b831d26"), new Guid("4c9ea98f-1208-8361-8f5f-ccf4b179ff89"), false, "The Football Is Good For Training And Recreational Purposes", "Incredible Wooden Pizza", 81.274550259706800m, "https://picsum.photos/640/480/?image=444", 46 }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryID", "ProductID" },
                values: new object[,]
                {
                    { new Guid("7fb37ecc-2549-4b70-866e-39da204c4bdb"), new Guid("11788f1c-7e70-9973-6f3d-c9ff72df695f") },
                    { new Guid("7fb37ecc-2549-4b70-866e-39da204c4bdb"), new Guid("18a74a15-fb01-0fcc-ed52-b2e56ed58b61") },
                    { new Guid("69f56e45-e95b-4694-b546-6cb76c0facac"), new Guid("1dfb0fba-f84d-f97f-c301-8f9c6294cc89") },
                    { new Guid("8ceeac06-1e28-4d24-8d56-ac9d1e44cfce"), new Guid("20bd175b-c07a-47ef-9d9c-5f5148e00d33") },
                    { new Guid("7fb37ecc-2549-4b70-866e-39da204c4bdb"), new Guid("20c2ce26-a22d-5015-986b-7777c3f0829e") },
                    { new Guid("7fb37ecc-2549-4b70-866e-39da204c4bdb"), new Guid("2d43389b-2dc3-6813-0eb0-49b5dc0a55f1") },
                    { new Guid("8ceeac06-1e28-4d24-8d56-ac9d1e44cfce"), new Guid("3241e82d-aa2e-7d68-9601-1a198e6f1423") },
                    { new Guid("af32e8f8-1404-46fd-9a70-c1a136985eb9"), new Guid("357dcc32-5691-5a8d-1205-ac8fdbe918d8") },
                    { new Guid("ec07b8e2-f9cc-41bd-8101-ad92ddb51ea4"), new Guid("41e35278-54f7-a421-d0d5-4235826a55d5") },
                    { new Guid("8ceeac06-1e28-4d24-8d56-ac9d1e44cfce"), new Guid("42aa701f-9d67-1932-a0c7-51ef1191c7c7") },
                    { new Guid("69f56e45-e95b-4694-b546-6cb76c0facac"), new Guid("5173998f-e412-7ef4-e58f-5fb68a0a3cb6") },
                    { new Guid("34af17e2-8958-422c-9b45-03d54869212c"), new Guid("536227b5-2b5e-7408-ee52-2920143cc4d2") },
                    { new Guid("ec07b8e2-f9cc-41bd-8101-ad92ddb51ea4"), new Guid("559ccb10-47bd-bdf7-38e6-1f55045c5613") },
                    { new Guid("69f56e45-e95b-4694-b546-6cb76c0facac"), new Guid("56185cda-dce2-0f1f-63bd-c90bcfd46f24") },
                    { new Guid("8ceeac06-1e28-4d24-8d56-ac9d1e44cfce"), new Guid("58c86520-2f99-e425-c7eb-7c659f6f6b00") },
                    { new Guid("8ceeac06-1e28-4d24-8d56-ac9d1e44cfce"), new Guid("5a7ec381-7fe2-acea-e21f-5c1649fca189") },
                    { new Guid("8ceeac06-1e28-4d24-8d56-ac9d1e44cfce"), new Guid("5a886510-fe25-add2-276c-37e426e25df7") },
                    { new Guid("ec07b8e2-f9cc-41bd-8101-ad92ddb51ea4"), new Guid("66a3bdf9-c10d-8be0-2283-e0772d50f146") },
                    { new Guid("8ceeac06-1e28-4d24-8d56-ac9d1e44cfce"), new Guid("6b416013-854c-76a2-98e9-976c3da1eaaa") },
                    { new Guid("69f56e45-e95b-4694-b546-6cb76c0facac"), new Guid("73565ff8-60ad-f71d-ae1b-20cd4c67d4e4") },
                    { new Guid("7fb37ecc-2549-4b70-866e-39da204c4bdb"), new Guid("7da87366-4777-20a1-1cd2-8b582f1dab88") },
                    { new Guid("34af17e2-8958-422c-9b45-03d54869212c"), new Guid("7dd70de1-b007-f0ba-b4af-b26d7650c8cf") },
                    { new Guid("8ceeac06-1e28-4d24-8d56-ac9d1e44cfce"), new Guid("87bb8a54-1311-fa41-a38c-f778d4cc2c00") },
                    { new Guid("af32e8f8-1404-46fd-9a70-c1a136985eb9"), new Guid("8d96b92c-fd82-57dc-7b38-add8e1c205c3") },
                    { new Guid("69f56e45-e95b-4694-b546-6cb76c0facac"), new Guid("93e2b54b-aa79-15ec-31c3-ac145b9452a9") },
                    { new Guid("af32e8f8-1404-46fd-9a70-c1a136985eb9"), new Guid("951d5f89-e612-e4b6-2d5c-1a7304c14439") },
                    { new Guid("ec07b8e2-f9cc-41bd-8101-ad92ddb51ea4"), new Guid("a345a6cf-47e6-ef94-09c6-a848e9de1f90") },
                    { new Guid("8ceeac06-1e28-4d24-8d56-ac9d1e44cfce"), new Guid("a4fc61a1-e319-b704-4017-da743337b2b1") },
                    { new Guid("8ceeac06-1e28-4d24-8d56-ac9d1e44cfce"), new Guid("a8927254-d684-205a-4b3e-86ec605d3bbb") },
                    { new Guid("ec07b8e2-f9cc-41bd-8101-ad92ddb51ea4"), new Guid("acdcabd1-e7ec-0c11-9ad4-28fc36c62e4e") },
                    { new Guid("34af17e2-8958-422c-9b45-03d54869212c"), new Guid("b8f5e25e-08be-5d9f-8b7f-ad247e439b4d") },
                    { new Guid("69f56e45-e95b-4694-b546-6cb76c0facac"), new Guid("bd40f82c-8de4-9084-ec2c-20da1effb972") },
                    { new Guid("7fb37ecc-2549-4b70-866e-39da204c4bdb"), new Guid("c334080c-037a-04c3-26dd-83f7845ad906") },
                    { new Guid("34af17e2-8958-422c-9b45-03d54869212c"), new Guid("c48d9ab4-7f88-06e1-5914-4c46ca2655bd") },
                    { new Guid("69f56e45-e95b-4694-b546-6cb76c0facac"), new Guid("db731e94-01cd-87d6-95dd-b9d854c7d48b") },
                    { new Guid("ec07b8e2-f9cc-41bd-8101-ad92ddb51ea4"), new Guid("dcc5057d-dcfe-0aa7-bbf1-a396b83cefc5") },
                    { new Guid("34af17e2-8958-422c-9b45-03d54869212c"), new Guid("e8e74b1d-98a2-c64a-e809-aaf81583e48c") },
                    { new Guid("af32e8f8-1404-46fd-9a70-c1a136985eb9"), new Guid("f1d2a016-dc1c-99aa-a2da-0839bb2d3cf7") },
                    { new Guid("ec07b8e2-f9cc-41bd-8101-ad92ddb51ea4"), new Guid("f2e2f601-4cfa-c93f-a28d-6a8d66dee66e") },
                    { new Guid("af32e8f8-1404-46fd-9a70-c1a136985eb9"), new Guid("f9fc6035-b68b-4159-bd9f-10f52b831d26") }
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
