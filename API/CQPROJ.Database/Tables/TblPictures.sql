CREATE TABLE [dbo].[TblPictures]
(
	[ID]		INT				NOT NULL PRIMARY KEY, 
    [IsVisible] BIT				NULL, 
    [Name]		NVARCHAR(MAX)	NULL, 
    [Type]		TINYINT			NULL,
	[ClassFK]	INT				NOT NULL,
	CONSTRAINT [PK_PictureID] PRIMARY KEY CLUSTERED ([ID] ASC)
)
