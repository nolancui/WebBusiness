
<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="chenggjiemian.aspx.cs" Inherits="WebApplication.MenuManage.chenggjiemian" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head id="Head1">
<meta http-equiv="Content-Type" content="text/html; charset="utf-8" />
<script language="javascript" type="text/javascript" src="../js/My97DatePicker/WdatePicker.js"></script> 
<link href="../js/table.css" rel="stylesheet" type="text/css" />
<script language=javascript src=../js/month.js></script>
<script language=javascript src=../js/func.js></script>
<script language=javascript >

    
        function ttt() {
            //���û������ѡ��
            var x = 0;
            var inputs = document.getElementsByTagName("input");
            var object = event.srcElement;
            for (var i = 0; i < inputs.length; i++) {
  
                if (inputs[i].type=='checkbox'&&object != inputs[i]) {
                    inputs[i].checked = false;
                  }
              }
              if (object != null && object.checked == true) {
                  ss = object.value;
                  document.getElementById('txtxis').value = ss;
              }
              else
                  document.getElementById('txtxis').value = 'null';



            var txtfwsj = document.getElementById('txtfwsj');

            var NowTime = new Date().toLocaleTimeString(); 
//            document.write(NowTime);

            txtfwsj.value = CurentTime();

        }
        function chechtxtxis() {
            if (document.getElementById('txtxis').value == 'null') {
                alert("δѡ������Ա");
            }

        }
        //��ȡ��ǰϵͳʱ�䰮
        function CurentTime() {

            var now = new Date();



            var year = now.getFullYear();       //�� 

            var month = now.getMonth() + 1;     //�� 

            var day = now.getDate();            //�� 


            var clock = year + "-";



            if (month < 10)

                clock += "0";



            clock += month + "-";



            if (day < 10)

                clock += "0";



            clock += day + " ";
            return (clock);

        }


        //�����еĶ���
        function jiazai() {


        }
