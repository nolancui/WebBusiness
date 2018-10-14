using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.OleDb;
using System.Data;


namespace Dyne.Dal.OleDb
{
    /// <summary>
    /// Copyright (C) 2008 HanYanHua
    /// ���ݷ��ʻ�����(����OleDb)
    /// </summary>
    public abstract class DbHelper
    {
        //���ݿ������ַ��� ���Զ�̬����connectionString֧�ֶ����ݿ�.		
        public static string connectionString = PubConstant.ConntionString;

        public DbHelper()
        {

        }

        #region  �ڲ�����

        /// <summary>
        /// �����ݿ�����
        /// </summary>
        /// <param name="p_oleDbConn">���ݿ�����</param>
        private static void  Open(OleDbConnection p_oleDbConn)
        {
            if (p_oleDbConn.State != ConnectionState.Open)
            {
                p_oleDbConn.Open();
            }
        }

        /// <summary>
        /// �ر����ݿ�����
        /// </summary>
        /// <param name="p_oleDbConn"></param>
        private static void Close(OleDbConnection p_oleDbConn)
        {
            if (p_oleDbConn.State == ConnectionState.Open)
            {
                p_oleDbConn.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_oleDbComm"></param>
        /// <param name="p_oleDbConn"></param>
        /// <param name="p_oleDbTrans"></param>
        /// <param name="p_strCmdText"></param>
        /// <param name="p_oleDbCmdParms"></param>
        private static void PrepareCommand(OleDbCommand p_oleDbComm, OleDbConnection p_oleDbConn,
                                           OleDbTransaction p_oleDbTrans, string p_strCmdText,
                                           OleDbParameter[] p_oleDbCmdParms)
        {
            Open(p_oleDbConn);

            p_oleDbComm.Connection = p_oleDbConn;

            p_oleDbComm.CommandText = p_strCmdText;

            if (p_oleDbTrans != null)
            {
                p_oleDbComm.Transaction = p_oleDbTrans;
            }

            p_oleDbComm.CommandType = CommandType.Text;

            if (p_oleDbCmdParms != null)
            {
                foreach (OleDbParameter parm in p_oleDbCmdParms)
                {
                    p_oleDbComm.Parameters.Add(parm);
                }
            }

            Close(p_oleDbConn);
        }

        /// <summary>
        /// ���� OleDbCommand ����(��������һ���������������һ������ֵ)
        /// </summary>
        /// <param name="connection">���ݿ�����</param>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <returns>OleDbCommand</returns>
        private static OleDbCommand BuildQueryCommand(OleDbConnection connection, 
                                                      string storedProcName, IDataParameter[] parameters)
        {
            OleDbCommand command = new OleDbCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (OleDbParameter parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
            return command;
        }

        /// <summary>
        /// ���� OleDbCommand ����ʵ��(��������һ������ֵ)	
        /// </summary>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <returns>OleDbCommand ����ʵ��</returns>
        private static OleDbCommand BuildIntCommand(OleDbConnection p_connection, 
                                                    string p_strStoredProcName, IDataParameter[] p_parameters)
        {
            OleDbCommand command = BuildQueryCommand(p_connection, p_strStoredProcName, p_parameters);
            command.Parameters.Add(new OleDbParameter("ReturnValue",
                OleDbType.Integer, 4, ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }

        #endregion

        #region  ִ�м�SQL���

        /// <summary>
        /// ִ��SQL��䣬����Ӱ��ļ�¼��
        /// </summary>
        /// <param name="p_strSql">SQL���</param>
        /// <returns>Ӱ��ļ�¼��</returns>
        public static int ExecuteSql(string p_strSql)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand(p_strSql, connection))
                {
                    try
                    {
                        Open(connection);
                        return cmd.ExecuteNonQuery();
                    }
                    catch (OleDbException exp)
                    {
                        throw new Exception(exp.Message);
                    }
                    finally
                    {
                        Close(connection);
                    }
                }
            }
        }

        /// <summary>
        /// ִ�ж���SQL��䣬ʵ�����ݿ�����
        /// </summary>
        /// <param name="p_ArrListSqls">����SQL���</param>		
        public static void ExecuteSqlTran(ArrayList p_ArrListSqls)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                Open(conn);
                OleDbCommand cmd     = new OleDbCommand();
                cmd.Connection       = conn;
                OleDbTransaction tra = conn.BeginTransaction();
                cmd.Transaction      = tra;
                try
                {
                    for (int i = 0; i < p_ArrListSqls.Count; i++)
                    {
                        string strSql = p_ArrListSqls[i].ToString();
                        if (strSql.Trim().Length > 1)
                        {
                            cmd.CommandText = strSql;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    tra.Commit();
                }
                catch (OleDbException exp)
                {
                    tra.Rollback();
                    throw new Exception(exp.Message);
                }
                finally
                {
                   Close(conn);
                }
            }
        }
        

        /// <summary>
        /// ִ�д�һ���洢���̲����ĵ�SQL��䣨������Ϊcontent��
        /// </summary>
        /// <param name="p_strSql">SQL���</param>
        /// <param name="p_strContent">��������,����һ���ֶ��Ǹ�ʽ���ӵ����£���������ţ�����ͨ�������ʽ���</param>
        /// <returns>Ӱ��ļ�¼��</returns>
        public static int ExecuteSql(string p_strSql, string p_strContent)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand cmd          = new OleDbCommand(p_strSql, connection);
                OleDbParameter oleDbPara  = new OleDbParameter("@content", OleDbType.VarChar);
                oleDbPara.Value           = p_strContent;
                cmd.Parameters.Add(oleDbPara);
                try
                {
                    Open(connection);
                    return  cmd.ExecuteNonQuery();
                }
                catch (OleDbException E)
                {
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    Close(connection);
                }
            }
        }
       
