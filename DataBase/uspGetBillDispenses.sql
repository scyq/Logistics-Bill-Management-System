USE [logisticsNew]
GO
/****** Object:  StoredProcedure [dbo].[uspGetBillDispenses]    Script Date: 2020-05-19 20:58:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************* 
*过程名称 : uspGetBillDispenses
*功能描述 : 获取多条票据分发信息
*输入参数 : 
	@receiveBillPerson	VARCHAR(50),	--领票人姓名
	@billType	VARCHAR(50),	        --票据类型
	@pageIndex	INT,					--待读取的页索引
	@pageSize	INT,					--每页显示的记录数
*输出参数 : 
	@recordCount	INT OUT		--总记录数
*返 回 值 :
	无
*结果集	:
	PKID				--票据ID
	BillType	        --票据类型
	BillStartCode	    --票据开始号
	BillEndCode		    --票据结束号
	ReceiveBillPerson	--领票人
	AcceptStation	    --接货点
	ReceiveBillTime		--领票时间
	ReceivePerson	    --分发人
*作	   者 : 陈宇卿
*创建日期 : 2020-3-11      
***********************************************************************************/

ALTER PROCEDURE [dbo].[uspGetBillDispenses]
(
	@receiveBillPerson	VARCHAR(50),	--领票人姓名
	@billType	VARCHAR(50),			--票据类型
	@pageIndex	INT,					--待读取的页索引
	@pageSize	INT,					--每页显示的记录数
	@recordCount	INT OUT				--总记录数
)

AS
BEGIN
	DECLARE @sqlBDS NVARCHAR(4000)  --Bill Dispenses Search SQL
	DECLARE @sqlRS NVARCHAR(4000)  --Result Set SQL
	
	-- 查出总条数
	SET @sqlBDS =
		'SELECT @recordCount = Count(*)
		 FROM BillMgt_BillDispense
		 WHERE ReceiveBillPerson LIKE ''%' + @receiveBillPerson + '%''' 
	
	IF @billType <> ''
	BEGIN
	SET	@sqlBDS = 
	@sqlBDS + ' AND BillType = ' + CONVERT(CHAR(50), @billType)
	END
	
	EXEC sp_executesql @sqlBDS, N'@recordcount INT OUT', @recordCount OUTPUT

	SET @sqlRS = 
		'SELECT SerialNumber,
			PKID,
			BillType,
			BillStartCode,
			BillEndCode,
			ReceiveBillPerson,
			AcceptStation,
			ReceiveBillTime,
			ReleasePerson
		FROM
		(
			SELECT PKID,
				BillType,
				BillStartCode,
				BillEndCode,
				ReceiveBillPerson,
				AcceptStation,
				ReceiveBillTime,
				ReleasePerson,
				ROW_NUMBER() OVER (ORDER BY PKID ASC) AS SerialNumber 
			FROM BillMgt_BillDispense
			WHERE ReceiveBillPerson LIKE ''%' + @receiveBillPerson + '%'''
	
	IF @billType <> ''
	BEGIN
	SET	@sqlRS = 
	@sqlRS + ' AND BillType = ' + CONVERT(CHAR(50), @billType)
	END

	SET @sqlRS = 
		@sqlRS + 	
		') AS T
		WHERE T.SerialNumber > ' + CONVERT(NVARCHAR(100), (@pageIndex - 1) * @pageSize) +
		' AND T.SerialNumber <= ' + CONVERT(NVARCHAR(100), @pageIndex * @PageSize)
 
	 EXEC (@sqlRS)
END