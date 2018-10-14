function tt()
{
	alert("hello world");
}
var PersonnalUseCarPay=[
[666 ,961,1097,1191,1345,1615,2102],
[616 ,869,982 ,1058,1185,1411,1838],
[616 ,869,982 ,1058,1185,1411,1838 ]
];
//6 sits below
//6-10
//over 10
//5万	10万	15万 	20万	30万	50万	100万
						
var CompanyNoprofitUseCarPay = [
[758 ,1067 ,1206,1301,1457 ,1735 ,2259 ],
[713 ,1014 ,1151,1245,1398 ,1669 ,2175 ],
[775 ,1092 ,1235,1332,1491 ,1775 ,2312 ],
[1014,1466 ,1671,1817,2052 ,2462 ,3208 ],
[1277,1820 ,2066,2236,2514 ,3005 ,3913 ],
[1646,2319 ,2622,2827,3166 ,3770 ,4909 ]
];

//758 ,1067 ,1206,1301,1457 ,1735 ,2259 
//713 ,1014 ,1151,1245,1398 ,1669 ,2175 
//775 ,1092 ,1235,1332,1491 ,1775 ,2312 
//1014,1466 ,1671,1817,2052 ,2462 ,3208 
//1277,1820 ,2066,2236,2514 ,3005 ,3913 
//1646,2319 ,2622,2827,3166 ,3770 ,4909 
//

var ProfitUsedCarPay = [
[1072 ,1672 ,1968 ,2167 ,2551 ,3198 ,4177 ],
[1726 ,2691 ,3166 ,3486 ,4105 ,5145 ,6720 ],
[1981 ,3089 ,3635 ,4003 ,4712 ,5907 ,7715 ],
[2715 ,4233 ,4981 ,5485 ,6457 ,8094 ,10572]
];

// 1072 ,1672 ,1968 ,2167 ,2551 ,3198 ,4177 
// 1726 ,2691 ,3166 ,3486 ,4105 ,5145 ,6720 
// 1981 ,3089 ,3635 ,4003 ,4712 ,5907 ,7715 
// 2715 ,4233 ,4981 ,5485 ,6457 ,8094 ,10572 

//----------------------------------------------------
//------begin sunshi----------------------------------
//[0,1)		[1,4)		[4,6)		[6,8)		≥8	
//基本保费	费率	基本保费	费率	基本保费	费率	基本保费	费率	基本保费	费率
									


var SunshiPersonnalCar = [
[603 ,1.43 ,569 ,1.35, 575  ,1.37 ,586 ,1.39 ,592 ,1.41],
[724 ,1.43 ,683 ,1.35, 689  ,1.37 ,703 ,1.39 ,711 ,1.41],
[724 ,1.43 ,683 ,1.35, 689  ,1.37 ,703 ,1.39 ,711 ,1.41]
];


//603 ,1.43 ,569 ,1.35, 575  ,1.37 ,586 ,1.39 ,592 ,1.41 
//724 ,1.43 ,683 ,1.35, 689  ,1.37 ,703 ,1.39 ,711 ,1.41 
//724 ,1.43 ,683 ,1.35, 689  ,1.37 ,703 ,1.39 ,711 ,1.41 
//

