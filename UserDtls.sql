USE [UserDb]
GO
/****** Object:  Table [dbo].[UserDtls]    Script Date: 11/27/2019 16:48:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDtls](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[UserType] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL
) ON [PRIMARY]
GO
