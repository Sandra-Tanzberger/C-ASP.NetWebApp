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
using ATG.Database;

namespace AppControl
{
    public partial class ProgramStaffForm : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // if (!IsPostBack)
            //{
                _InitDeleteGroupsGridColumns(GroupsDeleteGridHelper.GridColumnListDeleteGroups());
                _InitAddGroupsGridColumns(GroupsGridHelper.GridColumnListAddGroups());
           // }
        }

        //update Personnel person
        public void LoadProgramStaff(decimal programStaffID)
        {
            if (!IsPostBack)
            {
                ProgramStaffID = programStaffID;

                BO_ProgramStaff programStaff = BO_ProgramStaff.SelectOne(new BO_ProgramStaffPrimaryKey(programStaffID));
                txtFirstName.Text = programStaff.FirstName;
                txtLastName.Text = programStaff.LastName;
                txtloginid.Text = programStaff.LoginID;

                btnProgramStaffUpdate.Visible = true;
                if (!String.IsNullOrEmpty(txtloginid.Text))
                {
                    GroupsGrids.Visible = true;
                }
            }
        }
        //insert Personnel person
        public void LoadProgramStaff()
        {
            if (!IsPostBack)
            {
                ProgramStaffID = 0;
                btnProgramStaffInsert.Visible = true;
            }
        }

        protected void ProgramStaff_Update(Object sender, EventArgs e)
        {
            BO_ProgramStaff programStaff = new BO_ProgramStaff();
            programStaff.ProgramStaffID = ProgramStaffID;
            programStaff.FirstName = txtFirstName.Text;
            programStaff.LastName = txtLastName.Text;
            programStaff.Active = true;
            programStaff.StaffType = "1";
            programStaff.LoginID = txtloginid.Text;
            programStaff.Update();
            btnProgramStaffInsert.Visible = false;
        }

        protected void ProgramStaff_Insert(Object sender, EventArgs e)
        {
            BO_ProgramStaff programStaff = new BO_ProgramStaff();
            programStaff.FirstName = txtFirstName.Text.Trim();
            programStaff.LastName = txtLastName.Text.Trim();
            programStaff.Active = true;
            programStaff.StaffType = "1";
            programStaff.LoginID = txtloginid.Text;

            programStaff.InsertWithDefaultValues(true);

            ProgramStaffID = (decimal)programStaff.ProgramStaffID;

            btnProgramStaffInsert.Visible = false;
            btnProgramStaffUpdate.Visible = true;
            if (!String.IsNullOrEmpty(txtloginid.Text))
            {
                GroupsGrids.Visible = true;
                grdDeleteGroups.Rebind();
                grdAddGroups.Rebind();
            }
        }

        private decimal? ProgramStaffID
        {
            get
            {
                return (decimal)ViewState["ProgramStaffID"];
            }

            set
            {
                ViewState["ProgramStaffID"] = value;
            }
        }

        private void _InitDeleteGroupsGridColumns(GridBoundColumn[] inColumnList)
        {
            foreach (GridBoundColumn tmpCol in inColumnList)
            {
                GridBoundColumn gbc = new GridBoundColumn();
                grdDeleteGroups.Columns.Add(gbc);
                gbc.UniqueName = tmpCol.UniqueName;
                gbc.DataField = tmpCol.DataField;
                gbc.HeaderText = tmpCol.HeaderText;
                gbc.Visible = tmpCol.Visible;
                gbc.AllowFiltering = tmpCol.AllowFiltering;
                gbc.HeaderStyle.Width = tmpCol.HeaderStyle.Width;
            }
        }

        private void _InitAddGroupsGridColumns(GridBoundColumn[] inColumnList)
        {
            foreach (GridBoundColumn tmpCol in inColumnList)
            {
                GridBoundColumn gbc = new GridBoundColumn();
                grdAddGroups.Columns.Add(gbc);
                gbc.UniqueName = tmpCol.UniqueName;
                gbc.DataField = tmpCol.DataField;
                gbc.HeaderText = tmpCol.HeaderText;
                gbc.Visible = tmpCol.Visible;
                gbc.AllowFiltering = tmpCol.AllowFiltering;
                gbc.HeaderStyle.Width = tmpCol.HeaderStyle.Width;
            }
        }

        protected void DeleteGroups_NeedsDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            GroupsDeleteGridHelper groupsdeleteGridHelper = new GroupsDeleteGridHelper(txtloginid.Text);
            grdDeleteGroups.DataSource = groupsdeleteGridHelper.GridDataSourceDeleteGroups;
        }

        protected void AddGroups_NeedsDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            GroupsGridHelper groupsGridHelper = new GroupsGridHelper();
            grdAddGroups.DataSource = groupsGridHelper.GridDataSourceAddGroups;
        }


        protected void grdDeleteGroups_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName.Equals("Delete"))
            {
                foreach (Telerik.Web.UI.GridDataItem item in grdDeleteGroups.SelectedItems)
                {
                    BO_ApplicationAccess.Delete(item["GroupID"].Text, txtloginid.Text);
                }
            }
        }

        protected void grdAddGroups_ItemCommand(object sender, GridCommandEventArgs e)
        {
            foreach (Telerik.Web.UI.GridDataItem item in grdAddGroups.SelectedItems)
            {
                BO_ApplicationAccess.Insert(item["GroupID"].Text, txtloginid.Text);
            }
            grdDeleteGroups.Rebind();
        }

    }

}