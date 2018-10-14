<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
 
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1"><title>
	名单处理
</title><meta http-equiv="Content-Type" content="text/html; charset=utf-8" /><link href="../css/table.css" rel="stylesheet" type="text/css" />
<script language=javascript src=../com/month.js></script>
<script language=javascript src=../com/func.js></script>
<script language="javascript" type="text/javascript" src="../My97DatePick/WdatePicker.js" charset="gb2312"></script>
<SCRIPT language="javascript"> 
    function shuaxin() {
 
        window.top.frames['topFrame'].document.location.reload();
    }
    function add() {
 
        popwin2('../ADRAuditing/ADRaddkh.aspx?isadd=add&yemian=1', 900, 500, '数据添加');
    }
    function SHwin1(tiaojian, kssj, jssj, fps) {
        var tiaojian = tiaojian;
        var kssj = kssj;
        var jssj = jssj;
        var fps = fps;
        popwin2('ADRfenpei.aspx?tiaojian=' + tiaojian + '&kssj=' + kssj + '&jssj=' + jssj + '&fps=' + fps + '&lieb=2', 900, 500, '数据分配');
    }
</SCRIPT>
</head>
<body>
<DIV id=divWait style="visibility: hidden; WIDTH: 200px; POSITION: absolute; HEIGHT: 19px; BACKGROUND-COLOR: #ffffa3; fontSize: 10pt" align=center VALIGN="center">
<table border=1 width="100%" style="border-collapse:collapse;">
<tr style="BACKGROUND-COLOR: #ffffa3;"><td align=center><img align=absmiddle src=../style/waitdiv3.gif>&nbsp;&nbsp;<b>数据查询中，请稍候……</b></td>
</tr></table>
</DIV>
 
    <form name="form1" method="post" action="ADRkhcz.aspx?zt=2" id="form1" style="margin:0px">
