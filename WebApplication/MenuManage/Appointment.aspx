<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Appointment.aspx.cs" Inherits="WebApplication.MenuManage.Appointment" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head id="Head1">
<meta http-equiv="Content-Type" content="text/html; charset="utf-8" />
<script language="javascript" type="text/javascript" src="../js/My97DatePicker/WdatePicker.js"></script> 
<link href="../js/table.css" rel="stylesheet" type="text/css" />
<script language=javascript src=../js/month.js></script>
<script language=javascript src=../js/func.js></script>

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
	预约
</title></head>
<body style="border:1px solid gary;" leftMargin=0 topMargin=0  >
    <form name="form1" id="form1" runat=server>
    <div style=" vertical-align:middle; height: 44px;border:1px solid gary;"><h2 style="height: 44px">预约</h2></div>
   <div id="dlgReply"> 
     <table> 
       <tr>
           <td class="style1">
               客户类型：
           </td>
           <td colspan="3" class="style2">
             <select name="drkhlx"  runat=server id="drkhlx" style="width:170px;">
	         <option value="无">无</option>
	         <option value="A">A</option>
	         <option value="B">B</option>
	         <option value="C">C</option>
	         <option value="D">D</option>
	         <option value="E">E</option>
             </select>
            </td>
       </tr>
      <tr style=" line-height:60px">
      <td class="style1">
          预约时间：
      </td>
      <td colspan="3" class="style2">
         
          <input name="txttime" type="text" id="txttime" runat=server  class="Wdate" onclick="WdatePicker({dateFmt:&#39;yyyy-MM-dd HH:mm:ss&#39;})" style="height:20px;width:166px;text-align:left;" />
        
      </td>
       </tr>
       <tr>
			<td  style=" text-align:right" colspan=2>
			<asp:Button id="BtnSave" Text="确定" runat="server" OnClick="AppointmentButtonClick" class="searchbtn" />
             </td>
		</tr>
</table> 
</div> 

    </form>
</body>
</html>
