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
namespace WebApplication.SystemManage.DeptManager
{
    public partial class DepAdd: System.Web.UI.Page
    {

        string strReadPath = "DeptTree//DeptStruct.xml";
        string strSavePath = "DeptTree//DeptStruct.xml";
        [DllImport("kernel32.dll")]
        static extern bool SetFileAttributes(string lpFileName, uint dwFileAttributes);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                 //XmlDataSource xds=new XmlDataSource();
                 //xds.DataFile = strSavePath;  
                 //ListParentDept.DataSource = xds;
                 //ListParentDept.DataTextField = "Text";
                 //ListParentDept.DataValueField = "Text";
                 //ListParentDept.DataBind();

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
                         //foreach (XmlElement xe in xn)
                         //    //if (xe.Attributes[0].Value == selectitem)
                         //    {
                         //        ListItem lt = new ListItem();
                         //        lt.Text = xe.Attributes[0].Value;
                         //        ListParentDept.Items.Add(lt);
                         //    }
                     }
                 }

                 ListItem ltselext = new ListItem();
                 ltselext.Text = "请选择";
                 ltselext.Value = "00";
                 ltselext.Selected = true;
                 ListParentDept.Items.Insert(0, ltselext);

                 DbHelp dbmanage;
                 dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
                string DeptName = Request.QueryString["NodeName"];
                string strSQL = "select * from Deptment where DeptName='"+DeptName+"'";
               // OleDbDataReader reader1;
                //{
                //    using (OleDbCommand cmd = new OleDbCommand(strSQL, cn))
                //    {
                //        try
                //        {
                //            cn.Open();
                //            reader1 = cmd.ExecuteReader();
                //        }
                //        catch (System.Data.OleDb.OleDbException exp)
                //        {
                //            cn.Dispose();
                //            throw new Exception(exp.Message);
                //        }
                //    }
                //}
                //cn.Open();
                //OleDbCommand myCmd = new OleDbCommand(strSQL, cn);
                //int num1 = myCmd.ExecuteNonQuery();
                object firstobject;
                bool num = dbmanage.GetSingle(strSQL,out firstobject);
               // OleDbDataReader reader1 = dbmanage.ExecuteReader(strSQL) as OleDbDataReader;
                DataSet recset = dbmanage.QueryToDs(strSQL);
                try
                {
                    if (null != recset)
                    {
                        ListParentDept.SelectedValue = recset.Tables[0].Rows[0]["ParentDept"].ToString();
                        txtDeptLeader.Text = recset.Tables[0].Rows[0]["DeptLeader"].ToString();
                        txtDeptTel.Text =  recset.Tables[0].Rows[0]["DeptTel"].ToString();
                        txtDeptTax.Text =  recset.Tables[0].Rows[0]["DeptTax"].ToString();
                        txtDeptPerson.Text =  recset.Tables[0].Rows[0]["DeptPerson"].ToString();
                        txtOrder.Text =  recset.Tables[0].Rows[0]["DeptOrder"].ToString();
                        txtDeptName.Text =  recset.Tables[0].Rows[0]["DeptName"].ToString();
                        txtDeptAddress.Text =  recset.Tables[0].Rows[0]["DeptAddress"].ToString();
                        txtDeptMemo.Text = recset.Tables[0].Rows[0]["DeptMemo"].ToString();
                        //BtnSave.Visible = false;
                        BtnAdd.Visible = true;
                        //BtnConfirm.Visible = true;
                        BtnDel.Visible = true;
                    }
                    //{

                    //    BtnSave.Visible = true;
                    //    BtnAdd.Visible = false;
                    //    BtnConfirm.Visible = false;
                    //    BtnDel.Visible = false;

                    //}
                }
                catch
                {
                   // throw;
                }
            }
        }
        protected void AddElement(XmlNode xelement)
        {

            ListItem lt = new ListItem();
            lt.Text = xelement.Attributes[0].Value;
            ListParentDept.Items.Add(lt);
            if (xelement.HasChildNodes==true)
            {
                foreach (XmlElement element in xelement)
                {
                    AddElement(element);
                }
            }
        }

        protected XmlNode GetElementNode(XmlNode xelement, string selectitem)
        {
            XmlNode node=null;
            if(xelement.Attributes[0].Value == selectitem)
                node = xelement;
            else{
            if (xelement.HasChildNodes == true)
            {
                foreach (XmlElement element in xelement)
                {
                    if (element.Attributes[0].Value == selectitem)
                    {
                        node = element;
                        break;
                        // var content = element.GetAttribute("value");
                    }
                    node = GetElementNode(element, selectitem);
                }
            }
            }
            return node;

        }
        protected string GetParentNodePath(XmlNode xelement)
        {
            string strtemp;
            string strtemp1;
            XmlNode parentnode = xelement.ParentNode;
            strtemp = xelement.Name;
            if (strtemp != "所有部门")
            {
                strtemp1 = GetParentNodePath(parentnode);
                strtemp = strtemp1 + "/" + strtemp;
            }
            return strtemp;
            
        }
        protected void OnClickAdd(object sender, EventArgs e)
        {
            DbHelp dbmanage;
            dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
            string selectitem;
            if ("请选择" == ListParentDept.SelectedItem.Text)
                selectitem = "所有部门";
            else
                selectitem = ListParentDept.SelectedItem.Text;

            string strquerry = "select * from Deptment where DeptName='" + txtDeptName.Text + "'";
            object firstobject;
            bool addedhave = dbmanage.GetSingle(strquerry, out firstobject);
            if (addedhave == true && null!=firstobject)
            {
                string script_str = "<script>alert('此部门已经存在！')</script>";
                Response.Write(script_str);
                return;
            }

            string strSQL = "Insert into Deptment(ParentDept,DeptName,DeptLeader,DeptTel,DeptTax,DeptPerson,DeptOrder,DeptAddress,DeptMemo) Values ('" + selectitem + "', '" + 
               txtDeptName.Text + "', '" + txtDeptLeader.Text + "', '" +
               txtDeptTel.Text+"', '"+txtDeptTax.Text+"', '"+
               txtDeptPerson.Text+"', '"+txtOrder.Text+"','"+
               txtDeptAddress.Text + "', '" + txtDeptMemo.Text + "')";
            int returnnum = dbmanage.ExecuteSql(strSQL);
            try
            {
                XmlDocument doc = new XmlDocument();
                strSavePath = Server.MapPath(strReadPath);
                doc.Load(strSavePath);
                string nodepath = "所有部门";
                XmlNodeList xnl = doc.SelectSingleNode("所有部门").ChildNodes;
                XmlNode selectnode;
                if (xnl.Count > 0)
                {
                    foreach (XmlNode xn in xnl)
                    {
                        selectnode = GetElementNode(xn, selectitem);
                        //foreach (XmlElement xe in xn)
                        //if (xe.Attributes[0].Value == selectitem)
                        if (selectnode != null)
                        {
                            nodepath = GetParentNodePath(selectnode);
                            break;
                            // var content = element.GetAttribute("value");
                        }
                    }
                }
                XPathNavigator navigator = doc.CreateNavigator();
                foreach (XPathNavigator nav in navigator.Select(nodepath))
                {
                    if (nav.HasAttributes == true)
                    {
                        nav.MoveToFirstAttribute();
                        //if (nav.Name == "Value")
                        {
                            if (nav.Value == selectitem)
                            {
                                nav.MoveToParent();
                                nav.AppendChild("<node Text=\"" + txtDeptName.Text + "\"></node>");
                                SetFileAttributes(strSavePath, (uint)0);
                                SetFileAttributes(strSavePath, (uint)128);
                                doc.Save(strSavePath);
                           //     Response.Redirect(Request.RawUrl);
                            }
                        }
                    }
                    else
                    {
                        nav.AppendChild("<node Text=\"" + txtDeptName.Text + "\"></node>");
                        SetFileAttributes(strSavePath, (uint)0);
                        SetFileAttributes(strSavePath, (uint)128);
                        doc.Save(strSavePath);
                       // Response.Redirect(Request.RawUrl);
                    }
                    while (nav.MoveToNext()) ;
                }

                
               
            }
            catch (Exception)
            {
               

            }
            string script_strback = "<script>self.parent.frames['bmListTree'].location.href='DeptTreeinf.aspx'</script>";
            Response.Write(script_strback);

        }

        protected void OnClickConfirm(object sender, EventArgs e)
        {

        }
        protected void OnClickDel(object sender, EventArgs e)
        {

            DbHelp dbmanage;
            string selectitem = txtDeptName.Text;
            dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;"); 
            string strquerry = "delete from Deptment where DeptName='" + txtDeptName.Text + "'";
            int num = dbmanage.ExecuteSql(strquerry);
            try
            {
                XmlDocument doc = new XmlDocument();
                strSavePath = Server.MapPath(strReadPath);
                doc.Load(strSavePath);
                string nodepath = "所有部门";
                XmlNodeList xnl = doc.SelectSingleNode("所有部门").ChildNodes;
                XmlNode selectnode=null;
                if (xnl.Count > 0)
                {
                    foreach (XmlNode xn in xnl)
                    {
                        selectnode = GetElementNode(xn, selectitem);
                        //foreach (XmlElement xe in xn)
                        //if (xe.Attributes[0].Value == selectitem)
                        if (selectnode != null)
                        {
                            nodepath = GetParentNodePath(selectnode);
                            break;
                            // var content = element.GetAttribute("value");
                        }
                    }
                }

                if (selectnode==null) 
                    return;
                XPathNavigator navigator = doc.CreateNavigator();
                foreach (XPathNavigator nav in navigator.Select(nodepath))
                {
                    if (nav.HasAttributes == true)
                    {
                        nav.MoveToFirstAttribute();
                       // if (nav.Name == "Value")
                        {
                            if (nav.Value == selectitem)
                            {
                                nav.MoveToParent();
                                nav.DeleteSelf();
                            }
                        }
                    }
                    while (nav.MoveToNext()) ;
                    SetFileAttributes(strSavePath, (uint)0);
                    SetFileAttributes(strSavePath, (uint)128);
                    doc.Save(strSavePath);
                }
            }
            catch (Exception)
            {


            }
            string script_strback = "<script>self.parent.frames['bmListTree'].location.href='DeptTreeinf.aspx'</script>";
            Response.Write(script_strback);
            //Response.Redirect(Request.RawUrl);

        }
        protected void OnClickSave(object sender, EventArgs e)
        {

        }
    }
}
