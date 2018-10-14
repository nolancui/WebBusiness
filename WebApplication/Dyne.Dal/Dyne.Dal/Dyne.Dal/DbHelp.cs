using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

/**********************************
 * 数据库访问  
 * Copyright (C) 2008 HanYanHua
 **********************************/
namespace Dyne.Dal
{
    /// <summary>
    ///  数据库访问
    /// </summary>
    public class DbHelp
    {
        /// <summary>
        /// 数据库访问
        /// </summary>
        /// <param name="p_dbType">数据库类型</param>
        /// <param name="p_strConn">数据库连接串</param>
        public DbHelp(EnumDbType p_dbType, string p_strConn)
        {
            m_dbType = p_dbType;
            PubConstant.ConntionString = p_strConn;
        }

        /// <summary>
        /// 错误信息
        /// </summary>
        private  string m_strError = "";

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMessage
        {
            get
            {
                return m_strError;
            }
        }

        /// <summary>
        /// 数据库类型
        /// </summary>
        EnumDbType m_dbType;

        /// <summary>
        /// 测试数据库连接
        /// </summary>
        /// <returns></returns>
        public bool TestDbLink()
        {
            try
            {
                switch (m_dbType)
                {
                    case EnumDbType.DbOracle:
                        return DbHelperOra.TestDbLink();
                    case EnumDbType.DbSqlServer:
                        return DbHelperSql.TestDbLink(); ;
                    case EnumDbType.DbOleDb:
                        return DbHelperOledb.TestDbLink();
                    default:
                        return DbHelperOra.TestDbLink();
                }
            }
            catch (Exception exp)
            {
                m_strError = exp.Message;
                return false;
            }
        }

        /// <summary>
        /// 执行SQL语句，返回影响行数
        /// </summary>
        /// <param name="p_strSql">SQL语句</param>
        /// <returns>影响行数 -1 失败 </returns>
        public int ExecuteSql(string p_strSql)
        {
            try
            {
                switch (m_dbType)
                {
                    case EnumDbType.DbOracle:
                        return DbHelperOra.ExecuteSql(p_strSql);
                    case EnumDbType.DbSqlServer:
                        return DbHelperSql.ExecuteSql(p_strSql);
                    case EnumDbType.DbOleDb:
                        return DbHelperOledb.ExecuteSql(p_strSql);
                    default:
                        return DbHelperOra.ExecuteSql(p_strSql);
                }
            }
            catch (Exception exp)
            {
                m_strError = exp.Message;
                return -1;
            }
        }

        /// <summary>
        /// 执行SQL语句，返回影响行数(带一个存储过程参数 参数名：content)
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="content">参数内容,(复杂文章或特殊符号)</param>
        /// <returns>影响行数 -1 失败 </returns>
        public int ExecuteSql(string p_strSql, string p_strContent)
        {
            try
            {
                switch (m_dbType)
                {
                    case EnumDbType.DbOracle:
                        return DbHelperOra.ExecuteSql(p_strSql, p_strContent);
                    case EnumDbType.DbSqlServer:
                        return DbHelperSql.ExecuteSql(p_strSql, p_strContent);
                    case EnumDbType.DbOleDb:
                        return DbHelperOledb.ExecuteSql(p_strSql, p_strContent);
                    default:
                        return DbHelperOra.ExecuteSql(p_strSql, p_strContent);
                }
            }
            catch (Exception exp)
            {
                m_strError = exp.Message;
                return -1;
            }
        }

        /// <summary>
        /// 执行SQL语句，返回影响行数(带一个图像字段存储过程参数 参数名：image）
        /// </summary>
        /// <param name="p_strSql">Sql语句</param>
        /// <param name="p_byteFs">图像字节 sqlserver和oledb为Binary,oracle为Blob</param>
        /// <returns>影响的记录数 -1 失败 </returns>
        public int ExecuteSql(string p_strSql, byte[] p_byteImagee)
        {
            try
            {
                switch (m_dbType)
                {
                    case EnumDbType.DbOracle:
                        return DbHelperOra.ExecuteSql(p_strSql, p_byteImagee);
                    case EnumDbType.DbSqlServer:
                        return DbHelperSql.ExecuteSql(p_strSql, p_byteImagee);
                    case EnumDbType.DbOleDb:
                        return DbHelperOledb.ExecuteSql(p_strSql, p_byteImagee);
                    default:
                        return DbHelperOra.ExecuteSql(p_strSql, p_byteImagee);
                }
            }
            catch (Exception exp)
            {
                m_strError = exp.Message;
                return -1;
            }
        }


