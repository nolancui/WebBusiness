<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoaddatafromLocal.aspx.cs" Inherits="WebApplication.MenuManage.LoaddatafromLocal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script>

        function GetElementValue() {
            //var licenseNo = window.parent.document.getElementById("prpCitemCar.licenseNo");
            //var engineNo = window.parent.document.getElementById("prpCitemCar.engineNo");
            try {
                var Frame2 = parent.window.frames["Frame2"].document.getElementById("prpCitemCar.licenseNo").value
            }
            catch (e) {
                alert(e.message); 
            }
            alert("hello world");
            //window.parent.parent.frames["Frame2"].document.getElementById("prpCitemCar.licenseNo");
            alert(Frame2);
            alert("hello world");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
    <tr>
    <td><asp:Button ID="Button2" runat=server Text="自动登录" /></td>
    <td><asp:CheckBox ID="autorefresh" runat=server Text = "自动刷新页面" /></td>
    <td><asp:Button ID="readdata" runat=server Text="数据读取" OnClientClick=GetElementValue() /></td>
        <td><asp:Button ID="Button1" runat=server Text="保单信息保存" /></td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
