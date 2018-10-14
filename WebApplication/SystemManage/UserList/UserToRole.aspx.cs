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
    public partial class UserToRole : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string ID;
                string UserName;
                ID = Request.QueryString["ID"];
                UserName = Request.QueryString["UserName"];
                lblUser.InnerText = UserName;
                Dropdownlistbind();
            }
            //document.getElementById('lblUser').innerHTML = "用户名";
        }

        protected void OnSubbmitRole(object sender, EventArgs e)
        {
            DbHelp dbmanage;
            string ID;
            dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
            int selectid = RoleSelect.SelectedIndex;
            if (selectid != 0)
            {
                ID = Request.QueryString["ID"];
                string strSQL = "update AccountInf set Authority='" + RoleSelect.SelectedItem.Text + "' where ID=" + ID;
                dbmanage.ExecuteSql(strSQL);

                Response.Write("<script>alert('保存成功！');window.close()</script>");
            }
            else
            {
                Response.Write("<script>alert('未选择角色！')</script>");
            }
        }

        protected void Dropdownlistbind()
        {

            string strsql = "select * from Role";
            DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");

            //OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("..//..//DataBase//AccountInf.accdb"));
            //cn.Open();
            //OleDbCommand myCmd = new OleDbCommand(strsql, cn);
            //OleDbDataAdapter oda = new OleDbDataAdapter(myCmd);
            DataSet ds = dbmanage.QueryToDs(strsql);
            //oda.Fill(ds, "Role");
           
            RoleSelect.DataSource = ds.Tables[0].DefaultView;
            RoleSelect.DataTextField = "Authority";
            RoleSelect.DataValueField = "Authority";
            RoleSelect.DataBind();
            ListItem item = new ListItem("请选择");
            RoleSelect.Items.Insert(0,item);
        }


    }
}
