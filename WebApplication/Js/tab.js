
var logPath = '';
var menuColor='000000';
var textColor='333333';
var isMSIE = (navigator.appName == "Microsoft Internet Explorer");
var isOpera = navigator.userAgent.indexOf('Opera') != -1;
var fuckAlexa = false;
var bFirst = true;
var agreeMailPopUp = true;

//var menu_mode = 1;
function onClubClick(id, str, url, isNode)
{
	MDIOpen(url);
}

function onclickH(e){return onclickHook(e ? e : parent.leftFrame);}
function onclickME(e){return onclickHook(e ? e : window);}

var nowWindow = -1;
var maxWindow = 0;
var ocs = new Array();
var ocs_tab = new Array();
var wl = 90;
var bLeft = false, bRight = false;

function scrollTab(s)
{
	var w = tabs.document.body.offsetWidth;
	var l = mdi.frames.length * wl;

	tabs.scrollTo(s, 0);

	if(s)
	{
		document.getElementById("tab_left").src = "FRMTab/tab_left.gif"
		bLeft = true;
	}else
	{
		document.getElementById("tab_left").src = "FRMTab/tab_left_gray.gif"
		bLeft = false;
	}

	if(s + w < l)
	{
		document.getElementById("tab_right").src = "FRMTab/tab_right.gif"
		bRight = true;
	}else
	{
		document.getElementById("tab_right").src = "FRMTab/tab_right_gray.gif"
		bRight = false;
	}
}

function onresizeH(e)
{
	var w = tabs.document.body.offsetWidth;
	var l = mdi.frames.length * wl;
	var s = tabs.scrollX ? tabs.scrollX : tabs.document.body.scrollLeft;

	if(nowWindow != -1)
	{
		var p = tabs.document.getElementById("tab_" + nowWindow).offsetLeft;

		if(l == wl * 2)
		{
			setTimeout("tabs.scrollTo(0, 0);", 0);
			return;
		}else if(l == wl)
		{
			document.getElementById("tab_left").src = "FRMTab/tab_left_gray.gif"
			bLeft = false;

			document.getElementById("tab_right").src = "FRMTab/tab_right_gray.gif"
			bRight = false;
			return;
		}

		if(p < s)
		{
			s = p;
			if(l < w + s)s = l - w;
		}else if(p > w + s - wl)
		{
			s = p - w + wl;
			if(l < w + s)s = l - w;
		}else if(l < w + s)
		{
			s = l - w;
		}else return;

		if(s < 0)s = 0;
		scrollTab(s);
	}
}

onresize = onresizeH;

function onLefttab()
{
	var s = tabs.scrollX ? tabs.scrollX : tabs.document.body.scrollLeft;

	s -= s % wl;
	if(s > 0)s -= wl;
	scrollTab(s);
}

function onRighttab()
{
	var w = tabs.document.body.offsetWidth;
	var l = mdi.frames.length * wl;
	var s = tabs.scrollX ? tabs.scrollX : tabs.document.body.scrollLeft;

	s += wl;
	if(s + w > l)s = l - w;
	scrollTab(s);
}

function onTabDblClock()
{
	setTimeout("MDIClose();", 0);
}

function MDISwitch(i)
{
	if(nowWindow == i)return false;

	var ow, nw;

	if(nowWindow != -1)
	{
		tabs.document.getElementById("tab_" + nowWindow).className = "tab-unselect";
		ow = mdi.document.getElementById("mdi_" + nowWindow);

		ow.scrollPos = 0;
		if(ow.Attached && ow.contentWindow)if(ow.contentWindow.document)if(ow.contentWindow.document.body)
			ow.scrollPos = ow.contentWindow.document.body.scrollTop;

		ow.LastAccess = (new Date()).getTime();
		ow.style.display = "none";
	}

	nw = mdi.document.getElementById("mdi_" + i);

	nw.style.display = "";

	try
	{
		if(nw.scrollPos)
			nw.contentWindow.scrollTo(0, nw.scrollPos);
	}catch(e){};

	nowWindow = i;
	tabs.document.getElementById("tab_" + nowWindow).className = "tab-select";
document.all.TempPra.value=nowWindow;
	onresizeH();

	return false;
}

