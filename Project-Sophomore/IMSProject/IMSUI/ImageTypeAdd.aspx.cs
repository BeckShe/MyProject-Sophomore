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
    public partial class ImageTypeAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Btn_Add_Click(object sender, EventArgs e)
        {
            Products_Type type = new Products_Type() {
                TypeName = TextBox1.Text
            };
            if (Products_TypeManager.AddTypeFromDAL(type))
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
                Response.Write("<script language='javascript'>");
                Response.Write("alert('添加失败!');");
                Response.Write("</script>");
            }
        }
    }
    }
