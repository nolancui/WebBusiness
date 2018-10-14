using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using Dyne.Dal;
namespace WebApplication.MenuManage
{
    public partial class ADRwuxiao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void OnEnsure(object sender, EventArgs e)
        {
            string invalidate1="";
            if (ch.Value == "1")
                invalidate1 += "错号,";
            if (kh.Value == "1")
                invalidate1 += "空号,";
            if (gh.Value == "1")
                invalidate1 += "过户";
            string customerid = Request.QueryString["CustomerID"];
            string nowTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
            string strsql = "update BaseInfo set [State]='"+"无效"+
                "',CommitTime='"+nowTime+
                "',InvalidateReason='"+invalidate1+
                "',OtherInvalidateReason='"+txtwuxiao.Value+ "' where ID=" + customerid;
            int num = dbmanage.ExecuteSql(strsql);
            if (num > 0)
            {
                Response.Write("<script>alert('修改成功')</script>");
                Response.Write("<script language=javascript>opener.location.href=opener.location.href;window.close();</script>");
            }
            else
                Response.Write("<script>alert('num<0')</script>");
        }
        

    }
}
