using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using Dyne.Dal;
namespace WebApplication.SystemManage
{

    public partial class RoleInfoAdd : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        
        }
        protected void SaveBtnClick(object sender, EventArgs e)
        {
            DbHelp dbmanage;
            dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;"); 
            string strsql = "select * from Role where Authority='" + txtRoleName.Text + "'";
            try
            {
                object firstobject;
                bool num = dbmanage.GetSingle(strsql, out firstobject);
                if(null != firstobject)
                    Response.Write("<script>alert('角色已存在！')</script> ");
                else
                {
                    strsql = "insert into Role (Authority,AuthorityDescription) Values ('" + txtRoleName.Text + "','" + txtRoleDesc.Text + "')";
                    dbmanage.ExecuteSql(strsql);
                    Response.Write("<script>alert('角色创建成功！')</script> ");
                }
                    
            }
            catch (System.Exception ex)
            {
                throw;
            }
           

        }
       
    }
}