var SunshiCompanyNoneProfitCar = [
[368 ,1.22 ,347 ,1.15 ,351 ,1.16 ,358 ,1.18 ,362 ,1.20],
[442 ,1.16 ,417 ,1.09 ,421 ,1.10 ,430 ,1.13 ,434 ,1.14],
[246 ,0.95 ,232 ,0.89 ,235 ,0.90 ,239 ,0.92 ,242 ,0.93],
[318 ,1.22 ,300 ,1.15 ,303 ,1.16 ,309 ,1.19 ,312 ,1.20],
[348 ,1.34 ,328 ,1.26 ,331 ,1.27 ,338 ,1.30 ,341 ,1.31],
[229 ,1.62 ,216 ,1.53 ,218 ,1.55 ,223 ,1.58 ,225 ,1.59]
];
//368 ,1.22 ,347 ,1.15 ,351 ,1.16 ,358 ,1.18 ,362 ,1.20 
//442 ,1.16 ,417 ,1.09 ,421 ,1.10 ,430 ,1.13 ,434 ,1.14 
//246 ,0.95 ,232 ,0.89 ,235 ,0.90 ,239 ,0.92 ,242 ,0.93 
//318 ,1.22 ,300 ,1.15 ,303 ,1.16 ,309 ,1.19 ,312 ,1.20 
//348 ,1.34 ,328 ,1.26 ,331 ,1.27 ,338 ,1.30 ,341 ,1.31 
//229 ,1.62 ,216 ,1.53 ,218 ,1.55 ,223 ,1.58 ,225 ,1.59 

var SunShiProfitCar = [
[835 ,1.93 ,827  ,1.91 ,835  ,1.93 ,835 ,1.93 ,835 ,1.93],
[1179,2.37 ,1168 ,2.35 ,1179 ,2.37 ,1179,2.37 ,1179,2.37],
[1321,2.36 ,1308 ,2.34 ,1321 ,2.36 ,1321,2.36 ,1321,2.36],
[2097,2.52 ,2076 ,2.50 ,2097 ,2.52 ,2097,2.52 ,2097,2.52]
];
//835 ,1.93 ,827  ,1.91 ,835  ,1.93 ,835 ,1.93 ,835 ,1.93 
//1179,2.37 ,1168 ,2.35 ,1179 ,2.37 ,1179,2.37 ,1179,2.37 
//1321,2.36 ,1308 ,2.34 ,1321 ,2.36 ,1321,2.36 ,1321,2.36 
//2097,2.52 ,2076 ,2.50 ,2097 ,2.52 ,2097,2.52 ,2097,2.52 

//------------end shunshi--------------------------------
//-------------------------------------------------------

//-------------------------------------------------------
//-------------begin 
//车上人员责任险		全车盗抢损失险		玻璃单独破碎险	
//司机座位rate	乘客座位rate 基本保费	费率	国产玻璃	进口玻璃


var PersonnalUseOtherPay = [
[0.40 ,0.26 ,120 ,0.42 ,0.19 ,0.31],
[0.39 ,0.25 ,140 ,0.35 ,0.19 ,0.31],
[0.39 ,0.25 ,140 ,0.35 ,0.23 ,0.37]
];

// 0.40 ,0.26 ,120 ,0.42 ,0.19 ,0.31 
// 0.39 ,0.25 ,140 ,0.35 ,0.19 ,0.31 
// 0.39 ,0.25 ,140 ,0.35 ,0.23 ,0.37 

var CompanyNoneProfitOtherPay = [
[0.41 ,0.25 ,120 ,0.39 ,0.13 ,0.25],
[0.38 ,0.23 ,130 ,0.41 ,0.13 ,0.24],
[0.46 ,0.28 ,130 ,0.50 ,0.11 ,0.16],
[0.46 ,0.28 ,130 ,0.50 ,0.11 ,0.16],
[0.46 ,0.28 ,130 ,0.50 ,0.11 ,0.16],
[0.46 ,0.28 ,130 ,0.50 ,0.11 ,0.16]
];

// 0.41 ,0.25 ,120 ,0.39 ,0.13 ,0.25 
// 0.38 ,0.23 ,130 ,0.41 ,0.13 ,0.24 
// 0.46 ,0.28 ,130 ,0.50 ,0.11 ,0.16 
// 0.46 ,0.28 ,130 ,0.50 ,0.11 ,0.16 
// 0.46 ,0.28 ,130 ,0.50 ,0.11 ,0.16 
// 0.46 ,0.28 ,130 ,0.50 ,0.11 ,0.16 


//all the four situation be the same
var ProfitOtherPay = [
0.72 ,0.46 ,130 ,0.50 ,0.13 ,0.18 
];

