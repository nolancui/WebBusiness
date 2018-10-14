using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

/********************************
 * ���ݷ��ʻ�����(����sqlserver)
 ********************************/
namespace Dyne.Dal
{
    /// <summary>
    /// Copyright (C) 2008 HanYanHua
    /// ���ݷ��ʻ�����(����SqlServer)
    /// </summary>
    internal class DbHelperSql
    {
        /// <summary>
        /// �������ݿ�����
        /// </summary>
        /// <returns></returns>
        internal static bool TestDbLink()
        {
            using (SqlConnection connection = new SqlConnection(PubConstant.ConntionString))
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException  exp)
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
        private static SqlCommand BuildQueryCommand(SqlConnection p_connection,
                                                      string p_strStoredProcName, IDataParameter[] p_parameters)
        {
            SqlCommand command = new SqlCommand(p_strStoredProcName, p_connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in p_parameters)
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
        private static SqlCommand BuildIntCommand(SqlConnection p_connection,
                                                    string p_strStoredProcName, IDataParameter[] p_parameters)
        {
            SqlCommand command = BuildQueryCommand(p_connection, p_strStoredProcName, p_parameters);
            command.Parameters.Add(new SqlParameter("ReturnValue",
                SqlDbType.Int, 4, ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }


        /// <summary>
        /// ִ��SQL��䣬����Ӱ������
        /// </summary>
        /// <param name="p_strSql">SQL���</param>
        /// <returns>Ӱ������</returns>
        internal static int ExecuteSql(string p_strSql)
        {
            using (SqlConnection connection = new SqlConnection(PubConstant.ConntionString))
            {
                using (SqlCommand cmd = new SqlCommand(p_strSql, connection))
                {
                    try
                    {
                        connection.Open();
                        return cmd.ExecuteNonQuery();
                    }
                    catch (SqlException exp)
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
            using (SqlConnection connection = new SqlConnection(PubConstant.ConntionString))
            {
                using (SqlCommand cmd = new SqlCommand(p_strSql, connection))
                {
                    SqlParameter myParameter = new SqlParameter("@content", SqlDbType.VarChar);
                    myParameter.Value = p_strContent;
                    cmd.Parameters.Add(myParameter);
                    try
                    {
                        connection.Open();
                        return cmd.ExecuteNonQuery();
                    }
                    catch (SqlException exp)
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
            using (SqlConnection connection = new SqlConnection(PubConstant.ConntionString))
            {
                using (SqlCommand cmd = new SqlCommand(p_strSql, connection))
                {
                    SqlParameter myParameter = new SqlParameter("@image", SqlDbType.Binary);
                    myParameter.Value = p_byteImagee;
                    cmd.Parameters.Add(myParameter);
                    try
                    {
                        connection.Open();
                        return cmd.ExecuteNonQuery();
                    }
                    catch (SqlException exp)
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
            using (SqlConnection connection = new SqlConnection(PubConstant.ConntionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = BuildQueryCommand(connection, p_strStoredProcName, p_parameters);
                    return command.ExecuteNonQuery();
                }
                catch (SqlException exp)
                {
                    throw new Exception(exp.Message);
                }
            }
        }
        
        // <summary>
        /// ִ�ж���SQL��䣬ʵ�����ݿ�����
        /// </summary>
        /// <param name="p_ArrListSqls">����SQL���</param>		
        internal static void ExecuteSqlTran(ArrayList p_ArrListSqls)
        {
            using (SqlConnection conn = new SqlConnection(PubConstant.ConntionString))
            {
                TestDbLink();
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction tra = conn.BeginTransaction();
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
                catch (SqlException exp)
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
            using (SqlConnection connection = new SqlConnection(PubConstant.ConntionString))
            {
                using (SqlCommand cmd = new SqlCommand(p_strSql, connection))
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
                    catch (SqlException exp)
                    {
                        connection.Dispose();
                        throw new Exception(exp.Message);
                    }
                }
            }
        }


        /// <summary>
        /// ִ�в�ѯ��䣬����SqlDataReader
        /// </summary>
        /// <param name="p_strSql">Sql���</param>
        /// <returns>OleDbDataReader</returns>
        internal static SqlDataReader ExecuteReader(string p_strSql)
        {
            using (SqlConnection connection = new SqlConnection(PubConstant.ConntionString))
            {
                using (SqlCommand cmd = new SqlCommand(p_strSql, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        return reader;
                    }
                    catch (SqlException exp)
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
        internal static SqlDataReader ExecuteReader(string p_strStoredProcName, IDataParameter[] p_parameters)
        {
            using (SqlConnection connection = new SqlConnection(PubConstant.ConntionString))
            {
                SqlDataReader returnReader;
                try
                {
                    connection.Open();
                    SqlCommand command = BuildQueryCommand(connection, p_strStoredProcName, p_parameters);
                    command.CommandType = CommandType.StoredProcedure;
                    returnReader = command.ExecuteReader();
                    return returnReader;
                }
                catch (SqlException exp)
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
            using (SqlConnection connection = new SqlConnection(PubConstant.ConntionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter dataAdatper = new SqlDataAdapter(p_strSql, connection);
                    dataAdatper.Fill(ds);
                }
                catch (SqlException exp)
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
            using (SqlConnection connection = new SqlConnection(PubConstant.ConntionString))
            {
                try
                {
                    DataSet dataSet = new DataSet();
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand  = BuildQueryCommand(connection, p_strStoredProcName, p_parameters);
                    dataAdapter.Fill(dataSet);
                    return dataSet;
                }
                catch (SqlException exp)
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
            using (SqlConnection connection = new SqlConnection(PubConstant.ConntionString))
            {
                DataTable dt = new DataTable();
                try
                {
                    connection.Open();
                    SqlDataAdapter dataAdatper = new SqlDataAdapter(p_strSql, connection);
                    dataAdatper.Fill(dt);
                }
                catch (SqlException exp)
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
            using (SqlConnection connection = new SqlConnection(PubConstant.ConntionString))
            {
                try
                {
                    DataTable dataTable = new DataTable();
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = BuildQueryCommand(connection, p_strStoredProcName, p_parameters);
                    dataAdapter.Fill(dataTable);
                    return dataTable;
                }
                catch (SqlException exp)
                {
                    throw new Exception(exp.Message);
                }
            }
        }

        internal static int QueryRecordCount(string p_strSql)
        {
            using (SqlConnection connection = new SqlConnection(PubConstant.ConntionString))
            {
                using (SqlCommand cmd = new SqlCommand(p_strSql, connection))
                {
                    try
                    {
                        connection.Open();
                        return (int)cmd.ExecuteScalar();
                    }
                    catch (SqlException exp)
                    {
                        connection.Dispose();
                        throw new Exception(exp.Message);
                    }
                }
            }

        }

    }
}
