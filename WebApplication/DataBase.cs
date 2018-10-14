using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;
using Dyne.Dal;
namespace WebApplication
{
    public class DataBase
    {
        //abstract some behavoir
        //keep the system reusable

        public bool HandleDatabase(string cmd, string databasePath)
        {
            DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");

          //  cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + databasePath);
            try
            {
                //cn.Open();
                //OleDbCommand myCmd = new OleDbCommand(cmd, cn);
                //myCmd.ExecuteNonQuery();
                //cn.Close();
                dbmanage.ExecuteSql(cmd);
                return true;
            }
            catch (Exception openerror)
            {
                return false;
            }

        }
        public OleDbDataReader SearchIterm(string cmd, string databasePath)
        {
            //access "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
            //"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" (open .accdb database)
            //OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + databasePath);
            DbHelp dbmanage = new DbHelp(EnumDbType.DbSqlServer, "server=NOLAN-DEBUG-PC\\SQLEXPRESS1;database=test;Trusted_Connection=SSPI;");

            try
            {
                //cn.Open();
                //OleDbCommand myCmd = new OleDbCommand(cmd, cn);
                //OleDbDataAdapter oda = new OleDbDataAdapter(myCmd);
                OleDbDataReader adr = (OleDbDataReader)dbmanage.ExecuteReader(cmd);
                return adr;
            }
            catch (Exception openerror)
            {
                return null;
            }
        }
        public bool CloseConnect()
        {
            try
            {
                cn.Close();
                return true;
            }
            catch (Exception closeError)
            {
                return false;
            }
        }
        public OleDbDataAdapter bindData(string cmd, string databasePath)
        {
            cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + databasePath);
            try
            {
                cn.Open();
                OleDbCommand myCmd = new OleDbCommand(cmd, cn);
                OleDbDataAdapter oda = new OleDbDataAdapter(myCmd);
                cn.Close();
                return oda;
            }
            catch (Exception openerror)
            {
                return null;
            }

        }
        private OleDbConnection cn;
    }

}
