// ******************************************************************
// 文件名: Light.EXP.DataAccess.Bill.BillInterface.cs
// 作者:       陈宇卿
// 创建日期：  2020-04-15
// 主要内容：  票据管理模块的数据接口文件
// ******************************************************************
namespace Light.EXP.DataAccess.Bill
{

    using System;
    using System.Data;
    using System.Data.SqlClient;
    using Light.EXP.Model.Bill;
    public interface BillInterface
    {
        /// <summary>
        /// 获取多个票据分发实体
        /// </summary>
        /// <param name="receiveBillPerson">领票人</param>
        /// <param name="billType">票据类型</param>
        /// <param name="sortField">排序字段</param>
        /// <param name="sortOrder">排序次序</param>
        /// <param name="pageIndex">待读取的页索引</param>
        /// <param name="pageSize">每页显示的记录数</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns>DataSet</returns>

        DataSet GetBillDispenses(string receiveBillPerson, string billType, string sortField, string sortOrder, int pageIndex, int pageSize, ref Int64 recordCount);

        /// <summary>
        /// 获取单个票据分发实体
        /// </summary>
        /// <param name="pkId">票据Id</param>
        /// <returns>BillDispense</returns>

        BillDispense GetBillDispense(int pkId);

        /// <summary>
        /// 增加票据分发信息
        /// </summary>
        /// <param name="billDispense">票据分发实体</param>
        /// <returns>int</returns>

        int CreateBillDispense(BillDispense billDispense);

        /// <summary>
        /// 修改票据分发信息
        /// </summary>
        /// <param name="billDispense">票据分发实体</param>
        /// <returns>bool</returns>

        bool UpdateBillDispense(BillDispense billDispense);

        /// <summary>
        /// 删除票据分发信息
        /// </summary>
        /// <param name="pkId">票据ID</param>
        /// <returns>bool</returns>

        bool DeleteBillDispense(int pkId);

        /// <summary>
        /// 检验票据编号是否存在
        /// </summary>
        /// <param name="billCode"></param>
        /// <param name="billType"></param>
        /// <param name="receiveBillTime"></param>
        /// <returns>bool</returns>

        bool ExistBillDispense(string billCode, string billType, DateTime receiveBillTime);

        /// <summary>
        /// 获取多个票据明细实体
        /// </summary>
        /// <param name="billCode">票据编号</param>
        /// <param name="billType">票据类型</param>
        /// <param name="billStatus">票据状态</param>
        /// <param name="beginWriteDate">开始填写日期</param>
        /// <param name="endWriteDate">结束填写日期</param>
        /// <param name="pageIndex">待读取的页索引</param>
        /// <param name="pageSize">每页显示的记录数</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns>DataSet</returns>

        DataSet GetBillDetails(string billCode, string billType, string billStatus, DateTime beginWriteDate, DateTime endWriteDate, int pageIndex, int pageSize, ref Int64 recordCount);

        /// <summary>
        /// 获取多个员工信息实体
        /// </summary>
        /// <return>DataSet</return>

        DataSet GetBillEmployees();
    }
}
