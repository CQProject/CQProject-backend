CREATE TABLE [dbo].[TblEvaluations]
(
	[ID]			 INT			NOT NULL IDENTITY(1,1), 
    [Purport]		 NVARCHAR(MAX)	NULL,
    [EvaluationDate] DATETIME		NULL, 
    [ScheduleFK]	 INT			NULL,
	CONSTRAINT [PK_EvaluationID] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_TblEvaluation_ScheduleID]	FOREIGN KEY([ScheduleFK]) REFERENCES [dbo].[TblSchedules]([ID]) ON DELETE NO ACTION
)
