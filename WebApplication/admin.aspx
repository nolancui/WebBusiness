<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="admin.aspx.cs" Inherits="WebApplication.admin" %>
<HTML xmlns="http://www.w3.org/1999/xhtml"><HEAD><TITLE>ÅôÅÉÆû³µ·þÎñ</TITLE>
<meta http-equiv="Content-Type" content="text/html; charset="utf-8" /><LINK 
rel=stylesheet type=text/css href="images/admin_Rekoe.css">
<STYLE>.input_login {
	BORDER-BOTTOM: #ffffff 0px solid; BORDER-LEFT: #ffffff 0px solid; HEIGHT: 16px; FONT-SIZE: 9pt; BORDER-TOP: #ffffff 0px solid; BORDER-RIGHT: #ffffff 0px solid
}
.input_val {
	BORDER-BOTTOM: #c0c0c0 1px solid; BORDER-LEFT: #ffffff 0px solid; BACKGROUND-COLOR: #fdfdfd; HEIGHT: 16px; FONT-SIZE: 9pt; BORDER-TOP: #ffffff 0px solid; BORDER-RIGHT: #ffffff 0px solid
}
</STYLE>



<META name=GENERATOR content="MSHTML 8.00.7601.19104"></HEAD>
<BODY onkeydown="javascript:if(event.keyCode==13) {su();return false;}" 
oncontextmenu="javascript:return false" onselectstart="javascript:return false" 
 leftMargin=0 topMargin=0 bgColor=#3a6ea5>
<CENTER>
<TABLE border=0 width="100%" height="96%">
  <TBODY>
  <TR>
    <TD height="100%" width="100%" align=middle>
      <TABLE border=0 width=350 height="96%">
        <TBODY>
        <TR>
          <TD align=middle>
            <TABLE border=0 cellSpacing=0 cellPadding=0 width=575>
              <FORM style="MARGIN: 0px" id=frm_CCRM runat="server">
              <TBODY>
              <TR>
                <TD colSpan=2>
                    <IMG border=0 
              src="images/al_top1.png" style="margin-top: 0px"></TD></TR>
              <TR>
                <TD colSpan=2>
                  <TABLE border=0 cellSpacing=0 cellPadding=0 width=575>
                    <TBODY>
                    <TR>
                      <TD width=184><IMG border=0 
                        src="images/al_username.gif"></TD>
                      <TD background=images/al_body_bg.gif 
                        width=105><asp:TextBox type="text" class="form-control" placeholder="Username" 
                              ID="UserNameInput" runat="server" Width="85px" /></TD>
                      <TD width=93><IMG border=0 
                        src="images/al_password.gif"></TD>
                      <TD background=images/al_body_bg.gif 
                        width=105><asp:TextBox type="password" class="form-control" 
                              placeholder="Password" ID="PassWordInput" runat="server" TextMode=Password 
                              Width="103px"/></TD>
                      <TD width=88><IMG border=0 
                        src="images/al_body_right.gif"></TD></TR></TBODY></TABLE></TD></TR>
              <TR>
                <TD colSpan=2>
                  <TABLE border=0 cellSpacing=0 cellPadding=0 width=575>
                    <TBODY>
                    <TR>
                      <TD width=106><IMG border=0 
                        src="images/al_end_left.gif"></TD>
                      <TD width=361>
                        <TABLE border=0 cellSpacing=0 cellPadding=0 width=361>
                          <TBODY>
                          <TR>
                            <TD height=49 background=images/al_end_bg.gif 
                            align=middle>
                              </TD></TR>
                          <TR>
                            <TD><IMG border=0 
                              src="images/al_end_end.gif"></TD></TR></TBODY></TABLE></TD>
                      <TD width=108><asp:ImageButton style="CURSOR: hand" runat="server" onclick="LoginButton_Click"
                        border=0 alt=µÇÂ¼ 
                    src="images/al_end_right.gif"/></TD></TR></TBODY></TABLE></TD>
                      <TD width=108>
                      </TD></TR></TBODY></TABLE></TD></TR></FORM></TBODY></TABLE></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></CENTER><!--alt="×¢²á" style="cursor:hand" onclick="javascript:RegWin();"--></BODY></HTML>
</html>
