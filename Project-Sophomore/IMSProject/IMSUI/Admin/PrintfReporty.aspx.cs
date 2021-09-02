using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.Data;

namespace IMSUI.Admin
{
    public partial class PrintfReporty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Re_UserInfoDataBind();
        }

        private void Re_UserInfoDataBind()
        {
            DataTable dt = UsersManager.GetDataButForAdminFromDAL();
            Re_UserInfo.DataSource = dt;
            Re_UserInfo.DataBind();
        }

        protected void Btn_out_Click(object sender, EventArgs e)
        {
            System.Web.UI.Control ctl = this.Re_UserInfo;
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=Excel.xls");
            HttpContext.Current.Response.Charset = "UTF-8";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.Default;
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";

            ctl.Page.EnableViewState = false;
            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new HtmlTextWriter(tw);
            ctl.RenderControl(hw);
            HttpContext.Current.Response.Write(tw.ToString());
            HttpContext.Current.Response.End();

            //System.Web.UI.Control ctl = this.Label1;

            ////输出属性
            //HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=Excel.xls");
            //HttpContext.Current.Response.Charset = "UTF-8";
            //HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.Default;
            //HttpContext.Current.Response.ContentType = "application/ms-excel";

            ////输出空间内容到HtmlTextWriter
            //ctl.Page.EnableViewState = false;
            //System.IO.StringWriter tw = new System.IO.StringWriter();
            //System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
            //ctl.RenderControl(hw);

            ////输出HtmlTextWriter
            //HttpContext.Current.Response.Write(tw.ToString());
            //HttpContext.Current.Response.End();

        }

        protected void Btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("ImagesManager.aspx");
        }
    }
}