DROP TABLE IF EXISTS dbo.Clients;
DROP TABLE IF EXISTS dbo.Vehicles;

CREATE TABLE dbo.Clients (
	client_id int IDENTITY(1,1) PRIMARY KEY,
	client_name varchar(50) NOT NULL,
	client_surname varchar(50) NOT NULL
);
GO

CREATE TABLE dbo.Vehicles (
	vehicle_id int IDENTITY(1,1) PRIMARY KEY,
	client_id int FOREIGN KEY REFERENCES dbo.Clients(client_id),
	vehicle_name varchar(50) NOT NULL,
	capacity real NOT NULL
);
GO
