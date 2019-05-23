data.bak este un backup de la baza de date
Am creat urmatoarele 3 tabele:
CREATE TABLE [dbo].[Borrows] (
    [Id]       INT IDENTITY (1, 1) NOT NULL,
    [ClientID] INT NOT NULL,
    [BookID]   INT NOT NULL,
    [NoOfBorr] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Books] (
    [Id]      INT IDENTITY (1, 1) NOT NULL,
    [Titlu]   NVARCHAR (50) NOT NULL,
    [Autor]   NVARCHAR (50) NOT NULL,
    [Editura] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Clients] (
    [Id]      INT IDENTITY (1, 1) NOT NULL,
    [Nume]    NVARCHAR (50) NOT NULL,
    [Prenume] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

in baza de date numita "data"
