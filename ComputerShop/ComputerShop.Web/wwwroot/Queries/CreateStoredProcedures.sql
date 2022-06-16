USE `computer_store`;

DROP PROCEDURE IF EXISTS `computer_store`.`add_user`;

CREATE PROCEDURE `computer_store`.`add_user` (IN email VARCHAR(255), IN passwordHash VARCHAR(255), IN address VARCHAR(255), IN fullName VARCHAR(255))
BEGIN 
INSERT INTO `User` (`Email`, `PasswordHash`, `Address`, `FullName`,`RoleID`) values (email, passwordHash, address, fullName, 2);
END;

DROP PROCEDURE IF EXISTS `computer_store`.`get_user_list`;

CREATE PROCEDURE `computer_store`.`get_user_list` ()
BEGIN 
SELECT `User`.`ID`, `User`.`Email`, `User`.`PasswordHash`, `Role`.`ID`, `Role`.`Name`
FROM `User`
INNER JOIN `Role` ON `User`.`RoleID` = `Role`.`ID`;
END;

DROP PROCEDURE IF EXISTS `computer_store`.`get_user`;

CREATE PROCEDURE `computer_store`.`get_user` (IN email VARCHAR(255))
BEGIN 
SELECT `User`.`ID`, `User`.`Email`, `User`.`PasswordHash`, `User`.`Address`, `User`.`FullName`, `Role`.`ID`, `Role`.`Name`
FROM `User`
INNER JOIN `Role` ON `User`.`RoleID` = `Role`.`ID`
WHERE `User`.`Email` = email;
END;

DROP PROCEDURE IF EXISTS `computer_store`.`update_user`;

CREATE PROCEDURE `computer_store`.`update_user` (IN ID INT, IN address VARCHAR(255), IN fullName VARCHAR(255))
BEGIN 
UPDATE `User`
SET `User`.`Address` = address, `User`.`FullName` = fullName
WHERE `User`.`ID` = ID;
END;

DROP PROCEDURE IF EXISTS `computer_store`.`remove_user`;

CREATE PROCEDURE `computer_store`.`remove_user` (IN ID INT)
BEGIN 
DELETE
FROM `User`
WHERE `User`.`ID` = ID;
END;

DROP PROCEDURE IF EXISTS `computer_store`.`add_manufacturer`;

CREATE PROCEDURE `computer_store`.`add_manufacturer` (IN name VARCHAR(255))
BEGIN 
INSERT INTO `Manufacturer` (`Name`) VALUES (name);
END;

DROP PROCEDURE IF EXISTS `computer_store`.`get_manufacturer`;

CREATE PROCEDURE `computer_store`.`get_manufacturer` ()
BEGIN 
SELECT `Manufacturer`.`ID`, `Manufacturer`.`Name`
From `Manufacturer`;
END;

DROP PROCEDURE IF EXISTS `computer_store`.`add_type`;

CREATE PROCEDURE `computer_store`.`add_type` (IN name VARCHAR(255))
BEGIN 
INSERT INTO `Type` (`Name`) VALUES (name);
END;

DROP PROCEDURE IF EXISTS `computer_store`.`get_type`;

CREATE PROCEDURE `computer_store`.`get_type` ()
BEGIN 
SELECT `Type`.`ID`, `Type`.`Name`
From `Type`;
END;

DROP PROCEDURE IF EXISTS `computer_store`.`add_product`;

CREATE PROCEDURE `computer_store`.`add_product` (OUT ID INT, IN name VARCHAR(255), IN description VARCHAR(255), IN typeID INT, IN manufacturerID INT, IN price DECIMAL, IN count INT, IN pathToFile VARCHAR(255))
BEGIN 
INSERT INTO `Product` (`Name`, `Description`, `TypeID`, `ManufacturerID`, `Price`, `Count`, `PathToFile`) values (name, description, typeID, manufacturerID, price, count, pathToFile);
SELECT LAST_INSERT_ID() INTO ID;
END;

DROP PROCEDURE IF EXISTS `computer_store`.`add_characteristic`;

CREATE PROCEDURE `computer_store`.`add_characteristic` (IN productID INT, IN name VARCHAR(255), IN value VARCHAR(255))
BEGIN 
INSERT INTO `Characteristic` (`ProductID`, `Name`, `Value`) values (productID, name, value);
END;

DROP PROCEDURE IF EXISTS `computer_store`.`get_characteristic`;

