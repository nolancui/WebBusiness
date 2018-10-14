using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dyne.Dal;
using System.Data.OleDb;
using System.Data;
namespace WebApplication.BaseShearch
{
    public partial class Webprint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String[] Customeridstr = Request.QueryString["CustomerID"].Split(',');
            int elementcount = Customeridstr.Length;
            string []strinputArray= new string[17];
            for (int i = 0; i < elementcount; i++)
            {
                for (int j = 0; j < 17; j++)
                    strinputArray[j] = "";
                string customerid = Customeridstr[i];
                string strsql = "select * from BaseInfo where ID=" + customerid;
                DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");
                DataSet ds = dbmanage.QueryToDs(strsql);
                
                int count = ds.Tables[0].Rows.Count;
                if (count == 1)
                {

                  
                   
                    strinputArray[3] = ds.Tables[0].Rows[0]["ClientName"].ToString();
                    strinputArray[1] = ds.Tables[0].Rows[0]["CarNumber"].ToString();

                    strinputArray[4] = ds.Tables[0].Rows[0]["PhoneNum"].ToString();

                    strinputArray[0] = ds.Tables[0].Rows[0]["InsuranceTime"].ToString();
                    strinputArray[2] = ds.Tables[0].Rows[0]["InsuranceCompany"].ToString();
                    strinputArray[6] = ds.Tables[0].Rows[0]["Gift"].ToString();
                    strinputArray[10] = ds.Tables[0].Rows[0]["ServiceTime"].ToString();
                    strinputArray[11] = ds.Tables[0].Rows[0]["Address"].ToString();

                    string userid = ds.Tables[0].Rows[0]["UserID"].ToString();
                    dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;"); 
                    strsql = "select * from DetailCustomInf where Customerid='" + customerid + "'";
                    DataSet ds2 = dbmanage.QueryToDs(strsql);
                    if (ds2 != null)
                    {
                        count = ds2.Tables[0].Rows.Count;
                        if (count == 1)
                        {
                          

                            strinputArray[7] = ds2.Tables[0].Rows[0]["Disscountpremium"].ToString();
                            strinputArray[8] = ds2.Tables[0].Rows[0]["CompulsoryInsurance"].ToString();
                            strinputArray[5] = ds2.Tables[0].Rows[0]["TotalMoney"].ToString();
                            strinputArray[9] = ds2.Tables[0].Rows[0]["TravelTax"].ToString();
                        }
                    }
                    dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;"); 
                    strsql = "select * from AccountInf where ID=" + userid;
                    DataSet ds1 = dbmanage.QueryToDs(strsql);
                    if (ds1 != null)
                    {
                        int count1 = ds1.Tables[0].Rows.Count;
                        if (count1 == 1)
                        {
                           
                            strinputArray[13] = ds1.Tables[0].Rows[0]["UserName"].ToString();
                            strinputArray[15] = ds1.Tables[0].Rows[0]["PhoneNum"].ToString();
                        }
                    }


                Table testNewTable = new Table();
                testNewTable.HorizontalAlign = HorizontalAlign.Center;
                TableRow firstRow = new TableRow();
                firstRow.BorderWidth = 1;
                TableCell SecurityTime = new TableCell();
                SecurityTime.BorderWidth = 1;
                SecurityTime.Attributes.Add("width", "12.5%");
                SecurityTime.Text = "商业险时间";
                SecurityTime.HorizontalAlign = HorizontalAlign.Center;
                firstRow.Cells.Add(SecurityTime);
                TableCell inputcontent = new TableCell();
                inputcontent.BorderWidth = 1;
                inputcontent.ColumnSpan = 3;
                inputcontent.Attributes.Add("width", "37.5%");
                inputcontent.Text = strinputArray[0];
                inputcontent.HorizontalAlign = HorizontalAlign.Center;

                firstRow.Cells.Add(inputcontent);
                TableCell Company = new TableCell();
                Company.BorderWidth = 1;
                Company.Attributes.Add("width", "12.5%");
                Company.Text = "保险公司";
                Company.HorizontalAlign = HorizontalAlign.Center;

                firstRow.Cells.Add(Company);
                TableCell inputCompany = new TableCell();
                inputCompany.BorderWidth = 1;
                inputCompany.ColumnSpan = 3;
                inputCompany.Attributes.Add("width", "37.5%");
                inputCompany.Text = strinputArray[2];
                inputCompany.HorizontalAlign = HorizontalAlign.Center;

                firstRow.Cells.Add(inputCompany);
                testNewTable.Rows.Add(firstRow);

                TableRow secondRow = new TableRow();
                secondRow.BorderWidth = 1;
                TableCell carnum = new TableCell();
                carnum.BorderWidth = 1;
                carnum.Attributes.Add("width", "12.5%");
                carnum.Text = "车牌号码";
                carnum.HorizontalAlign = HorizontalAlign.Center;

                secondRow.Cells.Add(carnum);
                TableCell inputcarnum = new TableCell();
                inputcarnum.BorderWidth = 1;
                inputcarnum.ColumnSpan = 3;
                inputcarnum.Attributes.Add("width", "37.5%");
                inputcarnum.Text = strinputArray[1];
                inputcarnum.HorizontalAlign = HorizontalAlign.Center;

                secondRow.Cells.Add(inputcarnum);
                TableCell owner = new TableCell();
                owner.BorderWidth = 1;
                owner.Attributes.Add("width", "12.5%");
                owner.Text = "被保险人";
                owner.HorizontalAlign = HorizontalAlign.Center;

                secondRow.Cells.Add(owner);
                TableCell inputowner = new TableCell();
                inputowner.BorderWidth = 1;
                inputowner.ColumnSpan = 3;
                inputowner.Attributes.Add("width", "37.5%");
                inputowner.Text = strinputArray[3];
                inputowner.HorizontalAlign = HorizontalAlign.Center;

                secondRow.Cells.Add(inputowner);
                testNewTable.Rows.Add(secondRow);

                TableRow thirdRow = new TableRow();
                thirdRow.BorderWidth = 1;
                TableCell Disscountpremium = new TableCell();
                Disscountpremium.BorderWidth = 1;
                Disscountpremium.Attributes.Add("width", "12.5%");
                Disscountpremium.Text = "商业险金额";
                Disscountpremium.HorizontalAlign = HorizontalAlign.Center;

                thirdRow.Cells.Add(Disscountpremium);
                TableCell inputDisscountpremium = new TableCell();
                inputDisscountpremium.BorderWidth = 1;
                inputDisscountpremium.ColumnSpan = 3;
                inputDisscountpremium.Attributes.Add("width", "37.5%");
                inputDisscountpremium.Text = strinputArray[7];

                inputDisscountpremium.HorizontalAlign = HorizontalAlign.Center;

                thirdRow.Cells.Add(inputDisscountpremium);
                TableCell PhoneNum = new TableCell();
                PhoneNum.BorderWidth = 1;
                PhoneNum.Attributes.Add("width", "12.5%");
                PhoneNum.Text = "联系电话";
                PhoneNum.HorizontalAlign = HorizontalAlign.Center;

                thirdRow.Cells.Add(PhoneNum);
                TableCell inputPhoneNum = new TableCell();
                inputPhoneNum.BorderWidth = 1;
                inputPhoneNum.ColumnSpan = 3;
                inputPhoneNum.Attributes.Add("width", "37.5%");
                inputPhoneNum.Text = strinputArray[4];
                inputPhoneNum.HorizontalAlign = HorizontalAlign.Center;

                thirdRow.Cells.Add(inputPhoneNum);
                testNewTable.Rows.Add(thirdRow);

                TableRow fourthRow = new TableRow();
                fourthRow.BorderWidth = 1;
                TableCell CompulsoryInsurance = new TableCell();
                CompulsoryInsurance.BorderWidth = 1;
                CompulsoryInsurance.Attributes.Add("width", "12.5%");
                CompulsoryInsurance.Text = "交强险金额";
                CompulsoryInsurance.HorizontalAlign = HorizontalAlign.Center;

                fourthRow.Cells.Add(CompulsoryInsurance);
                TableCell inputCompulsoryInsurance = new TableCell();
                inputCompulsoryInsurance.BorderWidth = 1;
                inputCompulsoryInsurance.ColumnSpan = 3;
                inputCompulsoryInsurance.Attributes.Add("width", "37.5%");
                inputCompulsoryInsurance.Text = strinputArray[8];
                inputCompulsoryInsurance.HorizontalAlign = HorizontalAlign.Center;

                fourthRow.Cells.Add(inputCompulsoryInsurance);
                TableCell TotalMoney = new TableCell();
                TotalMoney.BorderWidth = 1;
                TotalMoney.Attributes.Add("width", "12.5%");
                TotalMoney.Text = "实收金额";
                TotalMoney.HorizontalAlign = HorizontalAlign.Center;

                fourthRow.Cells.Add(TotalMoney);
                TableCell inputTotalMoney = new TableCell();
                inputTotalMoney.BorderWidth = 1;
                inputTotalMoney.ColumnSpan = 3;
                inputTotalMoney.Attributes.Add("width", "37.5%");
                inputTotalMoney.Text = strinputArray[5];
                inputTotalMoney.HorizontalAlign = HorizontalAlign.Center;

                fourthRow.Cells.Add(inputTotalMoney);
                testNewTable.Rows.Add(fourthRow);

                TableRow fifthRow = new TableRow();
                fifthRow.BorderWidth = 1;
                TableCell TravelTax = new TableCell();
                TravelTax.BorderWidth = 1;
                TravelTax.Attributes.Add("width", "12.5%");
                TravelTax.Text = "车船税";
                TravelTax.HorizontalAlign = HorizontalAlign.Center;

                fifthRow.Cells.Add(TravelTax);
                TableCell inputTravelTax = new TableCell();
                inputTravelTax.BorderWidth = 1;
                inputTravelTax.ColumnSpan = 3;
                inputTravelTax.Attributes.Add("width", "37.5%");
                inputTravelTax.Text = strinputArray[9];
                inputTravelTax.HorizontalAlign = HorizontalAlign.Center;

                fifthRow.Cells.Add(inputTravelTax);
                TableCell Gift = new TableCell();
                Gift.BorderWidth = 1;
                Gift.Attributes.Add("width", "12.5%");
                Gift.Text = "礼品";
                Gift.HorizontalAlign = HorizontalAlign.Center;

                Gift.RowSpan = 2;
                fifthRow.Cells.Add(Gift);
                TableCell inputGift = new TableCell();
                inputGift.BorderWidth = 1;
                inputGift.ColumnSpan = 3;
                inputGift.RowSpan = 2;
                inputGift.Attributes.Add("width", "37.5%");

                inputGift.Text = strinputArray[6];
                inputGift.HorizontalAlign = HorizontalAlign.Center;

                fifthRow.Cells.Add(inputGift);
                testNewTable.Rows.Add(fifthRow);

                TableRow sixthRow = new TableRow();
                TableCell servicetime = new TableCell();
                servicetime.BorderWidth = 1;
                servicetime.Attributes.Add("width", "12.5%");
                servicetime.Text = "服务时间";
                servicetime.HorizontalAlign = HorizontalAlign.Center;

                sixthRow.Cells.Add(servicetime);
                TableCell inputservicetime = new TableCell();
                inputservicetime.BorderWidth = 1;
                inputservicetime.ColumnSpan = 3;
                inputservicetime.Attributes.Add("width", "37.5%");
                inputservicetime.HorizontalAlign = HorizontalAlign.Center;

                inputservicetime.Text = strinputArray[10];
                sixthRow.Cells.Add(inputservicetime);
                testNewTable.Rows.Add(sixthRow);

                TableRow seventhRow = new TableRow();
                TableCell Address = new TableCell();
                Address.BorderWidth = 1;
                Address.Attributes.Add("width", "12.5%");
                Address.Text = "服务地址";
                Address.HorizontalAlign = HorizontalAlign.Center;

                seventhRow.Cells.Add(Address);
                TableCell inputAddress = new TableCell();
                inputAddress.BorderWidth = 1;
                inputAddress.ColumnSpan = 8;
                inputAddress.Attributes.Add("width", "37.5%");
                inputAddress.Text = strinputArray[11];
                inputAddress.HorizontalAlign = HorizontalAlign.Center;

                seventhRow.Cells.Add(inputAddress);
                testNewTable.Rows.Add(seventhRow);

                TableRow eightthRow = new TableRow();
                TableCell UserName = new TableCell();
                UserName.BorderWidth = 1;
                UserName.Attributes.Add("width", "12.5%");
                UserName.Text = "业务员";
                UserName.HorizontalAlign = HorizontalAlign.Center;

                eightthRow.Cells.Add(UserName);
                TableCell inputUserName = new TableCell();
                inputUserName.BorderWidth = 1;
                inputUserName.ColumnSpan = 3;
                inputUserName.Attributes.Add("width", "37.5%");
                inputUserName.HorizontalAlign = HorizontalAlign.Center;

                inputUserName.Text = strinputArray[13];
                eightthRow.Cells.Add(inputUserName);

                TableCell ServicePeople = new TableCell();
                ServicePeople.BorderWidth = 1;
                ServicePeople.Attributes.Add("width", "12.5%");
                ServicePeople.Text = "服务人员";
                ServicePeople.HorizontalAlign = HorizontalAlign.Center;

                eightthRow.Cells.Add(ServicePeople);
                TableCell inputServicePeople = new TableCell();
                inputServicePeople.BorderWidth = 1;
                inputServicePeople.ColumnSpan = 1;
                inputServicePeople.Attributes.Add("width", "12.5%");
                inputServicePeople.HorizontalAlign = HorizontalAlign.Center;

                inputServicePeople.Text = strinputArray[12];
                eightthRow.Cells.Add(inputServicePeople);


                TableCell Confirmsignatures = new TableCell();
                Confirmsignatures.BorderWidth = 1;
                Confirmsignatures.Attributes.Add("width", "12.5%");
                Confirmsignatures.Text = "客户签字";
                Confirmsignatures.HorizontalAlign = HorizontalAlign.Center;

                Confirmsignatures.RowSpan = 2;
                eightthRow.Cells.Add(Confirmsignatures);
                TableCell inputConfirmsignatures = new TableCell();
                inputConfirmsignatures.BorderWidth = 1;
                inputConfirmsignatures.RowSpan = 2;
                inputConfirmsignatures.Attributes.Add("width", "37.5%");
                inputConfirmsignatures.HorizontalAlign = HorizontalAlign.Center;

                eightthRow.Cells.Add(inputConfirmsignatures);
                testNewTable.Rows.Add(eightthRow);

                TableRow ninethRow = new TableRow();
                TableCell phonenum = new TableCell();
                phonenum.BorderWidth = 1;
                phonenum.Attributes.Add("width", "12.5%");
                phonenum.Text = "业务电话";
                phonenum.HorizontalAlign = HorizontalAlign.Center;

                ninethRow.Cells.Add(phonenum);
                TableCell inputphonenum = new TableCell();
                inputphonenum.BorderWidth = 1;
                inputphonenum.ColumnSpan = 3;
                inputphonenum.Attributes.Add("width", "37.5%");
                inputphonenum.HorizontalAlign = HorizontalAlign.Center;

                inputphonenum.Text = strinputArray[15];
                ninethRow.Cells.Add(inputphonenum);

                TableCell Validation = new TableCell();
                Validation.BorderWidth = 1;
                Validation.Attributes.Add("width", "12.5%");
                Validation.Text = "财务确定";
                Validation.HorizontalAlign = HorizontalAlign.Center;

                ninethRow.Cells.Add(Validation);
                TableCell inputValidation = new TableCell();
                inputValidation.BorderWidth = 1;
                inputValidation.ColumnSpan = 1;
                inputValidation.HorizontalAlign = HorizontalAlign.Center;

                inputValidation.Attributes.Add("width", "12.5%");
                inputValidation.Text = strinputArray[16];
                ninethRow.Cells.Add(inputValidation);

                testNewTable.Rows.Add(ninethRow);


                HyperLink linkFile = new HyperLink();
                linkFile.Text = "<br /> <br />";
                div_print.Controls.Add(linkFile);
                div_print.Controls.Add(testNewTable);
                }
            }
             //testtable();
           //  GennerateExample();

        }

        protected void testtable()
        {
            Table tb = new Table();
            tb.BorderWidth = 1;

            int row = 3;    // 行数
            int col = 4;    // 列数
            for (int i = 0; i < row; i++)
            {
                TableRow tr = new TableRow();
                tr.BorderWidth = 1;
                tb.Rows.Add(tr);

                for (int j = 0; j < col; j++)
                {
                    TableCell td = new TableCell();
                    td.BorderWidth = 1;
                    tr.Cells.Add(td);
                    td.Text = i.ToString();
                }
            }
            Page.Controls.Add(tb);
        }


        protected void GennerateExample()
        {
            Table testNewTable = new Table();

            TableRow firstRow = new TableRow();
            firstRow.BorderWidth = 1;

            TableCell SecurityTime = new TableCell();
            SecurityTime.BorderWidth = 1;
            SecurityTime.Attributes.Add("width", "12.5%");
            SecurityTime.Text = "商业时间";
            firstRow.Cells.Add(SecurityTime);


            TableCell inputcontent = new TableCell();
            inputcontent.BorderWidth = 1;
            inputcontent.ColumnSpan = 3;
            inputcontent.Attributes.Add("width", "37.5%");
            inputcontent.Text = "2014.01.01";
            firstRow.Cells.Add(inputcontent);

            TableCell Company = new TableCell();
            Company.BorderWidth = 1;
            Company.Attributes.Add("width", "12.5%");
            Company.Text = "保险公司";
            firstRow.Cells.Add(Company);


            TableCell inputCompany = new TableCell();
            inputCompany.BorderWidth = 1;
            inputCompany.ColumnSpan = 3;
            inputCompany.Attributes.Add("width", "37.5%");
            inputCompany.Text = "太平洋保险";
            firstRow.Cells.Add(inputCompany);

            testNewTable.Rows.Add(firstRow);

            TableRow secondRow = new TableRow();
            secondRow.BorderWidth = 1;

            TableCell CarId = new TableCell();
            CarId.Text = "车牌号码";
            CarId.BorderWidth = 1;
            secondRow.Cells.Add(CarId);

            TableCell InputCarId = new TableCell();
            InputCarId.ColumnSpan = 3;
            InputCarId.BorderWidth = 1;
            InputCarId.Text = "1111111";

            secondRow.Cells.Add(InputCarId);

            TableCell InsurcedPerson = new TableCell();
            InsurcedPerson.Text = "被保险人";
            InsurcedPerson.BorderWidth = 1;
            secondRow.Cells.Add(InsurcedPerson);

            TableCell InputInsuredPerson = new TableCell();
            InputInsuredPerson.ColumnSpan = 3;
            InputInsuredPerson.BorderWidth = 1;
            InputInsuredPerson.Text = "testtest";
            secondRow.Cells.Add(InputInsuredPerson);

            testNewTable.Rows.Add(secondRow);

            TableRow thirdrow = new TableRow();
            thirdrow.BorderWidth = 1;

            TableCell Mount = new TableCell();
            Mount.Text = "商业险金额";
            Mount.BorderWidth = 1;
            thirdrow.Cells.Add(Mount);

            TableCell InputMount = new TableCell();
            InputMount.ColumnSpan = 3;
            InputMount.BorderWidth = 1;
            InputMount.Text = "1111111";

            thirdrow.Cells.Add(InputMount);

            TableCell Phone = new TableCell();
            Phone.Text = "联系电话";
            Phone.BorderWidth = 1;
            thirdrow.Cells.Add(Phone);

            TableCell InputPhone = new TableCell();
            InputPhone.ColumnSpan = 3;
            InputPhone.BorderWidth = 1;
            InputPhone.Text = "testtest";
            thirdrow.Cells.Add(InputPhone);

            testNewTable.Rows.Add(thirdrow);


            TableRow Fourthrow = new TableRow();
            Fourthrow.BorderWidth = 1;

            TableCell Mountt = new TableCell();
            Mountt.Text = "商业险金额";
            Mountt.BorderWidth = 1;
            Fourthrow.Cells.Add(Mountt);

            TableCell InputMountt = new TableCell();
            InputMountt.ColumnSpan = 3;
            InputMountt.BorderWidth = 1;
            InputMountt.Text = "1111111";

            Fourthrow.Cells.Add(InputMountt);

            TableCell Phonet = new TableCell();
            Phonet.Text = "联系电话";
            Phonet.BorderWidth = 1;
            Fourthrow.Cells.Add(Phonet);

            TableCell InputPhonet = new TableCell();
            InputPhonet.ColumnSpan = 3;
            InputPhonet.BorderWidth = 1;
            InputPhonet.Text = "testtest";
            Fourthrow.Cells.Add(InputPhonet);

            testNewTable.Rows.Add(Fourthrow);

            //div_print.InnerHtml += testNewTable;
            div_print.Controls.Add(testNewTable);
            // Page.Controls.Add(testNewTable);




            //            <table id="tbprint">

            //<tr>
            //<td width="12.5%">商业险时间</td><td colspan="3" width="37.5%"><span id="shangyebaoxian" runat="server"></span></td><td width="12.5%">保险公司</td><td colspan="3" width="37.5%"><span id="Span2" runat="server"></span></td>
            //</tr>
            //<tr>
            //<td>车牌号码</td><td colspan="3"><span id="Span1" runat="server"></span></td><td>被保险人</td><td colspan="3"><span id="Span3" runat="server"></span></td>
            //</tr>
            //<tr>
            //<td>商业险金额</td><td colspan="3"><span id="Span7" runat="server"></span></td><td>联系电话</td><td colspan="3"><span id="Span4" runat="server"></span></td>
            //</tr>
            //<tr>
            //<td>交强险金额</td><td colspan="3"><span id="Span8" runat="server"></span></td><td>实收金额</td><td colspan="3"><span id="Span5" runat="server"></span></td>
            //</tr>
            //<tr>
            //<td>车船税</td><td colspan="3"><span id="Span9" runat="server"></span></td><td rowspan="2">礼品</td><td colspan="3" rowspan="2"><span id="Span6" runat="server"></span></td>
            //</tr>
            //<tr>
            //<td>服务时间</td><td colspan="3"><span id="Span10" runat="server"></span></td>
            //</tr>
            //<tr>
            //<td>服务地址</td><td colspan="7" style="word-wrap:break-word;"><span id="Span11" runat="server"></span></td>
            //</tr>
            //<tr>
            //<td>业务员</td><td colspan="3"><span id="Span13" runat="server"></span></td><td>服务人员</td><td width="12.5%"><span id="Span12" runat="server"></span></td><td rowspan="2" width="12.5%">客户签字</td><td rowspan="2"><span id="Span14" runat="server"></span></td>
            //</tr>
            //<tr>
            //<td>业务电话</td><td colspan="3"><span id="Span15" runat="server"></span></td><td>财务确定</td><td width="12.5%"></td>
            //</tr>
            //</table>


        }
    }
}