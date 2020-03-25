// ******************************************************************
// �ļ���: Light.EXP.WebUI.SystemFrame.PageBase
// Copyright  (c)  2006-2007 ATA
// ����:       Ҷ����
// �������ڣ�  2007-10-23
// ��Ҫ���ݣ�  ����Webҳ��Ļ���
// ******************************************************************

namespace Light.EXP.WebUI.SystemFrame
{
    using System;
    using System.Web;
    using System.Web.UI;
    using System.ComponentModel;
    using System.Data;

    using Light.EXP.SystemFrameworks;
    using Light.EXP.Business.SystemFrame;
    
    public class PageBase : System.Web.UI.Page
    {
		/// <summary>
		/// ��ʼ·��
		/// </summary>
		private static String pageUrlBase;

		/// <summary>
		/// URLǰ׺
		/// </summary>
		private static String urlSuffix;

		/// <summary>
		/// ���캯��
		/// </summary>
		public PageBase ()
		{
			try
			{
				urlSuffix =  Context.Request.Url.Host;

				if(Context.Request.Url.Port != 80)
				{
					urlSuffix += ":" + Context.Request.Url.Port.ToString();
				}
				urlSuffix += Context.Request.ApplicationPath;

				pageUrlBase = @"http://" + urlSuffix + "/Secure/Login.aspx";
			}
			catch{}
		}
		
		/// <summary>
		/// �쳣����
		/// </summary>
		/// <param name="e"></param>
        protected override void OnError(EventArgs e) 
        {
			// ��ȡ�쳣
			Exception ex = Server.GetLastError();

			// д������־�ļ�
			ApplicationLog.Log(ex.Message);

			// ת�������Ϣҳ��
            Context.Session["SystemError"] = ex.Message;
            Context.Response.Redirect(@"http://" + urlSuffix + "/ErrorPage.aspx");

            Server.ClearError();
        }

		/// <summary>
		/// ��֤�Ƿ��½���Ƿ��д�ҳ�����Ȩ��
		/// </summary>
		protected void CheckAuthority()
		{
			//
			//����û��Ƿ��½
			//
            if (Context.Session["LoginID"] == null)
			{
                Context.Session["SystemError"] = "����û�е�½���ߵ�½�Ѿ���ʱ��";
                Context.Response.Redirect(@"http://" + urlSuffix + "/ErrorPage.aspx");
			}

            //
            //����û��Ƿ���Է��ʴ�ҳ��
            //
            if (!this.IsPostBack)
            {
                string pageName = Context.Request.FilePath.Substring(Request.FilePath.LastIndexOf("/") + 1, Request.FilePath.LastIndexOf(".") - Request.FilePath.LastIndexOf("/") - 1);
                string loginID = Context.Session["LoginID"].ToString();
                SystemBusiness systemBusiness = new SystemBusiness();
                if (!systemBusiness.CheckRight(loginID, pageName))
                {
                    Context.Session["SystemError"] = "��û��Ȩ�޷��ʴ�ҳ�棡";
                    Context.Response.Redirect(@"http://" + urlSuffix + "/ErrorPage.aspx");
                }
            }
		}
    }
    
}
