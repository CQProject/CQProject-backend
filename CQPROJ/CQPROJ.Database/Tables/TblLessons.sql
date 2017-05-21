CREATE TABLE [dbo].[TblLessons]
(
	[ID]			INT				NOT NULL IDENTITY(1,1), 
    [Summary]		NVARCHAR(MAX)	NULL, 
    [Homework]		NVARCHAR(MAX)	NULL, 
    [Observations]	NVARCHAR(MAX)	NULL, 
    [ScheduleFK]	INT				NULL,
	CONSTRAINT [PK_LessonID] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_TblLesson_ScheduleID] FOREIGN KEY([ScheduleFK]) REFERENCES [dbo].[TblSchedules]([ID]) ON DELETE CASCADE
)
