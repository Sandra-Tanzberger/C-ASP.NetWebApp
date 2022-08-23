using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using ATG.Interface;

namespace Common
{
    public partial class report : System.Web.UI.Page
    {
        protected void Page_Load( object sender, EventArgs e )
        {
            /* 
             * NOTE: 
             * 1). The calling program needs to set a couple of Session Variables
             * 2) The following Session Paramater is REQUIRED to run this report: "ReportName"
             * 3) The following Session Paramater is OPTIONAL : "ReportParams"
             * 4)  An example of setting the Session Variables:
             *          // Begin
             *          ReportParameter[] parm = new ReportParameter[1];
             *          parm[0] = new ReportParameter("ApplicationID", appId);
             *          Session["ReportParams"] = parm;
             *          
             *          Session["ReportName"] = "HospitalLicenseReport";
             *          // End
             */

            RptViewer1.ShowCredentialPrompts = false;
            RptViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;

            // get the Name of the report from the Session
            string reportName = (string)Session["ReportName"];
            reportName = (reportName != null) ? reportName : "";

            // get the ReportServerUrl and ReportPath prefix from the Web.Config file
            StateConfig config = StateConfig.getConfigObj();
            string reportServerUrl = config.Reports.ReportServerUrl;
            string reportPath = config.Reports.ReportPath;

            ReportParameter[] parm1 = (ReportParameter[])Session["ReportParams"];
           
            // code added to accomodate two different directory reports
            //if (reportName == "DIRECTORIESREPORT")
            //{
            //    string DirectoryProgramID = parm1[0].Values[0];

            //    //switch (DirectoryProgramID)
            //    //{
            //    //    case "HO":
            //    //        reportName = "HODIRECTORIESREPORT";
            //    //        break;
            //    //    case "HC":
            //    //        reportName = "HCBSDIRECTORIESREPORT";
            //    //        break;
            //    //}
            //}            

            RptViewer1.ServerReport.ReportServerUrl = new System.Uri(reportServerUrl);
            RptViewer1.ServerReport.ReportPath = reportPath + reportName;

            // set the report parameters
            // the directories reports do not need a program id
            //if (reportName != "HODIRECTORIESREPORT" && reportName != "HCBSDIRECTORIESREPORT")
            //{
            ReportParameter[] parm = (ReportParameter[])Session["ReportParams"];
            if (parm != null)
                RptViewer1.ServerReport.SetParameters(parm);
            //}

            // display the report
            RptViewer1.ServerReport.Refresh();
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            // Clear Session Variables
            Session["ReportParams"] = null;
            Session["ReportName"] = null;
        }
    }
}
