CREATE TABLE [dbo].[TblSchoolLayout]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(MAX) NULL, 
    [Logo] NVARCHAR(MAX) NULL, 
    [ProfilePicture] NVARCHAR(MAX) NULL, 
    [Acronym] NVARCHAR(50) NULL, 
    [OpeningTime] DATETIME NULL, 
    [ClosingTime] DATETIME NULL
)
