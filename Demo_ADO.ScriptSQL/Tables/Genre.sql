﻿CREATE TABLE [dbo].[Genre]
(
	[GenreId] INT IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	
	CONSTRAINT PK_Genre PRIMARY KEY([GenreId]),
	CONSTRAINT UK_Genre__Name UNIQUE([Name])
)
