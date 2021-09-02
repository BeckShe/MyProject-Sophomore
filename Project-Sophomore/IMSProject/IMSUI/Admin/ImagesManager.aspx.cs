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
    public partial class ImagesManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReProductsDataBind();
                UserNamesShow();
            }
            SessionBind();
        }

        private void UserNamesShow()
        {
            //string name = UsersManager.GetUsersNameFromDAL();
        }

        private void ReProductsDataBind()
        {
            //int id = int.Parse(Session["UsersId"].ToString());
            List<Products> products = ProductsManager.GetProductsFromDAL();
            
            ReProducts.DataSource = products;
            ReProducts.DataBind();
        }

        private void SessionBind()
        {
            if (Session["Name"] == null && Session["Pwd"] == null)
            {
                Response.Write("<script>alert('你还没登录或登录超时!');top.location.href='../LoginUI.aspx';</script>");
                //Response.Redirect("LoginUI.aspx");
            }
        }

        protected void ReProducts_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName=="Deletes")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                if (ProductsManager.DeleteProductFromDAL(id))
                {
                    Response.Write("<script>alert('删除成功!');window.location='ImagesManager.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('删除失败!');</script>");
                }
            }
        }
    }
}