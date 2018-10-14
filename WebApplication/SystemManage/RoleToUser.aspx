<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="RoleToUser.aspx.cs" Inherits="WebApplication.SystemManage.RoleToUser" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<!-- saved from url=(0064)http://120.55.240.108:8088/RolePower/RoleToUser.aspx -->
<HTML><HEAD><TITLE>角色对应用户信息</TITLE>
<meta http-equiv="Content-Type" content="text/html; charset="utf-8" />
<META content=no-cache http-equiv=Pragma>

<STYLE>.over {
	BORDER-BOTTOM: buttonshadow 1px solid; BORDER-LEFT: buttonhighlight 1px solid; BACKGROUND-COLOR: buttonface; BORDER-TOP: buttonhighlight 1px solid; BORDER-RIGHT: buttonshadow 1px solid
}
normal {
	BACKGROUND-COLOR: buttonface
}
.overbutton {
	BORDER-BOTTOM: buttonshadow 1px solid; BORDER-LEFT: buttonhighlight 1px solid; BACKGROUND-COLOR: buttonface; BORDER-TOP: buttonhighlight 1px solid; BORDER-RIGHT: buttonshadow 1px solid
}
.downbutton {
	BORDER-BOTTOM: buttonhighlight 1px solid; BORDER-LEFT: buttonshadow 1px solid; BACKGROUND-COLOR: buttonface; BORDER-TOP: buttonshadow 1px solid; BORDER-RIGHT: buttonhighlight 1px solid
}
.out {
	BACKGROUND-COLOR: #ffffff
}
.tdbig {
	COLOR: #003366; FONT-WEIGHT: bold
}
</STYLE>


<META name=GENERATOR content="MSHTML 8.00.7601.19104"></HEAD>
<BODY>
<TABLE style="BORDER-COLLAPSE: collapse" border=0 cellSpacing=0 
borderColor=#005599 cellPadding=4 width="100%">
<FORM id=form1 runat="server">
  <TBODY>
  <TR>
    <TD vAlign=top>
      <FIELDSET><LEGEND><B>具有该角色用户列表</B></LEGEND>
      
      <asp:GridView id="gridview1" runat="server"
      AllowPaging="True" PageSize="20"
             AutoGenerateColumns="False" DataKeyNames="ID" 
            CellPadding="4" 
            ForeColor="#333333" GridLines="None" CssClass="DataGridView" 
              HorizontalAlign="Center" OnRowCommand="GridView1_Command" border="0" style="width:100%;border-collapse:collapse;">
              
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
              <RowStyle BackColor="#EFF3FB" />
             <PagerStyle BackColor="#FFCC66" ForeColor="#333333" 
                           HorizontalAlign="Center" />
             <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#507CD1" />
             <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
             <AlternatingRowStyle BackColor="White" />
       <Columns>
               <asp:BoundField DataField="UserName" HeaderText="用户名" 
                    SortExpression="UserName"
                    HeaderStyle-HorizontalAlign="left" >
                 </asp:BoundField>
               
                <asp:BoundField DataField="UserIdentifier" HeaderText="用户姓名" 
                    SortExpression="UserIdentifier"
                    HeaderStyle-HorizontalAlign="left" >
                 </asp:BoundField>
               <asp:BoundField DataField="Deptment" HeaderText="部门信息" 
                    SortExpression="Deptment"
                    HeaderStyle-HorizontalAlign="left" >
                 </asp:BoundField>
                  <asp:TemplateField HeaderText="取消该角色" HeaderStyle-HorizontalAlign="left">
                 <ItemTemplate>   
                   <asp:LinkButton ID="CancleRole" runat="server" CausesValidation="False" ForeColor="Red" CommandName="CancleRole" CommandArgument=<%# Eval("ID")%>
                    Text="取消该角色"></asp:LinkButton>  
                   </ItemTemplate>  
              </asp:TemplateField>
             </Columns>
      </asp:GridView>
      </FIELDSET> </TD></TR>
  <TR>
    <TD vAlign=top>
      <FIELDSET ><LEGEND><B>未分配角色用户列表</B></LEGEND>
      <asp:GridView id="gridview2" runat="server"
      AllowPaging="True" PageSize="20"
             AutoGenerateColumns="False" DataKeyNames="ID" 
            CellPadding="4" 
            ForeColor="#333333" GridLines="None" CssClass="DataGridView" 
              HorizontalAlign="Center" OnRowCommand="GridView1_Command" border="0" style="width:100%;border-collapse:collapse;">
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
              <RowStyle BackColor="#EFF3FB" />
             <PagerStyle BackColor="#FFCC66" ForeColor="#333333" 
                           HorizontalAlign="Center" />
             <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#507CD1" />
             <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
             <AlternatingRowStyle BackColor="White" />
       <Columns>
               <asp:BoundField DataField="UserIdentifier" HeaderText="用户名" 
                    SortExpression="UserIdentifier"
                    HeaderStyle-HorizontalAlign="left" >
                 </asp:BoundField>
               
                <asp:BoundField DataField="UserName" HeaderText="用户姓名" 
                    SortExpression="UserName"
                    HeaderStyle-HorizontalAlign="left" >
                 </asp:BoundField>
               <asp:BoundField DataField="Deptment" HeaderText="部门信息" 
                    SortExpression="Deptment"
                    HeaderStyle-HorizontalAlign="left" >
                 </asp:BoundField>
                 
                   <asp:TemplateField HeaderText="修改" HeaderStyle-HorizontalAlign="left">
                 <ItemTemplate>   
                   <asp:LinkButton ID="CancleRole" runat="server"  CausesValidation="False" ForeColor="Red" CommandName="ArrangeRole" CommandArgument=<%# Eval("ID")%>
                    Text="分配该角色"></asp:LinkButton>  
                   </ItemTemplate>  
              </asp:TemplateField>
             </Columns>
      </asp:GridView>
      </FIELDSET> 
</TD></TR></FORM></TBODY></TABLE></TABLE></BODY></HTML>
