<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageTypeAdd.aspx.cs" Inherits="IMSUI.ImageTypeAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
   
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <table border="1" style="text-align:center;"> 
               <tr>
                   <td>添加分类:</td>
                   <td>
                       <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
               </tr>
               <tr>
                   <td></td>
                   <td> <asp:Button ID="Btn_Add" runat="server" Text="添加分类" OnClick="Btn_Add_Click" /></td>
               </tr>
           </table>
           
        </div>
    </form>
</body>
</html>
