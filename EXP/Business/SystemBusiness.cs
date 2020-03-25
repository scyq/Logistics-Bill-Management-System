// ******************************************************************
// �ļ���: Light.EXP.Business.SystemFrame.SystemBusiness.cs
// Copyright  (c)  2006-2007 ATA
// ����:       Ҷ����
// �������ڣ�  2007-11-14
// ��Ҫ���ݣ�  ϵͳ��ܵ�ҵ�������ļ�
// ******************************************************************

namespace Light.EXP.Business.SystemFrame
{
    using System;
    using System.Data;

    using Light.EXP.DataAccess.SystemFrame;

    public class SystemBusiness
    {
        /// <summary>
        /// ��¼��֤
        /// </summary>
        /// <param name="loginId">��¼ID</param>
        /// <param name="passowrd">����</param>
        /// <returns>bool</returns>
        public bool ValidateUser(string loginId, string password)
        {
            SystemInterface isystem = SystemFactory.Create();
            return isystem.ValidateUser(loginId, password);
        }

        /// <summary>
        /// Ȩ�޿���
        /// </summary>
        /// <param name="loginId">��¼ID</param>
        /// <param name="pageName">ҳ������</param>
        /// <returns></returns>
        public bool CheckRight(string loginId, string pageName)
        {
            SystemInterface isystem = SystemFactory.Create();
            return isystem.CheckRight(loginId, pageName);
        }
    }
}
