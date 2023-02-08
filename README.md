Script for generate database and store procedure
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
#
USE [Bank]
GO
/****** Object:  StoredProcedure [dbo].[GET_ACCOUNT_ACCTNO]    Script Date: 2/8/2023 11:20:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GET_ACCOUNT_ACCTNO] 
	@accountNo NVARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM BANK_ACCOUNT
	where ACCOUNT_NUMBER = @accountNo
END
GO
/****** Object:  StoredProcedure [dbo].[GET_CUSTOMER_BY_ID]    Script Date: 2/8/2023 11:20:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GET_CUSTOMER_BY_ID]
	-- Add the parameters for the stored procedure here
	@customerID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM CUSTOMER
	where CUSTOMER.ID = @customerID;
END
GO
/****** Object:  StoredProcedure [dbo].[INSERT_BANK_ACCOUNT]    Script Date: 2/8/2023 11:20:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[INSERT_BANK_ACCOUNT] 
	-- Add the parameters for the stored procedure here
	@custId INT,
	@accountNumber NVARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	 INSERT INTO BANK_ACCOUNT([CUST_ID],[ACCOUNT_NUMBER],[BALANCE])
	VALUES (@custId,@accountNumber,0);
END
GO
/****** Object:  StoredProcedure [dbo].[INSERT_TRANSACTION]    Script Date: 2/8/2023 11:20:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[INSERT_TRANSACTION]
	-- Add the parameters for the stored procedure here
	@accountNo NVARCHAR(50),
	@amount decimal,
	@tranType NVARCHAR(10),
	@terminalAccNumber NVARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO TRANSACTIONS ([ACCOUNT_NUMBER],[AMOUNT],[TRAN_TYPE],[TERMINAL_ACC_NUMBER])
	VALUES (@accountNo,@amount,@tranType,@terminalAccNumber);

END
GO
/****** Object:  StoredProcedure [dbo].[UPDATE_BALANCE_BY_ACCNO]    Script Date: 2/8/2023 11:20:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UPDATE_BALANCE_BY_ACCNO]
	@balance decimal,
	@accountNo NVARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE BANK_ACCOUNT
	set BALANCE = @balance
	where ACCOUNT_NUMBER = @accountNo
END
GO
