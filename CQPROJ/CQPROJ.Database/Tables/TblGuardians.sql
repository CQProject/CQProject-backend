CREATE TABLE [dbo].[TblGuardians]
(
	[ID]				INT				NOT NULL IDENTITY(1,1), 
    [FiscalNumber]		NVARCHAR(9)		NULL, 
    [CitizenCard]		NVARCHAR(9)		NULL, 
    [PhoneNumber]		NVARCHAR(13)	NULL, 
    [Address]			NVARCHAR(MAX)	NULL, 
	[StartWorkTime]		DATETIME		NULL,
	[NotContactHours]	NVARCHAR(MAX)	NULL,
    [UserFK]			INT				NOT NULL,
	CONSTRAINT [PK_GuardianID] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_TblGuardian_UserID] FOREIGN KEY([UserFK]) REFERENCES [dbo].[TblUsers]([ID]) ON DELETE NO ACTION
)