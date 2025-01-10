
-- Adatbázis létrehozása
CREATE DATABASE IF NOT EXISTS VikingLotto;
USE VikingLotto;

-- Tábla az importált adatok számára
CREATE TABLE IF NOT EXISTS ImportedNumbers (
    id INT AUTO_INCREMENT PRIMARY KEY,
    number1 TINYINT NOT NULL,
    number2 TINYINT NOT NULL,
    number3 TINYINT NOT NULL,
    number4 TINYINT NOT NULL,
    number5 TINYINT NOT NULL,
    number6 TINYINT NOT NULL
);

-- Tábla a sorsolt számok számára
CREATE TABLE IF NOT EXISTS DrawnNumbers (
    id INT AUTO_INCREMENT PRIMARY KEY,
    draw_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    number1 TINYINT NOT NULL,
    number2 TINYINT NOT NULL,
    number3 TINYINT NOT NULL,
    number4 TINYINT NOT NULL,
    number5 TINYINT NOT NULL,
    number6 TINYINT NOT NULL
);
