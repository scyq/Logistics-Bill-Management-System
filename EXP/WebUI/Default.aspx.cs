// ******************************************************************
// �ļ���: Light.EXP.WebUI.SystemFrame.Default.aspx.cs
// Copyright  (c)  2006-2007 ATA
// ����:       Ҷ����
// �������ڣ�  2007-10-23
// ��Ҫ���ݣ�  ϵͳ��ҳ��
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

	public partial class _Default : PageBase
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Response.Redirect("Secure/Login.aspx");
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
		private void InitializeComponent()
		{    
		}
		#endregion
	}
}