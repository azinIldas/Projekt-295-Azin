Use Master;
Drop Database if Exists BackendSkiService;

Create Database BackendSkiService;
Use BackendSkiService;

CREATE TABLE Bestellungen (
    BestellungsID INT IDENTITY(1, 1) PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Emailadresse VARCHAR(255) NOT NULL,
    Telefonnummer VARCHAR(20),
    Lieferdatum DATE,
    Service VARCHAR(50)
);

