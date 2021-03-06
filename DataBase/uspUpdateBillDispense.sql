USE [logisticsNew]
GO
/****** Object:  StoredProcedure [dbo].[uspUpdateBillDispense]    Script Date: 2020-03-30 22:46:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************* 
*过程名称 : uspUpdateBillDispense
*功能描述 : 修改票据分发信息
*输入参数 : 
	@PKID				INT,			--票据ID
    @receiveBillPerson 	VARCHAR(50),	--领票人
	@acceptionStation   VARCHAR(50),    --接货点
	@releasePerson		VARCHAR(50),	--分发人

*输出参数 : 
	无
*返 回 值 :
	0 - 成功
	<> 0 - 失败
*作    者 : 陈宇卿
*创建日期 : 2020-3-30      
***********************************************************************************/
ALTER PROCEDURE [dbo].[uspUpdateBillDispense]
(
	@PKID				INT,			--票据ID
    @receiveBillPerson 	VARCHAR(50),	--领票人
	@acceptionStation   VARCHAR(50),    --接货点
	@releasePerson		VARCHAR(50)	--分发人
)
AS
BEGIN
	BEGIN TRY
		UPDATE BillMgt_BillDispense
		SET ReceiveBillPerson = @receiveBillPerson,
			AcceptStation = @acceptionStation,
			ReleasePerson = @releasePerson
		WHERE PKID = @PKID
		RETURN 0
	END TRY
	BEGIN CATCH
		RETURN ERROR_NUMBER()
	END CATCH


END