function tt()
{
	alert("hello world");
}


 $("select[name='drxz']").bind("change", function() {
        discount();
        compute();
    });
    $("select[name='car_type']").bind("change", function() {
        //变更车辆类型，计算折扣率
        discount();
        compute();
    });


    $("input[name='txtwy']").bind("change", function() {
        discount();
        compute();
    });


//begin check box
    $("input[name='cbcsun']").bind("click", function() {
        compute();
    });

    $("input[name='cbsz']").bind("click", function() {
        compute();
    });

    $("input[name='cbches']").bind("click", function() {
        compute();
    });
    $("input[name='cbcheshuahe']").bind("click", function() {
        discount();
        compute();
    });

    $("input[name='zeren_driver']").bind("click", function() {
        discount();
        compute();
    });
    $("input[name='cbhh2']").bind("click", function() {
        compute();
    });

    $("input[name='cbzr2']").bind("click", function() {
        discount();
        compute();
    });

    //基本保险
    $("input[name='jdcsubx']").bind("click", function() {
        compute();
    });
    $("input[name='cbdsz']").bind("click", function() {
        discount();
        compute();
    });
    $("input[name='ckqcdq']").bind("click", function() {
        discount();
        compute();
    });
    $("input[name='cksj']").bind("click", function() {
        compute();
    });

    $("input[name='ckck']").bind("click", function() {
        discount();
        compute();
    });
    $("input[name='ckboli']").bind("click", function() {
        compute();
    });
    $("input[name='ckhh']").bind("click", function() {
        compute();
    });
    $("input[name='ckzr']").bind("click", function() {
        compute();
    });

  //end checkbox

  //select box
$("input[name='drssbx']").bind("change", function() {
        discount();
        compute();
    });

$("input[name='drds']").bind("change", function() {
        discount();
        compute();
    });

$("input[name='drsj']").bind("change", function() {
        discount();
        compute();
    });

$("input[name='drck']").bind("change", function() {
        discount();
        compute();
    });
$("input[name='ckboli']").bind("change", function() {
        discount();
        compute();
    });


