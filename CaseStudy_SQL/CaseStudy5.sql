USE master

CREATE DATABASE dbTransaction;

USE dbTransaction;

CREATE TABLE Orders ( 

    OrderID INT IDENTITY(1,1) PRIMARY KEY, 

    CustomerName VARCHAR(100), 

    OrderDate DATETIME DEFAULT GETDATE() 

); 

CREATE TABLE OrderItems ( 

    OrderItemID INT IDENTITY(1,1) PRIMARY KEY, 

    OrderID INT FOREIGN KEY REFERENCES Orders(OrderID), 

    ProductName VARCHAR(100), 

    Quantity INT, 

    UnitPrice DECIMAL(10,2) 

);

