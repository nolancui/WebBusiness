<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="AddClient.aspx.cs" Inherits="WebApplication.MenuManage.AddClient" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
 
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset="utf-8" />
    <title>�ͻ���Ϣ</title>
    <link href="css/common1.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../js/My97DatePicker/WdatePicker.js"></script> 
<!--[if IE 6]>
    <script src="js/DD_belatedPNG.js"></script>
    <script>
    //DD_belatedPNG.fix('*');
    </script>
    <![endif]-->
    <script src="com/func.js"></script>
    <script language=javascript type="text/javascript">
        function chengg() {

            alert('�ɹ�');

        }
        function shibai() {

            alert('ʧ��');

        }
        function subt_onclick() {

        }

    </script>
</head>
<body style="border:none;">
    <form id="form1" style="margin:0px" runat="server">
<div>

    <div ><!--class="mdl"-->
    
    <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td class="mtop"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td class="mtl">&nbsp;</td>
        <td valign="bottom" class="mtc"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td height="35" style="padding-left:10px; color:#eef1f2; font-weight:bold">�ͻ�������Ϣ</td>
            <td>&nbsp;</td>
            <td style="text-align:right;"><!--<img src="images/gb.gif" width="20" height="20"><img src="images/gb1.gif" width="20" height="20">--></td>
          </tr>
        </table></td>
        <td class="mtr">&nbsp;</td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td><table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td class="mcl">&nbsp;</td>
        <td  class="mcc"><table width="100%" height="100%"border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td style="background:#f8f9fa;" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0" class="editstyle">
            <tr>
            <td class="edittdleft">�ͻ�����</td>
            <td colspan="1"><label><input name="txtkhm" type="text" id="txtkhm" runat=server class="addinpu" /></label></td>
             <td class="edittdleft">���ƺţ�</td>
            <td colspan="1"><label><input name="txtcph" type="text" id="txtcph" runat=server class="addinpu" /></label></td>
            </tr>
            <tr>
                <td class="edittdleft">Ʒ�ƣ�</td>
                <td><label><input name="txtpinpai" type="text" id="txtpinpai" runat=server class="addinpu" /></label></td>
                  <td class="edittdleft">���ͺţ�</td>
                <td><label><input name="txtcxh" type="text" id="txtcxh" runat=server class="addinpu" /></label></td>
              </tr>
              <tr>
              <td class="edittdleft">�������ţ�</td>
                <td><input name="txtfdjh" type="text" id="txtfdjh" runat=server class="addinpu" /></td>
                <td class="edittdleft">�̶��绰��</td>
                <td><label><input name="txtgddh" type="text" id="txtgddh" runat=server class="addinpu" /></label></td>
              </tr>
              <tr id="tr_cp1">
                <td class="edittdleft">�ֻ����룺</td>
                <td><input name="txtsjhm" type="text" id="txtsjhm" runat=server class="addinpu" /></td>
                <td class="edittdleft">���֤�ţ�</td>
                <td><input name="txtsfzh" type="text" id="txtsfzh" runat=server class="addinpu" /></td>
              </tr>
              <tr>
                <td class="edittdleft">�Ǽ�ʱ�䣺</td>
                <td><input name="txtdjsj" type="text" id="txtdjsj" runat="server" class="addinpu" onclick="WdatePicker()" /></td>
                <td class="edittdleft">��ǿ��ʱ�䣺</td>
                <td><input name="txtjqxtime" type="text" id="txtjqxtime" runat=server class="addinpu" onclick="WdatePicker()" /></td>
              </tr>
                            <tr>
                <td class="edittdleft">��ҵ��ʱ�䣺</td>
                <td><input name="txtsyxsj" type="text" id="txtsyxsj" runat=server class="addinpu" onclick="WdatePicker()" /></td>
                <td class="edittdleft">Ͷ����˾��</td>
                <td>
                    <select name="txttpgs" id="txttpgs" runat=server class="addinpu" style="height:20px;width:170px;">
	<option value="��">��</option>
	<option value="�˱�">�˱�</option>
	<option value="ƽ��">ƽ��</option>
	<option value="̫��">̫��</option>
	<option value="����">����</option>
	<option value="����">����</option>
	<option value="�л�����">�л�����</option>
	<option value="���">���</option>
	<option value="����">����</option>
 
</select>
                  
              </tr>
                            <tr>
                <td class="edittdleft">���ܺţ�</td>
                <td><input name="txtcjh" type="text" id="txtcjh" runat=server class="addinpu" /></td>
                <td class="edittdleft">��λ����</td>
                <td><input name="txtzws" type="text" id="txtzws" runat=server class="addinpu" /></td>
              </tr>
                                <tr>
                <td class="edittdleft">״̬��</td>
                <td><input name="zt" type="text" id="zt" runat=server class="addinpu" /></td>
                <td class="edittdleft">�����ͷ���</td>
                <td><input name="sfkf" type="text" id="sfkf" runat=server class="addinpu" /></td>
              </tr>
               <tr>
                <td class="edittdleft">�ܽ�</td>
                <td ><input name="zje" type="text" id="zje" runat=server class="addinpu" /></td>
                 <td>���ţ�</td>
                 <td><asp:DropDownList ID="deptment" runat="Server"></asp:DropDownList>
                 </td>
              </tr>
              <tr id="tr_tp" >
                <td valign="middle" class="edittdleft">&nbsp;��ϵ��ַ��</td>
                <td style="padding-top:5px;" colspan="3"><label>
                <textarea name="txtlxdz" rows="2" cols="20" id="txtlxdz" runat=server class="addtext" style="height:50px;width:535px;">
</textarea>
                </label></td>
              </tr>
 
                
                
                              <tr id="tr_cp2">
                <td valign="middle" class="edittdleft">&nbsp;&nbsp;&nbsp; ��ע��</td>
                <td style="padding-top:5px;" colspan="3"><label>
                <textarea name="txtbz" rows="2" cols="20" id="txtbz" runat=server class="addtext" style="height:50px;width:535px;">
</textarea>
                </label></td>
                </tr>
                <tr>
                <td style="padding-top:8px; height:65px" colspan="4" align="center">
                <asp:Button ID="subt" runat="server" onclick="SaveButtonClick" Text="�ύ" />
                </td>
              </tr>
            </table>
            <!--add start-->
            <!--add end-->
              </td>
          </tr>
        </table></td>
        <td class="mcr">&nbsp;</td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td class="mdb"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td class="mbl">&nbsp;</td>
        <td class="mbc">&nbsp;</td>
        <td class="mbr">&nbsp;</td>
      </tr>
    </table></td>
  </tr>
</table>
 
    </div>
    </form>
</body>
</html>
