USE `computer_store`;

LOCK TABLES `Role` WRITE;
INSERT INTO `computer_store`.`Role` (`Name`) VALUES ('admin'), ('user');
UNLOCK TABLES;

LOCK TABLES `User` WRITE;
INSERT INTO `computer_store`.`User` (`Email`, `Address`, `FullName`, `PasswordHash`, `RoleID`) VALUES ('admin@mail.com', 'admin', 'admin', 'AQAQJwAAckwzbZKZ6EwcM/h9QNDhaltr+REOcYk2xEh5smtYzMLoyl9usLKuEzuYfPBuAksV', 1), ('user@mail.com', 'user', 'user', 'AQAQJwAADMYe/oKUNlJibe8IepbjXxoVxWY7sLoI0hITOpSapC3IqHWqEwY1E/NUCdMb9PEI', 2);
UNLOCK TABLES;

LOCK TABLES `Type` WRITE;
INSERT INTO `computer_store`.`Type` (`Name`) VALUES ('Motherboard'), ('Processor'), ('PowerSuply'), ('VideoCard'), ('RAM');
UNLOCK TABLES;

LOCK TABLES `Manufacturer` WRITE;
INSERT INTO `computer_store`.`Manufacturer` (`Name`) VALUES ('Apple');
UNLOCK TABLES;

