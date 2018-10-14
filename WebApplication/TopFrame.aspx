<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="TopFrame.aspx.cs" Inherits="WebApplication.TopFrame" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3c.org/TR/1999/REC-html401-19991224/loose.dtd">
<HTML xmlns="http://www.w3.org/1999/xhtml"><HEAD><TITLE>Top</TITLE>
<LINK rel=stylesheet type=text/css href="js/index.css"/>
<LINK rel=stylesheet type=text/css href="js/common.css"/>
<SCRIPT type=text/javascript src="js/jquery-1.4.min.js"></SCRIPT>
<SCRIPT type=text/javascript src="js/index.js"></SCRIPT>
<SCRIPT type=text/javascript src="js/layout.js"></SCRIPT>
<SCRIPT type=text/javascript src="js/layer.js"></SCRIPT>
<SCRIPT type=text/javascript src="js/iepngfix_tilebg.js"></SCRIPT>
<SCRIPT type=text/javascript src="js/func.js"></SCRIPT>

<SCRIPT language=javascript type=text/javascript>

    function sendHTTPRequest() {
        xmlHttp = GetXmlHttpObject();
        if (xmlHttp == null) {
            alert("您的浏览器不支持AJAX！");
        }
        var url = "notice.ashx";
        xmlHttp.onreadystatechange = function () {
            if (xmlHttp.readyState == 4) {
                if (xmlHttp.responseText != "") {
                    var tmp = "";
                    var arry = xmlHttp.responseText.split('+');
                    for (var m = 0; m < arry.length; m++) {
                        var title = arry[m].split(',')[0];
                        var value = arry[m].split(',')[1];
                        tmp += "<label title=\"" + value + "\">" + title + "</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                    }
                }
                document.getElementById("rss").innerHTML = tmp;
            }
        };
        xmlHttp.open("GET", url, true);
        xmlHttp.setRequestHeader("If-Modified-Since", "0");
        xmlHttp.send(null);
    }
    //这边是刷新的时间
    //setInterval(sendHTTPRequest, 10000);
    
    
    function GetXmlHttpObject() {
        var xmlHttp = null;
        try {
            // Firefox, Opera 8.0+, Safari
            xmlHttp = new XMLHttpRequest();
        }
        catch (e) {
            // Internet Explorer
            try {
                xmlHttp = new ActiveXObject("Msxml2.XMLHTTP");
            }
            catch (e) {
                xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
        }
        return xmlHttp;
    }

//this is my add

    //setInterval(showhello, 10000);
    setInterval(showmessage, 10000);
    function showmessage(){
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "TopFrame.aspx/GetMessage",
            dataType: "json",
            data: "{ 'getinf': 'success'}",
            success: showdata,
            error: function(error) {
                alert("error");
                alert(error.responseText);
            }
        });
    }
    function showhello()
    {
     $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "TopFrame.aspx/ShowHello",
            dataType: "json",
            data: "{ 'getinf': 'success'}",
            success: function (result) {
            alert(result.d);
            },
            error: function(error) {
                alert("error");
                alert(error.responseText);
            }
        });
    }

    function showdata(result) {
    document.getElementById("rss").innerHTML = result.d;
        
        
    }
   // this is end add 


</SCRIPT>

<SCRIPT language=javascript>
function SHwin() {
var leftbar=parent.Sbar.cols.split(",")[0]*1;
var middlebar=parent.mainFrame.document.body.offsetWidth;
var Telebar=parent.Sbar.cols.split(",")[2]*1;
if(leftbar<1) {
	if(Telebar>0)
		parent.Sbar.cols="175,0,"+Telebar;
	else
		parent.Sbar.cols="175,*,0";
}
else {
	if(Telebar>0)
		parent.Sbar.cols="0,0,"+Telebar;
	else
		parent.Sbar.cols="0,*,0";
}
}
function setLeftUrl(v) {
	parent.leftFrame.location.href="LeftFrame.aspx?LeftPra="+v;
}