//end selectbox





 function getcaryear() {
        var firstregdate = $("#first_reg_date").val();
        var myDate = new Date();
        var nowDate = myDate.getFullYear() + '-' + (myDate.getMonth() + 1) + '-' + myDate.getDate();
        return daysBetween(firstregdate, nowDate, 'y')
    }

    function getcarmonth() {
        var firstregdate = $("#first_reg_date").val();
        var myDate = new Date();
        var nowDate = myDate.getFullYear() + '-' + (myDate.getMonth() + 1) + '-' + myDate.getDate();
        return daysBetween(firstregdate, nowDate, 'm');
    }

    function daysBetween(DateOne, DateTwo, strInterval) {


        var dtStart = new Date(DateOne);
        var dtEnd = new Date(DateTwo);
        switch (strInterval) {
            case 's': return parseInt((dtEnd - dtStart) / 1000);
            case 'n': return parseInt((dtEnd - dtStart) / 60000);
            case 'h': return parseInt((dtEnd - dtStart) / 3600000);
            case 'd': return parseInt((dtEnd - dtStart) / 86400000);
            case 'w': return parseInt((dtEnd - dtStart) / (86400000 * 7));
            case 'm':
                if ((dtEnd.getDate() - dtStart.getDate()) > 1)
                    return (dtEnd.getMonth() + 1) + ((dtEnd.getFullYear() - dtStart.getFullYear()) * 12) - (dtStart.getMonth() + 1) + 1;
                else
                    return (dtEnd.getMonth() + 1) + ((dtEnd.getFullYear() - dtStart.getFullYear()) * 12) - (dtStart.getMonth() + 1);
            case 'y': return (dtEnd - dtStart) / (86400000 * 365);
        }
    }

    function daysdiff() {
        var DateOne = $("#first_reg_date").val();
        var myDate = new Date();
        var DateTwo = myDate.getFullYear() + '-' + (myDate.getMonth() + 1) + '-' + myDate.getDate();

        var dtStart = new Date(DateOne);
        var dtEnd = new Date(DateTwo);
        var month;
        if ((dtEnd.getDate() - dtStart.getDate()) > 1)
            month = (dtEnd.getMonth() + 1) + ((dtEnd.getFullYear() - dtStart.getFullYear()) * 12) - (dtStart.getMonth() + 1) + 1;
        else
            month = (dtEnd.getMonth() + 1) + ((dtEnd.getFullYear() - dtStart.getFullYear()) * 12) - (dtStart.getMonth() + 1);

        //alert(month);
        //alert(dtEnd.getDate());
        //alert(dtStart.getDate());

        if ((dtEnd.getDate()) > (dtStart.getDate())) {
            if (dtEnd.getDate() - dtStart.getDate() > 15)
                return ++month;
            else
                return month;
        } else {
            if (30 + dtEnd.getDate() - dtStart.getDate() > 15)
                return month;
            else
                return --month;
        }
    }


 function selectbaoxian(){
        if($("#insurer").val() == 1){
            //alert('人保');
            renbaochuantong();
        }
        else if($("#insurer").val() == 2){
            //alert('平安');          
            //pinganchuantong();
            }

        }else if($("#insurer").val() == 3){
            //太平洋
            renbaochuantong();
        }
    }



 function xuanzhogn() {
            //  机动车损失保险
            var jdcsubx = document.getElementById('jdcsubx');
             var cbcsun = document.getElementById('cbcsun');

             if (jdcsubx.checked) {
                 cbcsun.checked = true;
             }
             if (!jdcsubx.checked) {
                 cbcsun.checked = false;
             }
           // 这边的是三者的
            var cbdsz = document.getElementById('cbdsz');
            var cbsz = document.getElementById('cbsz');
            if (cbdsz.checked) {
                cbsz.checked = true;
            }
            if (!cbdsz.checked) {
                cbsz.checked =false;
            }
            //盗抢险的
            var ckqcdq = document.getElementById('ckqcdq');
            var cbches = document.getElementById('cbches'); 
             if (ckqcdq.checked) {
                cbches.checked = true;
            }
            if (!ckqcdq.checked) {
                cbches.checked =false;
            }
            //车上人员司机位
            var txtzuowei = document.getElementById('txtzuowei');
            var cksj = document.getElementById('cksj');
            var ckck = document.getElementById('ckck');
            var cbcheshuahe = document.getElementById('cbcheshuahe');
            var txtgs = document.getElementById('txtgs');
            //这边是里面的座位
            

            if (cksj.checked || ckck.checked) {
                cbcheshuahe.checked = true;
            }
            if (!cksj.checked && !ckck.checked) {
                cbcheshuahe.checked = false;
            }
            if (ckck.checked) {

                if (txtzuowei.value.length > 0 && txtzuowei.value != "0") {

                    txtgs.value =parseInt(txtzuowei.value) - 1;
                    
                }
            
            }
            //车上划痕损失费
            var ckhh = document.getElementById('ckhh');
            var cbhh2 = document.getElementById('cbhh2');
            if (ckhh.checked) {
                cbhh2.checked = true;
            }
            if (!ckhh.checked) {
                cbhh2.checked = false;
            }
            //自燃
            var ckzr = document.getElementById('ckzr');
            var cbzr2 = document.getElementById('cbzr2');

            if (ckzr.checked) {
                cbzr2.checked = true;
            }
            if (!ckzr.checked) {
                cbzr2.checked = false;
            }
         }

