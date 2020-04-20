// ******************************************************************
// 文件名: Light.EXP.DataAccess.SQLServer.BillSQLHandle.cs
// 作者:       陈宇卿
// 创建日期：  2020-04-13
// 主要内容：  票据管理模块的数据处理类文件
// ******************************************************************

namespace Light.EXP.DataAccess.Bill
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using Light.EXP.Model.Bill;
    using Light.EXP.DataAccess.SystemFrame;

    class BillSQLHandle
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
        public DataSet GetBillDispenses(string receiveBillPerson, string billType, string sortField, string sortOrder, int pageIndex, int pageSize, ref Int64 recordCount)
        {
            SQLHelper helper = new SQLHelper();
            SqlParameter[] prams =
            {
                new SqlParameter("@receiveBillPerson",SqlDbType.VarChar,50),
                new SqlParameter("@billType",SqlDbType.VarChar,50),
                new SqlParameter("@sortField", SqlDbType.NVarChar, 255),
                new SqlParameter("@sortOrder", SqlDbType.NVarChar, 4),
                new SqlParameter("@pageIndex",SqlDbType.Int,4),
                new SqlParameter("@pageSize",SqlDbType.Int,4),
                new SqlParameter("@recordCount", SqlDbType.Int, 4)
            };

            prams[0].Value = receiveBillPerson;
            prams[1].Value = billType;
            prams[2].Value = sortField;
            prams[3].Value = sortOrder;
            prams[4].Value = pageIndex;
            prams[5].Value = pageSize;
            prams[6].Direction = ParameterDirection.Output;
            DataSet ds = helper.ExecuteDataSet("uspGetBillDispenses", prams);
            recordCount = int.Parse(prams[6].Value.ToString());
            return ds;

        }

        /// <summary>
        /// 获取单个票据分发实体
		/// </summary>
        /// <param name="pkId">票据Id</param>
		/// <returns>BillDispense</returns>

        public BillDispense GetBillDispense(int pkId)
        {
            SQLHelper helper = new SQLHelper();
            SqlDataReader dr = null;
            SqlParameter[] prams =
            {
                new SqlParameter("@pkId", SqlDbType.Int, 4)
            };
            prams[0].Value = pkId;
            dr = helper.ExecuteDataReader("uspGetBillDispense", prams);

            BillDispense billDispense = new BillDispense();

            if (dr.Read())
            {
                billDispense.PkId = int.Parse(dr["PkId"].ToString());
                billDispense.BillType = dr["BillType"].ToString();
                billDispense.BillStartCode = dr["BillStartCode"].ToString();
                billDispense.BillEndCode = dr["BillEndCode"].ToString();
                billDispense.ReceiveBillPerson = dr["ReceiveBillPerson"].ToString();
                billDispense.AcceptStation = dr["AcceptStation"].ToString();
                if (dr["ReceiveBillTime"] == System.DBNull.Value)
                    billDispense.ReceiveBillTime = Convert.ToDateTime("1900-01-01");
                else
                    billDispense.ReceiveBillTime = Convert.ToDateTime(dr["ReceiveBillTime"].ToString());
                billDispense.ReleasePerson = dr["ReleasePerson"].ToString();
            }

            return billDispense;
        }

        /// <summary>
        /// 增加票据分发信息
		/// </summary>
		/// <param name="billDispense">票据分发实体</param>
		/// <returns>int</returns>
        public int CreateBillDispense(BillDispense billDispense)
        {
            SQLHelper helper = new SQLHelper();
            SqlParameter[] prams =
            {
                new SqlParameter("@billType",SqlDbType.VarChar,50),
                new SqlParameter("@billStartCode",SqlDbType.VarChar,50),
                new SqlParameter("@billEndCode",SqlDbType.VarChar,50),
                new SqlParameter("@receiveBillPerson",SqlDbType.VarChar,50),
                new SqlParameter("@acceptStation",SqlDbType.VarChar,50),
                new SqlParameter("@receiveBillTime",SqlDbType.DateTime,40),
                new SqlParameter("@releasePerson",SqlDbType.VarChar,50)
            };
            prams[0].Value = billDispense.BillType;
            prams[1].Value = billDispense.BillStartCode;
            prams[2].Value = billDispense.BillEndCode;
            prams[3].Value = billDispense.ReceiveBillPerson;
            prams[4].Value = billDispense.AcceptStation;
            prams[5].Value = billDispense.ReceiveBillTime;
            prams[6].Value = billDispense.ReleasePerson;

            return helper.ExecuteNonQuery("uspCreateBillDispense", prams);
        }

        /// <summary>
        /// 修改票据分发信息
		/// </summary>
		/// <param name="billDispense">票据分发实体</param>
		/// <returns>bool</returns>
        
        public bool UpdateBillDispense(BillDispense billDispense)
        {
            SQLHelper helper = new SQLHelper();
            SqlParameter[] prams =
            {
                new SqlParameter("@PKID",SqlDbType.Int,4),
                new SqlParameter("@receiveBillPerson",SqlDbType.VarChar,50),
                new SqlParameter("@acceptionStation",SqlDbType.VarChar,50),
                new SqlParameter("@releasePerson",SqlDbType.VarChar,50)
            };
            prams[0].Value = billDispense.PkId;
            prams[1].Value = billDispense.ReceiveBillPerson;
            prams[2].Value = billDispense.AcceptStation;
            prams[3].Value = billDispense.ReleasePerson;

            return helper.ExecuteNonQuery("uspUpdateBillDispense", prams) == 0? true : false;
        }

        /// <summary>
        /// 删除票据分发信息
		/// </summary>
        /// <param name="pkId">票据ID</param>
		/// <returns>bool</returns>
        
        public bool DeleteBillDispense(int pkId)
        {
            SQLHelper helper = new SQLHelper();
            SqlParameter[] prams =
            {
                new SqlParameter("@pkId",SqlDbType.Int,4)
            };
            prams[0].Value = pkId;
            return helper.ExecuteNonQuery("uspDeleteBillDispense", prams) == 0 ? true : false;
        }

        /// <summary>
        /// 检验票据编号是否存在
        /// </summary>
        /// <param name="billCode"></param>
        /// <param name="billType"></param>
        /// <param name="receiveBillTime"></param>
        /// <returns>bool</returns>
        
        public bool ExistBillDispense(string billCode, string billType, DateTime receiveBillTime)
        {
            SQLHelper helper = new SQLHelper();
            SqlParameter[] prams =
            {
                new SqlParameter("@billCode",SqlDbType.VarChar,50),
                new SqlParameter("@billType",SqlDbType.VarChar,50),
                new SqlParameter("@receiveBillTime",SqlDbType.DateTime,40)
            };

            prams[0].Value = billCode;
            prams[1].Value = billType;
            prams[2].Value = receiveBillTime;

            return helper.ExecuteNonQuery("uspExistBillDispense", prams) == 0 ? true : false;
        }

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
        
        public DataSet GetBillDetails(string billCode, string billType, string billStatus, DateTime beginWriteDate, DateTime endWriteDate, int pageIndex, int pageSize, ref Int64 recordCount)
        {
            SQLHelper helper = new SQLHelper();
            SqlParameter[] prams =
            {
                new SqlParameter("@billCode",SqlDbType.VarChar,50),
                new SqlParameter("@billType",SqlDbType.VarChar,50),
                new SqlParameter("@billStatus",SqlDbType.VarChar,50),
                new SqlParameter("@beginWriteDate",SqlDbType.DateTime,40),
                new SqlParameter("@endWriteDate",SqlDbType.DateTime,40),
                new SqlParameter("@pageIndex",SqlDbType.Int,4),
                new SqlParameter("@pageSize",SqlDbType.Int,4),
                new SqlParameter("@recordCount",SqlDbType.Int,4)
            };
            prams[0].Value = billCode;
            prams[1].Value = billType;
            prams[2].Value = billStatus;
            prams[3].Value = beginWriteDate;
            prams[4].Value = endWriteDate;
            prams[5].Value = pageIndex;
            prams[6].Value = pageSize;
            prams[7].Direction = ParameterDirection.Output;
            DataSet ds = helper.ExecuteDataSet("uspGetBillDetails", prams);
            recordCount = int.Parse(prams[7].Value.ToString());
            return ds;

        }

        /// <summary>
        /// 获取多个员工信息实体
        /// </summary>
        /// <return>DataSet</return>
        
        public DataSet GetBillEmployees()
        {
            SQLHelper helper = new SQLHelper();
            DataSet ds = helper.ExecuteDataSet("uspGetBillEmployees",null);
            return ds;
        }
    }
}
