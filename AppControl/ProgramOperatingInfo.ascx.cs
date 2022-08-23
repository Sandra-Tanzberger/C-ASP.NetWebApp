using System;
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
	public partial class ProgramOperatingInfo : System.Web.UI.UserControl
	{
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void AttachAction_Click(object sender, EventArgs e)
        {
            string tmpAddQueryString = "";
            string tmpAttachParentType = "APPLICATION";
            LinkButton tmpUpldBtn = (LinkButton)sender;

            string[] commandArgsSent = tmpUpldBtn.CommandArgument.ToString().Split(new char[] { ',' });

            //This is the add condition
            if (tmpUpldBtn.CommandName == "Upload" && tmpUpldBtn.Text.Equals("Attach"))
            {
                tmpAddQueryString += "Desc=" + "&";
                tmpAddQueryString += "AttID=" + commandArgsSent[0].ToString() + "&";
                tmpAddQueryString += "Type=" + tmpAttachParentType;


                AttachRadWin.NavigateUrl = "~/Common/FileUpload.aspx?" + tmpAddQueryString;
                AttachRadWin.Height = Unit.Pixel(125);
                AttachRadWin.Width = Unit.Pixel(545);
                AttachRadWin.Title = "Attach File";
                AttachRadWin.Visible = true;
                AttachRadWin.Modal = true;
            }
            else //Remove condition
            {
                decimal tmpFileAttachID = Convert.ToDecimal(commandArgsSent[1]);

                foreach (BO_ApplicationItem boAI in CurrentAppProvider.BO_ApplicationItemsApplicationID)
                {
                    if (boAI.FileAttachID.Equals(tmpFileAttachID))
                    {
                        boAI.FileAttachID = null;
                        foreach (BO_FileAttach boFA in CurrentAppProvider.Attachments)
                        {
                            if (boFA.FileAttachID.Equals(tmpFileAttachID))
                            {
                                boFA.Removed = true;
                                break;
                            }
                        }
                        break;
                    }
                }
            }
        }

        public void LoadApplication(string inKeyID, bool inAllowEdit, bool inIsOffsiteAffil)
        {
            //BO_Application tmpAppProvider = null;
            //BO_Affiliation tmpAffiliation = null;

            IsOffSite = inIsOffsiteAffil;
            AllowEdit = inAllowEdit;

            if (inKeyID != null
                && IsOffSite)
            {
                CurrentAffiliationID = inKeyID;
            }

            /*if (inKeyID != null) {
                if (!IsOffSite)
                {
                    //tmpAppProvider = new BO_Application();
                    //tmpAppProvider.LoadFullApplication(Convert.ToDecimal(inKeyID));

                    //if (tmpAppProvider.ApplicationID != null)
                    //{
                    //    CurrentAppProvider = tmpAppProvider;
                    //}
                    //else
                    //{
                    //    CurrentAppProvider = null;
                    //}
                }
                else
                {
                    CurrentAffiliationID = inKeyID;

                    //if (null != CurrentAppProvider.BO_AffiliationsApplicationID)
                    //{
                    //    foreach (BO_Affiliation tmpBA in CurrentAppProvider.BO_AffiliationsApplicationID)
                    //    {
                    //        if (tmpBA.UI_TrackID.Equals(CurrentAffiliationID))
                    //        {
                    //            tmpAffiliation = tmpBA;
                    //            break;
                    //        }
                    //    }
                    //}
                }
            }*/

            _LoadByProvider(AllowEdit);
            _ShowHideFields();
        }

        public bool SaveData()
        {
            bool noSaveError = false;

            if (_DoValidate())
            {
                noSaveError = true;
                switch (CurrentAppProvider.ProgramID)
                {
                    case "HC":

                        break;
                    case "HO":

                        break;
                    case "BR":

                        break;
                    case "PM":
                        //tblOperationDate fields
                        //someDataBaseValue = ddlYesNo.Text;

                        //tblLicenseInfo fields
                        CurrentAppProvider.LaCdsNum = txtLACDS.Text;
                        CurrentAppProvider.LaCdsNumExpDate = txtLACDSExpDate.SelectedDate;
                        CurrentAppProvider.UsDeaRegNum = txtUSDEACS.Text;
                        CurrentAppProvider.UsDeaRegNumExpDate = txtUSDEACSExpDate.SelectedDate;
                        CurrentAppProvider.OperationPrior2005 = ddlYesNo.SelectedValue;
                        break;
                    case "AS":
                        CurrentAppProvider.NumOperatingRooms = txtNumOperatingRooms.Text.Length > 0 ? Convert.ToInt16(txtNumOperatingRooms.Text) : 0;
                        break;
                    case "MT":
                        _SaveProgramMT();
                        break;
                    case "NE":
                        _SaveProgramNE();
                        break;
                }
            }

            return noSaveError;
        }

        protected void ProofOptAttachAction_Click(object sender, EventArgs e)
        {
            string tmpAddQueryString = "";
            string tmpAttachParentType = "PROOF_OPERATION_PRIOR_2005";
            LinkButton tmpUpldBtn = (LinkButton)sender;

            string[] commandArgsSent = tmpUpldBtn.CommandArgument.ToString().Split(new char[] { ',' });

            //This is the add condition
            if (tmpUpldBtn.CommandName == "Upload" && tmpUpldBtn.Text.Equals("Attach"))
            {
                tmpAddQueryString += "Desc=Proof of Opperation&";
                tmpAddQueryString += "AttID=" + commandArgsSent[0].ToString() + "&";
                tmpAddQueryString += "Type=" + tmpAttachParentType;


                AttachRadWin.NavigateUrl = "~/Common/FileUpload.aspx?" + tmpAddQueryString;
                AttachRadWin.Height = Unit.Pixel(125);
                AttachRadWin.Width = Unit.Pixel(545);
                AttachRadWin.Title = "Attach File";
                AttachRadWin.Visible = true;
                AttachRadWin.Modal = true;

            }
            else //Remove condition
            {
                decimal tmpFileAttachID = Convert.ToDecimal(commandArgsSent[1]);

                foreach (BO_ApplicationItem boAI in CurrentAppProvider.BO_ApplicationItemsApplicationID)
                {
                    if (boAI.FileAttachID.Equals(tmpFileAttachID))
                    {
                        boAI.FileAttachID = null;
                        foreach (BO_FileAttach boFA in CurrentAppProvider.Attachments)
                        {
                            if (boFA.FileAttachID.Equals(tmpFileAttachID))
                            {
                                boFA.Removed = true;
                                break;
                            }
                        }
                        break;
                    }
                }
            }

        }

        //private void _AddServiceToLocation( BO_Service inService )
        //{
        //    if ( !IsOffSite )
        //    {
        //        CurrentAppProvider.BO_ServicesApplicationID.Add( inService );
        //    }
        //    else
        //    {
        //        if ( null != CurrentAppProvider.BO_AffiliationsApplicationID )
        //        {
        //            foreach ( BO_Affiliation boAffil in CurrentAppProvider.BO_AffiliationsApplicationID )
        //            {
        //                if ( boAffil.UI_TrackID.Equals( CurrentAffiliationID ) )
        //                {
        //                    boAffil.BO_ServicesAffiliationID.Add( inService );

        //                    break;
        //                }
        //            }
        //        }
        //    }

        //}

        //private BO_Service _FindServiceBR( string inServiceType )
        //{
        //    BO_Service retVal = null;

        //    if ( !IsOffSite )
        //    {
        //        if ( null != CurrentAppProvider.BO_ServicesApplicationID )
        //        {
        //            foreach ( BO_Service boSvc in CurrentAppProvider.BO_ServicesApplicationID )
        //            {
        //                if ( boSvc.ServiceType.Equals( inServiceType ) )
        //                    retVal = boSvc;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        if ( null != CurrentAppProvider.BO_AffiliationsApplicationID )
        //        {
        //            foreach ( BO_Affiliation boAffil in CurrentAppProvider.BO_AffiliationsApplicationID )
        //            {
        //                if ( boAffil.UI_TrackID.Equals( CurrentAffiliationID )
        //                    && boAffil.BO_ServicesAffiliationID != null )
        //                {
        //                    foreach ( BO_Service boSvc in boAffil.BO_ServicesAffiliationID )
        //                    {
        //                        if ( boSvc.ServiceType.Equals( inServiceType ) )
        //                        {
        //                            retVal = boSvc;
        //                            break;
        //                        }
        //                    }

        //                    break;
        //                }
        //            }
        //        }
        //    }

        //    return retVal;
        //}

        //private BO_Service _getNewService( string inServiceType )
        //{
        //    BO_Service newService = new BO_Service();

        //    newService.IsNewRec = true;
        //    newService.PopsIntID = CurrentAppProvider.PopsIntID;
        //    newService.ApplicationID = CurrentAppProvider.ApplicationID;
        //    newService.ServiceType = inServiceType;

        //    if ( IsOffSite )
        //    {
        //        int ServiceCnt = 0;

        //        foreach ( BO_Affiliation boAffil in CurrentAppProvider.BO_AffiliationsApplicationID )
        //        {
        //            if ( boAffil.UI_TrackID.Equals( CurrentAffiliationID )
        //                && boAffil.BO_ServicesAffiliationID != null )
        //            {
        //                ServiceCnt = boAffil.BO_ServicesAffiliationID.Count;
        //                break;
        //            }
        //        }

        //        newService.UI_TrackID = "N" + ServiceCnt.ToString();
        //    }

        //    return newService;
        //}

        private void _SaveProgramMT()
        {
            CurrentAppProvider.LaCdsNum = txtLACDS.Text;
            CurrentAppProvider.LaCdsNumExpDate = txtLACDSExpDate.SelectedDate;
            CurrentAppProvider.UsDeaRegNum = txtUSDEACS.Text;
            CurrentAppProvider.UsDeaRegNumExpDate = txtUSDEACSExpDate.SelectedDate;
            CurrentAppProvider.MedicaidVendorNumber = txtMedicaidNo.Text;
            CurrentAppProvider.CurSurv = rdpMTCurCertSrvDt.SelectedDate;
            CurrentAppProvider.CliaIdNum = txtCLIAnum.Text;
            CurrentAppProvider.ClosedDate = rdpCertExpDt.SelectedDate;
            //CurrentAppProvider.NoOfAirAmbulances = txtAirAmb.Text; //These fields must be calculated when vehicles are added only
            //CurrentAppProvider.NoOfGroundAmbulances = txtGroundAmb.Text;
            //CurrentAppProvider.NoOfSprintVehicles = txtSprintVeh.Text;
            CurrentAppProvider.LevelCode = ddlLevelCareCode.SelectedValue;
            ddlLevelCareCode.DataSource = BO_LookupValue.SelectByFieldByKeyAndProgram("LEVEL_OF_CARE", "MT");
        }

        private void _SaveProgramNE()
        {
            CurrentAppProvider.CurSurv = rdpNECurCertSrvDt.SelectedDate;
            CurrentAppProvider.OriginalEnrollmentDate = rdpOrigEnrollDt.SelectedDate;
            //CurrentAppProvider.NoOfAmbulatoryVehicles = txtTotalNumAmbVeh.Text;  //These fields must be calculated when vehicles are added only
            //CurrentAppProvider.NoOfHandicappedVehicles = txtTotalNumHandVeh.Text;
            CurrentAppProvider.TotalDailyCapacityAmbulatoryVehicle = txtTotalDailyCapAmb.Text;
            CurrentAppProvider.TotalDailyCapacityHandicappedVehicle = txtTotalDailyCapHand.Text;
        }

        private bool _DoValidate()
        {
            bool retVal = true;
            string validationErrors = "";

            ErrorText.Visible = false;
            ErrorText.InnerHtml = "";

            if (("PM").Contains(CurrentAppProvider.ProgramID))
            {
                if (string.IsNullOrEmpty(txtLACDS.Text))
                {
                    validationErrors += "LA CDS Number is Required<br/>";
                }

                //if (null == txtLACDSExpDate.SelectedDate)
                //{
                //   validationErrors += "LA CDS Expiration Date is Required<br/>";
                //}

                if (string.IsNullOrEmpty(txtUSDEACS.Text))
                {
                    validationErrors += "US DEA CS Registration Number is Required<br/>";
                }

                //if (null == txtUSDEACSExpDate.SelectedDate)
                //{
                //    validationErrors += "US DEA CS Expiration Date is Required<br/>";
                //}

                if (validationErrors.Length > 0)
                {
                    ErrorText.Visible = true;
                    ErrorText.InnerHtml += validationErrors;
                    retVal = false;
                }
            }

            return retVal;
        }

        private void _LoadByProvider(bool AllowEdit)
        {
            switch (CurrentAppProvider.ProgramID)
            {
                case "PM":
                    _InitProgram_PM();
                    break;
                case "AS":
                    txtNumOperatingRooms.Text = (null != CurrentAppProvider && null != CurrentAppProvider.NumOperatingRooms ? CurrentAppProvider.NumOperatingRooms.Value.ToString() : "");
                    break;
                case "MT":
                    _InitProgram_MT();
                    break;
                case "NE":
                    _InitProgramNE();
                    break;
            }
        }

        private void _InitProgram_MT()
        {
            txtLACDS.Text = CurrentAppProvider.LaCdsNum;
            txtLACDSExpDate.SelectedDate = CurrentAppProvider.LaCdsNumExpDate;
            txtUSDEACS.Text = CurrentAppProvider.UsDeaRegNum;
            txtUSDEACSExpDate.SelectedDate = CurrentAppProvider.UsDeaRegNumExpDate;
            txtMedicaidNo.Text = CurrentAppProvider.MedicaidVendorNumber;
            rdpMTCurCertSrvDt.SelectedDate = CurrentAppProvider.CurSurv;
            txtCLIAnum.Text = CurrentAppProvider.CliaIdNum;
            rdpCertExpDt.SelectedDate = CurrentAppProvider.ClosedDate;
            txtAirAmb.Text = CurrentAppProvider.NoOfAirAmbulances;
            txtGroundAmb.Text = CurrentAppProvider.NoOfGroundAmbulances;
            txtSprintVeh.Text = CurrentAppProvider.NoOfSprintVehicles;
            ddlLevelCareCode.DataSource = BO_LookupValue.SelectByFieldByKeyAndProgram("LEVEL_OF_CARE", "MT");
            ddlLevelCareCode.DataTextField = "Valdesc";
            ddlLevelCareCode.DataValueField = "LookupVal";
            ddlLevelCareCode.DataBind();
            if(CurrentAppProvider.LevelCode!=null)
                ddlLevelCareCode.SelectedValue = CurrentAppProvider.LevelCode;
        }

        private void _InitProgramNE()
        {
            rdpNECurCertSrvDt.SelectedDate = CurrentAppProvider.CurSurv;
            rdpOrigEnrollDt.SelectedDate = CurrentAppProvider.OriginalEnrollmentDate;
            txtTotalNumAmbVeh.Text = CurrentAppProvider.NoOfAmbulatoryVehicles;
            txtTotalNumHandVeh.Text = CurrentAppProvider.NoOfHandicappedVehicles;
            txtTotalDailyCapAmb.Text = CurrentAppProvider.TotalDailyCapacityAmbulatoryVehicle;
            txtTotalDailyCapHand.Text = CurrentAppProvider.TotalDailyCapacityHandicappedVehicle;
        }

        private void _InitProgram_PM()
        {
            if (!IsOffSite)
            {
                //Clear prior to loading
                //ddlYesNo.Items.Clear();
                txtLACDS.Text.Equals(null);
                txtLACDSExpDate.SelectedDate.Equals(null);
                txtUSDEACS.Text.Equals(null);
                txtUSDEACSExpDate.SelectedDate.Equals(null);

                //Load values from database
                //
                // Yes/No and attachments will be added later
                //

                txtLACDS.Text = CurrentAppProvider.LaCdsNum;
                txtLACDSExpDate.SelectedDate = CurrentAppProvider.LaCdsNumExpDate;
                txtUSDEACS.Text = CurrentAppProvider.UsDeaRegNum;
                txtUSDEACSExpDate.SelectedDate = CurrentAppProvider.UsDeaRegNumExpDate;

                ddlYesNo.SelectedValue = CurrentAppProvider.OperationPrior2005;

                if (!string.IsNullOrEmpty(CurrentAppProvider.OperationPrior2005) && CurrentAppProvider.OperationPrior2005.Equals("Y"))
                {
                    //AttachParentIDType
                    if (null != CurrentAppProvider.Attachments)
                    {
                        foreach (BO_FileAttach boFA in CurrentAppProvider.Attachments)
                        {
                            if (boFA.AttachParentIdType.Equals("PROOF_OPERATION_PRIOR_2005"))
                            {
                                AttachLinkButtonSpan.Visible = true;
                                ProofOptAttachAction.Text = "Remove";
                                ProofOptAttachAction.CommandArgument = boFA.FileAttachID.Value.ToString();
                                ViewLinkButtonSpan.Visible = true;
                                ViewLinkButtonSpan.InnerHtml = "Attachment: <a href='../../Common/FileViewer.aspx?AttID=" + boFA.FileAttachID.Value.ToString() + "' target='_blank'>" + boFA.AttachFilename + "</a>";
                                break;
                            }
                        }
                    }
                    else
                    {
                        ProofOptAttachAction.Text = "Attach";
                        ProofOptAttachAction.Visible = true;
                    }
                }
            }
        }

        private void _ShowHideFields()
        {
            //Turn off all sections first then enable them by program type and location
            tblOperationDate.Visible = false;
            tblLicenseInfo.Visible = false;
            tblOperatingRooms.Visible = false;
            tblMT.Visible = false;
            tblNE.Visible = false;

            //AllowEdit ... ?
            if (Session["userType"].ToString() == "State")
            {
                switch (CurrentAppProvider.ProgramID)
                {
                    case "HC":
                        break;

                    case "HO":
                        break;

                    case "BR":
                        break;

                    case "PM":
                        tblOperationDate.Visible = true;
                        tblLicenseInfo.Visible = true;
                        break;
                    case "AS":
                        tblOperatingRooms.Visible = true;
                        break;
                    case "MT":
                        tblLicenseInfo.Visible = true;
                        tblMT.Visible = true;
                        break;
                    case "NE":
                        tblNE.Visible = true;

                        break;
                }
            }

            if (!AllowEdit)
            {
                /*
                ddlYesNo.Enabled = false;
                txtLACDS.Enabled = false;
                txtLACDSExpDate.Enabled = false;
                txtUSDEACS.Enabled = false;
                txtUSDEACSExpDate.Enabled = false;
                txtNumOperatingRooms.Enabled = false;
                */

                SetReadOnly(this.Controls);
            }
        }

        private void SetReadOnly(ControlCollection controlsCol)
        {
            foreach (Control control in controlsCol)
            {
                if (control is TextBox)
                    ((TextBox)control).Enabled = false;
                else if (control is Button)
                    ((Button)control).Enabled = false;
                else if (control is RadioButton)
                    ((RadioButton)control).Enabled = false;
                else if (control is ImageButton)
                    ((ImageButton)control).Enabled = false;
                else if (control is CheckBox)
                    ((CheckBox)control).Enabled = false;
                else if (control is DropDownList)
                    ((DropDownList)control).Enabled = false;
                else if (control is HyperLink)
                    ((HyperLink)control).Enabled = false;
                else if (control is RadDatePicker)
                    ((RadDatePicker)control).Enabled = false;

                SetReadOnly(control.Controls);
            }
        }

        #region Members Variables

        private bool IsOffSite
        {
            get
            {
                return (ViewState["IsOffSite"] != null ? (bool)ViewState["IsOffSite"] : false);
            }
            set
            {
                ViewState["IsOffSite"] = value;
            }
        }

        private string CurrentAffiliationID
        {
            get
            {
                return (ViewState["CurrentAffiliationID"] != null ? (string)ViewState["CurrentAffiliationID"] : null);
            }
            set
            {
                ViewState["CurrentAffiliationID"] = value;
            }
        }

        private BO_Application CurrentAppProvider
        {
            get
            {
                return Session["CurrentAppProvider"] == null ? null : (BO_Application)Session["CurrentAppProvider"];
            }
            //set
            //{
            //    Session["CurrentAppProvider"] = value;
            //}
        }

        public bool AllowEdit
        {
            get
            {
                return (null != ViewState["AllowEdit"] ? (bool)ViewState["AllowEdit"] : false);
            }
            set
            {
                ViewState["AllowEdit"] = value;
            }
        }

        #endregion
	}
}