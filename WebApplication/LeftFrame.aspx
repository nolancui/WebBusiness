<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="LeftFrame.aspx.cs" Inherits="WebApplication.LeftFrame" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3c.org/TR/1999/REC-html401-19991224/loose.dtd">
<!-- saved from url=(0051)http://120.55.240.108:8088/LeftFrame.aspx -->
<HTML xmlns="http://www.w3.org/1999/xhtml"><HEAD><TITLE>left</TITLE>
<meta http-equiv="Content-Type" content="text/html; charset="utf-8" /><LINK 
rel=stylesheet type=text/css href="js/lefthref.css"><LINK 
rel=stylesheet type=text/css href="js/index.css"><!--link href="css/common.css" rel="stylesheet" type="text/css" -->
<SCRIPT type=text/javascript src="js/jquery-1.4.min.js"></SCRIPT>

<SCRIPT type=text/javascript src="js/left.js"></SCRIPT>

<SCRIPT type=text/javascript src="js/tab.js"></SCRIPT>
<!-- 
	�����㷽�� layerAction('Ҫ�������id');
    �رղ㷽�� closeAction();
 -->
<SCRIPT src="js/DD_belatedPNG.js"></SCRIPT>

<SCRIPT language=javascript>
    DD_belatedPNG.fix('*');
    </SCRIPT>

<SCRIPT language=javascript>
function GetonclickH() {
	document.onclick=parent.mainFrame.onclickH;
}
function Hwin(){
	parent.Sbar.cols="0,*";
}

function fxtdzsIDherfUrl(urls){
	fxtdzsID.href=urls;
	fxtdzsID.click();
}
function wlxcIDherfUrl(urls){
	wlxcID.href=urls;
	wlxcID.click();
}
</SCRIPT>

<STYLE>.over {
	BORDER-BOTTOM: buttonshadow 1px solid; BORDER-LEFT: buttonhighlight 1px solid; BACKGROUND-COLOR: buttonface; BORDER-TOP: buttonhighlight 1px solid; BORDER-RIGHT: buttonshadow 1px solid
}
normal {
	BACKGROUND-COLOR: buttonface
}
.overbutton {
	BORDER-BOTTOM: #000080 1px solid; BORDER-LEFT: #000080 1px solid; BACKGROUND-COLOR: #ffeec2; BORDER-TOP: #000080 1px solid; BORDER-RIGHT: #000080 1px solid
}
.downbutton {
	BORDER-BOTTOM: #000080 1px solid; BORDER-LEFT: #000080 1px solid; BACKGROUND-COLOR: #fe803e; BORDER-TOP: #000080 1px solid; BORDER-RIGHT: #000080 1px solid
}
.out {
	BACKGROUND-COLOR: #ffffff
}
</STYLE>

<META name=GENERATOR content="MSHTML 8.00.7601.19104"></HEAD>
<BODY 
style="BORDER-BOTTOM: medium none; BORDER-LEFT: medium none; BORDER-TOP: medium none; BORDER-RIGHT: medium none" 
onload=GetonclickH();>
<FORM id=form1 method=post name=form1  runat="Server">
<!-- ��Ҫ���� -->
<DIV class=main>
<DIV class=left>
<DIV class=lefttitle>
<TABLE width="100%">
  <TBODY>
  <TR>
    <TD><SPAN><IMG alt=��ͷ src="images/leftxl.gif"></SPAN></TD>
    <TD align=right><IMG onmouseup='this.className="overbutton"' class=normal 
      onmouseover='this.className="overbutton"' 
      onmouseout='this.className="normal"' 
      onmousedown='this.className="downbutton"' onclick=Hwin(); 
      src="images/icon-close.gif"> </TD></TR></TBODY></TABLE></DIV><!-- ���˵� -->
<H3 class=linktitle>
<UL class=leftlink>
  <LI>
  <H3 class=linktitle runat="Server" id ="SystemManage" ><SPAN><IMG 
  src="images/leftlist2.gif"></SPAN>ϵͳ����</H3>
  <OL class=linkOl>
    <LI class=webfx-tree-item runat="Server" id="DeptManager" ><SPAN><IMG 
    src="images/leftlist3.gif"></SPAN><A 
    href="SystemManage/DeptManager.aspx" 
    target=mainFrame>���Ź���</A></LI>
    <LI class=webfx-tree-item runat="Server" id="UserPower" ><SPAN><IMG 
    src="images/leftlist3.gif"></SPAN><A 
    href="SystemManage/UserPower.aspx" 
    target=mainFrame>�û�����</A></LI>
    <LI class=webfx-tree-item runat="Server" id="RolePower"><SPAN><IMG 
    src="images/leftlist3.gif"></SPAN><A 
    href="SystemManage/RolePower.aspx" 
    target=mainFrame>��ɫ����</A></LI></OL></LI>
    <!--class="linktitle linkAfter"Ĭ�ϴ򿪲˵�|<ol class="linkOl" >style="display:block"Ĭ�ϴ򿪲˵�
    
   
    
-->

  <LI>
  <H3 class=linktitle runat=server id="Workordermanagement"><SPAN><IMG 
  src="images/leftlist2.gif"></SPAN>��������</H3>
  <OL class=linkOl>
    <LI class=webfx-tree-item runat="Server" id="ClientManage" visible =false ><SPAN><IMG 
    src="images/leftlist3.gif"></SPAN><A 
    href="MenuManage/ClientManage.aspx" 
    target=mainFrame>�ͻ�����</A></LI>
    <LI class=webfx-tree-item runat="Server" id ="ResetCustomdata" visible =false ><SPAN><IMG 
    src="images/leftlist3.gif" /> </SPAN><A 
    href="MenuManage/ResetCustomdata.aspx" 
    target=mainFrame>���ݻָ�</A></LI>
    <LI class=webfx-tree-item runat="Server" id ="GridViewyuanshi" visible =false><SPAN><IMG 
    src="images/leftlist3.gif"></SPAN><A 
    href="MenuManage/GridViewyuanshi.aspx" 
    target=mainFrame>ԭʼ����</A></LI>
    <LI class=webfx-tree-item runat="Server" id ="FenpeiDelete" visible =false><SPAN><IMG 
    src="images/leftlist3.gif"></SPAN><A 
    href="MenuManage/FenpeiDelete.aspx" 
    target=mainFrame>����ɾ��</A></LI>
    <LI class=webfx-tree-item runat="Server" id ="MinDanChuli" visible =false ><SPAN><IMG 
    src="images/leftlist3.gif" ></SPAN><A 
    href="MenuManage/MinDanChuli.aspx" 
    target=mainFrame>��������</A></LI>
    <LI class=webfx-tree-item runat="Server" id ="PiLiangChuLi" visible =false ><SPAN><IMG 
    src="images/leftlist3.gif" /> </SPAN><A 
    href="MenuManage/PiLiangChuLi.aspx" 
    target=mainFrame>��������</A></LI>
    </OL></LI>

    
  <LI>
  <H3 class=linktitle runat="Server" id = "BaseShearch" ><SPAN><IMG 
  src="images/leftlist2.gif"></SPAN>�ۺϲ�ѯ</H3>
  <OL class=linkOl>
    <LI class=webfx-tree-item runat="Server" id="ADRAuditing" ><SPAN><IMG 
    src="images/leftlist3.gif"></SPAN><A 
    href="BaseShearch/ADRAuditing.aspx?zt=0" 
    target=mainFrame>�ͻ���¼��ѯ</A></LI></OL></LI>
        </UL>
    
<DIV class=leftinfo></DIV></DIV></DIV></FORM></H3></BODY></HTML>
