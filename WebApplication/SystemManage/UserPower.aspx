<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="UserPower.aspx.cs" Inherits="WebApplication.SystemManage.UserPower" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3c.org/TR/1999/REC-html401-19991224/loose.dtd">
<HTML xmlns="http://www.w3.org/1999/xhtml"><HEAD><TITLE>�û�����</TITLE>
<meta http-equiv="Content-Type" content="text/html; charset="utf-8" /><LINK 
rel=stylesheet type=text/css href="UserPower/table.css">
<SCRIPT language=javascript src="UserPower/func.js"></SCRIPT>

<SCRIPT language=javascript src="UserPower/stylefunc.js"></SCRIPT>

<SCRIPT language=javascript>
function winReg() {
    window.open('UserList/UserReg.aspx?OperNo=ADD', '�����û�', 'status=no,height=420,width=600,toolbar=no,scrollbars=no,menubar=no,location=no,top=7,left=7,resizable=1');
}
function winPW(sUrl,sTitle,sWidth,sHeight) {
	window.open(sUrl,''+sTitle,'status=no,height='+sHeight+',width='+sWidth+',toolbar=no,scrollbars=no,menubar=no,resizable=0,location=no,top=200,left=227');
}

function winPM1(sUrl, spara, sTitle, sWidth, sHeight) {
    winPW(sUrl + spara, sTitle, sWidth, sHeight);
}
function test(id,stitile,swidth,sheight)
{
    var strtest = "UserList/UserReg.aspx?UserID=" + id + "";
    winPW(strtest, stitile, swidth, sheight);

    alert("test hello world");

}
function fun() {
    alert("ɾ���ɹ�");

}
</SCRIPT>

<META name=GENERATOR content="MSHTML 8.00.7601.19104"></HEAD>
<BODY>
<form id="form1" runat="Server"> 
<TABLE border=0 cellSpacing=0 cellPadding=0 width="100%" runat="Server">
  <TBODY>
  <TR>
    <TD noWrap>
      <DIV class=toolbar>
      <DIV 
      class=tableinfo><SPAN><!--<img src="../imagesPng/1.png" />--></SPAN><B 
      style="TEXT-ALIGN: left; MARGIN-LEFT: -10px">�û�����</B></DIV>
      <DIV style="FLOAT: left">
      <DIV id=paneladd>
      <UL class=btnlist>
        <LI><A style="CURSOR: hand" onclick=winReg();><SPAN><IMG alt=�����û� 
        src="UserPower/btn02.gif"></SPAN>�����û�</A></LI></UL></DIV></DIV></DIV>
<TABLE class=search border=0 cellSpacing=0 cellPadding=0 width="100%">
  <TBODY>
  <TR>
    <TD width=5 align=middle><!--<img src="../images/search2.gif" />--></TD>
    <TD class=cx width=60>��ѯ����</TD>
    <TD width=160>���ţ�<asp:DropDownList ID="deptment" runat="Server"></asp:DropDownList></TD>
    <TD width=150>�û�����<asp:textbox id=txtLoginName runat ="server" class=searchinput1/></TD>
    <TD width=120>������<asp:textbox id=txtUserName class=searchinput1 runat =server/></TD>
    <TD width=80>
    <asp:DropDownList ID=ListUserStatus runat="server">
    <asp:ListItem Selected=True Value=-1>����</asp:ListItem>
    <asp:ListItem Value=0>����</asp:ListItem>
    <asp:ListItem Value=1>����</asp:ListItem>
    </asp:DropDownList></TD>
    <TD><LABEL><asp:Button id=BtnSearch runat=Server Text ="��ѯ" OnClick="OnSearchStaf"/> 
      </LABEL></TD></TR></TBODY></TABLE>
      </TD></TR></TBODY></TABLE>
<asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="20"
            AutoGenerateColumns="False" DataKeyNames="ID" 
            CellPadding="4" 
            ForeColor="#333333" GridLines="None" CssClass="DataGridView" 
              HorizontalAlign="Center" onrowdeleting="GridView1_RowDeleting" OnPageIndexChanging="GridView1_PageIndexChanging"
               OnRowCommand="GridView1_Command" class="tablelist" align="Left" border="0" style="width:100%;border-collapse:collapse;">
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
        <asp:TemplateField HeaderText="���" HeaderStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                    <asp:Literal ID="lit" runat="server" Text="<%#Container.DataItemIndex+1%>" />
                     </ItemTemplate>
                 </asp:TemplateField> 
             <asp:TemplateField HeaderText="����" HeaderStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                    <asp:ImageButton ID="arrange" runat="Server" src="UserPower/tp.gif" CommandName ="ArrangeRole" CommandArgument=<%# Eval("ID")%> />
                     </ItemTemplate>
                 </asp:TemplateField> 
               <asp:BoundField DataField="UserName" HeaderText="�û���" 
                    SortExpression="UserName"
                    HeaderStyle-HorizontalAlign="Left" >
                 </asp:BoundField>
               <asp:BoundField DataField="Authority" HeaderText="Ա������" 
                    SortExpression="Authority"
                    HeaderStyle-HorizontalAlign="Left" >
                 </asp:BoundField>
               <asp:BoundField DataField="OrderOfDay" HeaderText="����ԤԼ��" 
                SortExpression="OrderOfDay"
                    HeaderStyle-HorizontalAlign="Left" >
                 </asp:BoundField>
               <asp:BoundField DataField="AllOrder" HeaderText="��ԤԼ��" 
                    SortExpression="AllOrder"
                    HeaderStyle-HorizontalAlign="Left" >
                 </asp:BoundField>
                <asp:BoundField DataField="UserIdentifier" HeaderText="����" 
                    SortExpression="UserIdentifier"
                    HeaderStyle-HorizontalAlign="Left" >
                 </asp:BoundField>
               <asp:BoundField DataField="Deptment" HeaderText="����" 
                    SortExpression="Deptment"
                    HeaderStyle-HorizontalAlign="Left" >
                 </asp:BoundField>
                 <asp:BoundField DataField="Enabled"
                    SortExpression="Enabled" Visible=false>
                 </asp:BoundField>
               <asp:TemplateField HeaderText="��������" HeaderStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                    <asp:ImageButton ID="restpassword" runat="Server" src="UserPower/i_password.gif" CommandName="Resetpass" CommandArgument=<%# Eval("ID")%> />
                     </ItemTemplate>
                 </asp:TemplateField> 
              <asp:TemplateField HeaderText="���·���" HeaderStyle-HorizontalAlign="Left">
                    <ItemTemplate> 
                    <asp:ImageButton ID="rearrange" runat="Server" src="UserPower/tp.gif" CommandName="ReArrange" CommandArgument=<%# Eval("ID")%> />
                     </ItemTemplate>
                 </asp:TemplateField> 
                 <asp:TemplateField HeaderText="ɾ��" HeaderStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                    <asp:ImageButton ID="delete" runat="Server" src="UserPower/del.gif" CausesValidation="False" CommandName="Delete"  
                    OnClientClick='<%#  "if (!confirm(\"��ȷ��Ҫɾ��" + Eval("UserName").ToString() + "��?\")) return false;"%>'/>
                     </ItemTemplate>
                 </asp:TemplateField> 
                 <asp:TemplateField HeaderText="����" HeaderStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                    <asp:Button ID="manage" runat="Server" Text='<%# Eval("Enabled") %>' CommandName="Btmanage" CommandArgument='<%# Eval("ID")+","+Eval("Enabled") %>'/>
                     </ItemTemplate>
                 </asp:TemplateField> 
                 <asp:TemplateField HeaderText="�޸�" HeaderStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                    <asp:ImageButton ID="edit" runat="Server" src="UserPower/set2.gif" CommandName ="RegEdit" CommandArgument=<%# Eval("ID")%> />
                     </ItemTemplate>
                 </asp:TemplateField> 

             </Columns>
      </asp:GridView>
      </form>
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
      </BODY></HTML>
