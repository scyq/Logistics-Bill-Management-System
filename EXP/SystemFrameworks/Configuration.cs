// ******************************************************************
// �ļ���: Light.EXP.SystemFrameworks.Configuration.cs
// Copyright  (c)  2006-2007 ATA
// ����:       Ҷ����
// �������ڣ�  2007-10-29
// ��Ҫ���ݣ�  ��ȡweb.config�ļ���������Ϣ
// ******************************************************************

namespace Light.EXP.SystemFrameworks
{
    using System.Configuration;

	public sealed class EXPConfiguration
	{
        private EXPConfiguration() 
        { 
        }

		/// <summary>
		/// ���ݿ������ַ���
		/// </summary>
		public static string ConnectionString
		{
			get
			{
				return ConfigurationSettings.AppSettings["ConnectionString"];
			}
		}

		/// <summary>
		/// ��־�ļ����λ��
		/// </summary>
		public static string Log
		{
			get
			{
				return ConfigurationSettings.AppSettings["Log"];
			}
		}

        /// <summary>
        /// ���ݷ��ʲ����ƿռ�
        /// </summary>
        public static string DataAccess
        {
            get
            {
                return ConfigurationSettings.AppSettings["DataAccess"];
            }
        }
	}
}
