using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Dyne.Dal;
using System.Xml;
using System.Xml.XPath;
namespace WebApplication.MenuManage
{
    public partial class MutiAddClient: System.Web.UI.Page
    {

        void binddata()
        {
            //OleDbConnection cn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("//DataBase//te.mdb"));
            //OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("..//DataBase//CustomerInfList.accdb"));
            DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");

            string strSQL = "SELECT CarNumber,Owner,VehicleBrand,PhoneNum,Firstregistration,VehicleModel,Address FROM CustomerInf";
            //cn.Open();
            //OleDbCommand myCmd = new OleDbCommand(strSQL, cn);
            //OleDbDataAdapter oda = new OleDbDataAdapter(myCmd);
            DataSet ds = dbmanage.QueryToDs(strSQL);
            //oda.Fill(ds, "CustomerInf");
            //cn.Close();
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
                //ListItem ltselext = new ListItem();
                //ltselext.Text = "所有部门";
                //ltselext.Value = "0";
                //deptment.Items.Insert(0, ltselext);

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
    protected bool HasChinese (string str)
    {
        return Regex.IsMatch(str, @"[\u4e00-\u9fa5]");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile == false)//HasFile用来检查FileUpload是否有指定文件  
        {
            Response.Write("<script>alert('请您选择Excel文件')</script> ");
            return;//当无文件时,返回  
        }
        string IsXls = System.IO.Path.GetExtension(FileUpload1.FileName).ToString().ToLower();//System.IO.Path.GetExtension获得文件的扩展名  
        if (IsXls != ".xls" && IsXls != ".xlsx")
        {
            Response.Write("<script>alert('只可以选择Excel文件')</script>");
            return;//当选择的不是Excel文件时,返回  
        }
        if (!Directory.Exists(Server.MapPath("~/ExcelTemp/")))
        {
            Directory.CreateDirectory(Server.MapPath("~/ExcelTemp/"));
        }
        string filename = FileUpload1.FileName;              //获取Execle文件名  DateTime日期函数  
        string savePath = Server.MapPath("~/ExcelTemp/" + filename);//Server.MapPath 获得虚拟服务器相对路径  
        FileUpload1.SaveAs(savePath);                        //SaveAs 将上传的文件内容保存在服务器上  
        DataSet ds = ExcelSqlConnection(savePath, filename);           //调用自定义方法  
        DataRow[] dr = ds.Tables[0].Select();            //定义一个DataRow数组  
        int rowsnum = ds.Tables[0].Rows.Count;
        if (rowsnum == 0)
        {
            Response.Write("<script>alert('Excel表为空表,无数据!')</script>");   //当Excel表为空时,对用户进行提示  
        }
        else
        {
            string sql;
            DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");

            //OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("//DataBase//CustomerBaseInfo.accdb"));
            //cn.Open();
            for (int i = 0; i < dr.Length; i++)
            {
                sql = "SELECT * FROM BaseInfo WHERE CarNumber = ('" + dr[i]["车牌号码"].ToString() + "')";
               
               // OleDbCommand cmd1 = new OleDbCommand(sql, cn);
                try
                {
                   
                    int count = dbmanage.QueryRecordCount(sql);
                    DataSet ds1 = dbmanage.QueryToDs(sql);
                    if(ds1.Tables[0].Rows.Count == 1)
                    {
                        string id = ds1.Tables[0].Rows[0]["ID"].ToString();
                        sql = "update BaseInfo set CarNumber='" + dr[i]["车牌号码"].ToString()
                            + "',VehicleBrand='" + dr[i]["车辆品牌"].ToString()
                            + "',VehicleModel='" + dr[i]["车辆型号"].ToString()
                            + "',VehicleIdentification='" + dr[i]["车辆识别代号"].ToString()
                            + "',EngineNumber='" + dr[i]["发动机号"].ToString()
                            + "',IDcard='" + dr[i]["身份证"].ToString()
                            + "',ClientName='" + dr[i]["所有人"].ToString()
                            + "',Address='" + dr[i]["联系地址"].ToString()
                            + "',PhoneNum='" + dr[i]["手机号码"].ToString()
                            + "',RegistrationTime='" + dr[i]["初次登记日期"].ToString()
                            + "',Expiration='" + dr[i]["保险到期时间"].ToString()
                            + "',reserve1='" + deptment.SelectedItem.Text + "' where ID="
                            + id;
                    }
                    else
                    {
                        sql = "insert into BaseInfo (CarNumber,VehicleBrand,VehicleModel,VehicleIdentification,EngineNumber,IDcard,ClientName,Address,PhoneNum,RegistrationTime,Expiration,reserve1) values('" + dr[i]["车牌号码"].ToString() + "','" + dr[i]["车辆品牌"].ToString() + "','" + dr[i]["车辆型号"].ToString() + "','" + dr[i]["车辆识别代号"].ToString() + "','" + dr[i]["发动机号"].ToString() + "','" + dr[i]["身份证"].ToString() + "','" + dr[i]["所有人"].ToString() + "','" + dr[i]["联系地址"].ToString() + "','" + dr[i]["手机号码"].ToString() + "','" + dr[i]["初次登记日期"].ToString() + "','" + dr[i]["保险到期时间"].ToString() + "','" + deptment.SelectedItem.Text + "')";

                    }
                }
                catch
                {
                }
                //sql = "insert into BaseInfo (CarNumber,VehicleBrand,VehicleModel,VehicleIdentification,EngineNumber,IDcard,ClientName,Address,PhoneNum,RegistrationTime,Expiration,reserve1) values('" + dr[i]["车牌号码"].ToString() + "','" + dr[i]["车辆品牌"].ToString() + "','" + dr[i]["车辆型号"].ToString() + "','" + dr[i]["车辆识别代号"].ToString() + "','" + dr[i]["发动机号"].ToString() + "','" + dr[i]["身份证"].ToString() + "','" + dr[i]["所有人"].ToString() + "','" + dr[i]["联系地址"].ToString() + "','" + dr[i]["手机号码"].ToString() + "','" + dr[i]["初次登记日期"].ToString() + "','" + dr[i]["保险到期时间"].ToString() + "','" + deptment.SelectedItem.Text + "')";
                //OleDbCommand cmd = new OleDbCommand(sql, cn);
                //cmd.ExecuteNonQuery();
                dbmanage.ExecuteSql(sql);
            }
            //cn.Close();
            Response.Write("<script>alert('Excle表导入成功!');</script>");
        }
    } 
    }
}
