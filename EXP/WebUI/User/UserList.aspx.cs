// ******************************************************************
// �ļ���: Light.EXP.WebUI.User.UserList.aspx.cs
// Copyright  (c)  2006-2007 ATA
// ����:       Ҷ����
// �������ڣ�  2007-10-19
// ��Ҫ���ݣ�  ��ʾ�û���Ϣ
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

    public partial class UserList : PageBase
    {
        /// <summary>
        /// ҳ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!this.IsPostBack)
            {
                // ��DataList
                this.BindDataList();
                // ����ɾ��ȷ����ʾ
                this.lnkbBatchDelete.Attributes.Add("onclick", "javascript:return confirm('��ȷʵҪɾ����Щ��¼��'); ");
            }
        }

        /// <summary>
        /// ������ť
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbSearch_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            this.BindDataList();
        }

        /// <summary>
        /// ����ɾ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkbBatchDelete_Click(object sender, EventArgs e)
        {
            string loginIDs = string.Empty;
            foreach (DataListItem item in this.dtlUser.Items)
            {
                HtmlInputCheckBox chkbUserID = (HtmlInputCheckBox)item.FindControl("chkbUserID");
                if (chkbUserID.Checked)
                {
                    if (loginIDs == string.Empty)
                        loginIDs = "'" + chkbUserID.Value + "'";
                    else
                        loginIDs = loginIDs + "," + "'" + chkbUserID.Value + "'";
                }
            }
            if (loginIDs.Length != 0)
            {
                loginIDs = "(" + loginIDs + ")";
                UserBusiness userBusiness = new UserBusiness();
                userBusiness.BatchDeleteUsers(loginIDs);
            }
            this.BindDataList();
        }

        #region ������
        /// <summary>
        /// ÿҳ��ʾ5����¼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbFive_Click(object sender, ImageClickEventArgs e)
        {
            ViewState["pageSize"] = 5;
            this.BindDataList();
        }

        /// <summary>
        /// ÿҳ��ʾ10����¼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbTen_Click(object sender, ImageClickEventArgs e)
        {
            ViewState["pageSize"] = 10;
            this.BindDataList();
        }

        /// <summary>
        /// ÿҳ��ʾ15����¼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbFifteen_Click(object sender, ImageClickEventArgs e)
        {
            ViewState["pageSize"] = 15;
            this.BindDataList();
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbUp_Click(object sender, ImageClickEventArgs e)
        {
            ViewState["sortField"] = this.drdlSortField.SelectedValue;
            ViewState["sortOrder"] = "ASC";
            this.BindDataList();
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbDown_Click(object sender, ImageClickEventArgs e)
        {
            ViewState["sortField"] = this.drdlSortField.SelectedValue;
            ViewState["sortOrder"] = "DESC";
            this.BindDataList();
        }

        /// <summary>
        /// ȫѡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbAllSelect_Click(object sender, ImageClickEventArgs e)
        {
            foreach (DataListItem item in this.dtlUser.Items)
            {
                HtmlInputCheckBox chkbUserID = (HtmlInputCheckBox)item.FindControl("chkbUserID");
                chkbUserID.Checked = true;
            }
        }

        /// <summary>
        /// ȡ��ȫѡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbCancelSelect_Click(object sender, ImageClickEventArgs e)
        {
            foreach (DataListItem item in this.dtlUser.Items)
            {
                HtmlInputCheckBox chkbUserID = (HtmlInputCheckBox)item.FindControl("chkbUserID");
                chkbUserID.Checked = false;
            }
        }
        #endregion

        /// <summary>
        /// ÿ����Ҫ��ҳ��ѯ��ҳ�涼��Ҫʵ�ִ˷���
        /// �˷���Ϊ��ҳ�ؼ��ṩ��ҳ���ݵĶ�ȡ��
        /// </summary>
        /// <param name="pageIndex">��ǰҪ��ȡ��ҳ, �ӣ���ʼ</param>
        /// <param name="recordCount">�ܵ���������(����ҳʱ)</param>
        /// <returns>һҳ����</returns>
        private DataSet GetPagerData(int pageIndex, ref Int64 recordCount)
        {
            string userName = txtbUserName.Text;
            int sex = int.Parse(this.drdlSex.SelectedValue);
            string sortField = "LoginId";
            string sortOrder = "ASC";
            if (ViewState["sortField"] != null)
                sortField = ViewState["sortField"].ToString();
            if (ViewState["sortOrder"] != null)
                sortOrder = ViewState["sortOrder"].ToString();

            // ��ȡ����Դ
            UserBusiness userBusiness = new UserBusiness();
            int pageSize = 10;
            if (ViewState["pageSize"] != null)
                pageSize = int.Parse(ViewState["pageSize"].ToString());
            DataSet dsUser = userBusiness.GetUsers(userName, sex, sortField, sortOrder, pageIndex, pageSize, ref recordCount);
            return dsUser;
        }

        /// <summary>
        /// ��DataList
        /// </summary>
        private void BindDataList()
        {
            int pageSize = 10;
            if (ViewState["pageSize"] != null)
                pageSize = int.Parse(ViewState["pageSize"].ToString());
            this.dtpUser.BindDataPage(this.GetPagerData, pageSize);
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
        private void InitializeComponent(){}
        #endregion
    }
}
