CREATE TABLE [dbo].[Consoles] (
    [ID]             INT          NOT NULL,
    [Type]           VARCHAR (50) NOT NULL,
    [Model]          VARCHAR (50) NOT NULL,
    [Manufacturer]   VARCHAR (50) NOT NULL,
    [ReleaseDate]    VARCHAR(10)         NOT NULL,
    [ControllerType] VARCHAR (50) NULL,
    [ChatPlatform]   VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

