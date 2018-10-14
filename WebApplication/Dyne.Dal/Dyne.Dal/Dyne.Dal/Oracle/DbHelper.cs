using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using System.Collections;

namespace Dyne.Dal.Oracle
{
    /// <summary>
    /// Copyright (C) 2008 HanYanHua
    /// ���ݷ��ʻ�����(����Oracle)
    /// </summary>
    public abstract  class DbHelper
    {
        //���ݿ������ַ���
        public static string connectionString = PubConstant.ConntionString;

        public DbHelper()
		{

        }

        #region �ڲ�����

        /// <summary>
        /// �����ݿ�����
        /// </summary>
        /// <param name="p_conn">���ݿ�����</param>
        private void Open(OracleConnection p_conn)
        {
            if (p_conn.State != ConnectionState.Open)
            {
                p_conn.Open();
            }
        }

        /// <summary>
        /// �ر����ݿ�����
        /// </summary>
        /// <param name="p_conn">���ݿ�����</param>
        private void Close(OracleConnection p_conn)
        {
            if (p_conn.State == ConnectionState.Open)
            {
                p_conn.Close();
            }
        }

        #endregion

        #region  ִ�м�SQL���

        /// <summary>
		/// ִ��SQL��䣬����Ӱ������
		/// </summary>
        /// <param name="p_strSql">SQL���</param>
        /// <returns>Ӱ������</returns>
		public  int ExecuteSql(string p_strSql)
		{
			using (OracleConnection connection = new OracleConnection(connectionString))
			{				
				using (OracleCommand cmd = new OracleCommand(p_strSql,connection))
				{
                    try
                    {
                        Open(connection);
                        return cmd.ExecuteNonQuery();
                    }
                    catch (OracleException exp)
                    {
                        throw new Exception(exp.Message);
                    }
				}				
			}
		}
		
