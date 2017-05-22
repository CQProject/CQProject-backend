CREATE TABLE [dbo].[TblSchAssistants]
(
	[ID]			INT				NOT NULL IDENTITY(1,1),
    [FiscalNumber]	NVARCHAR(9)		NULL,
    [CitizenCard]	NVARCHAR(9)		NULL,
    [PhoneNumber]	NVARCHAR(13)	NULL,
    [Address]		NVARCHAR(MAX)	NULL,
    [Photo]			NVARCHAR(MAX)	NULL,
    [Curriculum]	NVARCHAR(MAX)	NULL,
	[StartWorkTime] DATETIME		NULL,
    [EndWorkTime]	DATETIME		NULL,
    [UserFK]		INT				NOT NULL,
	CONSTRAINT [PK_SchAssistantID] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_TblSchAssistant_UserID]	FOREIGN KEY([UserFK]) REFERENCES [dbo].[TblUsers]([ID]) ON DELETE NO ACTION
)
