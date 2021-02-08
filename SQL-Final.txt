CREATE DATABASE QuickCar
GO
USE QuickCar
GO

CREATE TABLE Cars(
CarID int IDENTITY(1,1) PRIMARY KEY Not Null,
NameCar nchar(50) Not Null,
YearCar int DEFAULT YEAR(GetDate()) Not Null 
		CHECK(YearCar BETWEEN YEAR(GetDate())-10 AND YEAR(GetDate())),
TotalUsedTimes tinyint CHECK(TotalUsedTimes BETWEEN 0 AND 50) DEFAULT 0
)

CREATE TABLE Clients(
ClientID int IDENTITY(1,1) PRIMARY KEY Not Null,
ClientName nchar(30) Not Null,
ClientSurname nchar(30) Not Null,
)

CREATE TABLE CarInUse(
HireID int IDENTITY(1,1) PRIMARY KEY Not Null,
ClientID int Not Null,
CarID int Not Null,
StartTime datetime DEFAULT GetDate() CHECK(StartTime>= GetDate()),
StopTime datetime CHECK (StopTime>= GetDate()+1) Not null,
CONSTRAINT FK_Client_CarInUse FOREIGN KEY (ClientID) REFERENCES Clients (ClientID) ON DELETE NO ACTION,
CONSTRAINT FK_Car_CarInUse FOREIGN KEY (CarID) REFERENCES Cars (CarID) ON DELETE NO ACTION
)

CREATE TABLE RepairStatus(
RepairStatusID int IDENTITY(1,1) PRIMARY KEY,
RepairStatusText nchar(50) UNIQUE Not null,
)

CREATE TABLE CarsInService(
CarsInServiceID int IDENTITY(1,1) PRIMARY KEY Not null,
CarID int Not Null,
Comments nchar(250),
CarStatus int Not Null,	
StartServTime datetime DEFAULT GetDate() CHECK(StartServTime>= GetDate()),
StopServTime datetime CHECK(StopServTime>= GetDate()+1),
CONSTRAINT FK_CarInService_RepairStatus FOREIGN KEY (CarStatus) REFERENCES RepairStatus (RepairStatusID) ON DELETE NO ACTION,
CONSTRAINT FK_Car_CarInService FOREIGN KEY (CarID) REFERENCES Cars (CarID) ON DELETE NO ACTION
)

CREATE TABLE CarsSold(
CarsSoldID int IDENTITY(1,1) PRIMARY KEY Not Null,
CarID int UNIQUE Not Null,
SoldTime datetime DEFAULT GetDate()
CONSTRAINT FK_Cars_CarsSold FOREIGN KEY (CarID) REFERENCES Cars (CarID) ON DELETE NO ACTION,
)

INSERT into Cars (NameCar,YearCar) values ('Pontiac GTO','2019'), ('Ford Fiesta','2017'), ('Porsche GT3 RS','2018'), ('Opel Corsa F', '2019'), ('Ford Mustang GT', '2016')

INSERT into Clients (ClientName, ClientSurname) values ('David', 'Beckham'), ('John', 'Cena'), ('Tom', 'Hanks')

INSERT into RepairStatus (RepairStatusText) values ('InQueue'), ('Repairing'), ('Repaired')

INSERT into CarsSold (CarID) values ('1'), ('4')

INSERT into CarsInService (CarID, Comments, CarStatus, StopServTime) values ('2', 'Changing Tyres to Winter.', '1', GetDate()+2), ('5', 'Replacing the front bumper.', '2', GetDate()+1.5672)

INSERT into CarInUse (ClientID, CarID, StopTime) values ('1', '3', GetDate()+3)

GO