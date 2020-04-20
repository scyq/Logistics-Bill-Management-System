// ******************************************************************
// �ļ���: Light.EXP.Business.User.UserBusiness.cs
// Copyright  (c)  2006-2007 ATA
// ����:       Ҷ����
// �������ڣ�  2007-10-24
// ��Ҫ���ݣ�  �û������ҵ�������ļ�
// ******************************************************************

namespace Light.EXP.Business.User
{
    using System;
    using System.Data;

    using Light.EXP.DataAccess.User;
    using Light.EXP.Model.User;

	public class UserBusiness
	{
		/// <summary>
		/// ��ȡ����û�ʵ��, �����û���Ϣ��ѯҳ��DataList�����ݰ�
		/// </summary>
		/// <param name="userName">�û�����</param>
		/// <param name="sex">�Ա�</param>
		/// <param name="sortField">�����ֶ�</param>
		/// <param name="sortOrder">�������</param>
        /// <param name="pageIndex">����ȡ��ҳ����</param>
        /// <param name="pageSize">ÿҳ��ʾ�ļ�¼��</param>
        /// <param name="recordCount">�ܼ�¼��</param>
		/// <returns>DataSet</returns>
		public DataSet GetUsers(string userName, int sex, string sortField, string sortOrder, int pageIndex, int pageSize, ref Int64 recordCount)
		{
            UserInterface iuser = UserFactory.Create();
            return iuser.GetUsers(userName, sex, sortField, sortOrder, pageIndex, pageSize, ref recordCount);
		}

		/// <summary>
		/// ��ȡ�����û�ʵ��, �����û���Ϣ�༭��鿴ҳ��������ݰ�
		/// </summary>
        /// <param name="loginId">��¼Id</param>
		/// <returns>Userʵ��</returns>
        public Users GetUser(string loginId)
		{
            UserInterface iuser = UserFactory.Create();
            return iuser.GetUser(loginId);
		}
		
		/// <summary>
		/// �����û�, �����û���Ϣ����ҳ����Ӱ�ť�ĵ����¼�����
		/// </summary>
		/// <param name="users">�û�ʵ��</param>
		/// <returns>bool</returns>
		public bool CreateUser(Users user)
		{
            UserInterface iuser = UserFactory.Create();
			return iuser.CreateUser(user);
		}
		
		/// <summary>
		/// �޸��û�, �����û���Ϣ�༭ҳ���޸İ�ť�ĵ����¼�����
		/// </summary>
		/// <param name="users">�û�ʵ��</param>
		/// <returns>bool</returns>
		public bool UpdateUser(Users user)
		{
            UserInterface iuser = UserFactory.Create();
			return iuser.UpdateUser(user);			
		}

		/// <summary>
        /// ɾ���û�, �����û���Ϣ�༭ҳ��ɾ����ť�ĵ����¼�����
		/// </summary>
        /// <param name="loginId">��¼Id</param>
		/// <returns>bool</returns>
        public bool DeleteUser(string loginId)
		{
            UserInterface iuser = UserFactory.Create();
            return iuser.DeleteUser(loginId);					
		}

        /// <summary>
        /// ����ɾ������û�, �����û���Ϣ��ѯҳ������ɾ����ť�ĵ����¼�����
        /// </summary>
        /// <param name="logOnIds"></param>
        public void BatchDeleteUsers(string logOnIds)
        {
            UserInterface iuser = UserFactory.Create();
            iuser.BatchDeleteUsers(logOnIds);	
        }
	}
}
