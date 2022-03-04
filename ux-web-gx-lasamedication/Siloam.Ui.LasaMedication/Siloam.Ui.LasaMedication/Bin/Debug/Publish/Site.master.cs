using Siloam.Ui.LasaMedication.Pages.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //log4net.ThreadContext.Properties["Organization"] = MyUser.GetOrgId();

        if (!IsPostBack)
        {
            //data didapat dari form login
            DataTable dt_login = (DataTable)Session[Helper.Session_DataLogin];

            if (dt_login != null)
            {
                lblUsername.Text = dt_login.Rows[0]["fullName"].ToString();
                //HideMenu();
                //ShowMenuLogin(Guid.Parse(dt_login.Rows[0]["user_id"].ToString()), Guid.Parse(dt_login.Rows[0]["role_id"].ToString()), Int64.Parse(dt_login.Rows[0]["organization_id"].ToString()));
            }
            else
            {
                Response.Redirect("~/Pages/Login.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            //getDataOrganizationTicket();

            //if (HF_flagnotif.Value == "off")
            //{
            //    divNotif.Visible = false;
            //}
        }
    }

    protected void LinkButtonLogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Login.aspx", false);
        Context.ApplicationInstance.CompleteRequest();
    }

    protected void Test(object sender, EventArgs e)
    {
        lblUsername.Text = "Test Aja";
    }
}