function MDIClose()
{
	var i, f, la = 0, lw;

	if(nowWindow != -1)
	{
		var TabFrmSrc=eval("mdi.mdi_"+nowWindow).document.location.href;
	    	//var Flag=TabFrmSrc.substr(str.lastIndexOf("/")+1);
	   	var Flag=TabFrmSrc.replace(/(.+)[\\/]/,"").toLowerCase();

		tabs.document.getElementById("tab_list").removeChild(tabs.document.getElementById("tab_" + nowWindow));
		mdi.document.body.removeChild(mdi.document.getElementById("mdi_" + nowWindow));

		//top.RemoveSfrm.location.href="../RemoveSes.aspx?Flag="+Flag;

		for(i = 0; i < maxWindow; i ++)
		{
			if(nowWindow != i)
			{
				f = mdi.document.getElementById("mdi_" + i)
				if(f)
				{
					if(la < f.LastAccess)
					{
						la = f.LastAccess;
						lw = i;
					}
				}
			}
		}

		nowWindow = -1;
		if(la)MDISwitch(lw);
	}
	return false;
}

function MDIRefresh()
{
	var f;
	var l;

	f = mdi.document.getElementById("mdi_" + nowWindow);
	l = "";
	try
	{
		if(f)
			if(f.contentDocument)
				f.contentDocument.location = f.contentDocument.location;
			else eval("mdi.mdi_" + nowWindow).document.location = eval("mdi.mdi_" + nowWindow).document.location;
	}catch(e){}
}

function MDILoad(n, url)
{
	var f;
	var l;

	f = mdi.document.getElementById("mdi_" + n);
	l = "";
	try
	{
		if(f)
			if(f.contentDocument)
				l = f.contentDocument.location = url;
			else l = eval("mdi.mdi_" + n).document.location = url;
	}catch(e){}
}

function MDIOpen(url, nActiveMode)
{
	if(typeof nActiveMode == 'undefined')nActiveMode = 1;
	if(nowWindow == -1)nActiveMode = 1;

	if(url.charAt(0) == "/")
		url = "http://" + location.host + url;

	var i, f, l, l1, n;
	var url1 = url.toLowerCase();

	for(i = 0; i < maxWindow; i ++)
	{
		f = mdi.document.getElementById("mdi_" + i);
		l = "";
		l1 = "";
		try
		{
			if(f)
				if(f.contentDocument)
					l = '' + f.contentDocument.location;
				else l = '' + eval("mdi.mdi_" + i).document.location;
		}catch(e){}

		n = l.indexOf('?');
		if(n!=-1)l1 = l.substr(0, n);

		if(l.toString().toLowerCase() == url1 || l1.toString().toLowerCase() == url1)
		{
			if(nowWindow != i)
			{
				if(nActiveMode)
				{
					MDISwitch(i);
					if(nActiveMode == 2)
						setTimeout("mdi.document.getElementById(\"mdi_" + i + "\").src=\"" + url + "\"",0);
				}
			}else setTimeout("mdi.document.getElementById(\"mdi_" + i + "\").src=\"" + url + "\"",0);
			return;
		}
	}

	if(maxWindow > mdi.frames.length)
	{
		for(i = 0; i < maxWindow; i ++)
			if(!mdi.document.getElementById("mdi_" + i))
				break;
	}else
	{
		i = maxWindow;
		maxWindow ++;

		ocs[i] = new Function("return onclickHook(mdi.mdi_" + i + ");");
		ocs_tab[i] = new Function("MDISwitch(" + i + ");");
	}

	var nw = mdi.document.createElement("iframe")
	nw.width = "100%"
	nw.height = "100%"
	nw.frameBorder = 0
//	nw.scrolling = "yes"
	nw.id = "mdi_" + i;
	nw.LastAccess = (new Date()).getTime();
//	nw.Attached = true;
	nw.src = "blank.htm";
	nw.style.display = "none";

	if(isMSIE)
	{
		var ifHtml = nw.outerHTML;
		nw = mdi.document.createElement("div")
		nw.id = "mdi_" + i;
		mdi.document.body.appendChild(nw);

		mdi.document.getElementById("mdi_" + i).outerHTML = ifHtml;
	}else mdi.document.body.appendChild(nw);

	var td = tabs.document.createElement("td")
	td.className = "tab-unselect";
	td.width = wl;
	td.id = "tab_" + i;
	td.onclick=ocs_tab[i];
	td.ondblclick=onTabDblClock
	if(isOpera)
		td.innerHTML = "<a href='javascript:void(0);'>　加载中…</a>";
	else
		td.innerHTML = "　加载中…";
	tabs.document.getElementById("tab_list").appendChild(td);

	if(nActiveMode)MDISwitch(i);
	else onresizeH();

	setTimeout('MDILoad(' + i + ',"' + url + '");', 0);
}

