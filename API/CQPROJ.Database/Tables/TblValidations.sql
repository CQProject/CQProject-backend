CREATE TABLE [dbo].[TblValidations]
(
	[UserFK]			INT NOT NULL,
	[NotificationFK]	INT NOT NULL,
	[Accepted]			BIT NULL ,
	[Readed]			BIT NULL ,
	CONSTRAINT [PK_ValidationID] PRIMARY KEY CLUSTERED ([UserFK] ASC, [NotificationFK] ASC),
)