function mianpei(){
	    //损失
        if ($("input[name='jdcsubx']").is(":checked") == true && $("input[name='cbcsun']").is(":checked") == true){
            $("#txtcs").val(($("#chesunxian").val()*0.15).toFixed(2));
        }else{
            $("#txtcs").val(0);     
        }
        
        //三者
        if ($("input[name='cbdsz']").is(":checked") == true && $("input[name='cbsz']").is(":checked") == true){
            $("#txtds2").val(($("#sanze_result").val()*0.15).toFixed(2));
        }else{
            $("#txtds2").val(0);       
        }
        
        //盗抢
        if ($("input[name='ckqcdq']").is(":checked") == true && $("input[name='cbches']").is(":checked") == true){
            $("#txtdx2").val(($("#huahen_result").val()*0.20).toFixed(2));
        }else{
            $("#txtdx2").val(0);      
        }
        
        //this may be some problem
        if ($("input[name='cbcheshuahe']").is(":checked") == true && ($("input[name='cksj']").is(":checked") == true ||
         $("input[name='ckck']").is(":checked") == true)) {
         	var drivervalue  = $("#txtsj").val();
            var chengkevalue = $("#txtck").val();
            var resultinput = isNaN(drivervalue)?0:drivervalue + isNaN(chengkevalue)?0:chengkevalue;
	      $("#txtcsry").val((resultinput*0.15).toFixed(2));
        }
        else{
            $("#txtcsry").val(0);        
        }
        //end 
        
        if ($("input[name='ckhh']").is(":checked") == true && $("input[name='cbhh2']").is(":checked") == true){
            $("#txthh2").val((($("#txtsj").val() + $("#txtck").val())*0.15).toFixed(2));
        }else{
            $("#txthh2").val(0);       
        }
        
        if ($("input[name='ckzr']").is(":checked") == true && $("input[name='cbzr2']").is(":checked") == true){
            $("#txtzr2").val(($("#daoqiang_result").val()*0.15).toFixed(2));
        }else{
            $("#txtzr2").val(0);        
        }
        
    }
function renbaochuantong(){
                if($("input[name='jdcsubx']").is(":checked") == true){
                    renbaochuantong_chesun();
                }else{
                    $("#txtjdc").val(0);
                }
                
                if($("input[name='cbdsz']").is(":checked") == true){
                    renbaochuantong_sanze();
                }else{
                    $("#txtds").val(0);
                }
                
                if($("input[name='ckqcdq']").is(":checked") == true){
                    renbaochuantong_daoqiang();
                }else{
                    $("#txtdx").val(0);
                }
                
                if($("input[name='cksj']").is(":checked") == true){
                    renbaochuantong_zeren_driver();
                }else{
                    $("#txtsj").val(0);
                }
                if($("input[name='ckck']").is(":checked") == true){
                    renbaochuantong_zeren_chengke();
                }else{
                    $("#txtck").val(0);
                }
                
                if($("input[name='ckhh']").is(":checked") == true){
                    huahenxian();
                }else{
                    $("#txthh").val(0);
                }
                
                if($("input[name='ckzr']").is(":checked") == true){
                    renbaoziranxian();
                }else{
                    $("#txtzr").val(0);
                }

                if($("input[name='ckboli']").is(":checked") == true){
                    renbaochuantong_boli();
                }else{
                    $("#txtboli").val(0);
                }
                
    }


function total(){
        var total = 0;
        if(!isNaN($("#txtjdc").val()))
            total += parseFloat($("#txtjdc").val());

        if(!isNaN($("#txtcs").val()))
            total += parseFloat($("#txtcs").val());  

        if(!isNaN($("#txtds").val()))
            total += parseFloat($("#txtds").val());

        if(!isNaN($("#txtds2").val()))
            total += parseFloat($("#txtds2").val());

        if(!isNaN($("#txtsj").val()))
            total += parseFloat($("#txtsj").val());

        if(!isNaN($("#txtck").val()))
            total += parseFloat($("#txtck").val());

        if(!isNaN($("#ckqcdq").val()))
            total += parseFloat($("#ckqcdq").val());

        if(!isNaN($("#txtdx2").val()))
            total += parseFloat($("#txtdx2").val());

        if(!isNaN($("#txtboli").val()))
            total += parseFloat($("#txtboli").val());

        if(!isNaN($("#txthh").val()))
            total += parseFloat($("#txthh").val());

        if(!isNaN($("#txthh2").val()))
            total += parseFloat($("#txthh2").val());

        if(!isNaN($("#txtzr").val()))
            total += parseFloat($("#txtzr").val());

        if(!isNaN($("#txtzr2").val()))
            total += parseFloat($("#txtzr2").val());

        if(!isNaN($("#txtcsry").val()))
            total += parseFloat($("#txtcsry").val());

        //$("#txtzje").val(total.toFixed(2));
        //+$("#chechuanshui").val()+$("#jiaoqiangxian").val()
        var total_all = 0;
        total_all += total;
        if(!isNaN($("#txtjqx").val()))
            total_all += parseFloat($("#txtjqx").val());
        if(!isNaN($("#txtzc").val()))
            total_all += parseFloat($("#txtzc").val());
        $("#total_all").val(total_all.toFixed(2));
            
    }
