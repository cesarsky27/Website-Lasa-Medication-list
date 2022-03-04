using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Net;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using System.Net.NetworkInformation;
using Newtonsoft.Json;
using System.Drawing;
using System.DirectoryServices.Protocols;
using Newtonsoft.Json.Linq;

using Siloam.Ui.LasaMedication.App_Code.Controller;
using Siloam.Ui.LasaMedication.App_Code.Models;
using Siloam.Ui.LasaMedication.Pages.Common;

//using Siloam.Ui.LasaMedication.App_Code.Common;




    public partial class Pages_Login : System.Web.UI.Page
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt_login = (DataTable)Session[Helper.Session_DataLogin];

            if (dt_login != null)
            {
                Response.Redirect("~/Pages/dashboard.aspx", false);
            }

        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            string usernameLogin = username.Text.ToString().Replace('\\', '+');
            string passwordLogin = password.Text.ToString();

            List<ViewLoginUser> ListLoginData = new List<ViewLoginUser>();

            var GetLogin = clsLoginUser.GetLogin(usernameLogin, passwordLogin);
            var GetDataLogin = JsonConvert.DeserializeObject<Result_login_user>(GetLogin.Result.ToString());

            ListLoginData = GetDataLogin.list;
            var Result = ListLoginData[0];
            if (Result.code == 200)
            {
                DataTable dt_login = Helper.ToDataTable(ListLoginData);
                Session[Helper.Session_DataLogin] = dt_login;
                Response.Redirect("dashboard.aspx", false);
            }

            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alertpassexpired", "alert('" + Result.Message + "');", true);
            }
        }

    }


//Cara-2 Gagal
//private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

//protected global::System.Web.UI.HtmlControls.HtmlForm formLogin;

//protected global::System.Web.UI.ScriptManager ScriptManager1;

//protected global::System.Web.UI.UpdateProgress uProgLogin;

//protected global::System.Web.UI.UpdatePanel upError;

//protected global::System.Web.UI.WebControls.Image ImageLogin;

//protected global::System.Web.UI.WebControls.TextBox txtUsername;

//protected global::System.Web.UI.WebControls.TextBox txtPassword;


//protected global::System.Web.UI.HtmlControls.HtmlGenericControl pError;


//protected global::System.Web.UI.WebControls.CheckBox CheckBoxLoginAD;

//protected global::System.Web.UI.WebControls.Button btnSignIn;


//protected global::System.Web.UI.WebControls.ImageButton ImageButtonSignIn;

//protected global::System.Web.UI.WebControls.Button ButtonRedirect;

//protected global::System.Web.UI.UpdatePanel UpdatePanelForgot;


//protected global::System.Web.UI.WebControls.TextBox ForgotUsername;

//protected global::System.Web.UI.WebControls.TextBox ForgotEmail;

//protected global::System.Web.UI.UpdateProgress uProgForgot;


//protected global::System.Web.UI.UpdatePanel UpdatePanelNotif;

//protected global::System.Web.UI.HtmlControls.HtmlGenericControl p_Forgot;


//protected global::System.Web.UI.WebControls.Button Forgot_ButtonSubmit;

//protected global::System.Web.UI.WebControls.Label LabelChangePassTitle;


//protected global::System.Web.UI.HtmlControls.HtmlIframe iframechangepass;
//protected void Page_Load(object sender, EventArgs e)
//{
//    log4net.ThreadContext.Properties["Organization"] = MyUser.GetOrgId();

//    if (!IsPostBack)
//    {
//        if (Request.QueryString["action"] != null)
//        {
//            if (Request.QueryString["action"] == "clear")
//            {
//                Session.Abandon();
//            }
//        }

//        var registryflag = ConfigurationManager.AppSettings["registryflag"].ToString();

//        if (registryflag == "1")
//        {
//            ConfigurationManager.AppSettings["URLUserManagement"] = SiloamConfig.Functions.GetValue("urlUserManagement").ToString();
//        }
//    }
//}
//protected void btnSignIn_Click(object sender, EventArgs e)
//{
//    string StartTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
//    string Pesan = "";
//    var finish = 0;
//    try
//    {
//        btnSignIn.Enabled = false;
//        string usernameLogin = txtUsername.Text.ToString().Replace('\\', '+');
//        string passwordLogin = txtPassword.Text.ToString();

//        //pengecekan pada username AD
//        if (usernameLogin.Contains("+") == true)
//        {
//            var cekUserType = usernameLogin.Split('+');
//            if (cekUserType[0].Length >= 12)
//            {
//                passwordLogin = "12345678";
//            }

//            //login with AD manually
//            try
//            {
//                var UsernameData = usernameLogin.Split('+');
//                LdapConnection connection = new LdapConnection(UsernameData[0].ToString());
//                NetworkCredential credential = new NetworkCredential(UsernameData[1].ToString(), txtPassword.Text.ToString());
//                connection.Credential = credential;
//                connection.Bind();
//            }
//            catch (LdapException lexc)
//            {
//                string error = lexc.ServerErrorMessage;
//                pError.InnerText = "Login AD Fail! " + error;
//                pError.Attributes.Remove("style");
//                pError.Attributes.Add("style", "display:block; color:red;");
//                goto FINISHH;
//            }
//            catch (Exception exc)
//            {
//                pError.InnerText = "Login AD Fail! " + exc.ToString();
//                pError.Attributes.Remove("style");
//                pError.Attributes.Add("style", "display:block; color:red;");
//                goto FINISHH;
//            }
//        }

