CREATE TABLE [dbo].[TblPictures]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [IsVisible] BIT NULL, 
    [Name] NVARCHAR(MAX) NULL, 
    [Type] TINYINT NULL
)
