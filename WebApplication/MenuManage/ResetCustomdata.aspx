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
    <TD class=style1>�ͻ�����</TD>
    <TD style="MARGIN-LEFT: 40px" width=200 >
        <asp:DropDownList ID="DropDownList1" runat="Server"></asp:DropDownList></TD>
     <TD width=40 align=middle>����</TD>
    <TD width=80><asp:DropDownList ID="deptment" runat="Server" AutoPostBack=true 
            OnSelectedIndexChanged="SelectDeptment" Height="27px" Width="98px"></asp:DropDownList>
    </TD>
    <TD width=40 align=middle>Ա��</TD>
    <TD style="MARGIN-LEFT: 40px" width=160><asp:DropDownList ID="DropDownListstaf" 
            runat="Server" Height="27px" Width="98px"></asp:DropDownList></TD>
    <TD width=40 align=middle>����</TD>
    <TD width=80>
  
    <input name="BeginTime" type="text" id="BeginTime" runat=server onclick="WdatePicker()" class="Wdate"  placeholder="��ʼʱ��" />
    </TD>
    
    <TD width=40 align=middle>��</TD>
    <TD style="MARGIN-LEFT: 40px" width=80>
        <input name="EndTime" type="text" id="EndTime" runat=server onclick="WdatePicker()" class="Wdate"  placeholder="����ʱ��" />
</TD>
    <TD><LABEL>
          <asp:Button id=btnSearch runat="Server" class=searchbtn9 Text = ��ѯ type=submit name=btnSearch onclick="searchButtonClick" /> 
          <asp:Button id=Buttonreset runat="Server" class=searchbtn2 Text = �ָ� type=submit name=btnSearchreset onclick="ResetSelectedItem" Width="86px"/>
          <asp:Button id=Button_assin runat="Server" class=searchbtn9 Text = ���� type=submit name=btnAssin onclick="ReassinButtonClick" /> 
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
            ��<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1 %>'></asp:Label>ҳ ��<asp:Label ID="Label1" runat="server" Text='<%# ((GridView)Container.Parent.Parent).Rows.Count %>'></asp:Label>��  
          /��<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount %>'></asp:Label>ҳ    
           <asp:LinkButton ID="btnFirst" runat="server" CausesValidation="False"  
              CommandName="Page" Text="��ҳ" CommandArgument="first" OnClick="btnFirst_Click">  
         </asp:LinkButton>  
           <asp:LinkButton ID="btnPrev" runat="server" CausesValidation="False"  
                CommandName="Page" Text="��һҳ" CommandArgument="prev" onclick="btnFirst_Click">  
           </asp:LinkButton>  
           <asp:LinkButton ID="btnNext" runat="server" CausesValidation="False"  
               CommandName="Page" Text="��һҳ" CommandArgument="next" OnClick="btnFirst_Click">  
            </asp:LinkButton>  
          <asp:LinkButton ID="btnLast" runat="server" CausesValidation="False"               
           CommandName="Page" Text="βҳ" CommandArgument="last" OnClick="btnFirst_Click">  
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
             <asp:TemplateField HeaderText="���">
                    <ItemTemplate>
                    <asp:Literal ID="lit" runat="server" Text="<%#Container.DataItemIndex+1%>" />
                     </ItemTemplate>
                 </asp:TemplateField> 

               <asp:BoundField DataField="CarNumber" HeaderText="����" 
                    SortExpression="CarNumber"
                    HeaderStyle-HorizontalAlign="Left" >
                 </asp:BoundField>
               <asp:BoundField DataField="VehicleBrand" HeaderText="Ʒ��" 
                    SortExpression="VehicleBrand"
                    HeaderStyle-HorizontalAlign="Left" >
                 </asp:BoundField>
               <asp:BoundField DataField="ClientName" HeaderText="����" 
                    HeaderStyle-HorizontalAlign="Left" >
                 </asp:BoundField>
               <asp:BoundField DataField="PhoneNum" HeaderText="�ֻ�" 
                    SortExpression="PhoneNum"
                    HeaderStyle-HorizontalAlign="Left" >
                 </asp:BoundField>
                <asp:BoundField DataField="RegistrationTime" HeaderText="�Ǽ�����" 
                    SortExpression="RegistrationTime"
                    HeaderStyle-HorizontalAlign="Left" >
                 </asp:BoundField>
               <asp:BoundField DataField="Expiration" HeaderText="���յ�����" 
                    SortExpression="Expiration" HtmlEncode=false DataFormatString="{0:yyyy-MM-dd}"
                    HeaderStyle-HorizontalAlign="Left" >
                 </asp:BoundField>
               <asp:BoundField DataField="Address" HeaderText="��ϵ��ַ" 
                    SortExpression="Address"
                    HeaderStyle-HorizontalAlign="Left" >
                 </asp:BoundField>
              
              <asp:TemplateField HeaderText="ɾ��" HeaderStyle-HorizontalAlign="Left">
                 <ItemTemplate>   
                   <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"  
                    Text="ɾ��" OnClientClick='<%#  "if (!confirm(\"��ȷ��Ҫɾ��" + Eval("ClientName").ToString() + "��?\")) return false;"%>'></asp:LinkButton>  
                   </ItemTemplate>  
              </asp:TemplateField>

             </Columns>
          </asp:GridView>
    </div>
    </form>
</body>
</html>
