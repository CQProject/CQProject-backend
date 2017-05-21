CREATE TABLE [dbo].[TblTasks]
(
	[ID]			 INT			NOT NULL IDENTITY(1,1), 
    [DayOfWeek]		 DATETIME		NULL, 
    [Hour]			 DATETIME		NULL, 
    [Weekly]		 BIT			NULL, 
	[Description]	 NVARCHAR(MAX)	NULL,
    [SecretaryFK]	 INT			NULL, 
    [SchAssistantFK] INT			NULL,
	CONSTRAINT [PK_TaskID] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_TblTask_SecretaryID]		FOREIGN KEY([SecretaryFK])		REFERENCES [dbo].[TblSecretaries]([ID])	  ON DELETE CASCADE,
	CONSTRAINT [FK_TblTask_SchAssistantID]	FOREIGN KEY([SchAssistantFK])	REFERENCES [dbo].[TblSchAssistants]([ID]) ON DELETE CASCADE
)
