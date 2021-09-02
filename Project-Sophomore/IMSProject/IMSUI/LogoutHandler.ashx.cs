using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace IMSUI
{
    /// <summary>
    /// LogoutHandler 的摘要说明
    /// </summary>
    public class LogoutHandler : IHttpHandler,IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Session.Clear();
            context.Session.Abandon();
            context.Response.Redirect("LoginUI.aspx");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}