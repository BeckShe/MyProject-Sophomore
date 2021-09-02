using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

namespace IMSUI
{
    public partial class ImageTypeManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Re_DataBind();
            }
        }

        private void Re_DataBind()
        {
            Repeater1.DataSource = Products_TypeManager.GetTypes();
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName=="Update")
            {
                TextBox texts = e.Item.FindControl("TextBox1") as TextBox;
                texts.ReadOnly = false;
                LinkButton link = e.Item.FindControl("LBtn_Save") as LinkButton;
                link.Visible = true;
            }
            //BUG:要双击才能达到小窗口弹出效果
            if (e.CommandName == "Save")
            {
                TextBox texts = e.Item.FindControl("TextBox1") as TextBox;
                LinkButton link = e.Item.FindControl("LBtn_Save") as LinkButton;
                int id = Convert.ToInt32(e.CommandArgument);
                Products_Type type = new Products_Type()
                {
                    TypeId = id,
                    TypeName = texts.Text
                };
                if (Products_TypeManager.UpdateTypeFromDAL((type)))
                {
                    Response.Write("<script>alert('修改成功! ^_^');window.location.href='ImageTypeManager.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('修改失败!');</script>");
                }
            }
            if (e.CommandName == "Add")
            {
                //int id = Convert.ToInt32(e.CommandArgument);
                LinkButton link = e.Item.FindControl("LBtn_Add") as LinkButton;
                link.Attributes.Add("onclick", $"javascript:OpenOvertimeDlog('{e.CommandArgument}',540,250)");
            }
        }
    }
}