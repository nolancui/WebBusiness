﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeptTreeinf.aspx.cs" Inherits="WebApplication.SystemManage.DeptManager.DeptTreeinf" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:XmlDataSource ID="XmlDataSource1" runat="server"></asp:XmlDataSource>
        <asp:TreeView ID="TreeView1" runat="server" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" ShowLines=true >
        <ParentNodeStyle Font-Bold="False" />
        <SelectedNodeStyle Font-Bold="True" ForeColor="Blue" />
        <HoverNodeStyle ForeColor="#5555DD" />
        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
           NodeSpacing="0px" VerticalPadding="0px" ImageUrl ="DeptTree/ftv2folderclosed.gif"/>
           <DataBindings>
              <asp:TreeNodeBinding DataMember="node" TextField="Text" />
           </DataBindings>
        </asp:TreeView>

    </div>
    </form>
</body>
</html>
