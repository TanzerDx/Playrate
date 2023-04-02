CREATE TABLE [dbo].[Reviews] (
    [ID] INT NOT NULL,
    [Username] VARCHAR (50) NOT NULL,
    [URL_ProfilePicture] VARCHAR (MAX) NULL,
	[Rating] VARCHAR (20) NOT NULL,
    [Review] VARCHAR (5000) NULL,
	[Game] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);