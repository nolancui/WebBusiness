<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="RolePower.aspx.cs" Inherits="WebApplication.SystemManage.RolePower" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<!-- saved from url=(0051)http://120.55.240.108:8088/RolePower/RolePower.aspx -->
<HTML><head id="Head1" runat="server"><TITLE>角色管理</TITLE>
<meta http-equiv="Content-Type" content="text/html; charset="utf-8" />
<META content=no-cache http-equiv=Pragma><LINK rel=stylesheet type=text/css 
href="RolePower/style.css">
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
<LINK rel=stylesheet type=text/css href="RolePower/table.css">
<SCRIPT language=javascript>
function winPW() {
	window.open('RoleInfoAdd.aspx?OperNo=ADD','','status=no,height=160,width=340,toolbar=no,scrollbars=no,menubar=no,location=no,top=7,left=7,resizable=1');
	
} 
function RefreshFrame(surl)
{
frameuserpower.location.href=srul;
} 
//获取元素指定tagName的父元素 
function public_GetParentByTagName(element, tagName){ 
    var parent = element.parentNode; 
    var upperTagName = tagName.toUpperCase(); 
    //如果这个元素还不是想要的tag就继续上溯 
    while (parent && (parent.tagName.toUpperCase() != upperTagName)) 
    { 
      parent = parent.parentNode ? parent.parentNode : parent.parentElement; 
    } 
    return parent; 
} 

//设置节点的父节点Cheched——该节点可访问，则他的父节点也必能访问 
function setParentChecked(objNode) { 
    var objParentDiv = public_GetParentByTagName(objNode, "div"); 
    if(objParentDiv==null || objParentDiv == "undefined") 
    { 
      return; 
    } 
    var objID = objParentDiv.getAttribute( "ID"); 
    objID = objID.substring(0,objID.indexOf( "Nodes")); 
    objID = objID+ "CheckBox"; 
    var objParentCheckBox = document.getElementById(objID); 
    if(objParentCheckBox==null || objParentCheckBox == "undefined") 
    { 
      return; 
    } 
    if(objParentCheckBox.tagName!= "INPUT" && objParentCheckBox.type == "checkbox") 
    return; 
    objParentCheckBox.checked = true; 
    setParentChecked(objParentCheckBox); 
} 

//设置节点的父节点uncheched——检查父节点的所有子节点是否都没有选中，如果没有则取消父节点的选中状态
function setParentUnChecked(objNode){
    var objParentDiv = public_GetParentByTagName(objNode, "div"); 

    if(objParentDiv==null || objParentDiv == "undefined") 
    { 
      return; 
    }
    var objID = objParentDiv.getAttribute( "ID"); 
    objID = objID.substring(0,objID.indexOf( "Nodes")); 
    objID = objID+ "CheckBox"; 
    var objParentCheckBox = document.getElementById(objID); 
    if(objParentCheckBox==null || objParentCheckBox == "undefined") 
    { 
      return; 
    } 
    if(objParentCheckBox.tagName!= "INPUT" && objParentCheckBox.type == "checkbox") 
        return; 
    
    //parent.mainFrame.document.getElementById("textarea").value =objParentDiv.innerHTML;
    
    var objchild = objParentDiv.getElementsByTagName('INPUT'); ; 
    var count = objchild.length; 

    var ischeck = false;
    for(var i=0;i <objchild.length;i++) 
    { 
      var tempObj = objchild[i]; 
      if(tempObj.tagName== "INPUT" && tempObj.type == "checkbox" && tempObj.checked) 
      {         
        ischeck = true;
        return;
      } 
    } 
    
    objParentCheckBox.checked = ischeck;  
    setParentUnChecked(objParentCheckBox); 
}

//设置节点的子节点uncheched——该节点不可访问，则他的子节点也不能访问 
function setChildUnChecked(divID) 
{ 
    var objchild = divID.children; 
    var count = objchild.length; 
    for(var i=0;i <objchild.length;i++) 
    { 
      var tempObj = objchild[i]; 
      if(tempObj.tagName== "INPUT" && tempObj.type == "checkbox") 
      { 
        tempObj.checked = false; 
      } 
      setChildUnChecked(tempObj); 
    } 
} 

//设置节点的子节点cheched——该节点可以访问，则他的子节点也都能访问 
function setChildChecked(divID) 
{
    //alert(divID.innerHTML);
    //parent.mainFrame.document.getElementById("textarea").value =divID.innerHTML;
    var objchild = divID.children; 
    var count = objchild.length; 
    for(var i=0;i <objchild.length;i++) 
    { 
      var tempObj = objchild[i]; 
      if(tempObj.tagName== "INPUT" && tempObj.type == "checkbox") 
      { 
        tempObj.checked = true; 
      } 
      setChildChecked(tempObj); 
    } 
} 