<div>
<input type="hidden" name="__EVENTTARGET" id="__EVENTTARGET" value="" />
<input type="hidden" name="__EVENTARGUMENT" id="__EVENTARGUMENT" value="" />
<input type="hidden" name="__LASTFOCUS" id="__LASTFOCUS" value="" />
<input type="hidden" name="__VIEWSTATE" id="__VIEWSTATE" value="DdtX7Zl5MhOvjYGIpagxqFKyx7xEDgHqvf84YAQC2N99YnPX4FCjkeEw+rzJHx/r5CStUCUXzfSUwbZztrTH6jWhSnn9QL1V06loig36uAsNoXg5xrqNMgdY5axoH2YW29gzjkFbDvXFDbhBygCDomsQpxEZ9tc8nqWDVXUaw5mc8kbAO5AkMDPXSh+0Itg7KYGxqHQbcz4BCTFLYJtKkNtY6jAD2nQwHRMz0Fb80hvbVlU8qspdN1/m6AIemKYCQLz7Um8HvpsFj7KAYA7aD84j1cMUZHw7jobQ1FMO5mkiQg0vbu2IOHG6qEJhd5bq7kocO6sRnwLLYqmWuc1+oDCcR8APb8IA/RShtUOwTDuT8tuSOiRvBcQV4bulCUVUb6Bom2KGLNGbPgVCI7werE/fH4MVrbaTKcsBeoPJj5wH3tS1bDVf1Tx6LOOUOX2umpxUptu5pgnoRSRDUzOkWjxVL9rdmI76uVSU4gAzkxxwONbI0GzQd45R0dYlN4kXBLpCICnYlG1+nnTcVhEmiH/Rz0nKEz0Dcx/7H4f2biWqXynqixoh+sx4JYz/4kVSqTLhAsY258WTNLl9TNGypNH584hITBun1VNyzhaf3iG1Drx0EYDP828p25xDNXLjolQj/n3Bw2Vq43KEBM5O2Ppp0yORuwJ3A6TnjSyDxPskdm1Cy4s/HTyM0yAV2gmiLyJgRifOyQiCf9UlSe8wfhLJTJjW8v3RyjjUz//nOTtw6JQt/EF0Us6r5AJHzrXJYmbDPT+9jhj2gx2bz+pRG74M21f0pGsEiSfiAdQiRCYrHJGMU7xusm0ZulSBIHPm6JW0X+oZr/n/wJ3dTvLaQFwhL82btr7CkJgl5PZYFWXLNVrkthbEib8fNGNyR/g9Y/xQg34i1WZirjTFq+XE1kRtjdo7pYH+4W+nHdbhZLFpoMzYDHdnsad1Pv65E1jOABMUtdDH5uMjv+xFeGPAHPdVCTmvKpVKWvPFPxckasXSQltw0A+xWSoQ/RdCeDWe9NteB9dZrOlkRE8/9VEQusCJ7fVLyD7l+jZEJf0qrard/RmgadpWrUa8dgFkjaJEgzZB7YVpLAC6ldn+BuS2sltJAQGomSi24EkPGLCMrxfrj1dTGniSJwGWMWAPKI9qLCLEalZQLEbNKfZ5XzLMpfmh+MRcj7ezd4QmdteaCX7H9Z9msQ76SuBDVoCGB73TxkFTA58plVzDAjCwGuDruKMvUoKKNNtROtHqubcuxrTuk1TOxclnhrpaXg7eFDdISNp7Xy5JOCswLTmcOac33/BXu6sGXIncqGbrd97eXWN+K/UmTZVHbhqdxcNMxxTZgcaRykiw1iWr0gVBDnhKLu+6aAX78yuBlfIP5oAweEmFmplo9JI5JPAQ77PqoBaulcFdu+9pru1whhxlq+DFb8uFiJt0fHaBdO4M0hCn0xMtD1QzDuzuPkFnw/o0bSGy6iBHkq7/Mxx5UjAb4te9S1huxCYUe64y9o2uEa1OsUxUYH0PbpimXPvoFijhDht9OY5VxeL+hMqhta1McOMl8HveZywO2TITown47G54ly9rg4zXwyod7dHMSQe9jYYB93lfZgFHt+eRNFPGUnbsE7RUqksRBGxdu/yzmykvwacJ56KBsaY9hOCUOcK9nMNRPPK+n7DphMZ29MYsEyDhskoNzRv/K+rb3gxDhEVfh6UatfgSblq9zbefOrCfDq9mauDpFkuM8ItlcHWl8dEgIe7h5oS7XcyjU82xV8+ZTFQAdWIw7hdXuEMC9kQ0/23VroxdUHSB379I98tqjsvRA2TpgOAI0GfGXLNBYDf2FD4+GgobSUahQWqWA8oC0XYIVQlKdpxRuAQmJi+9sJpFZbJb6tZwPVzocCxUImh2uWX+Ls2A0ai3Nw3sirNByO4Iq0GVlmxTUKVGZwyaiHJIxOjyc04ZRldFz3A9AqaAfb+jxahrRgGccEvY5vjL9TOd9Q0ump9pxSPjXtsbCybami3qzM/70BcI4QZBHuxKXyEjN4gq0VKQtUQD7tL8kEqzrFMyVMQhf+jHTHMP5pRxFs1o2ZPaUadC7Y8hfQLiruhvGW/MXp/J2My8RDu3fm3tZAe4jCW4i0nPPNiMwobNJ/qAk8tmPY6EljYiuLdybYNmPfWnhqnq2CHO5Cw6m27gLB6LI0ygc7U48hSEw0eHQrQaDNBvh+PRkWJi6LI7pLpeOJIXEZudKq7Q9CrD7kvx6gPdajxMcH8V7cCG3L65xnq9YuPtzJKEj2gjdyBrXXYfnYgcIawbYFt03+2/c29zBoSQrq4CT9B/qP41tMJdidIFJbXV+9NjHPo/XcxRK6wvNdX1ZrsI2yqzdWhnmU42iVogCMX3v/tvAPX8Q1qc1beH3ljVl/7ceKA0YtS27eyYZpJ56uySzDj9FQ0/Xy4c+C6F20qo+pdb1jnup4bx4POBsgr7gjM4WWHGnfwc4eSM4qCVmJyqXRs5OuXhLX9dDZQuJ+FpAeCaz03ShdwXaB0C3Jpir7vQspK5c2lYnSPdzr2KW32GfViIXn2CnQUPJ2sBQfcaYX/2f25xHsgmmwJoKxQg7wigdEpETY0kemHepabP4994ak3TdGHUgmgYdqSJBi85lAhYworsTXfLIn+yv91qVer2gpH3F7qWUosENSZ4qORXkwsVHGDw76LB+GYVg3FKyTHw7iU0TMEOtqgVy9GYCg2zU26r6Y5/Rwx12m6W5CCYsyhFr7/mDAMAT2ivywsZWhzvtlgPe4HpDvmpqhg2K9Ms4SJeEQoZmbqvOaOj9WELixjul98B5FYWSfTv7U3NGDpdodo+09TXEt4isAxatKyWVb6QTVb1/antMKnvUy8zD+PPjjf6ku/TaSQ2FfrDPd5QLX1IZyUpDQWrtrGasYq0hdXu5PTxiEy/4sL+s1uSG0ikpFs1NaUPJRS5Go/h7lZo6GYA/SLksHTgjHbjcWscSS7UHBsBBAaV1NRhPrm90OF2OJifNQnBiiTZKpF9cm+dOYg0O9fFtgcIJ9+xurTsvheLsGPAkdafrM31wvn1HxmriyacFMCxofFLpXVUQIvdwLZXV2jtTE0BRfCGE8JZo0rjN2QfEYE2aa05oMVRDfhAjIFwy7qFnWREGC/VuGAJSQ1Mtrv6xS01w4cRWg4E9+Ss8R20A11kwiNZ8meRLk8jENi6pK3jJAReRXgqVMGNyQ9wIg0Vy8nXevlpJ2pD0NGbP/14WR6myIZD+EYn9XsDjTVZTf/rUcgCsgnMfIcK03fwnxf+MA+qdqmVOFjiqQ9YcGySpXQdjXJfQbVlydOeWo8Tq5/f1E0WqY+jfiiVoo/W74H3mOpcPMMECVQiheUlDBbSXtKG/U1uKJtGUQdm478efmul8TBxRqe/NcGMV/Qsuey0DDqMNxCVwfU4OhjDCXXEr2otfMkgIpjLYfUjJy6OF1vaDhEMLBVUOybLvbyNJb+pyu6V5YarAUpPjCi7hJXLq3rIg9fvl+dkGPKBrtHZwdoXdoXIQzR9eVh+uqREmtiugJAXbjtsLw64J2f5AfpEO0iV/8+xwKTdhVWIMLTll/K14g0kqe826Fgw+YJEn1LJw4FwqCV6a9ftkq2UeyEC5vJcraEPqu5Lf4B6fCGIRXk9x2AJ8mSyVb9pxFt0i6nC44Qp/lW4oyDlqNG2TbZAeVIPcnWl2P88UtTw/5oXh9A5p5WhTHokic+LvHpHKVLPWKiDsA5+eTMXchc9OlHcrif7rfK39j6SpJQ77ypvtaaZ+juE6LBvrNDtyTLuB0jGtbva50f7x5xr5x2DBbvbnKMBNlCfOOqe0WKDRNm6qQrFg8HCcPkqYsGHVoJQLTfFk819/O2sve9hATVcZHXZFySGSMy43Haj9VzZdkT8OAvfN52oN/lo4dqPjFQ52srg0JTYJI7eZjMWIuaNFdxil0/WBPjbO8P50Xgt3EJp18kXGt6+JqCnwn1HQgkCrsbZgKUBx1Vc3cuLKRHGj3ICR5uhjwd2qCQ8M4YRcwi8pZhOUhLrX3un/g15tVrvpSY9MIGBNcrL5gBvf+nTF5wJ83RmA70Fjs9hXYLutFO9o0/bWFJxjhpbT0HJVX/l9IZsgi4RXShEsil+ArnrrW2bsn5XM+SAxjF0UIhyX9eBQHcft40Qmmck99ub8ymKY/OyMSx1im/j8O4a8Z8PV7++k9QWd60/cTOR7TQK5y3QS7Xlj/Q2DVLavbGGC4HKQaaCMHsbEv6rqWkv/f3crWX9ckkadpWvPXc6gRSyWuyCo54O8Avyo5qwFpR8LRAO5KYd9EF4gXME+VupDDT7d9Q7ucGL49jcA1Vx+Qji16Kfeh7QmbKvrU7tWG8bm1777tX1rsWUYm0sHChdkj1N9TfWvlpN4bogOEXP5rSIHDeH7k5lzhjOGzB9yU0lla6aK1iydw5GjUPZJtuJiMLY9wIVHu899rFY87um4E4H5qX/yEt5P9bhSOwEsSCOOumr4x8e0U+gM3WiOBZY3zU1APC5WvHF5l7eV0pnz9dcRU6D7ZqxbKhvH5uq3kk4lfMngGsJr1vKu2bnNQp1EgSkgRpWw1sf6RDeLUxtySjENAAb/ZCmxgRCcQ9AuRj6cQzhl7BM6zq+cbKzRr67HOZFbOsGLgn2u3gV8UT2u4An+Sp30EN/U3R1497splRBVeayVDKguKqdLtnVauOyLOTkvGgWaz9f+GPZ2e99AcIWt/qU0KWAsd69LKTmIOn/HTWI2v5A/SelQqTjJdTXZNQ5+nMZTM81/NSObG/rrLHWopwO32z3dBrdqPqtgxy0RGFvN9ytw07WTV5E7ngxesjmXTz8GDbhPjf+hOqn61r7lAV1kcS0NSob7EnfkH43LV0XA4UK5NbYczlTPmG/OxywMf0p7zcgmsxJjKUbK/Wb/eqDZaa8xeGXfN2b6E+bjHqE1Yq5fjLBsWoVR+Pg7ORt8u0MH5vrSWOhLiP2aHzK9qeKwls6J+iX1Sb/BjLWIKqtEfwOoZvD+p0F3i46M6Tn28mGSBRzONTNB+6qD6NHuH8SjSPH1PhVxppZ1QJ2hMjL++blGHW7g5wnFOR6eBqkXmYMLzN/Mg5NTtB8xfWhZeUzBJs8/+db68VI+qZ4vYyimoSQ4SBd7D8kArzn01vcNpeKbwcts8KESKr5yLlOd0rDd/FwEGZvgR61JpZFf60eSfQPU6iCuFrC2vyl/0BfhFamY42A26tUXHl62S+Q5qToL6V6an7Ve+F0xGhbaAe8iQS2h+ozf+ts90BVKsTx6SxFwtZeIb7WjIrE484mS0KoWfMWTJ9fP3tz79leDV0XfwB3c4ZSdwOSU8D2KHXR0tXd3ZTs3PIGxUTndICoWlTPUxUg3K3IzqkiP6cdq38kVZi61kfMb95oFxtU09hw8JUe5nqfvhsc4nb/aW4OEf6Qd/2KGeanqp1yI7mhxGTqX6ZjwbCD5Mwhf97kTEMFbtfhLE0LZqYoxHg38c6e5bbSHI0T8aph//WF5NUtVdRCs5xmC1Ew8xSItr/QYoUhp+ywygpj/AbIJOj5RcTOfomWLl7IaJ5UwBYQwWvBRct2QXyPBJwqK7XNUjSc5Y8tWliZ4TbTCZoHJehdN5/0aALk0RbkFUZt47fJF4GZsbebY3lkny2HbUY0Q6VesjCONJENWs+Dv0tmA6GbMuVTbfbv0H2IkUj+PltN/PppnmH17b06/teMIAm6OnVIZAwkEi8Xa20DqxwGGZInfnODiEpyTWEr1IMJQ/3K7y8T6sF1BKZcbgjw58GXaYQWSvgNKWndGw21piPl/zcrGHbU6jZSNDOqLjUN3bEGQyFCugaDwtJNDsfgvTiuMO2vyEBLU5kctjbMk7TScmqfu29noUGNO8Sp9g9BQxsah/lboz5fkQShPQdNgQpce6caYxepqgOJ6KABqoPGZPKCFlOsXGNeFWxwivZGT0kOllZjGsPr4mQubTd8Yg7A/fd599Mmn6YJ/4fmgBoLD4xNCbis0Zmb6k55tL0wZlGAIpinX3EO+qekUUnPY+LR1rtIu3S1QmMRYGr7M6g67MN+7FBi+feW3AW1G+TrD90vvA+ssg5BN66lvpUgOsThXovN8OpbH0ica273EEewUgoXAiQi06Uczm/9RFRL9naZ0WPJAovenX5SPZo2BOs5PLee9HeLekHjkI3eeJmQYG8W/ayMVLG3nGidKp4udFsYBgmMyEpfaUIMfn+Cfh3BQIN0Aoww1xo+whoqNunAWqCMM6zCsNzCEfgcoKFyv6OLdkmChPAqRt3+3xxwT/K8ZQm/yH4pP6S6g/MuxJ5ofiTyVOnE8noetu8mRm8mxJ4YnDdx9y2JYKClJVR2lzMRgAd3iHwe3jwtVs0CPF4RGhxettMTSmoA63p/EN4IDGyZaBsk3mRQa9sMg84w/KAD/nf1yyuu52JlhpywGQ4vpsxY67Le1rlA3kYJe5hYwzFpNzehfw6yjDuv5VhnPnSZdZXkOPH6YLnYW5jtWTgVUJKFL5loTTwi9twJmM73JEDi5a7f22UF57TEO/OTUmQCAFrYSuERca7b08rRoRu+VT6JjOgOwYYwV39aMcluPvACdtx75+KejalrEM58TSwChi+RA+DkIU/R1dkNDSUBCgi0eL3OgeYOee8OutSX73hURZBAOTkDtFrNi/IGsq9083nf7l7Lhkarp8VjbKncdimlYrK117vBrfVK3s4L5SpczyaT+M3Ez3GCJDg2JLYFZoaiDLs607ZkU/RzavU3QxmiPWglpfIM/dmjFx55jfeMZxnJNekWf/AhBjQU15EX6MomVPtTOt1fdInB5cMqNJdmwC7vrwr90Kz3kJax65GEZkZ8098aKHqBQ17AQ7kI/znGnVC2V6wPrq+o2ozu6Rgw9M96l2V87TfkdTAcVcIp9D2WixGRcMPyqwi4EdUnk1Uw10TaKJqYtZO+dxRbUNDw75uRpE4te/fJgJmPmcXVZkWmwfZ3FW0P844Mn8UCAYExzarf4GnEWc/3kFr/42EdTHkwy3o8GQaDscVOECbU+TvONCdEVSkDaNcYZxXKGx5/XmoRYIq5GIPs3/WXw4cSx+AiwqOBbU2gSOFUTBWWvwfBSZaACTh2C1/9/SmNmVnHG/+AAuRktRrchzviYl/Fw8AcGTM6dVAdFuI9fakIo2XRdiifAlVj69dfg73rXEnBdz8SMWszmMncCmEx6Exk5zpcAoZdYm31mYME86Kl0iFuEMJX78vv5KHB473/128CpIFR+zOxgpu8S2zDZU+OMkE2YxRZtEh+Co4hJX3E/kZ4awY6/6jr/r79ywEwDMU6EIi+/toqBDA8yqOsWdBrfXAzNcVqVEantZlq8we0FNkW+4Qj7y8Ojd52KK7WDmd+CmgNAQdYAWo0uSoDzLlO1opIkOgnbdXxaYgYrPlb5nD5kz7JPx3uSC/SIiJVN4Y9kg4yIHtrGNoZOC1NVSdY4uq1OrgIqbGOZQvovsUJb9kI30uXe6f3DxnvMnVZFSYBCCCPyJuYB3QiNZsVcGeCYTJDFpe4vECYyCYr1A/9B5qpDfRBiP+53U4sSaewALbGsRBpwDd3BXEDs8wZr2AEosfiJOv50jmkFV7SAJzhGQMEMV2025GOSl/s5UTbHc74DZ/PJsl0Qu/lqLkLlSpgBP7gFaIzfMx/C+Wic2OpRRRN4EWlaqncuaa8PVCv4JOc9x2fIoERmNrc1ZwIVHkNfrUXTOh1FKQ1" />
</div>
 
