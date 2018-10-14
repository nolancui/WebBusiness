 <%@ Page Language="C#" AutoEventWireup="True" EnableEventValidation = "false" CodeBehind="UserInfoSet.aspx.cs" Inherits="WebApplication.SystemManage.UserList.UserInfoSet" %>
<html >
<head>
<script language="javascript" type="text/javascript" src="../../js/My97DatePicker/WdatePicker.js"></script> 
<script language="Javascript">
function showhide(){
   
   if(document.getElementById("changepass1").style.display== "none")
   {
      document.getElementById("changepass1").style.display="";
      document.all.txtPassFlag.value ="1";
      document.all.btnchangepass.value ="隐藏密码修改";
   }
   else
   {
        document.getElementById("changepass1").style.display= "none"
        document.all.txtPassFlag.value ="0";
        document.all.btnchangepass.value ="显示密码修改";
   }  
   if(document.getElementById("changepass2").style.display== "none")
   {
      document.getElementById("changepass2").style.display="";
   }
   else
   {
        document.getElementById("changepass2").style.display= "none"
   }  
   
   if(document.getElementById("changepass3").style.display== "none")
   {
      document.getElementById("changepass3").style.display="";
   }
   else
   {
        document.getElementById("changepass3").style.display= "none"
   }  
   
   if(document.getElementById("changepass4").style.display== "none")
   {
      document.getElementById("changepass4").style.display="";
   }
   else
   {
        document.getElementById("changepass4").style.display= "none"
   }  
 }
 </script>
<title>
	个人信息设置
</title></head>
<BODY style="BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none" leftMargin=0 topMargin=0 onload="" marginheight="0" marginwidth="0" >
<div class="pagetitle">
&nbsp;修改个人信息
</div>
    <form id="form1" runat="server">

<TABLE cellSpacing=0 cellpadding=4 width="100%" border=1 bordercolor="#005599" style="border-collapse:collapse;">
	<tr valign =top id ="changepass1">
	
			<td bgcolor="#FFF3CA"><sup><font color="#ff0000" >*</font></sup>原密码：</td>
			<td><input name="txtOldPass" type="password" maxlength="20" id="txtOldPass" runat="server" class="ServInput" style="width:119" />
             
                  <input name="txtPassFlag" type="text" id="txtPassFlag" style="width:1px;VISIBILITY:hidden" />
            </TD>
		</tr>
		<tr valign =top id ="changepass2">
			<td bgcolor="#FFF3CA"><sup><font color="#ff0000">*</font></sup>登录密码：</td>
			<td><input name="txtPassWord1" type="password" maxlength="20" id="txtPassWord1" runat=server class="ServInput" style="width:119" />（至少6位）
 
            </TD>
		</tr>
		<tr id ="changepass3">
			<td bgcolor="#FFF3CA"><sup><font color="#ff0000">*</font></sup>确认密码：</td>
			<td><input name="txtPassWord2" type="password" maxlength="20" id="txtPassWord2" runat="server" class="ServInput" style="width:119" />
               </TD>
		</tr>
		<tr  id ="changepass4"  >
            
			
			<td colspan=2 align=center>
			
                <asp:button id="btnMdfPass" runat="server" Text="修改密码" onclick="RefinePassword" />
		
            </TD>
		</tr>
		<tr>
			<td bgcolor="#FFF3CA"><sup><font color="#ff0000">*</font></sup>姓名：</td>
			<td><input name="txtUserName" type="text" runat="server" maxlength="15" id="txtUserName" class="ServInput" size="19" />
                    <input id="btnchangepass" type="button" value="隐藏密码修改" onclick ="showhide();" />
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="请输入用户姓名" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
            </TD>
		</tr>
		
		<tr>
			<td bgcolor="#FFF3CA"><sup><font color="#ff0000">*</font></sup>性别：</td>
			<td><table id="rSex" border="0">
	<tr>
		<td><asp:Panel ID=panelsex runat="server">
		<asp:RadioButton ID="RadioButtonSex0" runat="server" Checked=true Text="男" GroupName="GroupSex"/>
        <asp:RadioButton ID="RadioButtonSex1" runat="server" Text="女" GroupName="GroupSex"/>
        </asp:Panel></td>
	</tr>
</table>
            </TD>
		<tr>
			<td bgcolor="#FFF3CA"><sup><font color="#ff0000">*</font></sup>部门：</td>
			<td><asp:DropDownList ID="deptment" runat="Server"></asp:DropDownList>
            </TD>
		</tr>
		<tr>
			<td bgcolor="#FFF3CA"><sup><font color="#ff0000">*</font></sup>联系电话：</td>
			<td><input name="txtphone" type="text" runat="server" maxlength="30" id="txtphone" class="ServInput" size="19" onkeyup="javascript:this.value=this.value.replace(/\D/gi,&quot;&quot;);" style="width:119;" />
               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ErrorMessage="请输入电话" ControlToValidate="txtphone"></asp:RequiredFieldValidator>
            </TD>
		</tr>
			<tr>
			<td bgcolor="#FFF3CA">手机号码：</td>
			<td><input name="txtMobile" type="text" maxlength="30" runat="server" id="txtMobile" class="ServInput" size="19" onkeyup="javascript:this.value=this.value.replace(/\D/gi,&quot;&quot;);" style="width:119;" />
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ErrorMessage="请输入正确的手机格式" ControlToValidate="txtMobile"></asp:RequiredFieldValidator>
            </TD>
		</tr>
		<tr>
			<td bgcolor="#FFF3CA">住址：</td>
			<td><input name="txtAddress" type="text" runat="server" maxlength="100" id="txtAddress" class="ServInput"  size="19" style="width:317px;" />
            </TD>
		</tr>
		<tr>
			<td bgcolor="#FFF3CA">身份证号：</td>
			<td><input name="txtCardID" type="text" runat="server" maxlength="100" id="txtCardID" class="ServInput"  size="19" />
            </TD>
		</tr>
		<tr>
			<td bgcolor="#FFF3CA">学历：</td>
			<td><asp:DropDownList ID="listSchool" runat="Server" Width="119"></asp:DropDownList>
            </TD>
		</tr>
		<tr>
			<td bgcolor="#FFF3CA">出生日期：</td>
			<td>
			    <input id="txtBirthDay" type="text" runat=server onclick="WdatePicker()" class="Wdate" />
			</TD>
		</tr>
		<tr>
			<td bgcolor="#FFF3CA">Email：</td>
			<td><input name="txtMail" type="text" maxlength="50" id="txtMail" runat="server" class="ServInput"  size="19" />
            </TD>
		</tr>
 
		<tr>
			<td bgcolor="#A3CEEC" align=center colspan=2>
                <asp:button id="btnConfirm" Text="修改用户信息"  runat="server" onclick="RefineUserInf" />
                </td>
		</tr>
	</TABLE>

</form>
</body>
</html>

