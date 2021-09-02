<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginUI.aspx.cs" Inherits="IMSUI.LoginUI" %>

<%@ Register Assembly="WebValidates" Namespace="WebValidates" TagPrefix="cc1" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">
        <meta name="viewport"  content="width=device-width,initial-scale=1.0"/>   
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>登录页</title>
    <style type="text/css">
        .container {
            padding: 0px;
            margin: 0 auto;
            border: 1px solid black;
            background:rgba(0,0,0,.3);
            /*opacity:0.8;*/
            width: 500px;
        }
        body{
            /*background:url("https://wangz.online/static/img/timg.jpg") repeat scroll !important;*/
            background:url("/Images/bge.jpg") no-repeat scroll !important;
        }
        h1{
           text-align:center;
            
        }
        h1:hover{
             /*cursor:pointer;*/
             position:relative;
             font-family:Candara;
            /*transform: perspective(600px) rotateX(0deg) rotateY(0deg) rotateZ(0deg);*/
            color: #fafafa;
            letter-spacing: 0;
            font-weight: bold;
	        transform:rotateX(10deg);
	        -webkit-transform: rotateX(10deg); /* Safari and Chrome */
	        -webkit-transform: rotateY(120deg); /* Safari and Chrome */
            animation: round 6s infinite linear;
        }
          @keyframes round{
            0%{
                transform: rotateY(0deg);
            }
            100%{
                transform: rotateY(360deg);
            }
        }
          h3:hover{
              cursor:not-allowed;
          }
    </style>
    <script type="text/javascript" src="Scripts/jquery-3.4.1.min.js"></script>
    <script type="text/javascript">
        window.onload = function () { 
             var index = 0;
        var words = document.getElementById("h1s").innerText;
        function Type() {
            document.getElementById("h2s").innerText = words.substring(0, index++);
        }
        setInterval(Type,500);
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <h1 style="text-align: center;display:none" id="h1s">IMS系统</h1>
        <h1  style="text-align: center;" id="h2s"></h1>
       <marquee width="100%"  vspace="10" hspace="10" bgcolor="transparent" loop="-1" style="font-size:30px;color:lightskyblue" direction="right" scroamount="200">IMS系统欢迎你使用(^_^)</marquee>
        <div class="container">
            <h3 class="first" style="margin-left: 20px;text-align:center;">用户登录</h3>
            <hr />
            <p style="text-align:center">用户名:<asp:TextBox ID="UName" runat="server" placeholder="请输入用户名"></asp:TextBox></p>
            <p style="text-align:center">密&nbsp;&nbsp;码:<asp:TextBox ID="UPwd" runat="server" TextMode="Password" placeholder="请输入密码"></asp:TextBox></p>
           <p style="margin-left:120px;line-height:40px">&nbsp;&nbsp;&nbsp;&nbsp;验证码:<asp:TextBox ID="Confirms" runat="server" Width="80px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<cc1:ValidateCode ID="ValidateCode1" runat="server" BackColor="White" Style=" background:rgb(255, 255, 255);width:95px;height:42px;"></cc1:ValidateCode>
               <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">换一张</asp:LinkButton>
               &nbsp;
           </p>
            <p style="text-align:center">
                <asp:Button Style="margin-left: 20px;" ID="Btn_Login" runat="server" Text="登录" OnClick="Btn_Login_Click" BackColor="#66FF33" BorderColor="#33CC33" ForeColor="Black" Height="30px" Width="100px" />
               &nbsp; <asp:Button ID="Btn_Register" runat="server" Text="注册" BackColor="#66FF33" BorderColor="#33CC33" ForeColor="Black" Height="30px" Width="100px" OnClick="Btn_Register_Click" />
            </p>
        </div>
    </form>
</body>
</html>
