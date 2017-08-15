CREATE TABLE [dbo].[TblTasks]
(
	[ID]			INT				NOT NULL IDENTITY(1,1), 
    [DayOfWeek]		INT				NULL, 
	[Description]	NVARCHAR(MAX)	NULL,
    [UserFK]		INT				NULL, 
	CONSTRAINT [PK_TaskID] PRIMARY KEY CLUSTERED ([ID] ASC)
)