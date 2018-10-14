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
namespace WebApplication.SystemManage.UserList
{
    public partial class UserReg : System.Web.UI.Page
    {
        string strReadPath;
        bool bAddUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                strReadPath = "..//DeptManager//DeptTree//DeptStruct.xml";
                bAddUser = true;
                string OperNo = Request.QueryString["OperNo"];
                string Tableid = Request.QueryString["ID"];
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
                listDept.Items.Insert(0, ltselext);

                if (OperNo == "ADD")
                {
                    bAddUser = true;
                    lbltitle.InnerHtml = "新增";
                    titlename.InnerText = "新增用户";
                }
                else
                {
                    bAddUser = false;
                    lbltitle.InnerHtml = "修改";
                    titlename.InnerText = "修改用户";
                    DbHelp dbmanage;
                    dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
                    string strSQL = "select * from AccountInf where ID=" + Tableid;
                    object firstobject;
                    bool num = dbmanage.GetSingle(strSQL, out firstobject);
                    DataSet recset = dbmanage.QueryToDs(strSQL);
                    if (recset != null)
                    {
                        txtLoginName.Text = recset.Tables[0].Rows[0]["UserName"].ToString();
                        txtUserName.Text = recset.Tables[0].Rows[0]["UserIdentifier"].ToString();
                        string sex = recset.Tables[0].Rows[0]["Sex"].ToString();
                        if (sex == "Man")
                            RadioButtonSex0.Checked = true;
                        else
                            RadioButtonSex1.Checked = true;

                        listDept.SelectedValue = recset.Tables[0].Rows[0]["Deptment"].ToString();
                        txtphone.Text = recset.Tables[0].Rows[0]["PhoneNum"].ToString();
                        txtMobile.Text = recset.Tables[0].Rows[0]["MobileNumber"].ToString();
                        txtAddress.Text = recset.Tables[0].Rows[0]["Address"].ToString();
                        txtCardID.Text = recset.Tables[0].Rows[0]["IdenfierID"].ToString();
                        txtMail.Text = recset.Tables[0].Rows[0]["Email"].ToString();
                        txtMark.Text = recset.Tables[0].Rows[0]["AccountMemo"].ToString();
                    }


                }
            }
        }

        protected void OnClickConfirm(object sender, EventArgs e)
        {
            string OperNo = Request.QueryString["OperNo"];
            string Tableid = Request.QueryString["ID"];
            DbHelp dbmanage;
            string strsex;
            bool bAddUser;
            if (OperNo == "ADD")
                bAddUser = true;
            else
                bAddUser = false;
                  
            if(RadioButtonSex0.Checked)
                strsex = "Man";
            else
                strsex = "Female";
            dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
            string strSQL = null;
            if (bAddUser)
            {
                strSQL = "Insert into AccountInf(UserName,UserIdentifier,Sex,Deptment,PhoneNum,MobileNumber,Address,IdenfierID,Email) Values ('" + txtLoginName.Text + "', '" +
                txtUserName.Text + "', '" + strsex + "', '" +
                listDept.SelectedItem.Text + "', '" + txtphone.Text + "', '" +
                txtMobile.Text + "', '" + txtAddress.Text + "','" +
                txtCardID.Text + "', '" + txtMail.Text + "')";
            }
            else
            {
                strSQL = "update AccountInf set UserName='" + txtLoginName.Text + "',UserIdentifier='" +
                txtUserName.Text + "',Sex='" +
                strsex + "',Deptment='" +
                listDept.SelectedItem.Text + "',PhoneNum='" +
                txtphone.Text + "',MobileNumber='" +
                txtMobile.Text + "',Address='" +
                txtAddress.Text + "',IdenfierID='" +
                txtCardID.Text + "',Email='" +
                txtMail.Text + "',AccountMemo='" +
                txtMark.Text + "'" + " where ID=" + Tableid;
            }
            dbmanage.ExecuteSql(strSQL);
            string script_str = "<script>alert('保存成功！')</script>";
            Response.Write(script_str);
        }
        protected void AddElement(XmlNode xelement)
        {

            ListItem lt = new ListItem();
            lt.Text = xelement.Attributes[0].Value;
            listDept.Items.Add(lt);
            if (xelement.HasChildNodes == true)
            {
                foreach (XmlElement element in xelement)
                {
                    AddElement(element);
                }
            }
        }

    }
}