        /// <summary>
        /// 执行存储过程，返回影响的行数		
        /// </summary>
        /// <param name="p_storedProcName">存储过程名</param>
        /// <param name="p_parameters">存储过程参数</param>
        /// <returns>影响的记录数 -1 失败 </returns>
        public int ExecuteSql(string p_strStoredProcName, IDataParameter[] p_parameters)
        {
            try
            {
                switch (m_dbType)
                {
                    case EnumDbType.DbOracle:
                        return DbHelperOra.ExecuteSql(p_strStoredProcName, p_parameters);
                    case EnumDbType.DbSqlServer:
                        return DbHelperSql.ExecuteSql(p_strStoredProcName, p_parameters);
                    case EnumDbType.DbOleDb:
                        return DbHelperOledb.ExecuteSql(p_strStoredProcName, p_parameters);
                    default:
                        return DbHelperOra.ExecuteSql(p_strStoredProcName, p_parameters);
                }
            }
            catch (Exception exp)
            {
                m_strError = exp.Message;
                return -1;
            }
        }


        // <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="p_ArrListSqls">多条SQL语句</param>	
        /// <returns>是否成功</returns>
        public bool ExecuteSqlTran(ArrayList p_ArrListSqls)
        {
            try
            {
                switch (m_dbType)
                {
                    case EnumDbType.DbOracle:
                        DbHelperOra.ExecuteSqlTran(p_ArrListSqls);
                        break;
                    case EnumDbType.DbSqlServer:
                        DbHelperSql.ExecuteSqlTran(p_ArrListSqls);
                        break;
                    case EnumDbType.DbOleDb:
                        DbHelperOledb.ExecuteSqlTran(p_ArrListSqls);
                        break;
                    default:
                        DbHelperOra.ExecuteSqlTran(p_ArrListSqls);
                        break;
                }
            }
            catch (Exception exp)
            {
                m_strError = exp.Message;
                return false;
            }
            return true;
        }

        /// <summary>
        /// 执行Sql返回结果集中第一行第一列（空或无则返回null）。
        /// </summary>
        /// <param name="p_strSql">sql语句</param>
        /// <param name="o_obj">返回第一行第一列的值</param>
        /// <returns>是否成功</returns>
        public bool  GetSingle(string p_strSql,out object o_obj)
        {
            o_obj = null;
            try
            {
                switch (m_dbType)
                {
                    case EnumDbType.DbOracle:
                        o_obj = DbHelperOra.GetSingle(p_strSql);
                        break;
                    case EnumDbType.DbSqlServer:
                        o_obj = DbHelperSql.GetSingle(p_strSql);
                        break;
                    case EnumDbType.DbOleDb:
                        o_obj = DbHelperOledb.GetSingle(p_strSql);
                        break;
                    default:
                        o_obj = DbHelperOra.GetSingle(p_strSql);
                        break;
                }
            }
            catch (Exception exp)
            {
                m_strError = exp.Message;
                return false;
            }
            return true;
        }


        /// <summary>
        /// 执行查询语句，返回DataAdapter
        /// </summary>
        /// <param name="p_strSql">Sql语句</param>
        /// <returns>返回相应数据库的DataAdapter,错误返回null</returns>
        public object ExecuteReader(string p_strSql)
        {
            try
            {
                switch (m_dbType)
                {
                    case EnumDbType.DbOracle:
                        return DbHelperOra.ExecuteReader(p_strSql);
                    case EnumDbType.DbSqlServer:
                        return DbHelperSql.ExecuteReader(p_strSql);
                    case EnumDbType.DbOleDb:
                        return DbHelperOledb.ExecuteReader(p_strSql);
                    default:
                        return DbHelperOra.ExecuteReader(p_strSql);
                }
            }
            catch (Exception exp)
            {
                m_strError = exp.Message;
                return null;
            }
        }

