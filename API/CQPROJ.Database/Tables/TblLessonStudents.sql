CREATE TABLE [dbo].[TblLessonStudents]
(
	[LessonFK]	INT NOT NULL,
	[StudentFK] INT NOT NULL, 
    [Presence]	BIT NULL, 
    [Material]	BIT NULL, 
    [Behavior]	INT NULL,
	CONSTRAINT [PK_LessonStudent] PRIMARY KEY CLUSTERED ([LessonFK] ASC, [StudentFK] ASC)
)