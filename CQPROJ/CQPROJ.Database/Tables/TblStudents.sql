CREATE TABLE [dbo].[TblStudents]
(
	[ID]			INT				NOT NULL IDENTITY(1,1),
	[Photo]			NVARCHAR(MAX)	NULL,
	[DataOfBirth]	DATETIME		NULL,
	[UserFK]		INT				NULL,
    [GuardianFK]	INT				NULL,
	CONSTRAINT [PK_StudentID] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_TblStudent_UserID]		FOREIGN KEY([UserFK])		REFERENCES [dbo].[TblUsers]([ID]) ON DELETE NO ACTION,
	CONSTRAINT [FK_TblStudent_GuardianID]	FOREIGN KEY([GuardianFK])	REFERENCES [dbo].[TblGuardians]([ID]) ON DELETE NO ACTION
)
