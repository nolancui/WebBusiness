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
    public partial class Appointment: System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
            }

        }
        protected void AppointmentButtonClick(object Sender, EventArgs e)
        {
            string nowTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string customerid = Request.QueryString["CustomerID"];
            string UpdateStr = "update BaseInfo set State ='预约', Appointment='" + txttime.Value + "',CustomerType='" + drkhlx.Value + "',CommitTime='" +nowTime+"'"+
            " where ID=" + customerid;
            DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
            int count = dbmanage.ExecuteSql(UpdateStr);
            if (count > 0)
            {
                Response.Write("<script > alert( '预约成功！');</ </script>");
                Response.Write("<script language=javascript>opener.location.href=opener.location.href;window.close();</script>");
                
            }
            else
                Response.Write("<script>alert('预约失败，count<0')</script>");
        }

    }
}
