/***********************************************************************

NAME: AtgDatabase
 
PURPOSE: Database controller class.

REVISIONS:

Date           Author    Description
------------   -------   ---------------------------------
01/22/2010     SMM       Created
***********************************************************************/

using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Web.Configuration;
using ATG.ErrorLogging;
using ATG.Interface;

namespace ATG.Database
{
    public enum SRC_DB
    {
        SQL_SERVER,
        ORACLE,
        OLEDB,
        ODBC,
        CONFIG_DEFINED
    }

//    public enum Providers
//    {
//        SqlServer, OleDb, ODBC, ConfigDefined
//    }
    
    public class AtgDatabase
    {
        private string _strConnectionString;
        //private DbConnection _objConnection;
        //private DbCommand _objCommand;
        private DbProviderFactory _objFactory = null;

        /*
         * Constructor 
         */
        public AtgDatabase() {
        }

        /*
         * Get the Connection string for the database to be used for connection. 
         */
        public string _GetConnectionString( SRC_DB inSourceDB )
        {
            String tmpConnectionStr = "";            
            StateConfig config = StateConfig.getConfigObj();

            switch (inSourceDB)
            {
                case SRC_DB.ORACLE:
                    //get Oracle connection string from web.config
                    //return WebConfigurationManager.ConnectionStrings["ORA_AppConString"].ConnectionString;
                    tmpConnectionStr += "Persist Security Info=True;";
                    tmpConnectionStr += "Password=mdsdbax;";
                    tmpConnectionStr += "User ID=mdsdba;";
                    tmpConnectionStr += "Data Source=mdsdb;";
                    break;
                case SRC_DB.SQL_SERVER:
                    tmpConnectionStr += "Persist Security Info=True;";
                    tmpConnectionStr += "Password=" + config.AppDBUser.UserPass + ";";
                    tmpConnectionStr += "User ID=" + config.AppDBUser.UserName + ";";
                    tmpConnectionStr += "Initial Catalog=" + config.SqlServer.DefaultDB + ";";
                    tmpConnectionStr += "Data Source=" + config.SqlServer.DataSource + ";";
                    break;
                default:
                    break;   //return empty string - SMM TODO Handle with exception
            }

            return tmpConnectionStr;
        
        }

        public Boolean TestDBConnection()
        {
            Boolean retVal = false;

            SqlConnection con = GetSqlServerConnection();

            try
            {
                con.Open();
                retVal = true;
            }
            catch ( Exception ex )
            {
                GenericException.LogException( ex );
            }
            finally
            {
                con.Close();
            }

            return retVal;
        }

        public void InitProvider( SRC_DB inSrcDB )
        {
            _strConnectionString = _GetConnectionString( inSrcDB );
            switch ( inSrcDB )
            {
                case SRC_DB.SQL_SERVER:
                    _objFactory = SqlClientFactory.Instance;
                    break;
                case SRC_DB.OLEDB:
                    _objFactory = OleDbFactory.Instance;
                    break;
                case SRC_DB.ORACLE:
                    _objFactory = OracleClientFactory.Instance;
                    break;
                case SRC_DB.ODBC:
                    _objFactory = OdbcFactory.Instance;
                    break;
                /* TODO - SMM - Added configuration definitions for this and oracle client
                case SRC_DB.CONFIG_DEFINED:
                    string providername = "";
                    if ( connectionstring == "" )
                    {
                        if ( !string.IsNullOrEmpty( ConnectionStringHnalder ) )
                            connectionstring = ConnectionStringHnalder;
                        else
                        {
                            //Get connection information
                            GetConnectionInfoFromConfig( ref strConnectionString, ref providername );
                            ConnectionStringHnalder = strConnectionString;
                        }
                    }
                    else
                    {
                        ConnectionStringHnalder = connectionstring;
                        providername = ConfigurationManager.ConnectionStrings["connectionstring"].ProviderName;
                    }
                    switch ( providername )
                    {
                        case "System.Data.SqlClient":
                            _objFactory = SqlClientFactory.Instance;
                            break;
                        case "System.Data.OleDb":
                            _objFactory = OleDbFactory.Instance;
                            break;
                        case "System.Data.Odbc":
                            _objFactory = OdbcFactory.Instance;
                            break;
                    }
                    break;
                    */
            }
        }

        public DbConnection getConnection()
        {
            return _objFactory.CreateConnection();
        }

        public DbCommand getCommand()
        {
            return _objFactory.CreateCommand();
        }

        public string getConnectionString()
        {
            return _strConnectionString;
        }

        public DbParameter getParameter()
        {
            return _objFactory.CreateParameter();
        }

        public DbDataAdapter getDataAdapter()
        {
            return _objFactory.CreateDataAdapter();
        }
        /*
         * Get a connection to the Oracle Server.
         */
        public OracleConnection GetOracleConnection() 
        {
            return new OracleConnection( _GetConnectionString( SRC_DB.ORACLE ) );
        }

        /*
         * Get a coneection to the SQL Server. 
         */
        public SqlConnection GetSqlServerConnection()
        {
            return new SqlConnection( _GetConnectionString(SRC_DB.SQL_SERVER));
        }

        /*
         * Get a DataTable from the requested Source DB using supplied SQL Statement.
         */
        public DataTable GetDataTable(string inSql, SRC_DB inSourceDB)
        {
            DataSet ds = new DataSet();

            switch (inSourceDB)
            {
                case SRC_DB.ORACLE:
                    using (OracleConnection connection = GetOracleConnection())
                    {
                        OracleCommand cmd = new OracleCommand( inSql );
                        cmd.Connection = connection;
                        
                        connection.Open();
                        OracleDataAdapter da = new OracleDataAdapter( cmd );
                        da.Fill(ds);
                        cmd.Dispose();
                    }
                    break;
                case SRC_DB.SQL_SERVER:
                    using ( SqlConnection connection = GetSqlServerConnection() )
                    {
                        SqlCommand cmd = new SqlCommand( inSql );
                        cmd.Connection = connection;

                        connection.Open();
                        SqlDataAdapter da = new SqlDataAdapter( cmd );
                        da.Fill(ds);
                        cmd.Dispose();
                    }
                    break;
                default:
                    //return DataSet - SMM TODO Handle with exception
                    break;
            }

            return ds.Tables[0];
        }

        /**
         * Execute an sql statement - INSERT, UPDATE, or DELETE. 
         * Not to be used for SELECT as the results are not retrieved 
         * or returned. Use GetDataTable() method.
         */
        public int Execute( string inSql, SRC_DB inSourceDB ) {
            try 
            {
                switch (inSourceDB)
                {
                    case SRC_DB.ORACLE:
                        using (OracleConnection connection = GetOracleConnection())
                        {
                            OracleCommand cmd = new OracleCommand( inSql, connection );
                            cmd.Connection.Open();
                            return cmd.ExecuteNonQuery();
                        }
                    case SRC_DB.SQL_SERVER:
                        using (SqlConnection connection = GetSqlServerConnection())
                        {
                            SqlCommand cmd = new SqlCommand( inSql, connection );
                            cmd.Connection.Open();
                            return cmd.ExecuteNonQuery();
                        }
                }
            }
            catch (Exception ex)
            {
                GenericException.LogException ( ex );
            }
            
            return 0;
            
        }

    }
}