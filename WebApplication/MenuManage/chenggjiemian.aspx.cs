using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using Dyne.Dal;
namespace WebApplication.MenuManage
{
    public partial class chenggjiemian : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string customerid = Request.QueryString["CustomerID"];
                string strtxtzje = Request.QueryString["txtzje"];
                string strtxtjqx = Request.QueryString["txtjqx"];
                string strtxtzhfiyao = Request.QueryString["txtzhfiyao"];
                string strtxtzc = Request.QueryString["txtzc"];

                string strsql = "select * from BaseInfo where ID=" + customerid;
                DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
                DataSet ds = dbmanage.QueryToDs(strsql);
                int count;
                if (ds != null)
                {

                    count = ds.Tables[0].Rows.Count;
                    if (count == 1)
                    {
                        txtbbxr.Value = ds.Tables[0].Rows[0]["ClientName"].ToString();
                        txtcphm.Value = ds.Tables[0].Rows[0]["CarNumber"].ToString();

                        txtlxdh.Value = ds.Tables[0].Rows[0]["PhoneNum"].ToString();

                        txtqssj.Value = ds.Tables[0].Rows[0]["InsuranceTime"].ToString();
                        txtbxgs.Value = ds.Tables[0].Rows[0]["InsuranceCompany"].ToString();
                        txtpinpai3.Value = ds.Tables[0].Rows[0]["Gift"].ToString();
                        txtlxdz.Value = ds.Tables[0].Rows[0]["Address"].ToString();
                        txtbz.Value = ds.Tables[0].Rows[0]["Addition"].ToString();
                        txtfwsj.Value = ds.Tables[0].Rows[0]["ServiceTime"].ToString();
                        string userid = ds.Tables[0].Rows[0]["UserID"].ToString();
                        string strpay = ds.Tables[0].Rows[0]["PayManner"].ToString();
                        if (strpay == "刷卡")
                            RadioButton1.Checked = true;
                        if (strpay == "转账")
                            RadioButton2.Checked = true;
                        if (strpay == "现金")
                            RadioButton3.Checked = true;
                        if (strpay == "上门")
                            RadioButton4.Checked = true;

                        txtsyxje.Value = strtxtzhfiyao;
                        txtjqxje.Value = strtxtjqx;
                        txtssje.Value = strtxtzje;
                        txtpinpai2.Value = strtxtzc;

                        dbmanage  = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
                        strsql = "select * from AccountInf where ID=" + userid;
                        DataSet ds1 = dbmanage.QueryToDs(strsql);
                        txtywy.Value = ds1.Tables[0].Rows[0]["UserName"].ToString();
                        txtywydh.Value = ds1.Tables[0].Rows[0]["PhoneNum"].ToString();
                    }


                }
            }
                int count1;
                string strsql1 = "select * from AccountInf where Authority='内勤'";
                DbHelp dbmanage1 = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
                DataSet dsuser = dbmanage1.QueryToDs(strsql1);
                if (dsuser != null)
                {
                    count1 = dsuser.Tables[0].Rows.Count;
                    for (int i = 0; i < count1; i++)
                    {
                        string checkid = "ckbid_" + i.ToString();
                        CheckBox checkbox = new CheckBox();
                        checkbox.Text = dsuser.Tables[0].Rows[i]["UserName"].ToString();
                        checkbox.InputAttributes["onclick"] = "ttt()";
                        checkbox.InputAttributes["Value"] = dsuser.Tables[0].Rows[i]["ID"].ToString();
                        Secretary.Controls.Add(checkbox);
                    }
            }
            

        }

        protected void OnEnsureSuccess(object sender, EventArgs e)
        {
            if (txtxis.Value == "null")
                return;
            string nowTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string customerid = Request.QueryString["CustomerID"];
            string strpay="刷卡";
            if (RadioButton1.Checked == true)
                strpay = "刷卡";
            if (RadioButton2.Checked == true)
                strpay = "转账";
            if (RadioButton3.Checked == true)
                strpay = "现金";
            if (RadioButton4.Checked == true)
                strpay = "上门";
            DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
            string strsql = "update BaseInfo set Address='"+txtlxdz.Value+
                "',Addition='"+txtbz.Value+
                "',PayManner='"+strpay+
                "',Gift='"+txtpinpai3.Value+
                "',[State]='成功"+
                "',CommitTime='"+nowTime+
                "',ServiceTime='" + txtfwsj.Value +
                "',UserExtraID='"+txtxis.Value+"' where ID=" + customerid;
            int num = dbmanage.ExecuteSql(strsql);
            if (num > 0)
            {
                Response.Write("<script>alert('提交成功')</script>");
                Response.Write("<script language=javascript>opener.location.href=opener.location.href;window.close();</script>");
            }
            else
                Response.Write("<script>alert('提交失败，num < 0')</script>");
        }

    }
}
