using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Model;
using BLL;

namespace IMSUI
{
    public partial class UsersImageManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BUG:不用try+catch语句,定时session清除掉,页面报错
                try
                {
                    UserLogin.Text = Session["Name"].ToString();
                    ReProductsDataBind();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Page:"+ex.Message);
                }
                ShowWeather();
            }
            SessionBind();
           
        }

        private void ShowWeather()
        {
            cn.com.webxml.www.WeatherWebService webService = new cn.com.webxml.www.WeatherWebService();
            string[] infos = webService.getWeatherbyCityName("邵阳");
            Proc.Text = infos[0];
            City.Text = infos[1];
            Du.Text = infos[12];
            Descs.Text = infos[13];
        }

        private void ReProductsDataBind()
        {
                int id =int.Parse(Session["UsersId"].ToString());
                List<Products> products = ProductsManager.GetProductsFromDAL(id);
                ReProducts.DataSource = products;
                ReProducts.DataBind();
        }

        private void SessionBind()
        {
            if (Session["Name"] == null && Session["Pwd"] == null && Session["UsersId"]==null)
            {
                Response.Write("<script>alert('你还没登录或登录超时!');top.location.href='LoginUI.aspx';</script>");
                //Response.Redirect("LoginUI.aspx");
            }
        }

        protected void ReProducts_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Deletes")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                if (ProductsManager.DeleteProductFromDAL(id))
                {
                    Response.Write("<script>alert('删除成功!');window.location='UsersImageManager.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('删除失败!');</script>");
                }
            }
            //else if (e.CommandName== "CodesCopy")
            //{
            //    int id = int.Parse(e.CommandArgument.ToString());
            //    Response.Write("<script></script>");

            //}


            else if (e.CommandName == "Links")
            {
                Button button = e.Item.FindControl("Selected") as Button;
                int id = int.Parse(e.CommandArgument.ToString());
                string image = ProductsManager.GetProductsImagePath(id);
                //string path ="http://"+ "Image" + "//" + image;
                string path = "http://"+"www.baidu.com" +"/" +"Images" + "/" + image;
                if (!string.IsNullOrEmpty(image))
                {
                    //Response.Write($"<script>alert('获取选中的链接为:{path}');</script>");
                    //Page.RegisterStartupScript("msg", "<script>alert('获取选中的链接为:{path}');</script>");
                    button.Attributes["onclick"] = $"alert('获取选中的链接为:{path}');";
                }
                else
                {
                    Response.Write("<script>alert('获取选中图片链接失败!');</script>");
                }
            }
            else if (e.CommandName == "Replace")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                Button button = e.Item.FindControl("Replaces") as Button;
                button.Attributes.Add("onclick", $"javascript:OpenOvertimeDlog('{id}',540,250)");
            }
        }


    
    }
}