using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IMSUI
{
    public partial class News : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    UserLogin.Text = Session["Name"].ToString();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Page:" + ex.Message);
                }
            }
            SessionBind();
        }

        private void SessionBind()
        {
            if (Session["Name"] == null && Session["Pwd"] == null && Session["UsersId"] == null)
            {
                Response.Write("<script>alert('你还没登录或登录超时!');top.location.href='LoginUI.aspx';</script>");
                //Response.Redirect("LoginUI.aspx");
            }
        }
    }
}