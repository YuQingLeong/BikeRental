CREATE Table Customer (
	id INT NOT NULL PRIMARY KEY IDENTITY,
	name VARCHAR (100) NOT NULL,
	email VARCHAR (150) NOT NULL UNIQUE,
	phone VARCHAR (20) NULL,
	address VARCHAR (100) NULL
);

INSERT INTO Customer (name, email, phone, address)
VALUES
('Natalie', 'natalie@gmail.com', '+13161468575', 'Kansas, USA'),
('Khang', 'khang@gmail.com', '+14164577795', 'Kansas, USA'),
('Alice', 'alice@gmail.com', '+17563638864', 'Kansas, USA'),
('Bob', 'bob@gmail.com', '+16437784354', 'Kansas, USA');