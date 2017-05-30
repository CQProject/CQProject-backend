CREATE TABLE [dbo].[TblSchedules]
(
	[ID]			INT				NOT NULL IDENTITY(1,1), 
    [Subject]		NVARCHAR(MAX)	NULL, 
    [StartingTime]	DATE			NULL, 
    [EndingTime]	DATE			NULL, 
	[DayOfTheWeek]	NVARCHAR(MAX)	NULL, 
    [TeacherFK]		INT				NULL, 
    [ClassFK]		INT				NULL,
    CONSTRAINT [PK_ScheduleID] PRIMARY KEY CLUSTERED ([ID] ASC),
)
