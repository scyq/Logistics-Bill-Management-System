// ******************************************************************
// �ļ���: Light.EXP.SystemFrame.SystemFramework.Utility.cs
// Copyright  (c)  2006-2007 ATA
// ����:       Ҷ����
// �������ڣ�  2007-10-17
// ��Ҫ���ݣ�  ���ù��ߺ�����
// ******************************************************************

namespace Light.EXP.SystemFrameworks
{
    using System;
    using System.Web.UI;
    using System.Data;
    using System.Web.UI.WebControls;

	public sealed class Utility
    {
        private Utility() 
        {
        }

        /// <summary>
		/// ҳ��JavaScript��Ϣ��ʾ
		/// </summary>
		/// <param name="page">ҳ����</param>
		/// <param name="message">��ʾ��Ϣ</param>
		public static void AlertMsg(Page page, string message)
		{
			page.RegisterStartupScript("AlertMsg","<script  Language='Javascript'>alert('" + message + "');</script>");
		}

        /// <summary>
        /// �������ַ���ת��Ϊ����
        /// </summary>
        /// <param name="args">�����ַ���</param>
        /// <returns>Int</returns>
        public static int ToInt(string args)
        {
            if (args.Trim().Length == 0)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(args);                
            }
        }

        /// <summary>
        /// �������ַ���ת��ΪС��
        /// </summary>
        /// <param name="args">�����ַ���</param>
        /// <returns>Decimal</returns>
        public static decimal ToDecimal(string args)
        {
            if (args.Trim().Length == 0)
            {
                return 0;
            }
            else
            {
                return Convert.ToDecimal(args);
            }
        }

        /// <summary>
        /// �������ַ���ת��Ϊ�����ȸ�������
        /// </summary>
        /// <param name="args">�����ַ���</param>
        /// <returns>Double</returns>
        public static Single ToSingle(string args)
        {
            if (args.Trim().Length == 0)
            {
                return 0;
            }
            else
            {
                return Convert.ToSingle(args);
            }
        }

        /// <summary>
        /// �������ַ���ת��Ϊ˫���ȸ�������
        /// </summary>
        /// <param name="args">�����ַ���</param>
        /// <returns>Double</returns>
        public static double ToDouble(string args)
        {
            if (args.Trim().Length == 0)
            {
                return 0;
            }
            else
            {
                return Convert.ToDouble(args);            
            }
        }

        /// <summary>
        /// �������ַ���ת��Ϊ����
        /// </summary>
        /// <param name="args">�����ַ���</param>
        /// <returns>DateTime</returns>
        public static DateTime ToDateTime(string args)
        {
            if (args.Trim().Length == 0)
            {
                return DateTime.MinValue;
            }
            else
            {
                return Convert.ToDateTime(args);
            }
        }

        /// <summary>
        /// ������������
        /// </summary>
        /// <param name="inputDateTime">��������</param>
        /// <returns>object</returns>
        public static object ParseDateTime(DateTime inputDateTime)
        {
            if (inputDateTime == DateTime.MinValue)
            {
                return System.DBNull.Value;
            }
            else
            {
                return inputDateTime;
            }
        }
    }	 
}
