using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

/********************************
 * 数据访问基础类(基于sqlserver)
 ********************************/
namespace Dyne.Dal
{
    /// <summary>
    /// Copyright (C) 2008 HanYanHua
    /// 数据访问基础类(基于SqlServer)
    /// </summary>
    internal class DbHelperSql
    {
        /// <summary>
        /// 测试数据库连接
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
        /// 构建 DbCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
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
        /// 创建 DbCommand 对象实例(用来返回一个整数值)	
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>OleDbCommand 对象实例</returns>
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
        /// 执行SQL语句，返回影响行数
        /// </summary>
        /// <param name="p_strSql">SQL语句</param>
        /// <returns>影响行数</returns>
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
        /// 执行SQL语句，返回影响行数(带一个存储过程参数 参数名：content)
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="content">参数内容,(复杂文章或特殊符号)</param>
        /// <returns>影响行数</returns>
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
        /// 执行SQL语句，返回影响行数(带一个图像字段存储过程参数 参数名：image）
        /// </summary>
        /// <param name="p_strSql">Sql语句</param>
        /// <param name="p_byteFs">图像字节</param>
        /// <returns>影响的记录数</returns>
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
        /// 执行存储过程，返回影响的行数		
        /// </summary>
        /// <param name="p_storedProcName">存储过程名</param>
        /// <param name="p_parameters">存储过程参数</param>
        /// <returns>影响的行数</returns>
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
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="p_ArrListSqls">多条SQL语句</param>		
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
        /// 返回结果集中第一行第一列（空或无则返回null）。
        /// </summary>
        /// <param name="p_strSql">sql语句</param>
        /// <returns>查询结果（object）</returns>
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
        /// 执行查询语句，返回SqlDataReader
        /// </summary>
        /// <param name="p_strSql">Sql语句</param>
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
        /// 执行存储过程，返回DbDataReader
        /// </summary>
        /// <param name="p_storedProcName">存储过程名</param>
        /// <param name="p_parameters">存储过程参数</param>
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
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="p_strSql">sql语句</param>
        /// <returns>返回DataSet</returns>
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
        /// 执行存储过程查询返回DATASET
        /// </summary>
        /// <param name="p_storedProcName">存储过程名</param>
        /// <param name="p_parameters">存储过程参数</param>
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
        /// 执行查询语句，返回DataTable
        /// </summary>
        /// <param name="p_strSql">sql语句</param>
        /// <returns>返回DataTable</returns>
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
        /// 执行存储过程查询返回DataTable
        /// </summary>
        /// <param name="p_storedProcName">存储过程名</param>
        /// <param name="p_parameters">存储过程参数</param>
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
