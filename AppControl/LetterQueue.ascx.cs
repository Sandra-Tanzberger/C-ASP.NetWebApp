using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using ATG;
using ATG.BusinessObject;
using ATG.Utilities.Data;
using ATG.GridHelper;
using ATG.Interface;
using AppControl;
using System.Data;


namespace AppControl
{
    public partial class LetterQueue : System.Web.UI.UserControl
    {
        //manage dropdownbox state for postbacks
        private QueueGridHelper queueGridHelper = null;
        private LetterGridHelper letterGridHelper = null;

        protected override void OnInit(EventArgs e)
        {
       
            base.OnInit(e);    
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            InitLetterSearchDropdowns();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _InitQueueGridColumns(QueueGridHelper.GridColumnList());
                _InitLetterSearchGridColumns(LetterGridHelper.GridColumnList());
                grdLetterSearch.DataSource = new DataTable();
                grdLetterSearch.DataBind();//bind to null datatable on page load to enable search buttons as grid doesn't get created without a datasource
            }
 
            //RadComboBox cboProgram = (RadComboBox)Page.FindControlRecursive("cboProgram");
            //cboProgram.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(cboProgram_SelectedIndexChanged);
        }

        protected void LetterQueue_NeedsDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            queueGridHelper = new QueueGridHelper(ATG.CommonFunc.getUserName());
            grdLetterQueue.DataSource = queueGridHelper.GridDataSource;
        }

        protected void LetterSearch_NeedsDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            RadComboBox cboProgram = (RadComboBox)Page.FindControlRecursive("cboProgram");
            RadComboBox cboLetterType = (RadComboBox)Page.FindControlRecursive("cboLetterType");
            RadComboBox cboAnniversaryMonth = (RadComboBox)Page.FindControlRecursive("cboAnniversaryMonth");
            letterGridHelper = new LetterGridHelper();
            letterGridHelper.InitializeLetterGrid(cboProgram.SelectedValue.ToString(), cboLetterType.SelectedValue.ToString(), cboAnniversaryMonth.SelectedValue.ToString());
            grdLetterSearch.DataSource = letterGridHelper.GridDataSource;
        }

        private void InitLetterSearchDropdowns()
        {
            RadComboBox cboProgram = (RadComboBox)Page.FindControlRecursive("cboProgram");
            cboProgram.DataSource = BO_Program.SelectByField("ACTIVE", "1");
            cboProgram.DataTextField = "ProgramDescription";
            cboProgram.DataValueField = "ProgramID";
            cboProgram.DataBind();

           //if (!cboProgramValue.Equals(string.Empty))
            if(Session["cboProgramValue"]!=null)
                cboProgram.SelectedValue = Session["cboProgramValue"].ToString();

            RadComboBox cboLetterType = (RadComboBox)Page.FindControlRecursive("cboLetterType");
            cboLetterType.DataSource = BO_Letter.SelectLetterTypes(cboProgram.SelectedValue);
            cboLetterType.DataBind();

            if (Session["cboLetterTypeValue"] != null)
                cboLetterType.SelectedValue = Session["cboLetterTypeValue"].ToString();

            RadComboBox cboAnniversaryMonth = (RadComboBox)Page.FindControlRecursive("cboAnniversaryMonth");
            List<string> annMonth = new List<string>();
            annMonth.Add("ALL");//allow search for all months
            annMonth.Add("JAN");annMonth.Add("FEB");annMonth.Add("MAR");annMonth.Add("APR");annMonth.Add("MAY");annMonth.Add("JUN");
            annMonth.Add("JUL");annMonth.Add("AUG");annMonth.Add("SEP");annMonth.Add("OCT");annMonth.Add("NOV");annMonth.Add("DEC");
            cboAnniversaryMonth.DataSource = annMonth;
            cboAnniversaryMonth.DataBind();

            if (Session["cboAnniverysaryMonthValue"] != null)
                cboAnniversaryMonth.SelectedValue = Session["cboAnniverysaryMonthValue"].ToString();
        }

        public void LetterQueueGridDataBind()
        {
            queueGridHelper = new QueueGridHelper(ATG.CommonFunc.getUserName());
            grdLetterQueue.DataSource = queueGridHelper.GridDataSource;
            grdLetterQueue.DataBind();
        }

        private void _InitQueueGridColumns( GridBoundColumn[] inColumnList )
        {
            //remove all but the first select checkbox column to ensure columns are not added more than once on rebind
            int colCnt = grdLetterQueue.Columns.Count;
            for (int x = colCnt; x > 2; x--)
            {
                grdLetterQueue.Columns.RemoveAt(x - 1);
            }

            foreach (GridBoundColumn tmpCol in inColumnList)
            {
                GridBoundColumn gbc = new GridBoundColumn();
                grdLetterQueue.Columns.Add(gbc);
                gbc.UniqueName = tmpCol.UniqueName;
                gbc.DataField = tmpCol.DataField;
                gbc.HeaderText = tmpCol.HeaderText;
                gbc.Visible = tmpCol.Visible;
                gbc.AllowFiltering = tmpCol.AllowFiltering;
                gbc.HeaderStyle.Width = tmpCol.HeaderStyle.Width;
            }
        }

        private void _InitLetterSearchGridColumns(GridBoundColumn[] inColumnList)
        {
            //remove all but the first select checkbox column to ensure columns are not added more than once on rebind
            int colCnt = grdLetterSearch.Columns.Count;
            for (int x = colCnt; x > 2; x--)
            {
                grdLetterSearch.Columns.RemoveAt(x - 1);
            }
            foreach (GridBoundColumn tmpCol in inColumnList)
            {
                GridBoundColumn gbc = new GridBoundColumn();
                grdLetterSearch.Columns.Add(gbc);
                gbc.UniqueName = tmpCol.UniqueName;
                gbc.DataField = tmpCol.DataField;
                gbc.HeaderText = tmpCol.HeaderText;
                gbc.Visible = tmpCol.Visible;
                gbc.AllowFiltering = tmpCol.AllowFiltering;
                gbc.HeaderStyle.Width = tmpCol.HeaderStyle.Width;
            }
        }

        protected void grdLetterQueue_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName.Equals("Print"))
            {
                if (grdLetterQueue.SelectedItems.Count > 0)
                {
                    bool printLabels = false;
                    CheckBox cboPrintLabels = (CheckBox)Page.FindControlRecursive("cbPrintLabels");
                    if (cboPrintLabels.Checked)
                    {
                        BO_LettersQueue.UpdatePrintLabels(ATG.CommonFunc.getUserName(), true);
                        printLabels = true;
                    }
                    bool printCover = false;
                    CheckBox cboPrintCover = (CheckBox)Page.FindControlRecursive("cboPrintCover");
                    if (cboPrintCover.Checked)
                    {
                        printCover = true;
                    }

                    BO_Letters letters = new BO_Letters();
                    foreach (Telerik.Web.UI.GridDataItem queueItem in grdLetterQueue.SelectedItems)
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

                    RadWin1.NavigateUrl = "~/Common/LettersReportViewerPage.aspx";
                    RadWin1.VisibleStatusbar = false;
                    RadWin1.VisibleOnPageLoad = true;
                    RadWin1.Height = Unit.Pixel(600);
                    RadWin1.Width = Unit.Pixel(800);
                    //RadWin1.Style.Add("z-index", "9999");
                    RadWin1.Behaviors = WindowBehaviors.Maximize;
                    RadWin1.Behaviors = WindowBehaviors.Close;

                    RadWin1.Modal = true;
                    RadWin1.VisibleOnPageLoad = true;
                    RadWin1.Height = Unit.Pixel(525);
                    RadWin1.Width = Unit.Pixel(730);
                    RadWin1.Title = "Print Letters";
                    RadWin1.InitialBehaviors = WindowBehaviors.Maximize;
                    RadWindowManager1.Style.Add("z-index", "9999");
                    RadWindowManager1.Behaviors = WindowBehaviors.Close;
                }
                
            }

            if (e.CommandName.Equals("Clear"))
            {
                foreach (Telerik.Web.UI.GridDataItem item in grdLetterQueue.SelectedItems)
                {
                    BO_LettersQueue.DeleteAllByKeyFields(ATG.CommonFunc.getUserName(), Convert.ToDecimal(item["ApplicationID"].Text), Convert.ToDecimal(item["LetterID"].Text));
                }
                LetterQueueGridDataBind();
            }
        }

        protected void grdLetterSearch_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName.Equals("Add"))
            {
                foreach(Telerik.Web.UI.GridDataItem searchItem in grdLetterSearch.SelectedItems)
                {
                    bool itemFound = false;
                    foreach (Telerik.Web.UI.GridDataItem queueItem in grdLetterQueue.Items)
                    {
                        if (searchItem["ApplicationID"].Text == queueItem["ApplicationID"].Text && searchItem["LetterID"].Text == queueItem["LetterID"].Text)
                        {
                            itemFound = true;
                            break;
                        }
                    }
                    if (!itemFound)
                    {
                        BO_LettersQueue letterQueue = new BO_LettersQueue(ATG.CommonFunc.getUserName(), Convert.ToDecimal(searchItem["letterID"].Text), Convert.ToDecimal(searchItem["ApplicationID"].Text), false);
                        letterQueue.Insert();
                    }
                }
                LetterQueueGridDataBind();
                RadComboBox cboProgram = (RadComboBox)Page.FindControlRecursive("cboProgram");
            }

            if (e.CommandName.Equals("Search"))
            {
                RadComboBox cboProgram = (RadComboBox)Page.FindControlRecursive("cboProgram");
                RadComboBox cboLetterType = (RadComboBox)Page.FindControlRecursive("cboLetterType");
                RadComboBox cboAnniversaryMonth = (RadComboBox)Page.FindControlRecursive("cboAnniversaryMonth");
                letterGridHelper = new LetterGridHelper();
                letterGridHelper.InitializeLetterGrid(cboProgram.SelectedValue.ToString(), cboLetterType.SelectedValue.ToString(), cboAnniversaryMonth.SelectedValue.ToString());
                grdLetterSearch.DataSource = letterGridHelper.GridDataSource;
                grdLetterSearch.DataBind();
    
            }
        }

        private DataTable RemoveDuplicates(DataTable queueDataSource)
        {
            //check current user's queue and remove any from search that are already in queue to prevent printing duplicates
            DataTable newTable = queueDataSource;
            foreach(DataRow row in newTable.Rows)
            {
                foreach (Telerik.Web.UI.GridDataItem item in grdLetterQueue.Items)
                {
                    if (row["APPLICATION_ID"].ToString() == item["ApplicationID"].Text && row["LETTER_ID"].ToString() == item["LetterID"].Text)
                    {
                         newTable.Rows.Remove(row);
                         break;
                    }
                }    
            }
            return newTable;
        }

        public void cboProgram_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            Session["cboProgramValue"] = e.Value;
        }

        public void cboLetterType_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            Session["cboLetterTypeValue"] = e.Value;
        }

        public void cboAnniversaryMonth_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            Session["cboAnniverysaryMonthValue"] = e.Value;
        }
    }
}
