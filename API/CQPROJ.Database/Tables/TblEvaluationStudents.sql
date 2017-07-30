CREATE TABLE [dbo].[TblEvaluationStudents]
(
	[EvaluationFK]	INT		NOT NULL, 
	[StudentFK]		INT		NOT NULL,
    [Value]			FLOAT	NULL,
	CONSTRAINT [PK_EvaluationStudent] PRIMARY KEY CLUSTERED ([EvaluationFK] ASC, [StudentFK] ASC)
)
