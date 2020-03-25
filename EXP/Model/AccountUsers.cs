// ******************************************************************
// �ļ���: Light.EXP.Model.User.Users.cs
// Copyright  (c)  2006-2007 ATA
// ����:       Ҷ����
// �������ڣ�  2007-10-17
// ��Ҫ���ݣ�  �û������ʵ�����ļ�
// ******************************************************************

namespace Light.EXP.Model.User
{
    using System;

	public class Users
	{
		private string loginId = "";
        private string userName = "";
		private string password = "";
		private int sex = 0;
		private DateTime birthday = DateTime.Now;
		
		/// <summary>
		/// ��¼ID
		/// </summary>
		public string LoginId
		{
            get 
            {
                return loginId; 
            }
            set 
            {
                loginId = value; 
            }
		}

		/// <summary>
		/// �û�����
		/// </summary>
		public string UserName
		{
			get
            {
                return userName;
            }
			set
            {
                userName = value;
            }
		}

		/// <summary>
		/// ����
		/// </summary>
		public string Password
		{
			get
            {
                return password;
            }
			set
            {
                password = value;
            }
		}

		/// <summary>
		/// �Ա�
		/// </summary>
		public int Sex
		{
			get
            {
                return sex;
            }
			set
            {
                sex = value;
            }
		}

		/// <summary>
		/// ��������
		/// </summary>
		public DateTime Birthday
		{
			get
            {
                return birthday;
            }
			set
            {
                birthday = value;
            }
		}        
	}
}
