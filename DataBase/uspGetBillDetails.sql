USE [logisticsNew]
GO
/****** Object:  StoredProcedure [dbo].[uspGetBillDetails]    Script Date: 2020-05-19 21:00:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************* 
*过程名称 : uspGetBillDetails
*功能描述 : 获取多条票据明细信息
*输入参数 : 
	@billCode			VARCHAR(50),			--票据编号
	@billType			VARCHAR(50),	        --票据类型
	@billStatus			VARCHAR(50),			--票据状态
	@beginWriteDate		DATETIME,				--开始填写日期
	@endWriteDate		DATETIME,				--结束填写日期
	@pageIndex			INT,					--待读取的页索引
	@pageSize			INT,					--每页显示的记录数
*输出参数 : 
	@recordCount	INT OUT		--总记录数
*返 回 值 :
	无
*结果集	:
	BillType	        --票据类型
	BillCode			--票据编号
	BillState		    --票据状态
	WriteDate			--填写日期
	AcceptStation	    --接货点
*作	   者 : 陈宇卿
*创建日期 : 2020-3-30 
***********************************************************************************/
ALTER PROCEDURE [dbo].[uspGetBillDetails]
(
	@billCode			VARCHAR(50),			--票据编号
	@billType			VARCHAR(50),	        --票据类型
	@billStatus			VARCHAR(50),			--票据状态
	@beginWriteDate		DATETIME,				--开始填写日期
	@endWriteDate		DATETIME,				--结束填写日期
	@pageIndex			INT,					--待读取的页索引
	@pageSize			INT,					--每页显示的记录数
	@recordCount		INT OUT					--总记录数
)
AS
BEGIN
	DECLARE @sqlDS NVARCHAR(4000)   --Detail Search SQL
	DECLARE @sqlBDRS NVARCHAR(4000)  --Bill Detail Result Search SQL	
	
	--查出总条数
	SET @sqlDS =
		'SELECT @recordCount = Count(*)
		 FROM BillMgt_BillDetail
		 WHERE BillCode LIKE ''%' + @billCode + '%''' 

	IF @billType <> ''
	BEGIN
	SET	@sqlDS = 
	@sqlDS + ' AND BillType = ' + CONVERT(CHAR(50), @billType)
	END

	IF @billStatus <> ''
	BEGIN
	SET	@sqlDS = 
	@sqlDS + ' AND BillState = ' + CONVERT(CHAR(50), @billStatus)
	END

	IF @beginWriteDate <>NULL
	BEGIN
	SET	@sqlDS = 
	@sqlDS + ' AND WriteDate >= ' + CONVERT(CHAR(50), @beginWriteDate)
	END

	IF @endWriteDate <>NULL
	BEGIN
	SET	@sqlDS = 
	@sqlDS + ' AND WriteDate <= ' + CONVERT(CHAR(50), @endWriteDate)
	END

	EXEC sp_executesql @sqlDS, N'@recordCount INT OUT', @recordCount OUTPUT

	SET @sqlBDRS = 
		'SELECT SerialNumber,
				BillType,
				BillCode,
				BillState,
				WriteDate,
				AcceptStation
		FROM
		(
			SELECT BillType,
				BillCode,
				BillState,
				WriteDate,
				AcceptStation,
				ROW_NUMBER() OVER (ORDER BY PKID ASC) AS SerialNumber 
			FROM BillMgt_BillDetail
			WHERE BillCode LIKE ''%' + @billCode + '%'''
	
	IF @billType <> ''
	BEGIN
	SET	@sqlBDRS = 
	@sqlBDRS + ' AND BillType = ' + CONVERT(CHAR(50), @billType)
	END

	IF @billStatus <> ''
	BEGIN
	SET	@sqlBDRS = 
	@sqlBDRS + ' AND BillState = ' + CONVERT(CHAR(50), @billStatus)
	END

	IF @beginWriteDate <>NULL
	BEGIN
	SET	@sqlBDRS = 
	@sqlBDRS + ' AND WriteDate >= ' + CONVERT(CHAR(50), @beginWriteDate)
	END

	IF @endWriteDate <>NULL
	BEGIN
	SET	@sqlBDRS = 
	@sqlBDRS + ' AND WriteDate <= ' + CONVERT(CHAR(50), @endWriteDate)
	END

	SET @sqlBDRS = 
		@sqlBDRS + 	
		') AS T
		WHERE T.SerialNumber > ' + CONVERT(NVARCHAR(100), (@pageIndex - 1) * @pageSize) +
		' AND T.SerialNumber <= ' + CONVERT(NVARCHAR(100), @pageIndex * @PageSize)
 
	 EXEC (@sqlBDRS)
END