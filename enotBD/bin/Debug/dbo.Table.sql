﻿CREATE TABLE [dbo].[MOTHERBOARD]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name ] NCHAR(10) NOT NULL, 
    [Socet] NCHAR(10) NOT NULL, 
    [Chipset] NCHAR(10) NOT NULL, 
    [Formfactor] NCHAR(10) NOT NULL
)