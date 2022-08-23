using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATG;
using ATG.BusinessObject;
using Telerik.Web.UI;

namespace AppControl
{
    public partial class KeyPersonnelEditForm : System.Web.UI.UserControl
    {
        protected void Page_Load( object sender, EventArgs e )
        {
        }

        public void LoadPerson( decimal inPersonID, bool inAllowEdit )
        {
            AllowEdit = inAllowEdit;

            if ( CurrentAppProvider != null && CurrentKeyPersonnelList != null )
            {
                BO_Person tmpPerson = null;
                BO_ProviderPerson tmpProvPers = null;

                //if ( !IsNewRecord )
                //{
                    foreach ( BO_ProviderPerson boPrvdrPers in CurrentKeyPersonnelList )
                    {
                        if ( boPrvdrPers.PersonID.Equals( inPersonID ) && boPrvdrPers.PersonType.Equals( PersonType ) )
                        {
                            tmpPerson = boPrvdrPers.BO_PersonDetail;
                            break;
                        }
                    }
                //}

                if ( null == tmpPerson )
                {
                    tmpPerson = new BO_Person();
                    tmpProvPers = new BO_ProviderPerson();
                    tmpPerson.IsNewRec = true;
                    tmpProvPers.IsNewRec = true;
                    tmpPerson.PersonID = 0;
                    tmpPerson.UI_TrackID = "N" + CurrentKeyPersonnelList.Count();
                    tmpProvPers.PersonID = 0;
                    tmpProvPers.UI_TrackID = "N" + CurrentKeyPersonnelList.Count();
                    tmpPerson.BO_EducationsPersonID = new BO_Educations();
                    tmpPerson.BO_EmploymentsPersonID = new BO_Employments();
                    tmpProvPers.BO_PersonDetail = tmpPerson;
                    tmpProvPers.PersonType = PersonType;
                    CurrentKeyPersonnelList.Add( tmpProvPers );
                }

                //SMM 01/22/2012- Removed Title case conversion
                //txtKPFirstName.Text = CommonFunc.ConvertToTitleCase( tmpPerson.FirstName );
                //txtKPMiddleInitial.Text = CommonFunc.ConvertToTitleCase( tmpPerson.MiddleInitial );
                //txtKPLastName.Text = CommonFunc.ConvertToTitleCase( tmpPerson.LastName );
                txtKPFirstName.Text = tmpPerson.FirstName;
                txtKPMiddleInitial.Text = tmpPerson.MiddleInitial;
                txtKPLastName.Text = tmpPerson.LastName;
                txtKPPhone.Text = tmpPerson.PhoneNumber;
                txtKPFax.Text = tmpPerson.FaxNumber;
                txtKPEmail.Text = tmpPerson.EmailAddress;

                //CurrentPerson = tmpPerson;
                
                CurrentPersonID = tmpPerson.UI_TrackID;

                _InitGrid( rgKeyPersonnelEducation, "Education" );
                _InitGrid( rgKeyPersonnelEmployment, "Employment" );

            }
            _ShowHideFields();
        }

        private void _ShowHideFields()
        {
            if (Session["userType"].ToString() == "Public")
            {
                if (CurrentAppProvider.BusinessProcessID == "4" || CurrentAppProvider.BusinessProcessID == "5" || CurrentAppProvider.BusinessProcessID == "6" || CurrentAppProvider.BusinessProcessID == "7" || CurrentAppProvider.BusinessProcessID == "8" || CurrentAppProvider.BusinessProcessID == "10" || CurrentAppProvider.ApplicationStatus.Equals("4"))
                {
                    txtKPFirstName.ReadOnly = true;
                    txtKPMiddleInitial.ReadOnly = true;
                    txtKPLastName.ReadOnly = true;
                    txtKPPhone.ReadOnly = true;
                    txtKPFax.ReadOnly = true;
                    txtKPEmail.ReadOnly = true;

                    txtKPFirstName.BackColor = System.Drawing.Color.LightGray;
                    txtKPMiddleInitial.BackColor = System.Drawing.Color.LightGray;
                    txtKPLastName.BackColor = System.Drawing.Color.LightGray;
                    txtKPPhone.BackColor = System.Drawing.Color.LightGray;
                    txtKPFax.BackColor = System.Drawing.Color.LightGray;
                    txtKPEmail.BackColor = System.Drawing.Color.LightGray;
                }
            }
        }

        public void setNewPersonActive(bool inAllowEdit)
        {
            if (null != CurrentPersonID && !CurrentPersonID.Equals(""))
            {
                foreach (BO_ProviderPerson boPP in CurrentKeyPersonnelList)
                {
                    if (boPP.UI_TrackID.Equals(CurrentPersonID)
                        && !boPP.IsNewRec
                        //&& ( null == CurrentAppProvider.KeyPersonnelChange
                        //|| !CurrentAppProvider.KeyPersonnelChange.Equals( "Y" ) )
                        && inAllowEdit)
                    {
                        btnNewPerson.Visible = inAllowEdit;
                    }
                }
            }
        }

