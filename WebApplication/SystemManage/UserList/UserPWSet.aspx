 
 <%@ Page Language="C#" AutoEventWireup="True" CodeBehind="UserPWSet.aspx.cs" Inherits="WebApplication.SystemManage.UserList.UserPWSet" %>

<html>
<head>
<LINK href="../com/style.css" type=text/css rel=stylesheet>
<STYLE type=text/css> 
.txt-b01 {
	BORDER-RIGHT: #595959 1px solid; BORDER-TOP: #FFF3CA 1px solid; FONT-SIZE: 12px; BORDER-LEFT: #dadada 1px solid; COLOR: #023361; BORDER-BOTTOM: #696a6b 1px solid; FONT-FAMILY: "����"; BACKGROUND-COLOR: #FFF3CA
}
.txt02 {
	FONT-SIZE: 12px; COLOR: #023361; FONT-FAMILY: "����"
}
.title01 {
	FONT-SIZE: 16px; COLOR: #023361; FONT-FAMILY: "����"; LETTER-SPACING: 5px
}
</STYLE>
    <title>
	��������
</title>
    <script language="VBScript">
function Su()
	  if len(trim(form1.txtPWD.value)) = 0 then
	  form1.PWW.focus()
	  msg="������"
	  msgbox msg,64,"���"
	  exit function
	  end if
form1.submit
end function
</script>
</head>
<BODY style="background-color:#FFFFFF;border:1px solid #242424;" leftMargin=0 topMargin=0  >
<form id="form1" runat="server">
 
<div class="bgcolorOcxTitle" style="border-bottom:1px solid #242424;text-indent: 2;">
�û� <span id="lblUser"></span> ����������
</div>
	<TABLE cellSpacing=0 cellpadding=4 width="100%" border=1 bordercolor="#242424" style="border-collapse:collapse;">
		<tr><input type=hidden name="LN" value="">
			<td width=100 height=45 bgcolor="#EAEAEA"><sup><font color="#ff0000">*</font></sup>����Ϊ������</td>
			<td>
                <input name="txtPWD" type="text" runat="server" maxlength="1" id="txtPWD" style="width:23px;" />
            </TD>
		</tr>
		<tr>
			<td bgcolor="#EAEAEA" align=center colspan=2>
                <asp:button id="BtnReset" runat="server" Text="�� ��" onclick="SavePassword" /></td>
		</tr>
	</TABLE>
    </form>
</body>
</html>

