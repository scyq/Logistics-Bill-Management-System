// ******************************************************************
// 文件名: Light.EXP.Business.Bill.BillBusiness.cs
// 作者:       陈宇卿
// 创建日期：  2020-04-20
// 主要内容：  票据管理模块的业务逻辑类文件
// ******************************************************************

namespace Light.EXP.Business.Bill
{
    using System;
    using System.Data;

    using Light.EXP.DataAccess.Bill;
    using Light.EXP.Model.Bill;
    public class BillBusiness
    {
        /// <summary>
        /// 获取多个票据分发实体，用于票据分发查询界面GridView的数据绑定
        /// </summary>
        /// <param name="receiveBillPerson">领票人</param>
        /// <param name="billType">票据类型</param>
        /// <param name="sortField">排序字段</param>
        /// <param name="sortOrder">排序次序</param>
        /// <param name="pageIndex">待读取的页索引</param>
        /// <param name="pageSize">每页显示的记录数</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns>DataSet</returns>

        public DataSet GetBillDispenses(string receiveBillPerson, string billType, string sortField, string sortOrder, int pageIndex, int pageSize, ref Int64 recordCount)
        {
            BillInterface ibill = BillFactory.Create();
            return ibill.GetBillDispenses(receiveBillPerson, billType, sortField, sortOrder, pageIndex, pageSize, ref recordCount);
        }

        /// <summary>
        /// 获取单个票据分发实体，用于票据分发编辑页面表单的数据填充
        /// </summary>
        /// <param name="pkId">票据Id</param>
        /// <returns>BillDispense</returns>

        public BillDispense GetBillDispense(int pkId)
        {
            BillInterface ibill = BillFactory.Create();
            return ibill.GetBillDispense(pkId);
        }

        /// <summary>
		/// 增加票据分发信息, 用于票据分发添加按钮的单击事件处理
		/// </summary>
		/// <param name="billDispense">票据分发实体</param>
		/// <returns>int</returns>
        
        public int CreateBillDispense(BillDispense billDispense)
        {
            BillInterface ibill = BillFactory.Create();
            if (!ibill.ExistBillDispense(billDispense.BillStartCode, billDispense.BillType, billDispense.ReceiveBillTime))
                return -1;
            else if (!ibill.ExistBillDispense(billDispense.BillEndCode, billDispense.BillType, billDispense.ReceiveBillTime))
                return -2;
            else
                if (ibill.CreateBillDispense(billDispense) > 0)
                return ibill.CreateBillDispense(billDispense);
            else
                return billDispense.PkId;
            
        }

        /// <summary>
        /// 修改票据分发信息，用于票据分发编辑页面修改点击按钮事件处理
        /// </summary>
        /// <param name="billDispense">票据分发实体</param>
        /// <returns>bool</returns>
        
        public bool UpdateBillDispense(BillDispense billDispense)
        {
            BillInterface ibill = BillFactory.Create();
            return ibill.UpdateBillDispense(billDispense);
        }

        /// <summary>
        /// 删除票据分发信息，用于票据分发编辑页面删除按钮的单击事件处理
        /// </summary>
        /// <param name="pkId">票据ID</param>
        /// <returns>bool</returns>

        public bool DeleteBillDispense(int pkId)
        {
            BillInterface ibill = BillFactory.Create();
            return ibill.DeleteBillDispense(pkId);
        }


        /// <summary>
        /// 检验票据编号是否存在，用于增加票据分发信息之前的逻辑判断
        /// </summary>
        /// <param name="billCode"></param>
        /// <param name="billType"></param>
        /// <param name="receiveBillTime"></param>
        /// <returns>bool</returns>

        public bool ExistBillDispense(string billCode, string billType, DateTime receiveBillTime)
        {
            BillInterface ibill = BillFactory.Create();
            return ibill.ExistBillDispense(billCode, billType, receiveBillTime);
        }

        /// <summary>
        /// 获取多个票据明细实体，用于票据核销页面GridView的数据绑定
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
        
        public DataSet GetBillDetails(string billCode, string billType, string billStatus, DateTime beginWriteDate, DateTime endWriteDate, int pageIndex, int pageSize, ref Int64 recordCount)
        {
            BillInterface ibill = BillFactory.Create();
            return ibill.GetBillDetails(billCode, billType, billStatus, beginWriteDate, endWriteDate, pageIndex, pageSize, ref recordCount);
        }

        /// <summary>
        /// 获取多个员工信息实体，用于票据管理模块领票人或分发人下拉框的数据绑定
        /// </summary>
        /// <return>DataSet</return>
        
        public DataSet GetBillEmployees()
        {
            BillInterface ibill = BillFactory.Create();
            return ibill.GetBillEmployees();
        }

    }
}
