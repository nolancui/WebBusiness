<%@ Page Language="C#" AutoEventWireup="True" EnableEventValidation = "false" CodeBehind="MinDanChuli.aspx.cs" Inherits="WebApplication.MenuManage.MinDanChuli" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta charset="utf-8">
    <title></title>
 <meta http-equiv="Content-Type" content="text/html; charset="utf-8" />
    <link href="../js/table.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../js/My97DatePicker/WdatePicker.js"></script> 
    <link rel="shortcut icon" href="../Charisma/img/favicon.ico">
    <script language=javascript type=text/javascript >
        function winPW(sUrl, sTitle, sWidth, sHeight) { window.open(sUrl, '' + sTitle, 'status=no,height=' + sHeight + ',width=' + sWidth + ',toolbar=no,scrollbars=yes,menubar=no,resizable=0,location=no,top=200,left=227'); }
    </script>
</head>
<body >
<form id="form1" runat="Server">

<table width="100%" border="0" cellspacing="0" cellpadding="0" class="search" runat="Server">
  <tr>
    <td width="5" align="center"><!--<img src="../images/search2.gif" />--></td>
    <td width="60" class="cx">查询条件</td>
        <TD style="MARGIN-LEFT: 40px" width=200><INPUT 
      onblur="if(this.value.replace(/ /ig,'')=='')this.value=this.value" 
      style="WIDTH: 214px; COLOR: gray" id=txttj 
      onfocus="if(this.value==this.defaultValue)this.value=''" 
      value="车牌号/客户名/手机号码/地址/品牌" type=text name=txttj runat ="server"></TD>
        <td width="20"></td>
     <td width="100">
    <select name="drgdlx" id="drgdlx" runat="Server" style="width:100px;">
	<option selected="selected" value="--名单状态--">--名单状态--</option>
	<option value="预约">预约</option>
	<option value="未处理">未处理</option>
	<option value="失败">失败</option>
	<option value="成功">成功</option>
	<option value="需修改">需修改</option>
	<option value="无效">无效</option>

</select></td>
<td width="20"></td>
        <td width="100">
    <select name="drkhlx" id="drkhlx" runat="Server" style="width:100px;">
	<option selected="selected" value="--客户类型--">--客户类型--</option>
	<option value="A">A</option>
	<option value="B">B</option>
	<option value="C">C</option>
	<option value="D">D</option>
	<option value="E">E</option>
	<option value="F">F</option>

</select></td>
    <td width="40" align="center">日期</td>
    <td width="80"><input name="txtks" type="text" id="txtks" runat=server onclick="WdatePicker()" class="Wdate" style="height:16px;width:120px;" /></td>
    <td width="40" align="center">至</td>
    <td width="80" style="margin-left: 40px"><input name="txtjs" type="text" id="txtjs" runat=server onclick="WdatePicker()" class="Wdate" style="height:16px;width:120px;" /></td>
    <td ><label>
        <asp:Button id=btnSearch runat="Server" class=searchbtn9 Text = 查询 type=submit name=btnSearch OnClientClick="if(txttj.value==txttj.defaultValue)txttj.value=''" onclick="searchButtonClick" />
        <asp:Button id=AddClient runat="Server" class=searchbtn9 Text = 添加客户 type=submit name=btnSearch onclick="AddClientClick" />
       </label>
      </td>
    </tr>
</table>


<div class="ch-container">
    <div class="row">
    
            <!-- col-md-12 -->
                <div class="box col-md-12 ">
                 <div class="box-inner" well>


                <div class="box-content well" >
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="20"
              DataKeyNames="ID" AutoGenerateColumns="False" 
            CellPadding="4" 
            ForeColor="#333333" GridLines="None" CssClass="DataGridView" 
              HorizontalAlign="Center" onrowdeleting="GridView1_RowDeleting" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_Command"
              OnSelectedIndexChanged = "OnSelectedIndexChanged" class="tablelist" align="Left" border="0" style="width:100%;border-collapse:collapse;">
              
              <PagerTemplate>  
   <table width="100%" style="font-size:12px;">  
        <tr>  
       <td style="text-align: left">  
            第<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1 %>'></asp:Label>页 共<asp:Label ID="Label1" runat="server" Text='<%# ((GridView)Container.Parent.Parent).Rows.Count %>'></asp:Label>条  
          /共<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount %>'></asp:Label>页    
           <asp:LinkButton ID="btnFirst" runat="server" CausesValidation="False"  
              CommandName="Page" Text="首页" CommandArgument="first" OnClick="btnFirst_Click">  
         </asp:LinkButton>  
           <asp:LinkButton ID="btnPrev" runat="server" CausesValidation="False"  
                CommandName="Page" Text="上一页" CommandArgument="prev" onclick="btnFirst_Click">  
           </asp:LinkButton>  
           <asp:LinkButton ID="btnNext" runat="server" CausesValidation="False"  
               CommandName="Page" Text="下一页" CommandArgument="next" OnClick="btnFirst_Click">  
            </asp:LinkButton>  
          <asp:LinkButton ID="btnLast" runat="server" CausesValidation="False"               
           CommandName="Page" Text="尾页" CommandArgument="last" OnClick="btnFirst_Click">  
           </asp:LinkButton>  
          <asp:TextBox ID="txtNewPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1 %>'  
               Width="30px" AutoPostBack="True"   
          ontextchanged="txtNewPageIndex_TextChanged"></asp:TextBox>
           <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="go"  
             CommandName="Page" Text="GO" OnClick="btnFirst_Click"></asp:LinkButton>  
      </td>  
       </tr>  
    </table>  
