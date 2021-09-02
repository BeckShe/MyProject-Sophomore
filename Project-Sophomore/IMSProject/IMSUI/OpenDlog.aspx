<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OpenDlog.aspx.cs" Inherits="IMSUI.OpenDlog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <base target="_self" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>替换图片</title>
    <style type="text/css">
        *{
            margin:0 auto;
            padding:0;
        }
        html{
            /*background:url("Images/bge.jpg") no-repeat;
            background-size:100% 100%;*/
            background-color:rgb(255,242,226);
        }
        #Image_View{
        filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=scale);
        }
    </style>
    <script type="text/javascript">
             
            function preview(imgfile) {
                var image = document.getElementById("Image_View");
                //console.log(imgfile.value);
                image.src = "..\\MapStorage\\" + imgfile.value;
                console.log(image.src);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            这是对话框
           <p>替换图片</p> 
            <table border="1" style="border-collapse:collapse;text-align:center;width:100%">
                <tr>
                    <td>选择图片:</td>
                     <td> <asp:FileUpload ID="FileUpload1" runat="server"  onchange="preview(this)"/></td>
                </tr>
                <tr style="height:100px;">
                    <td>预览:</td>
                    <td>
                        <%--<asp:Image ID="Image_View" runat="server" Width="100px" Height="100px"/>--%>
                        <img id="Image_View" src="" width="120" height="120" />
                        <%--<div id="Image_View"></div>--%>
                    </td>
                </tr>
                 <tr>
                    <td></td>
                     <td>
                         <asp:Button ID="Btn_Cancel" runat="server" Text="取消" OnClick="Btn_Cancel_Click" BackColor="SteelBlue" ForeColor="White" Style="border-radius:10%;" BorderStyle="None" />
                         <asp:Button ID="Btn_Confirm" runat="server" Text="确定替换" BackColor="SteelBlue" ForeColor="White" Style="border-radius:10%;" BorderStyle="None" OnClick="Btn_Confirm_Click" /><asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
