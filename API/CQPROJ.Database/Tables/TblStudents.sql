CREATE TABLE [dbo].[TblStudents]
(
	[ID]			INT				NOT NULL IDENTITY(1,1),
	[Photo]			NVARCHAR(MAX)	NULL,
	[DataOfBirth]	DATETIME		NULL,
	[UserFK]		INT				NULL,
    [GuardianFK]	INT				NULL,
	CONSTRAINT [PK_StudentID] PRIMARY KEY CLUSTERED ([ID] ASC),
)
