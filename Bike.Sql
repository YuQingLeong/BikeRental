CREATE TABLE Bikes (
    BikeID INT NOT NULL PRIMARY KEY IDENTITY,
    type VARCHAR(200) NOT NULL,
    bikeModel VARCHAR(200) NOT NULL,
    availability INT NOT NULL,
    price DECIMAL(5,2) NOT NULL
);

INSERT INTO Rental(type, model, price)
VALUES
('touring bike', 'hello111', '25.00'),
('mountain bike', 'hello243', '20.00'),
('road bike', 'hello555', '20.00'),
('cuiser bike', 'hello123', '23.00');