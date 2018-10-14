using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using Dyne.Dal;
using System.Xml;
using System.Xml.XPath;

namespace WebApplication.MenuManage
{
    public partial class FenpeiDelete : System.Web.UI.Page
    {
        void bindstaff(string sql)
        {
            DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
            DataSet ds = dbmanage.QueryToDs(sql);
            DropDownListstaf.DataSource = ds.Tables[0].DefaultView;
            DropDownListstaf.DataTextField = "UserName";
            DropDownListstaf.DataValueField = "ID";
            DropDownListstaf.DataBind();
            ListItem ltselext = new ListItem();
            ltselext.Text = "全部人员";
            ltselext.Value = "全部人员";
            DropDownListstaf.Items.Insert(0, ltselext);
        }
        void binddata()
        {
            string strdeptname = deptment.SelectedItem.Text;
            string strsql;
            if(strdeptname!="所有部门")
               strsql = "select * from AccountInf where Authority='客服' and Deptment='"+strdeptname+"'";
            else
               strsql = "select * from AccountInf where Authority='客服'";
            bindstaff(strsql);
            GetRecordToGridView();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strReadPath = "..//SystemManage//DeptManager//DeptTree//DeptStruct.xml";
                XmlDocument doc = new XmlDocument();
                strReadPath = Server.MapPath(strReadPath);
                doc.Load(strReadPath);
                XmlNodeList xnl = doc.SelectSingleNode("所有部门").ChildNodes;
                if (xnl.Count > 0)
                {
                    foreach (XmlElement xn in xnl)
                    {
                        AddElement(xn);
                    }
                }
                ListItem ltselext = new ListItem();
                ltselext.Text = "所有部门";
                ltselext.Value = "0";
                deptment.Items.Insert(0, ltselext);
            }
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
            binddata();//根据需要重新绑定数据源至GridView控件。  
        }
        protected void txtNewPageIndex_TextChanged(object sender, EventArgs e)
        {
            GridViewRow gvr = GridView1.BottomPagerRow;
            TextBox temp = (TextBox)gvr.FindControl("txtNewPageIndex");
            int res = Convert.ToInt32(temp.Text.ToString());
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow gvr = GridView1.Rows[e.RowIndex];
            string strAssignTime = gvr.Cells[4].Text;
            string userid = GridView1.DataKeys[e.RowIndex].Value.ToString();
            string strSql = "update BaseInfo set UserID=null,OwnedService=null,AssignTime=null,State=null where UserID = " + userid + " and State='未处理' and AssignTime ='" + strAssignTime + "'";
            DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");

            //OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("..//DataBase//CustomerBaseInfo.accdb"));
            //OleDbCommand myCmd = new OleDbCommand(strSql, cn);
           // myCmd.Parameters.Add("@UserID", OleDbType.VarChar, 11).Value = GridView1.DataKeys[e.RowIndex].Value.ToString();
            //string test = GridView1.DataKeys[e.RowIndex].Value.ToString();
            //cn.Open();
            //myCmd.ExecuteNonQuery();
            ////Response.Write("<script > alert(id) </script>");
            //cn.Close();
            dbmanage.ExecuteSql(strSql);
            GetRecordToGridView();
            
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

            binddata();
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
        }
        protected void SearchButtonClick(object sender, EventArgs e)
        {
            GetRecordToGridView();
        }

