// ******************************************************************
// 文件名: Light.EXP.Model.Bill.BillDispense.cs
// 作者:       陈宇卿
// 创建日期：  2020-04-08
// 主要内容：  票据管理模块的实体类文件
// ******************************************************************


namespace Light.EXP.Model.Bill
{
    using System;
    public class BillDispense
    {
        private int pkId = 0;                               // 票据ID
        private string billType = "";                       // 票据类型
        private string billStartCode = "";                  // 票据开始号
        private string billEndCode = "";                    // 票据结束号
        private string receiveBillPerson = "";              // 领票人
        private string acceptStation = "";                  // 接货点
        private DateTime receiveBillTime = DateTime.Now;    // 领票时间
        private string releasePerson = "";                  // 分发人


        /// <summary>
        /// 票据ID
        /// </summary>

        public int PkId
        {
            get
            {
                return pkId;
            }

            set
            {
                pkId = value;
            }
        }


        /// <summary>
		/// 票据类型
		/// </summary>
        public string BillType
        {
            get
            {
                return billType;
            }

            set
            {
                billType = value;
            }
        }

        /// <summary>
		/// 票据开始号
		/// </summary>
        public string BillStartCode
        {
            get
            {
                return billStartCode;
            }

            set
            {
                billStartCode = value;
            }
        }


        /// <summary>
		/// 票据结束号
		/// </summary>
        public string BillEndCode
        {
            get
            {
                return billEndCode;
            }

            set
            {
                billEndCode = value;
            }
        }

        /// <summary>
		/// 领票人
		/// </summary>
        public string ReceiveBillPerson
        {
            get
            {
                return receiveBillPerson;
            }

            set
            {
                receiveBillPerson = value;
            }
        }

        /// <summary>
		/// 接货点
		/// </summary>
        public string AcceptStation
        {
            get
            {
                return acceptStation;
            }

            set
            {
                acceptStation = value;
            }
        }

        /// <summary>
		/// 领票时间
		/// </summary>
        public DateTime ReceiveBillTime
        {
            get
            {
                return receiveBillTime;
            }

            set
            {
                receiveBillTime = value;
            }
        }

        /// <summary>
		/// 分发人
		/// </summary>
        public string ReleasePerson
        {
            get
            {
                return releasePerson;
            }

            set
            {
                releasePerson = value;
            }
        }
    }
}
