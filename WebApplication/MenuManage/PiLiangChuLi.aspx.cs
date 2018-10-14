using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using Dyne.Dal;
using System.Data.SqlClient;
namespace WebApplication.MenuManage
{
    public partial class PiLiangChuLi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == "admin")
                return;
            if (!IsPostBack)
            {
                string username = null;
                if (Session["UserName"] != null)
                {
                    username = Session["UserName"].ToString();
                }
                else
                {
                    //if login error
                    username = "test";
                    Session["UserName"] = username;
                }

                //begin to initial the appointment 

                List<int> countInfo = new List<int>();
                InitialAppointmentTimeTableCount(countInfo);
               

                List<string> testInfo = new List<string>();
                //testInfo.Add("name1");
                //testInfo.Add("typeA");
                //testInfo.Add("CarId:xxxx");
                //testInfo.Add("AppointTime:now1");
                InitialAppoint(testInfo);

                initialTable(countInfo);
                YuyueGenZhong(testInfo, (int)(testInfo.Count / 4));
                txthuiyuan.Value = Convert.ToString(70);
            }
            GetTipsOfCustomerinf();

        }
        protected void GetTipsOfCustomerinf()
        {

            string struserid = Session["UserID"].ToString();
            int successnum = 0;
            int appointnum = 0;
            int failednum = 0;
            int invalidatenum = 0;
            DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
            string strsql = "select * from BaseInfo where [State]='成功' and UserID='" + struserid + "'";
            DataSet ds = dbmanage.QueryToDs(strsql);
            if (ds != null)
                successnum = ds.Tables[0].Rows.Count;
            strsql = "select * from BaseInfo where [State]='预约' and UserID='" + struserid + "'";
            ds = dbmanage.QueryToDs(strsql);
            if (ds != null)
                appointnum = ds.Tables[0].Rows.Count;
            strsql = "select * from BaseInfo where [State]='失败' and UserID='" + struserid + "'";
            ds = dbmanage.QueryToDs(strsql);
            if (ds != null)
                failednum = ds.Tables[0].Rows.Count;
            strsql = "select * from BaseInfo where [State]='无效' and UserID='" + struserid + "'";
            ds = dbmanage.QueryToDs(strsql);
            if (ds != null)
                invalidatenum = ds.Tables[0].Rows.Count;

            Label1.InnerHtml = "成功量:" + successnum.ToString() +
           " 预约量:" + appointnum.ToString() + " 失败量:" + failednum.ToString() +
           " 无效量:" + invalidatenum.ToString();
        }
        protected void initialTable(List<int> CountInfo)
        {
            row00.InnerHtml = CountInfo[0].ToString();
            row01.InnerHtml = CountInfo[1].ToString();
            row02.InnerHtml = CountInfo[2].ToString();
            row03.InnerHtml = CountInfo[3].ToString();
            row04.InnerHtml = CountInfo[4].ToString();
            row10.InnerHtml = CountInfo[5].ToString();
            row11.InnerHtml = CountInfo[6].ToString();
            row12.InnerHtml = CountInfo[7].ToString();
            row13.InnerHtml = CountInfo[8].ToString();
            row14.InnerHtml = CountInfo[9].ToString();

            row20.InnerHtml = CountInfo[10].ToString();
            row21.InnerHtml = CountInfo[11].ToString();
            row22.InnerHtml = CountInfo[12].ToString();
            row23.InnerHtml = CountInfo[13].ToString();
            row24.InnerHtml = CountInfo[14].ToString();
            row30.InnerHtml = CountInfo[15].ToString();
            row31.InnerHtml = CountInfo[16].ToString();
            row32.InnerHtml = CountInfo[17].ToString();
            row33.InnerHtml = CountInfo[18].ToString();
            row34.InnerHtml = CountInfo[19].ToString();

            row40.InnerHtml = CountInfo[20].ToString();
            row41.InnerHtml = CountInfo[21].ToString();
            row42.InnerHtml = CountInfo[22].ToString();
            row43.InnerHtml = CountInfo[23].ToString();
            row44.InnerHtml = CountInfo[24].ToString();
            row50.InnerHtml = CountInfo[25].ToString();
            row51.InnerHtml = CountInfo[26].ToString();
            row52.InnerHtml = CountInfo[27].ToString();
            row53.InnerHtml = CountInfo[28].ToString();
            row54.InnerHtml = CountInfo[29].ToString();

            row60.InnerHtml = CountInfo[30].ToString();
            row61.InnerHtml = CountInfo[31].ToString();
            row62.InnerHtml = CountInfo[32].ToString();
            row63.InnerHtml = CountInfo[33].ToString();
            row64.InnerHtml = CountInfo[34].ToString();
            row70.InnerHtml = CountInfo[35].ToString();
            row71.InnerHtml = CountInfo[36].ToString();
            row72.InnerHtml = CountInfo[37].ToString();
            row73.InnerHtml = CountInfo[38].ToString();
            row74.InnerHtml = CountInfo[39].ToString();

            row80.InnerHtml = CountInfo[40].ToString();
            row81.InnerHtml = CountInfo[41].ToString();
            row82.InnerHtml = CountInfo[42].ToString();
            row83.InnerHtml = CountInfo[43].ToString();
            row84.InnerHtml = CountInfo[44].ToString();












            //string style = "style='text-align:center;height:25px';";
            //string TrStyle = "style='border:1px solid gray;'";

            ////TableRow headButton = new TableRow();
            ////TableCell headButtonCell = new TableCell();
            ////Button headButtonCellButton = new Button();
            ////headButtonCellButton.Text = "预约情况统计";
            ////headButtonCellButton.CssClass = "height='26' colspan='6'style='color:red; font-weight:bold; border-bottom:0px solid red'";
            ////headButtonCell.Controls.Add(headButtonCellButton);
           
            ////headButton.CssClass = "height='26' colspan='6'style='color:red; font-weight:bold; border-bottom:0px solid red'";
            ////headButton.Cells.Add(headButtonCell);
            ////tableDivide.Rows.Add(headButton);

            //TableHeaderRow tHeadRow = new TableHeaderRow();
            

            //TableHeaderCell shiJiandian = new TableHeaderCell();
            //TableHeaderCell Time_8_10 = new TableHeaderCell();
            //TableHeaderCell Time_10_12 = new TableHeaderCell();
            //TableHeaderCell Time_12_15 = new TableHeaderCell();
            //TableHeaderCell Time_15_17 = new TableHeaderCell();
            //TableHeaderCell Time_17_19 = new TableHeaderCell();

            //shiJiandian.Text = "时间点";
            //Time_8_10.Text = "8-10";
            //Time_10_12.Text = "10-12";
            //Time_12_15.Text = "12-15";
            //Time_15_17.Text = "15-17";
            //Time_17_19.Text = "17-19";

            //tHeadRow.Controls.Add(shiJiandian);
            //tHeadRow.Controls.Add(Time_8_10);
            //tHeadRow.Controls.Add(Time_10_12);
            //tHeadRow.Controls.Add(Time_12_15);
            //tHeadRow.Controls.Add(Time_15_17);
            //tHeadRow.Controls.Add(Time_17_19);
  

            ////tableDivide.Rows.Add(tHeadRow);
            //string[] WeekInfo = {"星期一","星期二","星期三","星期四","星期五","星期六","星期日"};
            
            //int item = 5;
            //for (int i = 0; i < 7; i++)
            //{
            //    TableRow tr = new TableRow();

            //    TableCell shiJiandiancell = new TableCell();
            //    TableCell Time_8_10cell = new TableCell();
            //    TableCell Time_10_12cell = new TableCell();
            //    TableCell Time_12_15cell = new TableCell();
            //    TableCell Time_15_17cell = new TableCell();
            //    TableCell Time_17_19cell = new TableCell();

            //    Label shiJiandiancellLabel = new Label();
            //    Label Time_8_10cellLabel = new Label();
            //    Label Time_10_12cellLabel = new Label();
            //    Label Time_12_15cellLabel = new Label();
            //    Label Time_15_17cellLabel = new Label();
            //    Label Time_17_19cellLabel = new Label();

            //    shiJiandiancellLabel.Text = WeekInfo[i];
            //    Time_8_10cellLabel.Text = CountInfo[i*item + 0].ToString();
            //    Time_10_12cellLabel.Text = CountInfo[i*item + 1].ToString();
            //    Time_12_15cellLabel.Text = CountInfo[i*item + 2].ToString();
            //    Time_15_17cellLabel.Text = CountInfo[i*item + 3].ToString();
            //    Time_17_19cellLabel.Text = CountInfo[i*item + 4].ToString();
            //    shiJiandiancellLabel.CssClass = style;

            //    shiJiandiancell.CssClass = style;
            //    Time_8_10cell.CssClass = style;
            //    Time_10_12cell.CssClass = style;
            //    Time_12_15cell.CssClass = style;
            //    Time_15_17cell.CssClass = style;
            //    Time_17_19cell.CssClass = style;

            //    tr.CssClass = TrStyle;
            //    shiJiandiancell.Controls.Add(shiJiandiancellLabel);
            //    Time_8_10cell.Controls.Add(Time_8_10cellLabel);
            //    Time_10_12cell.Controls.Add(Time_10_12cellLabel);
            //    Time_12_15cell.Controls.Add(Time_12_15cellLabel);
            //    Time_15_17cell.Controls.Add(Time_15_17cellLabel);
            //    Time_17_19cell.Controls.Add(Time_17_19cellLabel);
         
            //    tr.Cells.Add(shiJiandiancell);
            //    tr.Cells.Add(Time_8_10cell);
            //    tr.Cells.Add(Time_10_12cell);
            //    tr.Cells.Add(Time_12_15cell);
            //    tr.Cells.Add(Time_15_17cell);
            //    tr.Cells.Add(Time_17_19cell);

                //tableDivide.Rows.Add(tr);
            //}
        }
        protected void YuyueGenZhong(List<string> ClientInfo,int clientNum)
        {
            TableHeaderRow tHeadRow = new TableHeaderRow();


            TableHeaderCell ClientName = new TableHeaderCell();
            TableHeaderCell ClientType = new TableHeaderCell();
            TableHeaderCell CarId = new TableHeaderCell();
            TableHeaderCell AppointTime = new TableHeaderCell();

            ClientName.Text = "客户名";
            ClientType.Text = "客户类型";
            CarId.Text = "车牌号";
            AppointTime.Text = "预约时间";
            int item = 4;

            tHeadRow.Cells.Add(ClientName);
            tHeadRow.Cells.Add(ClientType);
            tHeadRow.Cells.Add(CarId);
            tHeadRow.Cells.Add(AppointTime);

            //YuyueGenZhongTable.Rows.Add(tHeadRow);

            for (int i = 0; i < clientNum; i++)
            {
                TableRow AddRow = new TableRow();

                TableCell ClientNameElement = new TableCell();
                TableCell ClientTypeElement = new TableCell();
                TableCell ClientCarIdElement = new TableCell();
                TableCell AppointTimeElement = new TableCell();

                Button RenewPage = new Button();
                Label ClientTypeElementLable = new Label();
                Label ClientCarIdElementLable = new Label();
                Label AppointTimeElementLable = new Label();


                RenewPage.CssClass = "center btn btn-danger glyphicon glyphicon-trash icon-white";
                RenewPage.Text = ClientInfo[i*item + 0];
                RenewPage.Click += OnClickEvent;
                RenewPage.CommandArgument = ClientInfo[i * item + 0];

                ClientTypeElementLable.Text = ClientInfo[i * item + 1];
                ClientCarIdElementLable.Text = ClientInfo[i * item + 2];
                AppointTimeElementLable.Text = ClientInfo[i * item + 3];

                ClientNameElement.Controls.Add(RenewPage);
                ClientTypeElement.Controls.Add(ClientTypeElementLable);
                ClientCarIdElement.Controls.Add(ClientCarIdElementLable);
                AppointTimeElement.Controls.Add(AppointTimeElementLable);

                AddRow.Cells.Add(ClientNameElement);
                AddRow.Cells.Add(ClientTypeElement);
                AddRow.Cells.Add(ClientCarIdElement);
                AddRow.Cells.Add(AppointTimeElement);

                //YuyueGenZhongTable.Rows.Add(AddRow);

                //Button

            }


        }
        protected void OnClickEvent(object sender, EventArgs e)
        {
            string ClientName = ((Button)sender).CommandArgument.ToString();
            if (ClientName == "张福平")
            {
                ClientName = "test";
            }
             
            InitialPage(ClientName);


            //temple.RemoveAt(Convert.ToInt32(test) - 1);
            //tableDivide.Rows.RemoveAt(Convert.ToInt32(test));
            //SaveFile();

            //use this button trick renew webpage
            //search database and fullfill the component element
            //serch list and the result saved in a list
            //the use the list to initial the table
        }

        protected void InitialDetaiInfoTable(List<string> detaiInfo)
        {
            //check box state caculate by program not recode in database
            //baseInformation totoal is 18
            /*
            txtkh :ClientName 客户名
            txtchepai :CarId :车牌号
            txtchejia :车架号
            txtpinpai :品牌
            txtchexing :车型
            txtfadongji :发动机号
            txtguding   :固定电话
            txtshouj    :手机号
            txtshenfenz :身份证号
            txtdengj    :登记时间
            txtjiaoqiang :交强险时间
            txtshangyexian :商业险时间
            drtb         :投保公司
            txtzuowei    :座位数
            txtkhlx      :客户类型
            txtlxdz      :地址
            btnsave      :保存按钮 
            txtbz        :注备
             * 
             */
            //car infor
            /*
             txtcpp    车牌号  
             drxz     车辆类型(选择)   
             drzl     座位/吨数(选择)   
             txtwy    车辆价格   
             * /
             * 
             //不计免赔
             /*
             cbcsun      车损（checkbox）
             txtcs       车损input
             cbsz        三者(checkbox)
             txtds2      三者(input)
             cbches      盗抢(checkbox)
             txtdx2      盗抢(input)
             cbcheshuahe 车上人员(checkbox)
             txtcsry     车上人员(input)
             cbhh2       车身划痕（checkbox） 
             txthh2      车身划痕（input）
             cbzr2       自燃（checkbox）
             txtzr2      自燃（input） 
             */

            //基本保险
            /*
             jdcsubx    机动车损失保险(checkbox)
             drssbx     机动车损失保险(option)
             txtjdc     机动车损失保险(input)
             * 
             cbdsz      第三者责任保险
             drds      
             txtds   
             * 
             ckqcdq    全车盗抢损失险
             txtdx   
             * 
             cksj      车上人员司机位
             drsj      
             txtsj    
             * 
             ckck     车上人员乘客位 
             drck      
             txtgs     
             txtck  
             *
             //附加险
             * 
             ckboli   玻璃单独破碎 
             drboli
             txtboli
             * 
             ckhh    车身划痕损失费
             drhh
             txthh
             * 
             ckzr   车辆自燃损失费
             txtzr  
             * 
             txthuiyuan  VIP会员折扣系数
             txtjqx      交强险
             txtzc       车船税 
             txtzhfiyao  折后保费
             txtzje      总金额 
             */

            txtcpp.Value = txtchepai.Value;
            drxz.Value = detaiInfo[3];
            drzl.Value = detaiInfo[4];
            txtwy.Value = detaiInfo[5];
            cbcsun.Value = detaiInfo[6];
            txtcs.Value = detaiInfo[7];
            cbsz.Value = detaiInfo[8];
            txtds2.Value = detaiInfo[9];
            cbches.Value = detaiInfo[10];
            txtdx2.Value = detaiInfo[11];
            cbcheshuahe.Value = detaiInfo[12];
            txtcsry.Value = detaiInfo[13];
            cbhh2.Value = detaiInfo[14];
            txthh2.Value = detaiInfo[15];
            cbzr2.Value = detaiInfo[16];
            txtzr2.Value = detaiInfo[17];


            jdcsubx.Value = detaiInfo[18];

            drssbx.Value = detaiInfo[19];
            txtjdc.Value = detaiInfo[20];

            cbdsz.Value = detaiInfo[21];
            drds.Value = detaiInfo[22];
            txtds.Value = detaiInfo[23];

            ckqcdq.Value = detaiInfo[24];
            txtdx.Value = detaiInfo[25];

            cksj.Value = detaiInfo[26];
            drsj.Value = detaiInfo[27];
            txtsj.Value = detaiInfo[28];

            txtck.Value = detaiInfo[29];
            drck.Value = detaiInfo[30];
            txtgs.Value = detaiInfo[31];

            ckboli.Value = detaiInfo[32];
            drboli.Value = detaiInfo[33];
            txtboli.Value = detaiInfo[34];

            ckhh.Value = detaiInfo[35];
            drhh.Value = detaiInfo[36];
            txthh.Value = detaiInfo[37];

            ckzr.Value = detaiInfo[38];
            txtzr.Value = detaiInfo[39];
            txtfdj.Value = detaiInfo[40];
            txtfdj2.Value = detaiInfo[41];
            txthuiyuan.Value = detaiInfo[42];
            txtjqx.Value = detaiInfo[43];
            txtzc.Value = detaiInfo[44];
            txtzhfiyao.Value = detaiInfo[45];
            txtzje.Value = detaiInfo[46];

            InitialCheckState();
        }

        protected void WriteDataBackToDatabase(List<string> GetPageData)
        {
            GetPageData.Add(drxz.Value);
            GetPageData.Add(drzl.Value);
             GetPageData.Add(txtwy.Value);
             GetPageData.Add(cbcsun.Value);
             GetPageData.Add( txtcs.Value);
             GetPageData.Add( cbsz.Value);
             GetPageData.Add(txtds2.Value);
             GetPageData.Add(cbches.Value);
             GetPageData.Add(txtdx2.Value);
             GetPageData.Add(cbcheshuahe.Value);
             GetPageData.Add(txtcsry.Value);
            GetPageData.Add(cbhh2.Value);
             GetPageData.Add(txthh2.Value);
             GetPageData.Add( cbzr2.Value);
             GetPageData.Add(txtzr2.Value);


             GetPageData.Add( jdcsubx.Value);

            GetPageData.Add( drssbx.Value);
             GetPageData.Add( txtjdc.Value);

             GetPageData.Add( cbdsz.Value);
             GetPageData.Add(drds.Value);
             GetPageData.Add(txtds.Value);

             GetPageData.Add( ckqcdq.Value);
            GetPageData.Add( txtdx.Value);

             GetPageData.Add(cksj.Value);
             GetPageData.Add( drsj.Value);
             GetPageData.Add( txtsj.Value);

             GetPageData.Add( txtck.Value);

             GetPageData.Add( drck.Value);
             GetPageData.Add( txtgs.Value);

            GetPageData.Add(ckboli.Value);
             GetPageData.Add( drboli.Value);
             GetPageData.Add(txtboli.Value);

             GetPageData.Add( ckhh.Value);
             GetPageData.Add( drhh.Value);
             GetPageData.Add( txthh.Value);

             GetPageData.Add(ckzr.Value);
             GetPageData.Add( txtzr.Value);

             GetPageData.Add(txthuiyuan.Value);
             GetPageData.Add( txtjqx.Value);
             GetPageData.Add( txtzc.Value);
             GetPageData.Add( txtzhfiyao.Value);
             GetPageData.Add( txtzje.Value);
             GetPageData.Add(txtfdj.Value);
             GetPageData.Add(txtfdj2.Value);

        }


        protected bool InitialPage(string customerid)
        {

            InitializeBaseInf(customerid);
            string test = null;
            DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");

            //OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
            //   Server.MapPath("..//DataBase//DataManageMent.accdb"));
            string strSQL = "SELECT * FROM DetailCustomInf where CustomerID = '" + customerid + "'";
            //cn.Open();
            //OleDbCommand myCmd = new OleDbCommand(strSQL, cn);



            using (SqlConnection connection = new SqlConnection("server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;"))
            {
                using (SqlCommand cmd = new SqlCommand(strSQL, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        List<string> InitialData = new List<string>();
                        if (reader.Read())
                        {
                            if (reader.FieldCount > 0)
                            {

                                ContentInitial(reader, InitialData);
                                InitialDetaiInfoTable(InitialData);

                            }
                        }
                        else
                        {

                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                InitialData.Add("");

                            }
                            InitialDetaiInfoTable(InitialData);
                        }
                    }
                    catch (SqlException exp)
                    {
                        connection.Dispose();
                        throw new Exception(exp.Message);
                    }
                }
            }









           // OleDbDataReader rd = (OleDbDataReader)dbmanage.ExecuteReader(strSQL);
            

           // cn.Close();
            return true;
        }

        protected void InitializeBaseInf(string strcustomerid)
        {
            string strsql = "select * from BaseInfo where ID=" + strcustomerid;
            clientid.Value = strcustomerid;
            DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
            DataSet ds = dbmanage.QueryToDs(strsql);
            if (ds != null)
            {
                int count = ds.Tables[0].Rows.Count;
                if (count == 1)
                {
                    txtkh.Value = ds.Tables[0].Rows[0]["ClientName"].ToString();
                    txtchepai.Value = ds.Tables[0].Rows[0]["CarNumber"].ToString();
                    txtchejia.Value = ds.Tables[0].Rows[0]["VehicleIdentification"].ToString();
                    txtpinpai.Value = ds.Tables[0].Rows[0]["VehicleBrand"].ToString();
                    txtchexing.Value = ds.Tables[0].Rows[0]["VehicleModel"].ToString();
                    txtfadongji.Value = ds.Tables[0].Rows[0]["EngineNumber"].ToString();
                    txtguding.Value = ds.Tables[0].Rows[0]["FixTelephone"].ToString();
                    txtshouj.Value = ds.Tables[0].Rows[0]["PhoneNum"].ToString();
                    txtshenfenz.Value = ds.Tables[0].Rows[0]["IDcard"].ToString();
                    txtdengj.Value = ds.Tables[0].Rows[0]["RegistrationTime"].ToString();
                    txtjiaoqiang.Value = ds.Tables[0].Rows[0]["JiaoQiangTine"].ToString();
                    txtshangyexian.Value = ds.Tables[0].Rows[0]["InsuranceTime"].ToString();
                    drtb.Value = ds.Tables[0].Rows[0]["InsuranceCompany"].ToString();
                    txtzuowei.Value = ds.Tables[0].Rows[0]["setNumber"].ToString();
                    txtkhlx.Value = ds.Tables[0].Rows[0]["CustomerType"].ToString();
                    txtlxdz.Value = ds.Tables[0].Rows[0]["Address"].ToString();
                    txtbz.Value = ds.Tables[0].Rows[0]["Addition"].ToString();
                    txtdaoqi.Value = ds.Tables[0].Rows[0]["Expiration"].ToString();
                }

            }
            
        }
        protected void ContentInitial(SqlDataReader rd, List<string> initialData)
        {
            if (rd.FieldCount <= 0)
                return;
            for (int i = 0; i < rd.FieldCount; i++)
            {
                initialData.Add(Convert.ToString(rd[i]));

            }
        }

        protected void InitialCheckState()
        {
            jdcsubx.Checked = false;
            cbdsz.Checked = false;
            ckqcdq.Checked = false;
            cksj.Checked = false;
            ckck.Checked = false;

            cbdsz.Checked = false;
            cbsz.Checked = false;
            cbches.Checked = false;
            cbcheshuahe.Checked = false;
            cbhh2.Checked = false;
            cbzr2.Checked = false;
            cbcsun.Checked = false;
            ckzr.Checked = false;
            ckhh.Checked = false;
            ckboli.Checked = false;
            ckfdj.Checked = false;
            ckfdj2.Checked = false;
            if (txtjdc.Value != "0.00" && txtjdc.Value != "")
            {
                jdcsubx.Checked = true;
            }

            if (txtds.Value != "0.00" && txtds.Value != "")
            {
                cbdsz.Checked = true;
            }

            if (txtdx.Value != "0" && txtdx.Value != "0.00" && txtdx.Value != "")
            {
                ckqcdq.Checked = true;
            }
            if (txtsj.Value != "0.00" && txtsj.Value != "")
            {
                cksj.Checked = true;
            }
            if (txtck.Value != "0.00" && txtck.Value != "")
            {
                ckck.Checked = true;
            }


            if (txtcs.Value != "0.00" && txtcs.Value != "")
                cbcsun.Checked = true;
            if (txtds2.Value != "0.00" && txtds2.Value != "")
                cbsz.Checked = true;
            if (txtdx2.Value != "0.00" && txtdx2.Value != "")
            {
                cbches.Checked = true;
            }
            if (txtcsry.Value != "0.00" && txtcsry.Value != "")
            {
                cbcheshuahe.Checked = true;
            }
            if (txthh2.Value != "0.00" && txthh2.Value != "")
            {
                cbhh2.Checked = true;
            }
            if (txtzr2.Value != "0.00"&& txtzr2.Value != "")
            {
                cbzr2.Checked = true;
            }


            if ( txtboli.Value != "0.00"&& txtboli.Value != "")
            {
                ckboli.Checked = true;
            }

            if (txthh.Value != "0.00"&& txthh.Value != "" )
            {
                ckhh.Checked = true;
            }

            if (txtzr.Value != "0.00" && txtzr.Value != "")
            {
                ckzr.Checked = true;
            }

            if (txtfdj.Value != "0.00"&& txtfdj.Value != "")
            {
                ckfdj.Checked = true;
            }
            if (txtfdj2.Value != "0.00"&& txtfdj2.Value != "")
            {
                ckfdj2.Checked = true;
            }
        }

        protected void OnSaveBaseInf(object sender, EventArgs e)
        {
            string customerid = clientid.Value;
            string strsql = "update BaseInfo set PhoneNum='" + txtshouj.Value + "',RegistrationTime='"
                + txtdengj.Value + "',JiaoQiangTine='" + txtjiaoqiang.Value + "',InsuranceTime='"
                + txtshangyexian.Value + "',Expiration='"
                + txtdaoqi.Value + "',InsuranceCompany='" + drtb.Value + "',setNumber='"
                + txtzuowei.Value + "',CustomerType='" + txtkhlx.Value + "',Address='"
                + txtlxdz.Value + "',Addition='" + txtbz.Value + "' where ID=" + customerid;
            DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
            int count = dbmanage.ExecuteSql(strsql);
            Response.Write("<script>alert('保存成功')</script>");
        }
        protected void AppointmentButtonClick(object sender, EventArgs e)
        {
            string customerid = clientid.Value;
            string cmd = "<script>winPW('Appointment.aspx?CustomerID=" + customerid + "','',400,300)</script>";
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "winPW", cmd);

        }

        protected void SuccessButtonClick(object sender, EventArgs e)
        {
            string customerid = clientid.Value;
            string cmd = "<script>winPW('chenggjiemian.aspx?CustomerID=" + customerid + "&txtzje=" + txtzje.Value + "&txtjqx=" + txtjqx.Value + "&txtzhfiyao=" + txtzhfiyao.Value + "&txtzc=" + txtzc.Value + "','',800,600)</script>";
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "winPW", cmd);

        }

        protected void FailButtonClick(object sender, EventArgs e)
        {
            string customerid = clientid.Value;
            string strsql = "update BaseInfo set State='失败' where ID=" + customerid;
            DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
            int num = dbmanage.ExecuteSql(strsql);
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "Showalert", "<script>Showalert()</script>");
            Response.Redirect(Request.Url.ToString());
        }

        protected void InvalidButtonClick(object sender, EventArgs e)
        {
            string customerid = clientid.Value;
            string cmd = "<script>winPW('ADRwuxiao.aspx?CustomerID=" + customerid + "','',400,300)</script>";
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "winPW", cmd);
        }


        protected void SaveDetailInf(object sender, EventArgs e)
        {
            string customerid = clientid.Value;
            string strSQL = "select * from DetailCustomInf where Customerid='" + customerid + "'";
            DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
            DataSet ds = dbmanage.QueryToDs(strSQL);
            if (ds != null)
            {
                int count = ds.Tables[0].Rows.Count;
                List<string> GetPageData = new List<string>();
                WriteDataBackToDatabase(GetPageData);

                if (count == 1)
                {

                    strSQL = "update DetailCustomInf set CarGenType='" +
                        GetPageData[0] + "',SiteNumDun='" +
                                GetPageData[1] + "',CarPrice='" +
                               GetPageData[2] + "',DamangeInsuranceCheck='" +
                                GetPageData[3] + "',DamangeInsurance='" +
                                GetPageData[4] + "',ThreePersonCheck='" +
                                GetPageData[5] + "',ThreePerson='" +
                                GetPageData[6] + "',Robberycheck='" +
                                GetPageData[7] + "',Robbery='" +
                                GetPageData[8] + "',PassengerInCarcheck='" +
                                GetPageData[9] + "',PassengerInCar='" +
                                GetPageData[10] + "',ScratchInCarcheck='" +
                                GetPageData[11] + "',ScratchInCar='" +
                                GetPageData[12] + "',Selfignitecheck='" +
                                GetPageData[13] + "',Selfignite='" +
                                GetPageData[14] + "',Motorvehicleinsurancecheck='" +
                                GetPageData[15] + "',MotorvehicleinsuranceSelect='" +
                                GetPageData[16] + "',Motorvehicleinsurance='" +
                                GetPageData[17] + "',Thirdpartyinsurancecheck='" +
                                GetPageData[18] + "',ThirdpartyinsuranceSelect='" +
                                GetPageData[19] + "',Thirdpartyinsurance='" +
                                GetPageData[20] + "',AllDaoQianglosscheck='" +
                                GetPageData[21] + "',AllDaoQiangloss='" +
                                GetPageData[22] + "',DriverPersonnelcheck='" +
                                GetPageData[23] + "',DriverPersonnelSelect='" +
                                GetPageData[24] + "',DriverPersonnel='" +
                                GetPageData[25] + "',BusPassengercheck='" +
                                GetPageData[26] + "',BusPassengerSelect='" +
                                GetPageData[27] + "',BusPassenger='" +
                                GetPageData[28] + "',Glassalonebrokencheck='" +
                                GetPageData[29] + "',Glassalonebrokenselect='" +

                                GetPageData[30] + "',Glassalonebroken='" +
                                GetPageData[31] + "',ScratchInCarFeecheck='" +
                                GetPageData[32] + "',ScratchInCarFeeselect='" +
                                GetPageData[33] + "',ScratchInCarFee='" +
                                GetPageData[34] + "',SelfigniteFeecheck='" +
                                GetPageData[35] + "',SelfigniteFee='" +
                                GetPageData[36] + "',VIPDiscount='" +

                                GetPageData[37] + "',CompulsoryInsurance='" +
                                GetPageData[38] + "',TravelTax='" +
                                GetPageData[39] + "',Disscountpremium='" +
                                GetPageData[40] + "',TotalMoney='" +
                                GetPageData[41] + "',EngineSpecial='" +
                                GetPageData[42] + "',EngineSpecialFree='" +
                                GetPageData[43] + "'" + " where Customerid='" + customerid + "'";

                }
                else
                {
                    string ValueInsert = "";
                    for (int i = 0; i < 43; i++)
                    {
                        ValueInsert += "'" + GetPageData[i] + "',";
                    }
                    ValueInsert += "'" + GetPageData[43] + "')";
                    strSQL = "insert into DetailCustomInf (Customerid,CustomeName,CarGenType,SiteNumDun,CarPrice,DamangeInsuranceCheck,DamangeInsurance,ThreePersonCheck,ThreePerson,Robberycheck,Robbery,PassengerInCarcheck,PassengerInCar,ScratchInCarcheck,ScratchInCar,Selfignitecheck" +
                ",Selfignite,Motorvehicleinsurancecheck,MotorvehicleinsuranceSelect,Motorvehicleinsurance,Thirdpartyinsurancecheck,ThirdpartyinsuranceSelect,Thirdpartyinsurance,AllDaoQianglosscheck,AllDaoQiangloss,DriverPersonnelcheck,DriverPersonnelSelect,DriverPersonnel,BusPassengercheck" +
                ",BusPassengerSelect,BusPassenger,Glassalonebrokencheck,Glassalonebrokenselect,Glassalonebroken,ScratchInCarFeecheck,ScratchInCarFeeselect,ScratchInCarFee,SelfigniteFeecheck,SelfigniteFee,VIPDiscount,CompulsoryInsurance,TravelTax,Disscountpremium,TotalMoney,EngineSpecial,EngineSpecialFree) values('" + customerid + "','" + txtkh.Value + "'," + ValueInsert;
                }
                int releate = dbmanage.ExecuteSql(strSQL);
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "Showalert", "<script>Showalert()</script>");

            }
        }

        protected void InitialAppointmentTimeTableCount(List<int> count)
        {
            //int[,] countInfo = new int[7,6];

            string[] TimeSpan ={ "8:00:00","10:00:00","12:00:00","15:00:00","17:00:00","19:00:00"};
            string SearchStr = null;
            string TheDay = DateTime.Now.DayOfWeek.ToString();
            int indexArray = 0;

            if (TheDay.ToLower() == "monday" || TheDay == "星期一")
            {
                indexArray = 0;
            }
            else if (TheDay.ToLower() == "tuesday" || TheDay == "星期二")
            {
                indexArray = 1;
            }
            else if (TheDay.ToLower() == "wednesday" || TheDay == "星期三")
            {
                indexArray = 2;
            }
            else if (TheDay.ToLower() == "thursday" || TheDay == "星期四")
            {
                indexArray = 3;
            }
            else if (TheDay.ToLower() == "friday" || TheDay == "星期五")
            {
                indexArray = 4;
            }

            else if (TheDay.ToLower() == "saturday" || TheDay == "星期六")
            {
                indexArray = 5;
            }
            else if (TheDay.ToLower() == "sunday" || TheDay == "星期日")
            {
                indexArray = 6;
            }
            else
            {
                indexArray = 0;

            }

            string username = null;
            if (Session["UserName"] != null)
            {
                username = Session["UserName"].ToString();
            }
            else
            {
                username = "test";
                //or return
            }

            for (int day = 0; day < 9;day++ )
            {
                string nowDay = DateTime.Now.AddDays(-indexArray + day).ToString("yyyy/MM/dd");
                for (int i = 0; i < TimeSpan.Count() - 1; i++)
                {
                    string beginTime = nowDay + " " + TimeSpan[i];
                    string endTime = nowDay + " " + TimeSpan[i + 1];
                    SearchStr = "select * from BaseInfo where OwnedService = '" + username + "' ";
                    SearchStr += "and [State]='预约' and Appointment between '" + beginTime + "' and '" + endTime + "'";
                    DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
                    DataSet ds = dbmanage.QueryToDs(SearchStr);
                    if (ds != null)
                    {
                        int seacount = ds.Tables[0].Rows.Count;
                        //DataBase SearchData = new DataBase();
                        //string pathDataBase = Server.MapPath("//DataBase//CustomerBaseInfo.accdb");

                        //OleDbDataAdapter rd = SearchData.bindData(SearchStr, pathDataBase);
                        //DataSet ds = new DataSet();
                        // int counttest = rd.Fill(ds,"BaseInfo");
                        count.Add(seacount);
                    }
                }
            }
        }

        protected void InitialAppoint(List<string> appointment)
        {
            string username = null;
            if (Session["UserName"] != null)
            {
                username = Session["UserName"].ToString();
            }
            else
            {
                username = "test";
                //or return
            }
            string nowTime = System.DateTime.Now.ToString("yyyy-MM-dd ")+ "00:00:00";
            string endtime = System.DateTime.Now.ToString("yyyy-MM-dd ")+"23:59:59";
            //string strtj = "(Appointment between #" + nowTime + "# and #" + endtime + "#) or State='未处理') order by (case when Appointment is null then 0 end) ";
            //string SearchStr = "select * from BaseInfo where OwnedService = '" + username + "' and (State = '预约' and "+strtj;


            string strtj = "Appointment < '" + endtime + "') order by Appointment";
            string SearchStr = "select * from BaseInfo where OwnedService = '" + username + "' and (State = '预约' and "+strtj;
            DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
            DataSet ds = dbmanage.QueryToDs(SearchStr);
            //int seacount = ds.Tables[0].Rows.Count;


            //DataBase SearchData = new DataBase();
            //string pathDataBase = Server.MapPath("..//DataBase//CustomerBaseInfo.accdb");
            //OleDbDataAdapter rd = SearchData.bindData(SearchStr, pathDataBase);
            //DataSet ds = new DataSet();
            //int count = rd.Fill(ds, "BaseInfo");
            SearchStr = "select * from BaseInfo where OwnedService = '" + username+"' and State='未处理'";
            //rd = SearchData.bindData(SearchStr, pathDataBase);

            int count = 0;
            DataSet ds1 = dbmanage.QueryToDs(SearchStr);
            ds.Merge(ds1, true, MissingSchemaAction.AddWithKey);
            griduser.DataSource = ds.Tables[0];
            griduser.DataBind();
            count = ds.Tables[0].Rows.Count;
            if (count >= 1)
            {
                DataRow ReadRow = ds.Tables[0].Rows[0];
                InitializeBaseInf(ReadRow["ID"].ToString());
                InitialPage(ReadRow["ID"].ToString());
            }

        }

        protected void GridView1_Command(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("SelectCustomer"))
            {
                string id = e.CommandArgument.ToString();
                InitializeBaseInf(id);
                InitialPage(id);
            }
        }

        protected void CountAppointmentData()
        {



        }
    }
}
