// ******************************************************************
// �ļ���: Light.EXP.DataAccess.SystemFrame.SQLHelper.cs
// Copyright  (c)  2006-2007 ATA
// ����:       Ҷ����
// �������ڣ�  2007-10-17
// ��Ҫ���ݣ�  ͨ�õ����ݿ⴦���࣬ͨ��ado.net�����ݿ�����
// ******************************************************************

namespace Light.EXP.DataAccess.SystemFrame 
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    using Light.EXP.SystemFrameworks;

	public class SQLHelper : IDisposable
	{
		/// <summary>
		/// �������ݿ�����
		/// </summary>
		private SqlConnection conn = new SqlConnection(EXPConfiguration.ConnectionString);

		/// <summary>
		/// ִ�д洢���̷���DataSet
		/// </summary>
		/// <param name="procName">�洢��������</param>
		/// <param name="prams">�����б�</param>
		/// <returns>DataSet</returns>
		public DataSet ExecuteDataSet(string procName, SqlParameter[] prams)
		{
			DataSet ds = new DataSet();

			SqlCommand command = new SqlCommand(procName, conn);
			command.CommandType = CommandType.StoredProcedure;

			if (prams != null) 
			{
				foreach (SqlParameter parameter in prams)
					command.Parameters.Add(parameter);
			}

			SqlDataAdapter da = new SqlDataAdapter(command);
			da.Fill(ds);
			command.Parameters.Clear();
			return ds;		
		}

		/// <summary>
		/// ִ�д洢���̷���DataTable
		/// </summary>
		/// <param name="procName">�洢��������</param>
		/// <param name="prams">�����б�</param>
		/// <returns>DataTable</returns>
		public DataTable ExecuteDataTable(string procName, SqlParameter[] prams)
		{
			DataTable dt = new DataTable();

			SqlCommand command = new SqlCommand(procName, conn);
			command.CommandType = CommandType.StoredProcedure;

			if (prams != null) 
			{
				foreach (SqlParameter parameter in prams)
					command.Parameters.Add(parameter);
			}

			SqlDataAdapter da = new SqlDataAdapter(command);
			da.Fill(dt);
			command.Parameters.Clear();
			return dt;		
		}

		/// <summary>
		/// ִ�д洢���̷���DataReader
		/// </summary>
		/// <param name="procName">�洢��������</param>
		/// <param name="prams">�����б�</param>
		/// <returns>DataReader</returns>
		public SqlDataReader ExecuteDataReader(string procName, SqlParameter[] prams)
		{
			SqlCommand command = new SqlCommand(procName, conn);
			command.CommandType = CommandType.StoredProcedure;

			if (prams != null) 
			{
				foreach (SqlParameter parameter in prams)
					command.Parameters.Add(parameter);
			}

			conn.Open();

			SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
			command.Parameters.Clear();
			return reader;		
		}

		/// <summary>
		/// ִ�д洢�����޽��������
		/// </summary>
		/// <param name="procName">�洢��������</param>
		/// <param name="prams">�����б�</param>
		/// <returns>INT</returns>
		public int ExecuteNonQuery(string procName, SqlParameter[] prams)
		{
			SqlCommand command = new SqlCommand(procName, conn);
			command.CommandType = CommandType.StoredProcedure;

			conn.Open();

			if (prams != null) 
			{
				foreach (SqlParameter parameter in prams)
					command.Parameters.Add(parameter);
			}

			command.Parameters.Add(
				new SqlParameter("ReturnValue", SqlDbType.Int, 4,
				ParameterDirection.ReturnValue, false, 0, 0,
				string.Empty, DataRowVersion.Default, null));

			command.ExecuteNonQuery();

			conn.Close();

			return (int)command.Parameters["ReturnValue"].Value;
		}

        /// <summary>
        /// ����ɾ��
        /// </summary>
        /// <param name="selectcCmmandText">��ѯ���</param>
        /// <param name="deleteCommandText">ɾ�����</param>
        /// <param name="batchSize">����ɾ����¼����</param>
        public void BatchDelete(string selectCmmandText, string deleteCommandText, Int32 batchSize)
        {
            DataTable dataTable = new DataTable("Table");
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(selectCmmandText, conn);
            adapter.Fill(dataTable);
            adapter.DeleteCommand = new SqlCommand(deleteCommandText, conn);
            adapter.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            adapter.UpdateBatchSize = batchSize;
            conn.Open();
            adapter.DeleteCommand.ExecuteNonQuery();
            conn.Close();
            adapter.Update(dataTable);
        }

        /// <summary>
        /// �ͷ���Դ
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// �ͷ�����
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing != true)
            {
                return;
            }
            if (conn != null)
            {
                conn.Dispose();
                conn = null;
            }
        }
	}
}
