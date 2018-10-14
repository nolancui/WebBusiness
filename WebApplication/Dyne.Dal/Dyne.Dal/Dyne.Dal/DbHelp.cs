using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

/**********************************
 * ���ݿ����  
 * Copyright (C) 2008 HanYanHua
 **********************************/
namespace Dyne.Dal
{
    /// <summary>
    ///  ���ݿ����
    /// </summary>
    public class DbHelp
    {
        /// <summary>
        /// ���ݿ����
        /// </summary>
        /// <param name="p_dbType">���ݿ�����</param>
        /// <param name="p_strConn">���ݿ����Ӵ�</param>
        public DbHelp(EnumDbType p_dbType, string p_strConn)
        {
            m_dbType = p_dbType;
            PubConstant.ConntionString = p_strConn;
        }

        /// <summary>
        /// ������Ϣ
        /// </summary>
        private  string m_strError = "";

        /// <summary>
        /// ������Ϣ
        /// </summary>
        public string ErrorMessage
        {
            get
            {
                return m_strError;
            }
        }

        /// <summary>
        /// ���ݿ�����
        /// </summary>
        EnumDbType m_dbType;

        /// <summary>
        /// �������ݿ�����
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
        /// ִ��SQL��䣬����Ӱ������
        /// </summary>
        /// <param name="p_strSql">SQL���</param>
        /// <returns>Ӱ������ -1 ʧ�� </returns>
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
        /// ִ��SQL��䣬����Ӱ������(��һ���洢���̲��� ��������content)
        /// </summary>
        /// <param name="SQLString">SQL���</param>
        /// <param name="content">��������,(�������»��������)</param>
        /// <returns>Ӱ������ -1 ʧ�� </returns>
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
        /// ִ��SQL��䣬����Ӱ������(��һ��ͼ���ֶδ洢���̲��� ��������image��
        /// </summary>
        /// <param name="p_strSql">Sql���</param>
        /// <param name="p_byteFs">ͼ���ֽ� sqlserver��oledbΪBinary,oracleΪBlob</param>
        /// <returns>Ӱ��ļ�¼�� -1 ʧ�� </returns>
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
        /// ִ�д洢���̣�����Ӱ�������		
        /// </summary>
        /// <param name="p_storedProcName">�洢������</param>
        /// <param name="p_parameters">�洢���̲���</param>
        /// <returns>Ӱ��ļ�¼�� -1 ʧ�� </returns>
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
        /// ִ�ж���SQL��䣬ʵ�����ݿ�����
        /// </summary>
        /// <param name="p_ArrListSqls">����SQL���</param>	
        /// <returns>�Ƿ�ɹ�</returns>
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
        /// ִ��Sql���ؽ�����е�һ�е�һ�У��ջ����򷵻�null����
        /// </summary>
        /// <param name="p_strSql">sql���</param>
        /// <param name="o_obj">���ص�һ�е�һ�е�ֵ</param>
        /// <returns>�Ƿ�ɹ�</returns>
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
        /// ִ�в�ѯ��䣬����DataAdapter
        /// </summary>
        /// <param name="p_strSql">Sql���</param>
        /// <returns>������Ӧ���ݿ��DataAdapter,���󷵻�null</returns>
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
        /// ִ�д洢���̣�����DbDataReader
        /// </summary>
        /// <param name="p_storedProcName">�洢������</param>
        /// <param name="p_parameters">�洢���̲���</param>
        /// <returns>������Ӧ���ݿ��DataAdapter,���󷵻�null</returns>
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
        /// ִ�в�ѯ��䣬����DataSet
        /// </summary>
        /// <param name="p_strSql">sql���</param>
        /// <returns>����DataSet ���󷵻�null</returns>
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
        /// ִ�д洢���̲�ѯ����DATASET
        /// </summary>
        /// <param name="p_storedProcName">�洢������</param>
        /// <param name="p_parameters">�洢���̲���</param>
        /// <returns>����DataSet ���󷵻�null</returns>
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
        /// ִ�в�ѯ��䣬����DataTable
        /// </summary>
        /// <param name="p_strSql">sql���</param>
        /// <returns>����DataTable �����򷵻�null</returns>
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
        /// ִ�д洢���̲�ѯ����DataTable
        /// </summary>
        /// <param name="p_storedProcName">�洢������</param>
        /// <param name="p_parameters">�洢���̲���</param>
        /// <returns>����DataTable �����򷵻�null</returns>
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