        /// <summary>
        /// �����ݿ������ͼ���ʽ���ֶΣ�ͼ�������Ϊimage��
        /// </summary>
        /// <param name="p_strSql">SQL���</param>
        /// <param name="p_byteFs">ͼ���ֽ�,���ݿ���ֶ�����Ϊimage�����</param>
        /// <returns>Ӱ��ļ�¼��</returns>
        public static int ExecuteSqlInsertImg(string p_strSql, byte[] p_byteImagee)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand cmd           = new OleDbCommand(p_strSql, connection);
                OleDbParameter myParameter = new OleDbParameter("@image", OleDbType.Binary);
                myParameter.Value          = p_byteImagee;
                cmd.Parameters.Add(myParameter);
                try
                {
                    Open(connection);
                    return cmd.ExecuteNonQuery();
                }
                catch (OleDbException exp)
                {
                    throw new Exception(exp.Message);
                }
                finally
                {
                    cmd.Dispose();
                    Close(connection);
                }
            }
        }

        /// <summary>
        /// ���ؽ�����е�һ�е�һ�У��ջ����򷵻�null����
        /// </summary>
        /// <param name="SQLString">�����ѯ������</param>
        /// <returns>��ѯ�����object��</returns>
        public static object GetSingle(string p_strSql)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand(p_strSql, connection))
                {
                    try
                    {
                        Open(connection);
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (OleDbException exp)
                    {
                        throw new Exception(exp.Message);
                    }
                    finally
                    {
                        Close(connection);
                    }
                }
            }
        }
        
        /// <summary>
        /// ִ�в�ѯ��䣬����OleDbDataReader
        /// </summary>
        /// <param name="strSQL">��ѯ���</param>
        /// <returns>OleDbDataReader</returns>
        public static OleDbDataReader ExecuteReader(string p_strSql)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand(p_strSql, connection))
                {
                    try
                    {
                        Open(connection);
                        return cmd.ExecuteReader();
                    }
                    catch (System.Data.OleDb.OleDbException e)
                    {
                        throw new Exception(e.Message);
                    }
                    finally
                    {
                        Close(connection);
                    }
                }
            }
        }
        
        /// <summary>
        /// ִ�в�ѯ��䣬����DataSet
        /// </summary>
        /// <param name="SQLString">��ѯ���</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string p_strSql)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    Open(connection);
                    OleDbDataAdapter command = new OleDbDataAdapter(p_strSql, connection);
                    command.Fill(ds, "ds");
                }
                catch (OleDbException exp)
                {
                    throw new Exception(exp.Message);
                }
                finally
                {
                    Close(connection);
                }
                return ds;
            }
        }


        #endregion

        #region ִ�д�������SQL���

        /// <summary>
        /// ִ�д�����SQL��䣬����Ӱ��ļ�¼��
        /// </summary>
        /// <param name="p_strSql">SQL���</param>
        /// <param name="p_cmdParms">cmd����</param>
        /// <returns>Ӱ��ļ�¼��</returns>
        public static int ExecuteSql(string p_strSql, params OleDbParameter[] p_cmdParms)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, p_strSql, p_cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (OleDbException exp)
                    {
                        throw new Exception(exp.Message);
                    }
                }
            }
        }

        /// <summary>
        /// ִ�ж���������SQL��䣬ʵ�����ݿ�����
        /// </summary>
        /// <param name="p_hashTableSql">SQL���Ĺ�ϣ��keyΪsql��䣬value�Ǹ�����OleDbParameter[]��</param>
        public static void ExecuteSqlTran(Hashtable p_hashTableSql)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                Open(conn);
                using (OleDbTransaction trans = conn.BeginTransaction())
                {
                    OleDbCommand cmd = new OleDbCommand();
                    try
                    {
                        //ѭ��
                        foreach (DictionaryEntry dicEntry in p_hashTableSql)
                        {
                            string strSql = dicEntry.Key.ToString();
                            OleDbParameter[] cmdParms = (OleDbParameter[])dicEntry.Value;
                            PrepareCommand(cmd, conn, trans, strSql, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                            trans.Commit();
                        }
                    }
                    catch (OleDbException exp)
                    {
                        trans.Rollback();
                        throw new Exception(exp.Message);
                    }
                    finally
                    {
                        Close(conn);
                    }
                }
            }
        }

        /// <summary>
        /// ִ�д�����SQL���ص�һ�е�һ�У�����Ϊnull�������ز�ѯ�����object����
        /// </summary>
        /// <param name="p_strSql">Sql���</param>
        /// <param name="cmdParms">oledbcomm����</param>
        /// <returns>��ѯ�����object��</returns>
        public static object GetSingle(string p_strSql, params OleDbParameter[] p_cmdParms)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, p_strSql, p_cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (OleDbException exp)
                    {
                        throw new Exception(exp.Message);
                    }
                }
            }
        }

        /// <summary>
        /// ִ�д�����SQL��ѯ��䣬����OleDbDataReader
        /// </summary>
        /// <param name="p_strSql">��ѯ���</param>
        /// <param name="p_cmdParms">oledbcomm����</param>
        /// <returns>OleDbDataReader</returns>
        public static OleDbDataReader ExecuteReader(string p_strSql, params OleDbParameter[] p_cmdParms)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, p_strSql, p_cmdParms);
                        OleDbDataReader oleDbReader = cmd.ExecuteReader();
                        cmd.Parameters.Clear();
                        return oleDbReader;
                    }
                    catch (OleDbException exp)
                    {
                        throw new Exception(exp.Message);
                    }
                }
            }

        }

        /// <summary>
        /// ִ�д�����SQL��ѯ��䣬����DataSet
        /// </summary>
        /// <param name="p_strSql">SQL��ѯ���</param>
        /// <param name="cmdParms">oledbcomm����</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string p_strSql, params OleDbParameter[] cmdParms)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand cmd = new OleDbCommand();
                PrepareCommand(cmd, connection, null, p_strSql, cmdParms);
                using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (OleDbException exp)
                    {
                        throw new Exception(exp.Message);
                    }
                    return ds;
                }
            }
        }

        #endregion

        #region �洢���̲���

        /// <summary>
        /// ִ�д洢���̲�ѯ���ݼ�
        /// </summary>
        /// <param name="p_storedProcName">�洢������</param>
        /// <param name="p_parameters">�洢���̲���</param>
        /// <returns>OleDbDataReader</returns>
        public static OleDbDataReader RunProcedure(string p_storedProcName, IDataParameter[] p_parameters)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbDataReader returnReader;
                try
                {
                    Open(connection);
                    OleDbCommand command = BuildQueryCommand(connection, p_storedProcName, p_parameters);
                    command.CommandType = CommandType.StoredProcedure;
                    returnReader = command.ExecuteReader();
                    return returnReader;
                }
                catch (OleDbException exp)
                {
                    throw new Exception(exp.Message);
                }
                finally
                {
                    Close(connection);
                }
            }
        }


        /// <summary>
        /// ִ�д洢���̲�ѯ����DATASET
        /// </summary>
        /// <param name="p_storedProcName">�洢������</param>
        /// <param name="p_parameters">�洢���̲���</param>
        /// <param name="p_strTableName">DataSet����еı���</param>
        /// <returns>DataSet</returns>
        public static DataSet RunProcedure(string p_storedProcName, IDataParameter[] p_parameters, string p_strTableName)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    DataSet dataSet = new DataSet();
                    Open(connection);
                    OleDbDataAdapter sqlDA = new OleDbDataAdapter();
                    sqlDA.SelectCommand = BuildQueryCommand(connection, p_storedProcName, p_parameters);
                    //sqlDA.Fill(dataSet, tableName);
                    return dataSet;
                }
                catch (OleDbException exp)
                {
                    throw new Exception(exp.Message);
                }
                finally
                {
                    Close(connection);
                }
            }
        }

        /// <summary>
        /// ִ�д洢���̣�����Ӱ�������		
        /// </summary>
        /// <param name="p_storedProcName">�洢������</param>
        /// <param name="p_parameters">�洢���̲���</param>
        /// <returns></returns>
        //public static int RunProcedure(string p_storedProcName, IDataParameter[] p_parameters)
        //{
        //    using (OleDbConnection connection = new OleDbConnection(connectionString))
        //    {
        //        try
        //        {
        //            int result = 0;
        //            Open(connection);
        //            OleDbCommand command = BuildIntCommand(connection, p_storedProcName, p_parameters);
        //            result = command.ExecuteNonQuery();
        //            return result;
        //        }
        //        catch (OleDbException exp)
        //        {
        //            throw new Exception(exp.Message);
        //        }
        //        finally
        //        {
        //            Close(connection);
        //        }
        //    }
        //}

        #endregion
    }
}
