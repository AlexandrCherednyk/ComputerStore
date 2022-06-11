DROP DATABASE IF EXISTS Computer_Store;

CREATE DATABASE Computer_Store;

Use Computer_Store;

CREATE TABLE `Role` (
	ID INT NOT NULL AUTO_INCREMENT,
    Name VARCHAR(255) NOT NULL,
    PRIMARY KEY(ID)
);

CREATE TABLE `User` (
	ID INT NOT NULL AUTO_INCREMENT,
    Email VARCHAR(255) NOT NULL,
    PasswordHash VARCHAR(255) NOT NULL,
    RoleID INT NOT NULL,
    PRIMARY KEY(ID),
	CONSTRAINT fk_Users_Role FOREIGN KEY (RoleID) REFERENCES Role (ID)
);

CREATE TABLE `Manufacturer` (
	ID INT NOT NULL AUTO_INCREMENT,
    Name VARCHAR(255) NOT NULL,
    PRIMARY KEY(ID)
);

CREATE TABLE `Product` (
	ID INT NOT NULL AUTO_INCREMENT,
    Name VARCHAR(255) NOT NULL,
    Description VARCHAR(255) NULL,
    Type INT NOT NULL,
    ManufacturerID INT NOT NULL,
    Price DECIMAL NOT NULL,
    Count INT NOT NULL,
    PRIMARY KEY(ID),
    CONSTRAINT fk_Products_Manufacturer FOREIGN KEY (ManufacturerID) REFERENCES `Manufacturer` (ID)
);

CREATE TABLE `Input` (
	ID INT NOT NULL AUTO_INCREMENT,
    ProductID INT NOT NULL,
    Count INT NOT NULL,
    Time TIMESTAMP NOT NULL,
    PRIMARY KEY(ID),
    Constraint fk_Inputs_Product FOREIGN KEY (ProductID) REFERENCES `Product` (ID)
);

CREATE TABLE `Output` (
	ID INT NOT NULL AUTO_INCREMENT,
    ProductID INT NOT NULL,
    Count INT NOT NULL,
    Time TIMESTAMP NOT NULL,
    UserID INT NOT NULL, 
    PRIMARY KEY(ID),
    Constraint fk_Outputs_Product FOREIGN KEY (ProductID) REFERENCES `Product` (ID),
    Constraint fk_Outputs_User FOREIGN KEY (UserID) REFERENCES `User` (ID)
);

CREATE TABLE `Motherboard` (
	ID INT NOT NULL AUTO_INCREMENT,
    ProductID INT NOT NULL,
    Socket VARCHAR(255) NOT NULL,
    MemorySupport VARCHAR(255) NOT NULL,
    FormFactor VARCHAR(255) NOT NULL,
    PRIMARY KEY(ID),
    CONSTRAINT fk_Motherboards_Product FOREIGN KEY (ProductID) REFERENCES `Product` (ID)
);

CREATE TABLE `Processor` (
	ID INT NOT NULL AUTO_INCREMENT,
    ProductID INT NOT NULL,
    ProcessorFamily VARCHAR(255) NOT NULL,
    CoresNumber INT NOT NULL,
    ClockFrequency INT NOT NULL,
    PRIMARY KEY(ID),
    CONSTRAINT fk_Processors_Product FOREIGN KEY (ProductID) REFERENCES `Product` (ID)
);

CREATE TABLE `PowerSupply` (
	ID INT NOT NULL AUTO_INCREMENT,
    ProductID INT NOT NULL,
    Power INT NOT NULL,
    PRIMARY KEY(ID),
    CONSTRAINT fk_PowerSupplies_Product FOREIGN KEY (ProductID) REFERENCES `Product` (ID)
);

CREATE TABLE `VideoCard` (
	ID INT NOT NULL AUTO_INCREMENT,
    ProductID INT NOT NULL,
    GraphicsChip VARCHAR(255) NOT NULL,
    VideoCardMemory INT NOT NULL,
    VideoCardMemoryType VARCHAR(255) NOT NULL,
    PRIMARY KEY(ID),
    CONSTRAINT fk_VideoCards_Product FOREIGN KEY (ProductID) REFERENCES `Product` (ID)
);

CREATE TABLE `Ram` (
	ID INT NOT NULL AUTO_INCREMENT,
    ProductID INT NOT NULL,
    Memory INT NOT NULL,
    MemoryType VARCHAR(255) NOT NULL,
    MemoryFrequency INT NOT NULL,
    PRIMARY KEY(ID),
    CONSTRAINT fk_Rams_Product FOREIGN KEY (ProductID) REFERENCES `Product` (ID)
);