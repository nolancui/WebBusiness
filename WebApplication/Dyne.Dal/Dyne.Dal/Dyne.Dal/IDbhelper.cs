using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;


namespace Dyne.Dal
{
    /// <summary>
    /// 数据库操作接口
    /// </summary>
    public interface IDbhelper
    {
        /// <summary>
        /// 构建 DbCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>返回dbcommand</returns>
        IDbCommand  BuildQueryCommand(IDbConnection p_connection, string p_strStoredProcName, IDbDataAdapter[] p_parameters);

        /// <summary>
        /// 创建 DbCommand 对象实例(用来返回一个整数值)
        /// </summary>
        /// <param name="p_connection">数据库连接</param>
        /// <param name="p_strStoredProcName">存储过程名</param>
        /// <param name="p_parameters">存储过程参数</param>
        /// <returns>返回dbcommand</returns>
        IDbCommand BuildIntCommand(IDbConnection p_connection, string p_strStoredProcName, System.Data.IDbDataAdapter[] p_parameters);

        /// <summary>
        /// 执行SQL语句，返回影响行数
        /// </summary>
        /// <param name="p_strSql">SQL语句</param>
        /// <returns>影响行数</returns>
        int ExecuteSql(string p_strSql);

        /// <summary>
        /// 执行SQL语句，返回影响行数(带一个存储过程参数 参数名：content)
        /// </summary>
        /// <param name="p_strSql">Sql语句</param>
        /// <param name="p_strContent">参数内容,(复杂文章或特殊符号)</param>
        /// <returns>影响行数</returns>
        int ExecuteSql(string p_strSql, string p_strContent);

        /// <summary>
        /// 执行SQL语句，返回影响行数(带一个图像字段存储过程参数 参数名：image）
        /// </summary>
        /// <param name="p_strSql">Sql语句</param>
        /// <param name="p_byteImagee">图像字节</param>
        /// <returns>影响的行数</returns>
        int ExecuteSql(string p_strSql, byte[] p_byteImagee);

        /// <summary>
        /// 执行存储过程，返回影响的行数
        /// </summary>
        /// <param name="p_strStoredProcName">存储过程名</param>
        /// <param name="p_parameters">存储过程参数</param>
        /// <returns>影响的行数</returns>
        int ExecuteSql(string p_strStoredProcName, IDataParameter[] p_parameters);

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="p_ArrListSqls">多条SQL语句</param>
        void ExecuteSqlTran(ArrayList p_ArrListSqls);

        /// <summary>
        /// 执行sql返回结果集中第一行第一列（空或无则返回null）。
        /// </summary>
        /// <param name="p_strSql">sql语句</param>
        /// <returns>查询结果（object）</returns>
        object GetSingle(string p_strSql);

        /// <summary>
        /// 执行查询语句，返回DbDataReader
        /// </summary>
        /// <param name="p_strSql">Sql语句</param>
        /// <returns>IDatareader</returns>
        IDataReader ExecuteReader(string p_strSql);

        /// <summary>
        /// 执行存储过程，返回OleDbDataReader
        /// </summary>
        /// <param name="p_strStoredProcName">存储过程名</param>
        /// <param name="p_parameters">存储过程参数</param>
        /// <returns>IDatareader</returns>
        System.Data.IDataReader ExecuteReader(string p_strStoredProcName, IDataParameter[] p_parameters);

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="p_strSql">sql语句</param>
        /// <returns>DataSet</returns>
        DataSet QueryToDs(string p_strSql);

        /// <summary>
        /// 执行存储过程查询返回DataSet
        /// </summary>
        /// <param name="p_strStoredProcName">存储过程名</param>
        /// <param name="p_parameters">存储过程参数</param>
        /// <returns>DataSet</returns>
        void QueryToDs(string p_strStoredProcName, IDataParameter[] p_parameters);

        /// <summary>
        /// 执行查询语句，返回DataTable
        /// </summary>
        /// <param name="p_strSql">sql语句</param>
        /// <returns>DataTable</returns>
        DataTable QueryToDt(string p_strSql);

        /// <summary>
        /// 执行存储过程，返回DataTable
        /// </summary>
        /// <param name="p_strStoredProcName">存储过程名</param>
        /// <param name="p_parameters">存储过程参数</param>
        /// <returns>DataTable</returns>
        DataTable QueryToDt(string p_strStoredProcName, System.Data.IDataParameter[] p_parameters);
    }
}