function HtmlEncode(s)
{
	var s1;

	s1 = s.replace(new RegExp('&', 'g'), '&amp;');
	s1 = s1.replace(new RegExp('<', 'g'), '&lt;');
	s1 = s1.replace(new RegExp('>', 'g'), '&gt;');

	return s1;
}

function MDIonload(w, title)
{
	if(typeof title != 'undefined')
	{
		var s = new String(title);
		var l, n;

		l = 0;
		n = 0;
		while(l < 10 && n < s.length)
		{
			if(s.charCodeAt(n) > 128)
			{
				l ++;
				if(l == 10)break;
			}
			l ++;
			n ++;
		}

		if(n > 0)
		{
			if(isOpera)
				tabs.document.getElementById("tab_" + w).innerHTML = "<a href='javascript:void(0);'>　" + HtmlEncode(s.substr(0, n)) + "..</a>";
			else
				tabs.document.getElementById("tab_" + w).innerHTML = "　" + HtmlEncode(s.substr(0, n)) + "..";
			tabs.document.getElementById("tab_" + w).title = s;
			mdi.document.getElementById("mdi_" + w).Attached = true;
		};
	}
}

var oca = new Array();

function MDILoop()
{
	if(fuckAlexa)
	try
	{
		var i, o, path;

		for(i = 0; i < oca.length; i ++)
		{
			o = oca[i];
			path = o.getAttribute("path");
			if(path)
			{
				o.href = path;
				o.target = "_blank";
				o.setAttribute("path", '');
			}
		}

		oca = new Array();
	}catch(e){}
	else if(isMSIE && document.onclick && document.onclick!=onclickME)
		fuckAlexa = true;

	var f, f1;

	for(i = 0; i < maxWindow; i ++)
	{
		f = mdi.document.getElementById("mdi_" + i)
		try
		{
			if(f)
				if(f.contentDocument)
				{
					if(!f.contentDocument.clickhook)
					{
						f.contentDocument.onclick = onclickHook;
						f.contentDocument.clickhook = true;
						f.Attached = false;
					}
					if(!f.Attached)
						MDIonload(i, f.contentDocument.title);
				}else
				{
					f1 = eval("mdi.mdi_" + i)
					if(f1)if(f1.document)
					{
						if(!f1.document.clickhook)
						{
							if(fuckAlexa && f1.document.onclick)
								f1.document.oldclick = f1.document.onclick;
								//f1.document.onclick = ocs[i];
								f1.document.clickhook = true;
								f.Attached = false;
						}
						if(!f.Attached)
							MDIonload(i, f1.document.title);
					}
				}
		}catch(e){}
	}
}

