CREATE TABLE [dbo].[Games] (
    [ID]          INT           NOT NULL,
    [Name]        VARCHAR (50)  NOT NULL,
    [Genre]       VARCHAR (50)  NOT NULL,
    [ReleaseDate] VARCHAR(10)          NOT NULL,
    [Developer]   VARCHAR (50)  NOT NULL,
    [Rating]      VARCHAR (10)  NULL,
    [Description] VARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

