using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using System.Collections;

/********************************
 * ���ݷ��ʻ�����(����Oracle)
 ********************************/
namespace Dyne.Dal
{
    /// <summary>
    /// Copyright (C) 2008 HanYanHua
    /// ���ݷ��ʻ�����(����Oracle)
    /// </summary>
    internal class DbHelperOra
    {
        /// <summary>
        /// �������ݿ�����
        /// </summary>
        /// <returns></returns>
        internal static bool TestDbLink()
        {
            using (OracleConnection connection = new OracleConnection(PubConstant.ConntionString))
            {
                try
                {
                    connection.Open();
                }
                catch (OracleException exp)
                {
                    throw new Exception(exp.Message);
                }
            }
            return true;
        }


        /// <summary>
        /// ���� DbCommand ����(��������һ���������������һ������ֵ)
        /// </summary>
        /// <param name="connection">���ݿ�����</param>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <returns>OleDbCommand</returns>
        private static OracleCommand BuildQueryCommand(OracleConnection p_connection,
                                                      string p_strStoredProcName, IDataParameter[] p_parameters)
        {
            OracleCommand command = new OracleCommand(p_strStoredProcName, p_connection);
            command.CommandType   = CommandType.StoredProcedure;
            foreach (OracleParameter parameter in p_parameters)
            {
                command.Parameters.Add(parameter);
            }
            return command;
        }

