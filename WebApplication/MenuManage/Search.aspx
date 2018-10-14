<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Search.aspx.cs" Inherits="WebApplication.MenuManage.Search" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head><title>
</title>
<meta http-equiv="Content-Type" content="text/html; charset="utf-8" />
<script language="javascript" type="text/javascript" src="../js/My97DatePicker/WdatePicker.js"></script> 
<link href="../js/table.css" rel="stylesheet" type="text/css" />
<script language=javascript src=../js/month.js></script>
<script language=javascript src=../js/func.js></script>
<script language=javascript>
    function winPW(sUrl, sTitle, sWidth, sHeight) {
        window.open(sUrl, '' + sTitle, 'status=no,height=' + sHeight + ',width=' + sWidth + ',toolbar=no,scrollbars=no,menubar=no,resizable=0,location=no,top=200,left=227');
    }
    function Showalert() { alert('修改成功'); }
</script>
       <style type="text/css">
     table
        {
            border-collapse: collapse;
            border: none;
            color:#075587;
            border-top:solid 1px #bfd8e0;border-left:solid 1px #bfd8e0;border-right:solid 1px #bfd8e0;border-bottom:solid 1px #bfd8e0;
        }
        td
        {
           border: 1px solid #bfd8e0;
               width:100px;
               margin-left: 40px;
                color:Black;
           }
        .btn1 {    font-size: 9pt;    color: #003399;    border: 1px #003399 solid;    color: #006699;    border-bottom: #93bee2 1px solid;    border-left: #93bee2 1px solid;    border-right: #93bee2 1px solid;    border-top: #93bee2 1px solid;    background-image: url(../images/bluebuttonbg.gif);    background-color: #e8f4ff;    cursor: hand;    font-style: normal;    width: 60px;    height: 22px;}

           </style>
    <script src="../Js/jquery.js" ></script>
    <script language=javascript src = "../Js/caculate.js" ></script>
</head>
<body >
    <form name="form1"  id="form1" runat="Server">



<script type="text/javascript">
//<![CDATA[
if (typeof(Sys) === 'undefined') throw new Error('ASP.NET Ajax 客户端框架未能加载。');
//]]>
</script>


       <div style=" float:right; width:100%;">
      <table style="width:100%;margin-top:10px;margin-left:2px;" id="khzs">
      <tr style="height:25px; text-align:center">
       <td>客户名</td>
       <td align="left">
           <input name="txtkh" type="text" id="txtkh" runat="Server" disabled="disabled" style="width:102px;" />
           </td>
       <td>车牌号</td>
       <td align="left">
           <input name="txtchepai" type="text" id="txtchepai" runat=server disabled="disabled" style="width:102px;" />
           </td>
       <td>车架号</td>
       <td align="left">
           <input name="txtchejia" type="text" id="txtchejia" runat=server  disabled="disabled" style="width:150px;" />
           </td>
      </tr>
     <tr style=" height:25px; text-align:center">
       <td>品牌</td>
       <td align="left">   
           <input name="txtpinpai" type="text" id="txtpinpai" runat=server  disabled="disabled" style="width:102px;" />
         </td>
       <td>车型号</td>
       <td align="left">
           <input name="txtchexing" type="text" id="txtchexing" runat=server  disabled="disabled" style="width:102px;" />
         </td>
       <td>发动机号</td>
       <td align="left">
           <input name="txtfadongji" type="text"  id="txtfadongji" runat=server  disabled="disabled" style="width:150px;" />
         </td>
      </tr>
         <tr style="height:25px; text-align:center">
       <td>固定电话</td>
       <td align="left">    
           <input name="txtguding" type="text"  id="txtguding" runat=server  disabled="disabled" style="width:102px;" />
             </td>
       <td>手机号码</td>
       <td align="left">
           <input name="txtshouj" type="text"  id="txtshouj" runat=server  style="width:102px;" />
             </td>
       <td>身份证号</td>
       <td align="left">
           <input name="txtshenfenz" type="text"  id="txtshenfenz" runat=server  disabled="disabled" style="width:150px;" />
             </td>
      </tr>
       <tr style="height:25px;text-align:center">
       <td>登记时间</td>
       <td align="left">
           <input name="txtdengj" type="text" id="txtdengj" runat=server  onclick="WdatePicker()" class="Wdate" style="width:102px;" />
           </td>
       <td>交强险时间</td>
       <td align="left">
           <input name="txtjiaoqiang" type="text" id="txtjiaoqiang" runat=server  onclick="WdatePicker()" class="Wdate" style="width:102px;" />
           </td>
       <td>商业险时间</td>
       <td align="left">
           <input name="txtshangyexian" type="text"  id="txtshangyexian" runat=server  onclick="WdatePicker()" class="Wdate" style="width:150px;" />
           </td>
      </tr>
      
       <tr style="height:25px;text-align:center">
       <td>到期时间</td>
       <td align="left">
           <input name="txtdaoqi" type="text" id="txtdaoqi" runat=server  onclick="WdatePicker()" class="Wdate" style="width:102px;" />
           </td>
      </tr>
        <tr style="height:25px;text-align:center">
       <td>投保公司</td>
       <td align="left">
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
            </td>
       <td>座位数</td>
       <td align="left">
           <input name="txtzuowei" type="text" id="txtzuowei" runat=server  style="width:102px;" />
            </td>
       <td>客户类型</td>
       <td align="left">
           <input name="txtkhlx" type="text" id="txtkhlx" runat=server  style="width:150px;" />
            </td>
      </tr>
        <tr style="height:50px; text-align:center">
       <td>地址</td>
            
       <td align="left" colspan="4">
           <textarea name="txtlxdz" rows="2" cols="20" id="txtlxdz" runat=server  class="addtext" style="height:50px;width:430px;">
           </textarea></td>
       <td><asp:button   id="btnsave" runat=server Text="保存" class="searchbtn2" onclick="OnSaveBaseInf" /></td>
      </tr>
        <tr style="height:50px;text-align:center">
       <td>备注</td>
       <td align="left" colspan="5">
           <textarea name="txtbz" rows="2" cols="20" id="txtbz" runat=server class="addtext" style="height:50px;width:535px;"></textarea>
            </td>
      </tr>
      </table >

      
         <div id="uid">
	
      <div>
         <div style=" float:left;margin-left:2px; width:49%; margin-top:2px">
             <table width="100%">
             <tr>
              <td height="20" colspan="4"style="color:red; font-weight:bold"><input type=button runat="server" value="车辆" class="searchbtn6"/></td>
             </tr>
                <tr>
                    <td  style="width:60px">车牌号</td>
                    <td>     
           <input name="txtcpp" type="text" id="txtcpp" runat="Server" disabled="disabled" style="width:120px;" />
                    </td>
                      <td style="width:60px">车辆类型</td>
                    <td>     
           <select name="drxz" id="drxz" runat="Server"  onchange="car_typeChange()" style="height:20px;width:120px;">
		<option selected="selected" value="1">家庭自用汽车</option>
		<option value="2">企业非营业用车</option>
		<option value="3">营业货车</option>

	</select>
                    </td>
                </tr>
                <tr>
                  <td style="width:60px">座位/吨数</td>
                    <td>     
           <select name="car_type" id="drzl" runat="Server" onchange="compute()" style="height:20px;width:120px;">
		<option value="1">6座以下客车</option>
		<option value="2">6-10座客车</option>
		<option value="3">10座及以上客车</option>

	</select>
                    </td>
                      <td style="width:50px">车辆价格</td>
                      <td>     
                         <input name="txtwy" type="text" id="txtwy" runat="Server" onchange="compute()"  style="width:70px;" />万元
                      </td>
                </tr>
                 <div style="width:50%">
           <table width=100% style=" margin-top:2px; margin-left:6px">
            <tr>
              <td height="20" colspan="3"style="color:red; font-weight:bold"><input type=button  value="基本保险" class="searchbtn6"/></td>
            </tr>
            <tr>
                <td style=" width:120px">
                    <input id="jdcsubx" runat="Server" type="checkbox" name="jdcsubx" onclick="xuanzhong();compute()"  /><label for="jdcsubx">机动车损失保险</label>
                    </td>
                <td><select name="drssbx" id="drssbx" onchange="compute()" runat="Server" style="width:80px;">
		<option value="0">1年以下</option>
		<option value="1">1-2年</option>
		<option value="2">2-6年</option>
		<option value="3">6年以上</option>

	</select>
                    </td>
                <td>     
           <input name="txtjdc" type="text" id="txtjdc" runat="Server" style="width:102px;" />
                    </td>
            </tr>
               <tr>
                <td style=" width:120px">
                    <input id="cbdsz" runat="Server" type="checkbox" onclick="xuanzhong();compute()" name="cbdsz" /><label for="cbdsz">第三者责任保险</label>
                    </td>
                <td><select name="drds" id="drds" runat="Server" onchange="compute()" style="width:80px;">
		<option value="1">5万</option>
		<option value="2">10万</option>
		<option value="3">15万</option>
		<option value="4">20万</option>
		<option value="5">30万</option>
		<option value="6">50万</option>
		<option value="7">100万</option>
		<option value="150万">150万</option>
		<option value="200万">200万</option>

	</select>
                    </td>
                <td>     
           <input name="txtds" type="text" id="txtds" runat="Server" style="width:102px;" />
                    </td>
            </tr>
                       <tr>
                <td style=" width:120px">
                    <input id="ckqcdq" runat="Server" type="checkbox" onclick="xuanzhong();compute()" name="ckqcdq"  /><label for="ckqcdq">全车盗抢损失险</label></td>
                <td>
                    </td>
                <td>     
           <input name="txtdx" type="text" id="txtdx" runat="Server" style="width:102px;" />
                    </td>
            </tr>
                    <tr>
                <td style=" width:120px">
                    <input id="cksj" runat="Server" type="checkbox" onclick="xuanzhong();compute()" name="cksj" /><label for="cksj">车上人员司机位</label></td>
                <td><select name="drsj" onchange="compute()" runat="Server" id="drsj" style="width:80px;">
		<option selected="selected" value="1">1万</option>
		<option value="2">2万</option>
		<option value="3">3万</option>
		<option value="4">4万</option>
		<option value="5">5万</option>
		<option value="6">6万</option>
		<option value="7">7万</option>
		<option value="8">8万</option>
		<option value="9">9万</option>
		<option value="10">10万</option>
		<option value="15">15万</option>
		<option value="20">20万</option>

	</select>
                    </td>
                <td>     
           <input name="txtsj" type="text" id="txtsj" runat="Server" style="width:102px;" />
                    </td>
            </tr>
                    <tr style=" height:40px">
                <td style=" width:120px">
                    <input id="ckck" runat="Server" type="checkbox" onclick="xuanzhong();compute()" name="ckck" /><label for="ckck">车上人员乘客位</label>
                   </td>
                <td><select name="drck" onchange="compute()" id="drck" runat="Server" style="width:80px;">
		<option value="1">1万</option>
		<option value="2">2万</option>
		<option value="3">3万</option>
		<option value="4">4万</option>
		<option value="5">5万</option>
		<option value="6">6万</option>
		<option value="7">7万</option>
		<option value="8">8万</option>
		<option value="9">9万</option>
		<option value="10">10万</option>
		<option value="15">15万</option>
		<option value="20">20万</option>

	</select>
                    <br />
                    <input name="txtgs" type="text" id="txtgs" runat="Server" onchange="compute()" style="width:27px;" />

                    </td>
                <td>     
           <input name="txtck" type="text" id="txtck" runat="Server" style="width:102px;" />
                    </td>
            </tr>
            
            <tr>
              <td height="20" colspan="2"style="color:red; font-weight:bold">
                  <input class="searchbtn6" type="button" value="不计免赔" /></td>
             </tr>
                   <tr>
                  <td colspan=2><input id="cbcsun" runat="Server"  type="checkbox" name="cbcsun" onclick="compute()"/><label for="cbcsun">车损</label></td>
                      <td colspan=2>     
                        
             <input name="txtcs" type="text" id="txtcs" runat="Server" />
                      </td>
                </tr>
                       <tr>
                  <td colspan=2><input id="cbsz" runat="Server"  type="checkbox" name="cbsz" onclick="compute()"/><label for="cbsz">三者</label></td>
                      <td colspan=2>     
                        
             <input name="txtds2" type="text" id="txtds2" runat="Server" />
                      </td>
                </tr>
                       <tr>
                  <td colspan=2><input id="cbches" runat="Server" type="checkbox" name="cbches" onclick="compute()"/><label for="cbches">盗抢</label></td>
                      <td colspan=2>     
                        
             <input name="txtdx2" type="text" id="txtdx2" runat="Server" />
                      </td>
                </tr>
                       <tr>
                  <td colspan=2><input id="cbcheshuahe" runat="Server" type="checkbox" name="cbcheshuahe" onclick="compute()"/><label for="cbcheshuahe">车上人员</label></td>
                      <td colspan=2>     
                        
             <input name="txtcsry" type="text" id="txtcsry" runat="Server"  />
                      </td>
                </tr>
                       <tr>
                  <td colspan=2><input id="cbhh2" runat="Server" type="checkbox" onclick="compute()" name="cbhh2" /><label for="cbhh2">车身划痕</label></td>
                      <td colspan=2>     
                        
             <input name="txthh2" type="text" id="txthh2" runat="Server" />
                      </td>
                </tr>
                       <tr>
                  <td colspan=2><input id="cbzr2" runat="Server" type="checkbox" onclick="compute()" name="cbzr2" /><label for="cbzr2">自燃</label></td>
                      <td colspan=2>     
                        
             <input name="txtzr2" type="text" id="txtzr2" runat="Server" />
                      </td>
                </tr>
                                  <td colspan=2><input id="ckfdj2" runat="Server" type="checkbox" onclick="compute()" name="ckfdj2" /><label for="ckfdj2">发动机特别损失险</label></td>
                      <td colspan=2>     
                        
             <input name="txtfdj2" type="text" id="txtfdj2" runat="Server" />
                      </td>
                </tr>
                <tr>
                <tr>
              <td height="20" colspan="3"style="color:red; font-weight:bold">
                  <input class="searchbtn6" type="button" value="附加险" /></td>
            </tr>
                     <tr>
                <td style=" width:120px">
                    <input id="ckboli" runat="Server" type="checkbox" onclick="compute()" name="ckboli" /><label for="ckboli">玻璃单独破碎</label></td>
                <td><select name="drboli" id="drboli" onchange="compute()"  runat="Server">
		<option value="0">国产玻璃</option>
		<option value="1">进口玻璃</option>

	</select>
                    </td>
                <td>     
           <input name="txtboli" type="text" id="txtboli" runat="Server" style="width:102px;" />
                    </td>
            </tr>
                          <tr>
                <td style=" width:120px">
                    <input id="ckhh" runat="Server" type="checkbox" onclick="xuanzhong();compute()" name="ckhh" /><label for="ckhh">车身划痕损失费</label></td>
                <td><select name="drhh" id="drhh" onchange="compute()" runat="Server" style="width:80px;">
		<option value="1">2000</option>
		<option value="2">5000</option>

	</select>
                    </td>
                <td>     
           <input name="txthh" type="text" id="txthh" runat="Server" style="width:102px;" />
                    </td>
            </tr>
                          <tr>
                <td style=" width:120px">
                    <input id="ckzr" runat="Server" type="checkbox" name="ckzr" onclick="xuanzhong();compute();" /><label for="ckzr">车辆自燃损失费</label></td>
                <td>
                    </td>
                <td>     
           <input name="txtzr" type="text" id="txtzr" style="width:102px;" runat="Server" />
                    </td>
            </tr>
                          <tr>
                <td style=" width:120px">
                    <input id="ckfdj" runat="Server" type="checkbox" name="ckfdj" onclick="xuanzhong();compute();" /><label for="ckfdj">发动机特别损失险</label></td>
                <td>
                    </td>
                <td>     
           <input name="txtfdj" type="text" id="txtfdj" style="width:102px;" runat="Server" />
                    </td>
            </tr>
             
           </table>
         </div>
                

             </table>
         
        <table style="width:100%; margin-top:2px; margin-left:2px">
           <tr>
            <td>VIP会员折扣系数</td>
            <td style="color:Red; width:120px">                        
             <input name="txthuiyuan" type="text" id="txthuiyuan" onchange="compute()" style="width:29px;" runat="Server" />
                      八折数为80</td>
            <td>交强险</td>
            <td>                        
             <input name="txtjqx" type="text" id="txtjqx" onchange="compute()" style="width:75px;" runat="Server"  />
                      元</td>
            <td>车船税</td>
            <td>                        
             <input name="txtzc" type="text" id="txtzc" onchange="compute()" style="width:73px;" runat="Server"  />
                      元</td>
           </tr>
                 <tr>
            <td>折后保费</td>
            <td>                        
             <input name="txtzhfiyao" type="text" id="txtzhfiyao" runat="Server"  />
                      </td>
            <td>总金额</td>
            <td>                        
             <input name="txtzje" type="text" id="txtzje" runat="Server" style="width:72px;" />
                      元</td>
            <td colspan=2>
                    <asp:button id="Button1" runat="server" Text="计算保存" OnClientClick="compute()" class="searchbtn2" onclick="SaveDetailInf" />
                    </td>
           </tr>
        </table>
                     <table border=0 style=" height:50px; width:100px; margin-top:2px; margin-left:2px;">
                      <tr style=" border:0px solid red">
              <td style=" height:40px;border:0px solid red">
              <asp:Button id="ButtonSuccess" Text="成功" runat="server" class="searchbtn2" OnClick="SuccessButtonClick" /></td>
             
              <td style=" height:40px;border:0px solid red">
              <asp:Button id="ButtonAppointment" Text="预约" runat="server" class="searchbtn9" OnClick="AppointmentButtonClick" /></td>
              
              <td style=" height:40px;border:0px solid red">
              <asp:Button id="ButtonFaild" Text="失败"  runat="server" class="searchbtn10" OnClick="FailButtonClick" OnClientClick="javascript:return  confirm(&#39;真的认为失败吗？&#39;);" /></td>
              
              <td style=" height:40px;border:0px solid red">
              <asp:Button id="ButtonInvalid" Text="无效"  runat="server" class="searchbtn11" OnClick="InvalidButtonClick" OnClientClick="javascript:return confirm(&#39;真的认为无效吗？&#39;);"/></td>
           </tr>
        </table>

           </tr>
        </table>

          
        <div  style=" display:none">
            <input name="dalei" type="text" id="dalei" />
            <input name="xiaolei" type="text" id="xiaolei" />
        </div>

      </div>
       
</div>
    </form>
</body>
</html>
