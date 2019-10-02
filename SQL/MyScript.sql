CREATE DATABASE CoffeeShop	
CREATE TABLE Items(
ID INT IDENTITY(1,1) PRIMARY KEY,
Name VARCHAR(50),
Price FLOAT
)

INSERT INTO Items (Name, Price) Values ('Black', 120)
INSERT INTO Items (Name, Price) Values ('Regular', 80)
INSERT INTO Items (Name, Price) Values ('Cold', 100)
INSERT INTO Items (Name, Price) Values ('Hot', 90)

CREATE TABLE Customers
(
Id INT IDENTITY(1,1) PRIMARY KEY,
Name VARCHAR(50),
[Address] VARCHAR(200),

)

INSERT INTO Customers VALUES ('Ali', 'Dhaka' )
INSERT INTO Customers VALUES ('Hasan', 'Sylhet' )
INSERT INTO Customers VALUES ('Rafi', 'BNorisal' )

SELECT * FROM Items
SELECT * FROM Customers

CREATE TABLE Orders
(
Id INT IDENTITY(1,1) PRIMARY KEY,
CustomerId INT FOREIGN KEY REFERENCES Customers(Id),
ItemId INT FOREIGN KEY REFERENCES Items(Id),
Quantity INT,
TotalPrice FLOAT
)

INSERT INTO Orders VALUES (1, 1 , 5, 600)
INSERT INTO Orders VALUES (1, 2 , 3, 240)
INSERT INTO Orders VALUES (1, 3 , 2, 200)

INSERT INTO Orders VALUES (2, 2 , 2, 160)
INSERT INTO Orders VALUES (2, 3 , 3, 300)
INSERT INTO Orders VALUES (2, 4 , 4, 400)
SELECT * FROM Orders

DELETE FROM Customers WHERE ID = 3

SELECT o.Id, CustomerId ,c.Name AS Customer, ItemId, i.Name AS Item, Quantity, i.Price, TotalPrice 
FROM Orders AS o
LEFT JOIN Customers AS c ON c.Id = o.CustomerId
LEFT JOIN Items AS i ON i.Id = o.ItemId

DELETE FROM Orders WHERE Id = 9