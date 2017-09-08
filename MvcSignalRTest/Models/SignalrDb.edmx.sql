
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/04/2016 15:31:41
-- Generated from EDMX file: E:\github\MvcSignalRTest\MvcSignalRTest\Models\SignalrDb.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [qds214529528_db];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_dbo_ChatContents_dbo_ChatGroups_ChatGroup_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChatContents] DROP CONSTRAINT [FK_dbo_ChatContents_dbo_ChatGroups_ChatGroup_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_ChatContents_dbo_ChatUsers_ChatUser_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChatContents] DROP CONSTRAINT [FK_dbo_ChatContents_dbo_ChatUsers_ChatUser_Id];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Canvas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Canvas];
GO
IF OBJECT_ID(N'[dbo].[ChatContents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChatContents];
GO
IF OBJECT_ID(N'[dbo].[ChatGroups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChatGroups];
GO
IF OBJECT_ID(N'[dbo].[ChatUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChatUsers];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Canvas'
CREATE TABLE [dbo].[Canvas] (
    [Id] int  NOT NULL,
    [Name] nvarchar(max)  NULL,
    [Content] nvarchar(max)  NULL
);
GO

-- Creating table 'ChatContents'
CREATE TABLE [dbo].[ChatContents] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Content] nvarchar(400)  NOT NULL,
    [CreateDate] datetime  NOT NULL,
    [UserName] nvarchar(max)  NULL,
    [ChatUser_Id] int  NOT NULL,
    [ChatGroup_Id] int  NULL
);
GO

-- Creating table 'ChatGroups'
CREATE TABLE [dbo].[ChatGroups] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Remark] nvarchar(max)  NULL
);
GO

-- Creating table 'ChatUsers'
CREATE TABLE [dbo].[ChatUsers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(20)  NOT NULL,
    [IPAddress] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [UserID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [PWD] nvarchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Canvas'
ALTER TABLE [dbo].[Canvas]
ADD CONSTRAINT [PK_Canvas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ChatContents'
ALTER TABLE [dbo].[ChatContents]
ADD CONSTRAINT [PK_ChatContents]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ChatGroups'
ALTER TABLE [dbo].[ChatGroups]
ADD CONSTRAINT [PK_ChatGroups]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ChatUsers'
ALTER TABLE [dbo].[ChatUsers]
ADD CONSTRAINT [PK_ChatUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UserID] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ChatGroup_Id] in table 'ChatContents'
ALTER TABLE [dbo].[ChatContents]
ADD CONSTRAINT [FK_dbo_ChatContents_dbo_ChatGroups_ChatGroup_Id]
    FOREIGN KEY ([ChatGroup_Id])
    REFERENCES [dbo].[ChatGroups]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_ChatContents_dbo_ChatGroups_ChatGroup_Id'
CREATE INDEX [IX_FK_dbo_ChatContents_dbo_ChatGroups_ChatGroup_Id]
ON [dbo].[ChatContents]
    ([ChatGroup_Id]);
GO

-- Creating foreign key on [ChatUser_Id] in table 'ChatContents'
ALTER TABLE [dbo].[ChatContents]
ADD CONSTRAINT [FK_dbo_ChatContents_dbo_ChatUsers_ChatUser_Id]
    FOREIGN KEY ([ChatUser_Id])
    REFERENCES [dbo].[ChatUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_ChatContents_dbo_ChatUsers_ChatUser_Id'
CREATE INDEX [IX_FK_dbo_ChatContents_dbo_ChatUsers_ChatUser_Id]
ON [dbo].[ChatContents]
    ([ChatUser_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------