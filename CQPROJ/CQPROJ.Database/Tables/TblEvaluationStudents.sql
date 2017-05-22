CREATE TABLE [dbo].[TblEvaluationStudents]
(
	[EvaluationFK]	INT		NOT NULL, 
	[StudentFK]		INT		NOT NULL,
    [Value]			FLOAT	NULL,
	CONSTRAINT [PK_EvaluatStudent] PRIMARY KEY CLUSTERED ([EvaluationFK] ASC, [StudentFK] ASC),
    CONSTRAINT [FK_TblEvaluatStudent_EvaluationID]	FOREIGN KEY ([EvaluationFK])REFERENCES [dbo].[TblEvaluations]([ID])	ON DELETE NO ACTION,
    CONSTRAINT [FK_TblEvaluatStudent_StudentID]		FOREIGN KEY ([StudentFK])	REFERENCES [dbo].[TblStudents]([ID])	ON DELETE NO ACTION
)
