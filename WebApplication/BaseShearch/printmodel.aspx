<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="printmodel.aspx.cs" Inherits="WebApplication.BaseShearch.printmodel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="div_print" style="float:center">
<table id="tbprint" runat="server">

<tr>
<td width="12.5%">商业险时间</td><td colspan="3" width="37.5%"><span id="shangyebaoxian" runat="server"></span></td><td width="12.5%">保险公司</td><td colspan="3" width="37.5%"><span id="Span2" runat="server"></span></td>
</tr>
<tr>
<td>车牌号码</td><td colspan="3"><span id="Span1" runat="server"></span></td><td>被保险人</td><td colspan="3"><span id="Span3" runat="server"></span></td>
</tr>
<tr>
<td>商业险金额</td><td colspan="3"><span id="Span7" runat="server"></span></td><td>联系电话</td><td colspan="3"><span id="Span4" runat="server"></span></td>
</tr>
<tr>
<td>交强险金额</td><td colspan="3"><span id="Span8" runat="server"></span></td><td>实收金额</td><td colspan="3"><span id="Span5" runat="server"></span></td>
</tr>
<tr>
<td>车船税</td><td colspan="3"><span id="Span9" runat="server"></span></td><td rowspan="2">礼品</td><td colspan="3" rowspan="2"><span id="Span6" runat="server"></span></td>
</tr>
<tr>
<td>服务时间</td><td colspan="3"><span id="Span10" runat="server"></span></td>
</tr>
<tr>
<td>服务地址</td><td colspan="7" style="word-wrap:break-word;"><span id="Span11" runat="server"></span></td>
</tr>
<tr>
<td>业务员</td><td colspan="3"><span id="Span13" runat="server"></span></td><td>服务人员</td><td width="12.5%"><span id="Span12" runat="server"></span></td><td rowspan="2" width="12.5%">客户签字</td><td rowspan="2"><span id="Span14" runat="server"></span></td>
</tr>
<tr>
<td>业务电话</td><td colspan="3"><span id="Span15" runat="server"></span></td><td>财务确定</td><td width="12.5%"></td>
</tr>
</table>
</div>
    </form>
</body>
</html>
