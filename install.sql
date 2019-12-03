--CREATE DATABASE [umbracoCms]
--CREATE DATABASE [PetJournal]

USE [PetJournal]

DROP TABLE [dbo].[PetClassification]
DROP TABLE [dbo].[PetBreed]
DROP TABLE [dbo].[PetType]

CREATE TABLE [dbo].[PetType](
	 [Id] INT NOT NULL IDENTITY(1,1)
		CONSTRAINT PK_PetType PRIMARY KEY
	,[ShortName] VARCHAR(200) NOT NULL
	,[DisplayName] VARCHAR(2000) NULL
	,[Created] DATETIMEOFFSET NOT NULL
	,[Modified] DATETIMEOFFSET NOT NULL
	,CONSTRAINT IQ_PetType UNIQUE ([ShortName])
	,INDEX Idx_PetType_ShortName NONCLUSTERED ([ShortName])
)

CREATE TABLE [dbo].[PetBreed] (
	 [Id] INT NOT NULL IDENTITY(1,1)
		CONSTRAINT PK_PetBreed PRIMARY KEY
	,[PetTypeId] INT NOT NULL
		CONSTRAINT FK_PetBreed_PetType
		REFERENCES [dbo].[PetType]([Id])
	,[ShortName] VARCHAR(200) NOT NULL
	,[DisplayName] VARCHAR(2000) NULL
	,[Created] DATETIMEOFFSET NOT NULL
	,[Modified] DATETIMEOFFSET NOT NULL
	,CONSTRAINT IQ_PetBreed UNIQUE ([ShortName])
	,INDEX Idx_PetBreed_ShortName NONCLUSTERED ([ShortName])
)

CREATE TABLE [dbo].[PetClassification] (
	[Id] INT NOT NULL IDENTITY(1,1)
		CONSTRAINT PK_PetClassification PRIMARY KEY
	,[PetTypeId] INT NOT NULL
		CONSTRAINT FK_PetClassification_PetType
		REFERENCES [dbo].[PetClassification]([Id])
	,[ShortName] VARCHAR(200) NOT NULL
	,[DisplayName] VARCHAR(2000) NULL
	,[Created] DATETIMEOFFSET NOT NULL
	,[Modified] DATETIMEOFFSET NOT NULL
	,CONSTRAINT IQ_PetClassification UNIQUE ([ShortName])
	,INDEX Idx_PetClassification_ShortName NONCLUSTERED ([ShortName])

)