<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ADR.aspx.cs" Inherits="WebApplication.SystemManage.UserList.ADR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
 
<html>
<head id="Head1"><link href="../css/table.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../My97DatePick/WdatePicker.js" charset="gb2312"></script>
    <script type="text/javascript" language=javascript>
        function fun() {
 
            alert("fdfd");
        
        }
        
    </script>
 
<STYLE type=text/css> 
 #dlgReply 
{ 
/*display: table-cell; 
text-align: center;*/ 
vertical-align: middle; 
} 
table 
{ 
margin-left: auto; 
margin-right: auto; 
} 
 
 
</STYLE>
    <title>
	重新分配
</title></head>
<body style="border:1px solid gary;" leftMargin=0 topMargin=0  >
<form ID="form1" runat="Server">
    <div style=" vertical-align:middle; height: 44px;border:1px solid gary;  text-align:center"><h2 style="height: 44px">重新分配</h2></div>
   <div id="dlgReply"> 
     <table> 
          <tr style=" line-height:20px">
                                                    <td class="style1">
                                                        当前数量：
                                                    </td>
                                                    <td colspan="3" class="style2">
                                                        <input name="txtyyl" type="text" id="txtyyl" runat="Server" style="width:164px;" />
                                                    </td>
                                                     </tr>
                                                      <tr style=" line-height:20px">
                                                    <td class="style1">
                                                        所属客服：
                                                    </td>
                                                    <td colspan="3" class="style2">
                                                        <input name="txtsskf" type="text" id="txtsskf" runat="Server" style="width:164px;" />
                                                    </td>
                                                     </tr>
                                                            <tr tyle=" line-height:30px">
                                                    <td class="style1">
                                                        客户类型：
                                                    </td>
                                                    <td colspan="3" class="style2">
                                                               <asp:DropDownList runat =server ID="DropDownList1" style="width:100;" AutoPostBack=true OnSelectedIndexChanged="SelectCaculateRecordNum"/>
                                                    </td>
                                                     </tr>
                                                                  <tr tyle=" line-height:30px">
                                                    <td class="style1">
                                                        工单类型：
                                                    </td>
                                                    <td colspan="3" class="style2">
                                                    <asp:DropDownList runat =server ID="DropDownList2" style="width:100;" AutoPostBack=true OnSelectedIndexChanged="SelectCaculateRecordNum"/>
                                                    </td>
                                                     </tr>
                                               
                                                  <tr><td colspan="3"  style=" color:Red">&nbsp;</td></tr>      
 
     <tr style=" line-height:30px">
                                                    <td class="style1">
                                                        所属部门：
                                                    </td>
                                                    <td colspan="3" class="style2">
                                                            <asp:DropDownList ID="deptment" runat="Server" AutoPostBack=true OnSelectedIndexChanged="SelectDeptment"></asp:DropDownList>
                                                    </td>
                                                     </tr>
                                                          <tr tyle=" line-height:30px">
                                                    <td class="style1">
                                                        重新分配员工：
                                                    </td>
                                                    <td colspan="3" class="style2">
                                                            <asp:DropDownList ID="DropDownListstaf" runat="Server"></asp:DropDownList>
                                                    </td>
                                                     </tr>
 
                                                       <tr tyle=" line-height:30px">
                                                    <td class="style1">
                                                        重新分配的条数：
                                                    </td>
                                                    <td colspan="3" class="style2">
                                                        <input name="txtnum" type="text" id="txtnum" runat="server" style="height:20px;width:164px;" />
                                                    </td>
                                                     </tr>
 
                                                <tr>
			<td  style=" text-align:center" colspan=2>
			 <asp:Button id="BtnSave" runat="Server" Text="重新分配" OnClick="OnBtnSaveClick" />
 
		</tr>
</table> 
</div> 
 
    </form>
</body>
</html>
