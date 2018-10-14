<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientManage.aspx.cs" Inherits="WebApplication.MenuManage.ClientManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>

    <meta charset="utf-8">
    <title></title>
    <link href="../js/table.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../js/My97DatePicker/WdatePicker.js"></script> 
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
        function winPW(sUrl, sTitle, sWidth, sHeight) { window.open(sUrl, '' + sTitle, 'status=no,height=' + sHeight + ',width=' + sWidth + ',toolbar=no,scrollbars=yes,menubar=no,resizable=0,location=no,top=200,left=227'); }

    </script>
</head>
<body >
<form id="form1" runat="Server">

<TABLE class=search border=0 cellSpacing=0 cellPadding=0>
  <TBODY>
  <TR >
    <TD width=5 align=middle><!--<img src="../images/search2.gif" />--></TD>
    <TD class=cx width=60>查询条件</TD>
    <TD style="MARGIN-LEFT: 40px" width=200><INPUT 
      onblur="if(this.value.replace(/ /ig,'')=='')this.value=this.value" 
      style="WIDTH: 214px; COLOR: gray" id=inputSearch 
      onfocus="if(this.value==this.defaultValue)this.value=''" 
      value="车牌号/客户名/手机号码/地址/品牌" type=text name=inputSearch runat ="server"></TD>
    <TD><LABEL>
     <asp:Button id=searchbutton runat="Server" class=searchbtn9 Text = 查询客户 type=submit name=btnSearch OnClientClick="if(inputSearch.value==inputSearch.defaultValue)inputSearch.value=''" onclick="searchButtonClick"/> 
     <asp:Button id=addClientButton runat="Server" class=searchbtn9 Text = 添加客户 type=submit name=btnSearch onclick="addClient"/>  
     <asp:Button id=DeleteButton runat="Server" class=searchbtn9 Text = 删除  name=btnSearch onclick="DeleteSelectedItem"/> 
    </LABEL></TD>
    <TD style="TEXT-ALIGN: right">    <asp:Button id=MutiClientAddButton runat="Server"  class=searchbtn onclick="MutiAddClientClick" Text=批量添加 />    </TD>   </TR>   </TBODY> </TABLE>

<div class="ch-container">
    <div class="row">
    
            <!-- col-md-12 -->
                <div class="box col-md-12 ">
                 <div class="box-inner" well>


                <div class="box-content well" >
            <asp:GridView ID="GridView1" runat="server" margin:0 auto AllowPaging="True" PageSize="20"
            AutoGenerateColumns="False" DataKeyNames="ID" 
            CellPadding="4" 
            ForeColor="#333333" GridLines="None" CssClass="DataGridView" 
              HorizontalAlign="Center" onrowdeleting="GridView1_RowDeleting" OnPageIndexChanging="GridView1_PageIndexChanging"
              OnSelectedIndexChanged = "OnSelectedIndexChanged" OnRowCommand="GridView1_Command" class="tablelist" align="Left" border="0" style="width:100%;border-collapse:collapse;">
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
               <asp:BoundField DataField="ClientName" HeaderText="车主" 
                    SortExpression="ClientName"
                    HeaderStyle-HorizontalAlign="Left" >
                 </asp:BoundField>
               <asp:BoundField DataField="VehicleBrand" HeaderText="品牌" 
                    SortExpression="VehicleBrand"
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
                <asp:BoundField DataField="VehicleModel" HeaderText="车型号" 
                    SortExpression="VehicleModel"
                    HeaderStyle-HorizontalAlign="Left" >
                 </asp:BoundField>
               <asp:BoundField DataField="Address" HeaderText="联系地址" 
                    SortExpression="Address"
                    HeaderStyle-HorizontalAlign="Left" >
                 </asp:BoundField>


              
              <asp:TemplateField HeaderText="查看" >
                 <ItemTemplate>   
                 <asp:ImageButton ID="edit" runat="Server" src="../images/search2.gif" CommandName ="SearchClick" CommandArgument=<%# Eval("ID")%> />
                  </ItemTemplate>  
              </asp:TemplateField>
              <asp:TemplateField HeaderText="删除" >
                 <ItemTemplate>   
                   <asp:LinkButton ID="LinkButton1" runat="server" Text="删除" CausesValidation="False" CommandName="Delete">  </asp:LinkButton>  
                   </ItemTemplate>  
              </asp:TemplateField>

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

    </body>
</html>
