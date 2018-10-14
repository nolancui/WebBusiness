using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dyne.Dal;
using System.Data.OleDb;
using System.Data;
using System.Xml;
using System.Xml.XPath;
namespace WebApplication.MenuManage
{
    public partial class ResetCustomdata : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListItem lt = new ListItem("--名单状态--", "--名单状态--");
                DropDownList1.Items.Add(lt);
                lt = new ListItem("成功", "成功");
                DropDownList1.Items.Add(lt);
                lt = new ListItem("失败", "失败");
                DropDownList1.Items.Add(lt);
                lt = new ListItem("无效", "无效");
                DropDownList1.Items.Add(lt);

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

        protected void ResetDataClick(object sender, EventArgs e)
        {
            string ExpTime = System.DateTime.Now.AddDays(-240.0).ToString("yyyy-MM-dd HH:mm:ss");
            string currentDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
            string strSql = "update BaseInfo set State=NULL,UserID=NULL,CommitTime='";
            strSql += currentDate + "' where CommitTime <= '";
            strSql += ExpTime + "'";
            int refCount = dbmanage.ExecuteSql(strSql);
        }

        protected void searchButtonClick(object sender, EventArgs e)
        {
            string strbegintime = BeginTime.Value;
            string strendtime = EndTime.Value;
            string customType = DropDownList1.SelectedValue;
            string str;
            if (strbegintime != "" && strendtime != "")
            {
                str ="Expiration between '" + strbegintime + "' and '" + strendtime + "' and";
            }
            else if (strbegintime != "" && strendtime == "")
            {
                str = "Expiration >= '" + strbegintime + "' and";

            }
            else if (strbegintime == "" && strendtime != "")
            {
                str = "Expiration <= '" + strendtime + "' and";
            }
            else
            {
                str = "";
            }
            if (DropDownListstaf.SelectedIndex > 0)
            {
                str += " UserID=" + DropDownListstaf.SelectedValue + " and";

            }
                
            string strSQL = "SELECT * FROM BaseInfo where " + str+" State='" + customType + "' order by Expiration";
            binddata(strSQL);
        }

        void binddata(string strSQL)
        {
            DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
            DataSet ds = dbmanage.QueryToDs(strSQL);
            if (ds != null)
            {
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
                ViewState["SearchSql"] = strSQL;
            }
        }
        protected void ResetSelectedItem(object sender, EventArgs e)
        {
            DbHelp dbmanage1 = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");

            int iRowCount = GridView1.Rows.Count;

            CheckBox checkAllBox = (CheckBox)this.GridView1.HeaderRow.FindControl("chkAll");
            string sql = ViewState["SearchSql"].ToString();
            DataSet ds = dbmanage1.QueryToDs(sql);
            if (checkAllBox.Checked)
            {
                iRowCount = ds.Tables[0].Rows.Count;
            }
            string userid = "";
            string currentDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            for (int i = 0; i < iRowCount; i++)
            {
                if (checkAllBox.Checked)
                {
                    userid = ds.Tables[0].Rows[i]["ID"].ToString();
                }
                else
                {
                    CheckBox selectcheck = (CheckBox)GridView1.Rows[i].FindControl("chkRow");
                    if (selectcheck.Checked == true)
                    {
                        userid = GridView1.DataKeys[i].Value.ToString();
                    }
                }
               
                DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
                string strSql = "update BaseInfo set State='',UserID='',CommitTime='";
                strSql += currentDate + "' where ID =" + userid;
                dbmanage1.ExecuteSql(strSql);
            }
            string strbind = ViewState["SearchSql"].ToString();
            binddata(strbind);

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
            string SearchStr = ViewState["SearchSql"].ToString();
            binddata(SearchStr);
        }
        protected void txtNewPageIndex_TextChanged(object sender, EventArgs e)
        {
            GridViewRow gvr = GridView1.BottomPagerRow;
            TextBox temp = (TextBox)gvr.FindControl("txtNewPageIndex");
            int res = Convert.ToInt32(temp.Text.ToString());
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string userid = GridView1.DataKeys[e.RowIndex].Value.ToString();
            string strSql = "delete from BaseInfo where ID = " + userid;
            DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
            dbmanage.ExecuteSql(strSql);
            string SearchStr = ViewState["SearchSql"].ToString();
            binddata(SearchStr);
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

            string SearchStr = ViewState["SearchSql"].ToString();
            binddata(SearchStr);
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //Accessing BoundField Column
            string name = GridView1.SelectedRow.Cells[2].Text;
            //get the select line's name
            //Response.Write("<script > alert('"+ name +"') </script>");
            //redirect to the webpage use xxx.aspx?name
            //such as abc.aspx?name="+name;
            Response.Redirect("FinishTest.aspx?name=" + name);
        }


        protected void SelectDeptment(object sender, EventArgs e)
        {
            string strdeptname = deptment.SelectedItem.Text;
            string strsql;
            if (strdeptname != "所有部门")
                strsql = "select * from AccountInf where Authority='客服' and Deptment='" + strdeptname + "'";
            else
                strsql = "select * from AccountInf where Authority='客服'";
            bindstaff(strsql);

        }
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

        protected void ReassinButtonClick(object sender, EventArgs e)
        {
            string CustomerID = "";
            string cmd = "";
            int count = 0;
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                CheckBox ckb = (CheckBox)this.GridView1.Rows[i].Cells[0].FindControl("chkRow");
                string userid = GridView1.DataKeys[i].Value.ToString();
                if (ckb.Checked)
                {
                    CustomerID += userid + ",";
                }
             
            }
            CheckBox checkAllBox = (CheckBox)this.GridView1.HeaderRow.FindControl("chkAll");
            if (checkAllBox.Checked)
            {
                CustomerID = ViewState["SearchSql"].ToString();
                //DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
                //DataSet ds = dbmanage.QueryToDs(ViewState["SearchSql"].ToString());
                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{
                //    CustomerID += ds.Tables[0].Rows[i]["ID"].ToString() + ",";
                //}
                CustomerID = CustomerID.Replace("'", ",");
                cmd = "<script>winPW('DataReAssin.aspx?querrySQL=" + CustomerID + "&OriginalState=" + DropDownList1.SelectedValue + "','重新分配',1000,700)</script>";
            }
            else
            {
                if (CustomerID.Length > 0)
                {
                    CustomerID = CustomerID.Substring(0, CustomerID.Length - 1);
                    cmd = "<script>winPW('DataReAssin.aspx?CustomerID=" + CustomerID + "&OriginalState=" + DropDownList1.SelectedValue + "','重新分配',1000,700)</script>";
                }

            }
            if (CustomerID == "")
                return;


            Page.ClientScript.RegisterStartupScript(ClientScript.GetType(), "winPW", cmd);
        }
        
    }

    
}