</script>
        <style type="text/css">
     .tableclass
        {
            border-collapse: collapse;
            border: none;
            color:#075587;
            border-top:solid 1px #bfd8e0;border-left:solid 1px #bfd8e0;border-right:solid 1px #bfd8e0;border-bottom:solid 1px #bfd8e0;
        }
        td
        {
           border-top:solid 1px #bfd8e0;border-left:solid 1px #bfd8e0;border-right:solid 1px #bfd8e0; border-bottom:solid 1px #bfd8e0;
            width:100px
        }
        .btn1 {    font-size: 9pt;    color: #003399;    border: 1px #003399 solid;    color: #006699;    border-bottom: #93bee2 1px solid;    border-left: #93bee2 1px solid;    border-right: #93bee2 1px solid;    border-top: #93bee2 1px solid;    background-image: url(../images/bluebuttonbg.gif);    background-color: #e8f4ff;    cursor: hand;    font-style: normal;    width: 60px;    height: 22px;}


</style>
    <title>
	�ɹ�
</title></head>
<body style="border:1px solid gary;" leftMargin=0 topMargin=0  onload="ttt()">
<form id="form1" runat="server">
    <div style=" vertical-align:middle; height: 44px;border:1px solid gary;"><h2 style="height: 44px">�ɹ�</h2></div>
   <div id="dlgReply"> 
       <table style="width:100%;margin-top:10px;margin-left:2px;" id="khzs" runat="server" class=tableclass>
      <tr runat="server">
       <td  style=" text-align:center">���͸�����(��ѡ)</td>
       <td colspan=3 style=" height:25px; width:600px" id="Secretary" name="Secretary" runat="server">
         </td>    
      </tr>    
     <tr>
       <td style=" text-align:center;">��ҵ��ʱ��</td>
       <td>     
           <input name="txtqssj" type="text" runat="server" id="txtqssj" onclick="WdatePicker()" class="Wdate" style="width:160px;" />
         </td> 
       <td style=" width:100px; text-align:center">���չ�˾</td>
       <td>
           <input name="txtbxgs" type="text" runat="server" id="txtbxgs" style="width:160px;" />
         </td>
      </tr>
           
         <tr>
       <td style="text-align:center">���ƺ���</td>
       <td class="style2">     
           <input name="txtcphm" type="text"  runat="server" id="txtcphm" style="width:160px;" />
             </td>
       <td style=" text-align:center" class="style2">��������</td>
       <td class="style2">
           <input name="txtbbxr" type="text"  runat="server" id="txtbbxr" style="width:160px;" />
             </td>
      </tr>
       <tr>
       <td style=" text-align:center">��ҵ�ս��</td>
       <td >
           <input name="txtsyxje" type="text"  runat="server" id="txtsyxje" style="width:155px;" />
           </td>
       <td style=" width:100px; text-align:center">��ϵ�绰</td>
       <td>
           <input name="txtlxdh" type="text"  runat="server" id="txtlxdh" style="width:160px;" />
           </td>
      </tr>
        <tr style="height:25px;text-align:center">
       <td>��ǿ�ս��</td>
       <td style=" text-align:left">     
           <input name="txtjqxje" type="text" runat="server" id="txtjqxje" style="width:160px;" />
            </td>
       <td style=" width:100px; text-align:center">ʵ�ս��</td>
       <td style=" text-align:left">
           <input name="txtssje" type="text"  runat="server" id="txtssje" style="width:160px;" />
            </td>
      </tr>
      <tr style="height:25px;text-align:center">
       <td>����˰</td>
       <td style=" text-align:left">     
           <input name="txtpinpai2" type="text"  runat="server" id="txtpinpai2" style="width:160px;" />
            </td>
       <td rowspan=2 style=" width:100px; text-align:center" >��Ʒ</td>
       <td rowspan=2 style=" text-align:left">
           <input name="txtpinpai3" type="text" id="txtpinpai3"  runat="server" style="height:29px;width:160px;" />
            </td>
      </tr>
          <tr style="height:25px;text-align:center">
       <td>����ʱ��</td>
       <td style=" text-align:left">     
           <input name="txtfwsj" type="text" id="txtfwsj" runat="server" onclick="WdatePicker()" class="Wdate" style="width:160px;" />
            </td>
      </tr>
        <tr style="text-align:center">
       <td class="style1">�����ַ</td>
            
       <td colspan="2" style=" text-align:left">
           <textarea name="txtlxdz" rows="2" cols="20" id="txtlxdz" runat="server" class="addtext" style="height:50px;width:430px;"></textarea></td>
               <td rowspan=2 style=" text-align:center"><div style=" width:100%">���ʽ</div>
               <div style=" width:65%; height: 50px;">

              <input id="RadioButton1" type="radio" name="t" runat="server" value="RadioButton1"  /><label for="RadioButton1">ˢ��</label>
              <input id="RadioButton2" type="radio" name="t" runat="server" value="RadioButton2" /><label for="RadioButton2">ת��</label>
              <input id="RadioButton3" type="radio" name="t" runat="server" value="RadioButton3" /><label for="RadioButton3">�ֽ�</label>
              <input id="RadioButton4" type="radio" name="t" runat="server" value="RadioButton4" /><label for="RadioButton4">����</label>
               </div>
               </td>
            
      </tr>
        <tr style="height:50px;text-align:center">
       <td>��ע</td>
       <td colspan="2" style=" text-align:left">
           <textarea name="txtbz" rows="2" cols="20" id="txtbz" runat="server" class="addtext" style="height:50px;width:430px;"></textarea>
            </td>
            
      </tr>   
      </table >
           <table style="width:100%;margin-top:1px;margin-left:2px;" id="Table1" class=tableclass>
     <tr style=" height:25px; text-align:center">
       <td> ҵ��Ա</td>
       <td>     
           <input name="txtywy" type="text" runat="server" id="txtywy" style="width:160px;" />
         </td>
       <td style=" width:100px">������Ա</td>
       <td>
           &nbsp;</td>
           <td style=" width:100px">�ͻ�ǩ��</td>
       <td>
           &nbsp;</td>
      </tr>
         <tr style="height:25px; text-align:center">
       <td>ҵ��绰</td>
       <td>     
           <input name="txtywydh" type="text" runat="server" id="txtywydh" style="width:160px;" />
             </td>
       <td style=" width:100px; text-align:center">����ȷ��</td>
       <td>
           &nbsp;</td>
      </tr>
       
      </table >
      <div style="  width:100%; text-align:center; margin-top:10px">
         <asp:button id="BtnSave" runat="server" Text="ȷ   ��" class="searchbtn5" OnClientClick="chechtxtxis()" OnClick="OnEnsureSuccess" />
    
      </div>
     <div style=" display:none">
    <input name="txtxis" runat="server" type="text" id="txtxis" />
    </div>
</div>
    
    </form>
    
</body>
</html>

