CREATE TABLE [dbo].[TblClassStudents]
(
	[ClassFK]	INT NOT NULL,
	[StudentFK] INT NOT NULL,
	CONSTRAINT [PK_ClassStudent] PRIMARY KEY CLUSTERED ([ClassFK] ASC, [StudentFK] ASC),
)
