CREATE TABLE Orders (
Id INT PRIMARY KEY IDENTITY (1, 1),
UserName VARCHAR (250),
TotalPrice DECIMAL (18,2) NOT NULL,
FirstName VARCHAR (250),
LastName VARCHAR (250),
EmailAddress VARCHAR (250),
AddressLine VARCHAR (250),
Country VARCHAR (250),
State VARCHAR (250),
ZipCode VARCHAR (250),
CardName VARCHAR (250),
CardNumber VARCHAR (250),
Expiration VARCHAR (250),
CVV VARCHAR (250),
PaymentMethod INT NOT NULL,
CreatedBy VARCHAR (250),
CreatedDate DATETIME NOT NULL,
LastModifiedBy VARCHAR (250),
LastModifiedDate DATETIME NOT NULL,
);