/***********************************************************************

NAME: StateConfig, AppDBUserElement, EnvironmentElement, SqlServerElement
 
PURPOSE: Gathers State specific configuration settings from the Web.Config
         file. 

REVISIONS:

Date           Author    Description
------------   -------   ---------------------------------
01/22/2010     SMM       Created
***********************************************************************/

using System;
using System.Collections;
using System.Text;
using System.Configuration;
using System.Web.Configuration;
using System.Xml;

namespace ATG.Interface
{
    /*
     * Class Definition for SateConfig 
     */
    public class StateConfig : ConfigurationSection
    {
        private static StateConfig _m_StateConfig = null;

        /*
         * static method for initailizing the State Cofiguation object
         * 
         * @return none
         */
        public static void initialize()
        {
            if ( _m_StateConfig == null )
            {
                _m_StateConfig = (StateConfig) WebConfigurationManager.GetWebApplicationSection( "stateConfigGroup/stateConfig" );
            }

        }
        
        /*
         * static method for retrieving the State Cofiguation object
         * 
         * @return StateConfig
         */
        public static StateConfig getConfigObj()
        {
            if ( _m_StateConfig == null )
            {
                _m_StateConfig = (StateConfig) WebConfigurationManager.GetWebApplicationSection( "stateConfigGroup/stateConfig" );
            }

            return _m_StateConfig;
        }

        /*
         * Constructor
         */
        public StateConfig() 
        {
        }

        /*
         * Getter and Setter for the AppDBUserElement
         * 
         * @return AppDBUserElement
         */
        [ConfigurationProperty( "appDBUser" )]
        public AppDBUserElement AppDBUser
        {
            get
            {
                return (AppDBUserElement) this["appDBUser"];
            }
            set
            { this["appDBUser"] = value; }
        }

        /*
         * Getter and Setter for the EnvironmentElement
         * 
         * @return EnvironmentElement
         */
        [ConfigurationProperty( "environment" )]
        public EnvironmentElement Environment
        {
            get
            {
                return (EnvironmentElement) this["environment"];
            }
            set
            { this["environment"] = value; }
        }

        /*
         * Getter and Setter for the SqlServerElement
         * 
         * @return SqlServerElement
         */
        [ConfigurationProperty( "sqlServer" )]
        public SqlServerElement SqlServer
        {
            get
            {
                return (SqlServerElement) this["sqlServer"];
            }
            set
            { this["sqlServer"] = value; }
        }

        /*
         * Getter and Setter for the ReportsElement
         * 
         * @return ReportsElement
         */
        [ConfigurationProperty("reports")]
        public ReportsElement Reports
        {
            get
            {
                return (ReportsElement)this["reports"];
            }
            set
            { this["reports"] = value; }
        }

    }

    /*
     * Class Definition of the AppDBUserElement and the getters/setters for its attributes 
     */
    public class AppDBUserElement : ConfigurationElement
    {
        /*
         * Getter and Setter for the UserName to be used by the application when connecting
         * the specified database
         * 
         * @return String UserName
         */
        [ConfigurationProperty( "login", DefaultValue = "DEV", IsRequired = true )]
        public String UserName
        {
            get
            {
                return (String) this["login"];
            }
            set
            {
                this["login"] = value;
            }
        }

        /*
         * Getter and Setter for the User password to be used by the application when connecting
         * the specified database
         * 
         * @return String UserPass
         */
        [ConfigurationProperty( "pass", IsRequired = true )]
        public String UserPass
        {
            get
            { return (String) this["pass"]; }
            set
            { this["pass"] = value; }
        }
    }

    /*
     * Definition of the EnvironmentElement and the getters/setters for its attributes 
     */
    public class EnvironmentElement : ConfigurationElement
    {
        /*
         * Getter and Setter for the target platform to be used by the application when connecting
         * the specified database
         * 
         * @return String Target (DEV/UAT/PROD)
         */
        [ConfigurationProperty( "target", DefaultValue = "DEV", IsRequired = true )]
        public String Target
        {
            get
            {
                return (String) this["target"];
            }
            set
            {
                this["target"] = value;
            }
        }

        /*
         * Getter and Setter for the Debug Flag. WHere checked by the application additional output 
         * may be logged for the purpose of evaluation of errors/bugs
         * 
         * @return bool Debug
         */
        [ConfigurationProperty( "debug", DefaultValue = "false", IsRequired = true )]
        public bool Debug
        {
            get
            {
                return (bool) this["debug"];
            }
            set
            {
                this["debug"] = value;
            }
        }
    }

    /*
     * Definition of the SqlServerElement and the getters/setters for its attributes 
     */
    public class SqlServerElement : ConfigurationElement
    {
        /*
         * Getter and Setter for the Data Source to be used by the application. Value specified should be
         * in the form of "SERVER\INSTANCE"
         * 
         * @return String DataSource
         */
        [ConfigurationProperty( "dataSource", DefaultValue = "DEV", IsRequired = true )]
        public String DataSource
        {
            get
            {
                return (String) this["dataSource"];
            }
            set
            {
                this["dataSource"] = value;
            }
        }

        /*
         * Getter and Setter for the database within the DataSource to be used by the application.
         * 
         * @return String DefaultDB
         */
        [ConfigurationProperty( "defaultDB", DefaultValue = "", IsRequired = true )]
        public String DefaultDB
        {
            get
            {
                return (String) this["defaultDB"];
            }
            set
            {
                this["defaultDB"] = value;
            }
        }
    }

    /*
     * Class Definition of the ReportsElement and the getters/setters for its attributes 
     * Appears in the Web.Config as :
     * <reports reportServerUrl="http://ladev/AppReportServer" reportPath="/REPORTS/" />
     */
    public class ReportsElement : ConfigurationElement
    {
        /*
         * Getter and Setter for the ReportServerUrl to be used by the application when connecting
         * the specified Report Server
         * 
         * @return String ReportServerUrl
         */
        [ConfigurationProperty("reportServerUrl", DefaultValue = "http://ladev/AppReportServer", IsRequired = true)]
        public String ReportServerUrl
        {
            get
            {
                return (String)this["reportServerUrl"];
            }
            set
            {
                this["reportServerUrl"] = value;
            }
        }

        /*
         * Getter and Setter for the Reports Folder Path where reports are located on the Report Server
         * 
         * @return String ReportPath
         */
        [ConfigurationProperty("reportPath", DefaultValue = "/REPORTS/", IsRequired = true)]
        public String ReportPath
        {
            get
            { return (String)this["reportPath"]; }
            set
            { this["reportPath"] = value; }
        }
    }

}