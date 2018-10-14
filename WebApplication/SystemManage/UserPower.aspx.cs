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
    public partial class UserPower : System.Web.UI.Page
    {

        string gloablestrSQL = "SELECT * FROM AccountInf";
        string strReadPath = "DeptManager//DeptTree//DeptStruct.xml";
        [DllImport("kernel32.dll")]
        static extern bool SetFileAttributes(string lpFileName, uint dwFileAttributes);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                string strSavePath;
                XmlDocument doc = new XmlDocument();
                strSavePath = Server.MapPath(strReadPath);
                doc.Load(strSavePath);
                string nodepath = "所有部门";
                XmlNodeList xnl = doc.SelectSingleNode("所有部门").ChildNodes;
                if (xnl.Count > 0)
                {
                    foreach (XmlElement xn in xnl)
                    {
                        AddElement(xn);
                    }
                }

                ListItem ltselext = new ListItem();
                ltselext.Text = "请选择";
                ltselext.Value = "00";
                // ltselext.Selected = true;
                deptment.Items.Insert(0, ltselext);

                gridviewbinddata(gloablestrSQL);
                //for test
               
                //end for test
            }
        }
        void gridviewbinddata(string strSQL)
        {
            DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");


            //OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("..//DataBase//AccountInf.accdb"));
            //cn.Open();
            //OleDbCommand myCmd = new OleDbCommand(strSQL, cn);
            //OleDbDataAdapter oda = new OleDbDataAdapter(myCmd);
            DataSet ds = new DataSet();
            ds = dbmanage.QueryToDs(strSQL);
            //oda.Fill(ds, "AccountInf");
            //cn.Close();
            string strsql = "";
            //dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                strsql = "select * from BaseInfo where [State]='预约' and UserID='" + dr["ID"] + "'";
                DataSet dstotal = dbmanage.QueryToDs(strsql);
                int totalnum = 0;
                int daynum = 0;
                if (dstotal != null)
                    totalnum = dstotal.Tables[0].Rows.Count;
                string nowDay = DateTime.Now.ToString("yyyy-MM-dd");
                strsql = "select * from BaseInfo where [State]='预约' and UserID='" + dr["ID"] + "' and Appointment between '" + nowDay + " 00:00:00' and '" + nowDay + " 23:59:59'";
                DataSet dsday = dbmanage.QueryToDs(strsql);
                if(dsday!=null)
                    daynum = dsday.Tables[0].Rows.Count;
                dr["OrderOfDay"] = daynum.ToString();
                dr["AllOrder"] = totalnum.ToString();
            }
            ViewState["UserPower"] = strSQL;
            GridView1.DataSource = ds.Tables[0];

            GridView1.DataBind();
            IntialAuthority();
        }
        protected void AddElement(XmlNode xelement)
        {

            ListItem lt = new ListItem();
            lt.Text = xelement.Attributes[0].Value;
            deptment.Items.Add(lt);
            if (xelement.HasChildNodes == true)
            {
                foreach (XmlElement element in xelement)
                {
                    AddElement(element);
                }
            }
        }
        protected void OnSearchStaf(object sender, EventArgs e)
        {
            DbHelp dbmanage;
            string SearchStr = "select * from AccountInf where ";
            //string sqlsearch, sqlname, sqluser;
            int selectid = deptment.SelectedIndex;
            //string strdeptment = deptment.SelectedItem.Text;
            bool orstatus = false;
            if (selectid != 0)
            {
                if (orstatus)
                {
                    SearchStr += " or ";
                }
                orstatus = true;
                SearchStr += "Deptment='" + deptment.SelectedItem.Text + "'";
            }
            if (txtLoginName.Text != "")
            {
                if (orstatus)
                {
                    SearchStr += " and ";
                }
                orstatus = true;
                SearchStr += "UserIdentifier='" + txtLoginName.Text + "'";
            }
            if (txtUserName.Text != "")
            {
                if (orstatus)
                {
                    SearchStr += " and ";
                }
                orstatus = true;
                SearchStr += "UserName='" + txtUserName.Text + "'";

            }
            if (ListUserStatus.SelectedItem.Text != "所有")
            {
                if (orstatus)
                {
                    SearchStr += " and ";
                }
                orstatus = true;
                SearchStr += "Enabled='" + ListUserStatus.SelectedItem.Text + "'";
            }
            if (orstatus ==false)
            {
                SearchStr = "select * from AccountInf";
            }
            gloablestrSQL = SearchStr;
            gridviewbinddata(SearchStr);
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
            string userid = GridView1.DataKeys[e.RowIndex].Value.ToString();
            string strSql = "delete from AccountInf where ID = " + userid;
            //OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("//DataBase//AccountInf.accdb"));
            //OleDbCommand myCmd = new OleDbCommand(strSql, cn);
            //myCmd.Parameters.Add("@id", OleDbType.VarChar, 11).Value = GridView1.DataKeys[e.RowIndex].Value.ToString();
            //string test = GridView1.DataKeys[e.RowIndex].Value.ToString();
            //cn.Open();
            //myCmd.ExecuteNonQuery();
            //cn.Close();
            dbmanage.ExecuteSql(strSql);
            gridviewbinddata(gloablestrSQL);
        }
        protected void txtNewPageIndex_TextChanged(object sender, EventArgs e)
        {
            GridViewRow gvr = GridView1.BottomPagerRow;
            TextBox temp = (TextBox)gvr.FindControl("txtNewPageIndex");
            int res = Convert.ToInt32(temp.Text.ToString());
        }
        protected void btnFirst_Click(object sender, EventArgs e)
        {

            switch (((LinkButton)sender).CommandArgument.ToString())
            {
                case "first":
                    GridView1.PageIndex = 0;
                    break;
                case "last":
                    GridView1.PageIndex = GridView1.PageCount - 1;
                    break;
                case "prev":
                    if (GridView1.PageIndex >= 1)
                        GridView1.PageIndex = GridView1.PageIndex - 1;
                    break;
                case "next":
                    GridView1.PageIndex = GridView1.PageIndex + 1;
                    break;
                case "go":
                    {
                        GridViewRow gvr = GridView1.BottomPagerRow;
                        TextBox temp = (TextBox)gvr.FindControl("txtNewPageIndex");
                        int res = Convert.ToInt32(temp.Text.ToString());
                        GridView1.PageIndex = res - 1;
                    }
                    break;
            }
            string SearchStr = ViewState["UserPower"].ToString();
            gridviewbinddata(SearchStr);
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            string SearchStr = ViewState["UserPower"].ToString();
            gridviewbinddata(SearchStr);
        }

        protected void OnSelectedIndexChanged(object sender, GridViewDeleteEventArgs e)
        {

        }
        protected void GridView1_Command(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            if (e.CommandName.Equals("Btmanage"))
            {
                DbHelp dbmanage;
                String[] argument = e.CommandArgument.ToString().Split(',');
                string tableid = argument[0];
                string enabled = argument[1];
                if (enabled == "启用")
                    enabled = "禁用";
                else
                    enabled = "启用";
                dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;"); 
                string strSQL = "update AccountInf set Enabled='" + enabled + "' where ID=" + tableid.ToString();
                dbmanage.ExecuteSql(strSQL);
                gridviewbinddata(gloablestrSQL);
                Response.Write("<script>alert('保存成功')</script>");
               // Response.Write("<script>alert('保存成功！')</sctript>");
            }
            else if (e.CommandName.Equals("RegEdit"))
            {
                string cmd = "<script>winPW('UserList/UserReg.aspx?OperNo=EDIT&ID=" + id + "','修改用户',600,500)</script>";
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "winPW", cmd);
            }
            else if (e.CommandName.Equals("ArrangeRole"))
            {
                string cmd = "<script>winPW('UserList/UserToRole.aspx?ID=" + id+"','角色分配',250,200)</script>";
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "winPW", cmd);
            }
            else if (e.CommandName.Equals("ReArrange"))
            {
                string cmd = "<script>winPW('UserList/ADR.aspx?ID=" + id+"','重新分配',400,340)</script>";
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "winPW", cmd);
            }

            else if (e.CommandName.Equals("Resetpass"))
            {
                string cmd = "<script>winPW('UserList/UserPWSet.aspx?ID=" + id+"','重置密码',150,110)</script>";
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "winPW", cmd);
            }
        }

        protected void IntialAuthority()
        {
            if (Session["UserName"] != null && Session["LoginState"] != null && Session["Authority"] != null)
            {
                if (Session["LoginState"].ToString() != "LoginOn")
                {
                    string strScript = "<script> window.open('../admin.aspx', 'fullscreen', 'fullscreen = yes, resizable = yes, height = 1200, " +
                    " width = 1600, top = no, left = no, location = no, toolbar = no, menubar = no');</script>";
                    Response.Write(strScript);
                    Session.Clear();
                    return;
                }
                Dictionary<string, string> AutorityDict = new Dictionary<string, string>();

                AuthoritySet InitialAuthority = new AuthoritySet();
                InitialAuthority.GotAuthorityItem(AutorityDict, Session["Authority"].ToString(), "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
                if (AutorityDict == null)
                {
                    Session.Clear();
                    Response.Redirect("../admin.aspx");
                    return;
                }

                //initialpage()
                InitialPage(AutorityDict);
            }
            else
            {
                Response.Redirect("../admin.aspx");
                return;
            }
        }
        protected void InitialPage(Dictionary<string, string> AutorityDict)
        {
            //用户管理
            //用户禁/启
            //用户角色分配
            //用户密码重置
            //用户删除
            if (AutorityDict["UserEnable"] == "True")
            {
                for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
                {
                    Button ButtonEnable = (Button)GridView1.Rows[i].FindControl("manage");
                    ButtonEnable.Enabled = true;
                }
            }
            else
            {
                for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
                {
                    Button ButtonEnable = (Button)GridView1.Rows[i].FindControl("manage");
                    ButtonEnable.Enabled = false;
                }

            }
            //客户添加
            if (AutorityDict["UserAssignment"] == "True")
            {
                for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
                {
                    ImageButton ButtonEnable = (ImageButton)GridView1.Rows[i].FindControl("arrange");
                    ButtonEnable.Enabled = true;
                }
            }
            else
            {
                for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
                {
                    ImageButton ButtonEnable = (ImageButton)GridView1.Rows[i].FindControl("arrange");
                    ButtonEnable.Enabled = false;
                }
            }
            //批量添加
            if (AutorityDict["UserPasswordReset"] == "True")
            {
                for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
                {
                    ImageButton ButtonEnable = (ImageButton)GridView1.Rows[i].FindControl("restpassword");
                    ButtonEnable.Enabled = true;
                }
            }
            else
            {
                for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
                {
                    ImageButton ButtonEnable = (ImageButton)GridView1.Rows[i].FindControl("restpassword");
                    ButtonEnable.Enabled = false;
                }
            }

            if (AutorityDict["UserDelete"] == "True")
            {
                for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
                {
                    ImageButton ButtonEnable = (ImageButton)GridView1.Rows[i].FindControl("delete");
                    ButtonEnable.Enabled = true;
                }
            }
            else
            {
                for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
                {
                    ImageButton ButtonEnable = (ImageButton)GridView1.Rows[i].FindControl("delete");
                    ButtonEnable.Enabled = false;
                }
            }

        }

    }
}
