CREATE TABLE [dbo].[TblSchools]
(
	[ID]				INT				NOT NULL IDENTITY(1,1), 
    [Name]				NVARCHAR(MAX)	NULL, 
	[Logo]				NVARCHAR(MAX)	NULL, 
    [ProfilePicture]	NVARCHAR(MAX)	NULL, 
    [Acronym]			NVARCHAR(MAX)	NULL,
	CONSTRAINT [PK_SchoolID] PRIMARY KEY CLUSTERED ([ID] ASC)
)
