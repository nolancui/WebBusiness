using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dyne.Dal;
using System.Data.OleDb;
using System.Data;
namespace WebApplication.BaseShearch
{
    public partial class ADRAuditing : System.Web.UI.Page
    {
        string strbind = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                strbind = "SELECT * FROM BaseInfo order by CommitTime DESC";
                binddata(strbind);

                DbHelp dbmanage;
                //PubConstant.DBType = DbSqlServer;
              //  if()
                //dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=db_tsrj;uid=sa;pwd=;");
                //dbmanage = new DbHelp(EnumDbType.DbOleDb, "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("..//database//AccountInf.accdb"));
                //dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;uid=sa;pwd=;");
                dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
                string strsql = "select * from AccountInf where Authority='客服'";
                DataSet ds = dbmanage.QueryToDs(strsql);
                servicelist.DataSource = ds.Tables[0].DefaultView;
                servicelist.DataTextField = "UserName";
                servicelist.DataValueField = "ID";
                servicelist.DataBind();
                ListItem lt = new ListItem("所有人员");
                servicelist.Items.Insert(0, lt);
                lt = new ListItem("--名单状态--", "--名单状态--");
                DropDownList1.Items.Add(lt);
                lt = new ListItem("未处理", "未处理");
                DropDownList1.Items.Add(lt);
                lt = new ListItem("预约", "预约");
                DropDownList1.Items.Add(lt);
                lt = new ListItem("成功", "成功");
                DropDownList1.Items.Add(lt);
                lt = new ListItem("失败", "失败");
                DropDownList1.Items.Add(lt);
                lt = new ListItem("无效", "无效");
                DropDownList1.Items.Add(lt);
                lt = new ListItem("需修改", "需修改");
                DropDownList1.Items.Add(lt);

                lt = new ListItem("--客户类型--", "--客户类型--");
                DropDownList2.Items.Add(lt);
                lt = new ListItem("A", "A");
                DropDownList2.Items.Add(lt);
                lt = new ListItem("B", "B");
                DropDownList2.Items.Add(lt);
                lt = new ListItem("C", "C");
                DropDownList2.Items.Add(lt);
                lt = new ListItem("D", "D");
                DropDownList2.Items.Add(lt);
                lt = new ListItem("E", "E");
                DropDownList2.Items.Add(lt);
                lt = new ListItem("F", "F");
                DropDownList2.Items.Add(lt);