<script type="text/javascript"> 
//<![CDATA[
var theForm = document.forms['form1'];
if (!theForm) {
    theForm = document.form1;
}
function __doPostBack(eventTarget, eventArgument) {
    if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
        theForm.__EVENTTARGET.value = eventTarget;
        theForm.__EVENTARGUMENT.value = eventArgument;
        theForm.submit();
    }
}
//]]>
</script>
 
 
<div>
 
	<input type="hidden" name="__VIEWSTATEENCRYPTED" id="__VIEWSTATEENCRYPTED" value="" />
	<input type="hidden" name="__EVENTVALIDATION" id="__EVENTVALIDATION" value="05uyk2KnR8PH3nsWglVINhYXTaPuBeYrzMXHpUwUw6WIWOFguyjv+MOYwzNsKxcmtiGAWRY3arnenqn7CxKgDOEUskT2XcxOnMjOs8ry3a8LkV4znYVtb0MjIfShUGk7UYJSJsyQwBlfgdx31LtygLNCyrzKaEqSeqvY59sOuvE3PQbt8bnrzQFCaDNb+pBJtENTfLwH54IsAuSawNrektZn3saq/jRRuT7XD8R8BKvu5UMqiC+JyAnuyxO61gbm9tjugIjPd9kYol6Ax64q8/f//YXohf09xMoggPkKc62oeSQlRewFeZH4936ove+m+gSl1b6uzALBRO+un6JMzWnlINm2s+5ZaEev8ZUV1uPUZHN3/XUMushVF936Tcv4P9Ph/lslaBdNse+KHA+vjmylcX4Ny4ybXZXyrKLdK+UWnr3YO8nZZVoRSFiXV/JwGjQpZ1y8eWOHb6gQy+rtV8jYUOOcQ65hr2cdLu2fubVz7+E21i96MAcY9L0hKa0tDn/3NCkTusUAV6IkxOWLhETFi7oy66Pcy0S+gePJnzah1Us1B+OYD41dFcKmg6mIpJMxwQIPBYoMFrwNswsd3lrx3aOzOOUupRJU9XYQ9xAcHtfi0DjFY3yCL77g1y66hxSiQemisfM/SLiuv4j6z5xRLf04wrT+9HHtZX74EiLl2ytCkD3f2x7QDdkLjD0WZpoO/w7o51WJ/s6NQU6Z7Y6FrIcj4b7HzUpm6FINrJLvHAbrhiekqkqLaL+Y5ez12bpMpADFdNcasvej+ev6E+8ZulsUT41ZanokfPgxh7kz/mvfFcixtDh0Cla2o/S7J+SgKI33DDZnV70fbsguCST+RL3C/OXJAxmFZtY8lec=" />
