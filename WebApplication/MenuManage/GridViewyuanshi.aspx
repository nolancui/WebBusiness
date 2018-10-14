<%@ Page Language="C#" AutoEventWireup="True" EnableEventValidation = "false" CodeBehind="GridViewyuanshi.aspx.cs" Inherits="WebApplication.MenuManage.GridViewyuanshi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<head id="head1" runat="server">

<meta http-equiv="Content-Type" content="text/html; charset="utf-8" />
    <title></title>
    <script language="javascript" type="text/javascript" src="../js/My97DatePicker/WdatePicker.js"></script> 
    <link href="../js/table.css" rel="stylesheet" type="text/css" />
        <script language=javascript type=text/javascript >
            function winPW(sUrl, sTitle, sWidth, sHeight) { window.open(sUrl, '' + sTitle, 'status=no,height=' + sHeight + ',width=' + sWidth + ',toolbar=no,scrollbars=yes,menubar=no,resizable=0,location=no,top=200,left=227'); }
    </script>
</head>
<body >
<form id="form1" runat="Server">
  
<TABLE class=search border=0 cellSpacing=0 cellPadding=0 width="100%" runat="Server">
  <TBODY>
  <TR>
    <TD width=5 align=middle><!--<img src="../images/search2.gif" />--></TD>
    <TD class=cx width=60>查询条件</TD>
    <TD style="MARGIN-LEFT: 40px" width=200 >
        <input id="inputSearch" runat="server" name="inputSearch" 
            onblur="if(this.value.replace(/ /ig,'')=='')this.value=this.value" 
            onfocus="if(this.value==this.defaultValue)this.value=''" 
            style="WIDTH: 214px; COLOR: gray" type="text" value="车牌号/客户名/手机号码/地址/品牌" /></TD>
    <TD width=40 align=middle>日期</TD>
    <TD width=80>
  
    <input name="BeginTime" type="text" id="BeginTime" runat=server onclick="WdatePicker()" class="Wdate"  placeholder="起始时期" />
    </TD>
    
    <TD width=40 align=middle>至</TD>
    <TD style="MARGIN-LEFT: 40px" width=80>
        <input name="EndTime" type="text" id="EndTime" runat=server onclick="WdatePicker()" class="Wdate"  placeholder="结束时期" />
</TD>
<td>
<table>
<tr> <TD width=140 align=middle>部门</TD>
    <TD><asp:DropDownList ID="deptment" runat="Server"></asp:DropDownList></TD></tr>
<tr ><td width=140 colSpan=2>
    <input id="departmentnull" runat="Server" type="checkbox" name="departmentnull" /><label for="cbdsz">含部门未指定数据</label>
    </td></tr>
</table>
</td>
   
    
      
    
  
    <TD width=160>&nbsp;&nbsp; <SPAN id="fps" runat="server"></SPAN> </TD>
    <TD><LABEL>
          <asp:Button id=btnSearch runat="Server" class=searchbtn9 Text = 查询 type=submit name=btnSearch OnClientClick="if(inputSearch.value==inputSearch.defaultValue)inputSearch.value=''" onclick="searchButtonClick" /> 
          <asp:Button id=SubmitData runat="Server" class=searchbtn2 Text = 数据分配 type=submit name=btnSearch onclick="DataFenPeiClick"/> 
    </LABEL></TD></TR></TBODY></TABLE>

<asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="20"
             AutoGenerateColumns="False" DataKeyNames="ID" 
            CellPadding="4" 
            ForeColor="#333333" GridLines="None" CssClass="DataGridView" 
              HorizontalAlign="Center" onrowdeleting="GridView1_RowDeleting" OnPageIndexChanging="GridView1_PageIndexChanging"
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
               <asp:BoundField DataField="VehicleBrand" HeaderText="品牌" 
                    SortExpression="VehicleBrand"
                    HeaderStyle-HorizontalAlign="Left" >
                 </asp:BoundField>
               <asp:BoundField DataField="ClientName" HeaderText="车主" 
                    HeaderStyle-HorizontalAlign="Left" >
                 </asp:BoundField>
               <asp:BoundField DataField="PhoneNum" HeaderText="手机" 
                    SortExpression="PhoneNum"
                    HeaderStyle-HorizontalAlign="Left" >
                 </asp:BoundField>
                <asp:BoundField DataField="RegistrationTime" HeaderText="登记日期" 
                    SortExpression="RegistrationTime"
                    HeaderStyle-HorizontalAlign="Left" >
                 </asp:BoundField>
               <asp:BoundField DataField="Expiration" HeaderText="保险到期日" 
                    SortExpression="Expiration" HtmlEncode=false DataFormatString="{0:yyyy-MM-dd}"
                    HeaderStyle-HorizontalAlign="Left" >
                 </asp:BoundField>
               <asp:BoundField DataField="Address" HeaderText="联系地址" 
                    SortExpression="Address"
                    HeaderStyle-HorizontalAlign="Left" >
                 </asp:BoundField>
              
              <asp:TemplateField HeaderText="删除" HeaderStyle-HorizontalAlign="Left">
                 <ItemTemplate>   
                   <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"  
                    Text="删除" OnClientClick='<%#  "if (!confirm(\"你确定要删除" + Eval("ClientName").ToString() + "吗?\")) return false;"%>'></asp:LinkButton>  
                   </ItemTemplate>  
              </asp:TemplateField>

             </Columns>
          </asp:GridView>

</form>


<!-- external javascript -->


    </body>
</html>
