using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using WebValidates;

namespace IMSUI
{
    public partial class LoginUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               //验证码的BUG:宽高不能和填验证码的输入框同一基点;且linkbutton会回发,导致密码框密码被提交而丢失
                ValidateCode1.CreateYzm();
            }
        }

        protected void Btn_Login_Click(object sender, EventArgs e)
        {
            string name = UName.Text.Trim();
            string pwd = UPwd.Text.Trim();
            Users users = new Users();
            users.Name = name;
            users.Pwd = pwd;
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(pwd))
            {
                //HttpCookie cname = new HttpCookie("UserName",Server.UrlEncode(this.UName.Text));
                //HttpCookie cpwd = new HttpCookie("UserPwd",Server.UrlEncode(this.UPwd.Text));
                //cname.Expires = DateTime.Now.AddMinutes(3);
                //cpwd.Expires = DateTime.Now.AddMinutes(3);
                //Response.Cookies.Add(cname);
                //Response.Cookies.Add(cpwd);
                if (this.ValidateCode1.CheckYzm(this.Confirms.Text))
                {
                    Session["Name"] = name;
                    Session["Pwd"] = pwd;
                    int id = UsersManager.GetUsersIdFromDAL(users);
                    Session["UsersId"] = id;
                    if (UsersManager.GetUsersFromDAL(users).Count > 0 && id > 0)
                    {
                        string url = "";
                        url = name == "admin" ? url = "Admin//ImagesManager.aspx" : "UsersImageManager.aspx";
                        Application["CurrentUserCount"] = (int)Application["CurrentUserCount"] + 1;
                        Response.Redirect(url);
                        //if (name=="admin")
                        //{
                        //    Response.Redirect("Admin/ImagesManager.aspx");
                        //}
                        //else
                        //{
                        //    Response.Redirect("UsersImageManager.aspx");
                        //}
                    }
                    else
                    {
                        Response.Write("<script>alert('你输入的用户名或密码不正确!');</script>");
                        UName.Text = "";
                        UPwd.Text = "";
                    }

                }
                else
                {

                    //Response.Write("<script>alert('你输入的验证码不正确!');</script>");
                    ClientScript.RegisterStartupScript(
                        this.GetType(),
                        "erro",
                        "alert('验证失败!')",
                        true
                        );
                }
            }
            else
            {
                Response.Write("<script>alert('请输入用户名和密码');</script>");
            }
        }

        protected void Btn_Register_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddUsers.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            this.ValidateCode1.CreateYzm();
        }
    }
}