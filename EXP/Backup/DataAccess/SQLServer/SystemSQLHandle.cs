// ******************************************************************
// �ļ���: Light.EXP.DataAccess.SystemFrame.SystemSQLHandle.cs
// Copyright  (c)  2006-2007 ATA
// ����:       Ҷ����
// �������ڣ�  2007-11-14
// ��Ҫ���ݣ�  ϵͳ��ܵ����ݷ������ļ�
// ******************************************************************

namespace Light.EXP.DataAccess.SystemFrame
{
    using System.Data;
    using System.Data.SqlClient;

    public class SystemSQLHandle : SystemInterface
    {
        /// <summary>
        /// ��¼��֤
        /// </summary>
        /// <param name="loginId">��¼ID</param>
        /// <param name="passowrd">����</param>
        /// <returns>bool</returns>
        public bool ValidateUser(string loginId, string password)
        {
            SQLHelper helper = new SQLHelper();
            SqlParameter[] prams = {
										new SqlParameter("@loginID", SqlDbType.NVarChar, 20),
										new SqlParameter("@password", SqlDbType.NVarChar, 40)
								   };
            prams[0].Value = loginId;
            prams[1].Value = password;
            return helper.ExecuteNonQuery("uspValidateUser", prams) == 1 ? true : false;
        }

        /// <summary>
        /// Ȩ�޿���
        /// </summary>
        /// <param name="loginId">��¼ID</param>
        /// <param name="pageName">ҳ������</param>
        /// <returns></returns>
        public bool CheckRight(string loginId, string pageName)
        {
            SQLHelper helper = new SQLHelper();
            SqlParameter[] prams = {
										new SqlParameter("@loginID", SqlDbType.NVarChar, 20),
										new SqlParameter("@pageName", SqlDbType.NVarChar, 40)
								   };
            prams[0].Value = loginId;
            prams[1].Value = pageName;
            return helper.ExecuteNonQuery("uspCheckRight", prams) == 1 ? true : false;
        }
    }
}
