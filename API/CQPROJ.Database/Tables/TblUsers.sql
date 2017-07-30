CREATE TABLE [dbo].[TblUsers]
(
	[ID]			INT				NOT NULL IDENTITY(1,1), 
	[Name]			NVARCHAR(MAX)	NULL,
    [Email]			NVARCHAR(MAX)	NULL,
	[FiscalNumber]	NVARCHAR(MAX)	NULL,
	[CitizenCard]	NVARCHAR(MAX)	NULL,
	[PhoneNumber]	NVARCHAR(MAX)	NULL,
	[Address]		NVARCHAR(MAX)	NULL,
	[Photo]			NVARCHAR(MAX)	NULL,
	[Curriculum]	NVARCHAR(MAX)	NULL,
	[DateOfBirth]	DATETIME		NULL,
	[Password]		NVARCHAR(MAX)	NULL, 
    [RegisterDate]	DATETIME		NULL, 
    [IsActive]		BIT				NULL,
	[Function]		NVARCHAR(MAX)	NULL,
    CONSTRAINT [PK_UserID] PRIMARY KEY CLUSTERED ([ID] ASC)
)
