<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation = "false" CodeBehind="MutiAddClient.aspx.cs" Inherits="WebApplication.MenuManage.MutiAddClient" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
 
<html>
<head id="Head1"><link href="../js/table.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../My97DatePick/WdatePicker.js" charset="gb2312"></script>
<STYLE type=text/css> 
 
</STYLE>
    <title>
	批量导入
</title></head>
<BODY style="border:1px solid gary;" leftMargin=0 topMargin=0  >
    <form name="form1"  id="form1" runat=server>
 
    <div style=" vertical-align:middle; height: 44px;border:1px solid gary;"><h2 style="height: 44px">批量导入</h2></div>
	<TABLE  cellpadding=4 width="100%" border=1 style="border-collapse:collapse;">
		<tr><input type=hidden name="LN" value="">
			<td width=100   style=" text-align:center">批量导入：</td>
			<td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
            <td>部门：</td>
                 <td><asp:DropDownList ID="deptment" runat="Server"></asp:DropDownList>
                 </td>
		<tr>
			<td align=center colspan=4>
			<asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="导入" /></td>
		</tr>
	</TABLE>
    </form>
</body>
</html>