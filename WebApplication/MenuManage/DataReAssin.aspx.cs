using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using Dyne.Dal;
using System.Xml;
using System.Xml.XPath;
namespace WebApplication.MenuManage
{
    public partial class DataReAssin : System.Web.UI.Page
    {
        string strbind;
        void getUnArranageCount()
        {
            String stringID = Request.QueryString["CustomerID"];
            String[] Customeridstr = null;
            if(stringID != null)
                Customeridstr  = Request.QueryString["CustomerID"].Split(',');
            String querrySQL = Request.QueryString["querrySQL"];
            if (querrySQL != null)
            {
                String CustomerID = "";
                querrySQL = querrySQL.Replace(",", "'");
                DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
                DataSet ds = dbmanage.QueryToDs(querrySQL);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    CustomerID += ds.Tables[0].Rows[i]["ID"].ToString() + ",";
                }
                CustomerID = CustomerID.Substring(0, CustomerID.Length - 1);
                Customeridstr = CustomerID.Split(',');
            }
            //int elementcount = Customeridstr.Count();
            fps.InnerText = Customeridstr.Count().ToString();
        }
        void binddata(string strsql)
        {
            DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
            DataSet ds = dbmanage.QueryToDs(strsql);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count == 0)
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                GridView1.DataSource = ds.Tables[0].DefaultView;
                GridView1.DataBind();
                ViewState["strsql_Datafenpei"] = strsql;
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
                if (xnl.Count > 0)
                {
                    foreach (XmlElement xn in xnl)
                    {
                        AddElement(xn);
                    }
                }
                ListItem ltselext = new ListItem();
                ltselext.Text = "所有部门";
                ltselext.Value = "所有部门";
                deptment.Items.Insert(0, ltselext);
                strbind = "select * from AccountInf where Authority='客服'";
                binddata(strbind);
                getUnArranageCount();
            }
        }


        protected void AddElement(XmlNode xelement)
        {

            ListItem lt = new ListItem();
            lt.Text = xelement.Attributes[0].Value;
            lt.Value = xelement.Attributes[0].Value;
            deptment.Items.Add(lt);
            if (xelement.HasChildNodes == true)
            {
                foreach (XmlElement element in xelement)
                {
                    AddElement(element);
                }
            }
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {

        }

        protected void SaveExecl_Click(object sender, EventArgs e)
        {
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);  
        }

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
            //string name = GridView1.SelectedRow.Cells[2].Text;
            //get the select line's name
            //Response.Write("<script > alert('"+ name +"') </script>");
            //redirect to the webpage use xxx.aspx?name
            //such as abc.aspx?name="+name;
            //Response.Redirect("FinishTest.aspx?name=" + name);
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
            //if (Session["UserName"] == null || Session["UserPassWord"] == null)
            //   Response.Redirect("../admin.aspx");
            //if (Session["Priority"] == "normal")
            //   {

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
        protected void searchButtonClick(object sender, EventArgs e)
        {
            /*
              search condition 
             * txttj 车牌号/客户名/手机号码/地址/品牌
             * 模糊查询
             * 
             */

            //bool isChinese = HasChinese(inputSearch.Text);

            //string SearchStr = "select * from CustomerInf where CarNumber like '%" + inputSearch.Text +"%'";
            //SearchStr += "or Owner like '%" + inputSearch.Text + "%'";
            //SearchStr += "or PhoneNum like '%" + inputSearch.Text + "%'";
            //SearchStr += "or Address like '%" + inputSearch.Text + "%'";
            //SearchStr += "or VehicleBrand like '%" + inputSearch.Text + "%'";
            //DataBase SearchData = new DataBase();
            //string pathDataBase = Server.MapPath("//DataBase//CustomerInfList.accdb");

            //OleDbDataAdapter rd = SearchData.bindData(SearchStr, pathDataBase);
            //DataSet ds = new DataSet();
            //rd.Fill(ds, "CustomerInf");


        }
        protected void AddNewUserClick(object sender, EventArgs e)
        {
            Response.Write("<script>");
            Response.Write("window.open('..//SystemManage//UserList//UserReg.aspx','',width=500,height=500)");
            Response.Write("</script>");
        }

        protected void ArrangeCustomers(object sender, EventArgs e)
        {
            String[] Customeridstr = Request.QueryString["CustomerID"].Split(',');
            String OriginalState = Request.QueryString["OriginalState"];
            int elementcount = Customeridstr.Length;
            int checknum = 0;
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                CheckBox ckb = (CheckBox)this.GridView1.Rows[i].Cells[0].FindControl("CheckBox1");
                if (ckb.Checked)
                {
                    checknum++;
                }
            }
            int countarrange;
            if (txtfps.Text == "" && checknum != 0)
                countarrange = elementcount / checknum;
            else
                countarrange = int.Parse(txtfps.Text);
            int index = 0;
            DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                CheckBox ckb = (CheckBox)this.GridView1.Rows[i].Cells[0].FindControl("CheckBox1");
                string userid = GridView1.DataKeys[i].Value.ToString();
                string username = GridView1.Rows[i].Cells[1].Text;
                string strdatemonth = DateTime.Now.ToString("yyyy-MM");
                if (ckb.Checked)
                {
                    for (int j = 0; j < countarrange; j++)
                    {
                        if (index >= elementcount)
                            return;
                        string strsql = "";
                        if(OriginalState == "成功")
                            strsql = "update BaseInfo set UserID='" + userid + "',OwnedService='" + username + "',AssignTime='" + strdatemonth + "',State='未处理'";
                        else
                            strsql = "update BaseInfo set Addition='',UserID='" + userid + "',OwnedService='" + username + "',AssignTime='" + strdatemonth + "',State='未处理'";

                        strsql += "where ID=" + Customeridstr[j];
                        dbmanage.ExecuteSql(strsql);
                        index++;
                    }
                }
            }
            Response.Write("<script>alert('分配成功！')</script>");
            //Response.Redirect(Request.Url.ToString());



        }
        protected void SelectDeptment(object sender, EventArgs e)
        {
            string strdeptname = deptment.SelectedItem.Value;
            if (strdeptname == "所有部门")
            {
                strbind = ViewState["strsql_Datafenpei"].ToString();
                binddata(strbind);
                return;
            }
            strbind = "select * from AccountInf where Deptment='" + strdeptname + "' and Authority='客服'";
            binddata(strbind);
        }


        protected void chkAll_Checkedfenpei(object sender, EventArgs e)
        {
            int checknum = 0;
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                CheckBox ckb = (CheckBox)this.GridView1.Rows[i].Cells[0].FindControl("CheckBox1");
                if (ckb.Checked)
                {
                    checknum++;
                    GridView1.Rows[i].Font.Bold = true;
                }
                else
                    GridView1.Rows[i].Font.Bold = false;
            }

            if (checknum != 0)
            {
                int allrecord = int.Parse(fps.InnerText);
                int countarrange;
                int yushu;
                int weifenpei;
                if (txtfps.Text == "")
                    countarrange = allrecord / checknum;
                else
                    countarrange = int.Parse(txtfps.Text);
                if (countarrange > 0 && (countarrange * checknum > allrecord))
                {
                    int arrangenum = allrecord / countarrange;
                    weifenpei = checknum - arrangenum;
                    yushu = allrecord % arrangenum;
                    lbtishi.InnerHtml = "你选择了" + checknum + "人,可分配总量:" + fps.InnerText + ",最佳每人分配量:" + countarrange.ToString() + ",未分配人数:" + weifenpei.ToString() + ",剩余分配量:" + yushu.ToString();
                }
                else
                {
                    yushu = allrecord - countarrange * checknum;
                    lbtishi.InnerHtml = "你选择了" + checknum + "人,可分配总量:" + fps.InnerText + ",最佳每人分配量:" + countarrange.ToString() + ",剩余分配量:" + yushu.ToString();
                }
            }
            else
                lbtishi.InnerHtml = "";
        }
    }
}
