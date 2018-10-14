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
    /// 数据访问基础类(基于OleDb)
    /// </summary>
    public abstract class DbHelper
    {
        //数据库连接字符串 可以动态更改connectionString支持多数据库.		
        public static string connectionString = PubConstant.ConntionString;

        public DbHelper()
        {

        }

        #region  内部方法

        /// <summary>
        /// 打开数据库连接
        /// </summary>
        /// <param name="p_oleDbConn">数据库连接</param>
        private static void  Open(OleDbConnection p_oleDbConn)
        {
            if (p_oleDbConn.State != ConnectionState.Open)
            {
                p_oleDbConn.Open();
            }
        }

        /// <summary>
        /// 关闭数据库连接
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
        /// 构建 OleDbCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
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
        /// 创建 OleDbCommand 对象实例(用来返回一个整数值)	
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>OleDbCommand 对象实例</returns>
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

        #region  执行简单SQL语句

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="p_strSql">SQL语句</param>
        /// <returns>影响的记录数</returns>
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
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="p_ArrListSqls">多条SQL语句</param>		
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
        /// 执行带一个存储过程参数的的SQL语句（参数名为content）
        /// </summary>
        /// <param name="p_strSql">SQL语句</param>
        /// <param name="p_strContent">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        /// <returns>影响的记录数</returns>
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
        /// 向数据库里插入图像格式的字段（图像参数名为image）
        /// </summary>
        /// <param name="p_strSql">SQL语句</param>
        /// <param name="p_byteFs">图像字节,数据库的字段类型为image的情况</param>
        /// <returns>影响的记录数</returns>
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
        /// 返回结果集中第一行第一列（空或无则返回null）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
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
        /// 执行查询语句，返回OleDbDataReader
        /// </summary>
        /// <param name="strSQL">查询语句</param>
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
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
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

        #region 执行带参数的SQL语句

        /// <summary>
        /// 执行带参数SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="p_strSql">SQL语句</param>
        /// <param name="p_cmdParms">cmd参数</param>
        /// <returns>影响的记录数</returns>
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
        /// 执行多条带参数SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="p_hashTableSql">SQL语句的哈希表（key为sql语句，value是该语句的OleDbParameter[]）</param>
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
                        //循环
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
        /// 执行带参数SQL返回第一行第一列（空则为null），返回查询结果（object）。
        /// </summary>
        /// <param name="p_strSql">Sql语句</param>
        /// <param name="cmdParms">oledbcomm参数</param>
        /// <returns>查询结果（object）</returns>
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
        /// 执行带参数SQL查询语句，返回OleDbDataReader
        /// </summary>
        /// <param name="p_strSql">查询语句</param>
        /// <param name="p_cmdParms">oledbcomm参数</param>
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
        /// 执行带参数SQL查询语句，返回DataSet
        /// </summary>
        /// <param name="p_strSql">SQL查询语句</param>
        /// <param name="cmdParms">oledbcomm参数</param>
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

        #region 存储过程操作

        /// <summary>
        /// 执行存储过程查询数据集
        /// </summary>
        /// <param name="p_storedProcName">存储过程名</param>
        /// <param name="p_parameters">存储过程参数</param>
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
        /// 执行存储过程查询返回DATASET
        /// </summary>
        /// <param name="p_storedProcName">存储过程名</param>
        /// <param name="p_parameters">存储过程参数</param>
        /// <param name="p_strTableName">DataSet结果中的表名</param>
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
        /// 执行存储过程，返回影响的行数		
        /// </summary>
        /// <param name="p_storedProcName">存储过程名</param>
        /// <param name="p_parameters">存储过程参数</param>
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
