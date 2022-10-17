CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `Albums` (
    `album_id` NVARCHAR(32) NOT NULL,
    `name` NVARCHAR(200) NOT NULL,
    `billboard` NVARCHAR(200) NULL,
    `artists` longtext CHARACTER SET utf8mb4 NOT NULL,
    `popularity` int NULL,
    `total_tracks` int NOT NULL,
    `album_type` NVARCHAR(50) NULL,
    `image_url` NVARCHAR(600) NULL,
    CONSTRAINT `PK_Albums` PRIMARY KEY (`album_id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Artists` (
    `artist_id` NVARCHAR(32) NOT NULL,
    `name` NVARCHAR(200) NOT NULL,
    `followers` int NULL,
    `popularity` int NULL,
    `artist_type` NVARCHAR(50) NULL,
    `main_genre` NVARCHAR(100) NULL,
    `genres` longtext CHARACTER SET utf8mb4 NULL,
    `image_url` NVARCHAR(600) NULL,
    CONSTRAINT `PK_Artists` PRIMARY KEY (`artist_id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Releases` (
    `artist_id` NVARCHAR(32) NOT NULL,
    `album_id` NVARCHAR(32) NOT NULL,
    `release_date` NVARCHAR(50) NOT NULL,
    `release_date_precision` NVARCHAR(20) NOT NULL,
    CONSTRAINT `PK_Releases` PRIMARY KEY (`album_id`, `artist_id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Songs` (
    `song_id` NVARCHAR(32) NOT NULL,
    `song_name` NVARCHAR(200) NOT NULL,
    `billboard` NVARCHAR(200) NULL,
    `artists` longtext CHARACTER SET utf8mb4 NOT NULL,
    `release_date_precision` NVARCHAR(20) NOT NULL,
    `popularity` int NULL,
    `explicit` BOOLEAN(1) NULL,
    `song_type` NVARCHAR(50) NULL,
    CONSTRAINT `PK_Songs` PRIMARY KEY (`song_id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Tracks` (
    `song_id` NVARCHAR(32) NOT NULL,
    `album_id` NVARCHAR(32) NOT NULL,
    `track_number` int NOT NULL,
    `release_date` NVARCHAR(50) NOT NULL,
    `release_date_precision` NVARCHAR(20) NOT NULL,
    CONSTRAINT `PK_Tracks` PRIMARY KEY (`song_id`, `album_id`)
) CHARACTER SET=utf8mb4;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20221017015337_Initial', '6.0.10');

COMMIT;