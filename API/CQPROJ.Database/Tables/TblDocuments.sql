CREATE TABLE [dbo].[TblDocuments]
(
	[ID]			INT				NOT NULL IDENTITY(1,1), 
    [File]			NVARCHAR(MAX)	NULL, 
    [IsVisible]		BIT				NULL,
	[SubmitedIn]	DATETIME		NULL, 
	[ClassFK]		INT				NULL, 
    [UserFK]		INT				NULL, 
	[SubjectFK]		INT				NULL,
    CONSTRAINT [PK_DocumentID] PRIMARY KEY CLUSTERED ([ID] ASC),
)
