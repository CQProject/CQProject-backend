CREATE TABLE [dbo].[TblLessons]
(
	[ID]			INT				NOT NULL IDENTITY(1,1), 
    [Summary]		NVARCHAR(MAX)	NULL, 
    [Homework]		NVARCHAR(MAX)	NULL, 
    [Observations]	NVARCHAR(MAX)	NULL, 
    [ScheduleFK]	INT				NULL,
	[Day]		SMALLDATETIME	NULL, 
    CONSTRAINT [PK_LessonID] PRIMARY KEY CLUSTERED ([ID] ASC),
)
