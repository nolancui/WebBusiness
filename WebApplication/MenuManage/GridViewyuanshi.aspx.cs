using System;
using System.Collections.Generic;
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
    public partial class GridViewyuanshi : System.Web.UI.Page
    {


        void binddata(string strSQL)
        {
            //OleDbConnection cn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("//DataBase//te.mdb"));
          //  OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("..//DataBase//CustomerBaseInfo.accdb"));
           // string strSQL = "SELECT * FROM BaseInfo where UserID is null order by Expiration";

            DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
            DataSet ds = dbmanage.QueryToDs(strSQL);
            if (ds != null)
            {
                GridView1.DataSource = ds.Tables[0];
                int count = ds.Tables[0].Rows.Count;
                fps.InnerText ="可分配数据量："+ count.ToString();
                GridView1.DataBind();
                ViewState["SearchSql"] = strSQL;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strReadPath = "..//SystemManage//DeptManager//DeptTree//DeptStruct.xml";
                XmlDocument doc = new XmlDocument();
                strReadPath = Server.MapPath(strReadPath);
                doc.Load(strReadPath);
                string nodepath = "所有部门";
                XmlNodeList xnl = doc.SelectSingleNode("所有部门").ChildNodes;
                //ListItem lt = new ListItem();
                //lt.Text = "无";
                //deptment.Items.Add(lt);
                if (xnl.Count > 0)
                {
                    foreach (XmlElement xn in xnl)
                    {
                        AddElement(xn);
                    }
                }
                string strSQL = "SELECT * FROM BaseInfo where UserID is null order by Expiration";
                binddata(strSQL);
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
                    if (GridView1.PageIndex>=1)
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
 
            //OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("//DataBase//CustomerBaseInfo.accdb"));
            //OleDbCommand myCmd = new OleDbCommand(strSql, cn);
            //myCmd.Parameters.Add("@ID", OleDbType.VarChar, 11).Value = GridView1.DataKeys[e.RowIndex].Value.ToString();
            //string test = GridView1.DataKeys[e.RowIndex].Value.ToString();
            //cn.Open();
            //myCmd.ExecuteNonQuery();
            ////Response.Write("<script > alert(id) </script>");
            //cn.Close();
            string SearchStr = ViewState["SearchSql"].ToString();
            binddata(SearchStr);
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

            string SearchStr = ViewState["SearchSql"].ToString();
            binddata(SearchStr);
        }
        protected void UploadButton_Click(object sender, EventArgs e)
        {

        }

        protected void searchButtonClick(object sender, EventArgs e)
        {
            /*
              search condition 
             * txttj 车牌号/客户名/手机号码/地址/品牌
             * 模糊查询
             * 
             */

            //bool isChinese = HasChinese(inputSearch.Text);
            string SearchStr = null;
            string strbegintime = BeginTime.Value;
            string strendtime = EndTime.Value;

            //if (strbegintime != "")
            //    strbegintime += " 00:00:00";
            //if (strendtime != "")
            //    strendtime += " 23:59:59";
            string selectpart = deptment.SelectedItem.Text;
            if(deptment.SelectedItem.Text == "无")
                selectpart = "";
            string strdepartment = "reserve1='" + selectpart;
            strdepartment += "'";
            if (departmentnull.Checked)
            {
                strdepartment = "(reserve1='" + deptment.SelectedItem.Text;
                strdepartment += "'";
                strdepartment += " or reserve1 is null)";
            }
            if (inputSearch.Value == "" && strbegintime == "" && strendtime == "")
            {
                SearchStr = "SELECT * FROM BaseInfo where ";
                SearchStr += strdepartment;
            }
            else if (inputSearch.Value != "" && strbegintime != "" && strendtime != "")
            {
                SearchStr = "select * from BaseInfo where ";
                SearchStr += strdepartment;
                SearchStr += " and (CarNumber like '%" + inputSearch.Value + "%'";
                SearchStr += " or ClientName like '%" + inputSearch.Value + "%'";
                SearchStr += " or PhoneNum like '%" + inputSearch.Value + "%'";
                SearchStr += " or Address like '%" + inputSearch.Value + "%'";
                SearchStr += " or VehicleBrand like '%" + inputSearch.Value + "%')";
                SearchStr += " and Expiration between '" + strbegintime + "' and '" + strendtime + "'";

            }
            else if (inputSearch.Value != "" && strbegintime != "" && strendtime == "")
            {
                SearchStr = "select * from BaseInfo where ";
                SearchStr += strdepartment;
                SearchStr += " and (CarNumber like '%" + inputSearch.Value + "%'";
                SearchStr += " or ClientName like '%" + inputSearch.Value + "%'";
                SearchStr += " or PhoneNum like '%" + inputSearch.Value + "%'";
                SearchStr += " or Address like '%" + inputSearch.Value + "%'";
                SearchStr += " or VehicleBrand like '%" + inputSearch.Value + "%')";
                SearchStr += " and Expiration >= #" + strbegintime + "#";
            }
            else if (inputSearch.Value != "" && strbegintime == "" && strendtime != "")
            {
                SearchStr = "select * from BaseInfo where ";
                SearchStr += strdepartment;
                SearchStr += " and (CarNumber like '%" + inputSearch.Value + "%'";
                SearchStr += " or ClientName like '%" + inputSearch.Value + "%'";
                SearchStr += " or PhoneNum like '%" + inputSearch.Value + "%'";
                SearchStr += " or Address like '%" + inputSearch.Value + "%'";
                SearchStr += " or VehicleBrand like '%" + inputSearch.Value + "%')";
                SearchStr += " and Expiration <= '" + strendtime + "'";
            }

            else if (inputSearch.Value == "" && strbegintime != "" && strendtime != "")
            {
                SearchStr = "select * from BaseInfo where ";
                SearchStr += strdepartment;
                SearchStr += " and Expiration between '" + strbegintime + "' and '" + strendtime + "'";
    
            }
            else if (inputSearch.Value != "" && strbegintime == "" && strendtime == "")
            {
                SearchStr = "select * from BaseInfo where ";
                SearchStr += strdepartment;
                SearchStr += " and (CarNumber like '%" + inputSearch.Value + "%'";
                SearchStr += " or ClientName like '%" + inputSearch.Value + "%'";
                SearchStr += " or PhoneNum like '%" + inputSearch.Value + "%'";
                SearchStr += " or Address like '%" + inputSearch.Value + "%'";
                SearchStr += " or VehicleBrand like '%" + inputSearch.Value + "%')";
            }
            else if (inputSearch.Value == "" && strbegintime != "" && strendtime == "")
            {
                SearchStr = "select * from BaseInfo where ";
                SearchStr += strdepartment;
                SearchStr += " and Expiration >= #" + strbegintime + "#";
            }
            else
            {
                SearchStr = "select * from BaseInfo where ";
                SearchStr += strdepartment;
                SearchStr += " and Expiration <= #" + strendtime + "#";
            }

            SearchStr += " and (UserID is null or UserID=NULL) order by Expiration";

            binddata(SearchStr);

        }

        protected void SaveExecl_Click(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count > 0)
            {
                //调用导出方法  
                ExportGridViewForUTF8(GridView1, DateTime.Now.ToShortDateString() + ".xls");
            }
            else
            {
                Response.Write("<script > alert('no data exprot to excel') </script>");
            }
        }
        //this below reference web page
        //save gridview to excel

        /// <summary>  
        /// 重载，否则出现“类型“GridView”的控件“GridView1”必须放在具有 runat=server 的窗体标... ”的错误  
        /// </summary>  
        /// <param name="control"></param>  
        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);  
        }

        /// <summary>  
        /// 导出方法  
        /// </summary>  
        /// <param name="GridView"></param>  
        /// <param name="filename">保存的文件名称</param>  
        /// http://blog.csdn.net/qiuzhengxiang/article/details/7228165
        /// http://www.cnblogs.com/zhang3533/archive/2008/10/21/1316050.html
        /// http://www.jb51.net/article/33728.htm
        private void ExportGridViewForUTF8(GridView GridView, string filename)
        {

            string attachment = "attachment; filename=" + filename;

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", attachment);

            /* chinese will charos
            Response.Charset = "UTF-8";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
             * */
            Response.Charset = "GB2312";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            //Encoding.GetEncoding("GB2312")
            Response.ContentType = "application/ms-excel";
            System.IO.StringWriter sw = new System.IO.StringWriter();

            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView.RenderControl(htw);

            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

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

    /// <summary>  
   /// 连接Excel  读取Excel数据   并返回DataSet数据集合  
   /// </summary>  
   /// <param name="filepath">Excel服务器路径</param>  
   /// <param name="tableName">Excel表名称</param>  Properties=\"Excel 8.0;HDR=Yes;IMEX=1
   /// <returns></returns>  
    public static System.Data.DataSet ExcelSqlConnection(string filepath, string tableName)  
   {
       string strCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'";  
       OleDbConnection ExcelConn = new OleDbConnection(strCon);  
        try  
       {  
           string strCom = string.Format("SELECT * FROM [Sheet1$]");  
           ExcelConn.Open();  
           OleDbDataAdapter myCommand = new OleDbDataAdapter(strCom, ExcelConn);  
           DataSet ds = new DataSet();  
           myCommand.Fill(ds, "[" + tableName + "$]");  
           ExcelConn.Close();  
           return ds;  
        }  
        catch  
        {  
           ExcelConn.Close();  
           return null;  
        }     
    }
    protected void InitialStatus()
    {
        if (Session["UserName"] == null || Session["UserPassWord"] == null)
           Response.Redirect("../admin.aspx");
        //if (Session["Priority"] == "normal")
        //   {
        //       FileUpload1.Enabled = false;
        //       Button1.Enabled = false;
               
               
        //    }
        //if (Session["Priority"] == "low")
        //    {
        //        for (int i = 0; i < GridView1.Rows.Count; i++)
        //        {
        //            System.Web.UI.HtmlControls.HtmlSelect selectOption = (System.Web.UI.HtmlControls.HtmlSelect)GridView1.Rows[i].FindControl("selectError");
        //            CheckBox selectcheck = (CheckBox)GridView1.Rows[i].FindControl("chkSelect");
        //            Button PrintButton = (Button)GridView1.Rows[i].FindControl("PrintButton");
        //            LinkButton DeleteChoose = (LinkButton)GridView1.Rows[i].FindControl("LinkButton1");

        //            selectOption.Disabled = true;
        //            selectcheck.Enabled = false;
        //            PrintButton.Enabled = false;
        //            DeleteChoose.Enabled = false;
        //        }

        //}
    }

    protected void ButtonTicketPrint(object sender, EventArgs e)
    {
        this.Response.Write("<script language=javascript>window.open('Webprint.aspx','委托单')</script>");
    }

    protected void DataFenPeiClick(object sender, EventArgs e)
    {
        string cmd = "<script>winPW('Datafenpei.aspx?tiaojian=" + inputSearch.Value + "&kssj=" + BeginTime.Value + "&jssj=" + EndTime.Value + "&department=" + deptment.SelectedItem.Text + "&enablenull="+ departmentnull.Checked.ToString() + "','数据分配',1000,700)</script>";
        Page.ClientScript.RegisterStartupScript(ClientScript.GetType(), "winPW", cmd);
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
        
     protected void InitialYuanshiAuthority()
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
                //LeftFrame.GotAuthorityItem(AutorityDict, Session["Authority"].ToString());
                AuthoritySet InitialAuthority = new AuthoritySet();
                InitialAuthority.GotAuthorityItem(AutorityDict, Session["Authority"].ToString(), "..//DataBase//AccountInf.accdb");
                if (AutorityDict == null)
                {
                    Session.Clear();
                    Response.Redirect("../admin.aspx");
                    return;
                }

            }
            else
            {
                Response.Redirect("../admin.aspx");
                return;
            }
        }
     
    }
}