function compute()
{
	alert("hello world");
       // selectbaoxian();    //选择保险公司
       // mianpei();
       // //计算折扣
       // //车损
       // var discount = $("#txthuiyuan").val();
       // if (discount <0 || discount >1 || isNaN(discount)) {
       // 	discount = 1;
       // };
//
       // $("#txtjdc").val(($("#txtjdc").val()*discount).toFixed(2));
       // $("#txtcs").val(($("#txtcs").val()*discount).toFixed(2));
       // //三责
       // $("#txtds").val(($("#txtds").val()*discount).toFixed(2));
       // $("#txtds2").val(($("#txtds2").val()*discount).toFixed(2));
       // //驾驶员责任
       // $("#txtsj").val(($("#txtsj").val()*discount).toFixed(2));
       //
       // //乘客责任
       // $("#txtck").val(($("#txtck").val()*discount).toFixed(2));
       // //盗抢险
       // $("#ckqcdq").val(($("#ckqcdq").val()*discount).toFixed(2));
       // $("#txtdx2").val(($("#txtdx2").val()*discount).toFixed(2));
       // //玻璃险
       // $("#txtboli").val(($("#txtboli").val()*discount).toFixed(2));
       // //划痕险
       // $("#txthh").val(($("#txthh").val()*discount).toFixed(2));
       // $("#txthh2").val(($("#txthh2").val()*discount).toFixed(2));
       // 
       // //自燃险
       // $("#txtzr").val(($("#txtzr").val()*discount).toFixed(2));
       // $("#txtzr2").val(($("#txtzr2").val()*discount).toFixed(2));
//
       // $("#txtcsry").val(($("#txtcsry").val()*discount).toFixed(2));
       // 
       // total();
}

function discount()
{

}

function huahenxian(){
    var year = getcaryear();
    var price = $("#price").val();
    var huahen_type = $("#drhh").val(); 
    
    if(year < 2){
        if(price < 300000){
            if(huahen_type == 1){
                $("#txthh").val(400);
            }else 
                $("#txthh").val(570);
            }
        }else if(price < 500000){
            if(huahen_type == 1){
                $("#txthh").val(585);
            }else 
                $("#txthh").val(585);
            }
        }else{
            if(huahen_type == 1){
                $("#txthh").val(850);
            }else 
                $("#txthh").val(850);
            }
        }
    }else{
        if(price < 300000){
            if(huahen_type == 1){
                $("#txthh").val(610);
            }else 
                $("#txthh").val(850);
            }
        }else if(price < 500000){
            if(huahen_type == 1){
                $("#txthh").val(900);
            }else 
                $("#txthh").val(900);
            }
        }else{
            if(huahen_type == 1){
                $("#txthh").val(1100);
            }else 
                $("#txthh").val(1100);
            }
        }
    }
}

