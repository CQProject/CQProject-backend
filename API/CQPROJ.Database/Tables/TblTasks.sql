CREATE TABLE [dbo].[TblTasks]
(
	[ID]			INT				NOT NULL IDENTITY(1,1), 
    [Day]			DATETIME		NULL, 
    [Weekly]		BIT				NULL, 
	[Description]	NVARCHAR(MAX)	NULL,
    [UserFK]		INT				NULL, 
	CONSTRAINT [PK_TaskID] PRIMARY KEY CLUSTERED ([ID] ASC)
)