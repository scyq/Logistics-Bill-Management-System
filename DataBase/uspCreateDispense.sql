USE [logisticsNew]
GO
/****** Object:  StoredProcedure [dbo].[uspCreateDispense]    Script Date: 2020-05-19 22:56:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************* 
*过程名称 : uspCreateBillDispense
*功能描述 : 增加票据分发信息
*输入参数 : 
	@billType				VARCHAR(50),		--票据类型
    @billStartCode 			VARCHAR(50),	    --票据开始号
	@billEndCode			VARCHAR(50),     	--票据结束号
	@receiveBillPerson		VARCHAR(50),		--领票人
	@acceptStation			VARCHAR(50),		--接货点
	@receiveBillTime		DATETIME,			--领票时间
	@releasePerson			VARCHAR(50),		--分发人
*输出参数 : 
	@PKID					INT OUTPUT			--票据ID
*返 回 值 :
	0 - 成功
	<> 0 - 失败
*作    者 : 陈宇卿
*创建日期 : 2020-03-30      
***********************************************************************************/

ALTER PROCEDURE [dbo].[uspCreateDispense]
(
	@billType				VARCHAR(50),		--票据类型
    @billStartCode 			VARCHAR(50),	    --票据开始号
	@billEndCode			VARCHAR(50),     	--票据结束号
	@receiveBillPerson		VARCHAR(50),		--领票人
	@acceptStation			VARCHAR(50),		--接货点
	@receiveBillTime		DATETIME,			--领票时间
	@releasePerson			VARCHAR(50),		--分发人
	@PKID					INT OUTPUT          --输出参数
)
AS
BEGIN

	SET @billStartCode = dbo.funGenerateBillCode(@billType,@billStartCode,@receiveBillTime)
	SET @billEndCode = dbo.funGenerateBillCode(@billType,@billEndCode,@receiveBillTime)

	BEGIN TRY
	INSERT BillMgt_BillDispense
	(	
		BillType,
		BillStartCode,
		BillEndCode,
		ReceiveBillPerson,
		AcceptStation,
		ReceiveBillTime,
		ReleasePerson
	)
	VALUES
	(
		@billType,
		@billStartCode,
		@billEndCode,
		@receiveBillPerson,
		@acceptStation,
		@receiveBillTime,
		@releasePerson
	)
	RETURN 0
	END TRY
	BEGIN CATCH
		RETURN ERROR_NUMBER()
	END CATCH

	SET @PKID = @@IDENTITY			-- 返回最后一个插入的ID
END