//        List<ViewLoginUser> ListLoginData = new List<ViewLoginUser>();
//        var GetLogin = clsLoginUser.GetLogin(usernameLogin, passwordLogin);
//        var GetDataLogin = JsonConvert.DeserializeObject<Result_login_user>(GetLogin.Result.ToString());

//        ListLoginData = GetDataLogin.list;

//        if (ListLoginData.Count() > 0)
//        {
//            if (txtPassword.Text == "12345678" && !usernameLogin.Contains("+"))
//            {
//                if (true)
//                {
//                    LabelChangePassTitle.Text = "Silakan Ganti Password Default Anda.";
//                    string localIP = Helper.GetLocalIPAddress();
//                    //string localIP = "10.85.138.25"; //hardcode GTN

//                    var registryflag = ConfigurationManager.AppSettings["registryflag"].ToString();

//                    if (registryflag == "0")
//                    {
//                        iframechangepass.Src = "http://" + localIP + "/UserManagement/Pages/Viewer/UpdatePassword.aspx?Username=" + txtUsername.Text;
//                    }
//                    else if (registryflag == "1")
//                    {
//                        iframechangepass.Src = "http://" + localIP + "/viewer/Form/FormViewer/FormChangePassword?Username=" + txtUsername.Text;
//                    }

//                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalChangePass", "$('#modalChangePass').modal({backdrop: 'static', keyboard: false});", true);
//                    goto FINISHH;
//                }
//            }

//            int flagexp = 0;
//            var ResponseLogin = (JObject)JsonConvert.DeserializeObject<dynamic>(GetLogin.Result);
//            Pesan = ResponseLogin.Property("message").Value.ToString();
//            if (Pesan.Contains("Password expired"))
//            {
//                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alertpassexpired", "alert('" + Pesan + "');", true);
//            }

//            DataTable dt_login = Helper.ToDataTable(ListLoginData);
//            Session[Helper.Session_DataLogin] = dt_login;

//            if (flagexp == 1)
//            {
//                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "redirect", "redirectlogin();", true);
//            }
//            else
//            {
//                Response.Redirect("~/Pages/Home_logon_page.aspx", false);
//            }
//        }
//        else
//        {
//            var Response = (JObject)JsonConvert.DeserializeObject<dynamic>(GetLogin.Result);
//            var Status = Response.Property("status").Value.ToString();
//            var Message = Response.Property("message").Value.ToString();

//            pError.InnerText = Status + "! " + Message;
//            pError.Attributes.Remove("style");
//            pError.Attributes.Add("style", "display:block; color:red;");
//            txtUsername.BorderColor = Color.Red;
//            txtPassword.BorderColor = Color.Red;

//            if (Message.Contains("expired"))
//            {
//                LabelChangePassTitle.Text = "Password Expired! Please update your password.";
//                string localIP = Helper.GetLocalIPAddress();
//                //string localIP = "10.85.138.25"; //hardcode GTN
//                var registryflag = ConfigurationManager.AppSettings["registryflag"].ToString();

//                if (registryflag == "0")
//                {
//                    iframechangepass.Src = "http://" + localIP + "/UserManagement/Pages/Viewer/UpdatePassword.aspx?Username=" + txtUsername.Text;
//                }
//                else if (registryflag == "1")
//                {
//                    iframechangepass.Src = "http://" + localIP + "/viewer/Form/FormViewer/FormChangePassword?Username=" + txtUsername.Text;
//                }

//                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalChangePass", "$('#modalChangePass').modal({backdrop: 'static', keyboard: false}); toastr.warning('Password is Expired!', 'Warning');", true);
//            }
//        }

//        btnSignIn.Enabled = true;
//        Log.Debug(LogLibrary.SaveLog(MyUser.GetOrgId(), "username", txtUsername.Text.ToString().Replace('\\', '+'), "btnSignIn_Click", StartTime, "OK", txtUsername.Text.ToString().Replace('\\', '+'), "", "", ""));
//    }
//    catch (Exception exx)
//    {
//        string Status = "Fail";
//        pError.InnerText = Status + "! " + exx.Message;
//        pError.Attributes.Remove("style");
//        pError.Attributes.Add("style", "display:block; color:red;");
//        txtUsername.BorderColor = Color.Red;
//        txtPassword.BorderColor = Color.Red;

//        btnSignIn.Enabled = true;
//        Log.Error(LogLibrary.SaveLog(MyUser.GetOrgId(), "username", txtUsername.Text.ToString().Replace('\\', '+'), "btnSignIn_Click", StartTime, "ERROR", txtUsername.Text.ToString().Replace('\\', '+'), "", "", exx.Message));
//    }

//FINISHH:
//    btnSignIn.Enabled = true;
//    finish = 1;
//}

////fungsi inisialisasi username AD secara otomatis saat checkbox dicentang
//protected void CheckBoxLoginAD_CheckedChanged(object sender, EventArgs e)
//{
//    if (CheckBoxLoginAD.Checked)
//    {
//        txtUsername.Text = HttpContext.Current.User.Identity.Name.ToString();
//        txtPassword.Enabled = false;
//        txtUsername.Enabled = false;
//    }
//    else
//    {
//        txtUsername.Text = "";
//        txtPassword.Enabled = true;
//        txtUsername.Enabled = true;
//    }
//}