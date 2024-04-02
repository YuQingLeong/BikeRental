#1. Customer Table
#1.1 INSERT
INSERT INTO Customer (name, phone, email, address)
VALUES
('Trinity', '+3169991111', 'trinity@gmail.com', 'Wichita, USA');

#1.2 SELECT
SELECT * FROM Customer;

#1.3 UPDATE
UPDATE Customer
SET email = 'trinity1@gmail.com'
WHERE name = 'Trinity';

# ----------------------------------------------------------------------------------------------------------------

#2. Bikes Table
#2.1 INSERT
INSERT INTO Bikes (type, model, price)
VALUES
('touring bike', 'hello131', 25.00);

#2.2 SELECT
SELECT * FROM Bikes;

#2.3 UPDATE
UPDATE Bikes
SET price = 30.00 
WHERE model = 'hello131';

#----------------------------------------------------------------------------------------------------------------

#3. Rental Table
#3.1 INSERT
INSERT INTO Rental (CustomerID, BikeID, rentalDuration, rentalStartTime)
VALUES
(5, 5, 2.00, '2024-03-19 11:00:00');

#3.2 SELECT
SELECT * FROM Rental;

#3.3 UPDATE
UPDATE Rental
SET rentalDuration = 5.00
WHERE CustomerID = 1;

#----------------------------------------------------------------------------------------------------------------

#4. Payment Table
#4.1 INSERT
INSERT INTO Payment (CustomerID, Method, Amount, Time)
VALUES 
(5, 'Credit Card', 20.00, '2024-03-20 11:00:00');

#4.2 SELECT
SELECT * FROM Payment;

#4.3 UPDATE
UPDATE Payment
SET Method = Cash
WHERE CustomerID = 5;
