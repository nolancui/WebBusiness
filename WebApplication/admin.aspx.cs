using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Security;
using System.Data.OleDb;
using System.Data;
using Dyne.Dal;
namespace WebApplication
{
   
    //static Int dbtype = 1;
    public partial class admin : System.Web.UI.Page
    {
        Encrypted StringEncode = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            //use Encrypted to ....
            //StringEncode = new Encrypted();
            //if (!File.Exists(FilePath))
            //{
            //    if (!Directory.Exists("c://SmartVidi//"))
            //        Directory.CreateDirectory("c://SmartVidi//");
            //    StreamWriter FirstWrite = new StreamWriter(FilePath);
            //    FirstWrite.WriteLine(StringEncode.StringEncoding("admin"));
            //    FirstWrite.WriteLine(StringEncode.StringEncoding("admin"));
            //    FirstWrite.Close();
            //    return;
            //}
            //Response.Write("<script >   </script>");
           
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {

            string strSQL = "SELECT * FROM AccountInf where UserName='" + UserNameInput.Text +
                           "' and PassWord='" + PassWordInput.Text + "' and Enabled='启用'";
            //string databasePath = Server.MapPath("DataBase//AccountInf.accdb");


           // DataBase database = new DataBase();
            //OleDbDataReader adr = database.SearchIterm(strSQL, databasePath);
            //if (adr == null)
            //{
            //    Response.Write("<script > alert( 'table no such iterm') </script>");
            //    return;
            //}
           // OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + databasePath);
           DbHelp dbmanage;
           //dbmanage = new DbHelp(EnumDbType.DbOleDb, "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + databasePath);
           dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Integrated Security=True;");
           DataSet ds = dbmanage.QueryToDs(strSQL);
           if (ds != null)
            {
                int count = ds.Tables[0].Rows.Count;
                if(count ==0)
                {
                    Response.Write("<script > alert( 'no such account ') </script>");
                    return;
                }

            }
            else
           {
               Response.Write("<script > alert( 'no such account ') </script>");
               return;
           }

          
            //make sure the count login once

            //if (adr["LoginStatus"] == "true")
            //{
            //    Response.Write("<script > alert( 'the count already login ') </script>");
            //    return;
            //}
            Response.Write("<script > alert( 'welcome to webpage ') </script>");
            

            
            FormsAuthentication.RedirectFromLoginPage(UserNameInput.Text.Trim(), false);//授权（这里是关键）
            HttpCookie cookie = new HttpCookie("USER_COOKIE");
            //所有的验证信息检测之后，如果用户选择的记住密码，则将用户名和密码写入Cookie里面保存起来。
            cookie.Values.Add("UserName", this.UserNameInput.Text.Trim());
            cookie.Values.Add("UserPassword", this.PassWordInput.Text.Trim());
            //Session["UserName"] = FormatString.Replace(this.UserNameInput.Text.Trim());
            //这里是设置Cookie的过期时间，过了一天之后状态保持自动清空。
            cookie.Expires = System.DateTime.Now.AddDays(1.0);
            Session["UserName"] = this.UserNameInput.Text.Trim();
            Session["UserIdentifier"] = ds.Tables[0].Rows[0]["UserIdentifier"];
            Session["UserPassword"] = this.PassWordInput.Text.Trim();
            Session["Authority"] = ds.Tables[0].Rows[0]["Authority"];
            Session["UserID"] = ds.Tables[0].Rows[0]["ID"];
            Session["LoginState"] = "LoginOn";
            //cn.Close();
            HttpContext.Current.Response.Cookies.Add(cookie);

            //database.CloseConnect();
            //修改登录状态
            string UpdateStr = "update  AccountInf set LoginStatus ='true' where UserName='" + UserNameInput +"'";

            dbmanage.ExecuteSql(UpdateStr);
            //DataBase update = new DataBase();
            //update.HandleDatabase(UpdateStr, databasePath);
            //update.CloseConnect();

            Response.Redirect("index.aspx");
            return;

        }
    }
}
