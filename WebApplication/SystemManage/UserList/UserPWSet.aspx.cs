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
namespace WebApplication.SystemManage.UserList
{
    public partial class UserPWSet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }
        }

        protected void SavePassword(object sender, EventArgs e)
        {
            string userid = Request.QueryString["ID"];
            string strpassword = "";
            for (int i = 0; i < 6; i++)
                strpassword += txtPWD.Value;
            string strsql = "update AccountInf set [PassWord]='" + strpassword + "' where ID=" + userid;
            DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");

            dbmanage.ExecuteSql(strsql);
            Response.Write("<script>alert('修改成功')</script>");
        }
        
    }

    
    
}
