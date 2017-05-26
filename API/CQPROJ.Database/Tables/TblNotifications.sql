CREATE TABLE [dbo].[TblNotifications]
(
	[ID]			INT				NOT NULL IDENTITY(1,1),
	[Hour]			DATETIME		NULL, 
	[Subject]		NVARCHAR(MAX)	NULL, 
    [Description]	NVARCHAR(MAX)	NULL, 
    [Urgency]		BIT				NULL, 
    [UserFK]		INT				NULL ,
	CONSTRAINT [PK_NotificationID] PRIMARY KEY CLUSTERED ([ID] ASC),
)
