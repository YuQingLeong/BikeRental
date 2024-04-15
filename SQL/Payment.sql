CREATE TABLE Payment (
    PaymentID INT NOT NULL PRIMARY KEY IDENTITY,
    CustomerID INT NOT NULL,
    Method VARCHAR(200) NOT NULL,
    Amount DECIMAL(6,2) NOT NULL,
    Time DATETIME,
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID) ON DELETE CASCADE ON UPDATE CASCADE
);

INSERT INTO Payment (CustomerID, Method, Amount, Time)
VALUES 
(1, 'Credit Card', 75.00, '2024-03-18 11:00:00'),
(2, 'Credit Card', 40.00, '2024-03-18 13:00:00'),
(4, 'Cash', 60.00, '2024-03-20 10:00:00'),
(7, 'Online Transfer', 92.00, '2024-03-20 15:00:00');
