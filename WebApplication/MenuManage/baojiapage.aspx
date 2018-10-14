<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="baojiapage.aspx.cs" Inherits="WebApplication.MenuManage.baojiapage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <script>
        function GetAllElementValue() {

            try {
                var licenseNo = window.frames["Frame2"].document.getElementById("prpCitemCar.licenseNo");
                var engineNo = window.frames["Frame2"].document.getElementById("prpCitemCar.engineNo");
            }
            catch (e) {
                alert(e.message);
            }
          
            alert("hello world");
            

        }
       // GetAllElementValue();
    </script>
</head>
<FRAMESET id=Sbar rows="10%,90%">
<FRAME name="Frame1" src="LoaddatafromLocal.aspx"/>
<FRAME name="Frame2" src="http://157.122.153.67:9000/khyx/qtr/price/prepareQuote.do"/>
    </FRAMESET>
</html>