CREATE Table Rental (
	RentalID INT NOT NULL PRIMARY KEY IDENTITY,
	CustomerID INT NOT NULL,
	BikeID INT NOT NULL,
	rentalDuration DECIMAL(5,2) NOT NULL,
	rentalStartTime DATETIME,
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID) ON DELETE CASCADE,
    FOREIGN KEY (BikeID) REFERENCES Customer(BikeID) ON DELETE CASCADE
);

INSERT INTO Rental (CustomerID, BikeID, rentalDuration, rentalStartTime)
VALUES
('1', '1', '2.00', '1/2/2024 11:00AM'),
('2', '2', '3', '3/2/2024 12:00PM'),
('3', '3', '5', '3/6/2024 9:00AM'),
('4', '4', '1', '3/9/2024 8:00AM');