-- Verwendung der Master-Datenbank für administrative Aufgaben
USE Master;

-- Löscht die Datenbank 'BackendSkiService', falls sie bereits existiert
DROP DATABASE IF EXISTS BackendSkiService;

-- Erstellt eine neue Datenbank mit dem Namen 'BackendSkiService'
CREATE DATABASE BackendSkiService;

-- Wechselt zur neu erstellten 'BackendSkiService'-Datenbank, um Tabellen zu erstellen
USE BackendSkiService;

-- Erstellt eine neue Tabelle 'Bestellungen' innerhalb der 'BackendSkiService'-Datenbank
CREATE TABLE Bestellungen (
    -- Primärschlüssel der Tabelle, automatisch inkrementierend beginnend bei 1
    BestellungsID INT IDENTITY(1, 1) PRIMARY KEY,

    -- Spalte für den Namen des Bestellers, erfordert eine Eingabe (kann nicht NULL sein)
    Name VARCHAR(255) NOT NULL,

    -- Spalte für die E-Mail-Adresse des Bestellers, erfordert eine Eingabe
    Emailadresse VARCHAR(255) NOT NULL,

    -- Optionale Spalte für die Telefonnummer des Bestellers
    Telefonnummer VARCHAR(20),

    -- Optionale Spalte für das Lieferdatum der Bestellung
    Lieferdatum DATE,

    -- Optionale Spalte für zusätzliche Serviceinformationen
    Service VARCHAR(50)
);
