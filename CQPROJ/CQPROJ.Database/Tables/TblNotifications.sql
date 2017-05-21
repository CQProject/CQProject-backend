CREATE TABLE [dbo].[TblNotifications]
(
	[ID]			INT				NOT NULL IDENTITY(1,1),
	[Hour]			DATETIME		NULL, 
    [Description]	NVARCHAR(MAX)	NULL, 
    [Urgency]		BIT				NULL, 
    [UserFK]		INT				NULL ,
	CONSTRAINT [PK_NotificationID] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_TblNotification_UserID]	FOREIGN KEY([UserFK])	REFERENCES [dbo].[TblUsers]([ID]) ON DELETE CASCADE
)