CREATE PROCEDURE `computer_store`.`get_characteristic` (IN productID INT)
BEGIN 
SELECT `Characteristic`.`ID`, `Characteristic`.`ProductID`, `Characteristic`.`Name`, `Characteristic`.`Value`
FROM `Characteristic`
WHERE `Characteristic`.`ProductID` = productID;
END;

DROP PROCEDURE IF EXISTS `computer_store`.`get_product`;

CREATE PROCEDURE `computer_store`.`get_product` (IN ID INT)
BEGIN 
SELECT `Product`.`ID`, `Product`.`Name`, `Product`.`Description`, `Type`.`ID`, `Type`.`Name`, `Manufacturer`.`ID`, `Manufacturer`.`Name`, `Product`.`Price`, `Product`.`Count`, `Product`.`PathToFile`
FROM `Product`
INNER JOIN `Type` ON `Product`.`TypeID` = `Type`.`ID`
INNER JOIN `Manufacturer` ON `Product`.`ManufacturerID` = `Manufacturer`.`ID`
WHERE `Product`.`ID` = ID;
END;

DROP PROCEDURE IF EXISTS `computer_store`.`update_product`;

CREATE PROCEDURE `computer_store`.`update_product` (IN ID INT, IN name VARCHAR(255), IN description VARCHAR(255), IN typeID INT, IN manufacturerID INT, IN price DECIMAL, IN count INT, IN pathToFile VARCHAR(255))
BEGIN 
UPDATE `Product`
SET `Product`.`Name` = name, `Product`.`Description` = description, `Product`.`TypeID` = typeID, `Product`.`ManufacturerID` = manufacturerID, `Product`.`Price` = price, `Product`.`Count` = count, `Product`.`PathToFile` = pathToFile
WHERE `Product`.`ID` = ID;
END;

DROP PROCEDURE IF EXISTS `computer_store`.`remove_product`;

CREATE PROCEDURE `computer_store`.`remove_product` (IN ID INT)
BEGIN 
DELETE
FROM `Product`
WHERE `Product`.`ID` = ID;
END;

DROP PROCEDURE IF EXISTS `computer_store`.`get_product_range`;

CREATE PROCEDURE `computer_store`.`get_product_range` (IN `from` INT, IN `to` INT, IN search VARCHAR(255))
BEGIN 
SELECT `Product`.`ID`, `Product`.`Name`, `Product`.`Description`, `Type`.`ID`, `Type`.`Name`, `Manufacturer`.`ID`, `Manufacturer`.`Name`, `Product`.`Price`, `Product`.`Count`, `Product`.`PathToFile`
FROM `Product`
JOIN `Type` ON `Product`.`TypeID` = `Type`.`ID`
JOIN `Manufacturer` ON `Product`.`ManufacturerID` = `Manufacturer`.`ID`
WHERE `Product`.`Name` LIKE CONCAT('%', search, '%') 
ORDER BY `Product`.`ID`
LIMIT `from`, `to`;
END;

DROP PROCEDURE IF EXISTS `computer_store`.`product_count`;

CREATE PROCEDURE `computer_store`.`product_count` ()
BEGIN 
SELECT COUNT(`Product`.`ID`)
FROM `Product`;
END;

DROP PROCEDURE IF EXISTS `computer_store`.`get_input`;

CREATE PROCEDURE `computer_store`.`get_input` ()
BEGIN 
SELECT `Input`.`ID`, `Input`.`ProductID`, `Input`.`Count`, `Input`.`Time`
FROM `Input`;
END;

DROP PROCEDURE IF EXISTS `computer_store`.`add_input`;

CREATE PROCEDURE `computer_store`.`add_input` (IN productID int, IN count INT)
BEGIN 
INSERT INTO `Input` (`ProductID`, `Count`, `Time`) VALUES (productID, count, CURRENT_TIMESTAMP());
END;

DROP PROCEDURE IF EXISTS `computer_store`.`get_output`;

CREATE PROCEDURE `computer_store`.`get_output` ()
BEGIN 
SELECT `Output`.`ID`, `Output`.`ProductID`, `Output`.`Count`, `Output`.`TotalPrice`, `Output`.`Time`, `Output`.`UserID`
FROM `Output`;
END;

DROP PROCEDURE IF EXISTS `computer_store`.`add_output`;

CREATE PROCEDURE `computer_store`.`add_output` (IN productID int, IN count INT, IN totalPrice DECIMAL, IN userID INT)
BEGIN 
INSERT INTO `Output` (`ProductID`, `Count`, `TotalPrice`, `Time`, `UserID`) VALUES (productID, count, totalPrice, CURRENT_TIMESTAMP(), userID);
END;

