function Mover(go){go.bgColor="#ffe2b6";}
function Mout2(come){come.bgColor="#f1eeee";}

function winModal(strTemp,strMessage) {
winM=window.showModalDialog(strTemp,strMessage,"dialogHeight: 660px; dialogWidth: 720px; center: Yes; help: No; resizable: no; status:no;scroll:no;");
}
function winModeless(strTemp,strMessage) {
winM=window.showModelessDialog(strTemp,strMessage,"dialogHeight: 660px; dialogWidth: 720px; center: Yes; help: No; resizable: no; status:no;scroll:no;");
}
function winModalMIS(strTemp,strMessage) {
winM=window.showModelessDialog(strTemp,strMessage,"dialogHeight: 570px; dialogWidth: 957px; center: Yes; help: No; resizable: no; status:no;scroll:no;");
//winM=window.showModalDialog(strTemp,strMessage,"dialogHeight: 520px; dialogWidth: 957px; center: Yes; help: No; resizable: no; status:no;scroll:no;");
}

function setParentUrl(url){
var parWin=window.dialogArguments.window;
parWin.location.href=url;
window.close();
}

function winModalTel(strTemp,strMessage) {
winMTel=window.showModalDialog(strTemp,strMessage,"dialogHeight: 350px; dialogWidth: 520px; center: Yes; help: No; resizable: no; status: no;scroll:no;");
}

function setParentUrlTel(url){
var parWinTel=window.dialogArguments.window;
parWinTel.location.href=url;
window.close();
}

function popwin(sUrl,sWidth,sHeight,sTitle){
window.open(sUrl,''+sTitle,'status=no,height='+sHeight+',width='+sWidth+',toolbar=no,scrollbars=yes,menubar=no,resizable=0,location=no,top=30,left=127');
}
function popwin2(sUrl, sWidth, sHeight, sTitle) {
    window.open(sUrl, '' + sTitle, 'status=no,height=' + sHeight + ',width=' + sWidth + ',toolbar=no,scrollbars=yes,menubar=no,resizable=0,location=no,top=30,left=127');
}
function popwin3(sUrl,sWidth,sHeight,sTitle,stop,sleft){
window.open(sUrl,''+sTitle,'status=no,height='+sHeight+',width='+sWidth+',toolbar=no,scrollbars=no,menubar=no,resizable=0,location=no,top='+stop+',left='+sleft+'');
}
function popwin5(sUrl,sWidth,sHeight,sTitle,stop,sleft,res,scro){
window.open(sUrl,''+sTitle,'status=no,height='+sHeight+',width='+sWidth+',toolbar=no,scrollbars='+scro+',menubar=no,resizable='+res+',location=no,top='+stop+',left='+sleft+'');
}

function popwin4(sUrl, sWidth, sHeight, sTitle, stop, sleft, res) {
    window.open(sUrl, '' + sTitle, 'status=no,height=' + sHeight + ',width=' + sWidth + ',toolbar=no,scrollbars=no,menubar=no,resizable=' + res + ',location=no,top=' + stop + ',left=' + sleft + '');
}


function popwin21(sUrl) {
    //    window.open(sUrl, '' + sTitle, 'status=no,height=' + sHeight + ',width=' + sWidth + ',toolbar=no,scrollbars=yes,menubar=no,resizable=0,location=no,top=30,left=127');

    parent.parent.mainFrame.location.href = sUrl;
}

function KeyDown(){
//onclick="javascript:KeyDown();" onkeydown="javascript:KeyDown();"
if ((window.event.altKey)&&
      ((window.event.keyCode==37)||   //屏蔽 Alt+ 方向键 ←
       (window.event.keyCode==39))){  //屏蔽 Alt+ 方向键 →
     event.returnValue=false;
     }
  if (
//(event.keyCode==8)  ||                 //屏蔽退格删除键
      (event.keyCode==116)||                 //屏蔽 F5 刷新键
      (event.ctrlKey && event.keyCode==82)){ //Ctrl + R
     event.keyCode=0;
     event.returnValue=false;
     }
  if ((event.ctrlKey)&&(event.keyCode==78))   //屏蔽 Ctrl+n
     event.returnValue=false;
  if ((event.shiftKey)&&(event.keyCode==121)) //屏蔽 shift+F10
     event.returnValue=false;
  if (window.event.srcElement.tagName == "A" && window.event.shiftKey) 
      window.event.returnValue = false;  //屏蔽 shift 加鼠标左键新开一网页
  if ((window.event.altKey)&&(window.event.keyCode==115)){ //屏蔽Alt+F4
      window.showModelessDialog("about:blank","","dialogWidth:1px;dialogheight:1px");
      return false;}
  }

  function showdiv() {
      divWait.style.pixelTop = document.body.offsetHeight / 2 - parseInt(divWait.style.height) / 2 + 77;
      //divWait.style.pixelTop =document.body.clientHeight/ 2 - parseInt(divWait.style.height) / 2+77;

      divWait.style.pixelLeft = document.body.offsetWidth / 2 - parseInt(divWait.style.width) / 2;
      divWait.style.visibility = "visible";
  }
  function hidediv() {
      divWait.style.visibility = "hidden";
 }