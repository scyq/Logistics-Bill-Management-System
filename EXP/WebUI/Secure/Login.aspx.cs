// ******************************************************************
// �ļ���: Light.EXP.WebUI.SystemFrame.Login
// Copyright  (c)  2006-2007 ATA
// ����:       Ҷ����
// �������ڣ�  2007-10-17
// ��Ҫ���ݣ�  �û���¼ҳ��
// ******************************************************************

namespace Light.EXP.WebUI.SystemFrame
{
	using System;
	using System.Collections;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.SessionState;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Web.Security;

	public partial class Login : System.Web.UI.Page
	{
	    protected void Page_Load(object sender, System.EventArgs e)
		{
            if (!IsPostBack)
            {
                //�Ƴ������֤
                FormsAuthentication.SignOut();
                //�����Ự״̬�е�����ֵ
                HttpContext.Current.Session.Clear();
                //ȡ����ǰ�Ự
                HttpContext.Current.Session.Abandon();
            }
		}

        protected void lgnUserLogin_LoggedIn(object sender, EventArgs e)
        {
            Session["LoginID"] = this.lgnUserLogin.UserName;
        }

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent(){}
		#endregion
    }
}
