// ******************************************************************
// �ļ���: Light.EXP.DataAccess.User.UserInterface.cs
// Copyright  (c)  2006-2007 ATA
// ����:       Ҷ����
// �������ڣ�  2007-10-23
// ��Ҫ���ݣ�  �û�����Ľӿ��ļ�
// ******************************************************************

namespace Light.EXP.DataAccess.User
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using Light.EXP.Model.User;

	public interface UserInterface
	{
		/// <summary>
		/// ��ȡ����û�ʵ��
		/// </summary>
		/// <param name="userName">�û�����</param>
		/// <param name="sex">�Ա�</param>
		/// <param name="sortField">�����ֶ�</param>
		/// <param name="sortOrder">�������</param>
        /// <param name="pageIndex">����ȡ��ҳ����</param>
        /// <param name="pageSize">ÿҳ��ʾ�ļ�¼��</param>
        /// <param name="recordCount">�ܼ�¼��</param>
		/// <returns>DataSet</returns>
        DataSet GetUsers(string userName, int sex, string sortField, string sortOrder, int pageIndex, int pageSize, ref Int64 recordCount);

		/// <summary>
		/// ��ȡ�����û�ʵ��
		/// </summary>
        /// <param name="loginId">��¼Id</param>
		/// <returns>Userʵ��</returns>
        Users GetUser(string loginId);
		
		/// <summary>
		/// �����û�
		/// </summary>
		/// <param name="users">�û�ʵ��</param>
		/// <returns>bool</returns>
		bool CreateUser(Users user);
		
		/// <summary>
		/// �޸��û�
		/// </summary>
		/// <param name="users">�û�ʵ��</param>
		/// <returns>bool</returns>
		bool UpdateUser(Users user);

		/// <summary>
		/// ɾ���û�
		/// </summary>
        /// <param name="loginId">��¼Id</param>
		/// <returns>bool</returns>
        bool DeleteUser(string loginId);

        /// <summary>
        /// ����ɾ������û�
        /// </summary>
        /// <param name="loginIds"></param>
        void BatchDeleteUsers(string loginIds);
	}
}
