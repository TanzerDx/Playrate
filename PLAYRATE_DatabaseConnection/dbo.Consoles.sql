CREATE TABLE [dbo].[Consoles] (
    [ID] INT NOT NULL,
    [Model] VARCHAR (50) NOT NULL,
    [Manufacturer] VARCHAR (50) NOT NULL,
    [Release_Date] VARCHAR (50) NOT NULL,
    [URL_Console] VARCHAR (5000) NULL,
    [Controller_Type] VARCHAR (100) NULL,
    [Chat_Platform] VARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

