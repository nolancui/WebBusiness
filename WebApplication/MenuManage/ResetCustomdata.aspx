<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetCustomdata.aspx.cs" Inherits="WebApplication.MenuManage.ResetCustomdata" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset="utf-8" />
    <title></title>
    <script language="javascript" type="text/javascript" src="../js/My97DatePicker/WdatePicker.js"></script> 
    <link href="../js/table.css" rel="stylesheet" type="text/css" />
        <script language=javascript type=text/javascript >
            function winPW(sUrl, sTitle, sWidth, sHeight) { window.open(sUrl, '' + sTitle, 'status=no,height=' + sHeight + ',width=' + sWidth + ',toolbar=no,scrollbars=yes,menubar=no,resizable=0,location=no,top=200,left=227'); }
            function SelectAll(chkbox) {
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
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <TABLE id="TABLE1" class=search border=0 cellSpacing=0 cellPadding=0 width="100%" runat="Server">
  <TBODY>
  <TR>
    <TD class=style1>客户类型</TD>
    <TD style="MARGIN-LEFT: 40px" width=200 >
        <asp:DropDownList ID="DropDownList1" runat="Server"></asp:DropDownList></TD>
     <TD width=40 align=middle>部门</TD>
    <TD width=80><asp:DropDownList ID="deptment" runat="Server" AutoPostBack=true 
            OnSelectedIndexChanged="SelectDeptment" Height="27px" Width="98px"></asp:DropDownList>
    </TD>
    <TD width=40 align=middle>员工</TD>
    <TD style="MARGIN-LEFT: 40px" width=160><asp:DropDownList ID="DropDownListstaf" 
            runat="Server" Height="27px" Width="98px"></asp:DropDownList></TD>
    <TD width=40 align=middle>日期</TD>
    <TD width=80>
  
    <input name="BeginTime" type="text" id="BeginTime" runat=server onclick="WdatePicker()" class="Wdate"  placeholder="起始时期" />
    </TD>
    
    <TD width=40 align=middle>至</TD>
    <TD style="MARGIN-LEFT: 40px" width=80>
        <input name="EndTime" type="text" id="EndTime" runat=server onclick="WdatePicker()" class="Wdate"  placeholder="结束时期" />
</TD>
    <TD><LABEL>
          <asp:Button id=btnSearch runat="Server" class=searchbtn9 Text = 查询 type=submit name=btnSearch onclick="searchButtonClick" /> 
          <asp:Button id=Buttonreset runat="Server" class=searchbtn2 Text = 恢复 type=submit name=btnSearchreset onclick="ResetSelectedItem" Width="86px"/>
          <asp:Button id=Button_assin runat="Server" class=searchbtn9 Text = 分配 type=submit name=btnAssin onclick="ReassinButtonClick" /> 
              </LABEL>
      </TD></TR></TBODY></TABLE>
    
    <div>
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
             <asp:TemplateField>
              <HeaderTemplate>
            <asp:CheckBox id="chkAll" runat="server" onclick="SelectAll(this)" />
            </HeaderTemplate>
                <ItemTemplate>
                <asp:CheckBox ID="chkRow" runat="Server"/>
            </ItemTemplate>
            </asp:TemplateField>
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
    </div>
    </form>
</body>
</html>
