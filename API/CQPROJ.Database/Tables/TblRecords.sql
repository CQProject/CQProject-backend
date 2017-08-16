CREATE TABLE [dbo].[TblRecords]
(
	[ID]			INT				NOT NULL IDENTITY(1,1),
	[Hour]			DATETIME		NULL,
	[Temperature]	INT				NULL,
	[Luminosity]	INT				NULL,
	[Energy]		INT				NULL,
	[Humidity]		FLOAT			NULL,
	[SensorFK]		INT				NULL,
	CONSTRAINT [PK_RecordID] PRIMARY KEY CLUSTERED ([ID] ASC)
)
