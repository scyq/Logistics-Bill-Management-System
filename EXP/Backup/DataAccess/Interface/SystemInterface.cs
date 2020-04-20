// ******************************************************************
// �ļ���: Light.EXP.DataAccess.SystemFrame.SystemInterface.cs
// Copyright  (c)  2006-2007 ATA
// ����:       Ҷ����
// �������ڣ�  2007-11-14
// ��Ҫ���ݣ�  ϵͳ��ܵĽӿ��ļ�
// ******************************************************************

namespace Light.EXP.DataAccess.SystemFrame
{
    public interface SystemInterface
    {
        /// <summary>
        /// ��¼��֤
        /// </summary>
        /// <param name="loginId">��¼ID</param>
        /// <param name="passowrd">����</param>
        /// <returns>bool</returns>
        bool ValidateUser(string loginId, string password);

        /// <summary>
        /// Ȩ�޿���
        /// </summary>
        /// <param name="loginId">��¼ID</param>
        /// <param name="pageName">ҳ������</param>
        /// <returns></returns>
        bool CheckRight(string loginId, string pageName);
    }
}