</div>
         <table width="100%" border="0" cellspacing="0" cellpadding="0" class="search">
  <tr>
    <td width="5" align="center"><!--<img src="../images/search2.gif" />--></td>
    <td width="60" class="cx">查询条件</td>
    <td width="200" style="margin-left: 40px">
         <input name="txttj" type="text" value="车牌号/客户名/手机号码/地址/品牌" id="txttj" onfocus="if(this.value==this.defaultValue)this.value=&#39;&#39;" onblur="if(this.value.replace(/ /ig,&#39;&#39;)==&#39;&#39;)this.value=this.value" style="width:214px; color:Gray" /></asp:TextBox>
        </td>
        <td width="20"></td>
     <td width="100"><select name="drgdlx" onchange="javascript:setTimeout(&#39;__doPostBack(\&#39;drgdlx\&#39;,\&#39;\&#39;)&#39;, 0)" id="drgdlx" style="width:100px;">
	<option selected="selected" value="--名单状态--">--名单状态--</option>
	<option value="预约">预约</option>
	<option value="未处理">未处理</option>
	<option value="失败">失败</option>
	<option value="成功">成功</option>
	<option value="需修改">需修改</option>
	<option value="无效">无效</option>
 
</select></td>
<td width="20"></td>
        <td width="100"><select name="drkhlx" onchange="javascript:setTimeout(&#39;__doPostBack(\&#39;drkhlx\&#39;,\&#39;\&#39;)&#39;, 0)" id="drkhlx" style="width:100px;">
	<option selected="selected" value="--客户类型--">--客户类型--</option>
	<option value="A">A</option>
	<option value="B">B</option>
	<option value="C">C</option>
	<option value="D">D</option>
	<option value="E">E</option>
	<option value="F">F</option>
 
