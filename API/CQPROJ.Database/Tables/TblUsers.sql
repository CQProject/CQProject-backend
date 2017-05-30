CREATE TABLE [dbo].[TblUsers]
(
	[ID]			INT				NOT NULL IDENTITY(1,1), 
	[Name]			nvarchar(MAX)	NOT NULL,
    [Email]			NVARCHAR(MAX)	NOT NULL, 
	[Password]		NVARCHAR(MAX)	NOT NULL, 
    [CreatedDate]	DATETIME		NOT NULL, 
    [IsActive]		BIT				NOT NULL,
	[Function]		NVARCHAR(MAX)	NULL,
    CONSTRAINT [PK_UserID] PRIMARY KEY CLUSTERED ([ID] ASC)
)
