USE [Bank]
GO
/****** Object:  Table [dbo].[BANK_ACCOUNT]    Script Date: 2/8/2023 11:19:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BANK_ACCOUNT](
	[CUST_ID] [bigint] NULL,
	[ACCOUNT_NUMBER] [nvarchar](50) NULL,
	[BALANCE] [decimal](18, 0) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CUSTOMER]    Script Date: 2/8/2023 11:19:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CUSTOMER](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[FIRST_NAME] [nvarchar](max) NULL,
	[LAST_NAME] [nvarchar](max) NULL,
	[CITIZEN_ID] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TRANSACTIONS]    Script Date: 2/8/2023 11:19:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TRANSACTIONS](
	[ACCOUNT_NUMBER] [nvarchar](50) NULL,
	[AMOUNT] [decimal](18, 0) NULL,
	[TRAN_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[TRAN_TYPE] [nchar](10) NULL,
	[TERMINAL_ACC_NUMBER] [nvarchar](50) NULL
) ON [PRIMARY]
GO
