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
                name: "Address",
                columns: table => new
                {
                    AddressID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressFromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddressToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressID);
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
                name: "Order",
                columns: table => new
                {
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BillingName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderID);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReviewRating = table.Column<int>(type: "int", nullable: false),
                    ReviewText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewID);
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
                name: "Basket",
                columns: table => new
                {
                    BasketID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BasketDateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BasketStatusCode = table.Column<int>(type: "int", nullable: false)
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
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerID", "BirthDate", "EmailAddress", "FirstName", "LastName", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("06fce41f-e211-7f39-dae6-a85edd644d8c"), new DateTime(2008, 11, 17, 8, 26, 14, 440, DateTimeKind.Local).AddTicks(8864), "Leticia99@yahoo.com", "Leticia", "Roob", "59a96a32bc251374dc19163bd018c5a999a78b62", "812-776-7367 x795" },
                    { new Guid("074a1242-73d9-a485-7df0-f160dd454f1f"), new DateTime(2016, 4, 8, 16, 21, 11, 108, DateTimeKind.Local).AddTicks(3446), "Norman46@gmail.com", "Norman", "Treutel", "7f9aa8c5cd222ba4eeb4cf42e61875328582e12c", "1-616-207-7048" },
                    { new Guid("0ab31ab1-6cca-f6c7-b5d2-f3a074287d5c"), new DateTime(2021, 4, 4, 17, 11, 36, 752, DateTimeKind.Local).AddTicks(679), "Lydia22@gmail.com", "Lydia", "Blick", "fad00bc2685f8293c672c41d268c1ff1e67d1c22", "(661) 757-2446 x006" },
                    { new Guid("0afaf97c-0003-797c-fcbc-a416ed8444c4"), new DateTime(2009, 11, 8, 15, 24, 11, 174, DateTimeKind.Local).AddTicks(5858), "Stacey88@hotmail.com", "Stacey", "Baumbach", "70f946915560c464452885d78872ddec87f3cf9e", "(297) 283-9673 x51018" },
                    { new Guid("0ed92e86-f0e6-40fe-91d6-a5189d87ffc4"), new DateTime(2021, 3, 2, 17, 21, 4, 249, DateTimeKind.Local).AddTicks(9730), "Ebony34@yahoo.com", "Ebony", "Wisozk", "9c4ed5d078636edb8e216248761ecf0971996d42", "(756) 377-7522" },
                    { new Guid("0fa4e699-8596-c6fe-7ab7-31b5d408d1f6"), new DateTime(2012, 3, 27, 22, 36, 36, 534, DateTimeKind.Local).AddTicks(35), "Doris.Halvorson54@yahoo.com", "Doris", "Halvorson", "b973e11022a6bcb89a0aead8b4e009b648ce95b8", "981-638-4421" },
                    { new Guid("11d29de3-fa38-8668-8441-60d6e6ea087c"), new DateTime(2017, 8, 13, 18, 10, 59, 30, DateTimeKind.Local).AddTicks(8194), "Gretchen.Goodwin@yahoo.com", "Gretchen", "Goodwin", "c59c1e426192c211e1e04a122d4909a151253ced", "(808) 891-7308 x34438" },
                    { new Guid("1478da06-d81c-e683-1d19-bc5f4ae91de7"), new DateTime(2008, 2, 11, 4, 11, 36, 112, DateTimeKind.Local).AddTicks(6640), "Jeremy_Baumbach@hotmail.com", "Jeremy", "Baumbach", "83083ac12f6b047feda8af27c6ffe9d118b69461", "1-618-994-2223 x95552" },
                    { new Guid("1f06f1d4-7331-375e-3352-2a521c9cbd35"), new DateTime(2004, 10, 12, 0, 32, 38, 499, DateTimeKind.Local).AddTicks(5306), "Roderick_OKeefe@hotmail.com", "Roderick", "O'Keefe", "6c5aca8a3a842ce2681ad637c55da0afe179c097", "1-216-323-6087 x69980" },
                    { new Guid("22772f46-c201-8a3b-02cc-b7f24d0bfa13"), new DateTime(2006, 10, 30, 2, 29, 7, 370, DateTimeKind.Local).AddTicks(6218), "Felix_Ankunding87@hotmail.com", "Felix", "Ankunding", "bfb9364fec046c65accd5da8e5fbf128c583f63c", "501-645-3659 x0155" },
                    { new Guid("2e345ac3-41be-81c2-3878-3544c9f48c19"), new DateTime(2016, 7, 22, 1, 20, 51, 275, DateTimeKind.Local).AddTicks(8369), "Luke.Huels22@yahoo.com", "Luke", "Huels", "15e51e4d3335884c3b6227a0cc72a638534c7fd1", "(644) 391-0575" },
                    { new Guid("307814ac-7380-1e7b-ea0e-c4f38263aaa3"), new DateTime(2021, 3, 1, 16, 30, 58, 472, DateTimeKind.Local).AddTicks(1293), "Betsy.Grimes@yahoo.com", "Betsy", "Grimes", "5117f17e6a58656fe30ddf4294251a3165e2ef57", "1-571-222-0603" },
                    { new Guid("31971650-b99d-69e3-38c7-c99e03a8af46"), new DateTime(2007, 9, 30, 17, 43, 51, 31, DateTimeKind.Local).AddTicks(114), "Blake53@gmail.com", "Blake", "Johns", "bc07c285c7d69418cce0b98778628db1ce462643", "983.543.9489" },
                    { new Guid("32d9510b-b32d-07fc-fa84-27fd0155ccfc"), new DateTime(2021, 2, 28, 9, 18, 38, 78, DateTimeKind.Local).AddTicks(8919), "Deborah_Smitham@gmail.com", "Deborah", "Smitham", "f47cc13323b79eee2793ded70cd2cdbf093d7a40", "698.537.7004 x11011" },
                    { new Guid("363ac938-b99a-942d-c13b-7629eb28ceb9"), new DateTime(2015, 1, 19, 22, 55, 59, 987, DateTimeKind.Local).AddTicks(6457), "Darrin.Schroeder@yahoo.com", "Darrin", "Schroeder", "a057f2336048446e7270214cac247e2e1aeffef0", "297-688-4750" },
                    { new Guid("37209d80-f96c-1c43-f631-9a97293c4e9d"), new DateTime(2010, 12, 20, 4, 13, 5, 630, DateTimeKind.Local).AddTicks(4686), "Erica.Hintz@hotmail.com", "Erica", "Hintz", "692a9c05f11f8dbccd0f89646735823d45a7825f", "1-573-999-4613" },
                    { new Guid("392bc9a7-3d17-313b-0cdd-cf25f866b085"), new DateTime(2008, 3, 21, 11, 11, 35, 197, DateTimeKind.Local).AddTicks(3919), "Danny.Runte@hotmail.com", "Danny", "Runte", "4f9bbc164bffdc0b09be270e4d34e6b2bcbf3c6d", "1-998-883-5445" },
                    { new Guid("3bd619de-e507-ae53-9a9c-198449289a85"), new DateTime(2007, 11, 30, 9, 4, 17, 319, DateTimeKind.Local).AddTicks(3200), "Sheryl45@gmail.com", "Sheryl", "Prosacco", "169a23dfc9a609915db123d33dfa4c17cf4441f5", "372.783.7284" },
                    { new Guid("3e8dd33e-1518-de51-7b10-19167b4659af"), new DateTime(2017, 1, 26, 6, 23, 2, 8, DateTimeKind.Local).AddTicks(1867), "Percy_Haag@hotmail.com", "Percy", "Haag", "4973de9386c244b1521045cddaf26bd93766f5dd", "1-712-851-5804" },
                    { new Guid("433e01bc-d81e-4330-2596-6b876442df57"), new DateTime(2021, 10, 8, 9, 32, 0, 286, DateTimeKind.Local).AddTicks(3475), "Courtney75@gmail.com", "Courtney", "Dach", "649b2e4c3e91c90a9bac1d2db864c676964db004", "1-946-964-5804" },
                    { new Guid("43794dbb-45d8-c913-8ee2-16be50d66511"), new DateTime(2015, 4, 17, 7, 42, 11, 387, DateTimeKind.Local).AddTicks(2697), "Leona_Wiegand@yahoo.com", "Leona", "Wiegand", "cba1bc27e0eb22b581f9efd6e1e1f45e220eb81b", "933.575.5802 x51283" },
                    { new Guid("44ba3c65-046f-b89a-d1c8-f079f6e49262"), new DateTime(2018, 10, 19, 19, 27, 30, 318, DateTimeKind.Local).AddTicks(2555), "Edmond69@gmail.com", "Edmond", "Murray", "be0692a3a55708223521fc449cb9d9db7243fec3", "(212) 949-5218 x253" },
                    { new Guid("462ffa58-eb26-aa7f-6010-1d03a996eef7"), new DateTime(2019, 1, 6, 7, 3, 16, 173, DateTimeKind.Local).AddTicks(6102), "Dana.Dibbert49@yahoo.com", "Dana", "Dibbert", "2279b6485c9c32f2aaf06ff1196aba36eddfc50b", "507.279.8623" },
                    { new Guid("48f8fa33-c460-0769-787f-ab41fd19024b"), new DateTime(2020, 9, 30, 9, 27, 34, 258, DateTimeKind.Local).AddTicks(9088), "Regina.Tromp25@hotmail.com", "Regina", "Tromp", "6312496fbab4543ba500ae03a2fe7d5ea4d01fa6", "(718) 484-4344" },
                    { new Guid("4a761bd5-bce0-83f5-405a-64d7d95f9e43"), new DateTime(2016, 7, 18, 19, 53, 49, 320, DateTimeKind.Local).AddTicks(2763), "Jesus_Kris59@yahoo.com", "Jesus", "Kris", "329ce543815365c7bdf422bf1fea46ee1c287517", "(288) 517-8815" },
                    { new Guid("4a82c394-4d4f-be99-25dc-ddff23d837bb"), new DateTime(2007, 10, 26, 11, 45, 34, 147, DateTimeKind.Local).AddTicks(6015), "Jennie_Renner@hotmail.com", "Jennie", "Renner", "b7319de5b068b533be7e70a916ccb8bbc960054d", "(864) 411-7717 x9370" },
                    { new Guid("544c76db-88de-94ce-5d7a-bb8fa30c13bf"), new DateTime(2017, 10, 27, 10, 47, 11, 305, DateTimeKind.Local).AddTicks(9017), "Faith.Hahn@gmail.com", "Faith", "Hahn", "14704d53d9c817fbe9c812d68e3d85d46f30c103", "235.600.6876 x18391" },
                    { new Guid("5609e9fe-c115-7d82-69f5-3e5570f10ab2"), new DateTime(2017, 5, 9, 4, 12, 37, 28, DateTimeKind.Local).AddTicks(4765), "Alejandro_Johnson@hotmail.com", "Alejandro", "Johnson", "7a9e05dab77d133af1ec90435df7b9b461898ccd", "1-636-800-3880 x7955" },
                    { new Guid("57edce97-fb39-6ca8-98d7-ca25e90d3d96"), new DateTime(2014, 5, 14, 5, 2, 17, 165, DateTimeKind.Local).AddTicks(9068), "Edmond_Ledner42@yahoo.com", "Edmond", "Ledner", "fb425d63c6b5a8042a0b1897053bde881178cbcc", "430-947-2002 x6161" },
                    { new Guid("580784c3-c108-afaf-93f3-2cb9dfc97a85"), new DateTime(2010, 3, 13, 19, 49, 16, 568, DateTimeKind.Local).AddTicks(230), "Alberto_Kessler@hotmail.com", "Alberto", "Kessler", "16d85bc1fe3b987796607f18b076363c6488a797", "1-624-581-2345" },
                    { new Guid("59392b49-7be3-2f41-9ecc-1287d3edd780"), new DateTime(2020, 6, 20, 6, 22, 51, 429, DateTimeKind.Local).AddTicks(217), "Sadie43@yahoo.com", "Sadie", "Blanda", "d6be4b43970dd75d7aeb9aa90cf38abce5920c05", "(847) 508-4299" },
                    { new Guid("60c6675b-18d3-48e3-1d8e-c51781c0cd91"), new DateTime(2016, 11, 22, 11, 19, 27, 230, DateTimeKind.Local).AddTicks(1034), "Andy90@gmail.com", "Andy", "Gleason", "0ce29e83c14984e344e989eb0d02afde5c0f5777", "345.340.8775" },
                    { new Guid("62f650d6-3b74-e91e-815a-265cb3178d91"), new DateTime(2018, 12, 31, 7, 36, 32, 370, DateTimeKind.Local).AddTicks(8417), "Margarita_Crooks@gmail.com", "Margarita", "Crooks", "6f3a7c33122ce7ad25329281f4b17d7a7f5afdee", "850-593-4981 x166" },
                    { new Guid("631e87eb-5da2-702e-60c1-17da93b98c32"), new DateTime(2008, 12, 25, 3, 23, 14, 17, DateTimeKind.Local).AddTicks(4032), "Kelvin.Fahey@gmail.com", "Kelvin", "Fahey", "b024e480737f94dd03013aa745cf98d7df4d54c4", "866-896-8518 x9901" },
                    { new Guid("688f734c-e157-4fed-2679-1a5fe40fcbf0"), new DateTime(2019, 7, 20, 0, 37, 46, 897, DateTimeKind.Local).AddTicks(1611), "Brent54@yahoo.com", "Brent", "Bauch", "639a311882648c0d0c1980d7c31a94f85c644f65", "501-941-2417 x4757" },
                    { new Guid("68c7ca71-2309-6d2b-831c-eac7c37ab3b6"), new DateTime(2009, 5, 31, 12, 9, 20, 666, DateTimeKind.Local).AddTicks(8420), "Shane.Mraz@hotmail.com", "Shane", "Mraz", "2bafbe07c9f2c53d80bc0bbdff85095f0bccf583", "386-968-2732" },
                    { new Guid("719e2599-5766-6251-5611-2c2bf79f45c0"), new DateTime(2022, 3, 2, 4, 10, 12, 941, DateTimeKind.Local).AddTicks(2354), "Victoria.Bode@gmail.com", "Victoria", "Bode", "62d6347b958103bdc8b148830927f1a6da33289f", "1-233-768-9374" },
                    { new Guid("7533aa4f-79c3-080e-0bac-be0428ab2aef"), new DateTime(2007, 5, 22, 7, 35, 31, 523, DateTimeKind.Local).AddTicks(7745), "Ronnie_Wyman@gmail.com", "Ronnie", "Wyman", "9f9d260c990cdb8e9ae662a88d40003aed75dc07", "1-496-594-6226 x606" },
                    { new Guid("754e551c-15c9-cc9e-9650-c2d39a59dc7f"), new DateTime(2014, 2, 2, 0, 33, 26, 390, DateTimeKind.Local).AddTicks(170), "Marilyn40@yahoo.com", "Marilyn", "Schmitt", "23a924ef0a616756fcc1145436b3a2d528183c6e", "946-402-5786" },
                    { new Guid("75f7f787-b405-9689-9c36-cdcb1401eac5"), new DateTime(2021, 12, 29, 7, 3, 42, 602, DateTimeKind.Local).AddTicks(3366), "Rickey_VonRueden@yahoo.com", "Rickey", "VonRueden", "ccb476aac0ea148050b42c2877b1a038c28e5c0f", "1-808-889-2331" },
                    { new Guid("76378439-999c-54f2-23fd-17b72b45201b"), new DateTime(2006, 8, 3, 23, 50, 23, 209, DateTimeKind.Local).AddTicks(499), "Merle_Schiller@yahoo.com", "Merle", "Schiller", "6953f70c9bc282f59ee706aadf200898b17c7643", "614-391-6773 x6904" },
                    { new Guid("77c666c3-87b2-ee8c-c1da-c11c15a92fed"), new DateTime(2020, 12, 17, 17, 7, 49, 374, DateTimeKind.Local).AddTicks(6418), "Janie_Collins@yahoo.com", "Janie", "Collins", "ed5b3cdfcf9db1bfeb7bf16bdfa854557e2b5382", "1-817-753-9794" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerID", "BirthDate", "EmailAddress", "FirstName", "LastName", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("78d31a0c-36de-4777-a5f2-28b9cfdab52c"), new DateTime(2019, 3, 22, 1, 5, 32, 62, DateTimeKind.Local).AddTicks(7635), "Lorene_Schaefer39@hotmail.com", "Lorene", "Schaefer", "14f202fef5342358d5617a14a48e5722fdc559d1", "1-851-780-6248" },
                    { new Guid("7a3175d3-3435-fc85-bd8f-b6266f574363"), new DateTime(2007, 1, 13, 6, 18, 30, 614, DateTimeKind.Local).AddTicks(2043), "Ricardo_Hessel43@yahoo.com", "Ricardo", "Hessel", "3a64c8331db08832f70cac407bb3725c6b338730", "520-292-2752 x6133" },
                    { new Guid("7b1a1654-2892-8ec2-8c3b-e35b78f2e405"), new DateTime(2013, 6, 13, 15, 43, 12, 402, DateTimeKind.Local).AddTicks(1552), "Christie32@yahoo.com", "Christie", "Homenick", "e654565f7bf4efa9c5a1f8f660d5030cb61ed9ce", "554-238-8227" },
                    { new Guid("7db051ab-16a0-1c53-059b-8deeb6692244"), new DateTime(2016, 12, 18, 2, 30, 40, 251, DateTimeKind.Local).AddTicks(5212), "Judith83@yahoo.com", "Judith", "O'Hara", "9b71a29bb41d0e4118a11db9d72232c7aaecf6b3", "1-235-656-9097" },
                    { new Guid("814dd92f-f340-bc0e-1e93-24b9dc0b845a"), new DateTime(2005, 7, 12, 23, 49, 3, 409, DateTimeKind.Local).AddTicks(281), "Eula_Zemlak@yahoo.com", "Eula", "Zemlak", "1425fd97c595eb0e6241be848037b293ee2d6f77", "(773) 309-1569 x48798" },
                    { new Guid("81e46d00-02f2-9bf3-1d64-34c8b0acd3f2"), new DateTime(2008, 10, 6, 13, 38, 30, 331, DateTimeKind.Local).AddTicks(5434), "Roderick.OKon@yahoo.com", "Roderick", "O'Kon", "e172ead6b13050f41dec6e537112eeab6379e513", "(672) 952-7569" },
                    { new Guid("81ed7a05-bec6-a866-c17a-93440e772bd0"), new DateTime(2008, 1, 23, 9, 47, 25, 287, DateTimeKind.Local).AddTicks(9318), "Hope76@yahoo.com", "Hope", "Grady", "a7bbfdf9ba54fa8ec508912b46f970c672b8257a", "1-210-595-8707" },
                    { new Guid("8501a073-3b27-f999-c93f-7cb46f3af054"), new DateTime(2005, 7, 10, 13, 53, 12, 39, DateTimeKind.Local).AddTicks(4950), "Isaac.Hammes@yahoo.com", "Isaac", "Hammes", "dacaa5f2270709b69d4de6a09ddf0a9794596fae", "(766) 614-1709" },
                    { new Guid("86203469-a37f-7747-4d90-668c257eac37"), new DateTime(2006, 9, 27, 7, 44, 33, 305, DateTimeKind.Local).AddTicks(8348), "Albert_Romaguera15@hotmail.com", "Albert", "Romaguera", "cbc6390047a6a3f3c14d85c60396391e2e97b548", "(571) 561-7709" },
                    { new Guid("86cfb286-bdf6-2ed3-5e1b-5954890a56df"), new DateTime(2016, 4, 11, 14, 59, 4, 268, DateTimeKind.Local).AddTicks(745), "Alonzo_Gleichner39@hotmail.com", "Alonzo", "Gleichner", "9147031d2c913d25d8280473748dd2a5e58fab69", "742-319-3749" },
                    { new Guid("8770bd0c-97a4-973c-fc28-b7ca4085dcde"), new DateTime(2016, 2, 25, 15, 0, 12, 815, DateTimeKind.Local).AddTicks(7272), "Meghan.Marvin44@gmail.com", "Meghan", "Marvin", "10eb9093e308dfddb0c17d09aa4b687765cf4b77", "(251) 426-5407" },
                    { new Guid("88816ec0-cb5f-e228-1154-607b26318e6f"), new DateTime(2022, 2, 23, 2, 59, 48, 350, DateTimeKind.Local).AddTicks(94), "Dianne_Barton95@hotmail.com", "Dianne", "Barton", "42f4c15100fe13775c6e7fe427b98b74c47b2536", "1-399-611-2916 x7628" },
                    { new Guid("8afc72e0-3b97-2c79-59bc-2a19dd0e89ce"), new DateTime(2007, 12, 8, 10, 43, 32, 777, DateTimeKind.Local).AddTicks(9413), "Kelley.Kirlin@gmail.com", "Kelley", "Kirlin", "fe6add80a4bb8882b6cf66468ccfaba97e58c83f", "(949) 731-4516 x663" },
                    { new Guid("8c593526-bcfa-08bf-2447-12a39d4eccf4"), new DateTime(2012, 11, 7, 4, 59, 57, 90, DateTimeKind.Local).AddTicks(4865), "Eric_Hamill@gmail.com", "Eric", "Hamill", "8e5a011121ce90938f2d55b92f24642d21d543c2", "998-519-0752 x145" },
                    { new Guid("8ce95249-f837-47b2-db12-5ee799da4834"), new DateTime(2018, 10, 15, 0, 31, 56, 82, DateTimeKind.Local).AddTicks(3889), "Dianna.Adams77@yahoo.com", "Dianna", "Adams", "5415a2f37984fbb16296d52f3c4f810b363a4b21", "540.959.9177" },
                    { new Guid("8d4fb4fb-4e94-921f-2d4f-4bcb931ca066"), new DateTime(2013, 11, 14, 9, 13, 7, 351, DateTimeKind.Local).AddTicks(6109), "Brent.Walker@gmail.com", "Brent", "Walker", "3ae20ad3869be90020f99aeaf6db35101cd0a6e6", "691-316-0592" },
                    { new Guid("9a9b42a7-4ba4-b525-94c9-5b9a9b6369b3"), new DateTime(2018, 12, 9, 12, 44, 58, 399, DateTimeKind.Local).AddTicks(3893), "Pat17@yahoo.com", "Pat", "Greenfelder", "38a813a0511bbe75db6e5f9b9f935e09efb7214d", "565.662.6862 x2202" },
                    { new Guid("9ae34448-73d8-fc46-d5ce-e05850f2767d"), new DateTime(2011, 1, 31, 0, 31, 38, 945, DateTimeKind.Local).AddTicks(1678), "Grady93@gmail.com", "Grady", "Pouros", "3ac95e718d377da09f957f371a65c363ad88ebda", "942.341.5558" },
                    { new Guid("9c47be26-995e-4348-ab4a-fe669f1713d7"), new DateTime(2017, 11, 13, 18, 55, 37, 451, DateTimeKind.Local).AddTicks(5001), "Ira.Reinger@hotmail.com", "Ira", "Reinger", "f571b78cd87b77737604075e220fb7c962246a54", "1-666-856-9374 x45802" },
                    { new Guid("a0d87812-1b4e-0370-6f9f-1d78724c811a"), new DateTime(2012, 10, 29, 12, 26, 49, 496, DateTimeKind.Local).AddTicks(4805), "Ed.Kovacek@gmail.com", "Ed", "Kovacek", "cb50e321b36bfe9a8b34250ae2df76cb39ce8108", "244-967-6188 x207" },
                    { new Guid("a10da5b1-7317-2d07-882b-34444d5f1fb3"), new DateTime(2004, 11, 22, 1, 7, 48, 617, DateTimeKind.Local).AddTicks(7436), "Clyde38@yahoo.com", "Clyde", "Bayer", "3c5700d80fb50fd186394ee2182d72109fd25bb9", "1-862-530-8172" },
                    { new Guid("a15f21bc-4a12-d307-4f70-28fa46c9b08a"), new DateTime(2016, 1, 18, 1, 38, 34, 902, DateTimeKind.Local).AddTicks(9116), "Celia_Lowe@yahoo.com", "Celia", "Lowe", "c97416fdc34ec12e903b2e57b8bc6a60c157af00", "392-463-7548 x0841" },
                    { new Guid("a24b9981-cd06-2b26-91ba-95bc452d85d2"), new DateTime(2009, 7, 11, 5, 4, 27, 928, DateTimeKind.Local).AddTicks(8323), "Holly6@yahoo.com", "Holly", "Bogisich", "56c063c93e0547dff9f12f76efb7e1390a21ad70", "1-846-429-9540 x25620" },
                    { new Guid("a253cbdb-266b-12e3-1267-3fee72d75e43"), new DateTime(2010, 5, 8, 7, 33, 54, 47, DateTimeKind.Local).AddTicks(6754), "May.Sipes45@hotmail.com", "May", "Sipes", "47c7033ddf069a2803e561da0890738a1c9df01c", "833.994.0512" },
                    { new Guid("a2d96232-67c2-af6c-fbe2-6dc0d1371b75"), new DateTime(2010, 4, 25, 2, 2, 36, 504, DateTimeKind.Local).AddTicks(9869), "Ray72@hotmail.com", "Ray", "Zemlak", "66f17cc33c1c2d8053acad0ed2a1a88ed4b6a120", "397-894-9581 x8438" },
                    { new Guid("a5a8e215-f788-ece7-a316-cd85e7167ba9"), new DateTime(2019, 12, 20, 17, 9, 54, 500, DateTimeKind.Local).AddTicks(5487), "Margarita.Mosciski76@hotmail.com", "Margarita", "Mosciski", "18d00e087f38ce1e24e8c14a4cb38d269ce837aa", "(697) 950-5579" },
                    { new Guid("a5e2eecf-bea9-ff40-f1f1-3e8b96e324e7"), new DateTime(2012, 12, 28, 15, 43, 53, 146, DateTimeKind.Local).AddTicks(3849), "Fred.McKenzie94@hotmail.com", "Fred", "McKenzie", "19c2f25bd6372a8c0c3d397272bca70ae4d364cc", "841-520-7118 x5611" },
                    { new Guid("ae149335-880b-ba23-8a17-8eddc2d3f5b7"), new DateTime(2022, 3, 6, 15, 32, 47, 658, DateTimeKind.Local).AddTicks(7335), "Rudy27@yahoo.com", "Rudy", "Jacobson", "6690c0d6a189b3ab17e59b140a3a0f74bbc74ab2", "1-649-711-7095" },
                    { new Guid("b893dfdf-9e7d-3f69-65b1-49b0c8db873d"), new DateTime(2019, 3, 23, 18, 34, 14, 495, DateTimeKind.Local).AddTicks(1126), "Dominic_Witting@gmail.com", "Dominic", "Witting", "ffbd00c1705f54965e603a6e9830530f1cb2c03d", "856.831.1181 x496" },
                    { new Guid("b8eff8bd-aadf-6c1f-a63a-93c8da63a6a1"), new DateTime(2005, 6, 16, 1, 27, 36, 213, DateTimeKind.Local).AddTicks(5048), "Shelly_Wehner80@gmail.com", "Shelly", "Wehner", "31299b245544b3b3705a9b18e801b9f717e5893f", "(642) 949-1488 x036" },
                    { new Guid("bbc6cffa-a097-9a5a-63a5-6ec941494884"), new DateTime(2020, 2, 8, 0, 6, 35, 789, DateTimeKind.Local).AddTicks(4084), "Belinda_McDermott18@gmail.com", "Belinda", "McDermott", "ef293838ba0fb5cf834ac126f731f0c4b1dc1fc4", "(527) 718-6586 x6471" },
                    { new Guid("bc845f40-9423-027c-a52a-b14ab961d03b"), new DateTime(2022, 7, 11, 0, 49, 7, 1, DateTimeKind.Local).AddTicks(6734), "Warren93@hotmail.com", "Warren", "Dach", "8d9a8794270f1464fc4e47a1e40e0ee4ae9db922", "(348) 926-0215" },
                    { new Guid("c2d14246-3307-3f14-4d13-dbbb7535e733"), new DateTime(2011, 1, 29, 10, 6, 13, 71, DateTimeKind.Local).AddTicks(3259), "Dave8@hotmail.com", "Dave", "Treutel", "76691233b22f75d48842c88e961fa3d2655355fd", "(984) 273-6101 x00239" },
                    { new Guid("c5bb7180-9c3b-edf0-1866-85138bbab388"), new DateTime(2006, 2, 27, 13, 14, 43, 635, DateTimeKind.Local).AddTicks(7359), "Sam_Kris@gmail.com", "Sam", "Kris", "4e9e205b1d768dab1b06090bbcd0d1dc3a02c676", "(554) 328-0954 x33387" },
                    { new Guid("c5bf508a-8b1c-dc67-0a7c-592dc5fa9cf6"), new DateTime(2007, 6, 18, 1, 18, 25, 164, DateTimeKind.Local).AddTicks(147), "Lorena.Osinski99@gmail.com", "Lorena", "Osinski", "f82aa3d51621f7203ac5b899f5ea98354fe0c2d9", "966.238.1749" },
                    { new Guid("d1be9f91-7f34-1594-e670-c0e7c1fa4b89"), new DateTime(2022, 8, 14, 1, 54, 47, 986, DateTimeKind.Local).AddTicks(189), "Kent.DuBuque@yahoo.com", "Kent", "DuBuque", "315522af26b12cf25398b9be7dfc8fe8bc48fa3d", "(584) 508-7404 x133" },
                    { new Guid("d85439bd-7831-d176-b351-d29e1a9fdf21"), new DateTime(2009, 11, 21, 1, 52, 50, 241, DateTimeKind.Local).AddTicks(9789), "Grady75@hotmail.com", "Grady", "Jenkins", "385f28305ca754e179b42ef68c009c3a1e62446f", "251.897.6220" },
                    { new Guid("db9feb41-6c31-6790-3ade-12e27e63471e"), new DateTime(2017, 9, 14, 17, 34, 7, 722, DateTimeKind.Local).AddTicks(2149), "Mack.Hintz73@yahoo.com", "Mack", "Hintz", "39ce21daebc8aa69b3fdd3dd6d885a4439ce487e", "1-906-260-9273 x022" },
                    { new Guid("de28262a-5675-8830-6876-629c3019cd40"), new DateTime(2016, 9, 11, 20, 24, 24, 453, DateTimeKind.Local).AddTicks(3912), "Jonathon47@gmail.com", "Jonathon", "Mayer", "d7dc2676e45fb384e4c8b14249a0b9f2b5f50598", "(464) 342-4780 x324" },
                    { new Guid("dfd64567-9ec3-fd89-818f-b87ebb36fb67"), new DateTime(2006, 11, 24, 12, 29, 37, 537, DateTimeKind.Local).AddTicks(9186), "Tyrone_Mertz43@gmail.com", "Tyrone", "Mertz", "395c87b22cfc9e90bf004125adf0d286da3d4c56", "1-514-814-8742" },
                    { new Guid("e09cb287-369d-6874-2203-b3ad09c77532"), new DateTime(2021, 8, 23, 17, 51, 47, 653, DateTimeKind.Local).AddTicks(8886), "Wendy63@yahoo.com", "Wendy", "Nolan", "ea35b11cd5b098684f6ed9cd21211af2d0de57a7", "1-385-276-5111 x785" },
                    { new Guid("e15e2568-f789-e1b3-009b-9d3fa97d4352"), new DateTime(2021, 8, 3, 1, 18, 24, 231, DateTimeKind.Local).AddTicks(2361), "Myra42@yahoo.com", "Myra", "Blanda", "788daec3fb491aac36dea926dc74640b47ff2ef2", "1-505-377-2272" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerID", "BirthDate", "EmailAddress", "FirstName", "LastName", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("e29fd9b4-1dbb-ea35-9114-9d4f2473ae1e"), new DateTime(2005, 5, 19, 1, 59, 50, 693, DateTimeKind.Local).AddTicks(5868), "Christina_Effertz@yahoo.com", "Christina", "Effertz", "15e6f4901e00fe458eadfbc70c73bc382b4f8e83", "228-305-9654 x36810" },
                    { new Guid("e34e1fe4-006c-4566-2fba-16222d46f98b"), new DateTime(2009, 6, 7, 2, 9, 27, 16, DateTimeKind.Local).AddTicks(5924), "Essie_Hintz18@hotmail.com", "Essie", "Hintz", "9a51179c702c9ae4d89e757e1f7e4b5634eefecf", "492-481-9243 x61405" },
                    { new Guid("e6a72c6b-4fb0-5296-aaf7-dcf05c1e4e17"), new DateTime(2013, 7, 17, 3, 20, 16, 553, DateTimeKind.Local).AddTicks(5570), "Candace60@gmail.com", "Candace", "Kunze", "8c265f9f2d832691c5aa71124f515a442f35331c", "1-333-669-0429" },
                    { new Guid("e8396ba4-038c-78b3-af6e-1aebe5b8b545"), new DateTime(2010, 7, 8, 0, 27, 2, 192, DateTimeKind.Local).AddTicks(6465), "Brittany.Stroman@gmail.com", "Brittany", "Stroman", "4de6f797ba3658bf1dde1f45bc3958958dfa9960", "(220) 532-2971 x097" },
                    { new Guid("ec86c5cb-9bee-2b4b-2135-9295e1a914b0"), new DateTime(2022, 7, 3, 8, 31, 34, 960, DateTimeKind.Local).AddTicks(2943), "Doyle_Lockman@gmail.com", "Doyle", "Lockman", "d02cce6465ecef72cf90cb05b16bc2d1faa91ba8", "249-754-0176" },
                    { new Guid("ecae53c4-e059-bccb-65c2-1c911642bf5a"), new DateTime(2012, 3, 25, 2, 18, 16, 179, DateTimeKind.Local).AddTicks(5287), "Grace_Collier@hotmail.com", "Grace", "Collier", "b1b245eba639b220bc4e8edbd01d79de0ff03063", "860-843-7785" },
                    { new Guid("ed90974e-c8ce-dbbb-1348-ceb389c2e723"), new DateTime(2014, 3, 3, 20, 22, 14, 619, DateTimeKind.Local).AddTicks(6481), "Juana_Jerde69@gmail.com", "Juana", "Jerde", "82f084127c07b4124b3bfa8af9131d1396512b26", "794-781-9387" },
                    { new Guid("f230b603-35fe-0d03-3ccc-c9cb9956aeaa"), new DateTime(2007, 5, 16, 1, 40, 55, 636, DateTimeKind.Local).AddTicks(3012), "Molly.Rice26@gmail.com", "Molly", "Rice", "85475c7011467ead61a278523c7ee23e23887119", "476.747.0468" },
                    { new Guid("f25bda5b-7435-2ca7-96d2-6fd66138ed95"), new DateTime(2009, 7, 27, 13, 49, 53, 305, DateTimeKind.Local).AddTicks(4608), "Francisco95@yahoo.com", "Francisco", "Boyer", "e794cfa40173cde865349b6fb6499c200514f6f6", "1-777-387-2913" },
                    { new Guid("f336e5c7-f171-d57a-57dc-4c80276401b0"), new DateTime(2007, 6, 4, 5, 34, 50, 799, DateTimeKind.Local).AddTicks(8268), "Lydia.Bartoletti12@yahoo.com", "Lydia", "Bartoletti", "8733470cbfb602e7f3f14a4c8df7f33d3289e39a", "937.792.7942 x6992" },
                    { new Guid("f482dfd2-7dbc-861d-21c7-70d27bbe0116"), new DateTime(2021, 2, 9, 23, 32, 29, 890, DateTimeKind.Local).AddTicks(7643), "Mercedes.Wunsch@hotmail.com", "Mercedes", "Wunsch", "0808c811ba433b99fadbbd7ad5536be9197dbcbc", "928-820-0322 x7822" },
                    { new Guid("f5c512a0-02b7-5f57-fcbd-5ba893ac8846"), new DateTime(2022, 8, 26, 10, 4, 16, 643, DateTimeKind.Local).AddTicks(9366), "Terrance_Wuckert@gmail.com", "Terrance", "Wuckert", "4d9e755cdf3c31eb2795c84024c78cd0a2f12322", "237.314.3880 x328" },
                    { new Guid("f660b7b7-1261-4395-05e8-c667c0dcb0e0"), new DateTime(2015, 8, 31, 0, 38, 33, 293, DateTimeKind.Local).AddTicks(7372), "Grant.Murray85@gmail.com", "Grant", "Murray", "863a9b36e82d44bcc42a67c85623660af7dee182", "994-600-9838" },
                    { new Guid("fa9e7e15-74f3-b870-328b-5c3c51f5720c"), new DateTime(2007, 3, 12, 10, 8, 10, 640, DateTimeKind.Local).AddTicks(5521), "Willie_McDermott16@yahoo.com", "Willie", "McDermott", "375d307022037bbd48a2fdca0bb75ddd56da740e", "1-321-998-9781" },
                    { new Guid("fc4e5d28-531f-60bd-f873-8c42513981a2"), new DateTime(2008, 11, 3, 12, 8, 45, 944, DateTimeKind.Local).AddTicks(3358), "Terry.Berge@gmail.com", "Terry", "Berge", "fd685309c9964305a418fb00a0b88922b4178af5", "(932) 419-9440" },
                    { new Guid("fdb3f144-b34c-f907-bc45-6bc06130dabe"), new DateTime(2018, 7, 31, 8, 11, 40, 447, DateTimeKind.Local).AddTicks(8893), "Cameron52@gmail.com", "Cameron", "Stroman", "e338beddb4fc8d6cd2da4ab080afdbda7f5d2b61", "1-220-259-0892" }
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "BasketProduct");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "ProductImage");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "ZipCode");

            migrationBuilder.DropTable(
                name: "Basket");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "BasketStatus");

            migrationBuilder.DropTable(
                name: "Brand");
        }
    }
}
