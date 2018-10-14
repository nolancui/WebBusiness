using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dyne.Dal;
using System.Data.OleDb;
using System.Xml;
using System.Xml.XPath;
using System.Runtime.InteropServices;
using System.Data;
using System.IO;
using System.Data.SqlClient;
namespace WebApplication.SystemManage
{
    public partial class RoleToUser : System.Web.UI.Page
    {
        string strrole = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            {
                gridviewbind();
            }
        }
        protected void GridView1_Command(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            string strrole = Request.QueryString["Authority"];
            if (e.CommandName.Equals("CancleRole"))
            {
                DbHelp dbmanage;
                String ID = e.CommandArgument.ToString();
                dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
                string strSQL = "update AccountInf set Authority='undefined'" + " where ID=" + ID;
                dbmanage.ExecuteSql(strSQL);
                gridviewbind();

            }
            if (e.CommandName.Equals("ArrangeRole"))
            {
                DbHelp dbmanage;
                String ID = e.CommandArgument.ToString();
                dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
                string strSQL = "update AccountInf set Authority='" + strrole + "'" + " where ID=" + ID;
                dbmanage.ExecuteSql(strSQL);
                gridviewbind();

            }
            
        }

        protected void gridviewbind()
        {
            string strrole = Request.QueryString["Authority"];
            if (strrole == null||strrole == "" || strrole == "选择角色")
            {
                gridview1.DataSource=null;
                gridview2.DataSource = null;
                gridview1.DataBind();
                gridview2.DataBind();
                return;
            }
            DbHelp dbmanage;
            dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
            string strSQL = "select * from AccountInf where Authority='" + strrole + "'";

            DataSet ds1 = dbmanage.QueryToDs(strSQL);
            gridview1.DataSource = ds1.Tables[0];
            gridview1.DataBind();

            strSQL = "select * from AccountInf where Authority='undefined'or Authority is NULL";
            DataSet ds2 = dbmanage.QueryToDs(strSQL);
            gridview2.DataSource = ds2.Tables[0];
            gridview2.DataBind();
        }

    }
  
}
