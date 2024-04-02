INSERT INTO Customer (name, email, phone, address)
VALUES
('Natalie', 'natalie@gmail.com', '+13161468575', 'Kansas, USA'),
('Khang', 'khang@gmail.com', '+14164577795', 'Kansas, USA'),
('Alice', 'alice@gmail.com', '+17563638864', 'Kansas, USA'),
('Bob', 'bob@gmail.com', '+16437784354', 'Kansas, USA');

INSERT INTO Bikes(type,model, price)
VALUES
('touring bike', 'hello111', 25.00),
('mountain bike', 'hello243', 20.00),
('road bike', 'hello555', 20.00),
('cruiser bike', 'hello123', 23.00);

INSERT INTO Rental (CustomerID, BikeID, PaymentID, rentalDuration, rentalStartTime)
VALUES
(1, 1, 2.00, 1, '2024-03-15 11:00:00'),
(2, 2, 3, 2, '2024-03-16 13:00:00'),
(3, 3, 5, 3, '2024-03-17 14:00:00'),
(4, 4, 1, 4, '2024-03-18 13:00:00');

INSERT INTO Payment (CustomerID, Method, Amount, Time)
VALUES 
(1, 'Credit Card', 20.00, '2024-03-18 11:00:00'),
(2, 'Credit Card', 25.00, '2024-03-18 13:00:00'),
(3, 'Cash', 20.00, '2024-03-20 10:00:00'),
(4, 'Online Transfer', 30.00, '2024-03-20 15:00:00');
