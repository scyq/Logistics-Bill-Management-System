// ******************************************************************
// �ļ���: Light.EXP.SystemFrameworks.ApplicationLog.cs
// Copyright  (c)  2006-2007 ATA
// ����:       Ҷ����
// �������ڣ�  2007-10-17
// ��Ҫ���ݣ�  �������������ڼ�¼������־
// ******************************************************************

namespace Light.EXP.SystemFrameworks
{
    using System;
    using System.IO;

	public sealed class ApplicationLog 
	{
        private ApplicationLog() 
        {
        }

		/// <summary>
		/// ��¼��־���ı��ļ�
		/// </summary>
		/// <param name="message">��¼������</param>
		public static void Log(string message) 
		{
			string fileName = System.Web.HttpContext.Current.Server.MapPath(EXPConfiguration.Log);
		
			if(File.Exists(fileName))
			{
				StreamWriter sr = File.AppendText(fileName);
				sr.WriteLine ("\n");
				sr.WriteLine (DateTime.Now.ToString()+message);
				sr.Close();
			}
			else
			{
				StreamWriter sr = File.CreateText(fileName);
				sr.Close();
				Log(message);
			}
		}
	}
}