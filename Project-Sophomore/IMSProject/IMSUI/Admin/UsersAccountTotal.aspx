<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersAccountTotal.aspx.cs" Inherits="IMSUI.Admin.UsersAccountTotal" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>站长统计</title>
    <style type="text/css">
        #myeCharts{
            width:100%;
            height:500px;
            z-index:10000;
        }
        #myChart2{
            width:100%;
            height:350px;
            margin:0 auto;
            text-align:center;
            z-index:10000;
        }
         #myChart3{
            width:100%;
            height:400px;
            margin:0 auto;
            text-align:center;
            z-index:10000;
        }
         html{
             background-color:rgb(255,242,226);
              /*实现背景图不随滚动条而滚动*/
                /*background:url("/Images/bge.jpg") center top fixed ;*/   
         }
    </style>
    <script type="text/javascript" src="../Scripts/echarts.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-3.4.1.min.js"></script>
    <script type="text/javascript">
        window.onload = function () {
            var mychart = echarts.init(document.querySelector("#myeCharts"));

            //var arr = []; //存放7天的数据
            //function getBeforeDate(n){
            //    var n = n;
            //    console.log(n);
            //    var d = new Date();
            //    var year = d.getFullYear();
            //    var mon = d.getMonth();
            //    var day = d.getDate();
            //    if (day<=n) {
            //        if (mon > 1) {
            //            mon = mon - 1;
            //        } else {
            //            year = year - 1;
            //            mon = 12;
            //        }
            //    }
            //    d.setDate(d.getDate() + n);
            //    year = d.getFullYear();
            //    mon = d.getMonth() + 1;
            //    day = d.getDate();
            //    s = (mon < 10 ? ('0' + mon) : mon) + "-" + (day < 10 ? ('0' + day) : day);
            //    return s;
            //}
            //for (var i = 0; i < -7; i--) {
            //    arr.push(getBeforeDate(i));
            //}


            $.ajax({
                type: 'post',
                url: 'Ajax.ashx',
                data: { w: "GetCountsByMonth", year: 2020 },
                timeout: 5000,
                dataType: 'json',
                async: true,//默认为true,即所有请求均为异步请求
                //cache: true //默认为true,当data为script时,为false，flase将表示不会从浏览器缓存中请求数据
                success: function (data) {



                       var arr = []; //存放7天的数据
            //function getBeforeDate(n){
            //    var n = n;
            //    console.log(n);
            //    var d = new Date();
            //    var year = d.getFullYear();
            //    var mon = d.getMonth();
            //    var day = d.getDate();
            //    if (day<=n) {
            //        if (mon > 1) {
            //            mon = mon - 1;
            //        } else {
            //            year = year - 1;
            //            mon = 12;
            //        }
            //    }
            //    d.setDate(d.getDate() + n);
            //    year = d.getFullYear();
            //    mon = d.getMonth() + 1;
            //    day = d.getDate();
            //    s = (mon < 10 ? ('0' + mon) : mon) + "-" + (day < 10 ? ('0' + day) : day);
            //    return s;
            //}
                    for (var i = 0; i < -7; i--) {
                        arr.push(data.datamonths[i]);
            }




                    console.log(data);
                    console.log(data.datamonths);
                    console.log(data.dataitems);
        var optionCounts = {
   title: {
       text: '本站点历史访问的次数',
       left: 'center'
    },
    tooltip: {
        trigger: 'axis',
        axisPointer: {
            type: 'cross',
            label: {
                backgroundColor: '#6a7985'
            }
        }
    },
    legend: {
        data: ['历史访客人数'],
        left:'left'
    },
    grid: {
        left: '3%',
        right: '4%',
        bottom: '3%',
        containLabel: true
    },
   toolbox: {
        feature: {
            dataZoom: {
                show:true
            },
            dataView: {
                readOnly: true
            },
            restore: {},
            saveAsImage: {
                show:true,
	       	 pixelRatio: 2 
            }
        }
    },

    xAxis: {
        type: 'category',
        boundaryGap: false,
        data: data.datamonths
        //data: arr.reverse()
    },
    yAxis: {
        type: 'value'
    },
    series: [
        {
            name: '历史访客人数',
            type: 'line',
            stack: '总量',
            data: data.dataitems
        }

    ]
                    };
                    mychart.setOption(optionCounts);
                }
            });
        };
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>
                <asp:Button ID="Btn_Back" runat="server" Text="返回" OnClick="Btn_Back_Click" /><input type="button"  onclick="window.print();" value="打印"/></p>
           <div class="one">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UPanel" runat="server">
                <ContentTemplate>
                    <p>
                       当前在线人数:<asp:Label ID="OnlineCount" runat="server" Text=""></asp:Label></p>
                    <p>
                        <%--若是访客总人数,还是有BUG,且访问IE内核的(应该是QQ浏览器)浏览器,会增加2--%>
                      访客访问总次数:&nbsp;<asp:Label ID="TotalCount" runat="server" Text=""></asp:Label></p>
                    <asp:Timer runat="server" Interval="1000" OnTick="Unnamed_Tick"></asp:Timer>
                </ContentTemplate>
            </asp:UpdatePanel>
           </div>
<%--            <hr style="background-color:lightgray"/>
            <div class="SexChart"></div>--%>
             <hr style="background-color:lightgray"/>
            <div id="myeCharts">
                
            </div>
            <br />
            <hr style="background-color:lightgray"/>
                       <div id="myChart3">
                  <h3>本站点已注册用户的数据详情</h3>
                <asp:Chart ID="Chart3" runat="server" Height="341px" Width="966px" Palette="None" PaletteCustomColors="NavajoWhite">
                    <Series>
                        <asp:Series Name="Series1" LabelForeColor="Red"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1" BackColor="White">
                            <AxisX ArrowStyle="Triangle" IntervalAutoMode="VariableCount" LabelAutoFitMaxFontSize="20" MaximumAutoSize="7">
                                <ScaleBreakStyle Enabled="True" />
                            </AxisX>
                            <Area3DStyle Enable3D="True" />
                        </asp:ChartArea>
                    </ChartAreas>
                    <Legends>
                        <asp:Legend Name="Legend1">
                            <CellColumns>
                                <asp:LegendCellColumn ColumnType="SeriesSymbol" Name="Column1" Text="#VALX">
                                    <Margins Left="15" Right="15" />
                                </asp:LegendCellColumn>
                                <asp:LegendCellColumn Name="Column2" Text="当日注册量">
                                    <Margins Left="15" Right="15" />
                                </asp:LegendCellColumn>
                            </CellColumns>
                        </asp:Legend>
                    </Legends>
                </asp:Chart>
            </div>
            <div style="height:100px"></div>
            <hr style="background-color:lightgray"/>
              <div id="myChart2">
                <h3>本站点已注册用户的性别比例情况</h3>
                <asp:Chart ID="Chart2" runat="server" Height="408px" Width="903px">
                    <Series>
                        <asp:Series Name="Series1" ChartType="Pie" Legend="Legend1"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                    <Legends>
                        <asp:Legend Name="Legend1">
                            <CellColumns>
                                <asp:LegendCellColumn ColumnType="SeriesSymbol" Name="Column1" Text="#VALX">
                                    <Margins Left="15" Right="15" />
                                </asp:LegendCellColumn>
                                <asp:LegendCellColumn Name="Column2" Text="#VALX">
                                    <Margins Left="15" Right="15" />
                                </asp:LegendCellColumn>
                            </CellColumns>
                        </asp:Legend>
                    </Legends>
                </asp:Chart>
            </div>
        </div>
    </form>
</body>
</html>
