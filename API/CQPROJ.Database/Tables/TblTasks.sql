CREATE TABLE [dbo].[TblTasks]
(
	[ID]			 INT			NOT NULL IDENTITY(1,1), 
    [DayOfWeek]		 NVARCHAR(MAX)	NULL, 
    [Hour]			 DATETIME		NULL, 
    [Weekly]		 BIT			NULL, 
	[Description]	 NVARCHAR(MAX)	NULL,
    [SecretaryFK]	 INT			NULL, 
    [SchAssistantFK] INT			NULL,
	CONSTRAINT [PK_TaskID] PRIMARY KEY CLUSTERED ([ID] ASC),
)