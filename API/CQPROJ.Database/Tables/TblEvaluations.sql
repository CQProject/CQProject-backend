CREATE TABLE [dbo].[TblEvaluations]
(
	[ID]			 INT			NOT NULL IDENTITY(1,1), 
    [Purport]		 NVARCHAR(MAX)	NULL,
    [EvaluationDate] DATETIME		NULL, 
    [ScheduleFK]	 INT			NULL,
	CONSTRAINT [PK_EvaluationID] PRIMARY KEY CLUSTERED ([ID] ASC),
)
