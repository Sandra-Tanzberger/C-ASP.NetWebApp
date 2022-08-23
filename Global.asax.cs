using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using ATG;
using ATG.BusinessObject;
using ATG.ErrorLogging;
using ATG.Interface;
using ATG.Security;

namespace State
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start( object sender, EventArgs e )
        {
            //Initialize State configuration Object
            StateConfig.initialize();
            Application["Default_Height"] = 600;

            //Load static lists
            //States
            DataTable tmpStateWorkingTbl = new DataTable();
            DataColumn tmpSTDCol = null;

            tmpSTDCol = new DataColumn( "StateCode" );
            tmpStateWorkingTbl.Columns.Add( tmpSTDCol );
            tmpSTDCol = new DataColumn( "StateName" );
            tmpStateWorkingTbl.Columns.Add( tmpSTDCol );

            BO_States tmpBOST = BO_State.SelectAll();
            
            foreach ( BO_State boST in tmpBOST )
            {
                DataRow tmpRW = tmpStateWorkingTbl.NewRow();

                tmpRW["StateCode"] = boST.StateCode;
                tmpRW["StateName"] = boST.StateName;

                tmpStateWorkingTbl.Rows.Add( tmpRW );
            }

            Application["STATES_LIST"] = tmpStateWorkingTbl;
            
            //City, County and Zip
            DataTable tmpCityCountZipWorkingTbl = new DataTable();
            DataColumn tmpDCol = null;

            tmpDCol = new DataColumn( "StateCode" );
            tmpCityCountZipWorkingTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "StateName" );
            tmpCityCountZipWorkingTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "Zip" );
            tmpCityCountZipWorkingTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "County" );
            tmpCityCountZipWorkingTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "Cntyname" );
            tmpCityCountZipWorkingTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "City" );
            tmpCityCountZipWorkingTbl.Columns.Add( tmpDCol );
            
            BO_Ziplookups tmpLkups = BO_Ziplookup.SelectAll();

            foreach ( BO_Ziplookup boZL in tmpLkups )
            {
                DataRow tmpRW = tmpCityCountZipWorkingTbl.NewRow();

                DataRow[] tmpRows = tmpStateWorkingTbl.Select( "StateCode = '" + boZL.StateCode + "'" );
                string tmpStateFullName = "";

                foreach ( DataRow tmpRw in tmpRows )
                {
                    tmpStateFullName = tmpRw["StateName"].ToString(); ;
                }

                tmpRW["StateCode"] = boZL.StateCode;
                tmpRW["StateName"] = tmpStateFullName;
                tmpRW["Zip"] = boZL.Zip;
                tmpRW["County"] = boZL.County;
                tmpRW["Cntyname"] = boZL.Cntyname;
                tmpRW["City"] = boZL.City;

                tmpCityCountZipWorkingTbl.Rows.Add( tmpRW );
            }
            
            Application["CITY_COUNTY_ZIP_LIST"] = tmpCityCountZipWorkingTbl;
        }

        protected void Session_Start( object sender, EventArgs e )
        {
            Session.Add("User", new User(CommonFunc.getUserName()));//GCARTER=PBG, JMALBRUE=SUR
            //HttpContext.Current.Session.Add("User", new User("GCARTER"));
        }

        protected void Application_BeginRequest( object sender, EventArgs e )
        {

        }

        protected void Application_AuthenticateRequest( object sender, EventArgs e )
        {
            String test = "test";
        }

        protected void Application_Error( object sender, EventArgs e )
        {
            Exception ex = Server.GetLastError().GetBaseException();
            Type exceptionType = ex.GetType();
            String message = ex.Message + "\r\n - " + ex.StackTrace;
            System.Exception innerException = ex.InnerException;
            while (innerException != null)
            {
                message += "\r\n\r\n" + innerException.Message + "\r\n - " + innerException.StackTrace;
                innerException = innerException.InnerException;
            }

            System.Diagnostics.EventLog appLog = new System.Diagnostics.EventLog();
            appLog.Source = "POPS State Web Application";
            appLog.WriteEntry(message, System.Diagnostics.EventLogEntryType.Error);
        }

        protected void Session_End( object sender, EventArgs e )
        {

        }

        protected void Application_End( object sender, EventArgs e )
        {

        }
    }
}