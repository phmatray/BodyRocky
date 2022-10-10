classDiagram
direction BT
class Address {
   datetime2 AddressFromDate
   datetime2 AddressToDate
   nvarchar(400) Street
   uniqueidentifier CustomerId
   uniqueidentifier ZipCodeID
   uniqueidentifier AddressID
}
class Basket {
   datetime2 BasketDateAdded
   int BasketStatusCode
   uniqueidentifier CustomerId
   uniqueidentifier BasketID
}
class BasketProduct {
   int Quantity
   uniqueidentifier BasketId
   uniqueidentifier ProductId
}
class BasketStatus {
   nvarchar(max) Description
   int Code
}
class Brand {
   nvarchar(max) BrandName
   nvarchar(max) BrandLogo
   uniqueidentifier BrandID
}
class Category {
   nvarchar(max) CategoryName
   bit IsFeatured
   uniqueidentifier CategoryID
}
class Customer {
   nvarchar(max) FirstName
   nvarchar(max) LastName
   datetime2 BirthDate
   nvarchar(max) Password
   nvarchar(max) PhoneNumber
   nvarchar(max) EmailAddress
   uniqueidentifier CustomerID
}
class Order {
   nvarchar(max) BillingName
   nvarchar(max) Reference
   nvarchar(max) DeliveryName
   datetime2 PurchaseDate
   uniqueidentifier CustomerId
   uniqueidentifier BillingAddressId
   uniqueidentifier DeliveryAddressId
   int OrderStatusCode
   uniqueidentifier OrderID
}
class OrderStatus {
   nvarchar(max) Description
   int Code
}
class OrderedProduct {
   nvarchar(max) OrderedProductName
   nvarchar(max) OrderedProductDescription
   decimal(18,4) OrderedProductPrice
   int Quantity
   uniqueidentifier ProductId
   uniqueidentifier OrderId
   uniqueidentifier OrderedProductId
}
class Product {
   nvarchar(max) ProductName
   nvarchar(max) ProductDescription
   decimal(18,4) ProductPrice
   nvarchar(max) ProductURL
   bit IsFeatured
   uniqueidentifier BrandId
   uniqueidentifier ProductId
}
class ProductCategory {
   uniqueidentifier ProductId
   uniqueidentifier CategoryId
}
class ProductImage {
   nvarchar(max) Image
   bit IsFeatured
   uniqueidentifier ProductId
   uniqueidentifier ProductImageID
}
class Review {
   int ReviewRating
   nvarchar(max) ReviewText
   uniqueidentifier ProductId
   uniqueidentifier CustomerId
   uniqueidentifier ReviewID
}
class ZipCode {
   int Code
   nvarchar(450) Commune
   uniqueidentifier ZipCodeID
}

Address  -->  Customer : CustomerId:CustomerID
Address  -->  ZipCode : ZipCodeID
Basket  -->  BasketStatus : BasketStatusCode:Code
Basket  -->  Customer : CustomerId:CustomerID
BasketProduct  -->  Basket : BasketId:BasketID
BasketProduct  -->  Product : ProductId
Order  -->  Address : BillingAddressId:AddressID
Order  -->  Address : DeliveryAddressId:AddressID
Order  -->  Customer : CustomerId:CustomerID
Order  -->  OrderStatus : OrderStatusCode:Code
OrderedProduct  -->  Order : OrderId:OrderID
OrderedProduct  -->  Product : ProductId
Product  -->  Brand : BrandId:BrandID
ProductCategory  -->  Category : CategoryId:CategoryID
ProductCategory  -->  Product : ProductId
ProductImage  -->  Product : ProductId
Review  -->  Customer : CustomerId:CustomerID
Review  -->  Product : ProductId