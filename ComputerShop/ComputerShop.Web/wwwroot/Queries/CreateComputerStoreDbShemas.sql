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

CREATE TABLE `Type` (
	ID INT NOT NULL AUTO_INCREMENT,
    Name VARCHAR(255) NOT NULL,
    PRIMARY KEY(ID)
);

CREATE TABLE `Product` (
	ID INT NOT NULL AUTO_INCREMENT,
    Name VARCHAR(255) NOT NULL,
    Description VARCHAR(255) NULL,
    TypeID INT NOT NULL,
    ManufacturerID INT NOT NULL,
    Price DECIMAL NOT NULL,
    Count INT NOT NULL,
    PRIMARY KEY(ID),
    CONSTRAINT fk_Products_Manufacturer FOREIGN KEY (ManufacturerID) REFERENCES `Manufacturer` (ID),
    CONSTRAINT fk_Products_Type FOREIGN KEY (TypeID) REFERENCES `Type` (ID)
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

CREATE TABLE `Characteristic` (
	ID INT NOT NULL AUTO_INCREMENT,
    ProductID INT NOT NULL,
    Name VARCHAR(255),
    Value VARCHAR(255),
    PRIMARY KEY(ID),
    Constraint fk_Characteristics_Product FOREIGN KEY (ProductID) REFERENCES `Product` (ID)
);
