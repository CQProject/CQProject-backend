CREATE TABLE [dbo].[TblTimes]
(
	[ID]				INT				NOT NULL IDENTITY(1,1),
	[Order]				INT				NULL,
    [StartTime]			NVARCHAR(MAX)	NULL,
	[EndTime]			NVARCHAR(MAX)	NULL,
	[IsKindergarten]	BIT				NULL,
	[SchoolFK]			INT				NULL,
	CONSTRAINT [PK_TimeID] PRIMARY KEY CLUSTERED ([ID] ASC)
)
