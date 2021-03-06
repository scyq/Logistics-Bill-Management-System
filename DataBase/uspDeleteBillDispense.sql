USE [logisticsNew]
GO
/****** Object:  StoredProcedure [dbo].[uspDeleteBillDispense]    Script Date: 2020-03-30 22:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************* 
*过程名称 : uspDeleteBillDispense
*功能描述 : 删除票据分发信息
*输入参数 : 
	@PKID	INT,	--票据ID
*输出参数 : 
	无
*返 回 值 :
	0 - 成功
	<> 0 - 失败
*作    者 : 陈宇卿
*创建日期 : 2020-3-20      
***********************************************************************************/

ALTER PROCEDURE [dbo].[uspDeleteBillDispense]
(
	 @PKID	INT	--票据ID
)
AS
BEGIN
	BEGIN TRY
		DELETE BillMgt_BillDispense 
		WHERE PKID = @PKID
		RETURN 0
	END TRY
	BEGIN CATCH
		RETURN ERROR_NUMBER()
	END CATCH
END