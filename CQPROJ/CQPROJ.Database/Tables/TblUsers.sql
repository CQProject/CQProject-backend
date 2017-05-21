CREATE TABLE [dbo].[TblUsers]
(
	[ID]			INT				NOT NULL IDENTITY(1,1), 
    [Name]			NVARCHAR(MAX)	NOT NULL, 
    [Email]			NVARCHAR(MAX)	NULL, 
    [FiscalNumber]	NVARCHAR(MAX)	NOT NULL, 
    [CitizenCard]	NVARCHAR(MAX)	NOT NULL, 
    [PhoneNumber]	NVARCHAR(MAX)	NOT NULL, 
    [Photo]			NVARCHAR(MAX)	NULL, 
    [Curriculum]	NVARCHAR(MAX)	NULL,
	[Password]		NVARCHAR(MAX)	NOT NULL, 
    [CreatedDate]	DATETIME		NOT NULL, 
    [IsActive]		BIT				NULL,
	CONSTRAINT [PK_UserID] PRIMARY KEY CLUSTERED ([ID] ASC)
)
