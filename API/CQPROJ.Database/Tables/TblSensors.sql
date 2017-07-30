CREATE TABLE [dbo].[TblSensors]
(
	[ID]			INT				NOT NULL IDENTITY(1,1),
	[Hour]			DATETIME		NULL,
	[Temperature]	INT				NULL,
	[Luminosity]	INT				NULL,
	[Energy]		INT				NULL,
	[RoomFK]		INT				NULL,
	CONSTRAINT [PK_SensorID] PRIMARY KEY CLUSTERED ([ID] ASC)
)
