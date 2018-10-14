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
    public partial class ADR : System.Web.UI.Page
    {
        string strReadPath = "..//DeptManager//DeptTree//DeptStruct.xml";
        bool bAddUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataDisplay();
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
                deptment.Items.Insert(0, ltselext);

                ListItem lt = new ListItem("--名单状态--", "--名单状态--");
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
        protected void OnBtnSaveClick(object sender, EventArgs e)
        {
             string struserid = Request.QueryString["ID"];
            int intnum = int.Parse(txtnum.Value);
            if (intnum > int.Parse(txtyyl.Value))
                Response.Write("<script>alert('重新分配数目超过已有记录数目！')</script>");
            else
            {
                string strsql = "select * from BaseInfo where UserID='" + struserid + "'";
                if (DropDownList1.SelectedItem.Value != "--名单状态--" && DropDownList1.SelectedItem.Value != "")
                    strsql += " and State='" + DropDownList1.SelectedItem.Value + "'";
                if (DropDownList2.SelectedItem.Value != "--客户类型--" && DropDownList2.SelectedItem.Value != "")
                    strsql += " and CustomerType='" + DropDownList2.SelectedItem.Value + "'";
                //string strsql = "select * from BaseInfo where UserID='" + struserid + "' and [State]='" + DropDownList1.SelectedItem.Value + "'";
                DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");

                DataSet ds = dbmanage.QueryToDs(strsql);
                int count = 0;
                if(ds!=null)
                {
                    count = ds.Tables[0].Rows.Count;
                    for(int i=0;i<intnum;i++)
                    {
                        string strsql1 = "update BaseInfo set OwnedService='" + DropDownListstaf.SelectedItem.Text + "',UserID='" + DropDownListstaf.SelectedItem.Value + "' where ID=" + ds.Tables[0].Rows[i]["ID"];
                        dbmanage.ExecuteSql(strsql1);
                    }
                }
                
               // strsql = "select * from BaseInfo where UserID='" + struserid + "'";
                 ds = dbmanage.QueryToDs(strsql);
                count = ds.Tables[0].Rows.Count;
                txtyyl.Value = count.ToString();
                Response.Write("<script>alert('重新分配成功')</script>");

            }
        }

        protected void SelectCaculateRecordNum(object sender, EventArgs e)
        {

             string struserid = Request.QueryString["ID"];
            string strsql = "select * from BaseInfo where UserID='" + struserid + "'";
            if(DropDownList1.SelectedItem.Value!="--名单状态--"&&DropDownList1.SelectedItem.Value!="")
                strsql += " and State='" + DropDownList1.SelectedItem.Value + "'";
            if (DropDownList2.SelectedItem.Value != "--客户类型--" && DropDownList2.SelectedItem.Value != "")
                strsql += " and CustomerType='" + DropDownList2.SelectedItem.Value + "'";
            DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");

            DataSet ds = dbmanage.QueryToDs(strsql);
            int count = ds.Tables[0].Rows.Count;
            txtyyl.Value = count.ToString();

        }

        protected void SelectDeptment(object sender, EventArgs e)
        {
            string strdeptname = deptment.SelectedItem.Value;
            string strsql = "select * from AccountInf where Deptment='" + strdeptname + "' and Authority='客服'";
            DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");

            DataSet ds = dbmanage.QueryToDs(strsql);
            DropDownListstaf.DataSource = ds.Tables[0].DefaultView;
            DropDownListstaf.DataTextField = "UserName";
            DropDownListstaf.DataValueField = "ID";
            DropDownListstaf.DataBind();

        }

        protected void DataDisplay()
        {

            string struserid = Request.QueryString["ID"];
            string strsql = "select * from BaseInfo where UserID='" + struserid + "'";
            DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");

            DataSet ds = dbmanage.QueryToDs(strsql);
            int count = ds.Tables[0].Rows.Count;
            txtyyl.Value = count.ToString();

            strsql = "select * from AccountInf where ID=" + struserid;
            dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");

            ds = dbmanage.QueryToDs(strsql);

            if(ds!=null)
                txtsskf.Value = ds.Tables[0].Rows[0]["UserName"].ToString();
           
        }
    }


}
