<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepAdd.aspx.cs" Inherits="WebApplication.SystemManage.DeptManager.DepAdd" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3c.org/TR/1999/REC-html401-19991224/loose.dtd">
<!-- saved from url=(0072)http://120.55.240.108:8088/DeptManager/DepAdd.aspx -->
<HTML xmlns="http://www.w3.org/1999/xhtml"><HEAD  runat="server"><TITLE>DepAdd</TITLE>
<META content=no-cache http-equiv=Pragma><LINK rel=stylesheet type=text/css 
href="DepAdd/style.css"><LINK rel=stylesheet type=text/css 
href="DepAdd/table.css">
<STYLE type=text/css>.style1 {
	HEIGHT: 21px
}
.style2 {
	HEIGHT: 27px
}
</STYLE>

<META name=GENERATOR content="MSHTML 8.00.7601.19104"></HEAD>
<BODY 
style="BORDER-BOTTOM: #b9ddec 1px solid; BORDER-LEFT: #b9ddec 1px solid; BACKGROUND-COLOR: #ffffff; FONT-SIZE: 12px; BORDER-TOP: #b9ddec 1px solid; BORDER-RIGHT: #b9ddec 1px solid" 
background="" leftMargin=0 topMargin=0>
<form id="form1" runat="server" style="margin:0px" >
<SCRIPT type=text/javascript src="DepAdd/WebResource.axd"></SCRIPT>

<SCRIPT type=text/javascript src="DepAdd/WebResource(1).axd"></SCRIPT>


<DIV style="WIDTH: 100%" class=tableinfo><SPAN><!--<img src="../imagesPng/1.png" />--></SPAN><B>��λ����<DIV> </DIV>
    </B></DIV>
<DIV style="PADDING-LEFT: 11px; WIDTH: 100%" class=tableinfo><B><SPAN 
style="FONT-SIZE: 12px" id=lblTitle>�༭��λ</SPAN> </B></DIV>
<TABLE style="BORDER-COLLAPSE: collapse; FONT-SIZE: 12px" border=0 cellSpacing=0 
cellPadding=5 width="100%">
  <TBODY>
  <TR>
    <TD class=style2 width=100 align=right>�ϼ���λ�� </TD>
    <TD style="MARGIN-LEFT: 40px" class=style2 bgColor=#ffffff>
    <asp:DropDownList ID="ListParentDept" runat="server" Width="300px"></asp:DropDownList>
    </TD></TR>
  <TR>
    <TD width=100 align=right>��λ���ƣ� </TD>
    <TD class=style1><asp:textbox runat=server Width="300px" id=txtDeptName 
      class=searchinput1/> 
      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="����д��λ���ƣ�" ControlToValidate="txtDeptName"></asp:RequiredFieldValidator>
             </TD></TR>
  <TR>
    <TD width=100 align=right>��λ�쵼�� </TD>
    <TD bgColor=#ffffff><asp:textbox runat=server Width="300px" id=txtDeptLeader 
      class=searchinput1/> </TD></TR>
  <TR>
    <TD width=100 align=right>�� ���� </TD>
    <TD bgColor=#ffffff><asp:textbox runat=server Width="300px" id=txtDeptTel 
      class=searchinput1 
      onkeyup='javascript:this.value=this.value.replace(/\D/gi,"");'/> </TD></TR>
    <TD width=100 align=right>�� �棺 </TD>
    <TD bgColor=#ffffff><asp:textbox runat=server Width="300px" id=txtDeptTax 
      class=searchinput1 
      onkeyup='javascript:this.value=this.value.replace(/\D/gi,"");'/> </TD></TR>
  <TR>
    <TD width=100 align=right>�� ���� </TD>
    <TD bgColor=#ffffff><asp:textbox runat=server Width="300px" id=txtDeptPerson 
      class=searchinput1 
      onkeyup='javascript:this.value=this.value.replace(/\D/gi,"");'/> </TD></TR>
  <TR>
    <TD width=100 align=right>�� �� </TD>
    <TD bgColor=#ffffff><asp:textbox runat=server Width="300px" id=txtOrder 
      class=searchinput1 
      onkeyup='javascript:this.value=this.value.replace(/\D/gi,"");' 
      /> </TD></TR>
  <TR>
    <TD width=100 align=right>�� ַ�� </TD>
    <TD bgColor=#ffffff><asp:textbox runat=server Width="300px" id=txtDeptAddress 
      class=searchinput1 name=txtDeptAddress/> </TD></TR>
  <TR>
    <TD width=100 align=right>�� ע�� </TD>
    <TD bgColor=#ffffff>
    <asp:TextBox ID="txtDeptMemo" runat="server" Height="50px" Width="300px" TextMode="MultiLine"></asp:TextBox>
    </TD></TR>
  <TR>
    <TD colSpan=2 align=right>
<%--     <asp:Button ID=BtnSave runat=server Text = "����" OnClick="OnClickAdd"  />--%>
    <asp:Button ID=BtnAdd runat=server Text = "+����" OnClick="OnClickAdd"  OnClientClick="javascript:return   confirm('��ȷ��Ҫ������λ��');" />
<%--   <asp:Button ID=BtnConfirm runat=server Text="�ύ" OnClick="OnClickConfirm"/>--%>
    <asp:Button ID=BtnDel runat=server Text="xɾ��" OnClick="OnClickDel" OnClientClick="javascript:return   confirm('���Ҫɾ����');" />
    </TD></TR>
  <TR>
    <TD colSpan=2 align=right>&nbsp;</TD></TR></TBODY></TABLE>

<SCRIPT type=text/javascript>
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
</SCRIPT>
</form></BODY></HTML>
