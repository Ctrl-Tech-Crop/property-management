
CREATE DATABASE FSPropertyManagement
GO
USE FSPropertyManagement  
CREATE TABLE Property
(
  Id               uniqueidentifier NOT NULL DEFAULT NEWID(),
  PropertyTypeId   uniqueidentifier NOT NULL,
  AddressLine1     VARCHAR(100)     NOT NULL,
  AddressLine2     VARCHAR(50)      NULL    ,
  City             VARCHAR(30)      NOT NULL,
  Province         VARCHAR(10)      NOT NULL,
  PostalCode       CHAR(6)          NOT NULL,
  Name             VARCHAR(30)      NULL    ,
  TotalUnits       INT              NOT NULL,
  TotalVacantUnits INT              NULL    ,
  Parking          BIT              NOT NULL,
  Pets             BIT              NOT NULL,
  Smoking          BIT              NOT NULL,
  PRIMARY KEY (Id)
);

CREATE TABLE PropertyType
(
  Id   uniqueidentifier NOT NULL DEFAULT NEWID(),
  Name VARCHAR(20)      NULL    ,
  PRIMARY KEY (Id)
);

CREATE TABLE Tenant
(
  Id                    uniqueidentifier NOT NULL DEFAULT NEWID(),
  UnitId                uniqueidentifier NOT NULL,
  FirstName             VARCHAR(10)      NOT NULL,
  LastName              VARCHAR(10)      NOT NULL,
  PreferredName         VARCHAR(20)      NULL    ,
  Email                 VARCHAR(30)      NOT NULL,
  Phone                 INT              NOT NULL,
  TenancyStartDate      DATETIME         NOT NULL,
  Status                VARCHAR(6)       NOT NULL,
  Standing              VARCHAR(7)       NOT NULL,
  EmergencyContactName  VARCHAR(20)      NOT NULL,
  EmergencyContactPhone INT              NOT NULL,
  EmergencyContactEmail VARCHAR(30)      NOT NULL,
  ParkingStall          BIT              NOT NULL,
  MailingAddressLine1   VARCHAR(100)     NOT NULL,
  MailingAddressLine2   VARCHAR(50)      NULL    ,
  City                  VARCHAR(30)      NOT NULL,
  Province              VARCHAR(10)      NOT NULL,
  Country               VARCHAR(10)      NOT NULL,
  PostalCode            CHAR(6)          NOT NULL,
  PRIMARY KEY (Id)
);

CREATE TABLE Unit
(
  Id            uniqueidentifier NOT NULL DEFAULT NEWID(),
  PropertyId    uniqueidentifier NOT NULL,
  Number        VARCHAR(10)      NOT NULL,
  Name          VARCHAR(30)      NULL    ,
  Type          VARCHAR(25)      NOT NULL,
  UnitTypeId    uniqueidentifier NOT NULL,
  Area          DECIMAL          NOT NULL,
  NumberofRooms INT              NOT NULL,
  RentAmount    DECIMAL          NOT NULL,
  DepositAmount DECIMAL          NOT NULL,
  Furnished     BIT              NOT NULL,
  Laundry       VARCHAR(8)       NULL    ,
  PRIMARY KEY (Id)
);

ALTER TABLE Property
  ADD CONSTRAINT FK_PropertyType_TO_Property
    FOREIGN KEY (PropertyTypeId)
    REFERENCES PropertyType (Id);

ALTER TABLE Unit
  ADD CONSTRAINT FK_Property_TO_Unit
    FOREIGN KEY (PropertyId)
    REFERENCES Property (Id);

ALTER TABLE Unit
  ADD CONSTRAINT FK_PropertyType_TO_Unit
    FOREIGN KEY (UnitTypeId)
    REFERENCES PropertyType (Id);

ALTER TABLE Tenant
  ADD CONSTRAINT FK_Unit_TO_Tenant
    FOREIGN KEY (UnitId)
    REFERENCES Unit (Id);