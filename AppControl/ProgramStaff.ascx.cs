using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using ATG;
using ATG.BusinessObject;
using ATG.GridHelper;

namespace AppControl
{
    public partial class ProgramStaff : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _InitProgramStaffGridColumns(ProgramStaffGridHelper.GridColumnList());
            }
        }

        protected void ProgramStaffGrid_NeedsDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            ProgramStaffGridHelper programStaffGridHelper = new ProgramStaffGridHelper();
            programStaffGridHelper.InitializeProgramStaffGrid();
            grdProgramStaff.DataSource = programStaffGridHelper.GridDataSource;
        }

        protected void grdProgramStaff_ItemCommand(object sender, GridCommandEventArgs e)
        {
            string programStaffID = "";

            if (e.CommandName.Equals("Add"))
            {
                RadWinProgramStaff.NavigateUrl = "~/Common/EditForm/ProgramStaffForm.aspx?programstaffid=";
                RadWinProgramStaff.VisibleStatusbar = false;
                RadWinProgramStaff.VisibleOnPageLoad = true;
                //RadWinPersonnel.Height = Unit.Pixel(600);
                //RadWinPersonnel.Width = Unit.Pixel(800);

                RadWinProgramStaff.Modal = true;
                RadWinProgramStaff.VisibleOnPageLoad = true;
                //RadWinPersonnel.Height = Unit.Pixel(525);
                //RadWinPersonnel.Width = Unit.Pixel(730);
                RadWinProgramStaff.Title = "Add Program Staff";
                RadWindowManagerProgramStaff.Style.Add("z-index", "9999");
                RadWindowManagerProgramStaff.Behaviors = WindowBehaviors.Close;
                RadWindowManagerProgramStaff.InitialBehaviors = WindowBehaviors.Maximize;
            }

            if (grdProgramStaff.SelectedItems.Count > 0)
            {
                foreach (Telerik.Web.UI.GridDataItem item in grdProgramStaff.SelectedItems)
                {
                    programStaffID = item["ProgramStaffID"].Text;
                }

                if (e.CommandName.Equals("Edit"))
                {
                    RadWinProgramStaff.NavigateUrl = "~/Common/EditForm/ProgramStaffForm.aspx?programstaffid=" + programStaffID;
                    RadWinProgramStaff.VisibleStatusbar = false;
                    RadWinProgramStaff.VisibleOnPageLoad = true;
                    //RadWinPersonnel.Height = Unit.Pixel(600);
                    //RadWinPersonnel.Width = Unit.Pixel(800);

                    RadWinProgramStaff.Modal = true;
                    RadWinProgramStaff.VisibleOnPageLoad = true;
                    //RadWinPersonnel.Height = Unit.Pixel(525);
                    //RadWinPersonnel.Width = Unit.Pixel(730);
                    RadWinProgramStaff.Title = "Edit Program Staff";
                    RadWindowManagerProgramStaff.Style.Add("z-index", "9999");
                    RadWindowManagerProgramStaff.Behaviors = WindowBehaviors.Close;
                    RadWindowManagerProgramStaff.InitialBehaviors = WindowBehaviors.Maximize;
                }

                if (e.CommandName.Equals("Delete"))
                {
                    //custom dev., need to create stored procedure to only delete driver persons from the application/provider_person record unless that person record does not belong to any other applications.
                    BO_ProgramStaff _programStaff = new BO_ProgramStaff();
                    _programStaff.ProgramStaffID = Convert.ToDecimal(programStaffID);
                    _programStaff.Delete();
                    ProgramStaffGridDataBind();
                }
            }

            if (e.CommandName.Equals("Rebind"))
            {
                ProgramStaffGridDataBind();
            }
        }

        public void ProgramStaffGridDataBind()
        {
            ProgramStaffGridHelper programStaffGridHelper = new ProgramStaffGridHelper();
            programStaffGridHelper.InitializeProgramStaffGrid();
            grdProgramStaff.DataSource = programStaffGridHelper.GridDataSource;
            grdProgramStaff.DataBind();
        }

        private void _InitProgramStaffGridColumns(GridBoundColumn[] inColumnList)
        {
            foreach (GridBoundColumn tmpCol in inColumnList)
            {
                GridBoundColumn gbc = new GridBoundColumn();
                grdProgramStaff.Columns.Add(gbc);
                gbc.UniqueName = tmpCol.UniqueName;
                gbc.DataField = tmpCol.DataField;
                gbc.HeaderText = tmpCol.HeaderText;
                gbc.Visible = tmpCol.Visible;
                gbc.AllowFiltering = tmpCol.AllowFiltering;
                gbc.HeaderStyle.Width = tmpCol.HeaderStyle.Width;
            }
        }
    }
}