// ******************************************************************
// �ļ���: Light.EXP.DataAccess.User.UserFactory.cs
// Copyright  (c)  2006-2007 ATA
// ����:       Ҷ����
// �������ڣ�  2007-10-23
// ��Ҫ���ݣ�  �û�����Ĺ������ļ�
// ******************************************************************

namespace Light.EXP.DataAccess.User
{
    using System;
    using System.Reflection;

    using Light.EXP.SystemFrameworks;

	public sealed class UserFactory
	{
        private UserFactory() {}

		/// <summary>
        /// UserInterface�Ľӿڴ���
		/// </summary>
        /// <returns>UserInterface</returns>
		public static UserInterface Create()
		{	
			string path = EXPConfiguration.DataAccess;
			string className = path + ".User.UserSQLHandle";
            return (UserInterface)Assembly.Load(path).CreateInstance(className);
		}
	}
}