        /// <summary>
        /// ���� DbCommand ����ʵ��(��������һ������ֵ)	
        /// </summary>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <returns>OleDbCommand ����ʵ��</returns>
        private static OracleCommand BuildIntCommand(OracleConnection p_connection,
                                                    string p_strStoredProcName, IDataParameter[] p_parameters)
        {
            OracleCommand command = BuildQueryCommand(p_connection, p_strStoredProcName, p_parameters);
            command.Parameters.Add(new OracleParameter("ReturnValue",
                OracleType.Int16, 4, ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }



        /// <summary>
        /// ִ��SQL��䣬����Ӱ������
        /// </summary>
        /// <param name="p_strSql">SQL���</param>
        /// <returns>Ӱ������</returns>
        internal  static  int ExecuteSql(string p_strSql)
        {
            using (OracleConnection connection = new OracleConnection(PubConstant.ConntionString))
            {
                using (OracleCommand cmd = new OracleCommand(p_strSql, connection))
                {
                    try
                    {
                        connection.Open();
                        return cmd.ExecuteNonQuery();
                    }
                    catch (OracleException exp)
                    {
                        connection.Dispose();
                        throw new Exception(exp.Message);
                    }
                }
            }
        }

        /// <summary>
        /// ִ��SQL��䣬����Ӱ������(��һ���洢���̲��� ��������content)
        /// </summary>
        /// <param name="SQLString">SQL���</param>
        /// <param name="content">��������,(�������»��������)</param>
        /// <returns>Ӱ������</returns>
        internal static int ExecuteSql(string p_strSql, string p_strContent)
        {
            using (OracleConnection connection = new OracleConnection(PubConstant.ConntionString))
            {
                using (OracleCommand cmd = new OracleCommand(p_strSql, connection))
                {
                    OracleParameter myParameter = new OracleParameter("@content", OracleType.VarChar);
                    myParameter.Value = p_strContent;
                    cmd.Parameters.Add(myParameter);
                    try
                    {
                        connection.Open();
                        return cmd.ExecuteNonQuery();
                    }
                    catch (OracleException exp)
                    {
                        connection.Dispose();
                        throw new Exception(exp.Message);
                    }
                }
            }
        }

        /// <summary>
        /// ִ��SQL��䣬����Ӱ������(��һ��ͼ���ֶδ洢���̲��� ��������image��
        /// </summary>
        /// <param name="p_strSql">Sql���</param>
        /// <param name="p_byteFs">ͼ���ֽ�</param>
        /// <returns>Ӱ��ļ�¼��</returns>
        internal static int ExecuteSql(string p_strSql, byte[] p_byteImagee)
        {
            using (OracleConnection connection = new OracleConnection(PubConstant.ConntionString))
            {
                using (OracleCommand cmd = new OracleCommand(p_strSql, connection))
                {
                    OracleParameter myParameter = new OracleParameter("@image", OracleType.Blob);
                    myParameter.Value = p_byteImagee;
                    cmd.Parameters.Add(myParameter);
                    try
                    {
                        connection.Open();
                        return cmd.ExecuteNonQuery();
                    }
                    catch (OracleException exp)
                    {
                        connection.Dispose();
                        throw new Exception(exp.Message);
                    }
                }
            }
        }

        /// <summary>
        /// ִ�д洢���̣�����Ӱ�������		
        /// </summary>
        /// <param name="p_storedProcName">�洢������</param>
        /// <param name="p_parameters">�洢���̲���</param>
        /// <returns>Ӱ�������</returns>
        internal static int ExecuteSql(string p_strStoredProcName, IDataParameter[] p_parameters)
        {
            using (OracleConnection connection = new OracleConnection(PubConstant.ConntionString))
            {
                try
                {
                    connection.Open();
                    OracleCommand command = BuildQueryCommand(connection, p_strStoredProcName, p_parameters);
                    return command.ExecuteNonQuery();
                }
                catch (OracleException exp)
                {
                    throw new Exception(exp.Message);
                }
            }
        }

        /// <summary>
        /// ִ�ж���SQL��䣬ʵ�����ݿ�����
        /// </summary>
        /// <param name="p_ArrListSqls">����SQL���</param>		
        internal static void ExecuteSqlTran(ArrayList p_ArrListSqls)
        {
            using (OracleConnection conn = new OracleConnection(PubConstant.ConntionString))
            {
                TestDbLink();
                conn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                OracleTransaction tra = conn.BeginTransaction();
                cmd.Transaction = tra;
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
                catch (OracleException exp)
                {
                    tra.Rollback();
                    throw new Exception(exp.Message);
                }
            }
        }

        /// <summary>
        /// ���ؽ�����е�һ�е�һ�У��ջ����򷵻�null����
        /// </summary>
        /// <param name="p_strSql">sql���</param>
        /// <returns>��ѯ�����object��</returns>
        internal static object GetSingle(string p_strSql)
        {
            using (OracleConnection connection = new OracleConnection(PubConstant.ConntionString))
            {
                using (OracleCommand cmd = new OracleCommand(p_strSql, connection))
                {
                    try
                    {
                        connection.Open();
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
                    catch (OracleException exp)
                    {
                        connection.Dispose();
                        throw new Exception(exp.Message);
                    }
                }
            }
        }

        /// <summary>
        /// ִ�в�ѯ��䣬����DataAdapter
        /// </summary>
        /// <param name="p_strSql">Sql���</param>
        /// <returns>OleDbDataReader</returns>
        internal static OracleDataReader ExecuteReader(string p_strSql)
        {
            using (OracleConnection connection = new OracleConnection(PubConstant.ConntionString))
            {
                using (OracleCommand cmd = new OracleCommand(p_strSql, connection))
                {
                    try
                    {
                        connection.Open();
                        return cmd.ExecuteReader();
                    }
                    catch (OracleException exp)
                    {
                        connection.Dispose();
                        throw new Exception(exp.Message);
                    }
                }
            }
        }

        /// <summary>
        /// ִ�д洢���̣�����DbDataReader
        /// </summary>
        /// <param name="p_storedProcName">�洢������</param>
        /// <param name="p_parameters">�洢���̲���</param>
        /// <returns>OleDbDataReader</returns>
        internal static OracleDataReader ExecuteReader(string p_strStoredProcName, IDataParameter[] p_parameters)
        {
            using (OracleConnection connection = new OracleConnection(PubConstant.ConntionString))
            {
                OracleDataReader returnReader;
                try
                {
                    connection.Open();
                    OracleCommand command = BuildQueryCommand(connection, p_strStoredProcName, p_parameters);
                    command.CommandType = CommandType.StoredProcedure;
                    returnReader = command.ExecuteReader();
                    return returnReader;
                }
                catch (OracleException exp)
                {
                    throw new Exception(exp.Message);
                }
            }
        }
       
        /// <summary>
        /// ִ�в�ѯ��䣬����DataSet
        /// </summary>
        /// <param name="p_strSql">sql���</param>
        /// <returns>����DataSet</returns>
        internal static DataSet QueryToDs(string p_strSql)
        {
            using (OracleConnection connection = new OracleConnection(PubConstant.ConntionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    OracleDataAdapter command = new OracleDataAdapter(p_strSql, connection);
                    command.Fill(ds);
                }
                catch (OracleException exp)
                {
                    throw new Exception(exp.Message);
                }
                return ds;
            }
        }

        /// <summary>
        /// ִ�д洢���̲�ѯ����DATASET
        /// </summary>
        /// <param name="p_storedProcName">�洢������</param>
        /// <param name="p_parameters">�洢���̲���</param>
        /// <returns>DataSet</returns>
        internal static DataSet QueryToDs(string p_strStoredProcName, IDataParameter[] p_parameters)
        {
            using (OracleConnection connection = new OracleConnection(PubConstant.ConntionString))
            {
                try
                {
                    DataSet dataSet = new DataSet();
                    connection.Open();
                    OracleDataAdapter dataAdapter = new OracleDataAdapter();
                    dataAdapter.SelectCommand = BuildQueryCommand(connection, p_strStoredProcName, p_parameters);
                    dataAdapter.Fill(dataSet);
                    return dataSet;
                }
                catch (OracleException exp)
                {
                    throw new Exception(exp.Message);
                }
            }
        }

        /// <summary>
        /// ִ�в�ѯ��䣬����DataTable
        /// </summary>
        /// <param name="p_strSql">sql���</param>
        /// <returns>����DataTable</returns>
        internal static DataTable QueryToDt(string p_strSql)
        {
            using (OracleConnection connection = new OracleConnection(PubConstant.ConntionString))
            {
                DataTable dt = new DataTable();
                try
                {
                    connection.Open();
                    OracleDataAdapter dataAdatper = new OracleDataAdapter(p_strSql, connection);
                    dataAdatper.Fill(dt);
                }
                catch (OracleException exp)
                {
                    throw new Exception(exp.Message);
                }
                return dt;
            }
        }

        /// <summary>
        /// ִ�д洢���̲�ѯ����DataTable
        /// </summary>
        /// <param name="p_storedProcName">�洢������</param>
        /// <param name="p_parameters">�洢���̲���</param>
        /// <returns>dataTable</returns>
        internal static DataTable QueryToDt(string p_strStoredProcName, IDataParameter[] p_parameters)
        {
            using (OracleConnection connection = new OracleConnection(PubConstant.ConntionString))
            {
                try
                {
                    DataTable dataTable = new DataTable();
                    connection.Open();
                    OracleDataAdapter dataAdapter = new OracleDataAdapter();
                    dataAdapter.SelectCommand     = BuildQueryCommand(connection, p_strStoredProcName, p_parameters);
                    dataAdapter.Fill(dataTable);
                    return dataTable;
                }
                catch (OracleException exp)
                {
                    throw new Exception(exp.Message);
                }
            }
        }

        internal static int QueryRecordCount(string p_strSql)
        {
            using (OracleConnection connection = new OracleConnection(PubConstant.ConntionString))
            {
                using (OracleCommand cmd = new OracleCommand(p_strSql, connection))
                {
                    try
                    {
                        connection.Open();
                        return (int)cmd.ExecuteScalar();
                    }
                    catch (OracleException exp)
                    {
                        connection.Dispose();
                        throw new Exception(exp.Message);
                    }
                }
            }
        }
    }
}
