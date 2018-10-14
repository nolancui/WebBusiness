using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;


namespace Dyne.Dal
{
    /// <summary>
    /// ���ݿ�����ӿ�
    /// </summary>
    public interface IDbhelper
    {
        /// <summary>
        /// ���� DbCommand ����(��������һ���������������һ������ֵ)
        /// </summary>
        /// <param name="connection">���ݿ�����</param>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <returns>����dbcommand</returns>
        IDbCommand  BuildQueryCommand(IDbConnection p_connection, string p_strStoredProcName, IDbDataAdapter[] p_parameters);

        /// <summary>
        /// ���� DbCommand ����ʵ��(��������һ������ֵ)
        /// </summary>
        /// <param name="p_connection">���ݿ�����</param>
        /// <param name="p_strStoredProcName">�洢������</param>
        /// <param name="p_parameters">�洢���̲���</param>
        /// <returns>����dbcommand</returns>
        IDbCommand BuildIntCommand(IDbConnection p_connection, string p_strStoredProcName, System.Data.IDbDataAdapter[] p_parameters);

        /// <summary>
        /// ִ��SQL��䣬����Ӱ������
        /// </summary>
        /// <param name="p_strSql">SQL���</param>
        /// <returns>Ӱ������</returns>
        int ExecuteSql(string p_strSql);

        /// <summary>
        /// ִ��SQL��䣬����Ӱ������(��һ���洢���̲��� ��������content)
        /// </summary>
        /// <param name="p_strSql">Sql���</param>
        /// <param name="p_strContent">��������,(�������»��������)</param>
        /// <returns>Ӱ������</returns>
        int ExecuteSql(string p_strSql, string p_strContent);

        /// <summary>
        /// ִ��SQL��䣬����Ӱ������(��һ��ͼ���ֶδ洢���̲��� ��������image��
        /// </summary>
        /// <param name="p_strSql">Sql���</param>
        /// <param name="p_byteImagee">ͼ���ֽ�</param>
        /// <returns>Ӱ�������</returns>
        int ExecuteSql(string p_strSql, byte[] p_byteImagee);

        /// <summary>
        /// ִ�д洢���̣�����Ӱ�������
        /// </summary>
        /// <param name="p_strStoredProcName">�洢������</param>
        /// <param name="p_parameters">�洢���̲���</param>
        /// <returns>Ӱ�������</returns>
        int ExecuteSql(string p_strStoredProcName, IDataParameter[] p_parameters);

        /// <summary>
        /// ִ�ж���SQL��䣬ʵ�����ݿ�����
        /// </summary>
        /// <param name="p_ArrListSqls">����SQL���</param>
        void ExecuteSqlTran(ArrayList p_ArrListSqls);

        /// <summary>
        /// ִ��sql���ؽ�����е�һ�е�һ�У��ջ����򷵻�null����
        /// </summary>
        /// <param name="p_strSql">sql���</param>
        /// <returns>��ѯ�����object��</returns>
        object GetSingle(string p_strSql);

        /// <summary>
        /// ִ�в�ѯ��䣬����DbDataReader
        /// </summary>
        /// <param name="p_strSql">Sql���</param>
        /// <returns>IDatareader</returns>
        IDataReader ExecuteReader(string p_strSql);

        /// <summary>
        /// ִ�д洢���̣�����OleDbDataReader
        /// </summary>
        /// <param name="p_strStoredProcName">�洢������</param>
        /// <param name="p_parameters">�洢���̲���</param>
        /// <returns>IDatareader</returns>
        System.Data.IDataReader ExecuteReader(string p_strStoredProcName, IDataParameter[] p_parameters);

        /// <summary>
        /// ִ�в�ѯ��䣬����DataSet
        /// </summary>
        /// <param name="p_strSql">sql���</param>
        /// <returns>DataSet</returns>
        DataSet QueryToDs(string p_strSql);

        /// <summary>
        /// ִ�д洢���̲�ѯ����DataSet
        /// </summary>
        /// <param name="p_strStoredProcName">�洢������</param>
        /// <param name="p_parameters">�洢���̲���</param>
        /// <returns>DataSet</returns>
        void QueryToDs(string p_strStoredProcName, IDataParameter[] p_parameters);

        /// <summary>
        /// ִ�в�ѯ��䣬����DataTable
        /// </summary>
        /// <param name="p_strSql">sql���</param>
        /// <returns>DataTable</returns>
        DataTable QueryToDt(string p_strSql);

        /// <summary>
        /// ִ�д洢���̣�����DataTable
        /// </summary>
        /// <param name="p_strStoredProcName">�洢������</param>
        /// <param name="p_parameters">�洢���̲���</param>
        /// <returns>DataTable</returns>
        DataTable QueryToDt(string p_strStoredProcName, System.Data.IDataParameter[] p_parameters);
    }
}
