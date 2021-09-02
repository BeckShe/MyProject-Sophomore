<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintfReporty.aspx.cs" Inherits="IMSUI.Admin.PrintfReporty" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #container{
            width:100%;
            margin:0 auto;
            text-align:center;
        }
        #tblist tr:nth-child(2n+1){
            background-color:#eee;
        }
        th{
            border:1px solid #ccc;
        }
        td{
            border:1px solid #ccc;
        }
        html{
            background-color:rgb(255,242,226);
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
            <h3>用户注册信息</h3>
           <p>
               <asp:Button ID="Btn_Back" runat="server" Text="回退" OnClick="Btn_Back_Click" /> <asp:Button ID="Btn_out" runat="server" Text="核心代码导出" OnClick="Btn_out_Click" Style="margin-bottom:10px"  /></p>
            <%--这是打印--%>
            <div runat="server">
             <table id="tblist"  cellspacing="0" cellpadding="0" style="text-align:center;margin:0 auto;border-collapse:collapse;width:900px;">
                 <tr>
                    <th>编号</th>
                    <th>用户名</th>
                    <th>注册日期</th>
                    <th>注册时间</th>
                    <th>注册星期</th>
                    <th>用户性别</th>
                </tr>
            <asp:Repeater ID="Re_UserInfo" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Id") %></td>
                        <td><%# Eval("Name") %></td>
                        <td><%# Eval("Date","{0:d}") %></td>
                        <td><%# Eval("Time") %></td>
                        <td><%# Eval("Week") %></td>
                        <td><%# Eval("SexsStr") %></td>
                    </tr>
                </ItemTemplate>
                    
            </asp:Repeater>
              </table>  
                </div>
        </div>
    </form>
</body>
</html>
