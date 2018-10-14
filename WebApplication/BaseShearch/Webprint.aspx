<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Webprint.aspx.cs" Inherits="WebApplication.BaseShearch.Webprint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>委托单</title>
   <style type="text/css" >
       table{ border-collapse:collapse;}
      #tbprint td{border:1px solid #000000;text-align:center}
    </style>

</head>
<body >
    <script type="text/javascript">
        function printdiv(printpage) 
        {
            var headstr = "<html><head><title></title></head><body>";
            var footstr = "</body>";
            var newstr = document.all.item(printpage).innerHTML;
            var oldstr = document.body.innerHTML;
            document.body.innerHTML = headstr + newstr + footstr;
            window.print();
            document.body.innerHTML = oldstr;
            return false;
        }  
    </script>
    <form id="form1" runat="server">
   
<div id="div_print" runat="Server" style="float:center">

</div>
 <input type="button" value="打印" onclick="printdiv('div_print');"/>
    </form>
</body>

</html>
