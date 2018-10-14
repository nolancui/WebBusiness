using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using System.Collections;

/********************************
 * 数据访问基础类(基于Oracle)
 ********************************/
namespace Dyne.Dal
{
    /// <summary>
    /// Copyright (C) 2008 HanYanHua
    /// 数据访问基础类(基于Oracle)
    /// </summary>
    internal class DbHelperOra
    {
        /// <summary>
        /// 测试数据库连接
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
        /// 构建 DbCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
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
        /// 创建 DbCommand 对象实例(用来返回一个整数值)	
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>OleDbCommand 对象实例</returns>
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
        /// 执行SQL语句，返回影响行数
        /// </summary>
        /// <param name="p_strSql">SQL语句</param>
        /// <returns>影响行数</returns>
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
        /// 执行SQL语句，返回影响行数(带一个存储过程参数 参数名：content)
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="content">参数内容,(复杂文章或特殊符号)</param>
        /// <returns>影响行数</returns>
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
        /// 执行SQL语句，返回影响行数(带一个图像字段存储过程参数 参数名：image）
        /// </summary>
        /// <param name="p_strSql">Sql语句</param>
        /// <param name="p_byteFs">图像字节</param>
        /// <returns>影响的记录数</returns>
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
        /// 执行存储过程，返回影响的行数		
        /// </summary>
        /// <param name="p_storedProcName">存储过程名</param>
        /// <param name="p_parameters">存储过程参数</param>
        /// <returns>影响的行数</returns>
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
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="p_ArrListSqls">多条SQL语句</param>		
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
        /// 返回结果集中第一行第一列（空或无则返回null）。
        /// </summary>
        /// <param name="p_strSql">sql语句</param>
        /// <returns>查询结果（object）</returns>
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
        /// 执行查询语句，返回DataAdapter
        /// </summary>
        /// <param name="p_strSql">Sql语句</param>
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
        /// 执行存储过程，返回DbDataReader
        /// </summary>
        /// <param name="p_storedProcName">存储过程名</param>
        /// <param name="p_parameters">存储过程参数</param>
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
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="p_strSql">sql语句</param>
        /// <returns>返回DataSet</returns>
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
        /// 执行存储过程查询返回DATASET
        /// </summary>
        /// <param name="p_storedProcName">存储过程名</param>
        /// <param name="p_parameters">存储过程参数</param>
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
        /// 执行查询语句，返回DataTable
        /// </summary>
        /// <param name="p_strSql">sql语句</param>
        /// <returns>返回DataTable</returns>
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
        /// 执行存储过程查询返回DataTable
        /// </summary>
        /// <param name="p_storedProcName">存储过程名</param>
        /// <param name="p_parameters">存储过程参数</param>
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
