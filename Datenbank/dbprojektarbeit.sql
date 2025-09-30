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
-- Tabellenstruktur für Tabelle `manufacturer`
--

CREATE TABLE `manufacturer` (
  `manufacturerId` int(11) NOT NULL,
  `manufacturerName` varchar(250) DEFAULT NULL,
  `address` varchar(250) DEFAULT NULL,
  `phoneNumber` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Daten für Tabelle `manufacturer`
--

INSERT INTO `manufacturer` (`manufacturerId`, `manufacturerName`, `address`, `phoneNumber`) VALUES
(1, 'Siemens', 'München, Deutschland', '+49 89 123456'),
(2, 'Bosch', 'Stuttgart, Deutschland', '+49 711 654321'),
(3, 'Honeywell', 'New York, USA', '+1 212 111222');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `log`
--

CREATE TABLE `log` (
  `logId` int(11) NOT NULL,
  `date` datetime DEFAULT NULL,
  `userId` int(11) DEFAULT NULL,
  `sensorNr` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Daten für Tabelle `log`
--

INSERT INTO `log` (`logId`, `date`, `userId`, `sensorNr`) VALUES
(1, '2025-09-25 08:05:00', 1, 1),
(2, '2025-09-25 09:05:00', 2, 2),
(3, '2025-09-25 09:20:00', 3, 3),
(4, '2025-09-25 09:25:00', 1, 2);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `user`
--

CREATE TABLE `user` (
  `userId` int(11) NOT NULL,
  `username` varchar(250) DEFAULT NULL,
  `name` varchar(250) DEFAULT NULL,
  `password` varchar(250) DEFAULT NULL,
  `phoneNumber` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Daten für Tabelle `user`
--

INSERT INTO `user` (`userId`, `username`, `name`, `password`, `phoneNumber`) VALUES
(1, 'admin', 'Max Mustermann', 'admin123', '+49 170 1111111'),
(2, 'user1', 'Anna Schmidt', 'passwort', '+49 170 2222222'),
(3, 'user2', 'Peter Müller', '123456', '+49 170 3333333');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `sensor`
--

CREATE TABLE `sensor` (
  `sensorNr` int(11) NOT NULL,
  `address` varchar(250) DEFAULT NULL,
  `maxTemp` double DEFAULT NULL,
  `serverRack` varchar(250) DEFAULT NULL,
  `manufacturerId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Daten für Tabelle `sensor`
--

INSERT INTO `sensor` (`sensorNr`, `address`, `maxTemp`, `serverRack`, `manufacturerId`) VALUES
(1, 'Serverraum A - Rack 1', 70, 'Rack A1', 1),
(2, 'Serverraum A - Rack 2', 65, 'Rack A2', 2),
(3, 'Serverraum B - Rack 3', 60, 'Rack B3', 3);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `temperature`
--

CREATE TABLE `temperature` (
  `temperatureNr` int(11) NOT NULL,
  `temperatureValue` double DEFAULT NULL,
  `time` datetime DEFAULT NULL,
  `sensorNr` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Daten für Tabelle `temperature`
--

INSERT INTO `temperature` (`temperatureNr`, `temperatureValue`, `time`, `sensorNr`) VALUES
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
-- Indizes für die Tabelle `manufacturer`
--
ALTER TABLE `manufacturer`
  ADD PRIMARY KEY (`manufacturerId`);

--
-- Indizes für die Tabelle `log`
--
ALTER TABLE `log`
  ADD PRIMARY KEY (`logId`),
  ADD KEY `userId` (`userId`),
  ADD KEY `sensorNr` (`sensorNr`);

--
-- Indizes für die Tabelle `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`userId`);

--
-- Indizes für die Tabelle `sensor`
--
ALTER TABLE `sensor`
  ADD PRIMARY KEY (`sensorNr`),
  ADD KEY `manufacturerId` (`manufacturerId`);

--
-- Indizes für die Tabelle `temperature`
--
ALTER TABLE `temperature`
  ADD PRIMARY KEY (`temperatureNr`),
  ADD KEY `sensorNr` (`sensorNr`);

--
-- AUTO_INCREMENT für exportierte Tabellen
--

--
-- AUTO_INCREMENT für Tabelle `manufacturer`
--
ALTER TABLE `manufacturer`
  MODIFY `manufacturerId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT für Tabelle `log`
--
ALTER TABLE `log`
  MODIFY `logId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT für Tabelle `user`
--
ALTER TABLE `user`
  MODIFY `userId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT für Tabelle `sensor`
--
ALTER TABLE `sensor`
  MODIFY `sensorNr` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT für Tabelle `temperature`
--
ALTER TABLE `temperature`
  MODIFY `temperatureNr` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Constraints der exportierten Tabellen
--

--
-- Constraints der Tabelle `log`
--
ALTER TABLE `log`
  ADD CONSTRAINT `log_ibfk_1` FOREIGN KEY (`userId`) REFERENCES `user` (`userId`),
  ADD CONSTRAINT `log_ibfk_2` FOREIGN KEY (`sensorNr`) REFERENCES `sensor` (`sensorNr`);

--
-- Constraints der Tabelle `sensor`
--
ALTER TABLE `sensor`
  ADD CONSTRAINT `sensor_ibfk_1` FOREIGN KEY (`manufacturerId`) REFERENCES `manufacturer` (`manufacturerId`);

--
-- Constraints der Tabelle `temperature`
--
ALTER TABLE `temperature`
  ADD CONSTRAINT `temperature_ibfk_1` FOREIGN KEY (`sensorNr`) REFERENCES `sensor` (`sensorNr`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
