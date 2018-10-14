<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="UserReg.aspx.cs" Inherits="WebApplication.SystemManage.UserList.UserReg" %>
<html>
 
<head>
<title  id ="titlename" runat="Server"></title>
<meta http-equiv="Content-Type" content="text/html; charset="utf-8" /><meta http-equiv="Pragma" content="no-cache" />
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
<LINK href="../com/style.css" type=text/css rel=stylesheet>
<script language=javascript src=../com/monthBirthday.js></script>
</head>
<BODY style="background-color:#FFFFFF;border:1px solid #005599;" leftMargin=0 topMargin=0  >
    <form id="form1" runat="server">
<div  class="bgcolorOcxTitle" style="border-bottom:1px solid #242424;text-indent: 2;">
<span id="lbltitle" runat="Server"> </span>�û���Ϣ
</div>
<div style="width:100%;overflow:auto;">
<TABLE cellSpacing=0 cellpadding=4 width="100%" border=1 bordercolor="#242424" style="border-collapse:collapse;">
		<tr>
			<td width=150 bgcolor="#49C0F6"><sup><font color="#ff0000">*</font></sup>�û�����</td>
			<td>
			<asp:textbox runat =server maxlength="20" id="txtLoginName" class="ServInput" size="19" />
			<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="�������û���¼��" ControlToValidate="txtLoginName"></asp:RequiredFieldValidator>
            </TD>
		</tr>
 
		<tr>
			<td bgcolor="#71CBF5"><sup><font color="#ff0000">*</font></sup>������</td>
			<td><asp:textbox runat=server maxlength="15" id="txtUserName" class="ServInput" size="19" />
			<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ErrorMessage="�������û�����" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
            </TD>
		</tr>
		<tr>
			<td bgcolor="#71CBF5"><sup><font color="#ff0000">*</font></sup>�Ա�</td>
			<td><table id="rSex" border="0">
	<tr>
	<asp:Panel ID=panelsex runat="server">
		<asp:RadioButton ID="RadioButtonSex0" runat="server" Checked=true Text="��" GroupName="GroupSex"/>
        <asp:RadioButton ID="RadioButtonSex1" runat="server" Text="Ů" GroupName="GroupSex"/>
        </asp:Panel>
        </label></td>
	</tr>
</table>
            </TD>
		<tr>
			<td bgcolor="#71CBF5"><sup><font color="#ff0000">*</font></sup>���ţ�</td>
			<td><asp:DropDownList runat =server ID="listDept" style="width:119;"/></asp:DropDownList>
            </TD>
		</tr>
		<tr>
			<td bgcolor="#71CBF5">��ϵ�绰��</td>
			<td><asp:textbox runat="server" maxlength="30" id="txtphone" class="ServInput" size="19" onkeyup="javascript:this.value=this.value.replace(/\D/gi,&quot;&quot;);" style="width:119;" />
            </TD>
		</tr>
			<tr>
			<td bgcolor="#71CBF5">�ֻ����룺</td>
			<td><asp:textbox runat="server" maxlength="30" id="txtMobile" class="ServInput" size="19" onkeyup="javascript:this.value=this.value.replace(/\D/gi,&quot;&quot;);" style="width:119;" />
            </TD>
		</tr>
		<tr>
			<td bgcolor="#71CBF5">סַ��</td>
			<td><asp:textbox runat="server" maxlength="100" id="txtAddress" class="ServInput" size="19" style="width:317px;" />
            </TD>
		</tr>
		<tr>
			<td bgcolor="#71CBF5">���֤�ţ�</td>
			<td><asp:textbox runat="server" maxlength="100" id="txtCardID" class="ServInput"  size="19" />
            </TD>
		</tr>
		<!--
		<tr>
			<td bgcolor="#EAEAEA">ѧ����</td>
			<td><select name="listSchool" id="listSchool" style="width:119;">
	<option value="0">Сѧ</option>
	<option value="1">����</option>
	<option value="2">����</option>
	<option value="3">��ר</option>
	<option value="4">��ר</option>
	<option value="5">����</option>
	<option value="6">˶ʿ</option>
	<option value="7">��ʿ</option>
	<option value="8">����</option>
 
</select>
            </TD>
		</tr>
		
		<tr>
			<td bgcolor="#EAEAEA">�������ڣ�</td>
			<td>
                <input name="txtBirthDay" type="text" id="txtBirthDay" onclick="fPopCalendar(txtBirthDay,txtBirthDay);return false" />
			</TD>
		</tr>
		-->
		<tr>
			<td bgcolor="#71CBF5">Email��</td>
			<td><asp:textbox runat="server" maxlength="50" id="txtMail" class="ServInput" name="Email" size="19" />
            </TD>
		</tr>
				<tr>
			<td> ��ע��</td>
			<td><asp:textbox runat="server" TextMode="MultiLine" id="txtMark" class="ServInput size="19" style="height:50px;width:250px;"/>
            </TD>
		</tr>
		<tr>
			<td bgcolor="#71CBF5" align=right colspan=2>
                <asp:button runat="server" ID="btnConfirm" Text="��  ��" OnClick="OnClickConfirm"/>
		</tr>
	</TABLE>
    
 
</div>
 
 
<script type="text/javascript"> 
//<![CDATA[
 
var Page_ValidationActive = false;
if (typeof(ValidatorOnLoad) == "function") {
    ValidatorOnLoad();
}
 
function ValidatorOnSubmit() {
    if (Page_ValidationActive) {
        return ValidatorCommonOnSubmit();
    }
    else {
        return true;
    }
}
        //]]>
</script>
</form>    
</body>
</html>