function SHwin1() {
    popwin('SystemManage/UserList/UserInfoSet.aspx', 700, 550, '')
}
</SCRIPT>

<META name=GENERATOR content="MSHTML 8.00.7601.19104"></HEAD>
<BODY 
style="BORDER-BOTTOM: medium none; BORDER-LEFT: medium none; BORDER-TOP: medium none; BORDER-RIGHT: medium none">
<from id=form1 runat="Server">

<DIV class=header>
<DIV class=headtop>
<DIV class=logo onclick="layerAction('add')"><IMG alt=鹏派汽车服务 
src="images/logo1.png"></DIV>
<DIV class=shutdown><IMG onclick="top.location.href='admin.aspx'" alt=退出 
src="images/shutdown.png"></DIV><!--onclick="layerAction('quit')"   onclick="parent.ExitID.click();" -->
<DIV class=nav>
<DIV class=nleft></DIV>
<UL id=nav runat=server>
  <LI runat="Server" id="MenuManage" ><SPAN><IMG alt=工单管理  src="images/n1.gif"></SPAN><A 
  style="CURSOR: hand" onclick="setLeftUrl('1');">工单管理</A></LI>
  <LI id="BaseShearch" runat="Server"><SPAN><IMG alt=综合查询 src="images/n4.gif"></SPAN><A 
  style="CURSOR: hand" onclick="setLeftUrl('3');">综合查询</A></LI>
  <LI id="SystemManage" runat="Server"><SPAN><IMG alt=系统管理 src="images/n2.gif"></SPAN><A 
  style="CURSOR: hand" onclick="setLeftUrl('8');">系统管理</A></LI></UL></DIV></DIV>
<DIV class=menu>
<DIV class=mleft><IMG alt="" src="images/menuleft.gif"></DIV>
<UL class=mlist></LI>
  <LI><A style="CURSOR: hand" onclick=SHwin();><SPAN><IMG alt=目录 
  src="images/m4.gif"></SPAN>目录</A></LI>
  <LI><A style="CURSOR: hand" onclick=SHwin1();><SPAN><IMG alt=个人设置 
  src="images/m5.gif"></SPAN>个人设置</A></LI></UL>
  
<DIV class=mright><IMG alt="" src="images/menuright.gif"></DIV>
<UL class=mlistright>
  <LI><SPAN><IMG alt=时间 src="images/m7.gif"></SPAN> 
  <asp:Label id="datetimeofday" runat="server" ForeColor=White></asp:Label> </LI>
  <LI style="BACKGROUND: none transparent scroll repeat 0% 0%"><SPAN><IMG alt=关于 
  src="images/m8.gif"></SPAN></LI></UL>

    <marquee scrollamount="6" behavior=scroll  onmouseover="this.stop()" color="red"
        onmouseout="this.start()" 
        style="color:Red; bgcolor:white; font-size:12px; height: 32px; width: 66%;BACKGROUND-COLOR-COLOR: #ffffff" id="rss" 
        runat="server"></marquee></DIV></DIV><!-- 弹出层 -->
<DIV style="DISPLAY: none" id=cBg></DIV><!-- 退出系统 -->
<DIV id=quit class="quit commonLayer">
<DIV class=ttitle>退出系统</DIV>
<DIV class=qinfo><SPAN><IMG alt=退出 src="images/quit.gif"></SPAN> 
<P>你确定要退出系统吗？ 
<P>你确定要退出系统吗？<BR>确定请选“是”，取消请点击“否”</P></DIV>
<DIV class=qbtn><INPUT class=tbtn onclick="window.location='admin.aspx'" value=是 type=button name=""> 
&nbsp;&nbsp;&nbsp; <INPUT class=tbtn onclick=closeAction() value=否 type=button name=""></DIV></DIV>
</from></BODY></HTML>