</PagerTemplate>  



              <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
              <RowStyle BackColor="#EFF3FB" />
             <PagerStyle BackColor="#FFCC66" ForeColor="#333333" 
                           HorizontalAlign="Center" />
             <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#507CD1" />
             <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
             <AlternatingRowStyle BackColor="White" />
             
             <Columns>
              <asp:TemplateField HeaderText="序号">
                    <ItemTemplate>
                    <asp:Literal ID="lit" runat="server" Text="<%#Container.DataItemIndex+1%>" />
                     </ItemTemplate>
                 </asp:TemplateField> 
               <asp:BoundField DataField="CarNumber" HeaderText="车牌" 
                    SortExpression="CarNumber"
                    HeaderStyle-HorizontalAlign="Left" >
                 </asp:BoundField>
               <asp:BoundField DataField="ClientName" HeaderText="车主" 
                    SortExpression="ClientName"
                    HeaderStyle-HorizontalAlign="Left" >
                 </asp:BoundField>
               <asp:BoundField DataField="VehicleIdentification" HeaderText="车架号" 
                    SortExpression="VehicleIdentification"
                    HeaderStyle-HorizontalAlign="Left" >
                 </asp:BoundField>
               <asp:BoundField DataField="CustomerType" HeaderText="客户类型" 
                    SortExpression="CustomerType"
                    HeaderStyle-HorizontalAlign="Left" >
                 </asp:BoundField>
                <asp:BoundField DataField="OwnedService" HeaderText="客服" 
                    SortExpression="OwnedService"
                    HeaderStyle-HorizontalAlign="Left" >
                 </asp:BoundField>
               <asp:BoundField DataField="State" HeaderText="名单状态" 
                    SortExpression="State"
                    HeaderStyle-HorizontalAlign="Left" >
                 </asp:BoundField>
               <asp:BoundField DataField="PhoneNum" HeaderText="手机" 
                    SortExpression="PhoneNum"
                    HeaderStyle-HorizontalAlign="Left" >
                 </asp:BoundField>
                 <asp:BoundField DataField="Expiration" HeaderText="保险到期日期" 
                    SortExpression="Expiration" HtmlEncode=false DataFormatString="{0:yyyy-MM-dd}"
                    HeaderStyle-HorizontalAlign="Left" >
                 </asp:BoundField>
                 <asp:BoundField DataField="Appointment" HeaderText="预约时间" 
                    SortExpression="Appointment"
                    HeaderStyle-HorizontalAlign="Left" >
                 </asp:BoundField>
              <asp:TemplateField HeaderText="处理" HeaderStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                    <asp:ImageButton ID="handle" runat="Server" src="../images/m5.gif" CommandName ="Handle" CommandArgument=<%# Eval("ID")%> />
                     </ItemTemplate>
                 </asp:TemplateField> 
                 
                 <%--<td class="tdright" align="center">
 
      <a href="javascript:popwin('../ADRAuditing/serach.aspx?id=1447294&zt=1',900, 1200,'')"; title="操作">
            <img src="../images/m5.gif" width="16" height="16" border=0 title="操作"></a>
        </td>--%>

             <%-- <asp:TemplateField HeaderText="处理" >
                 <ItemTemplate>   
                   <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete">  </asp:LinkButton>  
                   </ItemTemplate>  
              </asp:TemplateField>--%>

             </Columns>
          </asp:GridView>
                </div>
                </div>
                </div>
            </div><!--/row-->
    </div><!--/#content.col-lg-10 col-sm-10-->


</div><!--/fluid-row-->

</div><!--/.fluid-container-->
</form>


<!-- external javascript -->

 <script src="../Charisma/bower_components/jquery/jquery.min.js"></script>
<script src="../Charisma/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
<script src="bower_components/bootstrap/dist/js/bootstrap.min.js"></script>

<!-- library for cookie management -->
<script src="../Charisma/js/jquery.cookie.js"></script>
<!-- calender plugin -->
<script src='../Charisma/bower_components/moment/min/moment.min.js'></script>
<script src='../Charisma/bower_components/fullcalendar/dist/fullcalendar.min.js'></script>
<!-- data table plugin -->
<script src='../Charisma/js/jquery.dataTables.min.js'></script>

<!-- select or dropdown enhancer -->
<script src="../Charisma/bower_components/chosen/chosen.jquery.min.js"></script>
<!-- plugin for gallery image view -->
<script src="../Charisma/bower_components/colorbox/jquery.colorbox-min.js"></script>
<!-- notification plugin -->
<script src="../Charisma/js/jquery.noty.js"></script>
<!-- library for making tables responsive -->
<script src="bower_components/responsive-tables/responsive-tables.js"></script>
<!-- star rating plugin -->
<script src="../Charisma/js/jquery.raty.min.js"></script>
<!-- for iOS style toggle switch -->
<script src="../Charisma/js/jquery.iphone.toggle.js"></script>
<!-- autogrowing textarea plugin -->
<script src="../Charisma/js/jquery.autogrow-textarea.js"></script>
<!-- multiple file upload plugin -->
<script src="../Charisma/js/jquery.uploadify-3.1.min.js"></script>
<!-- history.js for cross-browser state change on ajax -->
<script src="../Charisma/js/jquery.history.js"></script>
<!-- application script for Charisma demo -->
<script src="../Charisma/js/charisma.js"></script>

    </body>
</html>