setInterval("MDILoop()", 10);

function onclickStatHook(e, srcElement){
    while(srcElement && !srcElement.getAttribute("StatCode") && srcElement.parentNode != (e.document?e.document:e.currentTarget))
        srcElement = srcElement.parentNode;

    if(srcElement.getAttribute("StatCode")){
        try {
            var s = document.createElement('script');
			s.type = "text/javascript";
			//s.src = "http://webapp.xici.net/Statistic/StatCollect.asp?c=" + srcElement.getAttribute("StatCode") + "&" + (new Date()).getTime();
			document.getElementsByTagName("HEAD").item(0).appendChild(s);
        }catch(e){}
    }
}

//onerror=handleErr
function onclickHook(e)
{
	try{
		var srcElement = e.target ? e.target : e.event.srcElement;

		while(srcElement && srcElement.tagName.toLowerCase() != "a" && srcElement.tagName.toLowerCase() != "area" && srcElement.parentNode != (e.document?e.document:e.currentTarget))
			srcElement = srcElement.parentNode;

		if(!srcElement)
			return true;

		if((srcElement.tagName.toLowerCase() != "a" && srcElement.tagName.toLowerCase() != "area"))
			return true;

		if(srcElement.onclick)
		    if(srcElement.onclick.toString().indexOf("return") > -1)
		        return;

		onclickStatHook(e, srcElement);

		var hrefUrl = srcElement.href;
		var path = srcElement.getAttribute("path");

		if(typeof hrefUrl != 'undefined')
		{
			if(!path)
			{
				if(hrefUrl.substr(0, 11).toLowerCase() == "javascript:")return true;
				if(fuckAlexa && hrefUrl.search(/\.htm/i) > 0)
				{
					if(e.document.oldclick)
						e.document.oldclick();

					return true;
				}

				path = hrefUrl;
				hrefUrl = '';
			}else{
				if(path.substr(0, 7) != "http://" && path.substr(0, 1) != "/"){
					if(!e.location)
						path = this.location.pathname.substring(0, this.location.pathname.lastIndexOf("/") + 1) + path;
					else
						path = e.location.pathname.substring(0, e.location.pathname.lastIndexOf("/") + 1) + path;
				}
			}

			if(!srcElement.target || (srcElement.target.toLowerCase() != "_blank" && srcElement.target.toLowerCase() != "_self" && srcElement.target.toLowerCase() != "mainframe"))
			{
				if(srcElement.target.toLowerCase() == "_top")
				{
					//document.cookie = "xicifrmact=1; domain=xici.net; path=/;";
					top.location = path;
					return false;
				}

				if(e.document.oldclick)
					e.document.oldclick();

				if(srcElement.target != "")
				{
					window.open(path);
					return false;
				}

				return true;
			}

			if(fuckAlexa && hrefUrl == '')
			{
				srcElement.href = 'javascript:void(0);';
				srcElement.target = "_self";
				srcElement.setAttribute("path", path);
				oca.push(srcElement);
			}
			MDIOpen(path);

			return false;
		}
	}catch(e){alert(e.description);}

	return true;
}
//function handleErr(msg,url,l)
//{
//txt="";
//txt+="Error: " + msg + "\n";
//txt+="URL: " + url + "\n";
//txt+="Line: " + l + "\n\n";
//txt+="Click OK to continue.\n\n";
//alert(txt);
//return true;
//}

function onFrameLoad()
{
	mdi.document.charset="gb2312";
	mdi.openWindow = function(url, nActiveMode){MDIOpen(url, nActiveMode)};
	mdi.closeWindow = function(){MDIClose()};

	MDIOpen('welcome.html');


	if(logPath!='')setTimeout("MDIOpen(logPath);", 0);
}

var pageLoad = 0;
function onContentLoad()
{
	pageLoad ++;
	if(pageLoad > 1)onFrameLoad();
}
