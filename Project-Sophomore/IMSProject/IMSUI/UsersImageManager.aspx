<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersImageManager.aspx.cs" Inherits="IMSUI.UsersImageManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <%--<meta http-equiv="refresh" content="60" />--%>
    <title></title>
    <base target="_self" />
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
        dl dd.managers {
        visibility:hidden;
        }
        dl:hover dd.managers{
          visibility:initial;
        }
        dl:hover{
            padding:10px;
           border:0.5px solid grey;
           box-shadow: 0 0 3px 0px black ;
        }
        .imgthumb:hover{
            cursor:zoom-in;
        }

       .imgs{
          position: fixed;left: 0;top: 0; right: 0;bottom: 0;
           margin:auto;z-index:9999;border: 10px solid #fff;
       }
.mask{
    position: fixed;left: 0;top: 0; right: 0;bottom: 0;background-color: #000;
    opacity:0.5;filter: Alpha(opacity=50);z-index: 98;transition:all 1s;
    display: none;
}
.mask:hover{
    cursor:zoom-out;
}
    </style>
    <script type="text/javascript" src="Scripts/jquery-3.4.1.min.js"></script>
    <script type="text/javascript" src="Scripts/clipboard.min.js"></script>
    <script type="text/javascript">
      //一个可能是JS集成环境的BUG: alert()输出一个字符串时, 加入\n或\\n即可达到换行效果;但一个字符串加变量的输出,却始终不能换行
        function Copy() {
            var path = $("img").prop("outerHTML");
            //var url = document.getElementsByTagName("img")[0].outerHTML;
            //url.select();
               //alert(path);
            //document.execCommand("Copy"); // 执行浏览器复制命令
            //alert("复制成功!");
            alert("获取成功!");
            alert(path);
               return false;
            }
    </script>
    <script type="text/javascript">
        $(function ()  {
            $("img.imgthumb").dblclick(function (e) {
                   var newImg = '<img src='
                                    + $(this).attr("src") + ' class="imgs"></img>';
                $('#bigimg')
                    .html($(newImg).attr("title","单击图片外任意区域可还原图片")
                        .animate({ height: '550', width: '450' }, 1000));
                $('.mask').show();
            });
            $(document).bind("click", function (e) {
                var target = $(e.target);
                if (target.closest(".imgs").length == 0) {
                    $(".imgs").fadeOut("slow");
                    e.stopPropagation();
                    $(".mask").fadeOut("slow");
                    e.stopPropagation();
                   
                }
            });
            //$(".replace").click(function OpenOvertimeDlog (frm,width,height) {
            //    var me;
            //    var action;
            //    me = "OvertimeDlog.aspx?action=" + action + "";
            //    window.showModalDialog(me, null, 'dialogWidth=' + width + 'px;dialogHeight=' + height + 'px;help:no;status:no');
            //});
        });
    </script>
    <script type="text/javascript" lang="ja">
        function OpenOvertimeDlog (frm,width,height) {
                var me;
            var action;
            action = frm;
                me = "OpenDlog.aspx?action=" + action + "";
            window.showModalDialog(me, null, 'dialogWidth=' + width + 'px;dialogHeight=' + height + 'px;help:no;status:no');
            window.open(me, nul, 'width=' + width + ',height=' + height + 'toolbar=no, menubar=no, scrollbars=no, resizable=no, location=no, status=no',location=no,status=no);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>这是普通用户</p>
           <div class="header" style="width:100%">
               <ul style="width:100%">
                   <%--排列布局BUG--%>
                   <li>当前用户:<asp:Label ID="UserLogin" runat="server" Text="" ForeColor="Green"></asp:Label></li>
                   <li class="links"><a style="cursor:pointer" href="News.aspx">新闻</a></li>
                   <li class="links"><a style="cursor:pointer" href="UserChats.aspx">聊天室</a></li>
                   <%--<li class="links"><a style="cursor:pointer">管理图片</a></li>--%>
                  <%-- <li class="links"><a style="cursor:pointer" href="UsersImageAdd.aspx">上传图片</a></li>--%>
                   <li class="links"><a href="UsersImageAdd.aspx">上传图片</a></li>
                   <li class="links"><a style="cursor:pointer" href="ImageTypeManager.aspx">图片分类</a></li>
                   <li class="links"><a style="cursor:pointer" href="Coder.aspx">关于我们</a></li>
                   <li class="links"><a onclick="javascript:if(confirm('你确定要退出吗?'))window.location='LogoutHandler.ashx'" style="cursor:pointer">退出登录</a></li>
                   <li class="links">天气:&nbsp;<asp:Label ID="Proc" runat="server" Text=""  Style="color:red;"></asp:Label>&nbsp;<asp:Label ID="City" runat="server" Text="Label" Style="color:red;"></asp:Label>&nbsp;<asp:Label ID="Du" runat="server" Text="" Style="color:red;"></asp:Label>&nbsp;<asp:Label ID="Descs" runat="server" Text="" Style="color:red;"></asp:Label></li>
                   </ul>
               <hr  style="background-color:green"/>
           </div>
            <div class="selects"></div>
            <div class="content">
                <asp:Repeater ID="ReProducts" runat="server" OnItemCommand="ReProducts_ItemCommand">
                    <ItemTemplate>
                       <dl>
                           <dt style="border:1px solid black;">
                       <asp:Image ID="ImgProducts" runat="server"  class="imgthumb"  ImageUrl='<%# "~/Images/"+ Eval("Path") %>' Width="250" Height="250" Style="width:200px;height:200px;" ToolTip="点击查看大图"/>
                   <%--<img src='<%# "~/Images/"+ Eval("Path") %>' id="ImgProducts" />--%>
                               </dt>
                           <dd><%# Eval("Path") %></dd>
                           <dd><%# Eval("DateTime") %></dd>
                           <dd><%# Eval("Week")%></dd>
                           <dd class="managers">操作:
                              <asp:Button ID="Selected" runat="server" Text="链接" BorderStyle="None" ForeColor="LimeGreen" BackColor="Transparent" CommandArgument='<%# Eval("Id") %>' CommandName="Links"/>&nbsp;
                               <asp:Button ID="Code" runat="server" Text="代码" BorderStyle="None" ForeColor="LimeGreen" BackColor="Transparent" OnClientClick="return Copy();" />&nbsp;
                               <asp:Button ID="Dele" runat="server" Text="删除" BorderStyle="None" ForeColor="LimeGreen" BackColor="Transparent"  OnClientClick="return confirm('你确定删除吗?');" CommandArgument='<%# Eval("Id") %>' CommandName="Deletes" />&nbsp;
                               <asp:Button ID="Replaces" class="replace" runat="server" Text="替换" BorderStyle="None" ForeColor="LimeGreen" BackColor="Transparent" CommandArgument='<%# Eval("Id") %>' CommandName="Replace" /></dd>
                       <dd style="height:20px;"></dd> 
                       </dl>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div id="bigimg" style="width:100%;height:100%"></div>
          <div class="mask"></div>
        </div>

    </form>
</body>
</html>
