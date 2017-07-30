CREATE TABLE [dbo].[TblActions]
(
	[ID]			INT				NOT NULL IDENTITY(1,1),
    [Hour]			DATETIME		NULL, 
    [Description]	NVARCHAR(MAX)	NULL, 
    [UserFK]		INT				NULL,
	CONSTRAINT [PK_ActionID] PRIMARY KEY CLUSTERED ([ID] ASC)
)
