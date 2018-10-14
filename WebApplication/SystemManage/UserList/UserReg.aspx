<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="UserReg.aspx.cs" Inherits="WebApplication.SystemManage.UserList.UserReg" %>
<html>
 
<head>
<title  id ="titlename" runat="Server"></title>
<meta http-equiv="Content-Type" content="text/html; charset="utf-8" /><meta http-equiv="Pragma" content="no-cache" />
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
<LINK href="../com/style.css" type=text/css rel=stylesheet>
<script language=javascript src=../com/monthBirthday.js></script>
</head>
<BODY style="background-color:#FFFFFF;border:1px solid #005599;" leftMargin=0 topMargin=0  >
    <form id="form1" runat="server">
<div  class="bgcolorOcxTitle" style="border-bottom:1px solid #242424;text-indent: 2;">
<span id="lbltitle" runat="Server"> </span>用户信息
</div>
<div style="width:100%;overflow:auto;">
<TABLE cellSpacing=0 cellpadding=4 width="100%" border=1 bordercolor="#242424" style="border-collapse:collapse;">
		<tr>
			<td width=150 bgcolor="#49C0F6"><sup><font color="#ff0000">*</font></sup>用户名：</td>
			<td>
			<asp:textbox runat =server maxlength="20" id="txtLoginName" class="ServInput" size="19" />
			<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="请输入用户登录名" ControlToValidate="txtLoginName"></asp:RequiredFieldValidator>
            </TD>
		</tr>
 
		<tr>
			<td bgcolor="#71CBF5"><sup><font color="#ff0000">*</font></sup>姓名：</td>
			<td><asp:textbox runat=server maxlength="15" id="txtUserName" class="ServInput" size="19" />
			<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ErrorMessage="请输入用户姓名" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
            </TD>
		</tr>
		<tr>
			<td bgcolor="#71CBF5"><sup><font color="#ff0000">*</font></sup>性别：</td>
			<td><table id="rSex" border="0">
	<tr>
	<asp:Panel ID=panelsex runat="server">
		<asp:RadioButton ID="RadioButtonSex0" runat="server" Checked=true Text="男" GroupName="GroupSex"/>
        <asp:RadioButton ID="RadioButtonSex1" runat="server" Text="女" GroupName="GroupSex"/>
        </asp:Panel>
        </label></td>
	</tr>
</table>
            </TD>
		<tr>
			<td bgcolor="#71CBF5"><sup><font color="#ff0000">*</font></sup>部门：</td>
			<td><asp:DropDownList runat =server ID="listDept" style="width:119;"/></asp:DropDownList>
            </TD>
		</tr>
		<tr>
			<td bgcolor="#71CBF5">联系电话：</td>
			<td><asp:textbox runat="server" maxlength="30" id="txtphone" class="ServInput" size="19" onkeyup="javascript:this.value=this.value.replace(/\D/gi,&quot;&quot;);" style="width:119;" />
            </TD>
		</tr>
			<tr>
			<td bgcolor="#71CBF5">手机号码：</td>
			<td><asp:textbox runat="server" maxlength="30" id="txtMobile" class="ServInput" size="19" onkeyup="javascript:this.value=this.value.replace(/\D/gi,&quot;&quot;);" style="width:119;" />
            </TD>
		</tr>
		<tr>
			<td bgcolor="#71CBF5">住址：</td>
			<td><asp:textbox runat="server" maxlength="100" id="txtAddress" class="ServInput" size="19" style="width:317px;" />
            </TD>
		</tr>
		<tr>
			<td bgcolor="#71CBF5">身份证号：</td>
			<td><asp:textbox runat="server" maxlength="100" id="txtCardID" class="ServInput"  size="19" />
            </TD>
		</tr>
		<!--
		<tr>
			<td bgcolor="#EAEAEA">学历：</td>
			<td><select name="listSchool" id="listSchool" style="width:119;">
	<option value="0">小学</option>
	<option value="1">初中</option>
	<option value="2">高中</option>
	<option value="3">中专</option>
	<option value="4">大专</option>
	<option value="5">本科</option>
	<option value="6">硕士</option>
	<option value="7">博士</option>
	<option value="8">其它</option>
 
</select>
            </TD>
		</tr>
		
		<tr>
			<td bgcolor="#EAEAEA">出生日期：</td>
			<td>
                <input name="txtBirthDay" type="text" id="txtBirthDay" onclick="fPopCalendar(txtBirthDay,txtBirthDay);return false" />
			</TD>
		</tr>
		-->
		<tr>
			<td bgcolor="#71CBF5">Email：</td>
			<td><asp:textbox runat="server" maxlength="50" id="txtMail" class="ServInput" name="Email" size="19" />
            </TD>
		</tr>
				<tr>
			<td> 备注：</td>
			<td><asp:textbox runat="server" TextMode="MultiLine" id="txtMark" class="ServInput size="19" style="height:50px;width:250px;"/>
            </TD>
		</tr>
		<tr>
			<td bgcolor="#71CBF5" align=right colspan=2>
                <asp:button runat="server" ID="btnConfirm" Text="提  交" OnClick="OnClickConfirm"/>
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
