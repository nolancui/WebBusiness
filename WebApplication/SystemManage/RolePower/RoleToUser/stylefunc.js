var Tr_className;
function Mover11(go, F) { //"#FFF3CA" "#a3ceec"
    Tr_className = go.className;
    go.className = F;
}
function MoutAll(come, F1, F2) {
    if (Tr_className == F1)
        come.className = F1;
    else
        come.className = F2;
}

function showdiv() {
divWait.style.pixelTop = document.body.offsetHeight / 2 - parseInt(divWait.style.height) / 2;
divWait.style.pixelLeft = document.body.offsetWidth / 2 - parseInt(divWait.style.width) / 2;
divWait.style.visibility = "visible";
return;
}
function hidediv() {
divWait.style.visibility = "hidden";
}

function MoverWrite(go){ 
//var go;
go.style.background="#3366CC";
go.style.color="#FFFFFF";
}

function Mout1Write(come){ 
//var come;
come.style.background="#EFEFEF";
come.style.color="#000000";}