        protected void AddNewPerson_Click( object sender, CommandEventArgs e )
        {
            Button tmpCmdBtn = (Button) sender;
            BO_Person tmpPerson = new BO_Person();
            BO_ProviderPerson tmpProvPers = new BO_ProviderPerson();

            //Initialize new provider Person structure
            tmpPerson.IsNewRec = true;
            tmpProvPers.IsNewRec = true;
            tmpPerson.PersonID = 0;
            tmpPerson.UI_TrackID = "N" + CurrentKeyPersonnelList.Count();
            tmpProvPers.PersonID = 0;
            tmpProvPers.UI_TrackID = "N" + CurrentKeyPersonnelList.Count();
            tmpPerson.BO_EducationsPersonID = new BO_Educations();
            tmpPerson.BO_EmploymentsPersonID = new BO_Employments();
            tmpProvPers.BO_PersonDetail = tmpPerson;
            tmpProvPers.PersonType = PersonType;
            
            //Add to application provider_person list
            CurrentKeyPersonnelList.Add( tmpProvPers );
            btnNewPerson.Visible = false;

            IsNewRecord = true;

            foreach ( BO_ProviderPerson boPP in CurrentKeyPersonnelList )
            {
                if ( boPP.UI_TrackID.Equals( CurrentPersonID ) )
                    boPP.Removed = true;
            }

            CurrentPersonID = tmpPerson.UI_TrackID;

            _InitGrid( rgKeyPersonnelEducation, "Education" );
            _InitGrid( rgKeyPersonnelEmployment, "Employment" );

        }

        /// <summary>
        /// The parameter indicates if change of name should be checked
        /// in order to set the "KeyPersonnelChange" flag 
        /// </summary>
        /// <param name="isCheckNameChanged"></param>
        /// <returns></returns>
        public bool SaveData(bool isCheckNameChanged)
        {
            bool noSaveError = true;

            if ( null != CurrentAppProvider )
            {
                noSaveError = _DoValidate();

                if ( noSaveError )
                {

                    BO_ProviderPerson tmpProvPerson = null;

                    if (txtKPFirstName.Text.Trim().Length > 0 && txtKPLastName.Text.Trim().Length > 0)
                    {
                        foreach (BO_ProviderPerson boPP in CurrentKeyPersonnelList)
                        {
                            if (boPP.UI_TrackID.Equals(CurrentPersonID) && boPP.PersonType.Equals(PersonType))
                            {
                                tmpProvPerson = boPP;

                                // Set the "KeyPersonnelChange" flag if the name
                                // of Administrator or Director Of Nursing has changed
                                if (isCheckNameChanged)
                                {
                                    if (boPP.BO_PersonDetail.FirstName != null
                                        && !boPP.BO_PersonDetail.FirstName.Equals(txtKPFirstName.Text))
                                        CurrentAppProvider.KeyPersonnelChange = "Y";
                                    else if (boPP.BO_PersonDetail.FirstName == null
                                        && txtKPFirstName.Text.Trim().Length > 0)
                                        CurrentAppProvider.KeyPersonnelChange = "Y";

                                    if (boPP.BO_PersonDetail.MiddleInitial != null
                                        && !boPP.BO_PersonDetail.MiddleInitial.Equals(txtKPMiddleInitial.Text))
                                        CurrentAppProvider.KeyPersonnelChange = "Y";
                                    else if (boPP.BO_PersonDetail.MiddleInitial == null
                                        && txtKPMiddleInitial.Text.Trim().Length > 0)
                                        CurrentAppProvider.KeyPersonnelChange = "Y";

                                    if (boPP.BO_PersonDetail.LastName != null
                                        && !boPP.BO_PersonDetail.LastName.Equals(txtKPLastName.Text))
                                        CurrentAppProvider.KeyPersonnelChange = "Y";
                                    else if (boPP.BO_PersonDetail.LastName == null
                                        && txtKPLastName.Text.Trim().Length > 0)
                                        CurrentAppProvider.KeyPersonnelChange = "Y";

                                }

                                
                                break;
                            }
                        }

                        if ( null == tmpProvPerson )
                        {
                            tmpProvPerson = new BO_ProviderPerson();
                            tmpProvPerson.IsNewRec = true;
                            tmpProvPerson.ApplicationID = CurrentAppProvider.ApplicationID;
                            tmpProvPerson.PopsIntID = CurrentAppProvider.PopsIntID;
                            tmpProvPerson.PersonType = this.PersonType;
                            tmpProvPerson.UI_TrackID = "N" + CurrentAppProvider.BO_ProviderPeopleApplicationID.Count;

                            BO_Person tmpPerson = new BO_Person();
                            tmpPerson.IsNewRec = true;
                            tmpPerson.FirstName = txtKPFirstName.Text;
                            tmpPerson.MiddleInitial = txtKPMiddleInitial.Text;
                            tmpPerson.LastName = txtKPLastName.Text;
                            tmpPerson.PhoneNumber = txtKPPhone.Text;
                            tmpPerson.FaxNumber = txtKPFax.Text;
                            tmpPerson.EmailAddress = txtKPEmail.Text;
                            tmpPerson.UI_TrackID = "N0";

                            tmpProvPerson.BO_PersonDetail = tmpPerson;
                            CurrentAppProvider.BO_ProviderPeopleApplicationID.Add( tmpProvPerson );
                        }
                        else {
                            tmpProvPerson.BO_PersonDetail.FirstName = txtKPFirstName.Text;
                            tmpProvPerson.BO_PersonDetail.MiddleInitial = txtKPMiddleInitial.Text;
                            tmpProvPerson.BO_PersonDetail.LastName = txtKPLastName.Text;
                            tmpProvPerson.BO_PersonDetail.PhoneNumber = txtKPPhone.Text;
                            tmpProvPerson.BO_PersonDetail.FaxNumber = txtKPFax.Text;
                            tmpProvPerson.BO_PersonDetail.EmailAddress = txtKPEmail.Text;
                        }
                    }
                    else
                    {
                        int RecCnt = CurrentKeyPersonnelList.Count();

                        for (int RemCnt = 0; RemCnt < RecCnt; RemCnt++)
                        {
                            if (CurrentKeyPersonnelList[RemCnt].BO_PersonDetail.UI_TrackID.Equals(CurrentPersonID)
                                 && CurrentKeyPersonnelList[RemCnt].PersonType.Equals(PersonType))
                            {
                                // Set the "KeyPersonnelChange" flag if record previously existed
                                // and is now being removed
                                if (CurrentKeyPersonnelList[RemCnt].BO_PersonDetail.FirstName != null
                                    && CurrentKeyPersonnelList[RemCnt].BO_PersonDetail.LastName != null)
                                {
                                    if (CurrentKeyPersonnelList[RemCnt].BO_PersonDetail.FirstName.Trim().Length > 0
                                        && CurrentKeyPersonnelList[RemCnt].BO_PersonDetail.LastName.Trim().Length > 0)
                                    {
                                        CurrentAppProvider.KeyPersonnelChange = "Y";
                                    }
                                }

                                CurrentKeyPersonnelList.RemoveAt(RemCnt);
                                RecCnt--;
                            }
                        }
                    }
                }

            }
            else
            {
                // CurrentAppProvider is null : don't save the data
                noSaveError = false;
            }

            return noSaveError;
        }

