<%@ Page Language="C#" AutoEventWireup="True" EnableEventValidation = "false" CodeBehind="ADRAuditing.aspx.cs" Inherits="WebApplication.BaseShearch.ADRAuditing" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3c.org/TR/1999/REC-html401-19991224/loose.dtd">
<HTML xmlns="http://www.w3.org/1999/xhtml"><HEAD id=Head1><TITLE>客户管理</TITLE>
<meta http-equiv="Content-Type" content="text/html; charset="utf-8" />
<script language="javascript" type="text/javascript" src="../js/My97DatePicker/WdatePicker.js"></script> 
<link href="../js/table.css" rel="stylesheet" type="text/css" />
<script language=javascript src=../js/month.js></script>
<script language=javascript src=../js/func.js></script>

<SCRIPT language=javascript type=text/javascript>

    function chengg(id) {   

        popwin2('ADRdaying.aspx?id=' + id + '', 700, 350, '打印');
    }
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
    
   function winPW(sUrl,sTitle,sWidth,sHeight) {window.open(sUrl,''+sTitle,'status=no,height='+sHeight+',width='+sWidth+',toolbar=no,scrollbars=yes,menubar=no,resizable=0,location=no,top=200,left=227');}
      function showalert(strpara){alert(strpara);}

</SCRIPT>

<META name=GENERATOR content="MSHTML 8.00.7601.19104"></HEAD>
<BODY>
<DIV 
style="POSITION: absolute; BACKGROUND-COLOR: #ffffa3; WIDTH: 200px; HEIGHT: 19px; VISIBILITY: hidden; fontSize: 10pt" 
id=divWait align=center VALIGN="center">
<TABLE style="BORDER-COLLAPSE: collapse" border=1 width="100%">
  <TBODY>
  <TR style="BACKGROUND-COLOR: #ffffa3">
    <TD align=middle><IMG align=absMiddle 
      src="ADRAuditing_files/waitdiv3.gif">&nbsp;&nbsp;<B>数据查询中，请稍候……</B></TD></TR></TBODY></TABLE></DIV>
<FORM id=form1 runat="server"><%--action=ADRAuditing.aspx?zt=0--%>

<TABLE class=search border=0 cellSpacing=0 cellPadding=0 width="100%">
  <TBODY>
  <TR style="VERTICAL-ALIGN: middle">
    <TD width=5 align=middle><!--<img src="../images/search2.gif" />--></TD>
    <TD class=cx width=60>查询条件</TD>
    <TD style="MARGIN-LEFT: 40px" width=200><INPUT 
      onblur="if(this.value.replace(/ /ig,'')=='')this.value=this.value" 
      style="WIDTH: 214px; COLOR: gray" id=txttj 
      onfocus="if(this.value==this.defaultValue)this.value=''" 
      value="车牌号/客户名/手机号码/地址/品牌" type=text name=txttj runat ="server"></TD>
    <TD width=40 align=middle>日期</TD>
    <TD width=80><INPUT style="WIDTH: 100px; HEIGHT: 15px" id=txtks 
      class=Wdate onclick=WdatePicker() type=text name=txtks runat ="server"></TD>
    <TD width=40 align=middle>至</TD>
    <TD style="MARGIN-LEFT: 40px" width=80><INPUT 
      style="WIDTH: 100px; HEIGHT: 15px" id=txtjs class=Wdate 
      onclick=WdatePicker() type=text name=txtjs runat ="server"></TD>
    <TD width=40 align=middle>客服</TD>
    <TD width=110>
    <asp:DropDownList runat =server ID="servicelist" style="width:100;"/>
    </TD>
    <TD width=100>
    <asp:DropDownList runat =server ID="DropDownList1" style="width:100;"/></TD>
    <TD width=100>
<select name="insurer" id="drtb" runat=server  style="height:20px;width:107px;">
    <option value="无">无</option>
	<option value="人保">人保</option>
	<option value="平安">平安</option>
	<option value="太保">太保</option>
	<option value="人寿">人寿</option>
	<option value="阳光">阳光</option>
	<option value="中华联合">中华联合</option>
	<option value="大地">大地</option>
	<option value="永诚">永诚</option>
    </select>
    </TD>
    <TD width=100>
    <asp:DropDownList runat =server ID="DropDownList2" style="width:100;"/></TD>
    <TD><LABEL><asp:button id="btnSearch" runat="server" class=searchbtn2 OnClientClick="if(txttj.value==txttj.defaultValue)txttj.value=''" onclick="searchButtonClick" Text="查询客户" /> 
