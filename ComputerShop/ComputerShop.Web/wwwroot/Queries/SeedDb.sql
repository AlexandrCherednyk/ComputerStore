USE `computer_store`;

LOCK TABLES `Role` WRITE;
INSERT INTO `computer_store`.`Role` (`Name`) VALUES ('admin'), ('user');
UNLOCK TABLES;

LOCK TABLES `User` WRITE;
INSERT INTO `computer_store`.`User` (`Email`, `PasswordHash`, `RoleID`) VALUES ('admin@mail.com', 'AQAQJwAAckwzbZKZ6EwcM/h9QNDhaltr+REOcYk2xEh5smtYzMLoyl9usLKuEzuYfPBuAksV', 1);
UNLOCK TABLES;

LOCK TABLES `Manufacturer` WRITE;
INSERT INTO `computer_store`.`Manufacturer` (`Name`) VALUES ('Ukraine');
UNLOCK TABLES;

LOCK TABLES `Product` WRITE;
INSERT INTO `computer_store`.`Product` (`Name`, `Description`, `Type`, `ManufacturerID`, `Price`, `Count`) VALUES ('IPhone', 'Something', 1, 1, 200, 20);
UNLOCK TABLES;
