CREATE TABLE [dbo].[TblClassStudents]
(
	[ClassFK]	INT NOT NULL,
	[StudentFK] INT NOT NULL,
	CONSTRAINT [PK_ClassStudent] PRIMARY KEY CLUSTERED ([ClassFK] ASC, [StudentFK] ASC),
    CONSTRAINT [FK_TblClassStudent_ClassID]			FOREIGN KEY ([ClassFK])		REFERENCES [dbo].[TblClasses]([ID])		ON DELETE NO ACTION,
    CONSTRAINT [FK_TblClassStudent_StudentID]		FOREIGN KEY ([StudentFK])	REFERENCES [dbo].[TblStudents]([ID])	ON DELETE NO ACTION
)
