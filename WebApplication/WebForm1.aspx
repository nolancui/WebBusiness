<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
 
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Top</title>
<link href="css/index.css" rel="stylesheet" type="text/css" />
<link href="css/common.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/jquery-1.4.min.js"></script>
<script type="text/javascript" src="js/index.js"></script>
<script type="text/javascript" src="js/layout.js"></script>
<script type="text/javascript" src="js/layer.js"></script>
<script type="text/javascript" src="js/iepngfix_tilebg.js"></script> 
<script type="text/javascript" src="com/func.js"></script> 
<style type="text/css"> 
img, div,ul{ behavior: url(images/iepngfix.htc) }
</style> 
<!-- 
	弹出层方法 layerAction('要弹出层的id');
    关闭层方法 closeAction();
 -->
 
<!--[if IE 6]>
    <!--script src="js/DD_belatedPNG.js"></script-->
    <script>
    //DD_belatedPNG.fix('*');
    </script>
    <![endif]--> 
<script language="javascript" type="text/javascript"> 
 
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
    setInterval(sendHTTPRequest, 10000);
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
 
</script>
<script language="javascript"> 
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
function setLeftUrl(v){
	parent.leftFrame.location.href="LeftFrame.aspx?LeftPra="+v;
}
 
 
function SHwin1() {
    popwin('UserList/UserInfoSet.aspx', 700, 550, '')
}
</script>
 
</head>
<body style="border:none">
    <form name="form1" method="post" action="TopFrame.aspx" id="form1">
<div>
<input type="hidden" name="__VIEWSTATE" id="__VIEWSTATE" value="/wEPDwUJNjk0MDk3NjgyD2QWAgIBD2QWAmYPFgIeBFRleHQFGzIwMTblubQwNeaciDEz5pelIOaYn+acn+S6lGRkdlLTxn5aO/xdu769O88YKjch2guFnHHfLl5mK7UyZ9c=" />
</div>
 
    <div class="header">
  <div class="headtop">
    <div class="logo"  onclick="layerAction('add')"><img src="images/logo1.png" alt="安德瑞汽车服务" /></div>
    <div class="shutdown"><img src="images/shutdown.png" alt="退出" onclick="top.location.href='LoginOut.aspx'" /></div><!--onclick="layerAction('quit')"   onclick="parent.ExitID.click();" -->
    <div class="nav">
      <div class="nleft"></div>
      <ul id="nav">
      <li><span><img src="images/n1.gif" alt="工单管理" /></span><a onclick="setLeftUrl('1');" style="cursor:hand">工单管理</a></li><li><span><img src="images/n4.gif" alt="综合查询" /></span><a onclick="setLeftUrl('3');" style="cursor:hand">综合查询</a></li><li><span><img src="images/n2.gif" alt="系统管理" /></span><a onclick="setLeftUrl('8');" style="cursor:hand">系统管理</a></li>
        <!--<li><span><img src="images/n1.gif" alt="内容审核" /></span><a onclick="setLeftUrl('1');" style="cursor:hand">内容审核</a></li>
        <li><span><img src="images/n3.gif" alt="分析统计" /></span><a onclick="setLeftUrl('2');" style="cursor:hand">分析统计</a></li>
        <li><span><img src="images/n2.gif" alt="系统管理" /></span><a onclick="setLeftUrl('3');" style="cursor:hand">系统管理</a></li>
        <li class="navLast"><span><img src="images/n4.gif" alt="自定义" /></span>xxx</li>-->
      </ul>
    </div>
  </div>
  <div class="menu">
    <div class="mleft"><img src="images/menuleft.gif" alt="" /></div>
    <ul class="mlist">
      <!--<li> <span><img src="images/m1.gif" alt="主页" /></span> --><!--<span><img src="images/m2.gif" alt="后退" /></span> <span><img src="images/m3.gif" alt="前进" /></span>--></li>
	<li><a onclick="SHwin();" style="cursor:hand"><span><img src="images/m4.gif" alt="目录" /></span>目录</a></li>
    	<li><a onclick="SHwin1();" style="cursor:hand"><span><img src="images/m5.gif" alt="个人设置" /></span>个人设置</a></li>
                           
      <!--
      <li><span><img src="images/m5.gif" alt="通讯录" /></span>通讯录</li>
      <li style="background:none;"><span><img src="images/m6.gif" alt="消息" /></span><code>1条<img src="images/xl.gif" alt="箭头" /></code></li>
	-->
    </ul>
    <div class="mright"><img src="images/menuright.gif" alt="" /></div>
    <ul class="mlistright">
      <li><span><img src="images/m7.gif" alt="时间" /></span>
        <label>2016年05月13日 星期五</label>
      </li>
      <li style="background:none;"><span><img src="images/m8.gif" alt="关于" /></span></li>
    </ul>
       <marquee width="70%" scrollamount="6" onmouseover="this.stop()" color="red" onmouseout="this.start()" style="color:Red; font-size:12px"  id="rss"></marquee>
      </div>
</div>
<!-- 弹出层 -->
<div id="cBg" style="display:none;"></div>
<!-- 退出系统 -->   
<div class="quit commonLayer" id="quit">
    	<div class="ttitle">退出系统</div>
        <div class="qinfo">
        <span><img src="images/quit.gif" alt="退出" /></span>
        <p>你确定要退出系统吗？       <p>你确定要退出系统吗？<br />确定请选“是”，取消请点击“否”</p>
        </div>
        <div class="qbtn">
        <input name="" type="button" value="是" onclick="window.location='LoginOut.aspx'"  class="tbtn" /> &nbsp;&nbsp;&nbsp;
        <input name="" type="button" value="否" onclick="closeAction()" class="tbtn"/></div>
</div>
 
    </form>
</body>
</html>
