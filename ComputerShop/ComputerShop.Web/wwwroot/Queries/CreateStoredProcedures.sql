USE `computer_store`;

DROP PROCEDURE IF EXISTS `computer_store`.`add_user`;

CREATE PROCEDURE `computer_store`.`add_user` (IN email VARCHAR(255), IN passwordHash VARCHAR(255))
BEGIN 
INSERT INTO `User` (`Email`, `PasswordHash`, `RoleID`) values (email, passwordHash, 2);
END;

DROP PROCEDURE IF EXISTS `computer_store`.`get_user`;

CREATE PROCEDURE `computer_store`.`get_user` (IN email VARCHAR(255))
BEGIN 
SELECT `User`.`ID`, `User`.`Email`, `User`.`PasswordHash`, `Role`.`ID`, `Role`.`Name`
FROM `User`
INNER JOIN `Role` ON `User`.`RoleID` = `Role`.`ID`
WHERE `User`.`Email` = email;
END;

DROP PROCEDURE IF EXISTS `computer_store`.`add_manufacturer`;

CREATE PROCEDURE `computer_store`.`add_manufacturer` (IN name VARCHAR(255))
BEGIN 
INSERT INTO `Manufacturer` (`Name`) VALUES (name);
END;

DROP PROCEDURE IF EXISTS `computer_store`.`add_type`;

CREATE PROCEDURE `computer_store`.`add_type` (IN name VARCHAR(255))
BEGIN 
INSERT INTO `Type` (`Name`) VALUES (name);
END;

DROP PROCEDURE IF EXISTS `computer_store`.`add_product`;

CREATE PROCEDURE `computer_store`.`add_product` (IN name VARCHAR(255), IN description VARCHAR(255), IN typeID INT, IN manufacturerID INT, IN price DECIMAL, IN count INT)
BEGIN 
INSERT INTO `Product` (`Name`, `Description`, `TypeID`, `ManufacturerID`, `Price`, `Count`) values (name, description, typeID, manufacturerID, price, count);
END;

DROP PROCEDURE IF EXISTS `computer_store`.`get_product`;

CREATE PROCEDURE `computer_store`.`get_product` (IN ID INT)
BEGIN 
SELECT `Product`.`ID`, `Product`.`Name`, `Product`.`Description`, `Type`.`ID`, `Type`.`Name`, `Manufacturer`.`ID`, `Manufacturer`.`Name`, `Product`.`Price`, `Product`.`Count`
FROM `Product`
JOIN `Type` ON `Product`.`TypeID` = `Type`.`ID`
JOIN `Manufacturer` ON `Product`.`ManufacturerID` = `Manufacturer`.`ID`
WHERE `Product`.`ID` = ID;
END;

DROP PROCEDURE IF EXISTS `computer_store`.`get_product_range`;

CREATE PROCEDURE `computer_store`.`get_product_range` (IN `from` INT, IN `to` INT)
BEGIN 
SELECT `Product`.`ID`, `Product`.`Name`, `Product`.`Description`, `Type`.`ID`, `Type`.`Name`, `Manufacturer`.`ID`, `Manufacturer`.`Name`, `Product`.`Price`, `Product`.`Count`
FROM `Product`
JOIN `Type` ON `Product`.`TypeID` = `Type`.`ID`
JOIN `Manufacturer` ON `Product`.`ManufacturerID` = `Manufacturer`.`ID`
ORDER BY `Product`.`ID`
LIMIT `from`, `to`;
END;

DROP PROCEDURE IF EXISTS `computer_store`.`product_count`;

CREATE PROCEDURE `computer_store`.`product_count` ()
BEGIN 
SELECT COUNT(`Product`.`ID`)
FROM `Product`;
END;



