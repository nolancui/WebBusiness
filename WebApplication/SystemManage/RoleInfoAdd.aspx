<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="RoleInfoAdd.aspx.cs" Inherits="WebApplication.SystemManage.RoleInfoAdd" %>
<html>
<head id="Head1" runat="server">
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
	新增角色
</title></head>
<BODY style="background-color:#FFFFFF;border:1px solid #242424;" leftMargin=0 topMargin=0  >
    <form id="form1" runat="Server">
<div class="bgcolorOcxTitle" style="border-bottom:1px solid #242424;text-indent: 2;">
新增角色信息
</div>
	<TABLE cellSpacing=0 cellpadding=4 width="100%" border=1 bordercolor="#242424" style="border-collapse:collapse;">
		<tr><input type=hidden name="LN" value="">
			<td width=100 height=45 bgcolor="#EAEAEA">角色名称：</td>
			<td>
                <asp:TextBox id="txtRoleName" runat="Server"></asp:TextBox>
            </TD>
		</tr>
			<tr><input type=hidden name="LN" value="">
			<td width=100 height=45 bgcolor="#EAEAEA">角色描述：</td>
			<td>
                 <asp:TextBox id="txtRoleDesc" runat="Server" TextMode="MultiLine" Width="189px" Height="49px"></asp:TextBox>
            </TD>
		</tr>
		<tr>
			<td bgcolor="#EAEAEA" align=center colspan=2>
                <asp:Button id="BtnSave" runat="Server" Text="保  存" OnClick="SaveBtnClick"/></td>
		</tr>
	</TABLE>
    </form>
</body>
</html>
