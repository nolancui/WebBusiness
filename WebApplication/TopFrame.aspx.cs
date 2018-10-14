using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using Dyne.Dal;
using System.Web.Services; //引入命名空间
namespace WebApplication
{
    public partial class TopFrame: System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //if (Session["username"] == null)
            //{
            //    Response.Redirect("admin.aspx");
            //}
            if (!IsPostBack)
            {
                ManagementTheAuthority();
                datetimeofday.Text = System.DateTime.Now.ToString("dddd,yyyy年MM月dd日 ");

            }
            
        }

        protected void ManagementTheAuthority()
        {
            if (Session["UserName"] != null && Session["LoginState"] != null && Session["Authority"] != null)
            {
                if (Session["LoginState"].ToString() != "LoginOn")
                {
                    string strScript = "<script> window.open('admin.aspx', 'fullscreen', 'fullscreen = yes, resizable = yes, height = 1200, " +
                    " width = 1600, top = no, left = no, location = no, toolbar = no, menubar = no');</script>";
                    //Response.Redirect("admin.aspx");
                    Response.Write(strScript);
                    Session.Clear();
                    return;
                }
                Dictionary<string, string> AutorityDict = new Dictionary<string, string>();
                AuthoritySet InitialAutority = new AuthoritySet();
                InitialAutority.GotAuthorityItem(AutorityDict, Session["Authority"].ToString(), "DataBase//AccountInf.accdb");
                if (AutorityDict == null)
                {
                    Session.Clear();
                    Response.Redirect("admin.aspx");
                    return;
                }

                //initialpage()
                InitialPage(AutorityDict);
            }
            else
            {
                Response.Redirect("admin.aspx");
                return;
            }

        }

        protected void InitialPage(Dictionary<string, string> AutorityDict)
        {
            if (AutorityDict["Workordermanagement"] == "True")
            {
                MenuManage.Visible = true;
            }
            else
            {
                MenuManage.Visible = false;
            }

            if (AutorityDict["IntegrativeQuery"] == "True")
            {
                BaseShearch.Visible = true;
            }
            else
            {
                BaseShearch.Visible = false;
            }

            if (AutorityDict["Systemmanagement"] == "True")
            {
                SystemManage.Visible = true;
            }
            else
            {
                SystemManage.Visible = false;
            }

        }
        [WebMethod]
        public static string GetMessage()
        {

            string strmassage1 = "恭喜业务员 ";//恭喜业务员 江晶晶 于2016-05-07 09:51:53 成功提交一单 车牌号苏FE532Z 
            string strmassage2 = "成功提交一单 ";
            string strmassage3 = "车牌号 ";
            string strmassage4 = " 于";
            string massage = "";
            string stryesterdaystart = DateTime.Now.ToString("yyyy/MM/dd") + " 00:00:00";
            string stryesterdayend = DateTime.Now.ToString("yyyy/MM/dd") + " 23:59:59";

            string strsql = "select * from BaseInfo where State='成功' and CommitTime between '" + stryesterdaystart + "' and '" + stryesterdayend + "'";
            DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
            DataSet ds = dbmanage.QueryToDs(strsql);
            if (ds != null)
            {
                int count = ds.Tables[0].Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    massage += strmassage1 + ds.Tables[0].Rows[i]["OwnedService"].ToString();
                    massage += strmassage4;
                    massage += ds.Tables[0].Rows[i]["CommitTime"].ToString();
                    massage += strmassage2;
                    massage += strmassage3;
                    massage += ds.Tables[0].Rows[i]["CarNumber"].ToString();
                    massage += ds.Tables[0].Rows[i]["Addition"].ToString();
                    massage += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                }
            }
            return massage;
        }

        [WebMethod]
        public static string ShowHello()
        {
            return "hello world";
        }

    }
}