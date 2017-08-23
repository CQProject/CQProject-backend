CREATE TABLE [dbo].[TblValidations]
(
	[ReceiverFK]		INT NOT NULL,
	[NotificationFK]	INT NOT NULL,
	[StudentFK]			INT NULL,
	[Accepted]			BIT NULL ,
	[Read]				BIT NULL ,
	CONSTRAINT [PK_ValidationID] PRIMARY KEY CLUSTERED ([ReceiverFK] ASC, [NotificationFK] ASC)
)
