CREATE TABLE [dbo].[TblPictures]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [IsVisible] BIT NULL, 
    [Name] VARCHAR(MAX) NULL, 
    [Type] TINYINT NULL
)
