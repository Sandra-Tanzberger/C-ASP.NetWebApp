using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ATG;
using ATG.BusinessObject;
using ATG.Utilities.Data;
using Telerik.Web.UI;

namespace AppControl
{
    public partial class ApplicationPrint : System.Web.UI.UserControl
    {
        private DataTable _gridDataSource;
        string appID = "";
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (!IsPostBack)
                _InitGridColumns();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            appID = Request.QueryString["PrintKey"].ToString();
        }

        public void ReBindGrid()
        {
            BO_Application application = BO_Application.SelectOne(new BO_ApplicationPrimaryKey(Convert.ToDecimal(appID)));
            grdAppLetters.DataSource = _getGridDataSource(BO_Letter.SelectByProgram(application.ProgramID, ""), application);
            grdAppLetters.DataBind();
        }

        protected void grdAppLetters_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            BO_Application application = BO_Application.SelectOne(new BO_ApplicationPrimaryKey(Convert.ToDecimal(this.appID)));
            grdAppLetters.DataSource = _getGridDataSource(BO_Letter.SelectByProgram(application.ProgramID, ""), application);
        }

        protected void grdAppLetters_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName.Equals("Print"))
            {
                if (grdAppLetters.SelectedItems.Count > 0)
                {
                    bool printLabels = false;
                    CheckBox cboPrintLabels = (CheckBox)Page.FindControlRecursive("cboPrintLabels");
                    if (cboPrintLabels.Checked)
                    {
                        //BO_LettersQueue.UpdatePrintLabels(ATG.CommonFunc.getUserName(), true);
                        printLabels = true;
                    }
                    bool printCover = false;
                    CheckBox cboPrintCover = (CheckBox)Page.FindControlRecursive("cboPrintCover");
                    if (cboPrintCover.Checked)
                    {
                        printCover = true;
                    }

                    BO_Letters letters = new BO_Letters();
                    foreach (Telerik.Web.UI.GridDataItem queueItem in grdAppLetters.SelectedItems)
                    {
                        BO_Letter letter = new BO_Letter();
                        letter.ApplicationID = Convert.ToDecimal(queueItem["ApplicationID"].Text);
                        letter.LetterDisplayName = queueItem["LetterName"].Text.ToString();
                        letter.LetterID = Convert.ToDecimal(queueItem["LetterID"].Text);
                        letter.ReportName = queueItem["ReportName"].Text.ToString();
                        letters.Add(letter);
                    }

                    Session["LetterQueue"] = letters;
                    Session["PrintLabels"] = printLabels;
                    Session["PrintCover"] = printCover;

                    RadWindow newwindow = new RadWindow();
                    newwindow.ID = "RadWindowAppPrint";
                    newwindow.NavigateUrl = "~/Common/LettersReportViewerPage.aspx";
                    newwindow.VisibleStatusbar = false;
                    newwindow.VisibleOnPageLoad = true;
                    newwindow.Title = "Print Letters";
                    AppPrintRadWinMan.Windows.Add(newwindow);
                    AppPrintRadWinMan.Style.Add("z-index", "9999");
                    AppPrintRadWinMan.Behaviors = WindowBehaviors.Close;
                    AppPrintRadWinMan.InitialBehaviors = WindowBehaviors.Maximize;
                }
                
            }


            if (e.CommandName.Equals("Queue"))
            {
                foreach (Telerik.Web.UI.GridDataItem queueItem in grdAppLetters.SelectedItems)
                {
                    BO_LettersQueue letterQueue = new BO_LettersQueue(ATG.CommonFunc.getUserName(), Convert.ToDecimal(queueItem["letterID"].Text), Convert.ToDecimal(queueItem["ApplicationID"].Text), false);
                    letterQueue.Insert();
                }

                ReBindGrid();
            }
        }

        public DataTable GridDataSource
        {
            set { _gridDataSource = value; }
            get { return _gridDataSource; }
        }

        private void _InitGridColumns()
        {
            //remove all but the first select checkbox column to ensure columns are not added more than once on rebind
            int colCnt = grdAppLetters.Columns.Count;
            for (int x = colCnt; x > 2; x--)
            {
                grdAppLetters.Columns.RemoveAt(x - 1);
            }

            GridBoundColumn col1 = new GridBoundColumn();
            grdAppLetters.Columns.Add(col1);
            col1.UniqueName = "ApplicationID";
            col1.DataField = "APPLICATION_ID";
            col1.HeaderText = "Application ID";
            col1.Visible = false;
            col1.HeaderStyle.Width = Unit.Percentage(0);
            col1.AllowFiltering = false;


            GridBoundColumn col2 = new GridBoundColumn();
            grdAppLetters.Columns.Add(col2);
            col2.UniqueName = "FacilityName";
            col2.DataField = "FACILITY_NAME";
            col2.HeaderText = "Facility";
            col2.Visible = false;
            col2.HeaderStyle.Width = Unit.Percentage(0);
            col2.AllowFiltering = false;

            GridBoundColumn col3 = new GridBoundColumn();
            grdAppLetters.Columns.Add(col3);
            col3.UniqueName = "LetterType";
            col3.DataField = "LETTER_TYPE";
            col3.HeaderText = "Letter Type";
            col3.Visible = true;
            col3.HeaderStyle.Width = Unit.Percentage(30);
            col3.AllowFiltering = false;

            GridBoundColumn col4 = new GridBoundColumn();
            grdAppLetters.Columns.Add(col4);
            col4.UniqueName = "LetterName";
            col4.DataField = "LETTER_DISPLAY_NAME";
            col4.HeaderText = "Letter Name";
            col4.Visible = true;
            col4.HeaderStyle.Width = Unit.Percentage(70);
            col4.AllowFiltering = false;

            GridBoundColumn col5 = new GridBoundColumn();
            grdAppLetters.Columns.Add(col5);
            col5.UniqueName = "LetterID";
            col5.DataField = "LETTER_ID";
            col5.HeaderText = "Letter ID";
            col5.Visible = false;
            col5.HeaderStyle.Width = Unit.Percentage(0);
            col5.AllowFiltering = false;

            GridBoundColumn col6 = new GridBoundColumn();
            grdAppLetters.Columns.Add(col6);
            col6.UniqueName = "ReportName";
            col6.DataField = "REPORT_NAME";
            col6.HeaderText = "Report Name";
            col6.Visible = false;
            col6.HeaderStyle.Width = Unit.Percentage(0);
            col6.AllowFiltering = false;
        }

        private DataTable _getGridDataTableStruct()
        {
            DataTable tmpDTbl = new DataTable();
            DataColumn tmpDCol = null;

            tmpDCol = new DataColumn("APPLICATION_ID");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("FACILITY_NAME");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("LETTER_TYPE");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("LETTER_DISPLAY_NAME");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("LETTER_ID");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("REPORT_NAME");
            tmpDTbl.Columns.Add(tmpDCol);

            return tmpDTbl;
        }

        private DataTable _getGridDataSource(BO_Letters availableLetters, BO_Application application)
        {
            DataTable retTable = _getGridDataTableStruct();

            foreach (BO_Letter letter in availableLetters)
             {
                 bool letterFound = false;
                 BO_LettersQueue currentQueue = new BO_LettersQueue(ATG.CommonFunc.getUserName());
                 BO_Letters currentQueueLetters = currentQueue.Letters;
                 foreach (BO_Letter currentQueueLetter in currentQueueLetters)
                 {
                     if (letter.LetterID == currentQueueLetter.LetterID && currentQueueLetter.ApplicationID == application.ApplicationID)
                         letterFound = true;
                 }
                 if (!letterFound)
                 {
                     if (!(letter.LetterType.ToLower().Replace(" ","").Contains("physicallicense") && !application.ApplicationStatus.Equals("4")))
                     {

                         DataRow tmpDR = retTable.NewRow();
                         tmpDR["APPLICATION_ID"] = application.ApplicationID;
                         tmpDR["FACILITY_NAME"] = letter.FacilityName;
                         tmpDR["LETTER_TYPE"] = letter.LetterType;
                         tmpDR["LETTER_DISPLAY_NAME"] = letter.LetterDisplayName;
                         tmpDR["LETTER_ID"] = letter.LetterID;
                         tmpDR["REPORT_NAME"] = letter.ReportName;

                         retTable.Rows.Add(tmpDR);
                     }
                 }
             }

            return HandleOffsites(application, retTable);
        }

        private DataTable HandleOffsites(BO_Application application, DataTable table)
        {
            if (OffsiteFound(table))
            {
                string licenseToRemove = "";
                if (application.BO_AffiliationsApplicationIDFilteredByClosedDate.Count > 0) //has offsites
                    licenseToRemove = "physicallicensenooffsite";
                else
                    licenseToRemove = "physicallicense";

                foreach (DataRow row in table.Rows)
                {
                    if (row["LETTER_TYPE"].ToString().ToLower().Replace(" ", "") == licenseToRemove)
                    {
                        table.Rows.Remove(row); // if found drop out of loop - once altered table loop will break
                        break;
                    }
                }
            }

            return table;
        }

        private bool OffsiteFound(DataTable table)
        {
            bool offsiteFound = false;
            foreach(DataRow row in table.Rows)
                if (row["LETTER_TYPE"].ToString().ToLower().Replace(" ", "")=="physicallicensenooffsite")
                    offsiteFound = true;

            return offsiteFound;
        }

    }
}