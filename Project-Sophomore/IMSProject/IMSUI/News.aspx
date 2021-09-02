<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="IMSUI.News" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <script>
         setTimeout("location.reload()",60000);
         //setTimeout("location.href='UsersImageManager.aspx'",60000);
    </script>
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
          iframe{
              margin:0px auto;
              margin-left:10%;
              padding:0;
              width:80%;
              height:630px;
          }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
               <div class="header" style="width:100%">
               <ul style="width:100%">
                   <%--排列布局BUG--%>
                   <li>当前用户:<asp:Label ID="UserLogin" runat="server" Text="" ForeColor="Green"></asp:Label></li>
                    <li class="links"><a style="cursor:pointer" href="UsersImageManager.aspx">主页</a></li>
                   <li class="links"><a style="cursor:pointer" href="News.aspx">新闻</a></li>
              <%--     <li class="links"><a style="cursor:pointer">管理图片</a></li>--%>
                  <%-- <li class="links"><a style="cursor:pointer" href="UsersImageAdd.aspx">上传图片</a></li>--%>
                   <li class="links"><a href="UsersImageAdd.aspx">上传图片</a></li>
                   <li class="links"><a style="cursor:pointer" href="ImageTypeManager.aspx">图片分类</a></li>
                   <li class="links"><a style="cursor:pointer" href="Coder.aspx">关于我们</a></li>
                   <li class="links"><a onclick="javascript:if(confirm('你确定要退出吗?'))window.location='LogoutHandler.ashx'" style="cursor:pointer">退出登录</a></li>
                   </ul>
               <hr  style="background-color:green"/>
           </div>
            <div class="content">
                <iframe src="https://www.toutiao.com/" frameborder="2"></iframe>
            </div>
        </div>
    </form>
</body>
</html>
