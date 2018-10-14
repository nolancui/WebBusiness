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
namespace WebApplication.MenuManage
{
    public partial class MinDanChuli : System.Web.UI.Page
    {
        string strbing;
        void binddata(string strSQL)
        {
            DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");

            //OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("..//DataBase//CustomerBaseInfo.accdb"));
            //cn.Open();
            //OleDbCommand myCmd = new OleDbCommand(strSQL, cn);
            //OleDbDataAdapter oda = new OleDbDataAdapter(myCmd);
            DataSet ds = dbmanage.QueryToDs(strSQL);
            //oda.Fill(ds, "BaseInfo");
            //cn.Close();
            if (ds != null)
            {
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
                ViewState["strsql_mindanchuli"] = strSQL;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strau =Session["Authority"].ToString();
                if (strau == "内勤")
                    strbing = "SELECT * FROM BaseInfo where UserExtraID='" + Session["UserID"] + "'";
                else
                    strbing = "SELECT * FROM BaseInfo where UserID='" + Session["UserID"] + "' order by Appointment DESC";
                binddata(strbing);
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
            strbing=ViewState["strsql_mindanchuli"].ToString();

            binddata(strbing);//根据需要重新绑定数据源至GridView控件。  
}
        protected void txtNewPageIndex_TextChanged(object sender, EventArgs e)
        {
            GridViewRow gvr = GridView1.BottomPagerRow;
            TextBox temp = (TextBox)gvr.FindControl("txtNewPageIndex");
            int res = Convert.ToInt32(temp.Text.ToString());
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
            string userid = GridView1.DataKeys[e.RowIndex].Value.ToString();
            string strSql = "delete from BaseInfo where ID = " + userid; ;
            //OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("..//DataBase//CustomerBaseInfo.accdb"));
            //OleDbCommand myCmd = new OleDbCommand(strSql, cn);
            //myCmd.Parameters.Add("@id", OleDbType.VarChar, 11).Value = GridView1.DataKeys[e.RowIndex].Value.ToString();
            //string test = GridView1.DataKeys[e.RowIndex].Value.ToString();
            //cn.Open();
            //myCmd.ExecuteNonQuery();
            //Response.Write("<script > alert(id) </script>");
            //cn.Close();
            dbmanage.ExecuteSql(strSql);
            strSql = ViewState["strsql_mindanchuli"].ToString();
            binddata(strSql); 
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            
           // binddata();
        }
        protected void UploadButton_Click(object sender, EventArgs e)
        {

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
        /// 
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
        if (Session["Priority"] == "normal")
           {
 
            }
        if (Session["Priority"] == "low")
            {
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    System.Web.UI.HtmlControls.HtmlSelect selectOption = (System.Web.UI.HtmlControls.HtmlSelect)GridView1.Rows[i].FindControl("selectError");
                    CheckBox selectcheck = (CheckBox)GridView1.Rows[i].FindControl("chkSelect");
                    Button PrintButton = (Button)GridView1.Rows[i].FindControl("PrintButton");
                    LinkButton DeleteChoose = (LinkButton)GridView1.Rows[i].FindControl("LinkButton1");

                    selectOption.Disabled = true;
                    selectcheck.Enabled = false;
                    PrintButton.Enabled = false;
                    DeleteChoose.Enabled = false;
                }

        }
    }

