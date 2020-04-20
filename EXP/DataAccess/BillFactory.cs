// ******************************************************************
// 文件名: Light.EXP.DataAccess.Bill.BillFactory.cs
// 作者:       陈宇卿
// 创建日期：  2020-04-18
// 主要内容：  票据管理模块的工厂类文件
// ******************************************************************

namespace Light.EXP.DataAccess.Bill
{
    using System;
    using System.Reflection;
    using Light.EXP.SystemFrameworks;

    public sealed class  BillFactory
    {
        private BillFactory() { }

        /// <summary>
        /// BillInterface的接口创建
		/// </summary>
        /// <returns>BillInterface</returns>
        
        public static BillInterface Create()
        {
            string path = EXPConfiguration.DataAccess;
            string className = path + ".Bill.BillSQLHandle";
            return (BillInterface)Assembly.Load(path).CreateInstance(className);
        }


    }
}
