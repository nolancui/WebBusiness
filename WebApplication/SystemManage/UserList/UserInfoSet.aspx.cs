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
    public partial class UserInfoSet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string UserID = Session["UserID"].ToString();
                string strReadPath = "..//DeptManager//DeptTree//DeptStruct.xml";
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
                ltselext.Text = "请选择";
                ltselext.Value = "0";
                deptment.Items.Add(ltselext);

                ListItem ltselext1 = new ListItem();
                ltselext1.Text = "小学";
                ltselext1.Value = "1";
                listSchool.Items.Add(ltselext1);
                ListItem ltselext2 = new ListItem();

                ltselext2.Text = "初中";
                ltselext2.Value = "2";
                listSchool.Items.Add(ltselext2);
                ListItem ltselext3 = new ListItem();

                ltselext3.Text = "高中";
                ltselext3.Value = "3";
                listSchool.Items.Add(ltselext3);
                ListItem ltselext4 = new ListItem();

                ltselext4.Text = "中专";
                ltselext4.Value = "4";
                listSchool.Items.Add(ltselext4);
                ListItem ltselext5 = new ListItem();

                ltselext5.Text = "大专";
                ltselext5.Value = "5";
                listSchool.Items.Add(ltselext5);
                ListItem ltselext6 = new ListItem();

                ltselext6.Text = "本科";
                ltselext6.Value = "6";
                listSchool.Items.Add(ltselext6);
                ListItem ltselext7 = new ListItem();

                ltselext7.Text = "硕士";
                ltselext7.Value = "7";
                listSchool.Items.Add(ltselext7);
                ListItem ltselext8 = new ListItem();

                ltselext8.Text = "博士";
                ltselext8.Value = "8";
                listSchool.Items.Add(ltselext8);
                ListItem ltselext9 = new ListItem();

                ltselext9.Text = "其它";
                ltselext9.Value = "9";
                listSchool.Items.Add(ltselext9);
                GetUserInf();
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

        void GetUserInf()
        {
            DbHelp dbmanage;
            dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
            string strsql = "select * from AccountInf where ID=" + Session["UserID"];
            DataSet ds = dbmanage.QueryToDs(strsql);
             int count = ds.Tables[0].Rows.Count;
             if (count == 1)
             {
                 txtUserName.Value = ds.Tables[0].Rows[0]["UserIdentifier"].ToString();
                 string strsex = ds.Tables[0].Rows[0]["Sex"].ToString();
                 if(strsex =="Man")
                     RadioButtonSex0.Checked = true;
                 else
                     RadioButtonSex1.Checked = true;

                 deptment.SelectedItem.Text = ds.Tables[0].Rows[0]["Deptment"].ToString();
                 txtphone.Value = ds.Tables[0].Rows[0]["PhoneNum"].ToString();
                 txtMobile.Value = ds.Tables[0].Rows[0]["MobileNumber"].ToString();
                 txtAddress.Value = ds.Tables[0].Rows[0]["Address"].ToString();
                 txtCardID.Value = ds.Tables[0].Rows[0]["IdenfierID"].ToString();
                 if (ds.Tables[0].Rows[0]["School"].ToString() == "")
                     listSchool.SelectedValue = "1";
                 else
                     listSchool.SelectedValue = ds.Tables[0].Rows[0]["School"].ToString();
                 txtBirthDay.Value = ds.Tables[0].Rows[0]["BirthDay"].ToString();
                 txtMail.Value = ds.Tables[0].Rows[0]["Email"].ToString();

             }

        }
        protected void RefinePassword(object sender, EventArgs e)
        {
            string originalpass = txtOldPass.Value;
            string newpass = txtPassWord1.Value;
            string passagain = txtPassWord2.Value;

            if (newpass != passagain)
            {
                Response.Write("<script>alert('输入新密码不一致')</script>");
                return;
            }
            string strSQL = "SELECT * FROM AccountInf where ID=" + Session["UserID"] +
                        " and PassWord='" + originalpass + "'";
            DbHelp dbmanage;
            dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
            DataSet ds = dbmanage.QueryToDs(strSQL);
            int count = ds.Tables[0].Rows.Count;
            if (count != 1)
            {
                Response.Write("<script>alert('输入原密码有误')</script>");
                return;
            }
            else
            {
                strSQL ="update AccountInf set [PassWord]='"+newpass+"'"+" where ID="+ Session["UserID"];
                count = dbmanage.ExecuteSql(strSQL);
                if (count == 1)
                {
                    Response.Write("<script>alert('密码修改成功')</script>");
                }
                else
                    Response.Write("<script>alert('密码修改失败')</script>");

            }
        }
        protected void RefineUserInf(object sender, EventArgs e)
        {
            DbHelp dbmanage;
            dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
            string strsql = "update AccountInf set UserIdentifier='" + txtUserName.Value + "'," +
                "Sex='" + (RadioButtonSex0.Checked == true ? "Man" : "Female") + "',"
                    + "Deptment='" + deptment.SelectedItem.Text + "',"
                    + "PhoneNum ='" + txtphone.Value + "',"
                    + "MobileNumber ='" + txtMobile.Value + "',"
                    + "Address ='" + txtAddress.Value + "',"
                    + "IdenfierID='" + txtCardID.Value + "',"
                    + "School='" + listSchool.SelectedValue + "',"
                    + "BirthDay='" + txtBirthDay.Value + "',"
                    + "Email='" + txtMail.Value + "' where ID=" + Session["UserID"];
            dbmanage.ExecuteSql(strsql);
            Response.Write("<script>alert('保存成功')</script>");
            
        }

        
        
    }

    
    
}