    protected void ButtonTicketPrint(object sender, EventArgs e)
    {
        this.Response.Write("<script language=javascript>window.open('Webprint.aspx','委托单')</script>");
    }
    protected void searchButtonClick(object sender, EventArgs e)
    {
        /*
          search condition 
         * txttj 车牌号/客户名/手机号码/地址/品牌
         * 模糊查询
         * 
         */
        //if (Session["username"] == "admin")
        //    return;
        //bool isChinese = HasChinese(inputSearch.Text);
         string strau =Session["Authority"].ToString();
        string SearchStr = null;
        string strkssj = txtks.Value;
        string strjssj = txtjs.Value;

        //if (strkssj != "")
        //    strkssj += " 00:00:00";
        //if (strjssj != "")
        //    strjssj += " 23:59:59";
        if (txttj.Value == "" && strkssj == "" && strjssj == "" && drgdlx.Value == "" && drkhlx.Value =="")
        {
            if (strau == "内勤")
                strbing = "SELECT * FROM BaseInfo where UserExtraID='" + Session["UserID"] + "'";
            else
                strbing = "SELECT * FROM BaseInfo where UserID='" + Session["UserID"] + "' order by Appointment DESC";
            binddata(strbing);
            return;
        }
        else
        {
            if (txttj.Value == "" && strkssj == "" && strjssj == "")
            {

            }
            else if (txttj.Value != "" && strkssj != "" && strjssj != "")
            {
                SearchStr = "select * from BaseInfo where ";
                SearchStr += "CarNumber like '%" + txttj.Value + "%'";
                SearchStr += "or ClientName like '%" + txttj.Value + "%'";
                SearchStr += "or PhoneNum like '%" + txttj.Value + "%'";
                SearchStr += "or Address like '%" + txttj.Value + "%'";
                SearchStr += "or VehicleIdentification like '%" + txttj.Value + "%'";
                SearchStr += "and Expiration between '" + strkssj + "' and '" + strjssj + "'";

            }
            else if (txttj.Value != "" && strkssj != "" && strjssj == "")
            {
                SearchStr = "select * from BaseInfo where ";
                SearchStr += "CarNumber like '%" + txttj.Value + "%'";
                SearchStr += "or ClientName like '%" + txttj.Value + "%'";
                SearchStr += "or PhoneNum like '%" + txttj.Value + "%'";
                SearchStr += "or Address like '%" + txttj.Value + "%'";
                SearchStr += "or VehicleIdentification like '%" + txttj.Value + "%'";
                SearchStr += "and Expiration >= '" + strkssj + "'";
            }
            else if (txttj.Value != "" && strkssj == "" && strjssj != "")
            {
                SearchStr = "select * from BaseInfo where ";
                SearchStr += "CarNumber like '%" + txttj.Value + "%'";
                SearchStr += "or ClientName like '%" + txttj.Value + "%'";
                SearchStr += "or PhoneNum like '%" + txttj.Value + "%'";
                SearchStr += "or Address like '%" + txttj.Value + "%'";
                SearchStr += "or VehicleIdentification like '%" + txttj.Value + "%'";
                SearchStr += "and Expiration <= #" + strjssj + "#";
            }

            else if (txttj.Value == "" && strkssj != "" && strjssj != "")
            {
                SearchStr = "select * from BaseInfo where ";
                SearchStr += "Expiration between '" + strkssj + "' and '" + strjssj + "'";

            }
            else if (txttj.Value != "" && strkssj == "" && strjssj == "")
            {
                SearchStr = "select * from BaseInfo where ";
                SearchStr += "CarNumber like '%" + txttj.Value + "%'";
                SearchStr += "or ClientName like '%" + txttj.Value + "%'";
                SearchStr += "or PhoneNum like '%" + txttj.Value + "%'";
                SearchStr += "or Address like '%" + txttj.Value + "%'";
                SearchStr += "or VehicleIdentification like '%" + txttj.Value + "%'";
            }
            else if (txttj.Value == "" && strkssj != "" && strjssj == "")
            {
                SearchStr = "select * from BaseInfo where ";
                SearchStr += "Expiration >= '" + strkssj + "'";
            }
            else
            {
                SearchStr = "select * from BaseInfo where ";
                SearchStr += "Expiration <= '" + strjssj + "'";
            }

            if (drgdlx.Value != "--名单状态--")
            {
                //名单状态
                if (SearchStr != null)
                {
                    SearchStr += "and State = '" + drgdlx.Value + "'";
                }
                else
                {
                    SearchStr = "select * from BaseInfo where State = '" + drgdlx.Value + "'";
                }
            }
            if (drkhlx.Value != "--客户类型--")
            {
                //客户类型
                if (SearchStr != null)
                {
                    SearchStr += " and CustomerType = '" + drkhlx.Value + "'";
                }
                else
                {
                    SearchStr = "select * from BaseInfo where CustomerType = '" + drkhlx.Value + "'";
                }
            }
            if (SearchStr != null)
            {
                if (strau == "内勤")
                    SearchStr += " and UserExtraID='" + Session["UserID"] + "'";
                else
                {
                    SearchStr += " and UserID='" + Session["UserID"] + "'";
                    SearchStr += " order by Appointment DESC";
                }
            }
            else
            {
                if (strau == "内勤")
                    SearchStr = "SELECT * FROM BaseInfo where UserExtraID='" + Session["UserID"] + "'";
                else
                {
                    SearchStr = "SELECT * FROM BaseInfo where UserID='" + Session["UserID"] + "'";
                    SearchStr += " order by Appointment DESC";
                }
            }

        }

        strbing = SearchStr;
        binddata(strbing);
        //DataBase SearchData = new DataBase();
        //string pathDataBase = Server.MapPath("//DataBase//CustomerBaseInfo.accdb");

        //OleDbDataAdapter rd = SearchData.bindData(SearchStr, pathDataBase);
        //DataSet ds = new DataSet();
        //rd.Fill(ds, "BaseInfo");
        //GridView1.DataSource = ds.Tables["BaseInfo"];
        //GridView1.DataBind();


    }
    protected void AddClientClick(object sender, EventArgs e)
    {
        Response.Write("<script>");
        Response.Write("window.open('AddClient.aspx','','width=900,height=700')");
        Response.Write("</script>");
    }


    protected void GridView1_Command(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Handle"))
        {
            string id = e.CommandArgument.ToString();
            string cmd = "<script>winPW('Search.aspx?CustomerID=" + id + "&Onlyview=false','',1000,700)</script>";
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "winPW", cmd);
        }
    }
        protected void MindanChuliAuthority()
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

            //initialpage()
            GetAuthority(AutorityDict);
        }
        else
        {
            Response.Redirect("../admin.aspx");
            return;
        }
    }

        protected void GetAuthority(Dictionary<string, string> AutorityDict)
        {
            //查询 添加 处理。。。。
            //客户删除
            //if (AutorityDict["CustomerDelete"] == "True")
            //{
            //    DeleteButton.Visible = true;
            //    DeleteButton.Enabled = true;
            //}
            //else
            //{
            //    DeleteButton.Visible = false;
            //    DeleteButton.Enabled = false;
            //}
            ////客户添加
            //if (AutorityDict["AddCustomer"] == "True")
            //{
            //    addClientButton.Visible = true;
            //}
            //else
            //{
            //    addClientButton.Visible = false;
            //}



        }
    }
}
