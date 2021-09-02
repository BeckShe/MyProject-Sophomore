<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUsers.aspx.cs" Inherits="IMSUI.AddUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
   <style type="text/css">
       *{
           margin:0px;
           padding:0px;
           text-decoration:none;
       }
       body{
           background:url("/Images/bg.jpg") no-repeat scroll !important;
       }
       .as {
           width: 320px;
           height: 250px;
           text-align: center;
           margin-top: 50px;
           border: 1px dashed #ffffff;
           margin: 0px auto;
           margin-top:200px;
       }
       .auto-style1 {
           height: 44px;
       }
   </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="as">
            <h1 style="color:#ffffff">用户注册</h1>
            <table style="width:270px; text-align:center; margin:0px auto; margin-top:20px;border-color:white;" border="1" >
                <tr>
                    <td style="color:#ffffff" class="auto-style1">用户名称：</td>
                    <td class="auto-style1"><asp:TextBox ID="txtname" runat="server"></asp:TextBox></td>
                </tr>
                <tr >
                    <td style="color:#ffffff">密码:</td>
                    <td><asp:TextBox ID="txtpwd" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="color:#ffffff">性别:</td>
                    <td style="color:white;">
                       <%-- <asp:RadioButton ID="Male" runat="server" GroupName="Sex" Text="男"/>&nbsp;&nbsp;
                        <asp:RadioButton ID="FelMale" runat="server" GroupName="Sex" Text="女" />--%>
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Width="100%">
                            <asp:ListItem Text="男" Value="1"></asp:ListItem>
                            <asp:ListItem Text="女" Value="2"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
            </table>
            <p style="margin-top:20px;">
                <asp:Button ID="btnadd" runat="server" Text="保存" OnClick="btnadd_Click" Height="30px" Width="100px"/>
            </p>
        </div>
    </form>
</body>
</html>
