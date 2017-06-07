
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/08/2017 00:40:04
-- Generated from EDMX file: D:\ICT\C# Projecten\WebWinkel\WinkelServiceLibrary\WinkelModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [StoreDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AankoopAankoopRegel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AankoopRegelSet] DROP CONSTRAINT [FK_AankoopAankoopRegel];
GO
IF OBJECT_ID(N'[dbo].[FK_AankoopRegelProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AankoopRegelSet] DROP CONSTRAINT [FK_AankoopRegelProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_GebruikerAankoop]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AankoopSet] DROP CONSTRAINT [FK_GebruikerAankoop];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AankoopRegelSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AankoopRegelSet];
GO
IF OBJECT_ID(N'[dbo].[AankoopSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AankoopSet];
GO
IF OBJECT_ID(N'[dbo].[GebruikerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GebruikerSet];
GO
IF OBJECT_ID(N'[dbo].[ProductSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AankoopRegelSet'
CREATE TABLE [dbo].[AankoopRegelSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [aantal] int  NOT NULL,
    [AankoopId] int  NOT NULL,
    [Product_Id] int  NOT NULL
);
GO

-- Creating table 'AankoopSet'
CREATE TABLE [dbo].[AankoopSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [aankoopdatum] datetime  NOT NULL,
    [Gebruiker_Id] int  NOT NULL
);
GO

-- Creating table 'GebruikerSet'
CREATE TABLE [dbo].[GebruikerSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [gebruikersnaam] nvarchar(max)  NOT NULL,
    [wachtwoord] nvarchar(max)  NOT NULL,
    [saldo] float  NOT NULL
);
GO

-- Creating table 'ProductSet'
CREATE TABLE [dbo].[ProductSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [naam] nvarchar(max)  NOT NULL,
    [prijs] float  NOT NULL,
    [aantal] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AankoopRegelSet'
ALTER TABLE [dbo].[AankoopRegelSet]
ADD CONSTRAINT [PK_AankoopRegelSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AankoopSet'
ALTER TABLE [dbo].[AankoopSet]
ADD CONSTRAINT [PK_AankoopSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GebruikerSet'
ALTER TABLE [dbo].[GebruikerSet]
ADD CONSTRAINT [PK_GebruikerSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductSet'
ALTER TABLE [dbo].[ProductSet]
ADD CONSTRAINT [PK_ProductSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AankoopId] in table 'AankoopRegelSet'
ALTER TABLE [dbo].[AankoopRegelSet]
ADD CONSTRAINT [FK_AankoopAankoopRegel]
    FOREIGN KEY ([AankoopId])
    REFERENCES [dbo].[AankoopSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AankoopAankoopRegel'
CREATE INDEX [IX_FK_AankoopAankoopRegel]
ON [dbo].[AankoopRegelSet]
    ([AankoopId]);
GO

-- Creating foreign key on [Product_Id] in table 'AankoopRegelSet'
ALTER TABLE [dbo].[AankoopRegelSet]
ADD CONSTRAINT [FK_AankoopRegelProduct]
    FOREIGN KEY ([Product_Id])
    REFERENCES [dbo].[ProductSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AankoopRegelProduct'
CREATE INDEX [IX_FK_AankoopRegelProduct]
ON [dbo].[AankoopRegelSet]
    ([Product_Id]);
GO

-- Creating foreign key on [Gebruiker_Id] in table 'AankoopSet'
ALTER TABLE [dbo].[AankoopSet]
ADD CONSTRAINT [FK_GebruikerAankoop]
    FOREIGN KEY ([Gebruiker_Id])
    REFERENCES [dbo].[GebruikerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GebruikerAankoop'
CREATE INDEX [IX_FK_GebruikerAankoop]
ON [dbo].[AankoopSet]
    ([Gebruiker_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------