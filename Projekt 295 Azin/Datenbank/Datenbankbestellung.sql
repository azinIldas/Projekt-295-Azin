-- Verwendung der Master-Datenbank f�r administrative Aufgaben
USE Master;

-- L�scht die Datenbank 'BackendSkiService', falls sie bereits existiert
DROP DATABASE IF EXISTS BackendSkiService;

-- Erstellt eine neue Datenbank mit dem Namen 'BackendSkiService'
CREATE DATABASE BackendSkiService;

-- Wechselt zur neu erstellten 'BackendSkiService'-Datenbank, um Tabellen zu erstellen
USE BackendSkiService;

-- Erstellt eine neue Tabelle 'Bestellungen' innerhalb der 'BackendSkiService'-Datenbank
CREATE TABLE Bestellungen (
    -- Prim�rschl�ssel der Tabelle, automatisch inkrementierend beginnend bei 1
    BestellungsID INT IDENTITY(1, 1) PRIMARY KEY,

    -- Spalte f�r den Namen des Bestellers, erfordert eine Eingabe (kann nicht NULL sein)
    Name VARCHAR(255) NOT NULL,

    -- Spalte f�r die E-Mail-Adresse des Bestellers, erfordert eine Eingabe
    Emailadresse VARCHAR(255) NOT NULL,

    -- Optionale Spalte f�r die Telefonnummer des Bestellers
    Telefonnummer VARCHAR(20),

    -- Optionale Spalte f�r das Lieferdatum der Bestellung
    Lieferdatum DATE,

    -- Optionale Spalte f�r zus�tzliche Serviceinformationen
    Service VARCHAR(50)
);

-- Um inhalt zu checken
Select * From Bestellungen;

---------------------------------
--- Logging Tabelle erstellen ---
USE BackendSkiService;

-- Erstellt eine neue Tabelle 'Benutzer'
CREATE TABLE Benutzer (
    -- Prim�rschl�ssel der Tabelle, automatisch inkrementierend beginnend bei 1
    BenutzerID INT IDENTITY(1, 1) PRIMARY KEY,

    -- Spalte f�r den Benutzernamen, darf nicht NULL sein
    Name VARCHAR(255) NOT NULL,

    -- Spalte f�r das Passwort, darf nicht NULL sein
    Password VARCHAR(255) NOT NULL,

    -- Spalte f�r den Adminstatus,  true oder false
    AdminStatus BIT NOT NULL
);

-- Optional: Einf�gen eines Testbenutzers in die Tabelle
INSERT INTO Benutzer (Name, Password, AdminStatus) VALUES ('TestUser', 'TestPasswort', 0);

-- Um den Inhalt der Tabelle zu �berpr�fen
SELECT * FROM Benutzer;