        /// <summary>
        /// 执行存储过程，返回DbDataReader
        /// </summary>
        /// <param name="p_storedProcName">存储过程名</param>
        /// <param name="p_parameters">存储过程参数</param>
        /// <returns>返回相应数据库的DataAdapter,错误返回null</returns>
        public object  ExecuteReader(string p_strStoredProcName, IDataParameter[] p_parameters)
        {
            try
            {
                switch (m_dbType)
                {
                    case EnumDbType.DbOracle:
                        return DbHelperOra.ExecuteReader(p_strStoredProcName, p_parameters);
                    case EnumDbType.DbSqlServer:
                        return DbHelperSql.ExecuteReader(p_strStoredProcName, p_parameters);
                    case EnumDbType.DbOleDb:
                        return DbHelperOledb.ExecuteReader(p_strStoredProcName, p_parameters);
                    default:
                        return DbHelperOra.ExecuteReader(p_strStoredProcName, p_parameters);
                }
            }
            catch (Exception exp)
            {
                m_strError = exp.Message;
                return null;
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="p_strSql">sql语句</param>
        /// <returns>返回DataSet 错误返回null</returns>
        public DataSet QueryToDs(string p_strSql)
        {
            try
            {
                switch (m_dbType)
                {
                    case EnumDbType.DbOracle:
                        return DbHelperOra.QueryToDs(p_strSql);
                    case EnumDbType.DbSqlServer:
                        return DbHelperSql.QueryToDs(p_strSql);
                    case EnumDbType.DbOleDb:
                        return DbHelperOledb.QueryToDs(p_strSql);
                    default:
                        return DbHelperOra.QueryToDs(p_strSql);
                }
            }
            catch (Exception exp)
            {
                m_strError = exp.Message;
                return null;
            }
        }

        /// <summary>
        /// 执行存储过程查询返回DATASET
        /// </summary>
        /// <param name="p_storedProcName">存储过程名</param>
        /// <param name="p_parameters">存储过程参数</param>
        /// <returns>返回DataSet 错误返回null</returns>
        public  DataSet QueryToDs(string p_strStoredProcName, IDataParameter[] p_parameters)
        {
            try
            {
                switch (m_dbType)
                {
                    case EnumDbType.DbOracle:
                        return DbHelperOra.QueryToDs(p_strStoredProcName, p_parameters);
                    case EnumDbType.DbSqlServer:
                        return DbHelperSql.QueryToDs(p_strStoredProcName, p_parameters);
                    case EnumDbType.DbOleDb:
                        return DbHelperOledb.QueryToDs(p_strStoredProcName, p_parameters);
                    default:
                        return DbHelperOra.QueryToDs(p_strStoredProcName, p_parameters);
                }
            }
            catch (Exception exp)
            {
                m_strError = exp.Message;
                return null;
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataTable
        /// </summary>
        /// <param name="p_strSql">sql语句</param>
        /// <returns>返回DataTable 错误则返回null</returns>
        public DataTable QueryToDt(string p_strSql)
        {
            try
            {
                switch (m_dbType)
                {
                    case EnumDbType.DbOracle:
                        return DbHelperOra.QueryToDt(p_strSql);
                    case EnumDbType.DbSqlServer:
                        return DbHelperSql.QueryToDt(p_strSql);
                    case EnumDbType.DbOleDb:
                        return DbHelperOledb.QueryToDt(p_strSql);
                    default:
                        return DbHelperOra.QueryToDt(p_strSql);
                }
            }
            catch (Exception exp)
            {
                m_strError = exp.Message;
                return null;
            }
        }


        /// <summary>
        /// 执行存储过程查询返回DataTable
        /// </summary>
        /// <param name="p_storedProcName">存储过程名</param>
        /// <param name="p_parameters">存储过程参数</param>
        /// <returns>返回DataTable 错误则返回null</returns>
        public DataTable QueryToDt(string p_strStoredProcName, IDataParameter[] p_parameters)
        {
            try
            {
                switch (m_dbType)
                {
                    case EnumDbType.DbOracle:
                        return DbHelperOra.QueryToDt(p_strStoredProcName, p_parameters);
                    case EnumDbType.DbSqlServer:
                        return DbHelperSql.QueryToDt(p_strStoredProcName, p_parameters);
                    case EnumDbType.DbOleDb:
                        return DbHelperOledb.QueryToDt(p_strStoredProcName, p_parameters);
                    default:
                        return DbHelperOra.QueryToDt(p_strStoredProcName, p_parameters);
                }
            }
            catch (Exception exp)
            {
                m_strError = exp.Message;
                return null;
            }
        }

    }
}
