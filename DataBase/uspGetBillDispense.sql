USE [logisticsNew]
GO
/****** Object:  StoredProcedure [dbo].[uspGetBillDispense]    Script Date: 2020-04-20 21:58:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************* 
*过程名称 : uspGetBillDispense
*功能描述 : 获取单条票据分发信息
*输入参数 : 
	@PKID 	INT	       --票据ID
*输出参数 : 
	无
*返 回 值 :
*结 果 集 :
	BillType			--票据类型
	BillStartCode		--票据开始号
	BillEndCode			--票据结束号
	ReceiveBillPerson	--领票人
	AcceptStation		--接货点
	ReceiveBillTime		--领票时间
	ReleasePerson		--分发人
*作	   者 : 陈宇卿
*创建日期 : 2020-03-25    
***********************************************************************************/

ALTER PROCEDURE [dbo].[uspGetBillDispense]
(
	@PKID	INT		--票据ID
)
AS
BEGIN
	SELECT BillType,
		BillStartCode,
		BillEndCode,
		ReceiveBillPerson,
		AcceptStation,
		ReceiveBillTime,
		ReleasePerson
	FROM BillMgt_BillDispense 
	WHERE PKID = @PKID
END