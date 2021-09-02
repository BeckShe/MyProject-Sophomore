<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserChats.aspx.cs" Inherits="IMSUI.UserChats" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        *{
           margin: auto;
           padding:0;
        }
        #container{
            width:800px;
            height:550px;
            border:1px dashed red;
        }
        .middle{
              display:flex;
            flex-direction:row;
        }
        .left{
            width:300px;
            height:500px;
            overflow-y:scroll;
             border:1px solid black;
        }
        .right{
            width:550px;
            height:500px;
            /*overflow-y:scroll;*/
             border:1px solid green;
        }
        .sends{
            margin-top:30px;
            text-align:center;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
             
                  <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                      <ContentTemplate>
                           <p style="text-align:center;">
                          <asp:Label ID="Online_Count" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </p>
                        <%--  <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick"></asp:Timer>--%>
                   
                
            <br />
         <div class="middle">
              <div class="left">
                  <asp:ListBox ID="LB_Uname" runat="server" Height="474px" Width="285px"></asp:ListBox>
          </div>
            <div class="right">
                <%--<textarea id="TA_Show" class="auto-style1"></textarea>--%>
                <%--<asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>--%>
        <asp:TextBox ID="T_Show" runat="server" Height="490px" ReadOnly="True" TextMode="MultiLine" Width="535px" BackColor="#fff2e2"></asp:TextBox>
                        <asp:Timer ID="Timer2" runat="server" Interval="1000" OnTick="Timer2_Tick"></asp:Timer>
            </div>
             </ContentTemplate>
              </asp:UpdatePanel>
         </div>
         <p class="sends">   
             <asp:TextBox ID="TB_Chat" runat="server" Width="300" Height="45"></asp:TextBox>
             <asp:Button ID="Btn_Send" runat="server" Text="发送" OnClick="Btn_Send_Click" />
             <asp:Button ID="Btn_Back" runat="server" Text="退出" OnClientClick="return confirm('你确定退出多人聊天室吗?');" OnClick="Btn_Back_Click" />
             </p>
             <%--</ContentTemplate>
              </asp:UpdatePanel>--%>
             </div>
    </form>
</body>
</html>
