CREATE TABLE [dbo].[TblSchedules]
(
	[ID]			INT				NOT NULL IDENTITY(1,1), 
    [Subject]		NVARCHAR(MAX)	NULL, 
    [StartingTime]	DATETIME		NULL, 
    [EndingTime]	DATETIME		NULL, 
    [TeacherFK]		INT				NULL, 
    [ClassFK]		INT				NULL,
	CONSTRAINT [PK_ScheduleID] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_TblSchedule_TeacherID]	FOREIGN KEY([TeacherFK])	REFERENCES [dbo].[TblTeachers]([ID])	ON DELETE NO ACTION,
	CONSTRAINT [FK_TblSchedule_ClassID]		FOREIGN KEY([ClassFK])		REFERENCES [dbo].[TblClasses]([ID])		ON DELETE NO ACTION
)