        /// <summary>
        /// Data Validation
        /// </summary>
        /// <returns></returns>
        private bool _DoValidate()
        {
            bool retVal = true;
            string validationErrors = "";

            ErrorText.Visible = false;
            ErrorText.InnerHtml = "";

            /* 
             * TODO: Validation code goes here
             * In case of Validation failure, the following needs to happen:
             * 1) ErrorText.Visible = true;
             * 2) ErrorText.InnerHtml += validationErrors;
             * 3) retVal = false;
             */

            return retVal;
        }

        protected void rgKeyPersonnelEducation_NeedDataSource( object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e )
        {
            int tmpRowCnt = 0;
            if ( null != CurrentAppProvider && null != KP_EducationDataSource )
            {
                tmpRowCnt = KP_EducationDataSource.Rows.Count > 0 ? KP_EducationDataSource.Rows.Count + 2 : 3;
                rgKeyPersonnelEducation.Height = Unit.Pixel( ( 26 * tmpRowCnt ) + 3 );
                rgKeyPersonnelEducation.DataSource = (DataTable) KP_EducationDataSource;
            }
        }

        protected void rgKeyPersonnelEmployment_NeedDataSource( object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e )
        {
            int tmpRowCnt = 0;
            if ( null != CurrentAppProvider && null != KP_EmploymentDataSource )
            {
                tmpRowCnt = KP_EmploymentDataSource.Rows.Count > 0 ? KP_EmploymentDataSource.Rows.Count + 2 : 3;
                rgKeyPersonnelEmployment.Height = Unit.Pixel( ( 26 * tmpRowCnt ) + 3 );
                rgKeyPersonnelEmployment.DataSource = (DataTable) KP_EmploymentDataSource;
            }
        }

        protected void rgKeyPersonnelEducation_ItemCreated( object sender, Telerik.Web.UI.GridItemEventArgs e )
        {
            EducationEditForm tmpKPEF = (EducationEditForm) e.Item.FindControl( GridEditFormItem.EditFormUserControlID );

            if ( tmpKPEF != null )
            {
                int tmpRowCnt = KP_EducationDataSource.Rows.Count > 0 ? KP_EducationDataSource.Rows.Count + 2 : 3;
                    
                Button tmpInsertBtn = (Button) tmpKPEF.FindControl( "btnInsert" );
                Button tmpUpdateBtn = (Button) tmpKPEF.FindControl( "btnUpdate" );
                Button tmpCancelBtn = (Button) tmpKPEF.FindControl( "btnCancel" );

                if ( tmpInsertBtn != null && tmpUpdateBtn != null )
                {
                    tmpCancelBtn.Visible = true;

                    if ( ( e.Item is GridEditFormInsertItem ) && e.Item.IsInEditMode )
                    {
                        rgKeyPersonnelEducation.Height = Unit.Pixel( ( 26 * tmpRowCnt ) + 225 );

                        if ( AllowEdit )
                        {
                            tmpInsertBtn.Visible = true;
                            tmpUpdateBtn.Visible = false;
                        }
                    }
                    else if ( ( e.Item is GridEditableItem ) && e.Item.IsInEditMode )
                    {
                        rgKeyPersonnelEducation.Height = Unit.Pixel( ( 26 * KP_EducationDataSource.Rows.Count ) + 225 );

                        if ( AllowEdit )
                        {
                            tmpInsertBtn.Visible = false;
                            tmpUpdateBtn.Visible = true;
                        }
                    }
                }

                GridEditFormItem editedItem = e.Item as GridEditFormItem;

                //SMM TODO - This is a hack at this point as I have been unable to find a way to determine if the cancel button
                //was clicked and abort processing on the edit form.  
                if ( !( e.Item is GridEditFormInsertItem ) && !editedItem["UITrackID"].Text.Contains( "&nbsp;" ) )
                {
                    string tmpEducationUI_TrackID = editedItem["UITrackID"].Text;
                    
                    foreach ( BO_Education boED in CurrentProviderPerson.BO_PersonDetail.BO_EducationsPersonID )
                    {
                        if ( boED.UI_TrackID.Equals( tmpEducationUI_TrackID ) )
                        {
                            tmpKPEF.CollegeSchool = boED.CollegeSchool;
                            
                            if ( null != boED.GraduationDate )
                                tmpKPEF.GraduationDate = boED.GraduationDate.Value;
                            
                            tmpKPEF.DegreeObtained = boED.DegreeObtained;
                            tmpKPEF.EducationUI_TrackID = boED.UI_TrackID;
                            break;
                        }
                    }
                }
            } 
        }

