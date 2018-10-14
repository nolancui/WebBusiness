
<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ADRwuxiao.aspx.cs" Inherits="WebApplication.MenuManage.ADRwuxiao" %>

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
	无效
</title></head>
<body style="border:1px solid gary;" leftMargin=0 topMargin=0  >
    <form id="form1" runat="server">
    <div style=" vertical-align:middle; height: 44px;border:1px solid gary;"><h2 style="height: 44px">
        无效</h2></div>
   <div id="dlgReply"> 
     <table border=1> 
       <tr>
                                                    <td class="style1">
                                                        无效原因：
                                                    </td>
                                                    <td colspan="3" class="style2">
                                                        <input id="ch" runat="server" type="checkbox" name="ch" /><label for="ch">错号</label>
                                                         <input id="kh" runat="server" type="checkbox" name="kh" /><label for="kh">空号</label>
                                                          <input id="gh" runat="server" type="checkbox" name="gh" /><label for="gh">过户</label>
                                                      

                                                    </td>
                                                     </tr>
                                                     <tr><td></td></tr>
                                                   
                                                    <tr style=" line-height:60px">
                                                    <td class="style1">
                                                        其它原因：
                                                    </td>
                                                    <td colspan="3" class="style2">
                                                       
                                                          <textarea name="txtwuxiao" runat="server" rows="2" cols="20" id="txtwuxiao" class="addtext" style="height:50px;width:295px;">
</textarea>
                                                      
                                                    </td>
                                                </tr>
                                                <tr>
			<td  style=" text-align:right" colspan=3>
			<asp:button id="BtnSave" runat="server" Text="确   定" class="searchbtn" OnClick="OnEnsure" /></td>
		</tr>
</table> 
</div> 

    </form>
</body>
</html>
