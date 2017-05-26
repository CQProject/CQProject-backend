CREATE TABLE [dbo].[TblGuardians]
(
	[ID]				INT				NOT NULL IDENTITY(1,1), 
    [FiscalNumber]		NVARCHAR(9)		NULL, 
    [CitizenCard]		NVARCHAR(9)		NULL, 
    [PhoneNumber]		NVARCHAR(13)	NULL, 
    [Address]			NVARCHAR(MAX)	NULL, 
	[NotContactHours]	NVARCHAR(MAX)	NULL,
    [UserFK]			INT				NOT NULL,
	CONSTRAINT [PK_GuardianID] PRIMARY KEY CLUSTERED ([ID] ASC),
)