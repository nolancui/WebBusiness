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
    public partial class AddClient: System.Web.UI.Page
    {

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
    protected bool HasChinese (string str)
    {
        return Regex.IsMatch(str, @"[\u4e00-\u9fa5]");
    }
    protected void SaveButtonClick(object sender, EventArgs e)
    {
        List<string> getItemValue = new List<string>();
        GetItemInput(getItemValue);
        //write to database
        DbHelp dbmanage;

        string strSQL = null;
        string ValueInsert = null;

        if (getItemValue.Count < 2)
        {
            //something error
            //something important information forget input
            return;
        }
        dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");

       // OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("//DataBase//CustomerBaseInfo.accdb"));
        //cn.Open();
        strSQL = "SELECT * FROM BaseInfo WHERE CarNumber = ('" + txtcph.Value + "')";
      //  OleDbCommand cmd1 = new OleDbCommand(strSQL, cn);
        try
        {

            int count = (int)dbmanage.QueryRecordCount(strSQL);
            if (count > 0)
            {
                Response.Write("<script>alert('该车已经添加到系统')</script>");
              //  cn.Close();
                return;
            }
           // cn.Close();
        }
        catch
        {
        }
        dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
        strSQL = "select * from AccountInf where UserName='" + sfkf.Value + "'";
        DataSet ds = dbmanage.QueryToDs(strSQL);
        string strUserid="";
        if (ds != null)
        {
            int count = ds.Tables[0].Rows.Count;
            if (count == 1)
                strUserid = ds.Tables[0].Rows[0]["ID"].ToString();
        }
        for (int i = 0; i < getItemValue.Count - 1; i++)
        {
            ValueInsert += "'" + getItemValue[i] + "',";
        }
        ValueInsert += "'" + getItemValue[getItemValue.Count - 1] + "','" + strUserid + "')";
        strSQL = "Insert into BaseInfo(ClientName,CarNumber,VehicleBrand,VehicleModel,EngineNumber,FixTelephone,PhoneNum,IDcard,RegistrationTime,JiaoQiangTine,InsuranceTime,InsuranceCompany,VehicleIdentification,setNumber,State,OwnedService,TotalPay,Address,Addition,reserve1,UserID) Values (";
        strSQL += ValueInsert;
        dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");

        //if select is null then begin the next insert
        //else return the count have been exist

        //{
        //    string SearchExist = "Select * form BaseInfo where ClientName=";
        //    SearchExist += "'" + getItemValue[0] + "'";
        //    DbHelp tempSearch = new DbHelp(EnumDbType.DbOleDb, "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("..//database//CustomerBaseInfo.accdb"));
        //    //this place exist oledb datebase
        //    OleDbDataReader rd = (OleDbDataReader)tempSearch.ExecuteReader(SearchExist);
        //    if (!rd.Read())
        //    {
        //        //the count exist
        //        return;
        //    }
        //}

        dbmanage.ExecuteSql(strSQL);
        string script_str = "<script>alert('保存成功！')</script>";
        Response.Write(script_str);

    }

    protected void GetItemInput(List<string> getItem)
    {
        getItem.Add(txtkhm.Value);
        getItem.Add(txtcph.Value);
        getItem.Add(txtpinpai.Value);
        getItem.Add(txtcxh.Value);
        getItem.Add(txtfdjh.Value);
        getItem.Add(txtgddh.Value);
        getItem.Add(txtsjhm.Value);
        getItem.Add(txtsfzh.Value);
        getItem.Add(txtdjsj.Value);
        getItem.Add(txtjqxtime.Value);
        getItem.Add(txtsyxsj.Value);
        getItem.Add(txttpgs.Value);
        getItem.Add(txtcjh.Value);
        getItem.Add(txtzws.Value);
        getItem.Add(zt.Value);
        getItem.Add(sfkf.Value);
        getItem.Add(zje.Value);
        getItem.Add(txtlxdz.Value);
        getItem.Add(txtbz.Value);
        getItem.Add(deptment.SelectedItem.Text);
    }
    }
}
