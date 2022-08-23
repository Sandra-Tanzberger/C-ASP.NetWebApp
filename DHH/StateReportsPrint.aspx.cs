using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;
using ATG.BusinessObject;
using ATG.Utilities.Data;
using ATG.Interface;

namespace DHH
{
    public partial class StateReportsPrint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // get the Typr of report from the Session
            string stateReportType = (string) Session["StateReportType"];
            if(string.IsNullOrEmpty(stateReportType))
                stateReportType = "PhysicalLicense";

            if (stateReportType.Equals("PhysicalLicense"))
                GeneratePhysicalLicense();
            else
                GenerateLicenseReport();
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            // Clear Session Variables
            Session["ReportParams"] = null;
        }

        /// <summary>
        /// Generate the Physical License for a given Provider Type
        /// </summary>
        private void GeneratePhysicalLicense()
        {
            // get the ProgramID from the Session
            string programID = (string)Session["ProgramID"];
            if (string.IsNullOrEmpty(programID))
                programID = "";

            BO_ProgramPrimaryKey boProgramPrimaryKey = new BO_ProgramPrimaryKey(programID);
            BO_Program boProgram = BO_Program.SelectOne(boProgramPrimaryKey);

            // Is this a licensed provider type ?
            if (boProgram != null
                && boProgram.Licensed != null && boProgram.Licensed.Equals("1"))
            {
                // get the PHYSICAL_LICENSE_REPORT lookup values 
                BO_LookupValues reportNameLookupsCollection = PhysicalLicenseNameLookups;

                string reportMessage = "A Physical License cannot be displayed for this Provider";

                // display the Physical License
                DisplayReport(reportNameLookupsCollection, programID, reportMessage );
            }
            else
            {
                labelMessage.Text = "A Physical License cannot be displayed because this Provider is not a Licensed Provider";
                RptViewer1.Visible = false;
            }
        }

        /// <summary>
        /// Generate the License Report for a given Provider type
        /// </summary>
        private void GenerateLicenseReport()
        {
            // get the ProgramID from the Session
            string programID = (string)Session["ProgramID"];
            if (string.IsNullOrEmpty(programID))
                programID = "";

            // get the PHYSICAL_LICENSE_REPORT lookup values 
            BO_LookupValues reportNameLookupsCollection = LicenseReportNameLookups ;

            string reportMessage = "A License Report cannot be displayed for this Provider";

            // display the License report
            DisplayReport(reportNameLookupsCollection, programID, reportMessage);
        }

        /// <summary>
        /// Determine the ReportName and display the report
        /// </summary>
        /// <param name="reportNameLookupsCollection"></param>
        /// <param name="programID"></param>
        /// <param name="reportMessage"></param>
        private void DisplayReport(
            BO_LookupValues reportNameLookupsCollection,string programID, string reportMessage)
        {
            string licenseReportName = "";

            foreach (BO_LookupValue tmpLV in reportNameLookupsCollection)
            {
                if (programID.Equals(tmpLV.LookupVal))
                {
                    // By default, ReportName = value from the VALDESC column
                    licenseReportName = tmpLV.Valdesc;

                    /*
                     * The "Physical License Report" has two versions
                     * - One for Providers that have Offsites
                     * - another for Providers that do NOT have Offistes
                     * - The EXTRA column in Lookup_Values stores the name of the "NoOffsite" report
                     */

                    // Check if the EXTRA column has a value
                    if (!string.IsNullOrEmpty(tmpLV.Extra))
                    {
                        /* 
                         * - Check if provider has any Offsites
                         * - If "YES", use value from the VALDESC column
                         * - If "NO", then use the value from the EXTRA column
                         */

                        // Get the Application Id from the ReportParameters
                        string appId = null;
                        ReportParameter[] parm = (ReportParameter[])Session["ReportParams"];
                        if (parm != null)
                        {
                            foreach ( ReportParameter rp in parm )
                            {
                                if (rp.Name.Equals("ApplicationID"))
                                {
                                    appId = rp.Values[0];
                                    break;
                                }
                            }
                            if(!string.IsNullOrEmpty(appId))
                            {
                                // convert to decimal
                                decimal? appId_decimal = null;
                                try
                                {
                                    appId_decimal = Decimal.Parse(appId);
                                }
                                catch (Exception ex)
                                {
                                    appId_decimal = null;
                                }
                                // get the Application object
                                BO_ApplicationPrimaryKey boApplicationPrimaryKey = new BO_ApplicationPrimaryKey(appId_decimal);
                                BO_Affiliations boAffiliations = BO_Affiliation.SelectAllByForeignKeyApplicationID(boApplicationPrimaryKey);
                                if (boAffiliations != null && boAffiliations.Count > 0)
                                {
                                    // provider has Offsites
                                    // ReportName = value from the VALDESC column
                                    licenseReportName = tmpLV.Valdesc;

                                }
                                else
                                {
                                    // provider does NOT have Offsites
                                    // ReportName = value from the EXTRA column
                                    licenseReportName = tmpLV.Extra;
                                }
                            }
                        }
                    }
                    break;
                }
            }
            if (!string.IsNullOrEmpty(licenseReportName))
            {
                RptViewer1.ShowCredentialPrompts = false;
                RptViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;

                // get the ReportServerUrl and ReportPath prefix from the Web.Config file
                StateConfig config = StateConfig.getConfigObj();
                string reportServerUrl = config.Reports.ReportServerUrl;
                string reportPath = config.Reports.ReportPath;

                RptViewer1.ServerReport.ReportServerUrl = new System.Uri(reportServerUrl);
                RptViewer1.ServerReport.ReportPath = reportPath + licenseReportName;

                // set the report parameters
                ReportParameter[] parm = (ReportParameter[])Session["ReportParams"];
                if (parm != null)
                    RptViewer1.ServerReport.SetParameters(parm);

                RptViewer1.ServerReport.Refresh();
            }
            else
            {
                labelMessage.Text = reportMessage;
                RptViewer1.Visible = false;
            }
        }


        /// <summary>
        /// Access the PHYSICAL_LICENSE_REPORT lookup values collection
        /// </summary>
        private BO_LookupValues PhysicalLicenseNameLookups
        {
            get
            {
                BO_LookupValues tmpLkups;
                if (Session["PhysicalLicenseNameLookups"] == null)
                {
                    tmpLkups = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "PHYSICAL_LICENSE_REPORT");
                    PhysicalLicenseNameLookups = tmpLkups;
                }
                else
                    tmpLkups = (BO_LookupValues)Session["PhysicalLicenseNameLookups"];

                return tmpLkups;
            }
            set
            {
                Session["PhysicalLicenseNameLookups"] = value;
            }
        }

        /// <summary>
        /// Access the LICENSE_REPORT lookup values collection
        /// </summary>
        private BO_LookupValues LicenseReportNameLookups
        {
            get
            {
                BO_LookupValues tmpLkups;
                if (Session["LicenseReportNameLookups"] == null)
                {
                    tmpLkups = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "LICENSE_REPORT");
                    LicenseReportNameLookups = tmpLkups;
                }
                else
                    tmpLkups = (BO_LookupValues)Session["LicenseReportNameLookups"];

                return tmpLkups;
            }
            set
            {
                Session["LicenseReportNameLookups"] = value;
            }
        }

    }
}
