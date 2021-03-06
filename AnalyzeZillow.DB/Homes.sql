﻿CREATE TABLE [dbo].[Homes]
(
	[zId] INT NOT NULL PRIMARY KEY, 
    [Street] NVARCHAR(MAX) NOT NULL, 
    [City] NVARCHAR(50) NOT NULL, 
    [State] NCHAR(10) NOT NULL, 
    [ZipCode] INT NOT NULL, 
    [Latitude] DECIMAL NULL, 
    [Longitude] DECIMAL NULL, 
    [FIPSCounty] INT NOT NULL, 
    [HomeType] NVARCHAR(50) NULL, 
    [TaxAssesmentYear] INT NOT NULL, 
    [TaxAssessment] DECIMAL NOT NULL, 
    [YearBuild] INT NOT NULL, 
    [LotSize] INT NULL, 
    [HomeSize] INT NOT NULL, 
    [NumBathrooms] DECIMAL NULL, 
    [NumBedrooms] INT NULL, 
    [TotalRooms] FLOAT NULL, 
    [ZillowEstimate] FLOAT NULL, 
    [ZillowLowEstimate] FLOAT NULL, 
    [ZillowHighEstimate] FLOAT NULL, 
    [LastSoldPrice] FLOAT NULL, 
    [LastSoldDate] DATETIME NULL
)
