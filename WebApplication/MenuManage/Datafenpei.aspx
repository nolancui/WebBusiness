<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation = "false" CodeBehind="Datafenpei.aspx.cs" Inherits="WebApplication.MenuManage.Datafenpei" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
 
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

<title>
	数据分配
	
	</title><meta http-equiv="Content-Type" content="text/html; charset="utf-8" />
<script language="javascript" type="text/javascript" src="../js/My97DatePicker/WdatePicker.js"></script> 
<link href="../js/table.css" rel="stylesheet" type="text/css" />
<script language=javascript src=../js/month.js></script>
<script language=javascript src=../js/func.js></script>
<SCRIPT language="javascript"> 
    function shuaxin() {
        window.top.frames['topFrame'].document.location.reload();
    }
    function winReg() {
        window.open('../SystemManage/UserList/UserReg.aspx?OperNo=ADD', '新增用户', 'status=no,height=420,width=600,toolbar=no,scrollbars=no,menubar=no,location=no,top=7,left=7,resizable=1');
    }

    function pandun() {
        alert("请选择每人分配的工单数");
    }
    

    function SelectAll(chkbox)
    {
        var box = chkbox;
        state = chkbox.checked;
        elem = box.form.elements;
        for (i = 0; i < elem.length; i++)
            if (elem[i].type == "checkbox" && elem[i].id != box.id) {
            if (elem[i].checked != state) {
                elem[i].click();
            }
        }
    }



</SCRIPT>
    <style type="text/css">
        .style1
        {
            height: 33px;
        }
    </style>
</head>
<body>
<DIV id=divWait style="visibility: hidden; WIDTH: 200px; POSITION: absolute; HEIGHT: 19px; BACKGROUND-COLOR: #ffffa3; fontSize: 10pt" align=center VALIGN="center">
<table border=1 width="100%" style="border-collapse:collapse;">
<tr style="BACKGROUND-COLOR: #ffffa3;"><td align=center><img align=absmiddle src=images/waitdiv3.gif>&nbsp;&nbsp;<b>数据查询中，请稍候……</b></td>
</tr></table>
</DIV>
 
    <form id="form1" runat="Server" style="margin:0px">
         <table width="100%" border="0" cellspacing="0" cellpadding="0" class="search">
  <tr>
    <td width="5" align="center"><!--<img src="../images/search2.gif" />--></td>
    <td width="60" class="cx">查询条件</td>
    <td width="140" style="margin-left: 40px">
 
         <input name="txttj" type="text" value="车牌号/客户名/手机号码/地址/品牌" id="txttj" style="width:140px;color:Gray" /></asp:TextBox>
        </td>
    <td width="40" align="center">日期</td>
    <td width="70"><input name="txtks" type="text" id="txtks" runat=server onclick="WdatePicker()" class="Wdate" style="height:15px;width:100px;" /></td>
    <td width="40" align="center">至</td>
    <td width="70" style="margin-left: 40px"><input name="txtjs" runat=server type="text" id="txtjs" onclick="WdatePicker()" class="Wdate" style="height:15px;width:100px;" /></td>
      <td width="120"> 
      <div>可分配总量<span id="fps" runat="Server"> </span>
      </div>
      </td>
    <TD width=80><asp:DropDownList ID="deptment" runat="Server" AutoPostBack=true OnSelectedIndexChanged="SelectDeptment"></asp:DropDownList>
    </TD>
      </td>
       <td width="40" align="center"><asp:textbox id="txtfps" runat="server" AutoPostBack=true onkeyup='javascript:this.value=this.value.replace(/\D/gi,"");' OnTextChanged="chkAll_Checkedfenpei"/></td>
    <td >
        <label>
               <asp:button id="Button1" text="分配" runat="server" class="searchbtn2" onclick="ArrangeCustomers" />
        </label>
      </td>
    </tr>
</table>
<div style="float:left">
    <TABLE cellSpacing=0 cellpadding=0 width="100%"  border=0 align="center" class="ntable">
  <tr style="width:300px">
  <td style="font-weight:bold; height:40px; width:auto">
      添加员工
        </td>
      <td style="font-weight:bold; height:40px; width:auto">所属员工名称</td>
  </tr>
  <tr>
  <td class="style1" style=" vertical-align:middle">
        <asp:Button id="addNewUser" Text="添加员工" OnClientClick =winReg() runat="Server" class="searchbtn"/>
        <span id="lbtishi" runat="server" style="display:inline-block;height:33px;color:Red"></span>

</td>
  <td class="style1"></td>
  </tr>
  <tr>
   <td></td>
   <td style="width:200px;">
   <div>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="20"
     AutoGenerateColumns="False" DataKeyNames="ID" class="tablelist" align="Left" border="0" style="width:100%;border-collapse:collapse;">
      <Columns>
            <asp:TemplateField >
      <HeaderTemplate>
      <asp:CheckBox id="chkAll" runat="server" onclick="SelectAll(this)" AutoPostBack="True" OnCheckedChanged="chkAll_Checkedfenpei" />
       </HeaderTemplate>
          <ItemStyle HorizontalAlign="Center" Height="35px" Width="50px"/>
          <ItemTemplate>
          <asp:CheckBox  ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="chkAll_Checkedfenpei"></asp:CheckBox>   
          </ItemTemplate> 
          </asp:TemplateField>

               <asp:BoundField DataField="UserName" HeaderText="员工姓名" 
                    HeaderStyle-HorizontalAlign="Center" >
                 </asp:BoundField>
                 </Columns>
   
   </asp:GridView>
	
</div>
   </td>
  </tr>
  </TABLE>  
  </div>
  <div> 
      </div>
    </form>
</body>
</html>