</select></td>
    <td width="40" align="center">日期</td>
    <td width="80"><input name="txtks" type="text" id="txtks" onclick="WdatePicker()" class="Wdate" style="height:16px;width:120px;" /></td>
    <td width="40" align="center">至</td>
    <td width="80" style="margin-left: 40px"><input name="txtjs" type="text" id="txtjs" onclick="WdatePicker()" class="Wdate" style="height:16px;width:120px;" /></td>
    <td ><label>
        <input type="submit" name="btnSearch" value="查询" onclick="return showdiv();" id="btnSearch" class="searchbtn2" />
             <input type="submit" name="Button1" value="添加客户" onclick="return showdiv();" id="Button1" class="searchbtn11" />
        </label>
      </td>
    </tr>
</table>
    <TABLE cellSpacing=0 cellpadding=0 width="100%" border=0 align="center">
  <tr>
  <td>
    <div>
	<table class="tablelist" cellspacing="0" cellpadding="0" align="Left" border="0" id="GridUser" style="width:100%;border-collapse:collapse;">
		<tr style="white-space:nowrap;">
			<th scope="col"><a href="javascript:__doPostBack(&#39;GridUser&#39;,&#39;Sort$ADRChepai&#39;)">车牌</a></th><th scope="col"><a href="javascript:__doPostBack(&#39;GridUser&#39;,&#39;Sort$ADRCheZhu&#39;)">车主</a></th><th scope="col"><a href="javascript:__doPostBack(&#39;GridUser&#39;,&#39;Sort$ADRChejiahao&#39;)">车架号</a></th><th scope="col"><a href="javascript:__doPostBack(&#39;GridUser&#39;,&#39;Sort$khlx&#39;)">客户类型</a></th><th scope="col"><a href="javascript:__doPostBack(&#39;GridUser&#39;,&#39;Sort$ADRZrr&#39;)">客服</a></th><th scope="col"><a href="javascript:__doPostBack(&#39;GridUser&#39;,&#39;Sort$ADRZt&#39;)">名单状态</a></th><th scope="col">手机</th><th scope="col"><a href="javascript:__doPostBack(&#39;GridUser&#39;,&#39;Sort$ADRbaoxiandaoqi&#39;)">保险到期日期</a></th><th scope="col"><a href="javascript:__doPostBack(&#39;GridUser&#39;,&#39;Sort$ADRyuyuetime&#39;)">预约时间</a></th><th scope="col">处理</th>
		</tr><tr>
			<td class="tdright" align="center">苏F76R93</td><td class="tdright" align="center">吴德华</td><td class="tdright" align="center">LS5W3ABR9DB084586</td><td class="tdright" align="center">&nbsp;</td><td class="tdright" align="center">Admin</td><td class="tdright" align="center">未处理</td><td class="tdright" align="center">13962985266</td><td class="tdright" align="center" title="江苏省通州市金沙镇界北村三组27号">2015-01-24</td><td class="tdright" align="center">&nbsp;</td><td class="tdright" align="center">
 
      <a href="javascript:popwin('../ADRAuditing/serach.aspx?id=1429545&zt=1',900, 1200,'')"; title="操作">
            <img src="../images/m5.gif" width="16" height="16" border=0 title="操作"></a>
        </td>
		</tr>
	</table>
