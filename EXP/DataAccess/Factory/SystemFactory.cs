// ******************************************************************
// �ļ���: Light.EXP.DataAccess.SystemFrame.SystemFactory.cs
// Copyright  (c)  2006-2007 ATA
// ����:       Ҷ����
// �������ڣ�  2007-11-14
// ��Ҫ���ݣ�  ϵͳ��ܵĹ������ļ�
// ******************************************************************

namespace Light.EXP.DataAccess.SystemFrame
{
    using System.Reflection;
    using Light.EXP.SystemFrameworks;

    public sealed class SystemFactory
    {
        private SystemFactory()
        {
        }

        /// <summary>
        /// SystemInterface�Ľӿڴ���
        /// </summary>
        /// <returns>SystemInterface</returns>
        public static SystemInterface Create()
        {
            string path = EXPConfiguration.DataAccess;
            string className = path + ".SystemFrame.SystemSQLHandle";
            return (SystemInterface)Assembly.Load(path).CreateInstance(className);
        }
    }
}
