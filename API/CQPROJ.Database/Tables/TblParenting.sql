CREATE TABLE [dbo].[TblParenting]
(
	[StudentFK]		INT		NOT NULL, 
	[GuardianFK]	INT		NOT NULL,
	CONSTRAINT [PK_Parenting] PRIMARY KEY CLUSTERED ([StudentFK] ASC, [GuardianFK] ASC)
)
