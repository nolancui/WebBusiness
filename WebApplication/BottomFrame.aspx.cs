using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;

namespace WebApplication
{
    public partial class BottomFrame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            welcome.InnerHtml = "欢迎你，" + Session["UserName"];
            username.InnerHtml = "姓名，" + Session["UserIdentifier"];
        }


    }
}
