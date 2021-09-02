using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using BLL;
using Model;

namespace IMSUI.Admin
{
    public partial class UsersAccountTotal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CountBind();
                ChartPieDataBind();
                ChartBarDataBind();
            }
        }

        private void ChartBarDataBind()
        {
            int year = Convert.ToInt32(DateTime.Now.Date.ToString().Substring(0, 4));
            DataTable dt2 = UsersManager.GetDataRegisterCountFromDAL(year);
            Chart3.DataSource = dt2;
            Chart3.Series[0].XValueMember = "Dates";
            Chart3.Series[0].YValueMembers = "PersonCounts";
            Chart3.Titles.Add("Chart3Title");
            Chart3.Titles[0].Text = "注册用户的日期及个数统计并分析";
            Chart3.Legends.Add("Chart3Legend");
            Chart3.Series[0].LabelToolTip = "日期：#VALX\\n人数：#VAL";
            Chart3.Series[0].ToolTip = "日期：#VALX\\n人数：#VAL";
            Chart3.Series[0].Label = "#VAL";
            Chart3.Series[0].MarkerStyle = MarkerStyle.Cross;

            Chart3.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
            //Chart3.ChartAreas[0].AxisX.Interval=10;
            Chart3.ChartAreas[0].AxisX.MajorGrid.LineDashStyle=ChartDashStyle.Dash;
            //Annotation annotation = new LineAnnotation();
            //Chart3.Annotations.Add(annotation);
            //Chart3.Annotations[0].TextStyle = TextStyle.Emboss;
            Chart3.DataBind();
        }

        private void ChartPieDataBind()
        {
            DataTable dts = UsersManager.GetUsersSexsFromDAL();
            Chart2.DataSource = dts;
            Chart2.Series[0].XValueMember = "Sexss";
            Chart2.Series[0].YValueMembers = "Countss";
            //Chart1.Series[0].LegendText = "注册用户的男女比例情况分析";
            Chart2.Titles.Add("ChartTitle");
            Chart2.Titles[0].Text = "注册用户的男女比例统计并分析";
            Chart2.Series[0].LegendToolTip = "性别:#VALX";
            Chart2.Series[0].LabelToolTip = "性别：#VALX\\n人数：#VAL";
            Chart2.Series[0].ToolTip = "性别：#VALX\\n人数：#VAL";
            Chart2.Series[0].Label = "#PERCENT{P2}";
            Chart2.ChartAreas[0].AxisY.Interval = 0.001D;
            Chart2.Series[0].IsValueShownAsLabel = true;
            Chart2.DataBind();
        }

        private void CountBind()
        {
            //除去管理员进行的统计
            TotalCount.Text = ((int)Application["TotalCount"]-1).ToString();
            if ((int)Application["CurrentUserCount"] - 1>=0)
            {
                OnlineCount.Text = ((int)Application["CurrentUserCount"] - 1).ToString();
            }
            else
            {
                Application["CurrentUserCount"] = 0;
                OnlineCount.Text = Application["CurrentUserCount"].ToString();
            }
            //OnlineCount.Text = ((int)Application["CurrentUserCount"] - 1).ToString();
        }

        protected void Unnamed_Tick(object sender, EventArgs e)
        {
            CountBind();
        }

        protected void Btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("ImagesManager.aspx");
        }
    }
}