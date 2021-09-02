<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImagesManager.aspx.cs" Inherits="IMSUI.ImagesManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script>
        setTimeout("location.href='ImagesManager.aspx'",60000);
    </script>
    <style type="text/css">
        .header ul li{
            float:left;
            list-style:none;
            margin-left:20px;
        }
        .header ul{
            overflow:hidden;
        }
        a{
            text-decoration:none;
            color:limegreen;
        }
        .content{
            width:100%;
           display:flex;
           flex-direction:row;
          flex-wrap:wrap;
           justify-content:flex-start;
        }
        dl{
            margin-left:20px;
        }
       dd{
           margin-left:0;
       }
        a:hover{
            color:red;
        }
        html{
            background-color:rgb(255,242,226);
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <div class="header">
               <ul>
                   <li>
                       <asp:Label ID="Admins" runat="server" Text="管理员:Admin"></asp:Label></li>
                   <%--<li><a>管理图片</a></li>--%>
                   <%--<li><a>上传图片</a></li>--%>
                   <li><a href="PrintfReporty.aspx">报表打印</a></li>
                   <li><a href="UsersAccountTotal.aspx">站长统计</a></li>
                   <li><a onclick="javascript:if(confirm('你确定要退出吗?'))window.location='../LogoutHandler.ashx'" style="cursor:default">退出登录</a></li>
               </ul>
               <hr  style="background-color:green"/>
           </div>
            <div class="selects"></div>
            <div class="content">
                <asp:Repeater ID="ReProducts" runat="server" OnItemCommand="ReProducts_ItemCommand" >
                    <ItemTemplate>
                       <dl style="border:2px solid grey">
                           <dt style="border:1px solid black;">
                  <asp:Image ID="ImgProdcuts" runat="server" ImageUrl='<%# "~/Images/"+ Eval("Path") %>' Width="250" Height="250" Style="width:200px;height:200px"/>
                    </dt>
                           <dd><%# Eval("Path") %></dd>
                           <dd><%# Eval("DateTime") %></dd>
                           <dd><%# Eval("Week")%></dd>
                           <dd>操作:
                               <asp:Button ID="Dele" runat="server" Text="删除" BorderStyle="None" ForeColor="LimeGreen" BackColor="Transparent"  OnClientClick="return confirm('你确定删除吗?');" CommandArgument='<%# Eval("Id") %>' CommandName="Deletes" />
                           </dd>
                       <dd style="height:20px;"></dd> 
                       </dl>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </form>
</body>
</html>