//触发事件 
function CheckEvent(){ 
    var objNode = event.srcElement;
    if(objNode.tagName!= "INPUT" || objNode.type!= "checkbox") 
        return; 
    
    //选中
    if(objNode.checked==true){ 
        setParentChecked(objNode); 
        var objID = objNode.getAttribute("ID"); 
            objID = objID.substring(0,objID.indexOf( "CheckBox"));
        var objParentDiv = document.getElementById(objID+ "Nodes"); 
        if(objParentDiv==null || objParentDiv == "undefined"){
            return; 
        } 
        setChildChecked(objParentDiv); 
    }else{ //取消选中
        var objID = objNode.getAttribute("ID"); 
            objID = objID.substring(0,objID.indexOf("CheckBox")); 
        var objParentDiv = document.getElementById(objID+ "Nodes"); 

        if(objParentDiv!=null && objParentDiv != "undefined") { 
            setChildUnChecked(objParentDiv);
        }
        setParentUnChecked(objNode);
    } 
} 

//显示选中的节点
function ShowCheck(){
  var inputs = document.getElementsByTagName("input");
  var result = "";
  //parent.mainFrame.document.getElementById("textarlea").value = document.body.innerHTML;
  for(var i=inputs.length-1;i>=0;i--)
  {
    if(inputs[i].type=="checkbox"&& inputs[i].checked==true)
    {
    var title = inputs[i].nextSibling.title;
    if(result.indexOf(title)==-1){
      result += title+",";
      alert(result);
    }
    }
  }
  result = result.substring(0,result.length-1);
  return result;
}
    

function BtnAdd_onclick() {

}
function SetTreeNodeClickHander(treeID)
{
    var objs = document.getElementsByTagName("input");
    for(var i=0;i<objs.length;i++)
    {
        if(objs[i].type=='checkbox')
        {
            var obj=objs[i];
            if(obj.id.indexOf(treeID)!=-1)
            {
                objs[i].onclick=function(){TreeSingleSelect(treeID,this);};
            }
        }
    }
}
function TreeSingleSelect(treeID,checkNode)
{
    if(!treeID)
    return;
    var objs = document.getElementsByTagName("input");
    for(var i=0;i<objs.length;i++)
    {
        if(objs[i].type=='checkbox')
        {
            var obj=objs[i];
            if(obj.id.indexOf(treeID)!=-1)
            {
            }
        }
    }    
}
function CheckDelete()
{
   if(document.all.listRole.value =="-999")
   {
     alert("请选择要删除的角色");
     return false;
   }
   return   confirm('真的要删除吗？');
}
function getaUrl(aID)
{
   var aUrl=  document.getElementById(aID);
   
   for(var i=0;i<aUrl.length;i++)
   {
       if(aUrl[i].type=="href")
       {
            
       }
   } 
}
</SCRIPT>



<META name=GENERATOR content="MSHTML 8.00.7601.19104"></HEAD>
<BODY 
style="BORDER-BOTTOM: #005599 1px solid; BORDER-LEFT: #005599 1px solid; BACKGROUND-COLOR: #ffffff; BORDER-TOP: #005599 1px solid; BORDER-RIGHT: #005599 1px solid" 
leftMargin=0 topMargin=0>
<FORM id=form1 runat="Server">


<TABLE style="BORDER-BOTTOM: #242424 1px solid; TEXT-INDENT: 2px" 
class=bgcolorOcxTitle width="100%">
  <TBODY>
  <TR>
    <TD class=tdbig>系统管理——角色管理</TD>
    <TD align=right>
      <DIV id=paneladd><BUTTON id=BtnAdd runat="Server" onclick=winPW();><IMG border=0 
      align=absMiddle src="RolePower/add2.gif"> 新增角色</BUTTON> <!--<input id="BtnAdd" type="button" value="新增角色" onclick="winPW();" onclick="return BtnAdd_onclick()" />--></DIV></TD></TR></TBODY></TABLE>
<TABLE border=0 cellSpacing=0 cellPadding=0 width="100%">
  <TBODY>
  <TR vAlign=top>
    <TD vAlign=top>
      <TABLE class=table_1 border=0 cellSpacing=0 cellPadding=2 width="100%">
        <TBODY>
        <TR>
          <TD height=22 noWrap>&nbsp;当前可用角色：<asp:DropDownList id="listRole" runat="Server" AutoPostBack=true OnSelectedIndexChanged="SelectRole"></asp:DropDownList>
          </TD>
          <TD height=22 noWrap align=right>
          <asp:Button id="btnSave" runat="server" Text = "保存角色权限" OnClick="SaveRoleAuthority" />
          <asp:Button id="btnDeleterole" runat="server" Text = "删除角色" OnClick="DeleteRole" />
          </TD>
          <TD></TD></TR></TBODY></TABLE></TD></TR>
  <TR style="size: auto">
    <TD valign =top>
    <div id=DIV1 onclick=CheckEvent()>
        <asp:TreeView ID="TreeViewPower" runat="server" ShowCheckBoxes=All OnSelectedNodeChanged="TreeViewPower_SelectedNodeChanged" ShowLines=true>
        <ParentNodeStyle Font-Bold="False" />
        <SelectedNodeStyle Font-Bold="True" ForeColor="Blue" />
        <HoverNodeStyle ForeColor="#5555DD" />
        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
           NodeSpacing="0px" VerticalPadding="0px"/>
        </asp:TreeView>
    </div></TD>
    <TD valign =top style="size: auto">
        <IFRAME runat="server"  src="RoleToUser.aspx" frameBorder=0 height="800px" width="600px"
            id ="iroleframename" marginWidth=0 
        scrolling=yes></IFRAME></TD>
      </TR></TBODY></TABLE>
</FORM></BODY></HTML>
