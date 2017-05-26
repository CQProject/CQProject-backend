CREATE TABLE [dbo].[TblSchoolLayout]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(MAX) NULL, 
    [Logo] NVARCHAR(MAX) NULL, 
    [BackgroundPicture] NVARCHAR(MAX) NULL, 
    [Acronym] NVARCHAR(50) NULL, 
    [OpeningTime] TIME(0) NULL, 
    [ClosingTime] TIME(0) NULL
)
