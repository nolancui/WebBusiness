<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="FenpeiDelete.aspx.cs" Inherits="WebApplication.MenuManage.FenpeiDelete" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3c.org/TR/1999/REC-html401-19991224/loose.dtd">
<!-- saved from url=(0055)http://120.55.240.108:8088/ADRAuditing/ADRfpdelete.aspx -->
<HTML xmlns="http://www.w3.org/1999/xhtml"><HEAD id=Head1><TITLE>原始数据删除</TITLE>
<meta http-equiv="Content-Type" content="text/html; charset="utf-8" />
<script language="javascript" type="text/javascript" src="../js/My97DatePicker/WdatePicker.js"></script> 
<link href="../js/table.css" rel="stylesheet" type="text/css" />
<script language=javascript src=../js/month.js></script>
<script language=javascript src=../js/func.js></script>

<script language="javascript">
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
<META name=GENERATOR content="MSHTML 8.00.7601.19104"></HEAD>
<BODY>
<DIV 
style="POSITION: absolute; BACKGROUND-COLOR: #ffffa3; WIDTH: 200px; HEIGHT: 19px; VISIBILITY: hidden; fontSize: 10pt" 
id=divWait align=center VALIGN="center">
<TABLE style="BORDER-COLLAPSE: collapse" border=1 width="100%">
  <TBODY>
  <TR style="BACKGROUND-COLOR: #ffffa3">
    <TD align=middle><IMG align=absMiddle 
      src="ADRfpdelete/waitdiv3.gif">&nbsp;&nbsp;<B>数据查询中，请稍候……</B></TD></TR></TBODY></TABLE></DIV>
<FORM style="MARGIN: 0px" id="form1" runat="Server">
<TABLE class=search border=0 cellSpacing=0 cellPadding=0 width="100%">
  <TBODY>
  <TR>
    <TD width=5 align=middle><!--<img src="../images/search2.gif" />--></TD>
    <TD class=cx width=60>删除月份</TD>
    <TD style="MARGIN-LEFT: 40px" width=110><INPUT 
      style="WIDTH: 100px; HEIGHT: 16px" id=txtyf class=Wdate runat="Server" 
      onclick="WdatePicker({startDate:'%y/%M',dateFmt:'yyyy-MM'});" type=text 
      name=txtyf> </TD>
    <TD width=40 align=middle>部门</TD>
    <TD width=80><asp:DropDownList ID="deptment" runat="Server" AutoPostBack=true OnSelectedIndexChanged="SelectDeptment"></asp:DropDownList>
    </TD>
    
    <TD width=40 align=middle>员工</TD>
    <TD style="MARGIN-LEFT: 40px" width=80><asp:DropDownList ID="DropDownListstaf" runat="Server"></asp:DropDownList></TD>
 <asp:Button id="SearchButton" Text="查询" runat="server" OnClick="SearchButtonClick" />
    <asp:Button id="DeleteButton" Text="删除" runat="Server" OnClick ="DeleteButtonClick" />
      </TD></TR></TBODY></TABLE>

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
             
             <asp:TemplateField >
      <HeaderTemplate>
      <asp:CheckBox id="chkAll" runat="server" onclick="SelectAll(this)" />
       </HeaderTemplate>
          <ItemStyle HorizontalAlign="Center" Height="35px" Width="50px"/>
          <ItemTemplate>
          <asp:CheckBox  ID="chkRow" runat="server"></asp:CheckBox>   
          </ItemTemplate> 
          </asp:TemplateField>
            <asp:TemplateField HeaderText="序号" HeaderStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                    <asp:Literal ID="lit" runat="server" Text="<%#Container.DataItemIndex+1%>" />
                     </ItemTemplate>
                 </asp:TemplateField> 
               <asp:BoundField DataField="OwnedService" HeaderText="员工名称" 
                    HeaderStyle-HorizontalAlign="Left" >
                 </asp:BoundField>
               <asp:BoundField DataField="UnhandleNum" HeaderText="未处理数量" 
                    HeaderStyle-HorizontalAlign="Left" >
                 </asp:BoundField>
               <asp:BoundField DataField="AssignTime" HeaderText="月份" 
                    HeaderStyle-HorizontalAlign="Left" >
                 </asp:BoundField>
               <asp:BoundField DataField="State" HeaderText="状态" 
                    SortExpression="State"
                    HeaderStyle-HorizontalAlign="Left" >
                 </asp:BoundField>
              
              <asp:TemplateField HeaderText="删除" HeaderStyle-HorizontalAlign="Left">
                 <ItemTemplate>   
                   <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" CommandArgument=<%# Eval("AssignTime")%>
                    Text="删除" OnClientClick='<%#  "if (!confirm(\"你确定要删除" + Eval("OwnedService").ToString() + "吗?\")) return false;"%>'></asp:LinkButton>  
                   </ItemTemplate>  
              </asp:TemplateField>

             </Columns>
          </asp:GridView>
      </form></BODY></HTML>
