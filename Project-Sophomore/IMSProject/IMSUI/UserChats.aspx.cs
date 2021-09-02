using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IMSUI
{
    public partial class UserChats : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Online_Count.Text ="当前在线人数:"+ Application["CurrentUserCount"].ToString();
                if (Session["Name"]!=null)
                {
                    //BUG:在线用户名一旦刷新,就会不停将相同的名字添加
                    Application.Add(Session["Name"].ToString(), Session["Name"]);
                }
                //T_Show.Text = Application["Content"].ToString();
                T_Show.Text = Application["Content"].ToString();
                //LB_Uname.Items.Clear();
                foreach (string item in Application.Contents)
                {
                    if (!item.Equals("Content")&& !item.Equals("CurrentUserCount") && !item.Equals("name"))
                    {
                        LB_Uname.Items.Add(new ListItem(Application[item].ToString(),Application[item].ToString()));
                    }
                }
            }
        }

        protected void Btn_Send_Click(object sender, EventArgs e)
        {
            if (Session["Name"] != null)
            {
                Application["Content"] +=DateTime.Now.Date.ToString("yyyy-MM-dd") +" "+ DateTime.Now.ToShortTimeString()+" " + (Session["Name"].ToString()) + "说:" + TB_Chat.Text + "\n";
              T_Show.Text = Application["Content"].ToString();
                TB_Chat.Text = "";
            }
        }

        protected void Timer2_Tick(object sender, EventArgs e)
        {
            Online_Count.Text = "当前在线人数:" + Application["CurrentUserCount"].ToString();
            T_Show.Text = Application["Content"].ToString();
        }

        protected void Btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("UsersImageManager.aspx");
            TB_Chat.Text = "";
        }

        //protected void Timer1_Tick(object sender, EventArgs e)
        //{
        //    Online_Count.Text = "当前在线人数:" + Application["CurrentUserCount"].ToString();
        //}
    }
}