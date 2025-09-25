-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Erstellungszeit: 25. Sep 2025 um 09:27
-- Server-Version: 10.4.32-MariaDB
-- PHP-Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Datenbank: `dbprojektarbeit`
--

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `hersteller`
--

CREATE TABLE `hersteller` (
  `HerstellerId` int(11) NOT NULL,
  `Herstellername` varchar(250) DEFAULT NULL,
  `Adresse` varchar(250) DEFAULT NULL,
  `Telefonnummer` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Daten für Tabelle `hersteller`
--

INSERT INTO `hersteller` (`HerstellerId`, `Herstellername`, `Adresse`, `Telefonnummer`) VALUES
(1, 'Siemens', 'München, Deutschland', '+49 89 123456'),
(2, 'Bosch', 'Stuttgart, Deutschland', '+49 711 654321'),
(3, 'Honeywell', 'New York, USA', '+1 212 111222');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `log`
--

CREATE TABLE `log` (
  `LogId` int(11) NOT NULL,
  `Datum` datetime DEFAULT NULL,
  `NutzerId` int(11) DEFAULT NULL,
  `SensorNr` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Daten für Tabelle `log`
--

INSERT INTO `log` (`LogId`, `Datum`, `NutzerId`, `SensorNr`) VALUES
(1, '2025-09-25 08:05:00', 1, 1),
(2, '2025-09-25 09:05:00', 2, 2),
(3, '2025-09-25 09:20:00', 3, 3),
(4, '2025-09-25 09:25:00', 1, 2);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `nutzer`
--

CREATE TABLE `nutzer` (
  `NutzerId` int(11) NOT NULL,
  `Anmeldename` varchar(250) DEFAULT NULL,
  `Name` varchar(250) DEFAULT NULL,
  `Passwort` varchar(250) DEFAULT NULL,
  `Telefonnummer` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Daten für Tabelle `nutzer`
--

INSERT INTO `nutzer` (`NutzerId`, `Anmeldename`, `Name`, `Passwort`, `Telefonnummer`) VALUES
(1, 'admin', 'Max Mustermann', 'admin123', '+49 170 1111111'),
(2, 'user1', 'Anna Schmidt', 'passwort', '+49 170 2222222'),
(3, 'user2', 'Peter Müller', '123456', '+49 170 3333333');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `sensor`
--

CREATE TABLE `sensor` (
  `SensorNr` int(11) NOT NULL,
  `Adresse` varchar(250) DEFAULT NULL,
  `MaxTemp` double DEFAULT NULL,
  `Serverschrank` varchar(250) DEFAULT NULL,
  `HerstellerId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Daten für Tabelle `sensor`
--

INSERT INTO `sensor` (`SensorNr`, `Adresse`, `MaxTemp`, `Serverschrank`, `HerstellerId`) VALUES
(1, 'Serverraum A - Rack 1', 70, 'Rack A1', 1),
(2, 'Serverraum A - Rack 2', 65, 'Rack A2', 2),
(3, 'Serverraum B - Rack 3', 60, 'Rack B3', 3);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `temperatur`
--

CREATE TABLE `temperatur` (
  `TemperaturNr` int(11) NOT NULL,
  `Temperaturwert` double DEFAULT NULL,
  `Zeit` datetime DEFAULT NULL,
  `SensorNr` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Daten für Tabelle `temperatur`
--

INSERT INTO `temperatur` (`TemperaturNr`, `Temperaturwert`, `Zeit`, `SensorNr`) VALUES
(1, 32.5, '2025-09-25 08:00:00', 1),
(2, 35.2, '2025-09-25 09:00:00', 1),
(3, 29.8, '2025-09-25 08:30:00', 2),
(4, 40.1, '2025-09-25 09:15:00', 2),
(5, 28, '2025-09-25 08:45:00', 3),
(6, 30.5, '2025-09-25 09:30:00', 3);

--
-- Indizes der exportierten Tabellen
--

--
-- Indizes für die Tabelle `hersteller`
--
ALTER TABLE `hersteller`
  ADD PRIMARY KEY (`HerstellerId`);

--
-- Indizes für die Tabelle `log`
--
ALTER TABLE `log`
  ADD PRIMARY KEY (`LogId`),
  ADD KEY `NutzerId` (`NutzerId`),
  ADD KEY `SensorNr` (`SensorNr`);

--
-- Indizes für die Tabelle `nutzer`
--
ALTER TABLE `nutzer`
  ADD PRIMARY KEY (`NutzerId`);

--
-- Indizes für die Tabelle `sensor`
--
ALTER TABLE `sensor`
  ADD PRIMARY KEY (`SensorNr`),
  ADD KEY `HerstellerId` (`HerstellerId`);

--
-- Indizes für die Tabelle `temperatur`
--
ALTER TABLE `temperatur`
  ADD PRIMARY KEY (`TemperaturNr`),
  ADD KEY `SensorNr` (`SensorNr`);

--
-- AUTO_INCREMENT für exportierte Tabellen
--

--
-- AUTO_INCREMENT für Tabelle `hersteller`
--
ALTER TABLE `hersteller`
  MODIFY `HerstellerId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT für Tabelle `log`
--
ALTER TABLE `log`
  MODIFY `LogId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT für Tabelle `nutzer`
--
ALTER TABLE `nutzer`
  MODIFY `NutzerId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT für Tabelle `sensor`
--
ALTER TABLE `sensor`
  MODIFY `SensorNr` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT für Tabelle `temperatur`
--
ALTER TABLE `temperatur`
  MODIFY `TemperaturNr` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Constraints der exportierten Tabellen
--

--
-- Constraints der Tabelle `log`
--
ALTER TABLE `log`
  ADD CONSTRAINT `log_ibfk_1` FOREIGN KEY (`NutzerId`) REFERENCES `nutzer` (`NutzerId`),
  ADD CONSTRAINT `log_ibfk_2` FOREIGN KEY (`SensorNr`) REFERENCES `sensor` (`SensorNr`);

--
-- Constraints der Tabelle `sensor`
--
ALTER TABLE `sensor`
  ADD CONSTRAINT `sensor_ibfk_1` FOREIGN KEY (`HerstellerId`) REFERENCES `hersteller` (`HerstellerId`);

--
-- Constraints der Tabelle `temperatur`
--
ALTER TABLE `temperatur`
  ADD CONSTRAINT `temperatur_ibfk_1` FOREIGN KEY (`SensorNr`) REFERENCES `sensor` (`SensorNr`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