        protected void rgKeyPersonnelEducation_InsertCommand( object source, GridCommandEventArgs e )
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            EducationEditForm tmpEEF = (EducationEditForm) e.Item.FindControl( GridEditFormItem.EditFormUserControlID );

            BO_Education tmpEd = new BO_Education();

            if ( tmpEEF.ValidateData() )
            {
                tmpEd.CollegeSchool = tmpEEF.CollegeSchool;
                tmpEd.GraduationDate = tmpEEF.GraduationDate;
                tmpEd.DegreeObtained = tmpEEF.DegreeObtained;
                tmpEd.IsNewRec = true;
                tmpEd.UI_TrackID = "N" + KP_EducationDataSource.Rows.Count.ToString();

                CurrentProviderPerson.BO_PersonDetail.BO_EducationsPersonID.Add( tmpEd );
                KP_EducationDataSource = null;
            }
            else
            {
                e.Canceled = true;
            }
        }

        protected void rgKeyPersonnelEducation_UpdateCommand( object source, GridCommandEventArgs e )
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            EducationEditForm tmpEEF = (EducationEditForm) e.Item.FindControl( GridEditFormItem.EditFormUserControlID );

            if ( tmpEEF.ValidateData() )
            {
                foreach ( BO_Education boED in CurrentProviderPerson.BO_PersonDetail.BO_EducationsPersonID )
                {
                    if ( boED.UI_TrackID.Equals( tmpEEF.EducationUI_TrackID ) )
                    {
                        boED.CollegeSchool = tmpEEF.CollegeSchool;
                        boED.GraduationDate = tmpEEF.GraduationDate;
                        boED.DegreeObtained = tmpEEF.DegreeObtained;
                    }
                }

                KP_EducationDataSource = null;
            }
            else
            {
                e.Canceled = true;
            }
            
        }

        protected void rgKeyPersonnelEducation_DeleteCommand( object source, GridCommandEventArgs e )
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            string tmpUITrackID = editedItem["UITrackID"].Text;

            foreach ( BO_Education boED in CurrentProviderPerson.BO_PersonDetail.BO_EducationsPersonID )
            {
                if ( boED.UI_TrackID.Equals( tmpUITrackID ) ) 
                {
                    boED.Removed = true;
                }
            }

            KP_EducationDataSource = null;

        }

        protected void rgKeyPersonnelEmployment_ItemCreated( object sender, Telerik.Web.UI.GridItemEventArgs e )
        {
            EmploymentEditForm tmpKPEF = (EmploymentEditForm) e.Item.FindControl( GridEditFormItem.EditFormUserControlID );

            if ( tmpKPEF != null )
            {
                int tmpRowCnt = KP_EmploymentDataSource.Rows.Count > 0 ? KP_EmploymentDataSource.Rows.Count + 2 : 3;

                Button tmpInsertBtn = (Button) tmpKPEF.FindControl( "btnInsert" );
                Button tmpUpdateBtn = (Button) tmpKPEF.FindControl( "btnUpdate" );
                Button tmpCancelBtn = (Button) tmpKPEF.FindControl( "btnCancel" );

                if ( tmpInsertBtn != null && tmpUpdateBtn != null )
                {
                    tmpCancelBtn.Visible = true;

                    if ( ( e.Item is GridEditFormInsertItem ) && e.Item.IsInEditMode )
                    {
                        rgKeyPersonnelEmployment.Height = Unit.Pixel( ( 26 * tmpRowCnt ) + 225 );

                        if ( AllowEdit )
                        {
                            tmpInsertBtn.Visible = true;
                            tmpUpdateBtn.Visible = false;
                        }
                    }
                    else if ( ( e.Item is GridEditableItem ) && e.Item.IsInEditMode )
                    {
                        rgKeyPersonnelEmployment.Height = Unit.Pixel( ( 26 * tmpRowCnt ) + 225 );

                        if ( AllowEdit )
                        {
                            tmpInsertBtn.Visible = false;
                            tmpUpdateBtn.Visible = true;
                        }
                    }
                }

                GridEditFormItem editedItem = e.Item as GridEditFormItem;

                //SMM TODO - This is a hack at this point as I have been unable to find a way to determine if the cancel button
                //was clicked and abort processing on the edit form.  
                if ( !( e.Item is GridEditFormInsertItem ) && !editedItem["UITrackID"].Text.Contains( "&nbsp;" ) )
                {
                    string tmpUITrackID = editedItem["UITrackID"].Text;

                    foreach ( BO_Employment boEM in CurrentProviderPerson.BO_PersonDetail.BO_EmploymentsPersonID )
                    {
                        if ( boEM.UI_TrackID.Equals( tmpUITrackID ) )
                        {
                            tmpKPEF.StartDate = boEM.StartDate.Value;
                            tmpKPEF.EndDate = boEM.EndDate.Value;
                            tmpKPEF.FacilityName = boEM.FacilityName;
                            tmpKPEF.FacilityAddress = boEM.FacilityAddress;
                            tmpKPEF.JobDuties = boEM.JobDutySummary;
                            tmpKPEF.EmploymentUI_TrackID = boEM.UI_TrackID;
                            break;
                        }
                    }
                }
            }
        }

        protected void rgKeyPersonnelEmployment_InsertCommand( object source, GridCommandEventArgs e )
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            EmploymentEditForm tmpEEF = (EmploymentEditForm) e.Item.FindControl( GridEditFormItem.EditFormUserControlID );

            BO_Employment tmpEm = new BO_Employment();

            if ( tmpEEF.ValidateData() )
            {
                tmpEm.StartDate = tmpEEF.StartDate;
                tmpEm.EndDate = tmpEEF.EndDate;
                tmpEm.FacilityName = tmpEEF.FacilityName;
                tmpEm.FacilityAddress = tmpEEF.FacilityAddress;
                tmpEm.JobDutySummary = tmpEEF.JobDuties;
                tmpEm.IsNewRec = true;
                tmpEm.UI_TrackID = "N" + KP_EmploymentDataSource.Rows.Count.ToString();

                CurrentProviderPerson.BO_PersonDetail.BO_EmploymentsPersonID.Add( tmpEm );
                KP_EmploymentDataSource = null;
            }
            else
            {
                e.Canceled = true;
            }
        }

        protected void rgKeyPersonnelEmployment_UpdateCommand( object source, GridCommandEventArgs e )
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            EmploymentEditForm tmpEEF = (EmploymentEditForm) e.Item.FindControl( GridEditFormItem.EditFormUserControlID );

            if ( tmpEEF.ValidateData() )
            {
                foreach ( BO_Employment boEm in CurrentProviderPerson.BO_PersonDetail.BO_EmploymentsPersonID )
                {
                    if ( boEm.UI_TrackID.Equals( tmpEEF.EmploymentUI_TrackID ) )
                    {
                        boEm.StartDate = tmpEEF.StartDate;
                        boEm.EndDate = tmpEEF.EndDate;
                        boEm.FacilityName = tmpEEF.FacilityName;
                        boEm.FacilityAddress = tmpEEF.FacilityAddress;
                        boEm.JobDutySummary = tmpEEF.JobDuties;
                    }
                }

                KP_EmploymentDataSource = null;
            }
            else
            {
                e.Canceled = true;
            }
        }

        protected void rgKeyPersonnelEmployment_DeleteCommand( object source, GridCommandEventArgs e )
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            string tmpUITrackID = editedItem["UITrackID"].Text;

            foreach ( BO_Employment boEm in CurrentProviderPerson.BO_PersonDetail.BO_EmploymentsPersonID )
            {
                if ( boEm.UI_TrackID.Equals( tmpUITrackID ) )
                {
                    boEm.Removed = true;
                }
            }

            KP_EmploymentDataSource = null;

        }

        protected void rgKeyPersonnelEducation_PreRender( object sender, EventArgs e )
        {
            LinkButton tmpInsertBtn = (LinkButton) this.FindControlRecursive( "btnEDAddNew" );
            LinkButton tmpEditBtn = (LinkButton) this.FindControlRecursive( "btnEDEditSelected" );
            LinkButton tmpViewBtn = (LinkButton) this.FindControlRecursive( "btnEDViewSelected" );
            LinkButton tmpDeleteBtn = (LinkButton) this.FindControlRecursive( "btnEDDeleteSelected" );

            if ( null != tmpInsertBtn && null != tmpEditBtn && null != tmpViewBtn && null != tmpDeleteBtn )
            {
                if ( AllowEdit )
                {
                    tmpInsertBtn.Visible = true;
                    if ( KP_EducationDataSource.Rows.Count > 0 )
                    {
                        tmpEditBtn.Visible = true;
                        tmpViewBtn.Visible = false;
                        tmpDeleteBtn.Visible = true;
                    }
                    else
                    {
                        tmpEditBtn.Visible = false;
                        tmpViewBtn.Visible = false;
                        tmpDeleteBtn.Visible = false;
                    }
                }
                else
                {
                    tmpInsertBtn.Visible = false;
                    if ( KP_EducationDataSource.Rows.Count > 0 )
                    {
                        tmpEditBtn.Visible = false;
                        tmpViewBtn.Visible = true;
                        tmpDeleteBtn.Visible = false;
                    }
                    else
                    {
                        tmpEditBtn.Visible = false;
                        tmpViewBtn.Visible = false;
                        tmpDeleteBtn.Visible = false;
                    }
                }
            }
        }

        protected void rgKeyPersonnelEmployment_PreRender( object sender, EventArgs e )
        {
            LinkButton tmpInsertBtn = (LinkButton) this.FindControlRecursive( "btnEMAddNew" );
            LinkButton tmpEditBtn = (LinkButton) this.FindControlRecursive( "btnEMEditSelected" );
            LinkButton tmpViewBtn = (LinkButton) this.FindControlRecursive( "btnEMViewSelected" );
            LinkButton tmpDeleteBtn = (LinkButton) this.FindControlRecursive( "btnEMDeleteSelected" );

            if ( null != tmpInsertBtn && null != tmpEditBtn && null != tmpViewBtn && null != tmpDeleteBtn )
            {
                if ( AllowEdit )
                {
                    tmpInsertBtn.Visible = true;
                    if ( KP_EmploymentDataSource.Rows.Count > 0 )
                    {
                        tmpEditBtn.Visible = true;
                        tmpViewBtn.Visible = false;
                        tmpDeleteBtn.Visible = true;
                    }
                    else
                    {
                        tmpEditBtn.Visible = false;
                        tmpViewBtn.Visible = false;
                        tmpDeleteBtn.Visible = false;
                    }
                }
                else
                {
                    tmpInsertBtn.Visible = false;
                    if ( KP_EmploymentDataSource.Rows.Count > 0 )
                    {
                        tmpEditBtn.Visible = false;
                        tmpViewBtn.Visible = true;
                        tmpDeleteBtn.Visible = false;
                    }
                    else
                    {
                        tmpEditBtn.Visible = false;
                        tmpViewBtn.Visible = false;
                        tmpDeleteBtn.Visible = false;
                    }
                }
            }
        }

        public bool AllowEdit
        {
            get
            {
                return ( null != ViewState["AllowEdit"] ? (bool) ViewState["AllowEdit"] : false );
            }
            set
            {
                ViewState["AllowEdit"] = value;
            }
        }

        public bool IsNewRecord
        {
            get
            {
                return IsNewRec.Value.Equals( "Y" );
            }
            set
            {
                if ( value )
                    IsNewRec.Value = "Y";
                else
                    IsNewRec.Value = "N";
            }
        }

        public string PersonType
        {
            get
            {
                return (string) ViewState["PersonType"];
            }
            set
            {
                ViewState["PersonType"] = value;
            }
        }

        private void _InitGrid( RadGrid inGridToInit, string inGridType )
        {
            inGridToInit.AllowFilteringByColumn = false;
            //inGridToInit.EnableViewState = true;
            inGridToInit.ShowHeader = true;
            inGridToInit.AllowPaging = false;
            inGridToInit.AllowSorting = false;
            inGridToInit.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Top;
            inGridToInit.ClientSettings.Selecting.AllowRowSelect = true;
            inGridToInit.ClientSettings.Scrolling.AllowScroll = true;
            inGridToInit.ClientSettings.Scrolling.UseStaticHeaders = true;
            inGridToInit.ClientSettings.Resizing.AllowColumnResize = true;
            inGridToInit.RegisterWithScriptManager = true;

            if ( inGridToInit.Columns.Count < 1 )
                _BuildGridColumns( inGridType );

            int tmpRowCnt = 0;

            switch ( inGridType )
            {
                case "Education":
                    tmpRowCnt = KP_EducationDataSource.Rows.Count > 0 ? KP_EducationDataSource.Rows.Count + 2 : 3;
                    inGridToInit.Height = Unit.Pixel( ( 26 * tmpRowCnt ) + 10 );
                    inGridToInit.DataSource = KP_EducationDataSource;
                    inGridToInit.DataBind();
                    break;
                case "Employment":
                    tmpRowCnt = KP_EmploymentDataSource.Rows.Count > 0 ? KP_EmploymentDataSource.Rows.Count + 2 : 3;
                    inGridToInit.Height = Unit.Pixel( ( 26 * tmpRowCnt ) + 10 );
                    inGridToInit.DataSource = KP_EmploymentDataSource;
                    inGridToInit.DataBind();
                    break;
            }
        }

        //Defines the columns for the grid. They must exist in the DataTable used as the datasource
        //but not all need to be listed here, only those that are needed.
        private void _BuildGridColumns( String inGridType )
        {
            GridBoundColumn tmpCol = null;

            switch ( inGridType )
            {
                case "Education":
                    tmpCol = new GridBoundColumn();
                    rgKeyPersonnelEducation.MasterTableView.Columns.Add( tmpCol );
                    tmpCol.UniqueName = "CollegeSchool";
                    tmpCol.DataField = "CollegeSchool";
                    tmpCol.HeaderText = "College/School";
                    tmpCol.Visible = true;
                    tmpCol.HeaderStyle.Width = Unit.Percentage( 35 );
                    tmpCol.DataFormatString = "<nobr>{0}</nobr>";

                    tmpCol = new GridBoundColumn();
                    rgKeyPersonnelEducation.MasterTableView.Columns.Add( tmpCol );
                    tmpCol.UniqueName = "GraduationDate";
                    tmpCol.DataField = "GraduationDate";
                    tmpCol.HeaderText = "Graduation Date";
                    tmpCol.Visible = true;
                    tmpCol.HeaderStyle.Width = Unit.Percentage( 20 );
                    tmpCol.DataFormatString = "<nobr>{0}</nobr>";

                    tmpCol = new GridBoundColumn();
                    rgKeyPersonnelEducation.MasterTableView.Columns.Add( tmpCol );
                    tmpCol.UniqueName = "DegreeObtained";
                    tmpCol.DataField = "DegreeObtained";
                    tmpCol.HeaderText = "Degree Obtained";
                    tmpCol.Visible = true;
                    tmpCol.HeaderStyle.Width = Unit.Percentage( 45 );
                    tmpCol.DataFormatString = "<nobr>{0}</nobr>";

                    tmpCol = new GridBoundColumn();
                    rgKeyPersonnelEducation.MasterTableView.Columns.Add( tmpCol );
                    tmpCol.UniqueName = "PersonID";
                    tmpCol.DataField = "PersonID";
                    tmpCol.HeaderText = "Person Internal ID";
                    tmpCol.Visible = false;

                    tmpCol = new GridBoundColumn();
                    rgKeyPersonnelEducation.MasterTableView.Columns.Add( tmpCol );
                    tmpCol.UniqueName = "EducationID";
                    tmpCol.DataField = "EducationID";
                    tmpCol.HeaderText = "Education Internal ID";
                    tmpCol.Visible = false;

                    tmpCol = new GridBoundColumn();
                    rgKeyPersonnelEducation.MasterTableView.Columns.Add( tmpCol );
                    tmpCol.UniqueName = "UITrackID";
                    tmpCol.DataField = "UITrackID";
                    tmpCol.HeaderText = "Row Tracking ID";
                    tmpCol.Visible = false;
                    break;
                case "Employment":
                    tmpCol = new GridBoundColumn();
                    rgKeyPersonnelEmployment.MasterTableView.Columns.Add( tmpCol );
                    tmpCol.UniqueName = "StartDate";
                    tmpCol.DataField = "StartDate";
                    tmpCol.HeaderText = "Start Date";
                    tmpCol.Visible = true;
                    tmpCol.HeaderStyle.Width = Unit.Percentage( 12 );
                    tmpCol.DataFormatString = "<nobr>{0}</nobr>";

                    tmpCol = new GridBoundColumn();
                    rgKeyPersonnelEmployment.MasterTableView.Columns.Add( tmpCol );
                    tmpCol.UniqueName = "EndDate";
                    tmpCol.DataField = "EndDate";
                    tmpCol.HeaderText = "End Date";
                    tmpCol.Visible = true;
                    tmpCol.HeaderStyle.Width = Unit.Percentage( 12 );
                    tmpCol.DataFormatString = "<nobr>{0}</nobr>";

                    tmpCol = new GridBoundColumn();
                    rgKeyPersonnelEmployment.MasterTableView.Columns.Add( tmpCol );
                    tmpCol.UniqueName = "FacilityName";
                    tmpCol.DataField = "FacilityName";
                    tmpCol.HeaderText = "Facility Name";
                    tmpCol.Visible = true;
                    tmpCol.HeaderStyle.Width = Unit.Percentage( 23 );
                    tmpCol.DataFormatString = "<nobr>{0}</nobr>";

                    tmpCol = new GridBoundColumn();
                    rgKeyPersonnelEmployment.MasterTableView.Columns.Add( tmpCol );
                    tmpCol.UniqueName = "FacilityAddress";
                    tmpCol.DataField = "FacilityAddress";
                    tmpCol.HeaderText = "Facility Address";
                    tmpCol.Visible = true;
                    tmpCol.HeaderStyle.Width = Unit.Percentage( 23 );
                    tmpCol.DataFormatString = "<nobr>{0}</nobr>";

                    tmpCol = new GridBoundColumn();
                    rgKeyPersonnelEmployment.MasterTableView.Columns.Add( tmpCol );
                    tmpCol.UniqueName = "JobDutySummary";
                    tmpCol.DataField = "JobDutySummary";
                    tmpCol.HeaderText = "Job Duty Summary";
                    tmpCol.Visible = true;
                    tmpCol.HeaderStyle.Width = Unit.Percentage( 30 );
                    tmpCol.DataFormatString = "<nobr>{0}</nobr>";

                    tmpCol = new GridBoundColumn();
                    rgKeyPersonnelEmployment.MasterTableView.Columns.Add( tmpCol );
                    tmpCol.UniqueName = "PersonID";
                    tmpCol.DataField = "PersonID";
                    tmpCol.HeaderText = "Person Internal ID";
                    tmpCol.Visible = false;

                    tmpCol = new GridBoundColumn();
                    rgKeyPersonnelEmployment.MasterTableView.Columns.Add( tmpCol );
                    tmpCol.UniqueName = "EmploymentID";
                    tmpCol.DataField = "EmploymentID";
                    tmpCol.HeaderText = "Employment Internal ID";
                    tmpCol.Visible = false;

                    tmpCol = new GridBoundColumn();
                    rgKeyPersonnelEmployment.MasterTableView.Columns.Add( tmpCol );
                    tmpCol.UniqueName = "UITrackID";
                    tmpCol.DataField = "UITrackID";
                    tmpCol.HeaderText = "Row Tracking ID";
                    tmpCol.Visible = false;
                    break;
            }
        }

        //Defines the DataTable structure to be used by the grid
        private DataTable _getKeyPersGridInitTable( string inGridType )
        {
            DataTable tmpDTbl = new DataTable();
            DataColumn tmpDCol = null;

            switch ( inGridType )
            {
                case "Education":
                    tmpDCol = new DataColumn( "CollegeSchool" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "GraduationDate" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "DegreeObtained" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "EducationID" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "PersonID" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "UITrackID" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    break;
                case "Employment":
                    tmpDCol = new DataColumn( "StartDate" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "EndDate" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "FacilityName" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "FacilityAddress" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "JobDutySummary" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "PersonID" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "EmploymentID" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "UITrackID" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    break;
            }

            return tmpDTbl;
        }

        #region Members
        private BO_Application CurrentAppProvider
        {
            get
            {
                return Session["CurrentAppProvider"] == null ? null : (BO_Application) Session["CurrentAppProvider"];
            }
        }

        private BO_ProviderPeople CurrentKeyPersonnelList
        {
            get
            {
                BO_ProviderPeople tmpList;

                if ( CurrentAppProvider != null && CurrentAppProvider.BO_ProviderPeopleApplicationID != null )
                {
                    tmpList = CurrentAppProvider.BO_ProviderPeopleApplicationID;
                }
                else
                {
                    tmpList = new BO_ProviderPeople();
                }
                return tmpList;
            }
            set
            {
                CurrentAppProvider.BO_ProviderPeopleApplicationID = value;
            }
        }
        
        private BO_ProviderPerson CurrentProviderPerson
        {
            get
            {
                BO_ProviderPerson tmpProvPerson = null;

                if ( null != CurrentAppProvider && null != CurrentKeyPersonnelList )
                {
                    foreach ( BO_ProviderPerson boPP in CurrentKeyPersonnelList )
                    {
                        if ( boPP.UI_TrackID.Equals( CurrentPersonID ) && boPP.PersonType.Equals( PersonType ) )
                            tmpProvPerson = boPP;
                    }
                }
                else
                {
                    tmpProvPerson = new BO_ProviderPerson();
                }
                return tmpProvPerson;
            }
            //set
            //{
            //    if ( null != CurrentAppProvider && null != CurrentKeyPersonnelList )
            //    {
            //        foreach ( BO_ProviderPerson boPP in CurrentKeyPersonnelList )
            //        {
            //            if ( boPP.PersonID.Equals( CurrentPersonID ) && boPP.PersonType.Equals( PersonType ) )
            //                boPP.BO_PersonDetail = value;
            //        }
            //    }
            //}
        }

        private string CurrentPersonID
        {
            get
            {
                return ( null != ViewState["CurrentPersonID"] ) ? (string) ViewState["CurrentPersonID"] : null;
            }
            set
            {
                ViewState["CurrentPersonID"] = value;
            }
        }

        private DataTable KP_EducationDataSource
        {
            get
            {
                DataTable retTable = (DataTable) ViewState["KP_EducationDataSource"];

                if ( retTable == null )
                {
                    retTable = _getKeyPersGridInitTable( "Education" );

                    if ( null != CurrentProviderPerson && null != CurrentProviderPerson.BO_PersonDetail && CurrentProviderPerson.BO_PersonDetail.PersonID != null )
                    {
                        foreach ( BO_Education boED in CurrentProviderPerson.BO_PersonDetail.BO_EducationsPersonID )
                        {
                            if ( !boED.Removed )
                            {
                                DataRow tmpDR = retTable.NewRow();
                                //SMM 01/22/2012 - Removed Title case conversion
                                //tmpDR["CollegeSchool"] = CommonFunc.ConvertToTitleCase( boED.CollegeSchool );
                                //tmpDR["DegreeObtained"] = CommonFunc.ConvertToTitleCase( boED.DegreeObtained );
                                tmpDR["CollegeSchool"] = boED.CollegeSchool;
                                tmpDR["DegreeObtained"] = boED.DegreeObtained;
                                tmpDR["GraduationDate"] = ( null == boED.GraduationDate ? "" : DateTime.Parse( boED.GraduationDate.ToString() ).ToShortDateString() );
                                tmpDR["EducationID"] = boED.EducationID.ToString();
                                tmpDR["PersonID"] = boED.PersonID.ToString();
                                tmpDR["UITrackID"] = boED.UI_TrackID;
                                
                                retTable.Rows.Add( tmpDR );
                            }
                        }
                    }
                }
                return retTable;
            }
            set
            {
                ViewState["KP_EducationDataSource"] = value;
            }
        }

        private DataTable KP_EmploymentDataSource
        {
            get
            {
                DataTable retTable = (DataTable) ViewState["KP_EmploymentDataSource"];

                if ( retTable == null )
                {
                    retTable = _getKeyPersGridInitTable( "Employment" );

                    if ( null != CurrentProviderPerson && null != CurrentProviderPerson.BO_PersonDetail && CurrentProviderPerson.BO_PersonDetail.PersonID != null )
                    {
                        foreach ( BO_Employment boEM in CurrentProviderPerson.BO_PersonDetail.BO_EmploymentsPersonID )
                        {
                            if ( !boEM.Removed )
                            {
                                DataRow tmpDR = retTable.NewRow();
                                tmpDR["StartDate"] = ( null == boEM.StartDate ? "" : DateTime.Parse( boEM.StartDate.ToString() ).ToShortDateString() );
                                tmpDR["EndDate"] = ( null == boEM.EndDate ? "" : DateTime.Parse( boEM.EndDate.ToString() ).ToShortDateString() );
                                //SMM 01/22/2012 - Removed Title Case conversion
                                //tmpDR["FacilityName"] = CommonFunc.ConvertToTitleCase( boEM.FacilityName );
                                //tmpDR["FacilityAddress"] = CommonFunc.ConvertToTitleCase( boEM.FacilityAddress );
                                tmpDR["FacilityName"] = boEM.FacilityName;
                                tmpDR["FacilityAddress"] = boEM.FacilityAddress;
                                tmpDR["JobDutySummary"] = boEM.JobDutySummary;
                                tmpDR["EmploymentID"] = boEM.EmploymentID.ToString();
                                tmpDR["PersonID"] = boEM.PersonID.ToString();
                                tmpDR["UITrackID"] = boEM.UI_TrackID;

                                retTable.Rows.Add( tmpDR );
                            }
                        }
                    }
                }
                return retTable;
            }
            set
            {
                ViewState["KP_EmploymentDataSource"] = value;
            }
        }
        
        #endregion

    }
}