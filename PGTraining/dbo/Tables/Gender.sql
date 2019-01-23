CREATE TABLE [dbo].[Gender] (
    [ID]   INT           IDENTITY (1, 1) NOT NULL,
    [Code] NCHAR (1)     NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED ([Code] ASC)
);

