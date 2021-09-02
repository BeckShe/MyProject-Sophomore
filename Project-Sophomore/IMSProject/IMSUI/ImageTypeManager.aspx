<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageTypeManager.aspx.cs" Inherits="IMSUI.ImageTypeManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        *{
            margin:0 auto;
            padding:0;
        }
        html{
            background-color:rgb(255,242,226);
        }
        .header ul li{
            float:left;
            list-style:none;
        }
          .header ul li.links{
            margin-left:20px;
        }
        .header ul{
            overflow:hidden;
        }
        a{
            text-decoration:none;
            color:limegreen;
        }
          a:hover{
            color:red;
        }
    </style>
     <script type="text/javascript" lang="ja">
        function OpenOvertimeDlog (frm,width,height) {
                var me;
            var action;
            action = frm;
                me = "ImageTypeAdd.aspx?action=" + action + "";
            window.showModalDialog(me, null, 'dialogWidth=' + width + 'px;dialogHeight=' + height + 'px;help:no;status:no');
            window.open(me, nul, 'width=' + width + ',height=' + height + 'toolbar=no, menubar=no, scrollbars=no, resizable=no, location=no, status=no',location=no,status=no);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
              <div class="header" style="width:100%">
               <ul style="width:100%">
                   <%--排列布局BUG--%>
                   <li>当前用户:<asp:Label ID="UserLogin" runat="server" Text="" ForeColor="Green"></asp:Label></li>
                    <li class="links"><a style="cursor:pointer" href="UsersImageManager.aspx">主页</a></li>
                   <li class="links"><a style="cursor:pointer" href="News.aspx">新闻</a></li>
                   <li class="links"><a style="cursor:pointer">管理图片</a></li>
                  <%-- <li class="links"><a style="cursor:pointer" href="UsersImageAdd.aspx">上传图片</a></li>--%>
                   <li class="links"><a href="UsersImageAdd.aspx">上传图片</a></li>
                   <li class="links"><a style="cursor:pointer">图片分类</a></li>
                   <li class="links"><a style="cursor:pointer" href="Coder.aspx">关于我们</a></li>
                   <li class="links"><a onclick="javascript:if(confirm('你确定要退出吗?'))window.location='LogoutHandler.ashx'" style="cursor:pointer">退出登录</a></li>
                   </ul>
               <hr  style="background-color:green"/>
           </div>
            <br />
            <%--图片分类--%>
            <table border="1" style="width:80%;text-align:center;">
                <tr>
                    <th>类别ID</th>
                    <th>图片分类</th>
                    <th>操作</th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("TypeId") %></td>
                            <td style="width:60%">
                                <asp:TextBox ID="TextBox1" runat="server" ReadOnly="true" BorderStyle="None" Text='<%# Eval("TypeName") %>' style="text-align:center;background-color:transparent;"></asp:TextBox></td>
                            <td>
                                [<asp:LinkButton ID="LBtn_Update" runat="server" Style="color:green" CommandArgument='<%#Eval("TypeId") %>' CommandName="Update">修改</asp:LinkButton>]
                                  <asp:LinkButton ID="LBtn_Save" runat="server" Style="color:green" CommandArgument='<%#Eval("TypeId") %>' CommandName="Save" Visible="false">[保存]</asp:LinkButton>
                                [<asp:LinkButton ID="LBtn_Add" runat="server" Style="color:green" CommandName="Add">末尾追加</asp:LinkButton>]
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </form>
</body>
</html>