function renbaochuantong_chesun(){
        // var year = getcaryear();
        // var yearType = 0;
        // 	if (year<1) {
        // 		yearType = 0;
        // 	}
        // 	else if(year <4)
        // 	{
        // 		yearType = 1;
        // 	}else if (year <6) 
        // 	{
        // 		yearType =2;
        // 	}else if(year < 8)
        // 	{
        // 		yearType = 3;
        // 	}
        // 	else
        // 	{
        // 		yearType = 4;
        // 	}

        //set the value is 0 1 2 3 4
        var yearType = $("#drssbx").val();
        var car_type = $("#drxz").val();
        var car_vol  = $("#drzl").val();

        var price = $("#txtwy").val() * 10000;
        if (car_type == 1){
        	
        	
        	var basePrice = SunshiPersonnalCar[car_vol-1][2*yearType];
        	var baseRate  = SunshiPersonnalCar[car_vol-1][2*yearType + 1 ];
        	$("#txtjdc").val((price*baseRate+basePrice).toFixed(2));
        }
        else if (car_type == 2) {
        	var basePrice = SunshiCompanyNoneProfitCar[car_vol-1][2*yearType];
        	var baseRate  = SunshiCompanyNoneProfitCar[car_vol-1][2*yearType + 1 ];
        	$("#txtjdc").val((price*baseRate+basePrice).toFixed(2));
        }
        else
        {
        	var basePrice = SunShiProfitCar[car_vol-1][2*yearType];
        	var baseRate  = SunShiProfitCar[car_vol-1][2*yearType + 1 ];
        	$("#txtjdc").val((price*baseRate+basePrice).toFixed(2));
        }

    }
function renbaochuantong_sanze(){
        var sanze_type = $("#drds").val();
        var car_type = $("#drxz").val();
        var car_vol  = $("#drzl").val();
        //注意防止越界

        if (car_type == 1){
        	
        	var sanzeValue = PersonnalUseCarPay[car_vol-1][sanze_type-1];
        	$("#txtds").val(sanzeValue);
        }
        else if (car_type == 2) {
        	var sanzeValue = CompanyNoprofitUseCarPay[car_vol-1][sanze_type-1];
        	$("#txtds").val(sanzeValue);
        }
        else
        {
        	var sanzeValue = ProfitUsedCarPay[car_vol-1][sanze_type-1];
        	$("#txtds").val(sanzeValue);
        }
    }
    
function renbaochuantong_zeren_driver(){
    var zeren_driver = $("#drsj").val();
    var car_type = $("#drxz").val();
    var car_vol  = $("#drzl").val();
    //注意防止越界

    if (car_type == 1){
    	
    	var zerenDriverValue = PersonnalUseOtherPay[car_vol-1][0];
    	 $("#txtsj").val((zeren_driver*10000*zerenDriverValue).toFixed(2));
    }
    else if (car_type == 2) {
    	var sanzeValue = CompanyNoneProfitOtherPay[car_vol-1][0];
    	$("#txtsj").val((zeren_driver*10000*zerenDriverValue).toFixed(2));
    }
    else
    {
    	var sanzeValue = ProfitOtherPay[0][0];
    	$("#txtsj").val((zeren_driver*10000*zerenDriverValue).toFixed(2));
    }
}

function renbaochuantong_zeren_chengke(){
    var seat = $("#txtgs").val();

    var zeren_driver = $("#ckck").val();
    var car_type = $("#drxz").val();
    var car_vol  = $("#drzl").val();
    //注意防止越界

    if (car_type == 1){
    	
    	var zerenChengKeValue = PersonnalUseOtherPay[car_vol-1][0];
    	 $("#txtck").val((zeren_driver*10000*zerenDriverValue*(seat - 1)).toFixed(2));
    }
    else if (car_type == 2) {
    	var zerenChengKeValue = CompanyNoneProfitOtherPay[car_vol-1][1];
    	$("#txtck").val((zeren_driver*10000*zerenDriverValue*(seat - 1)).toFixed(2));
    }
    else
    {
    	var zerenChengKeValue = ProfitOtherPay[0][1];
    	$("#txtck").val((zeren_driver*10000*zerenDriverValue*(seat - 1)).toFixed(2));
    }
    
}
    
