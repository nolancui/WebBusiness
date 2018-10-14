using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Xml;
using System.Runtime.InteropServices;
using System.Xml.XPath;
namespace WebApplication.SystemManage.DeptManager
{
   
    public partial class DeptTreeinf : System.Web.UI.Page
    {
        string strReadPath = "DeptTree\\DeptStruct.xml";
        string strSavePath = "DeptTree\\DeptStruct.xml";

        [DllImport("kernel32.dll")]
        static extern bool SetFileAttributes(string lpFileName, uint dwFileAttributes);
        protected void Page_Load(object sender, EventArgs e)
        {
             
            if (!Page.IsPostBack)
            {
                TreeviewBind(XmlDataSource1, TreeView1, strReadPath);
            }
        }
        void TreeviewBind(XmlDataSource xds, TreeView tv, string path)
        {
            xds.DataFile = path;
            tv.DataSource = xds;
            try
            {
                tv.DataBind();
            }
            catch
            {
            }
                
        }
        TreeNode tn = new TreeNode();
        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            //?NodeName=上海'
           tn = TreeView1.SelectedNode;
           string script_str;
           script_str = "<script>self.parent.frames['frmbmoperarea'].location.href='DepAdd.aspx?NodeName="+tn.Text+"'</script>";
           Response.Write(script_str);

        }
    }
}
