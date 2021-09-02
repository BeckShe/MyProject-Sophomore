using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

namespace IMSUI
{
    public partial class AddUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnadd_Click(object sender, EventArgs e)
        {
            if (txtname.Text == "" || txtpwd.Text == "")
            {
                Response.Write("<Script>alert('名称或密码不能为空！')</Script>");
                return;
            }
            if (RadioButtonList1.SelectedValue == "")
            {
                Response.Write("<Script>alert('你还未选择性别！')</Script>");
                return;
            }

            var User = new Users
            {
                Name = txtname.Text,
                Pwd = txtpwd.Text,
                Date=DateTime.Now.Date,
                Time=DateTime.Now.TimeOfDay.ToString().Substring(0,8),
                Week= System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek),
                Sexs = Convert.ToInt32(RadioButtonList1.SelectedValue)
            };
            if (UsersManager.AddStu(User))
            {
                //Response.Redirect("LoginUI.aspx");
                Response.Write("<script>alert('注册成功!恭喜你成为IMS一员 ^_^');window.location.href='LoginUI.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败')</script>");
            }
        }
    }
}