CREATE TABLE [dbo].[TblSchedules]
(
	[ID]			INT				NOT NULL IDENTITY(1,1), 
    [StartingTime]	INT				NULL, 
    [Duration]		INT				NULL, 
	[DayOfWeek]		INT				NULL, 
	[SubjectFK]		INT				NULL, 
    [TeacherFK]		INT				NULL, 
    [ClassFK]		INT				NULL,
	[RoomFK]		INT				NULL,
    CONSTRAINT [PK_ScheduleID] PRIMARY KEY CLUSTERED ([ID] ASC)
)
