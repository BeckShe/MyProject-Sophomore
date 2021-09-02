using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using BLL;
using System.Data;
using System.Text;

namespace IMSUI.Admin
{
    /// <summary>
    /// Ajax 的摘要说明
    /// </summary>
    public class Ajax : IHttpHandler
    {
        HttpContext ctx;
        public void ProcessRequest(HttpContext context)
        {
            ctx = context;
            string w = YYCMS.Request.GetFormString("w");
            switch (w)
            {
                case "GetCountsByMonth": GetCountsByMonth(); break;

            }
        }

        private void GetCountsByMonth()
        {
            var year = YYCMS.Request.GetFormInt("year", 0);
            DataSet ds = Counts_AdminManager.GetDataInfoYearFromDAL(year);
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append("\"datamonths\":[");
            int i = 0;
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                //sb.AppendFormat("{0}", item["Date"]);
                if (i==ds.Tables[0].Rows.Count-1)
                {
                    //sb.Append($"{item["Date"].ToString()}");
                    sb.AppendFormat("\"{0}\"", item[0].ToString().Substring(0,9));
                }
                else
                {
                    //sb.Append($"{item["Date"].ToString()}");
                    sb.AppendFormat("\"{0}\",", item[0].ToString().Substring(0, 9));
                }
                i++;

            }
            sb.Append("],");
            //sb.Append(",");
            sb.Append("\"dataitems\":[");
            int j = 0;
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                //sb.AppendFormat("{0}", item["Date"]);
                if (j==ds.Tables[0].Rows.Count-1)
                {
                    //sb.Append($"{item["VisitedCounts"].ToString()}");
                    //sb.AppendFormat("{0}",item["VisitedCounts"].ToString());
                    sb.AppendFormat("\"{0}\"", item[1].ToString());
                }
                else
                {
                    //sb.Append($"{item["VisitedCounts"].ToString()}");
                    sb.AppendFormat("\"{0}\",", item[1].ToString());
                }
                j++;
            }
            sb.Append("]");
            sb.Append("}");
            ctx.Response.ContentType = "text/json";
            ctx.Response.Write(sb.ToString());
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