USE `ironbot1970`;

-- DELETE FROM `Rentals`;
-- DELETE FROM `Cart`;
-- DELETE FROM `BillingAddresses`;
-- DELETE FROM `Users`;
-- DELETE FROM `Robots`;
-- DELETE FROM `Categories`;

-- Beszúrás a Categories táblába
INSERT INTO `Categories` (`Name`, `Description`, `ImageUrl`, `IsDeleted`)
VALUES
    ('Fűnyíró', 'Kertészeti robotok', 'fűnyíro_image.jpg', 0),
    ('Drón', 'Repülő drónok', 'dron_image.jpg', 0),
    ('Porszívó', 'Háztartási porszívók', 'porszivo_image.jpg', 0);

-- Beszúrás a BillingAddresses táblába
INSERT INTO `BillingAddresses` (`FullName`, `VATNumber`, `Country`, `City`, `Zip`, `Address`)
VALUES
    ('Teszt Felhasználó', '12345678', 'Magyarország', 'Budapest', '12345', 'Teszt utca 1.');

-- Beszúrás a Users táblába (10 felhasználó)
INSERT INTO `Users` (`Username`, `PasswordHash`, `PasswordSalt`, `Email`, `Phone`, `Mobile`, `FirstName`, `LastName`, `Country`, `City`, `Zip`, `Address`, `BillingAddressId`, `Status`, `IsValidated`, `ValidationUrl`, `IsAdmin`)
VALUES
    ('teszt_user1', 'hashed_password1', 'salt1', 'teszt1@example.com', NULL, '06123456789', 'Teszt', 'Felhasználó1', 'Magyarország', 'Budapest', '12345', 'Teszt utca 2.', 1, 1, 1, 'validation_url1', 0),
    ('teszt_user2', 'hashed_password2', 'salt2', 'teszt2@example.com', NULL, '06234567890', 'Teszt', 'Felhasználó2', 'Magyarország', 'Debrecen', '67890', 'Teszt utca 3.', NULL, 1, 1, 'validation_url2', 0),
    ('teszt_user3', 'hashed_password3', 'salt3', 'teszt3@example.com', NULL, '06345678901', 'Teszt', 'Felhasználó3', 'Magyarország', 'Miskolc', '56789', 'Teszt utca 4.', NULL, 1, 1, 'validation_url3', 0),
    ('teszt_user4', 'hashed_password4', 'salt4', 'teszt4@example.com', NULL, '06456789012', 'Teszt', 'Felhasználó4', 'Magyarország', 'Szeged', '23456', 'Teszt utca 5.', NULL, 1, 1, 'validation_url4', 0),
    ('teszt_user5', 'hashed_password5', 'salt5', 'teszt5@example.com', NULL, '06567890123', 'Teszt', 'Felhasználó5', 'Magyarország', 'Pécs', '45678', 'Teszt utca 6.', NULL, 1, 1, 'validation_url5', 0),
    ('teszt_user6', 'hashed_password6', 'salt6', 'teszt6@example.com', NULL, '06678901234', 'Teszt', 'Felhasználó6', 'Magyarország', 'Győr', '34567', 'Teszt utca 7.', NULL, 1, 1, 'validation_url6', 0),
    ('teszt_user7', 'hashed_password7', 'salt7', 'teszt7@example.com', NULL, '06789012345', 'Teszt', 'Felhasználó7', 'Magyarország', 'Eger', '56789', 'Teszt utca 8.', NULL, 1, 1, 'validation_url7', 0),
    ('teszt_user8', 'hashed_password8', 'salt8', 'teszt8@example.com', NULL, '06890123456', 'Teszt', 'Felhasználó8', 'Magyarország', 'Székesfehérvár', '67890', 'Teszt utca 9.', NULL, 1, 1, 'validation_url8', 0),
    ('teszt_user9', 'hashed_password9', 'salt9', 'teszt9@example.com', NULL, '06901234567', 'Teszt', 'Felhasználó9', 'Magyarország', 'Nyíregyháza', '78901', 'Teszt utca 10.', NULL, 1, 1, 'validation_url9', 0),
    ('teszt_user10', 'hashed_password10', 'salt10', 'teszt10@example.com', NULL, '06987654321', 'Teszt', 'Felhasználó10', 'Magyarország', 'Sopron', '89012', 'Teszt utca 11.', NULL, 1, 1, 'validation_url10', 0);

