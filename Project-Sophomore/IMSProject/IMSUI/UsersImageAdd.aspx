<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersImageAdd.aspx.cs" Inherits="IMSUI.UsersImageAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta lang="en" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
     <style type="text/css">
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
         .addsmanager{
             width:700px;
             height:500px;
             margin:0 auto;
            /*background-color:wheat;*/
            background-color:rgb(255,242,226);
             border:1px solid black;
         }
         .content{
             margin:0px auto;
             width:100%;
          text-align:center;
         }
         </style>
    <script type="text/javascript">
        window.onload = function () {
            var fs = document.getElementsByClassName("fileState");
            for (var i = 0; i < fs.length; i++) {
                if (fs[i].innerText == "上传成功!") {
                    fs[i].parentNode.style.backgroundColor = "#9AD8FF";
            }
            }
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--这是添加--%>
               <div class="header" style="width:100%">
               <ul style="width:100%">
                   <%--排列布局BUG--%>
                   <li>当前用户:<asp:Label ID="UserLogin" runat="server" Text="" ForeColor="Green"></asp:Label></li>
                   <li class="links"><a style="cursor:pointer" href="UsersImageManager.aspx">主页</a></li>
                    <li class="links"><a style="cursor:pointer" href="News.aspx">新闻</a></li>
                   <%--<li class="links"><a style="cursor:pointer">管理图片</a></li>--%>
                  <%-- <li class="links"><a style="cursor:pointer" href="UsersImageAdd.aspx">上传图片</a></li>--%>
                    <li class="links"><a href="UsersImageAdd.aspx">上传图片</a></li>
                   <li class="links"><a style="cursor:pointer" href="ImageTypeManager.aspx">图片分类</a></li>
                   <li class="links"><a style="cursor:pointer" href="Coder.aspx">关于我们</a></li>
                   <li class="links"><a onclick="javascript:if(confirm('你确定要退出吗?'))window.location='LogoutHandler.ashx'" style="cursor:pointer">退出登录</a></li>
                   </ul>
               <hr  style="background-color:green"/>
           </div>
            <div class="content">
                <p>选择分类:<asp:DropDownList ID="DDL_Type" runat="server" AutoPostBack="True"></asp:DropDownList></p>
                <div class="addsmanager">
                    <br />
                    <p>
                        <asp:FileUpload ID="FileUpload1" runat="server"/>&nbsp;<asp:Button ID="Btn_AddList" runat="server" Text="添加" OnClick="Btn_AddList_Click" />&nbsp;&nbsp;<asp:Button ID="Btn_DeleteSeleted" runat="server" Text="删除选中" />&nbsp;&nbsp;<asp:Button ID="StartUp" runat="server" Text="开始上传" OnClick="StartUp_Click" />&nbsp;&nbsp;&nbsp;<asp:Button ID="Btn_CleanList" runat="server" Text="清空列表" Style="margin-right:20px" OnClick="Btn_CleanList_Click" /></p>
                <hr style="background-color:gainsboro"/>
                    <table style="width:100%" border="1">
                        <tr style="width:100%;background-color:lightgrey">
                            <th style="width:10%;">编号</th>
                            <th style="width:45%">文件名称</th>
                            <th style="width:15%">文件类型</th>
                            <th style="width:15%">文件大小</th>
                            <th style="width:15%">状态</th>
                        </tr>
                        <asp:Repeater ID="ReUp" runat="server">
                          <ItemTemplate>
                             <tr style="width:100%;background-color:white;">
                            <td style="width:10%;"><%# Eval("FileId")%></td>
                            <td style="width:45%"><%# Eval("FilesName")%></td>
                            <td style="width:15%"><%# Eval("FileFix")%></td>
                            <td style="width:15%"><%# Eval("FileSize") %></td>
                          <%--  <td style="width:15%"><%# Eval("FileStates") %></td>--%>
                            <td style="width:15%" class="fileState"><%=Fs %></td>
                        </tr>
                          </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
