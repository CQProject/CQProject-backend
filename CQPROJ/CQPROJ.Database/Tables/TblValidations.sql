CREATE TABLE [dbo].[TblValidations]
(
	[UserFK]			INT NOT NULL,
	[NotificationFK]	INT NOT NULL,
	[Accepted]			BIT NULL ,
	[Readed]			BIT NULL ,
	CONSTRAINT [PK_ValidationID] PRIMARY KEY CLUSTERED ([UserFK] ASC, [NotificationFK] ASC),
    CONSTRAINT [FK_TblValidation_UserID]			FOREIGN KEY ([NotificationFK])	REFERENCES [dbo].[TblNotifications]([ID])	ON DELETE NO ACTION,
    CONSTRAINT [FK_TblValidation_NotificationID]	FOREIGN KEY ([UserFK])			REFERENCES [dbo].[TblUsers]([ID])			ON DELETE NO ACTION
)
