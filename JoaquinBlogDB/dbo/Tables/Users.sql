﻿CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [Username] NVARCHAR(16) NOT NULL,
	[Firstname] NVARCHAR(50) NOT NULL,
	[Lastname] NVARCHAR(50) NOT NULL,
	[Password] NCHAR(16) NOT NULL,
)
