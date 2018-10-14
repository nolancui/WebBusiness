<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3c.org/TR/1999/REC-html401-19991224/loose.dtd">
<!-- saved from url=(0037)http://120.55.240.108:8088/Clock.aspx -->
<HTML xmlns="http://www.w3.org/1999/xhtml"><HEAD><TITLE>Clock</TITLE>
<META content="text/html; charset=gb2312" http-equiv=Content-Type>
<META url="" content=55 http-equiv=Refresh><LINK rel=stylesheet type=text/css 
href="Clock/down.css">
<SCRIPT type=text/javascript>
        //--------------CallCenter window-------------
        var oPopup = window.createPopup();
        var popTop=50;
        function popmsg(msgstr){
        //msgstr=convertStr(msgstr);
            var winstr = "<table id=\"b\" width=\"200\" height=\"177\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" background=\"images/pop1.gif\">";
        winstr+="<tr><td height=\"27\"></td></tr><tr><td align=\"center\"><table width=\"96%\" height=\"120\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">";
        winstr+="<tr><td align=\"center\" valign=\"top\" style=\"word-break: break-all;font-size:12px;color: #FFFFFF;\">"+msgstr+"</td></tr></table></td></tr><tr><td height=\"37\"></td></tr></table>";
        oPopup.document.body.innerHTML = winstr;
        popshow();
        }
        function popshow(){
        //window.status=popTop;
        if(popTop>1720){
        clearTimeout(mytime);
        oPopup.hide();
        return;
        }else if(popTop>1520&&popTop<1720){
        oPopup.show(screen.width-205,screen.height,200,1720-popTop);
        }else if(popTop>1500&&popTop<1520){
        oPopup.show(screen.width-205,screen.height+(popTop-1720),200,177);
        }else if(popTop<180){
        oPopup.show(screen.width-205,screen.height,200,popTop);
        }else if(popTop<220){
        oPopup.show(screen.width-205,screen.height-popTop+13,200,177);
        }
        popTop+=15;
        var mytime=setTimeout("popshow();",50);
        }
        //popmsg("&nbsp;&nbsp;有新业务。");
        //--------------BSCallCenter window-------------
         "; setTimeout("popmsg(pop);",500);
    </SCRIPT>

<META name=GENERATOR content="MSHTML 8.00.7601.19104"></HEAD>
<BODY>
<FORM id=form1 method=post name=form1 action=Clock.aspx>
<DIV><INPUT id=__VIEWSTATE 
value=/wEPDwUKMjA0MjMxNTU1OGRkDDgEuNyOLLQ3/gXYvC7a0sizRwoN44nvhTOjLysF6e4= 
type=hidden name=__VIEWSTATE> </DIV></FORM></BODY></HTML>
