CREATE TABLE [dbo].[TblClassTeachers]
(
	[ClassFK]	INT NOT NULL,
	[TeacherFK] INT NOT NULL,
	CONSTRAINT [PK_ClassTeacher] PRIMARY KEY CLUSTERED ([ClassFK] ASC, [TeacherFK] ASC)
)