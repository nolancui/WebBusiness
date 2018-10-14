<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="UserToRole.aspx.cs" Inherits="WebApplication.SystemManage.UserList.UserToRole" %>
<html>
<meta http-equiv="Content-Type" content="text/html; charset="utf-8" />
<META http-equiv=Pragma content=no-cache>
<script language=javascript src=../com/month.js></script>
<head id="Head1">
<LINK href="../com/style.css" type=text/css rel=stylesheet>
<STYLE type=text/css> 
.txt-b01 {
	BORDER-RIGHT: #595959 1px solid; BORDER-TOP: #FFF3CA 1px solid; FONT-SIZE: 12px; BORDER-LEFT: #dadada 1px solid; COLOR: #023361; BORDER-BOTTOM: #696a6b 1px solid; FONT-FAMILY: "宋体"; BACKGROUND-COLOR: #FFF3CA
}
.txt02 {
	FONT-SIZE: 12px; COLOR: #023361; FONT-FAMILY: "宋体"
}
.title01 {
	FONT-SIZE: 16px; COLOR: #023361; FONT-FAMILY: "黑体"; LETTER-SPACING: 5px
}
</STYLE>
    <title>
	角色分配
</title></head>
<BODY style="background-color:#FFFFFF;border:1px solid #005599;" leftMargin=0 topMargin=0  >
<form id="form1" runat="server">
<div class="bgcolorOcxTitle" style="border-bottom:1px solid #242424;text-indent: 2;">
用户 <span id="lblUser" runat = "Server"></span> 的角色分配
</div>
<TABLE cellSpacing=0 cellpadding=4 width="100%" border=1 bordercolor="#242424" style="border-collapse:collapse;">
		<tr><input type=hidden name="LN" value="">
			<td width=150 height=45 bgcolor="#EAEAEA"><sup><font color="#ff0000">*</font></sup>请选择角色：</td>
			<td>
                <asp:DropDownList ID="RoleSelect" runat="Server"></asp:DropDownList>
            </TD>
		</tr>
	
		<tr>
			<td bgcolor="#EAEAEA" align=center colspan=2>
                <asp:button id="BtnSave" runat="server" Text="保 存" OnClick="OnSubbmitRole"/>
            </td>
		</tr>
		</TABLE>
</form>
<script language=javascript> 
window.resizeTo(document.body.scrollWidth,document.body.scrollHeight+20);
</script>
</body>
</html>