		/// <summary>
		/// ִ�ж���SQL��䣬ʵ�����ݿ�����
		/// </summary>
        /// <param name="p_arrayListSqls">����SQL���</param>		
		public void ExecuteSqlTran(ArrayList p_arrayListSqls)
		{
			using (OracleConnection conn = new OracleConnection(connectionString))
			{
                try
                {
                    Open(conn);
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    OracleTransaction trans = conn.BeginTransaction();
                    cmd.Transaction = trans;

                    for (int i = 0; i < p_arrayListSqls.Count; i++)
                    {
                        string strsql = p_arrayListSqls[i].ToString();
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    trans.Commit();
                }
                catch (OracleException exp)
                {
                    //trans.Rollback();
                    throw new Exception(exp.Message);
                }
                finally
                {
                    Close(conn);
                }
			}
		}
		
        /// <summary>
		/// ִ�д�һ����������SQL��䡣
		/// </summary>
        /// <param name="p_strSql">SQL���</param>
        /// <param name="p_strContent">��������,����������content������һ���ֶ��Ǹ�ʽ���ӵ����£���������ţ�����ͨ�������ʽ���</param>
		/// <returns>Ӱ��ļ�¼��</returns>
		public  int ExecuteSql(string p_strSql,string p_strContent)
		{				
			using (OracleConnection connection = new OracleConnection(connectionString))
			{
				OracleCommand   cmd         = new OracleCommand(p_strSql,connection);
                OracleParameter myParameter = new OracleParameter("@content", OracleType.NVarChar);
				myParameter.Value           = p_strContent ;
				cmd.Parameters.Add(myParameter);
				try
				{
                    Open(connection);
                    return cmd.ExecuteNonQuery();
				}
				catch(OracleException exp)
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
		/// �����������ݴ���ͼ�����SQL
		/// </summary>
		/// <param name="strSQL">SQL���</param>
        /// <param name="p_byteImages">ͼ���ֽ�,���ݿ���ֶ�����Ϊblob�����(������Ϊimage)</param>
		/// <returns>Ӱ��ļ�¼��</returns>
		public int ExecuteSqlInsertImg(string p_strSql,byte[] p_byteImages)
		{		
			using (OracleConnection connection = new OracleConnection(connectionString))
			{
				OracleCommand cmd           = new OracleCommand(p_strSql,connection);
                OracleParameter myParameter = new OracleParameter("@image", OracleType.Blob);
				myParameter.Value           = p_byteImages ;
				cmd.Parameters.Add(myParameter);

				try
				{
                    Open(connection);
                    return cmd.ExecuteNonQuery();
				}
				catch(OracleException exp)
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
		/// ִ��һ��SQL���ص�һ�е�һ��(���򷵻�null)�����ز�ѯ�����object����
		/// </summary>
        /// <param name="p_strSql">SQL���</param>
		/// <returns>��ѯ�����object��</returns>
        public object GetSingle(string p_strSql)
		{
			using (OracleConnection connection = new OracleConnection(connectionString))
			{
				using(OracleCommand cmd = new OracleCommand(p_strSql,connection))
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
                    catch (OracleException exp)
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
        /// ִ�в�ѯ��䣬����OracleDataReader ( ע�⣺���ø÷�����һ��Ҫ��SqlDataReader����Close )
		/// </summary>
		/// <param name="strSQL">��ѯ���</param>
		/// <returns>OracleDataReader</returns>
		public static OracleDataReader ExecuteReader(string strSQL)
		{
			OracleConnection connection = new OracleConnection(connectionString);			
			OracleCommand cmd = new OracleCommand(strSQL,connection);				
			try
			{
				connection.Open();
                OracleDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
				return myReader;
			}
			catch(System.Data.OracleClient.OracleException e)
			{								
				throw new Exception(e.Message);
			}			
			
		}		
		/// <summary>
		/// ִ�в�ѯ��䣬����DataSet
		/// </summary>
		/// <param name="SQLString">��ѯ���</param>
		/// <returns>DataSet</returns>
		public static DataSet Query(string SQLString)
		{
			using (OracleConnection connection = new OracleConnection(connectionString))
			{
				DataSet ds = new DataSet();
				try
				{
					connection.Open();
					OracleDataAdapter command = new OracleDataAdapter(SQLString,connection);				
					command.Fill(ds,"ds");
				}
				catch(System.Data.OracleClient.OracleException ex)
				{				
					throw new Exception(ex.Message);
				}			
				return ds;
			}			
		}


		#endregion

		#region ִ�д�������SQL���

		/// <summary>
		/// ִ��SQL��䣬����Ӱ��ļ�¼��
		/// </summary>
		/// <param name="SQLString">SQL���</param>
		/// <returns>Ӱ��ļ�¼��</returns>
		public static int ExecuteSql(string SQLString,params OracleParameter[] cmdParms)
		{
			using (OracleConnection connection = new OracleConnection(connectionString))
			{				
				using (OracleCommand cmd = new OracleCommand())
				{
					try
					{		
						PrepareCommand(cmd, connection, null,SQLString, cmdParms);
						int rows=cmd.ExecuteNonQuery();
						cmd.Parameters.Clear();
						return rows;
					}
					catch(System.Data.OracleClient.OracleException E)
					{				
						throw new Exception(E.Message);
					}
				}				
			}
		}
		
			
		/// <summary>
		/// ִ�ж���SQL��䣬ʵ�����ݿ�����
		/// </summary>
		/// <param name="SQLStringList">SQL���Ĺ�ϣ��keyΪsql��䣬value�Ǹ�����OracleParameter[]��</param>
		public static void ExecuteSqlTran(Hashtable SQLStringList)
		{			
			using (OracleConnection conn = new OracleConnection(connectionString))
			{
				conn.Open();
				using (OracleTransaction trans = conn.BeginTransaction()) 
				{
					OracleCommand cmd = new OracleCommand();
					try 
					{
						//ѭ��
						foreach (DictionaryEntry myDE in SQLStringList)
						{	
							string 	cmdText=myDE.Key.ToString();
							OracleParameter[] cmdParms=(OracleParameter[])myDE.Value;
							PrepareCommand(cmd,conn,trans,cmdText, cmdParms);
							int val = cmd.ExecuteNonQuery();
							cmd.Parameters.Clear();

							trans.Commit();
						}					
					}
					catch 
					{
						trans.Rollback();
						throw;
					}
				}				
			}
		}
	
				
		/// <summary>
		/// ִ��һ�������ѯ�����䣬���ز�ѯ�����object����
		/// </summary>
		/// <param name="SQLString">�����ѯ������</param>
		/// <returns>��ѯ�����object��</returns>
		public static object GetSingle(string SQLString,params OracleParameter[] cmdParms)
		{
			using (OracleConnection connection = new OracleConnection(connectionString))
			{
				using (OracleCommand cmd = new OracleCommand())
				{
					try
					{
						PrepareCommand(cmd, connection, null,SQLString, cmdParms);
						object obj = cmd.ExecuteScalar();
						cmd.Parameters.Clear();
						if((Object.Equals(obj,null))||(Object.Equals(obj,System.DBNull.Value)))
						{					
							return null;
						}
						else
						{
							return obj;
						}				
					}
					catch(System.Data.OracleClient.OracleException e)
					{				
						throw new Exception(e.Message);
					}					
				}
			}
		}
		
		/// <summary>
        /// ִ�в�ѯ��䣬����OracleDataReader ( ע�⣺���ø÷�����һ��Ҫ��SqlDataReader����Close )
		/// </summary>
		/// <param name="strSQL">��ѯ���</param>
		/// <returns>OracleDataReader</returns>
		public static OracleDataReader ExecuteReader(string SQLString,params OracleParameter[] cmdParms)
		{		
			OracleConnection connection = new OracleConnection(connectionString);
			OracleCommand cmd = new OracleCommand();				
			try
			{
				PrepareCommand(cmd, connection, null,SQLString, cmdParms);
                OracleDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
				cmd.Parameters.Clear();
				return myReader;
			}
			catch(System.Data.OracleClient.OracleException e)
			{								
				throw new Exception(e.Message);
			}					
			
		}		
		
		/// <summary>
		/// ִ�в�ѯ��䣬����DataSet
		/// </summary>
		/// <param name="SQLString">��ѯ���</param>
		/// <returns>DataSet</returns>
		public static DataSet Query(string SQLString,params OracleParameter[] cmdParms)
		{
			using (OracleConnection connection = new OracleConnection(connectionString))
			{
				OracleCommand cmd = new OracleCommand();
				PrepareCommand(cmd, connection, null,SQLString, cmdParms);
				using( OracleDataAdapter da = new OracleDataAdapter(cmd) )
				{
					DataSet ds = new DataSet();	
					try
					{												
						da.Fill(ds,"ds");
						cmd.Parameters.Clear();
					}
					catch(System.Data.OracleClient.OracleException ex)
					{				
						throw new Exception(ex.Message);
					}			
					return ds;
				}				
			}			
		}


		private static void PrepareCommand(OracleCommand cmd,OracleConnection conn,OracleTransaction trans, string cmdText, OracleParameter[] cmdParms) 
		{
			if (conn.State != ConnectionState.Open)
				conn.Open();
			cmd.Connection = conn;
			cmd.CommandText = cmdText;
			if (trans != null)
				cmd.Transaction = trans;
			cmd.CommandType = CommandType.Text;//cmdType;
			if (cmdParms != null) 
			{
				foreach (OracleParameter parm in cmdParms)
					cmd.Parameters.Add(parm);
			}
		}

		#endregion

		#region �洢���̲���

		/// <summary>
        /// ִ�д洢���� ����SqlDataReader ( ע�⣺���ø÷�����һ��Ҫ��SqlDataReader����Close )
		/// </summary>
		/// <param name="storedProcName">�洢������</param>
		/// <param name="parameters">�洢���̲���</param>
		/// <returns>OracleDataReader</returns>
		public static OracleDataReader RunProcedure(string storedProcName, IDataParameter[] parameters )
		{
			OracleConnection connection = new OracleConnection(connectionString);
			OracleDataReader returnReader;
			connection.Open();
			OracleCommand command = BuildQueryCommand( connection,storedProcName, parameters );
			command.CommandType = CommandType.StoredProcedure;
            returnReader = command.ExecuteReader(CommandBehavior.CloseConnection);				
			return returnReader;			
		}
		
		
		/// <summary>
		/// ִ�д洢����
		/// </summary>
		/// <param name="storedProcName">�洢������</param>
		/// <param name="parameters">�洢���̲���</param>
		/// <param name="tableName">DataSet����еı���</param>
		/// <returns>DataSet</returns>
		public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName )
		{
			using (OracleConnection connection = new OracleConnection(connectionString))
			{
				DataSet dataSet = new DataSet();
				connection.Open();
				OracleDataAdapter sqlDA = new OracleDataAdapter();
				sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters );
				sqlDA.Fill( dataSet, tableName );
				connection.Close();
				return dataSet;
			}
		}

		
		/// <summary>
		/// ���� OracleCommand ����(��������һ���������������һ������ֵ)
		/// </summary>
		/// <param name="connection">���ݿ�����</param>
		/// <param name="storedProcName">�洢������</param>
		/// <param name="parameters">�洢���̲���</param>
		/// <returns>OracleCommand</returns>
		private static OracleCommand BuildQueryCommand(OracleConnection connection,string storedProcName, IDataParameter[] parameters)
		{			
			OracleCommand command = new OracleCommand( storedProcName, connection );
			command.CommandType = CommandType.StoredProcedure;
			foreach (OracleParameter parameter in parameters)
			{
				command.Parameters.Add( parameter );
			}
			return command;			
		}
		
		/// <summary>
		/// ִ�д洢���̣�����Ӱ�������		
		/// </summary>
		/// <param name="storedProcName">�洢������</param>
		/// <param name="parameters">�洢���̲���</param>
		/// <param name="rowsAffected">Ӱ�������</param>
		/// <returns></returns>
		public static int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected )
		{
			using (OracleConnection connection = new OracleConnection(connectionString))
			{
				int result;
				connection.Open();
				OracleCommand command = BuildIntCommand(connection,storedProcName, parameters );
				rowsAffected = command.ExecuteNonQuery();
				result = (int)command.Parameters["ReturnValue"].Value;
				//Connection.Close();
				return result;
			}
		}
		
		/// <summary>
		/// ���� OracleCommand ����ʵ��(��������һ������ֵ)	
		/// </summary>
		/// <param name="storedProcName">�洢������</param>
		/// <param name="parameters">�洢���̲���</param>
		/// <returns>OracleCommand ����ʵ��</returns>
		private static OracleCommand BuildIntCommand(OracleConnection connection,string storedProcName, IDataParameter[] parameters)
		{
			OracleCommand command = BuildQueryCommand(connection,storedProcName, parameters );
			command.Parameters.Add( new OracleParameter ( "ReturnValue",
                OracleType.Int32, 4, ParameterDirection.ReturnValue,
				false,0,0,string.Empty,DataRowVersion.Default,null ));
			return command;
		}
		#endregion	
    }
}
