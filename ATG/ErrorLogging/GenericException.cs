using System;
using System.IO;
using System.Web;
using System.Data.SqlClient;
using ATG.Database;

namespace ATG.ErrorLogging 
{
    /// <summary>
    /// Summary description for GenericException
    /// </summary>
    public class GenericException : Exception {

        //private static AtgDatabase _m_AtgDb = null;

        public static void LogException( Exception inException )
        {
            Type exceptionType = inException.GetType();
            String message = inException.Message + "\r\n - " + inException.StackTrace;
            System.Exception innerException = inException.InnerException;
            while (innerException != null) {
                message += "\r\n\r\n" + innerException.Message + "\r\n - " + innerException.StackTrace;
                innerException = innerException.InnerException;
            }

            if ( message.Length < 1 )
                message = "An unknown exception occured.";

            WriteException( exceptionType.ToString(), message );
        }

        public GenericException() {
        }

        private static void WriteException( String inExceptionType, String inMsg )
        {
            // rjc - 11/21/2012 - previous version was not properly disposing of database
            // resources. also did not properly deal with special chars (i.e. quotes) in the parameters.

            /*if ( null == _m_AtgDb )
            {
                _m_AtgDb = new AtgDatabase();
                _m_AtgDb.InitProvider( SRC_DB.SQL_SERVER );
            }

            DateTime tmpDT = DateTime.Now;
            SqlConnection con = _m_AtgDb.GetSqlServerConnection();

            try
            {
                con.Open();
                _m_AtgDb.Execute( "Insert into error_log ( ERROR_CD, ERROR_MSG ) values ( \'" + inExceptionType + "\',\'" + inMsg + "\')"
                                    , SRC_DB.SQL_SERVER );
            }*/
            bool success = true;
            string exMessage = "";
            try {
                using (DatabaseHelper db = new DatabaseHelper()) {
                    //db.ExecuteNonQuery("Insert into error_log ( ERROR_CD, ERROR_MSG ) values ( \'" + inExceptionType + "\',\'" + inMsg + "\')", System.Data.CommandType.Text, ref success);
                    db.AddParameter("@ErrorCode", inExceptionType.Substring(0, Math.Min(255, inExceptionType.Length)));
                    db.AddParameter("@ErrorMessage", inMsg.Substring(0, Math.Min(1000, inMsg.Length)));
                    db.ExecuteScalar("Insert into error_log ( ERROR_CD, ERROR_MSG ) values ( @ErrorCode, @ErrorMessage )", System.Data.CommandType.Text, ref success);
                }
            }
            catch ( Exception ex )
            {
                success = false;
                exMessage = ex.Message;
            }
            finally
            {
                //con.Close();

                // try to log to file if unable to log to database
                if (!success) {
                    try {
                        string sPath = HttpContext.Current.Server.MapPath("/Logs");
                        string errLogName = "\\\\error_";
                        DateTime tmpDT = DateTime.Now;
                        errLogName += tmpDT.Month.ToString();
                        errLogName += tmpDT.Day.ToString();
                        errLogName += tmpDT.Year.ToString();
                        errLogName += tmpDT.Millisecond.ToString();
                        errLogName += ".log";

                        //FileStream myFS = new FileStream( sPath + errLogName, FileMode.CreateNew );
                        using (StreamWriter sw = new StreamWriter(sPath + errLogName)) {
                            // Add some text to the file.
                            sw.WriteLine("Unable to log exception to database: LALIC \r\n");
                            sw.WriteLine(tmpDT.ToString());
                            sw.WriteLine("\r\n-------------------\r\n");
                            // Arbitrary objects can also be written to the file.
                            sw.WriteLine("Logged to file Cause: " + exMessage);
                            sw.WriteLine("Original Error to log: " + inExceptionType + "\r\n\r\n");
                            sw.WriteLine("Original Error Stack: " + inMsg);
                        }
                    }
                    catch (Exception) {
                    }
                }
            }
        }

        public static void LogToErrorTable( string inErrCd, string inMsg )
        {
            WriteException( inErrCd, inMsg );
        }

    }
}