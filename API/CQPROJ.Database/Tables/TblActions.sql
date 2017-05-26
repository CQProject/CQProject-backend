CREATE TABLE [dbo].[TblActions]
(
	[ID]			INT				NOT NULL IDENTITY(1,1),
    [Hour]			DATETIME		NOT NULL, 
    [Description]	NVARCHAR(MAX)	NOT NULL, 
    [UserFK]		INT				NULL,
	CONSTRAINT [PK_ActionID] PRIMARY KEY CLUSTERED ([ID] ASC),
)
