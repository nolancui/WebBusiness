using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//THIS PART ADD OLE
using System.Data.OleDb;
using System.Data;
using Dyne.Dal;
namespace WebApplication
{
    public partial class LeftFrame: System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ManagementTheAuthority();
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
                Workordermanagement.Visible = true;
            }
            else
            {
                Workordermanagement.Visible = false;
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
            

            ///工单管理
            //客户管理
            if (AutorityDict["CustomerManagement1"] == "True")
            {
                ClientManage.Visible = true;
            }
            else
            {
                ClientManage.Visible = false;
            }

            //原始数据
            if (AutorityDict["RawData"] == "True")
            {
                GridViewyuanshi.Visible = true;
                ResetCustomdata.Visible = true;
            }
            else
            {
                GridViewyuanshi.Visible = false;
                ResetCustomdata.Visible = false;
            }

            //分配删除
            if (AutorityDict["DistributionDelete"] == "True")
            {
                FenpeiDelete.Visible = true;
            }
            else
            {
                FenpeiDelete.Visible = false;
            }

            //名单处理
            if (AutorityDict["Listprocess1"] == "True")
            {
                MinDanChuli.Visible = true;
            }
            else
            {
                MinDanChuli.Visible = false;
            }

            //批量处理

            if (AutorityDict["BatchProcess1"] == "True")
            {
                PiLiangChuLi.Visible = true;
            }
            else
            {
                PiLiangChuLi.Visible = false;
            }
            ///系统管理
            //部门管理

            if (AutorityDict["DepartmentManagement"] == "True")
            {
                DeptManager.Visible = true;
            }
            else
            {
                DeptManager.Visible = false;
            }

            //用户管理
            if (AutorityDict["UserManagemenr"] == "True")
            {
                UserPower.Visible = true;
            }
            else
            {
                UserPower.Visible = false;
            }
            //角色管理
            if (AutorityDict["PasswordReset"] == "True")
            {
                RolePower.Visible = true;
            }
            else
            {
                RolePower.Visible = false;
            }

            if (AutorityDict["IntegrativeQuery"] == "True")
            {
                ADRAuditing.Visible = true;
            }
            else
            {
                ADRAuditing.Visible = false;
            }
        }
    }

    public class AuthoritySet
    {
        public void GotAuthorityItem(Dictionary<string, string> AutorityDict, string AutorityName,string dbPath)
        {
            //search database
            //
            string SearchStr = "select * from Role where Authority = '" + AutorityName + "' ";
            DbHelp dbmanage;
            dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Integrated Security=True;");
            //DataBase SearchData = new DataBase();
            //string pathDataBase = System.Web.HttpContext.Current.Server.MapPath(dbPath);

            //OleDbDataAdapter rd = SearchData.bindData(SearchStr, pathDataBase);
            DataSet ds = dbmanage.QueryToDs(SearchStr);
           // int count = rd.Fill(ds, "Role");

            int TotleColumn = ds.Tables[0].Columns.Count;
            //int test = ds.Tables[0].Rows.Count;

            //if(ds.Tables[0].Rows.Count <=0)
            // return ;//something error
            for (int i = 0; i < TotleColumn; i++)
            {
                AutorityDict.Add(ds.Tables[0].Columns[i].ToString(), ds.Tables[0].Rows[0][i].ToString());
            }
           // SearchData.CloseConnect();
        }
    }
}
