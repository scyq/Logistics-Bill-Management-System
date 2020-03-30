USE [logisticsNew]
GO
/****** Object:  StoredProcedure [dbo].[uspGetBillEmployees]    Script Date: 2020-03-31 0:04:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************* 
*过程名称 : uspGetBillEmployees
*功能描述 : 获取全部员工信息，用于员工选择下拉框
*输入参数 : 
	无
*输出参数 : 
	无
*返 回 值 :
*作	   者 : 陈宇卿
*创建日期 : 2020-3-31      
***********************************************************************************/
ALTER PROCEDURE [dbo].[uspGetBillEmployees]

AS
BEGIN
	SELECT *
	FROM Basic_EmployeeInfor 
END


