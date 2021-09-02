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
    public partial class OpenDlog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (FileUpload1.HasFile)
                {
                    //string filename = FileUpload1.FileName;
                    //this.Image_View.ImageUrl = "Images//" + filename;
                }
            }
        }

        protected void Btn_Confirm_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                ImageUpLoadDo();
                Products products = new Products();
                products.Path = FileUpload1.FileName;
                products.DateTime = DateTime.Now;
                products.Week = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);
                products.Id= int.Parse(Request["action"].ToString());
                if (ProductsManager.UpdatesProductsFromDAL(products))
                {
                    Response.Write("<script language='javascript'>");
                    Response.Write("window.close();");
                    Response.Write("window.opener.location.href=window.opener.location.href;");
                    Response.Write("opener.document.location.reload();");
                    Response.Write("self.opener.document.location.reload(); ");
                    Response.Write("</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('替换失败!');</script>");
                }
               
            }
            else
            {
                Response.Write("<script>alert('请选择图片!');</script>");
            }
        }

        private void ImageUpLoadDo()
        {
            string filename = FileUpload1.FileName;
            string filefix = filename.Substring(filename.LastIndexOf('.') + 1);
            if (filefix!="png" && filefix!="jpg" && filefix!="jpeg" && filefix!="gif" && filefix!="pic" && filefix!="ico")
            {
                Label1.Text = "你上传的文件不是图片类型的文件!";
            }
            else
            {
                FileUpload1.SaveAs(Server.MapPath(".") + "//Images//" + Server.HtmlDecode(filename));
                Label1.Text = "图片上传成功!";
            }
        }

        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'>");
            Response.Write("window.close();");
            Response.Write("</script>");
        }

    }
}