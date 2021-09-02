<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Coder.aspx.cs" Inherits="IMSUI.Coder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport"  content="width=device-width;initial-scale=1.0"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        * {
            margin: 0px auto;
            padding: 0;
        }

        .container {
            width: 100%;
            height: 100%;
            position: fixed;
            left: 0;
            top: 0;
            right: 0;
            bottom: 0;
            /*background-color:#b3b3b3;*/
            background-color: #000;
            opacity: 0.65;
            filter: Alpha(opacity=65);
            z-index: 200;
            transition: all 1s;
        }

        .codeimg {
            /*display:flex;
      justify-content:center;
      align-items:center;*/
            position: absolute;
            width: 300px;
            height: 300px;
            top: 0;
            bottom: 0;
            left: 0;
            right: 0;
            margin: auto;
            z-index: 9999;
            border: 5px solid #fff;
            opacity:1;
            background-color:white;
        }

       body {
            background: url("/Images/bge.jpg") no-repeat scroll !important;
        }

        .imgdesc {
            /*color:lawngreen;*/
            /*color:#11c200;*/
            color:#17ff00;
            font-size:33px;
            position: absolute;
            /*top: 0;
            bottom: 0;
            left: 0;
            right: 0;
            margin:auto;*/
             top: 75%; left: 41.8%; transform: translateY(-50%);
            /*margin-left: 50%;
            margin-top: 20%;*/
             opacity: 1;
            z-index: 9999;
        }
    </style>
    <script type="text/javascript" src="Scripts/jquery-3.4.1.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $(".imgdesc").dblclick(function () {
                //$(".codeimg").fadeOut(5000);
                window.location.href = "UsersImageManager.aspx";
                //setInterval(window.location.href = "UsersImageManager.aspx",5000);
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <%--<asp:Image ID="Image1" runat="server" ImageUrl="~/Images/codeImage.jpg"  class="codeimg" />--%>
        </div>
   <%--Tip:要实现在半透明的遮罩层上高亮图片,且图片不透明的,那么将mask层与内容区平级安排;否则mask层的透明度会影响内容区域--%>
        <img class="codeimg" src="Images/codeImage2.jpg" title="请双击下方文字回退到主界面" />
            <p class="imgdesc">烽鸟组·精心制作</p>
    </form>
</body>
</html>
