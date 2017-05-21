CREATE TABLE [dbo].[TblLessonStudents]
(
	[LessonFK]	INT NOT NULL,
	[StudentFK] INT NOT NULL, 
    [Presence]	BIT NULL, 
    [Material]	BIT NULL, 
    [Behavior]	INT NULL,
	CONSTRAINT [PK_LessonStudent] PRIMARY KEY CLUSTERED ([LessonFK] ASC, [StudentFK] ASC),
    CONSTRAINT [FK_TblLessonStudent_LessonID]	FOREIGN KEY ([LessonFK])	REFERENCES [dbo].[TblLessons]([ID])		ON DELETE CASCADE,
    CONSTRAINT [FK_TblLessonStudent_StudentID]	FOREIGN KEY ([StudentFK])	REFERENCES [dbo].[TblStudents]([ID])	ON DELETE CASCADE
)
