using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Data.SqlClient;
using System.Configuration;

namespace IMSUI
{
    public class Global : System.Web.HttpApplication
    {
        string sqlconstr = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;

        protected void Application_Start(object sender, EventArgs e)
        {
            //SqlConnection sqlcon = new SqlConnection(sqlconstr);
            //sqlcon.Open();
            //string sql = "select * from Counts_Admin";
            //SqlCommand sqlcmd = new SqlCommand(sql, sqlcon);
            //int count = Convert.ToInt32(sqlcmd.ExecuteScalar());
            Application.Lock();
            //Application["TotalCount"] = count;
            Application["TotalCount"] = 0;
            Application["Content"] = "";
            Application["CurrentUserCount"] = 0;
            Application.UnLock();
            //sqlcon.Close();
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //if (Session["Name"].ToString()!="admin")
            //{
                Application.Lock();
                Application["TotalCount"] = (int)Application["TotalCount"] + 1;
                //Application["CurrentUserCount"] = (int)Application["CurrentUserCount"] + 1;
                Application.UnLock();
            //}
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            //if (Session["UserId"] == null)
            //{
            //    Response.Redirect("LoginUI.aspx");
            //}
            if ((int)Application["CurrentUserCount"]>0)
            {
                Application.Lock();
                Application["CurrentUserCount"] = (int)Application["CurrentUserCount"] - 1;
                Application.UnLock();
            }
            else
            {
                Application.Lock();
                Application["CurrentUserCount"] =0;
                Application.UnLock();
            }
        }

        protected void Application_End(object sender, EventArgs e)
        {
            
            SqlConnection sqlcon = new SqlConnection(sqlconstr);
            sqlcon.Open();
            string week = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);
            string sql = $"insert into Counts_Admin values('{DateTime.Now.Date}','{DateTime.Now.ToString("HH:mm:ss")}','{week}','{(int)Application["TotalCount"]-1}')";
            SqlCommand cmd = new SqlCommand(sql, sqlcon);
            cmd.ExecuteNonQuery();
            sqlcon.Close();

            Application["Content"] = "";
        }
    }
}