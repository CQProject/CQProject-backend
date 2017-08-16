CREATE TABLE [dbo].[TblSensors]
(
	[ID]			INT				NOT NULL IDENTITY(1,1),
	[Name]			NVARCHAR(MAX)	NULL,
	[XCoord]		INT				NULL,
	[YCoord]		INT				NULL,
	[FloorFK]		INT				NULL,
	CONSTRAINT [PK_SensorID] PRIMARY KEY CLUSTERED ([ID] ASC)
)