</div>
</td>
  </tr>
  </TABLE>
<TABLE width="100%" border="0" cellspacing="0" cellpadding="0" class="tablelist">
 <TR>
          <TD class="page" vAlign=top align =left > 
           <TABLE width="100%" border="0" cellspacing="0" cellpadding="0">
                  <TR class="List_Page">
                  <td align =left>
						总共1条纪录共1 页&nbsp;
							第 1 页
                            <a id="btnFirst" href="javascript:__doPostBack(&#39;btnFirst&#39;,&#39;&#39;)" style="color:Navy;font-family:verdana;font-size:8pt;">首页</a>&nbsp;
							<a id="btnPrev" href="javascript:__doPostBack(&#39;btnPrev&#39;,&#39;&#39;)" style="color:Navy;font-family:verdana;font-size:8pt;">前一页</a>&nbsp;
							<a id="btnNext" href="javascript:__doPostBack(&#39;btnNext&#39;,&#39;&#39;)" style="color:Navy;font-family:verdana;font-size:8pt;">下一页</a>&nbsp;
							<a id="btnLast" href="javascript:__doPostBack(&#39;btnLast&#39;,&#39;&#39;)" style="color:Navy;font-family:verdana;font-size:8pt;">末页</a>
				 </td>
				 <td align=right>转到第  
                     <input name="txtPageNum" type="text" maxlength="4" id="txtPageNum" onkeyup="javascript:this.value=this.value.replace(/\D/gi,&quot;&quot;);" size="4" class="pageinput" />页<input type="submit" name="btnChange" value="转到" id="btnChange" style="height: 21px" />
                          </td>
				</TR>
			</TABLE>
            </TD></TR>      
 </TABLE>
    
 
<script type="text/javascript"> 
//<![CDATA[
add()//]]>
</script>
</form>
</body>
</html>