-- Beszúrás a Robots táblába (legalább 15 robot kategóriánként)
INSERT INTO `Robots` (`Name`, `Description`, `ThumbnailUrl`, `PhotoUrl`, `CategoryId`, `Manufacturer`, `ManufactureYear`, `RentalFee`, `Deposit`, `Status`)
VALUES
    -- Kategória: Fűnyíró
    ('Fűnyíró Robot 1', 'Automata fűnyíró', 'robot1_thumbnail.jpg', 'robot1_photo.jpg', 1, 'Gyártó1', 2020, 50.00, 100.00, 0),
    ('Fűnyíró Robot 2', 'Önjáró fűnyíró', 'robot2_thumbnail.jpg', 'robot2_photo.jpg', 1, 'Gyártó2', 2021, 60.00, 120.00, 0),
    ('Fűnyíró Robot 3', 'Okos fűnyíró', 'robot3_thumbnail.jpg', 'robot3_photo.jpg', 1, 'Gyártó3', 2022, 70.00, 140.00, 0),
    ('Fűnyíró Robot 4', 'Háziasszony fűnyíró', 'robot4_thumbnail.jpg', 'robot4_photo.jpg', 1, 'Gyártó4', 2019, 55.00, 110.00, 0),
    ('Fűnyíró Robot 5', 'Professzionális fűnyíró', 'robot5_thumbnail.jpg', 'robot5_photo.jpg', 1, 'Gyártó5', 2023, 75.00, 150.00, 0),
    -- Kategória: Drón
    ('Drón Robot 1', 'Repülő drón', 'robot6_thumbnail.jpg', 'robot6_photo.jpg', 2, 'Gyártó6', 2022, 80.00, 150.00, 0),
    ('Drón Robot 2', 'Kamerás drón', 'robot7_thumbnail.jpg', 'robot7_photo.jpg', 2, 'Gyártó7', 2021, 100.00, 200.00, 0),
    ('Drón Robot 3', 'Szállító drón', 'robot8_thumbnail.jpg', 'robot8_photo.jpg', 2, 'Gyártó8', 2023, 120.00, 250.00, 0),
    ('Drón Robot 4', 'Vadász drón', 'robot9_thumbnail.jpg', 'robot9_photo.jpg', 2, 'Gyártó9', 2020, 90.00, 180.00, 0),
    ('Drón Robot 5', 'Hobby drón', 'robot10_thumbnail.jpg', 'robot10_photo.jpg', 2, 'Gyártó10', 2019, 70.00, 140.00, 0),
    -- Kategória: Porszívó
    ('Porszívó Robot 1', 'Okos porszívó', 'robot11_thumbnail.jpg', 'robot11_photo.jpg', 3, 'Gyártó11', 2020, 30.00, 80.00, 0),
    ('Porszívó Robot 2', 'Robot porszívó', 'robot12_thumbnail.jpg', 'robot12_photo.jpg', 3, 'Gyártó12', 2019, 40.00, 90.00, 0),
    ('Porszívó Robot 3', 'Wi-Fi porszívó', 'robot13_thumbnail.jpg', 'robot13_photo.jpg', 3, 'Gyártó13', 2021, 35.00, 75.00, 0),
    ('Porszívó Robot 4', 'Automata porszívó', 'robot14_thumbnail.jpg', 'robot14_photo.jpg', 3, 'Gyártó14', 2023, 50.00, 100.00, 0),
    ('Porszívó Robot 5', 'Csendes porszívó', 'robot15_thumbnail.jpg', 'robot15_photo.jpg', 3, 'Gyártó15', 2022, 45.00, 95.00, 0);

-- Beszúrás a Cart táblába (minta foglalások)
INSERT INTO `Cart` (`UserId`, `RobotId`, `StartDate`, `EndDate`)
VALUES
    (1, 1, '2023-10-15', '2023-10-20'),
    (2, 2, '2023-11-01', '2023-11-05');

-- Beszúrás a Rentals táblába (minta foglalások)
INSERT INTO `Rentals` (`RentalGroup`, `UserId`, `RobotId`, `StartDate`, `EndDate`, `RentalFee`, `RentalDeposit`, `RentalTotalAmount`, `IsDepositPaid`, `IsRentalTotalAmountPaid`, `IsDepositRefunded`, `Status`)
VALUES
    ('20231015-1', 1, 1, '2023-10-15', '2023-10-20', 250.00, 100.00, 350.00, 1, 1, 0, 1),
    ('20231101-1', 2, 2, '2023-11-01', '2023-11-05', 320.00, 150.00, 470.00, 1, 0, 0, 0);
