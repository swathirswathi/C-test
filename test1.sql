

CREATE TABLE Products (
    ProductId INT PRIMARY KEY,
    ProductName NVARCHAR(255) NOT NULL,
    Description NVARCHAR(1000),
    Price DECIMAL(10, 2) NOT NULL,
    QuantityInStock INT NOT NULL,
    Type NVARCHAR(50) NOT NULL
);


CREATE TABLE Electronics (
    ProductId INT PRIMARY KEY,
    Brand NVARCHAR(255) NOT NULL,
    WarrantyPeriod INT NOT NULL,
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);


CREATE TABLE Clothing (
    ProductId INT PRIMARY KEY,
    Size NVARCHAR(50) NOT NULL,
    Color NVARCHAR(50) NOT NULL,
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);


CREATE TABLE Users (
    UserId INT PRIMARY KEY,
    Username NVARCHAR(255) NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    Role NVARCHAR(50) NOT NULL
);


CREATE TABLE Orders (
    OrderId INT PRIMARY KEY,
    UserId INT NOT NULL,
    ProductId INT NOT NULL,
    OrderDate DATETIME DEFAULT GETDATE() NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(UserId),
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);


INSERT INTO Products (ProductId, ProductName, Description, Price, QuantityInStock, Type) 
VALUES 
    (1, 'Smartphone', 'High-end mobile device', 799.99, 50, 'Electronics'),
    (2, 'Laptop', 'Powerful laptop for gaming and work', 1499.99, 30, 'Electronics'),
    (3, 'T-shirt', 'Comfortable cotton t-shirt', 19.99, 100, 'Clothing'),
    (4, 'Jeans', 'Classic blue jeans', 39.99, 75, 'Clothing');

INSERT INTO Electronics (ProductId, Brand, WarrantyPeriod) 
VALUES 
    (1, 'Samsung', 12),
    (2, 'Dell', 24);


INSERT INTO Clothing (ProductId, Size, Color) 
VALUES 
    (3, 'M', 'Blue'),
    (4, 'L', 'Black');


INSERT INTO Users (UserId, Username, Password, Role) 
VALUES 
    (1, 'john_doe', 'password123', 'Customer'),
    (2, 'admin_user', 'adminpass', 'Admin');

INSERT INTO Orders (OrderId, UserId, ProductId, OrderDate) 
VALUES 
    (1, 1, 1, '2023-01-10 08:30:00'),
    (2, 1, 3, '2023-02-15 12:45:00'),
    (3, 2, 2, '2023-03-20 15:00:00');