        protected void GetRecordToGridView()
        {
            /*
        search condition 
       * txttj 车牌号/客户名/手机号码/地址/品牌
       * 模糊查询select distinct name,id from table
       * 
       */
            
            string strsql;
            string strdate;
            string strservice="";
            if (txtyf.Value != "")
                strdate = " AssignTime='" + txtyf.Value + "'";
            else
                strdate = " AssignTime is not null";
            if(DropDownListstaf.SelectedItem.Text!="全部人员")
                strservice = " (OwnedService='" + DropDownListstaf.SelectedItem.Text + "' and UserID='" + DropDownListstaf.SelectedItem.Value + "') and";
            else
                for (int i = 1; i < DropDownListstaf.Items.Count; i++)
                {
                    string stror = "(";
                    if(i!=1)
                        stror=" or";
                    strservice += stror + " (OwnedService='" + DropDownListstaf.Items[i].Text + "' and UserID='" + DropDownListstaf.Items[i].Value + "')";
                    if (i == DropDownListstaf.Items.Count - 1)
                        strservice += ") and";
                }

            strsql = "select distinct UserID,OwnedService,AssignTime from BaseInfo where"+strservice + strdate;
            DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
            DataSet ds = dbmanage.QueryToDs(strsql);
            if (ds != null)
            {
                DataSet dsdatail;
                //DataSet dsgridview;
                int count = ds.Tables[0].Rows.Count;
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", Type.GetType("System.String"));
                dt.Columns.Add("UnhandleNum", Type.GetType("System.String"));
                dt.Columns.Add("AssignTime", Type.GetType("System.String"));
                dt.Columns.Add("OwnedService", Type.GetType("System.String"));
                dt.Columns.Add("State", Type.GetType("System.String"));
                //if (count == 0)
                //    dt.Rows.Add(dt.NewRow());
                for (int i = 0; i < count; i++)
                {
                    strsql = " select * from BaseInfo where UserID='" + ds.Tables[0].Rows[i]["UserID"] + "' and OwnedService='" + ds.Tables[0].Rows[i]["OwnedService"] + "' and" + strdate + " and State='未处理' and AssignTime='"+ds.Tables[0].Rows[i]["AssignTime"]+"'";
                    dsdatail = dbmanage.QueryToDs(strsql);
                    if (dsdatail != null)
                    {
                        if (dsdatail.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = dt.NewRow();
                            dr["ID"] = ds.Tables[0].Rows[i]["UserID"];
                            dr["UnhandleNum"] = dsdatail.Tables[0].Rows.Count.ToString();
                            dr["AssignTime"] = ds.Tables[0].Rows[i]["AssignTime"];
                            dr["OwnedService"] = ds.Tables[0].Rows[i]["OwnedService"];
                            dr["State"] = "未处理";
                            dt.Rows.Add(dr);
                        }
                    }
                }
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }
        protected void DeleteButtonClick(object sender, EventArgs e)
        {
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                CheckBox ckb = (CheckBox)this.GridView1.Rows[i].Cells[0].FindControl("chkRow");
                //OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("..//DataBase//CustomerBaseInfo.accdb"));
                DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");

                if (ckb.Checked)
                {
                    GridViewRow gvr = GridView1.Rows[i];
                    string strAssignTime = gvr.Cells[4].Text;
                    string userid = GridView1.DataKeys[i].Value.ToString();
                    string strSql = "update BaseInfo set UserID=null,OwnedService=null,AssignTime=null,State=null where UserID = " + userid + " and State='未处理' and AssignTime ='" + strAssignTime + "'";
                    //OleDbCommand myCmd = new OleDbCommand(strSql, cn);
                    //myCmd.Parameters.Add("@UserID", OleDbType.VarChar, 11).Value = GridView1.DataKeys[i].Value.ToString();
                    //cn.Open();
                    //myCmd.ExecuteNonQuery();
                    //cn.Close();
                    dbmanage.ExecuteSql(strSql);
                }
            }
            GetRecordToGridView();
            //string strSql = "delete from FenPeiDeleteTable where Owner= @Owner";
            //OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("..//DataBase//FenPeiDeleteInfo.accdb"));
            //OleDbCommand myCmd = new OleDbCommand(strSql, cn);
            //myCmd.Parameters.Add("@Owner", OleDbType.VarChar, 11).Value = GridView1.DataKeys[e.RowIndex].Value.ToString();
            ////string test = GridView1.DataKeys[e.RowIndex].Value.ToString();
            //cn.Open();
            //myCmd.ExecuteNonQuery();
            ////Response.Write("<script > alert(id) </script>");
            //cn.Close();
            //binddata();

        }
        protected void SelectDeptment(object sender, EventArgs e)
        {
            binddata();
        }
        //查询指定部门的人员，并根据人员再查询按月份统计未处理状态的数目，每个月份作为一项记录显示
        protected void OnSearchBtnActon(object sender, EventArgs e)
        {

        }
        //上面的删除功能还不明确，可能是删除某个部门的所有未处理数据，待咨询。。。
        protected void OnDeleteBtnActon(object sender, EventArgs e)
        {

        }
        
    }
}
