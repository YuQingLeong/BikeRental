CREATE Table Customer (
	CustomerID INT NOT NULL PRIMARY KEY IDENTITY,
	name VARCHAR (100) NOT NULL,
	email VARCHAR (150) NOT NULL UNIQUE,
	phone VARCHAR (20) NULL,
	address VARCHAR (100) NULL
);

CREATE TABLE Bikes (
    BikeID INT NOT NULL PRIMARY KEY IDENTITY,
    type VARCHAR(200) NOT NULL,
    model VARCHAR(200) NOT NULL,
    price DECIMAL(5,2) NOT NULL
);

CREATE Table Rental (
	RentalID INT NOT NULL PRIMARY KEY IDENTITY,
	CustomerID INT NOT NULL,
	BikeID INT NOT NULL,
	PaymentID INT NOT NULL,
	rentalDuration DECIMAL(5,2) NOT NULL,
	rentalStartTime DATETIME,
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (BikeID) REFERENCES Bikes(BikeID) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (PaymentID) REFERENCES Payment(PaymentID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE Payment (
	PaymentID INT NOT NULL PRIMARY KEY IDENTITY,
    CustomerID INT NOT NULL,
    Method VARCHAR(200) NOT NULL,
	Amount DECIMAL(6,2) NOT NULL,
    Time DATETIME,
	FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID) ON DELETE CASCADE ON UPDATE CASCADE
);