<asp:button id=Button1 class=searchbtn Text="Excel" runat="server"/> 
      </LABEL><asp:button class=searchbtn  runat="server" Text="打印" id="Button2" OnClick="ButtonTicketPrint" />
    </TD></TR></TBODY></TABLE>
    <div class="ch-container">
    <div class="row">
    
            <!-- col-md-12 -->
                <div class="box col-md-12 ">
                 <div class="box-inner" well>


                <div class="box-content well" >
 <asp:GridView id="gridview1" runat="server"
      AllowPaging="True" PageSize="20"
                         AutoGenerateColumns="False" DataKeyNames="ID" 
            CellPadding="4" 
            ForeColor="#333333" GridLines="None" CssClass="DataGridView" 
              HorizontalAlign="Center" 
              OnRowCommand="GridView1_Command" class="tablelist" align="Left" border="0" style="width:100%;border-collapse:collapse;">
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
              <RowStyle BackColor="#EFF3FB" Wrap="false" />
             <PagerStyle BackColor="#FFCC66" ForeColor="#333333" 
                           HorizontalAlign="Center" />
             <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#507CD1" />
             <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Wrap="false"/>
                <EditRowStyle BackColor="#2461BF" />
             <AlternatingRowStyle BackColor="White" />
       <Columns>
                   <asp:TemplateField >
      <HeaderTemplate>
      <asp:CheckBox id="chkAll" runat="server" onclick="SelectAll(this)" />
       </HeaderTemplate>
          <ItemStyle HorizontalAlign="Center" Height="35px" Width="50px"/>
          <ItemTemplate>
          <asp:CheckBox  ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckSelect"></asp:CheckBox>   
          </ItemTemplate> 
          </asp:TemplateField>
                      <asp:TemplateField HeaderText="序号">
                    <ItemTemplate>
                    <asp:Literal ID="lit" runat="server" Text="<%#Container.DataItemIndex+1%>" />
                     </ItemTemplate>
                 </asp:TemplateField> 
               <asp:BoundField DataField="CarNumber" HeaderText="车牌" 
                    SortExpression="CarNumber">
                 </asp:BoundField>
               
                <asp:BoundField DataField="ClientName" HeaderText="客户名" 
                    SortExpression="ClientName" >
                 </asp:BoundField>
               <asp:BoundField DataField="OwnedService" HeaderText="客服" 
                    SortExpression="OwnedService" >
                 </asp:BoundField>
                  <asp:BoundField DataField="PhoneNum" HeaderText="手机" 
                    SortExpression="PhoneNum" >
                 </asp:BoundField>
                  <asp:BoundField DataField="CommitTime" HeaderText="提交时间" 
                    SortExpression="CommitTime">
                 </asp:BoundField>
                  <asp:BoundField DataField="State" HeaderText="状态" 
                    SortExpression="State" >
                 </asp:BoundField>
                  <asp:BoundField DataField="CustomerType" HeaderText="客户类型" 
                    SortExpression="CustomerType" >
                 </asp:BoundField>
                  <asp:BoundField DataField="InsuranceCompany" HeaderText="投保公司" 
                    SortExpression="InsuranceCompany" >
                 </asp:BoundField>
                  <asp:BoundField DataField="PayManner" HeaderText="付款方式" 
                    SortExpression="PayManner" >
                 </asp:BoundField>
                  <asp:BoundField DataField="Appointment" HeaderText="预约时间" 
                    SortExpression="Appointment" >
                 </asp:BoundField>
                  <asp:BoundField DataField="Address" HeaderText="联系地址" 
                    SortExpression="Address" >
                 </asp:BoundField>
                 <asp:TemplateField HeaderText="添加">
                    <ItemTemplate>
                    <asp:ImageButton ID="add" runat="Server" src="../images/add.gif" CommandName ="AddToUser" CommandArgument=<%# Eval("ID")%> OnClientClick="javascript:return   confirm('你确认添加当前客户');"/>
                     </ItemTemplate>
                 </asp:TemplateField> 
                 <asp:TemplateField HeaderText="无效">
                    <ItemTemplate>
                    <asp:ImageButton ID="invalidate" runat="Server" src="../images/go.gif" CommandName ="InvalidataRecord" CommandArgument=<%# Eval("ID")%> OnClientClick="javascript:return   confirm('你确认要设置为无效');" />
                     </ItemTemplate>
                 </asp:TemplateField> 
                 <asp:TemplateField HeaderText="退回">
                    <ItemTemplate>
                    <asp:ImageButton ID="revert" runat="Server" src="../images/arow1.gif" CommandName ="RevertRecord" CommandArgument=<%# Eval("ID")%>  OnClientClick="javascript:return   confirm('你确认要退回');"/>
                     </ItemTemplate>
                 </asp:TemplateField> 
                 <asp:TemplateField HeaderText="查看">
                    <ItemTemplate>
                    <asp:ImageButton ID="view" runat="Server" src="../images/search2.gif" CommandName ="ViewDetail" CommandArgument=<%# Eval("ID")%> />
                     </ItemTemplate>
                 </asp:TemplateField> 
                 <asp:TemplateField HeaderText="删除">
                    <ItemTemplate>
                    <asp:ImageButton ID="delete" runat="Server" src="../images/gb1.gif" CommandName="DeleteItem" CommandArgument=<%# Eval("ID")%>  OnClientClick="javascript:return   confirm('你确认要删除');"/>
                     </ItemTemplate>
                 </asp:TemplateField> 
             </Columns>
      </asp:GridView>
                      </div>
                </div>
                </div>
            </div><!--/row-->
    </div><!--/#content.col-lg-10 col-sm-10-->
      </FORM></BODY></HTML>
