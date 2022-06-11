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

DROP PROCEDURE IF EXISTS `computer_store`.`add_product`;

CREATE PROCEDURE `computer_store`.`add_product` (IN name VARCHAR(255), IN description VARCHAR(255), IN type INT, IN manufacturerID INT, IN price DECIMAL, IN count INT)
BEGIN 
INSERT INTO `Product` (`Name`, `Description`, `Type`, `ManufacturerID`, `Price`, `Count`) values (name, description, type, manufacturerID, price, count);
END;

DROP PROCEDURE IF EXISTS `computer_store`.`get_product`;

CREATE PROCEDURE `computer_store`.`get_product` (IN ID INT)
BEGIN 
SELECT `Product`.`ID`, `Product`.`Name`, `Product`.`Description`, `Product`.`Type`, `Product`.`ManufacturerID`, `Product`.`Count`
FROM `Product`
WHERE `Product`.`ID` = ID;
END;

DROP PROCEDURE IF EXISTS `computer_store`.`get_product_range`;

CREATE PROCEDURE `computer_store`.`get_product_range` (IN `from` INT, IN `to` INT)
BEGIN 
SELECT `Product`.`ID`, `Product`.`Name`, `Product`.`Description`, `Product`.`Type`, `Product`.`ManufacturerID`, `Product`.`Price` , `Product`.`Count`
FROM `Product`
ORDER BY `Product`.`ID`
LIMIT `from`, `to`;
END;

DROP PROCEDURE IF EXISTS `computer_store`.`product_count`;

CREATE PROCEDURE `computer_store`.`product_count` ()
BEGIN 
SELECT COUNT(`Product`.`ID`)
FROM `Product`;
END;

DROP PROCEDURE IF EXISTS `computer_store`.`add_motherboard`;

CREATE PROCEDURE `computer_store`.`add_motherboard` (IN productID INT, IN socket VARCHAR(255), IN memorySupport VARCHAR(255), IN formFactor VARCHAR(255))
BEGIN 
INSERT INTO `Motherboard` (`ProductID`, `Socket`, `MemorySupport`, `FormFactor`) values (productID, socket, memorySupport, formFactor);
END;

DROP PROCEDURE IF EXISTS `computer_store`.`get_motherboard`;

CREATE PROCEDURE `computer_store`.`get_motherboard` (IN productID VARCHAR(255))
BEGIN 
SELECT `Motherboard`.`ID`, `Motherboard`.`Socket`, `Motherboard`.`MemorySupport`, `Motherboard`.`FormFactor`
FROM `Motherboard`
WHERE `Motherboard`.`ProductID` = productID;
END;

DROP PROCEDURE IF EXISTS `computer_store`.`add_processor`;

CREATE PROCEDURE `computer_store`.`add_processor` (IN productID INT, IN processorFamily VARCHAR(255), IN coresNumber INT, IN clockFrequency INT)
BEGIN 
INSERT INTO `Processor` (`ProductID`, `ProcessorFamily`, `CoresNumber`, `ClockFrequency`) values (productID, processorFamily, coresNumber, clockFrequency);
END;

DROP PROCEDURE IF EXISTS `computer_store`.`get_processor`;

CREATE PROCEDURE `computer_store`.`get_processor` (IN productID VARCHAR(255))
BEGIN 
SELECT `Processor`.`ID`, `Processor`.`ProcessorFamily`, `Processor`.`CoresNumber`, `Processor`.`ClockFrequency`
FROM `Processor`
WHERE `Processor`.`ProductID` = productID;
END;

DROP PROCEDURE IF EXISTS `computer_store`.`add_power_supply`;

CREATE PROCEDURE `computer_store`.`add_power_supply` (IN productID INT, IN power INT)
BEGIN 
INSERT INTO `PowerSupply` (`ProductID`, `Power`) values (productID, power);
END;

DROP PROCEDURE IF EXISTS `computer_store`.`get_power_supply`;

CREATE PROCEDURE `computer_store`.`get_power_supply` (IN productID VARCHAR(255))
BEGIN 
SELECT `PowerSupply`.`ID`, `PowerSupply`.`Power`
FROM `PowerSupply`
WHERE `PowerSupply`.`ProductID` = productID;
END;

DROP PROCEDURE IF EXISTS `computer_store`.`add_video_card`;

CREATE PROCEDURE `computer_store`.`add_video_card` (IN productID INT, IN graphicsChip VARCHAR(255), IN videoCardMemory INT, IN videoCardMemoryType VARCHAR(255))
BEGIN 
INSERT INTO `VideoCard` (`ProductID`, `GraphicsChip`, `VideoCardMemory`, `VideoCardMemoryType`) values (productID, graphicsChip, videoCardMemory, videoCardMemoryType);
END;

DROP PROCEDURE IF EXISTS `computer_store`.`get_video_card`;

CREATE PROCEDURE `computer_store`.`get_video_card` (IN productID VARCHAR(255))
BEGIN 
SELECT `VideoCard`.`ID`, `VideoCard`.`GraphicsChip`, `VideoCard`.`VideoCardMemory`, `VideoCard`.`VideoCardMemoryType`
FROM `VideoCard`
WHERE `VideoCard`.`ProductID` = productID;
END;

DROP PROCEDURE IF EXISTS `computer_store`.`add_ram`;

CREATE PROCEDURE `computer_store`.`add_ram` (IN productID INT, IN memory INT, IN memoryType VARCHAR(255), IN memoryFrequency INT)
BEGIN 
INSERT INTO `Ram` (`ProductID`, `Memory`, `MemoryType`, `MemoryFrequency`) values (productID, memory, memoryType, memoryFrequency);
END;

DROP PROCEDURE IF EXISTS `computer_store`.`get_ram`;

CREATE PROCEDURE `computer_store`.`get_ram` (IN productID VARCHAR(255))
BEGIN 
SELECT `Ram`.`ID`, `Ram`.`Memory`, `Ram`.`MemoryType`, `Ram`.`MemoryFrequency`
FROM `Ram`
WHERE `Ram`.`ProductID` = productID;
END;

