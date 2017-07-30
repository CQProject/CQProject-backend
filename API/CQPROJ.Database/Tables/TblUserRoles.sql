CREATE TABLE [dbo].[TblUserRoles]
(
	[UserFK] INT NOT NULL,
    [RoleFK] INT NOT NULL,
    CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED ([UserFK] ASC, [RoleFK] ASC)
)