function renbaochuantong_daoqiang(){        

    var price = $("#txtwy").val();

    var car_type = $("#drxz").val();
    var car_vol  = $("#drzl").val();
    //var month = getcarmonth();
    var month = daysdiff(); 

    var oldrate = 0.006;
    if (car_type =1 && car_vol == 3) {
    	oldrate = 0.009;
    };
    
    var oldprice = price - price*oldrate*month;
    // $("#daoqiang_old_price").val(oldprice.toFixed(2));


    var qiangDaoBasePrice = 0;

    //注意防止越界

    if (car_type == 1){
    	
    	var qiangDaoBasePrice = PersonnalUseOtherPay[car_vol-1][2];
    	var qiangDaoBaseRate  = PersonnalUseOtherPay[car_vol-1][3];
    	$("#txtdx").val((oldprice*qiangDaoBaseRate + qiangDaoBasePrice).toFixed(2));
    }
    else if (car_type == 2) {
    	var qiangDaoBasePrice = CompanyNoneProfitOtherPay[car_vol-1][2];
    	var qiangDaoBaseRate  = CompanyNoneProfitOtherPay[car_vol-1][3];
    	$("#txtdx").val((oldprice*qiangDaoBaseRate + qiangDaoBasePrice).toFixed(2));
    }
    else
    {
    	var qiangDaoBasePrice = ProfitOtherPay[0][2];
    	var qiangDaoBaseRate  = ProfitOtherPay[0][3];
    	$("#txtdx").val((oldprice*qiangDaoBaseRate + qiangDaoBasePrice).toFixed(2));
    }
       
}
    
function renbaochuantong_boli(){

    var boli_type = $("#drboli").val();
    var car_type = $("#drxz").val();
    var price = $("#txtwy").val();
    var car_vol  = $("#drzl").val();
    //var month = getcarmonth();
    
    //注意防止越界
    //define boli_type =0 or 1

    if (car_type == 1){	
    	var BoliRate = PersonnalUseOtherPay[car_vol-1][4+boli_type];
    	$("#txtboli").val((price*BoliRate).toFixed(2));
    }
    else if (car_type == 2) {
    	var BoliRate = CompanyNoneProfitOtherPay[car_vol-1][4+boli_type];
    	$("#txtboli").val((price*BoliRate).toFixed(2));
    }
    else
    {
    	var BoliRate = ProfitOtherPay[0][4 + boli_type];
    	$("#txtboli").val((price*BoliRate).toFixed(2));
    }      
}
function renbaoziranxian(){
    var price = $("#txtwy").val();
    var month = getcarmonth();
    var year = getcaryear();
    var car_type = $("#drxz").val();
    //alert(year);
    //alert(parseInt(year));
    if( (year-parseInt(year)) >0.85){
        year = parseInt(year)+1;
    }
    oldrate = 0.006;
    if (car_type =1 && car_vol == 3) {
	   oldrate = 0.009;
    };
    var oldprice = price - price*oldrate*month;
    //$("#ziran_old_price").val(oldprice.toFixed(2)); 
    
    if(year <2){  
        if (car_type == 3) {
        	$("#txtzr").val((oldprice*0.002).toFixed(2)); 
        }
        else
        {
        	$("#txtzr").val((oldprice*0.0012).toFixed(2)); 
        }    
                 
    }else if(year < 4){
        if (car_type == 3) {
        	$("#txtzr").val((oldprice*0.003).toFixed(2)); 
        }
        else
        {
        	$("#txtzr").val((oldprice*0.002).toFixed(2)); 
        }  
    }else if (year <6)
    {
        if (car_type == 3) {
        	$("#txtzr").val((oldprice*0.0045).toFixed(2)); 
        }
        else
        {
        	$("#txtzr").val((oldprice*0.003).toFixed(2)); 
        } 
    }
    else
    {
    	if (car_type == 3) {
        	$("#txtzr").val((oldprice*0.006).toFixed(2)); 
        }
        else
        {
        	$("#txtzr").val((oldprice*0.005).toFixed(2)); 
        } 
    }
}












 
 

