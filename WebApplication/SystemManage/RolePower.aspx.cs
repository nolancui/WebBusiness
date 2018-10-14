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
    public partial class RolePower : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Dropdownlistbind();
                TreeNode node = new TreeNode();
                node.Text = "所有权限";
                node.Value = "AllAuth";
                
                node.ShowCheckBox = false;
                TreeViewPower.Nodes.Add(node);
                TreeNode node1 = new TreeNode();
                TreeNode node2 = new TreeNode();
                TreeNode node3 = new TreeNode();
                node1.ShowCheckBox = true;
                node1.Text = "工单管理";
                node2.Text = "综合查询";
                node3.Text = "系统管理";

                node1.Value = "Workordermanagement";
                node2.Value = "IntegrativeQuery";
                node3.Value = "Systemmanagement";

                node.ChildNodes.Add(node1);
                node.ChildNodes.Add(node2);
                node.ChildNodes.Add(node3);
                TreeNode node11 = new TreeNode();
                TreeNode node12 = new TreeNode();
                TreeNode node13 = new TreeNode();
                TreeNode node14 = new TreeNode();
                TreeNode node15 = new TreeNode();
                node11.Text = "客户管理";
                node12.Text = "原始数据";
                node13.Text = "分配删除";
                node14.Text = "名单处理";
                node15.Text = "批量处理";

                node11.Value = "CustomerManagement1";
                node12.Value = "RawData";
                node13.Value = "DistributionDelete1";
                node14.Value = "Listprocess1";
                node15.Value = "BatchProcess1";

                node1.ChildNodes.Add(node11);
                node1.ChildNodes.Add(node12);
                node1.ChildNodes.Add(node13);
                node1.ChildNodes.Add(node14);
                node1.ChildNodes.Add(node15);

                TreeNode node21 = new TreeNode();
                node21.Text = "客户记录查询";
                node21.Value = "CustomRecordQuery";

                node2.ChildNodes.Add(node21);

                TreeNode node31 = new TreeNode();
                TreeNode node32 = new TreeNode();
                TreeNode node33 = new TreeNode();
                node31.Text = "部门管理";
                node32.Text = "用户管理";
                node33.Text = "密码重置";

                node31.Value = "DepartmentManagement";
                node32.Value = "UserManagemenr";
                node33.Value = "PasswordReset";

                node3.ChildNodes.Add(node31);
                node3.ChildNodes.Add(node32);
                node3.ChildNodes.Add(node33);


                TreeNode node111 = new TreeNode();
                TreeNode node112 = new TreeNode();
                TreeNode node113 = new TreeNode();
                TreeNode node114 = new TreeNode();
                node111.Text = "客户管理";
                node112.Text = "客户删除";
                node113.Text = "批量添加";
                node114.Text = "添加客户";

                node111.Value = "CustomerManagement";
                node112.Value = "CustomerDelete";
                node113.Value = "BatchAdd";
                node114.Value = "AddCustomer";
                node11.ChildNodes.Add(node111);
                node11.ChildNodes.Add(node112);
                node11.ChildNodes.Add(node113);
                node11.ChildNodes.Add(node114);

                TreeNode node121 = new TreeNode();
                node121.Text = "原始数据";
                node121.Value = "originaldata";
                node12.ChildNodes.Add(node121);

                TreeNode node131 = new TreeNode();
                node131.Text = "分配删除";
                node131.Value = "DistributionDelete";
                node13.ChildNodes.Add(node131);

                TreeNode node141 = new TreeNode();
                node141.Text = "名单处理";
                node141.Value = "Listprocess";
                node14.ChildNodes.Add(node141);

                TreeNode node151 = new TreeNode();
                node151.Text = "批量处理";
                node151.Value = "batchprocess";
                node15.ChildNodes.Add(node151);

                TreeNode node211 = new TreeNode();
                node211.Text = "查看";
                node211.Value = "ViewMore";
                node21.ChildNodes.Add(node211);

                TreeNode node212 = new TreeNode();
                node212.Text = "导出excel";
                node212.Value = "Exportexcel";
                node21.ChildNodes.Add(node212);

                TreeNode node213 = new TreeNode();
                node213.Text = "打印";
                node213.Value = "Print";
                node21.ChildNodes.Add(node213);

                TreeNode node214 = new TreeNode();
                node214.Text = "客户删除";
                node214.Value = "CustomerDelete1";
                node21.ChildNodes.Add(node214);

                TreeNode node215 = new TreeNode();
                node215.Text = "客户退回";
                node215.Value = "CustomerReturn";
                node21.ChildNodes.Add(node215);

                TreeNode node216 = new TreeNode();
                node216.Text = "客户无效";
                node216.Value = "CustomerInvalidate";
                node21.ChildNodes.Add(node216);

                TreeNode node217 = new TreeNode();
                node217.Text = "添加";
                node217.Value = "Add";
                node21.ChildNodes.Add(node217);

                TreeNode node311 = new TreeNode();
                node311.Text = "部门管理";
                node311.Value = "DeptmentManage";
                node31.ChildNodes.Add(node311);

                TreeNode node321 = new TreeNode();
                node321.Text = "用户禁/启";
                node321.Value = "UserEnable";
                node32.ChildNodes.Add(node321);
                TreeNode node322 = new TreeNode();
                node322.Text = "用户角色分配";
                node322.Value = "UserAssignment";
                node32.ChildNodes.Add(node322);
                TreeNode node323 = new TreeNode();
                node323.Text = "用户密码重置";
                node323.Value = "UserPasswordReset";
                node32.ChildNodes.Add(node323);
                TreeNode node324 = new TreeNode();
                node324.Text = "用户删除";
                node324.Value = "UserDelete";
                node32.ChildNodes.Add(node324);

                TreeNode node331 = new TreeNode();
                node331.Text = "角色改";
                node331.Value = "RoleModify";
                node33.ChildNodes.Add(node331);
                TreeNode node332 = new TreeNode();
                node332.Text = "角色删";
                node332.Value = "RoleDelete";
                node33.ChildNodes.Add(node332);
                TreeNode node333 = new TreeNode();
                node333.Text = "角色增";
                node333.Value = "RoleAdd";
                node33.ChildNodes.Add(node333);
                if(listRole.SelectedItem !=null)
                    SetAllCheckValue(listRole.SelectedItem.Value);
            }

        }

        string temp = "";
        protected void GetCkeckValue(TreeNode pnode)
        {
            int value = Convert.ToInt32(pnode.Checked);
            temp += "t."+pnode.Value + "='" + value.ToString()+"'";
            foreach(TreeNode tn in pnode.ChildNodes)
            {
                temp += ",";
                GetCkeckValue(tn);
            }
        }


        protected void Dropdownlistbind()
        {

            string strsql = "select * from Role";
            DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");

            //OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("..//DataBase//AccountInf.accdb"));
            //cn.Open();
            //OleDbCommand myCmd = new OleDbCommand(strsql, cn);
            //OleDbDataAdapter oda = new OleDbDataAdapter(myCmd);
            DataSet ds = dbmanage.QueryToDs(strsql);
            //oda.Fill(ds, "Role");
            //cn.Close();
            listRole.DataSource = ds.Tables[0].DefaultView;
            listRole.DataTextField = "Authority";
            listRole.DataValueField = "Authority";
            listRole.DataBind();
            ListItem lt = new ListItem("选择角色");
            listRole.Items.Insert(0, lt);
        }
        protected void SetCkeckValue(TreeNode pnode, string select, string nodevalue)
        {

            bool bselect;
            if (select == "True"||select == "TRUE"||select=="true")
                bselect = true;
            else
                bselect = false;
            if (pnode.Value == nodevalue)
                pnode.Checked = bselect;
            else
            {
                foreach (TreeNode tn in pnode.ChildNodes)
                    SetCkeckValue(tn, select, nodevalue);
            }
        }
        protected void SaveRoleAuthority(object sender, EventArgs e)
        {
             GetCkeckValue(TreeViewPower.Nodes[0]);
             string strSQL = "update Role t set " + temp + " where Authority='"+listRole.SelectedItem.Text+"'";
            DbHelp dbmanage;
            dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;"); int number = dbmanage.ExecuteSql(strSQL);
            Response.Redirect(Request.Url.ToString()); 
        }

        protected void SetAllCheckValue(string role)
        {
            if (role == "选择角色")
            {
                SetAllFalseCheck();
                return;
            }
            string strsql = "select * from Role where Authority='"+role+"'";
            DbHelp dbmanage;
            dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;"); DataSet ds = dbmanage.QueryToDs(strsql);
            if (ds.Tables[0].Rows.Count == 0)
                return;
            string check = ds.Tables[0].Rows[0]["AllAuth"].ToString();
            SetCkeckValue(TreeViewPower.Nodes[0], check, "AllAuth");
            check = ds.Tables[0].Rows[0]["CustomerManagement"].ToString();
            SetCkeckValue(TreeViewPower.Nodes[0], check, "CustomerManagement");
            check = ds.Tables[0].Rows[0]["CustomerDelete"].ToString();
            SetCkeckValue(TreeViewPower.Nodes[0], check, "CustomerDelete");
            check = ds.Tables[0].Rows[0]["BatchAdd"].ToString();
            SetCkeckValue(TreeViewPower.Nodes[0], check, "BatchAdd");
            check = ds.Tables[0].Rows[0]["AddCustomer"].ToString();
            SetCkeckValue(TreeViewPower.Nodes[0], check, "AddCustomer");
            check = ds.Tables[0].Rows[0]["originaldata"].ToString();
            SetCkeckValue(TreeViewPower.Nodes[0], check, "originaldata");
            check = ds.Tables[0].Rows[0]["DistributionDelete"].ToString();
            SetCkeckValue(TreeViewPower.Nodes[0], check, "DistributionDelete");
            check = ds.Tables[0].Rows[0]["Listprocess"].ToString();
            SetCkeckValue(TreeViewPower.Nodes[0], check, "Listprocess");
            check = ds.Tables[0].Rows[0]["batchprocess"].ToString();
            SetCkeckValue(TreeViewPower.Nodes[0], check, "batchprocess");
            check = ds.Tables[0].Rows[0]["ViewMore"].ToString();
            SetCkeckValue(TreeViewPower.Nodes[0], check, "ViewMore");
            check = ds.Tables[0].Rows[0]["Exportexcel"].ToString();
            SetCkeckValue(TreeViewPower.Nodes[0], check, "Exportexcel");
            check = ds.Tables[0].Rows[0]["Print"].ToString();
            SetCkeckValue(TreeViewPower.Nodes[0], check, "Print");
            check = ds.Tables[0].Rows[0]["CustomerDelete1"].ToString();
            SetCkeckValue(TreeViewPower.Nodes[0], check, "CustomerDelete1");
            check = ds.Tables[0].Rows[0]["CustomerReturn"].ToString();
            SetCkeckValue(TreeViewPower.Nodes[0], check, "CustomerReturn");
            check = ds.Tables[0].Rows[0]["CustomerInvalidate"].ToString();
            SetCkeckValue(TreeViewPower.Nodes[0], check, "CustomerInvalidate");
            check = ds.Tables[0].Rows[0]["Add"].ToString();
            SetCkeckValue(TreeViewPower.Nodes[0], check, "Add");
            check = ds.Tables[0].Rows[0]["DeptmentManage"].ToString();
            SetCkeckValue(TreeViewPower.Nodes[0], check, "DeptmentManage");
            check = ds.Tables[0].Rows[0]["UserEnable"].ToString();
            SetCkeckValue(TreeViewPower.Nodes[0], check, "UserEnable");
            check = ds.Tables[0].Rows[0]["UserAssignment"].ToString();
            SetCkeckValue(TreeViewPower.Nodes[0], check, "UserAssignment");
            check = ds.Tables[0].Rows[0]["UserPasswordReset"].ToString();
            SetCkeckValue(TreeViewPower.Nodes[0], check, "UserPasswordReset");
            check = ds.Tables[0].Rows[0]["UserDelete"].ToString();
            SetCkeckValue(TreeViewPower.Nodes[0], check, "UserDelete");
            check = ds.Tables[0].Rows[0]["RoleModify"].ToString();
            SetCkeckValue(TreeViewPower.Nodes[0], check, "RoleModify");
            check = ds.Tables[0].Rows[0]["RoleDelete"].ToString();
            SetCkeckValue(TreeViewPower.Nodes[0], check, "RoleDelete");
            check = ds.Tables[0].Rows[0]["RoleAdd"].ToString();
            SetCkeckValue(TreeViewPower.Nodes[0], check, "RoleAdd");
            check = ds.Tables[0].Rows[0]["Workordermanagement"].ToString();
            SetCkeckValue(TreeViewPower.Nodes[0], check, "Workordermanagement");
            check = ds.Tables[0].Rows[0]["IntegrativeQuery"].ToString();
            SetCkeckValue(TreeViewPower.Nodes[0], check, "IntegrativeQuery");
            check = ds.Tables[0].Rows[0]["Systemmanagement"].ToString();
            SetCkeckValue(TreeViewPower.Nodes[0], check, "Systemmanagement");
            check = ds.Tables[0].Rows[0]["CustomerManagement1"].ToString();
            SetCkeckValue(TreeViewPower.Nodes[0], check, "CustomerManagement1");
            check = ds.Tables[0].Rows[0]["RawData"].ToString();
            SetCkeckValue(TreeViewPower.Nodes[0], check, "RawData");
            check = ds.Tables[0].Rows[0]["DistributionDelete1"].ToString();
            SetCkeckValue(TreeViewPower.Nodes[0], check, "DistributionDelete1");
            check = ds.Tables[0].Rows[0]["Listprocess1"].ToString();
            SetCkeckValue(TreeViewPower.Nodes[0], check, "Listprocess1");
            check = ds.Tables[0].Rows[0]["BatchProcess1"].ToString();
            SetCkeckValue(TreeViewPower.Nodes[0], check, "BatchProcess1");
            check = ds.Tables[0].Rows[0]["CustomRecordQuery"].ToString();
            SetCkeckValue(TreeViewPower.Nodes[0], check, "CustomRecordQuery");
            check = ds.Tables[0].Rows[0]["DepartmentManagement"].ToString();
            SetCkeckValue(TreeViewPower.Nodes[0], check, "DepartmentManagement");
            check = ds.Tables[0].Rows[0]["UserManagemenr"].ToString();
            SetCkeckValue(TreeViewPower.Nodes[0], check, "UserManagemenr");
            check = ds.Tables[0].Rows[0]["PasswordReset"].ToString();
            SetCkeckValue(TreeViewPower.Nodes[0], check, "PasswordReset");

        }

        protected void SetAllFalseCheck()
        {
            SetCkeckValue(TreeViewPower.Nodes[0], "false", "AllAuth");
            SetCkeckValue(TreeViewPower.Nodes[0], "false", "CustomerManagement");
            SetCkeckValue(TreeViewPower.Nodes[0], "false", "CustomerDelete");
            SetCkeckValue(TreeViewPower.Nodes[0], "false", "BatchAdd");
            SetCkeckValue(TreeViewPower.Nodes[0], "false", "AddCustomer");
            SetCkeckValue(TreeViewPower.Nodes[0], "false", "originaldata");
            SetCkeckValue(TreeViewPower.Nodes[0], "false", "DistributionDelete");
            SetCkeckValue(TreeViewPower.Nodes[0], "false", "Listprocess");
            SetCkeckValue(TreeViewPower.Nodes[0], "false", "batchprocess");
            SetCkeckValue(TreeViewPower.Nodes[0], "false", "ViewMore");
            SetCkeckValue(TreeViewPower.Nodes[0], "false", "Exportexcel");
            SetCkeckValue(TreeViewPower.Nodes[0], "false", "Print");
            SetCkeckValue(TreeViewPower.Nodes[0], "false", "CustomerDelete1");
            SetCkeckValue(TreeViewPower.Nodes[0], "false", "CustomerReturn");
            SetCkeckValue(TreeViewPower.Nodes[0], "false", "CustomerInvalidate");
            SetCkeckValue(TreeViewPower.Nodes[0], "false", "Add");
            SetCkeckValue(TreeViewPower.Nodes[0], "false", "DeptmentManage");
            SetCkeckValue(TreeViewPower.Nodes[0], "false", "UserEnable");
            SetCkeckValue(TreeViewPower.Nodes[0], "false", "UserAssignment");
            SetCkeckValue(TreeViewPower.Nodes[0], "false", "UserPasswordReset");
            SetCkeckValue(TreeViewPower.Nodes[0], "false", "UserDelete");
            SetCkeckValue(TreeViewPower.Nodes[0], "false", "RoleModify");
            SetCkeckValue(TreeViewPower.Nodes[0], "false", "RoleDelete");
            SetCkeckValue(TreeViewPower.Nodes[0], "false", "RoleAdd");
            SetCkeckValue(TreeViewPower.Nodes[0], "false", "Workordermanagement");
            SetCkeckValue(TreeViewPower.Nodes[0], "false", "IntegrativeQuery");
            SetCkeckValue(TreeViewPower.Nodes[0], "false", "Systemmanagement");
            SetCkeckValue(TreeViewPower.Nodes[0], "false", "CustomerManagement1");
            SetCkeckValue(TreeViewPower.Nodes[0], "false", "RawData");
            SetCkeckValue(TreeViewPower.Nodes[0], "false", "DistributionDelete1");
            SetCkeckValue(TreeViewPower.Nodes[0], "false", "Listprocess1");
            SetCkeckValue(TreeViewPower.Nodes[0], "false", "BatchProcess1");
            SetCkeckValue(TreeViewPower.Nodes[0], "false", "CustomRecordQuery");
            SetCkeckValue(TreeViewPower.Nodes[0], "false", "DepartmentManagement");
            SetCkeckValue(TreeViewPower.Nodes[0], "false", "UserManagemenr");
            SetCkeckValue(TreeViewPower.Nodes[0], "false", "PasswordReset");
        }
        protected void DeleteRole(object sender, EventArgs e)
        {
            if (listRole.SelectedIndex == 0)
                return;
            string deleterole = listRole.SelectedItem.Text;
            string strsql = "delete from Role where Authority='" + deleterole + "'";
            DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");

            dbmanage.ExecuteSql(strsql);
            strsql = "update AccountInf set Authority='undefine' where Authority='" + deleterole + "'";
            dbmanage.ExecuteSql(strsql);
            Response.Redirect(Request.Url.ToString()); 
        }


        protected void SelectRole(object sender, EventArgs e)
        {

            SetAllCheckValue(listRole.SelectedItem.Value);
            iroleframename.Attributes["src"] = "RoleToUser.aspx?Authority=" + listRole.SelectedItem.Value;
        }
        protected void TreeViewPower_SelectedNodeChanged(object sender, EventArgs e)
        {

        }

        protected void IntialAuthority()
        {
            if (Session["UserName"] != null && Session["LoginState"] != null && Session["Authority"] != null)
            {
                if (Session["LoginState"].ToString() != "LoginOn")
                {
                    string strScript = "<script> window.open('../admin.aspx', 'fullscreen', 'fullscreen = yes, resizable = yes, height = 1200, " +
                    " width = 1600, top = no, left = no, location = no, toolbar = no, menubar = no');</script>";
                    //Response.Redirect("admin.aspx");
                    Response.Write(strScript);
                    Session.Clear();
                    return;
                }
                Dictionary<string, string> AutorityDict = new Dictionary<string, string>();

                AuthoritySet InitialAuthority = new AuthoritySet();
                InitialAuthority.GotAuthorityItem(AutorityDict, Session["Authority"].ToString(), "..//DataBase//AccountInf.accdb");
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
            //角色改
            //角色删
            //角色增
            if (AutorityDict["RoleModify"] == "True")
            {
                TreeViewPower.Enabled = true;
            }
            else
            {
                TreeViewPower.Enabled = false;
                
            }

            if (AutorityDict["RoleDelete"] == "True")
            {
                btnDeleterole.Visible = true;
            }
            else
            {
                btnDeleterole.Visible = false;
            }
            //zeng
            if (AutorityDict["RoleAdd"] == "True")
            {
                BtnAdd.Visible = true;
            }
            else
            {
                BtnAdd.Visible = false;
            }


        }

    }
  
}
