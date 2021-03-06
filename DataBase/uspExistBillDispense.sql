USE [logisticsNew]
GO
/****** Object:  StoredProcedure [dbo].[uspExistBillDispense]    Script Date: 2020-03-30 23:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************* 
*过程名称 : uspExistBillDispense
*功能描述 : 判定指定票据类型的票据开始号或票据结束号在票据分发表中是否存在
*输入参数 : 
	@billCode	VARCHAR(50),		--票据开始号或票据结束号
	@billType	VARCHAR(50),		--票据类型
	@receiveBillTime DATETIME		--领票时间
*输出参数 : 
	默认
*返 回 值 :
	0 - 不存在
	1 - 存在
*作    者 : 陈宇卿
*创建日期 : 2020-3-30      
***********************************************************************************/
ALTER PROCEDURE [dbo].[uspExistBillDispense]
(
	@billCode	VARCHAR(50),		--票据开始号或票据结束号
	@billType	VARCHAR(50),		--票据类型
	@receiveBillTime DATETIME		--领票时间
)
AS
BEGIN
	DECLARE @vBillCode	VARCHAR(11)			--真实票据编号变量，11位和函数对应
	SET @vBillCode = dbo.funGenerateBillCode(@billType,@billCode,@receiveBillTime)

	DECLARE @billStartCode	VARCHAR(11)		--游标结果集变量
	DECLARE @billEndCode	VARCHAR(11)		

	DECLARE @FLAG	INT						--找到与否的标志

	DECLARE cursorBillDispense cursor
	FOR	SELECT BillStartCode, BillEndCode
	FROM BillMgt_BillDispense
	WHERE BillType = @billType				--过滤条件

	OPEN cursorBillDispense
	FETCH NEXT FROM cursorBillDispense INTO @billStartCode, @billEndCode

	WHILE @@FETCH_STATUS = 0
	BEGIN
		IF (@vBillCode <= @billStartCode AND @vBillCode >= @billEndCode) SET @FLAG = 1
		ELSE FETCH NEXT FROM cursorBillDispense INTO @billStartCode, @billEndCode
	END

	CLOSE cursorBillDispense
	DEALLOCATE	cursorBillDispense

	--甄别是否查询到，如果是1就查询到了，否则就没有
	IF(@FLAG = 1) RETURN 1
	ELSE RETURN 0

END