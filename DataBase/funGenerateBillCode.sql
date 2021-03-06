USE [logisticsNew]
GO
/****** Object:  UserDefinedFunction [dbo].[funGenerateBillCode]    Script Date: 2020-03-25 21:08:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- 函数名称：funGenerateBillCode
-- 作    者：陈宇卿
-- 生成日期：2020-03-25	
-- 功能描述：生成票据编号的自定义函数
-- =============================================

ALTER FUNCTION [dbo].[funGenerateBillCode]
(
	@billType			NVARCHAR(50),	--票据类型
	@billCode			NVARCHAR(50),	--票据编号
	@receiveBillTime	DATETIME		--领票时间
)
RETURNS	CHAR(11) --返回数据类型
AS
BEGIN
	DECLARE @returnBillCode	VARCHAR(11)	--返回值
	SET @returnBillCode = CASE @billType
	WHEN '货运单' THEN 'C'
	WHEN '回执单' THEN 'R'
	ELSE 'N'	-- 表示Null
	END 
	-- 112的格式为 YYMMDD 这里只取六位
	SET @returnBillCode = @returnBillCode + CONVERT(CHAR(6),@receiveBillTime,112)

	SET @returnBillCode = @returnBillCode + @billCode

	RETURN @returnBillCode
END

