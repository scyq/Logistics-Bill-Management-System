// ******************************************************************
// �ļ���: Light.EXP.WebUI.User.UserUpdate.aspx.cs
// Copyright  (c)  2006-2007 ATA
// ����:       Ҷ����
// �������ڣ�  2007-10-19
// ��Ҫ���ݣ�  �û��޸ģ�ɾ��
// ******************************************************************

namespace Light.EXP.WebUI.User
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
    using System.Data.SqlClient;

    using Light.EXP.Business.User;
    using Light.EXP.Model.User;
    using Light.EXP.SystemFrameworks;
    using Light.EXP.WebUI.SystemFrame;

	public partial class UserUpdate : PageBase
	{	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!this.IsPostBack)
			{					
				// ��ȡ��UserListҳ���ݵı���ֵ
				string LoginID = Request.QueryString["LoginID"];

				// �����û����������
				UserBusiness userBusiness = new UserBusiness();

				// ���ݵ�¼ID��ȡ�û�ʵ��
				Users user = new Users();
				user = userBusiness.GetUser(LoginID);

				// ��ȡ�õ��û�DataTable����
				this.txtbUserID.Text = user.LoginId;
				this.txtbUserName.Text = user.UserName;
				this.rdblSex.SelectedValue = user.Sex.ToString();
				if (user.Birthday.ToShortDateString() != "1900-1-1")
					this.txtbBirthday.Text = user.Birthday.ToShortDateString();
				else
					this.txtbBirthday.Text = string.Empty;

				// ����ɾ��ȷ����ʾ
				this.imgbDelete.Attributes.Add("onclick", "javascript:return confirm('��ȷʵҪɾ���ü�¼��'); ");
			}
		}

		/// <summary>
		/// �޸İ�ť
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void imgbUpdate_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if (! this.ValidateForm())
				return; 

			// �����û�ʵ�������
			Users user = new Users();
			
			// Ϊ�û�ʵ�������ĸ������Ը�ֵ
			user.LoginId = this.txtbUserID.Text;
			user.UserName = this.txtbUserName.Text;
			user.Sex = int.Parse(this.rdblSex.SelectedValue);
			if (this.txtbBirthday.Text.Length != 0)
				user.Birthday = Convert.ToDateTime(this.txtbBirthday.Text);
			else
				user.Birthday = Convert.ToDateTime("1900-1-1");
			
			// �����û����������
			UserBusiness userBusiness = new UserBusiness();

			if (userBusiness.UpdateUser(user)) 
			{
				Response.Redirect("UserList.aspx");
			}// �޸Ĳ����ɹ�
			else 
			{
				Utility.AlertMsg(this, "�޸��û�ʧ�ܣ�");
			}// �޸Ĳ���ʧ��
		}

		/// <summary>
		/// ɾ����ť
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void imgbDelete_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			// �����û����������
			UserBusiness userBusiness = new UserBusiness();
			
			if (userBusiness.DeleteUser(this.txtbUserID.Text)) 
			{
				Response.Redirect("UserList.aspx");
			}// ɾ�������ɹ�
			else 
			{
				Utility.AlertMsg(this, "ɾ���û�ʧ�ܣ�");
			}// ɾ������ʧ��
		}

		/// <summary>
		/// ȡ����ť
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void imgbCancel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("UserList.aspx");
		}

		/// <summary>
		/// ����֤
		/// </summary>
		/// <returns>bool(true: ͨ�� false: ��ͨ��)</returns>
		private bool ValidateForm()
		{
			if (this.txtbUserID.Text.Length == 0)
			{
				Utility.AlertMsg(this, "�������û�ID��");
				return false;
			}
			if (this.txtbUserName.Text.Length == 0)
			{
				Utility.AlertMsg(this, "�������û����ƣ�");
				return false;
			}
			return true;
		}

		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.imgbUpdate.Click += new System.Web.UI.ImageClickEventHandler(this.imgbUpdate_Click);
			this.imgbDelete.Click += new System.Web.UI.ImageClickEventHandler(this.imgbDelete_Click);
			this.imgbCancel.Click += new System.Web.UI.ImageClickEventHandler(this.imgbCancel_Click);

		}
		#endregion
	}
}
