using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Dyne.Dal;
namespace WebApplication.MenuManage
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<int> countInfo = new List<int>();
                txthuiyuan.Value = Convert.ToString(70);
                string customerid = Request.QueryString["CustomerID"];
                string StrOnlyread = Request.QueryString["Onlyview"];
                if (customerid == null)
                {
                    //default
                    //InitialPage("test");
                }
                else
                {
                    InitialPage(customerid, StrOnlyread);
                }
            }


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


        protected bool InitialPage(string customerid, string strread)
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
                        if (reader.Read())
                        {
                            if (reader.FieldCount > 0)
                            {
                                List<string> InitialData = new List<string>();
                                ContentInitial(reader, InitialData);
                                InitialDetaiInfoTable(InitialData);

                            }
                        }
                        else
                        {


                        }
                    }
                    catch (SqlException exp)
                    {
                        connection.Dispose();
                        throw new Exception(exp.Message);
                    }
                }
            }

            if(strread=="true")
            {
                btnsave.Visible = false;
                Button1.Visible = false;
                ButtonSuccess.Visible = false;
                ButtonAppointment.Visible = false;
                ButtonFaild.Visible = false;
                ButtonInvalid.Visible = false;

            }
            
          //  cn.Close();
            return true;
        }

        protected void InitializeBaseInf(string strcustomerid)
        {
            string strsql = "select * from BaseInfo where ID=" + strcustomerid;
            DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
            DataSet ds = dbmanage.QueryToDs(strsql);
            int count = ds.Tables[0].Rows.Count;
            if (count == 1)
            {
                txtkh.Value = ds.Tables[0].Rows[0]["ClientName"].ToString();
                txtchepai.Value = ds.Tables[0].Rows[0]["CarNumber"].ToString();
                txtcpp.Value = txtchepai.Value;
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
            if (txtzr2.Value != "0.00" && txtzr2.Value != "")
            {
                cbzr2.Checked = true;
            }


            if (txtboli.Value != "0.00" && txtboli.Value != "")
            {
                ckboli.Checked = true;
            }

            if (txthh.Value != "0.00" && txthh.Value != "")
            {
                ckhh.Checked = true;
            }

            if (txtzr.Value != "0.00" && txtzr.Value != "")
            {
                ckzr.Checked = true;
            }

            if (txtfdj.Value != "0.00" && txtfdj.Value != "")
            {
                ckfdj.Checked = true;
            }
            if (txtfdj2.Value != "0.00" && txtfdj2.Value != "")
            {
                ckfdj2.Checked = true;
            }
        }

        protected void OnSaveBaseInf(object sender, EventArgs e)
        {
            string customerid = Request.QueryString["CustomerID"];
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
            string customerid = Request.QueryString["CustomerID"];
            string cmd = "<script>winPW('Appointment.aspx?CustomerID=" + customerid + "','',400,300)</script>";
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "winPW", cmd);

        }

        protected void SuccessButtonClick(object sender, EventArgs e)
        {
            string customerid = Request.QueryString["CustomerID"];
            string cmd = "<script>winPW('chenggjiemian.aspx?CustomerID=" + customerid + "&txtzje=" + txtzje.Value + "&txtjqx=" + txtjqx.Value + "&txtzhfiyao=" + txtzhfiyao.Value + "&txtzc=" + txtzc.Value + "','',800,600)</script>";
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "winPW", cmd);

        }

        protected void FailButtonClick(object sender, EventArgs e)
        {
                string customerid = Request.QueryString["CustomerID"];
                string strsql = "update BaseInfo set State='失败' where ID=" + customerid;
                DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
                int num = dbmanage.ExecuteSql(strsql);
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "Showalert", "<script>Showalert()</script>");
        }
        protected void InvalidButtonClick(object sender, EventArgs e)
        {

            string customerid = Request.QueryString["CustomerID"];
            string cmd = "<script>winPW('ADRwuxiao.aspx?CustomerID=" + customerid + "','',400,300)</script>";
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "winPW", cmd);
        }


        protected void SaveDetailInf(object sender, EventArgs e)
        {
            string customerid = Request.QueryString["CustomerID"];
            string strSQL = "select * from DetailCustomInf where Customerid='" + customerid + "'";
            DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
            DataSet ds = dbmanage.QueryToDs(strSQL);
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
}
