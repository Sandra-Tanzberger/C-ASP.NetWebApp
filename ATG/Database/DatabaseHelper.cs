/***********************************************************************

NAME: DatabaseHelper
 
PURPOSE: Provides methods for access to database objects for retrieval
         of data as well as writing it back.

REVISIONS:

Date           Author    Description
------------   -------   ---------------------------------
01/22/2010     SMM       Created
***********************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;
using System.IO;
using System.Xml;
using System.Threading;
using ATG.ErrorLogging;

namespace ATG.Database
{
    [Serializable]
    public class DatabaseHelper : IDisposable
    {
	
		#region Class Level variables
		
        //private string strConnectionString;
        [NonSerialized]private DbConnection objConnection;
        [NonSerialized]private DbCommand objCommand;
        //private DbProviderFactory objFactory = null;
        [NonSerialized]private AtgDatabase _AtgDb = null;
        private bool boolHandleErrors = false;
        private string strLastError;
        private bool boolLogError = false;
        private string strLogFile;
        //private string ConnectionStringHnalder;
		
		#endregion
		
		#region Constants
		
		#endregion

		#region Constructors/Destructors
		
        public DatabaseHelper( SRC_DB inSrcDB )
        {
            _AtgDb = new AtgDatabase();
            _AtgDb.InitProvider( inSrcDB );

            objConnection = _AtgDb.getConnection();
            objCommand = _AtgDb.getCommand();
            objConnection.ConnectionString = _AtgDb.getConnectionString();
            objCommand.Connection = objConnection;
        }
 
        public DatabaseHelper(): this( SRC_DB.SQL_SERVER)
        {
        }
		
		#endregion
		
		#region Properties
		
        public bool HandleErrors
        {
            get
            {
                return boolHandleErrors;
            }
            set
            {
                boolHandleErrors = value;
            }
        }

        public string LastError
        {
            get
            {
                return strLastError;
            }
        }

        public bool LogErrors
        {
            get
            {
                return boolLogError;
            }
            set
            {
                boolLogError = value;
            }
        }

        public string LogFile
        {
            get
            {
                return strLogFile;
            }
            set
            {
                strLogFile = value;
            }
        }
		
		#endregion

		#region Methods (Public)
		
	    public int AddParameter(string name, object value)
        {
            DbParameter p = _AtgDb.getParameter();
            p.ParameterName = name;
            p.Value = value;
            return objCommand.Parameters.Add(p);
        }

        public int AddParameter(string name, object value, System.Data.ParameterDirection parameterDirection)
        {
            DbParameter p = _AtgDb.getParameter();
            p.ParameterName = name;
            p.Value = value;
            p.Direction = parameterDirection;
            return objCommand.Parameters.Add(p);
        }
        
        public int AddParameter(DbParameter parameter)
        {
            return objCommand.Parameters.Add(parameter);
        }

        public void ClearParameters()
        {
            objCommand.Parameters.Clear();
        }

        public DbCommand Command
        {
            get
            {
                return objCommand;
            }
        }

        public void BeginTransaction()
        {
            if (objConnection.State == System.Data.ConnectionState.Closed)
            {
                objConnection.Open();
            }
            objCommand.Transaction = objConnection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            objCommand.Transaction.Commit();
            objConnection.Close();
        }

        public void RollbackTransaction()
        {
            objCommand.Transaction.Rollback();
            objConnection.Close();
        }

        public int ExecuteNonQuery(string spName, ref bool executionSucceeded)
        {
            return ExecuteNonQuery(spName, CommandType.StoredProcedure, ConnectionState.CloseOnExit,ref executionSucceeded);
        }

        public int ExecuteNonQuery(string query, CommandType commandtype, ref bool executionSucceeded)
        {
            return ExecuteNonQuery(query, commandtype, ConnectionState.CloseOnExit, ref executionSucceeded);
        }

        public int ExecuteNonQuery(string query, CommandType commandtype, ConnectionState connectionstate, ref bool executionSucceeded)
        {
            objCommand.CommandText = query;
            objCommand.CommandType = commandtype;

            int i = -1;
            try
            {
                if (objConnection.State == System.Data.ConnectionState.Closed)
                {
                    objConnection.Open();
                }
                i = objCommand.ExecuteNonQuery();
                executionSucceeded = true;
            }
            catch (Exception ex)
            {
                executionSucceeded = false;
                HandleExceptions(ex);
            }
            finally
            {
                objCommand.Parameters.Clear();
                if (connectionstate == ConnectionState.CloseOnExit)
                {
                    objConnection.Close();
                }
            }

            return i;
        }

		public object ExecuteScalar(string spName,ref bool executionSucceeded)
        {
            return ExecuteScalar(spName, CommandType.StoredProcedure, ConnectionState.CloseOnExit, ref executionSucceeded);
        }

        public object ExecuteScalar(string query, CommandType commandtype,ref bool executionSucceeded)
        {
            return ExecuteScalar(query, commandtype, ConnectionState.CloseOnExit,ref executionSucceeded);
        }

        public object ExecuteScalar(string query, CommandType commandtype, ConnectionState connectionstate, ref bool executionSucceeded)
        {
            objCommand.CommandText = query;
            objCommand.CommandType = commandtype;
            object o = null;
            try
            {
                if (objConnection.State == System.Data.ConnectionState.Closed)
                {
                    objConnection.Open();
                }
                o = objCommand.ExecuteScalar();
                executionSucceeded = true;
            }
            catch (Exception ex)
            {
                executionSucceeded = false;
                HandleExceptions(ex);
            }
            finally
            {
                objCommand.Parameters.Clear();
                if (connectionstate == ConnectionState.CloseOnExit)
                {
                    objConnection.Close();
                }
            }

            return o;
        }

        public DbDataReader ExecuteReader(string spName,ref bool executionSucceeded)
        {
            return ExecuteReader(spName, CommandType.StoredProcedure, ConnectionState.CloseOnExit, ref executionSucceeded);
        }

        public DbDataReader ExecuteReader(string query, CommandType commandtype, ref bool executionSucceeded)
        {
            return ExecuteReader(query, commandtype, ConnectionState.CloseOnExit, ref executionSucceeded);
        }

        public DbDataReader ExecuteReader(string query, CommandType commandtype, ConnectionState connectionstate, ref bool executionSucceeded)
        {
            objCommand.CommandText = query;
            objCommand.CommandType = commandtype;
            DbDataReader reader = null;
            try
            {
                if (objConnection.State == System.Data.ConnectionState.Closed)
                {
                    objConnection.Open();
                }
                if (connectionstate == ConnectionState.CloseOnExit)
                {
                    reader = objCommand.ExecuteReader(CommandBehavior.CloseConnection);
                }
                else
                {
                    reader = objCommand.ExecuteReader();
                }
                executionSucceeded = true;
            }
            catch (Exception ex)
            {
                executionSucceeded = false;
                HandleExceptions(ex);
            }
            finally
            {
                objCommand.Parameters.Clear();
            }

            return reader;
        }

        public IDataReader GetRelation(string parent, string child, string weak, string parentid, string parentIDinChildTable, string ChildTableID, string ChildTableIDinWeekTable)
        {
            IDataReader dr=null;
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();

            oDatabaseHelper.AddParameter("@parent", parent);
            oDatabaseHelper.AddParameter("@child", child);
            oDatabaseHelper.AddParameter("@weak", weak);
            
            oDatabaseHelper.AddParameter("@parentID", parentid);
            oDatabaseHelper.AddParameter("@parentIDinChildTable", parentIDinChildTable);
            
            oDatabaseHelper.AddParameter("@weakParentID", ChildTableID);
            oDatabaseHelper.AddParameter("@weakchildID", ChildTableIDinWeekTable);
           
			bool status = false;
			dr=oDatabaseHelper.ExecuteReader("sp_GetRelation",ref status);
			return dr;
        }

        public DataSet ExecuteDataSet(string spName, ref bool executionSucceeded)
        {
            return ExecuteDataSet(spName, CommandType.StoredProcedure, ConnectionState.CloseOnExit, ref executionSucceeded);
        }

        public DataSet ExecuteDataSet(string query, CommandType commandtype, ref bool executionSucceeded)
        {
            return ExecuteDataSet(query, commandtype, ConnectionState.CloseOnExit, ref executionSucceeded);
        }

        public DataSet ExecuteDataSet(string query, CommandType commandtype, ConnectionState connectionstate, ref bool executionSucceeded)
        {
            DbDataAdapter adapter = _AtgDb.getDataAdapter();
            objCommand.CommandText = query;
            objCommand.CommandType = commandtype;
            adapter.SelectCommand = objCommand;
            DataSet ds = new DataSet();
            try
            {
                adapter.Fill(ds);
                executionSucceeded = true;
            }
            catch (Exception ex)
            {
                executionSucceeded = false;
                HandleExceptions(ex);
            }
            finally
            {
                objCommand.Parameters.Clear();
                if (connectionstate == ConnectionState.CloseOnExit)
                {
                    if (objConnection.State == System.Data.ConnectionState.Open)
                    {
                        objConnection.Close();
                    }
                }
            }
            return ds;
        }
		
        public void Dispose()
        {
            objConnection.Close();
            objConnection.Dispose();
            objCommand.Dispose();
        }
		
		#endregion

		#region Methods (Private)
		
		private void GetConnectionInfoFromConfig(ref string strConnectionString,ref string providername)
		{
			string configFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "bin", "Ignyte.Datalayer.config");
			if (File.Exists(configFile) == false)
			    configFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Ignyte.Datalayer.config");
			XmlDocument doc = new XmlDocument();
			doc.Load(configFile);
         

			XmlNode node=doc.SelectSingleNode("/configuration/appSettings/add[@key='ConnectionStringToUse']");
			string env=node.Attributes["value"].Value;

			node=doc.SelectSingleNode(string.Format("/configuration/connectionStrings/add[@name='{0}']",env));
			
			strConnectionString=node.Attributes["connectionString"].Value;
			providername=node.Attributes["providerName"].Value;
			
		}

        private void HandleExceptions(Exception ex)
        {
            if (LogErrors)
            {
                //WriteToLog(ex.Message);
                GenericException.LogException( ex );
            }
            if (HandleErrors)
            {
                strLastError = ex.Message;
            }
            else
            {
                throw ex;
            }
        }

        private void WriteToLog(string msg)
        {
            //StreamWriter writer = File.AppendText(LogFile);
            //writer.WriteLine(DateTime.Now.ToString() + " - " + msg);
            //writer.Close();

        }
		
        private static void AssignParameterValues(DbParameter[] commandParameters, object[] parameterValues)
        {
            if ((commandParameters == null) || (parameterValues == null))
            {
                // Do nothing if we get no data
                return;
            }

            // We must have the same number of values as we pave parameters to put them in
            if (commandParameters.Length != parameterValues.Length)
            {
                throw new ArgumentException("Parameter count does not match Parameter Value count.");
            }

            // Iterate through the SqlParameters, assigning the values from the corresponding position in the 
            // value array
            for (int i = 0, j = commandParameters.Length; i < j; i++)
            {
                // If the current array value derives from IDbDataParameter, then assign its Value property
                if (parameterValues[i] is IDbDataParameter)
                {
                    IDbDataParameter paramInstance = (IDbDataParameter)parameterValues[i];
                    if (paramInstance.Value == null)
                    {
                        commandParameters[i].Value = DBNull.Value;
                    }
                    else
                    {
                        commandParameters[i].Value = paramInstance.Value;
                    }
                }
                else if (parameterValues[i] == null)
                {
                    commandParameters[i].Value = DBNull.Value;
                }
                else
                {
                    commandParameters[i].Value = parameterValues[i];
                }
            }
        }
		
		#endregion
    }

    public enum ConnectionState
    {
        KeepOpen, CloseOnExit
    }
}