                lt = new ListItem("--客户类型--", "--客户类型--");
                
            }
        }
        void binddata(string strSQL)
        {
            DbHelp dbmanage;
            //dbmanage = new DbHelp(EnumDbType.DbOleDb, "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("..//database//CustomerBaseInfo.accdb"));
            dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
           // OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("..//DataBase//CustomerBaseInfo.accdb"));
            //cn.Open();
            //OleDbCommand myCmd = new OleDbCommand(strSQL, cn);
            //OleDbDataAdapter oda = new OleDbDataAdapter(myCmd);
            //DataSet ds = new DataSet();
            DataSet ds = dbmanage.QueryToDs(strSQL);
           // oda.Fill(ds, "BaseInfo");
            gridview1.DataSource = ds.Tables[0];
            gridview1.DataBind();
            ViewState["strsql_ADRAudit"] = strSQL;
            IntialAuthority();
        }
      
        protected void GridView1_Command(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");

            if (e.CommandName.Equals("ViewDetail"))
            {
                string cmd = "<script>winPW('../MenuManage/search.aspx?CustomerID=" + id + "&Onlyview=true','',700,1200)</script>";
                Page.ClientScript.RegisterStartupScript(ClientScript.GetType(), "winPW", cmd);
            }
            if (e.CommandName.Equals("InvalidataRecord"))
            {
                string cmd = "<script>winPW('../MenuManage/ADRwuxiao.aspx?CustomerID=" + id + "','',400,300)</script>";
                Page.ClientScript.RegisterStartupScript(ClientScript.GetType(), "winPW", cmd);
            }
            if (e.CommandName.Equals("RevertRecord"))
            {
                string strsql = "update BaseInfo set State='需修改' where ID=" + id;
                int num = dbmanage.ExecuteSql(strsql);
                Response.Write("<script>alert('修改成功')</script>");
                strbind = ViewState["strsql_ADRAudit"].ToString();
                binddata(strbind); 
            }
            if (e.CommandName.Equals("DeleteItem"))
            {
                string strSql = "delete from BaseInfo where ID =" + id;
                int num = dbmanage.ExecuteSql(strSql);
                Response.Write("<script>alert('修改成功')</script>");
                strbind = ViewState["strsql_ADRAudit"].ToString();
                binddata(strbind); 
            }
            if (e.CommandName.Equals("AddToUser"))
            {
                string strSql = "select * from BaseInfo where ID =" + id +" and UserID is null";
                DataSet ds = dbmanage.QueryToDs(strSql);
                int count = ds.Tables[0].Rows.Count;
                if (count == 1)
                {
                    string strdatemonth = DateTime.Now.ToString("yyyy-MM");
                    strSql = "update BaseInfo temp set UserID='" + Session["UserID"].ToString() + "',OwnedService='" + Session["UserName"].ToString() + "',AssignTime='" + strdatemonth + "',State='未处理' where ID=" + id;
                    dbmanage.ExecuteSql(strSql);
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "showalert", "<script>showalert('添加成功')</script>");
                }
                else
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "showalert", "<script>showalert('该客户已经添加')</script>");
                strbind = ViewState["strsql_ADRAudit"].ToString();
                binddata(strbind); 
            }
            

        }

        protected void IntialAuthority()
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

                AuthoritySet InitialAuthority = new AuthoritySet();
                InitialAuthority.GotAuthorityItem(AutorityDict, Session["Authority"].ToString(), "..//DataBase//AccountInf.accdb");
                if (AutorityDict == null)
                {
                    Session.Clear();
                    Response.Redirect("./admin.aspx");
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
            //查看 导出excel 打印
            //客户删除 客户退回 客户无效
            //添加

            //客户删除
            if (AutorityDict["ViewMore"] == "True")
            {
                for (int i = 0; i <= gridview1.Rows.Count - 1; i++)
                {
                    ImageButton ButtonEnable = (ImageButton)gridview1.Rows[i].FindControl("view");
                    ButtonEnable.Enabled = true;
                }
            }
            else
            {
                for (int i = 0; i <= gridview1.Rows.Count - 1; i++)
                {
                    ImageButton ButtonEnable = (ImageButton)gridview1.Rows[i].FindControl("view");
                    ButtonEnable.Enabled = false;
                }
            }
            //导出excel

            if (AutorityDict["Exportexcel"] == "True")
            {
                Button1.Enabled = true;
                Button1.Visible = true;
            }
            else
            {
                Button1.Enabled = false;
                Button1.Visible = false;
            }
            //批量添加
            if (AutorityDict["Print"] == "True")
            {
                Button2.Enabled = true;
                Button2.Visible = true;
            }
            else
            {
                Button2.Enabled = false;
                Button2.Visible = false;
            }

            if (AutorityDict["CustomerDelete1"] == "True")
            {
                for (int i = 0; i <= gridview1.Rows.Count - 1; i++)
                {
                    ImageButton ButtonEnable = (ImageButton)gridview1.Rows[i].FindControl("delete");
                    ButtonEnable.Enabled = true;
                    ButtonEnable.Visible = true;
                }
            }
            else
            {
                for (int i = 0; i <= gridview1.Rows.Count - 1; i++)
                {
                    ImageButton ButtonEnable = (ImageButton)gridview1.Rows[i].FindControl("delete");
                    ButtonEnable.Enabled = false;
                    ButtonEnable.Visible = false;
                }
            }

            if (AutorityDict["CustomerReturn"] == "True")
            {
                for (int i = 0; i <= gridview1.Rows.Count - 1; i++)
                {
                    ImageButton ButtonEnable = (ImageButton)gridview1.Rows[i].FindControl("revert");
                    ButtonEnable.Enabled = true;
                }
            }
            else
            {
                for (int i = 0; i <= gridview1.Rows.Count - 1; i++)
                {
                    ImageButton ButtonEnable = (ImageButton)gridview1.Rows[i].FindControl("revert");
                    ButtonEnable.Enabled = false;
                }
            }

            if (AutorityDict["CustomerInvalidate"] == "True")
            {
                for (int i = 0; i <= gridview1.Rows.Count - 1; i++)
                {
                    ImageButton ButtonEnable = (ImageButton)gridview1.Rows[i].FindControl("invalidate");
                    ButtonEnable.Enabled = true;
                }
            }
            else
            {
                for (int i = 0; i <= gridview1.Rows.Count - 1; i++)
                {
                    ImageButton ButtonEnable = (ImageButton)gridview1.Rows[i].FindControl("invalidate");
                    ButtonEnable.Enabled = false;
                }
            }

            if (AutorityDict["Add"] == "True")
            {
                for (int i = 0; i <= gridview1.Rows.Count - 1; i++)
                {
                    ImageButton ButtonEnable = (ImageButton)gridview1.Rows[i].FindControl("add");
                    ButtonEnable.Enabled = true;
                }
            }
            else
            {
                for (int i = 0; i <= gridview1.Rows.Count - 1; i++)
                {
                    ImageButton ButtonEnable = (ImageButton)gridview1.Rows[i].FindControl("add");
                    ButtonEnable.Enabled = false;
                }
            }

        }
        protected void searchButtonClick(object sender, EventArgs e)
        {
            /*
              search condition 
             * txttj 车牌号/客户名/手机号码/地址/品牌
             * 模糊查询
             * 
             */
            string strtimeduration=""; 
            if(txtks.Value!=""&&txtjs.Value!="")
               strtimeduration = " CommitTime between '" + txtks.Value + "' and '" + txtjs.Value + "'";

            if (txtks.Value == "" && txtjs.Value != "")
                strtimeduration = " CommitTime <= '" + txtjs.Value + "'";
            if (txtks.Value != "" && txtjs.Value == "")
                strtimeduration = " CommitTime >= '" + txtks.Value + "'";

            if (servicelist.Text != "所有人员") strtimeduration += (strtimeduration==""? "":" and")+" UserID='" + servicelist.SelectedValue + "'";
            if(DropDownList1.Text!="--名单状态--")strtimeduration+= (strtimeduration==""? "":" and") + " [State]='"+DropDownList1.Text+"'";
            if (DropDownList2.Text != "--客户类型--") strtimeduration += (strtimeduration==""? "":" and")+" CustomerType='" + DropDownList2.Text + "'";
            if (drtb.Value != "无") strtimeduration += (strtimeduration == "" ? "" : " and") + " InsuranceCompany='" + drtb.Value + "'";
            string SearchStr="";
            if (txttj.Value != "")
            {
                SearchStr = "select * from BaseInfo where (CarNumber like '%" + txttj.Value + "%'";
                SearchStr += "or ClientName like '%" + txttj.Value + "%'";
                SearchStr += "or PhoneNum like '%" + txttj.Value + "%'";
                SearchStr += "or Address like '%" + txttj.Value + "%'";
                SearchStr += "or VehicleBrand like '%" + txttj.Value + "%')"; 
            }
            else
                SearchStr = "select * from BaseInfo" ;

             if(strtimeduration!="")
             {
                  if (txttj.Value != "" )
                      SearchStr += " and " + strtimeduration;
                  else
                      SearchStr += " where " + strtimeduration;
             }

             SearchStr += " order by CommitTime DESC";
            strbind = SearchStr;
            ViewState["strsql_ADRAudit"] = strbind;
            binddata(strbind);
            txttj.Value = "车牌号/客户名/手机号码/地址/品牌";


        }
        protected void btnFirst_Click(object sender, EventArgs e)
        {

            switch (((LinkButton)sender).CommandArgument.ToString())
            {
                case "first":
                    gridview1.PageIndex = 0;
                    break;
                case "last":
                    gridview1.PageIndex = gridview1.PageCount - 1;
                    break;
                case "prev":
                    if (gridview1.PageIndex >= 1)
                        gridview1.PageIndex = gridview1.PageIndex - 1;
                    break;
                case "next":
                    gridview1.PageIndex = gridview1.PageIndex + 1;
                    break;
                case "go":
                    {
                        GridViewRow gvr = gridview1.BottomPagerRow;
                        TextBox temp = (TextBox)gvr.FindControl("txtNewPageIndex");
                        int res = Convert.ToInt32(temp.Text.ToString());
                        gridview1.PageIndex = res - 1;
                    }
                    break;
            }
            strbind = ViewState["strsql_ADRAudit"].ToString();
            binddata(strbind);//根据需要重新绑定数据源至GridView控件。  
        }

        protected void txtNewPageIndex_TextChanged(object sender, EventArgs e)
        {
            GridViewRow gvr = gridview1.BottomPagerRow;
            TextBox temp = (TextBox)gvr.FindControl("txtNewPageIndex");
            int res = Convert.ToInt32(temp.Text.ToString());
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridview1.PageIndex = e.NewPageIndex;

            binddata(strbind);
        }
        protected void ButtonTicketPrint(object sender, EventArgs e)
        {
            string CustomerID = "";
            for (int i = 0; i < this.gridview1.Rows.Count; i++)
            {
                CheckBox ckb = (CheckBox)this.gridview1.Rows[i].Cells[0].FindControl("CheckBox1");
                string userid = gridview1.DataKeys[i].Value.ToString();
                if (ckb.Checked)
                {
                    CustomerID += userid + ",";
                }

            }
            if (CustomerID == "")
                return;
            CustomerID = CustomerID.Substring(0, CustomerID.Length - 1);
            this.Response.Write("<script language=javascript>window.open('Webprint.aspx?CustomerID=" + CustomerID + "','委托单')</script>");
        }

        protected void CheckSelect(object sender, EventArgs e)
        {
            for (int i = 0; i < this.gridview1.Rows.Count; i++)
            {
                CheckBox ckb = (CheckBox)this.gridview1.Rows[i].Cells[0].FindControl("CheckBox1");
                string userid = gridview1.DataKeys[i].Value.ToString();
                if (ckb.Checked)
                {
                    gridview1.Rows[i].Font.Bold = true;
                }
                else
                    gridview1.Rows[i].Font.Bold = false;
            }
        }


    }
}
