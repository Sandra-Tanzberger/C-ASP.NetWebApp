using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using ATG.BusinessObject;
using ATG.Utilities.Data;
using ATG;

namespace AppControl
{
    public partial class LOIMatchFormControl : System.Web.UI.UserControl
    {
        private string _genUserNamePwButtonText = "Generate Username and Password";

        protected void Page_Load(object sender, EventArgs e)
        {
            lblTrackID.Text = loiID.ToString();
        }

        protected void GenButton_Click(object sender, EventArgs e)
        {
            //BO_AppSetups boas = BO_AppSetup.SelectByField("Setting", "NextID");
            //if (null != boas)
            //{
                //txtStateID.Text = facType + boas[0].SettingVal.PadLeft(7, '0').ToUpper();
           // }
        }

      

        protected void FindButton_Click(object sender, EventArgs e)
        {
            //find();
        }

        protected void ViewButton_Click(object sender, EventArgs e)
        {
            //RadWindow newwindow = new RadWindow();
            //newwindow.ID = "RadWindow1";
            //newwindow.NavigateUrl = "Common/DocPrint.aspx?doc=LOI&ID=" + loiID.ToString();
            //newwindow.VisibleOnPageLoad = true;
            //newwindow.Height = 500;
            //newwindow.Width = 700;
            //RadWindowManager1.Windows.Add(newwindow);
        }

        protected void LinkButton_Click(object sender, EventArgs e)
        {
            string _stateId = "";
            BO_AppSetups boas = BO_AppSetup.SelectByField("Setting", "NextID");
            if (null != boas)
            {
                _stateId = facType + boas[0].SettingVal.PadLeft(7, '0').ToUpper();
            }

            BO_Providers providers = BO_Provider.SelectByField("STATE_ID", _stateId.ToUpper());
            if ((btnLink.Text != _genUserNamePwButtonText)
                && providers != null 
                && providers.Count > 0
            ) {
                lblErrMsg.Text = "* " + _stateId + " is already linked to another facility.";
            }
            else
            {
                if (_stateId != "")
                {
                    decimal? PopsIntID = null;

                    BO_LetterOfIntentPrimaryKey bopk = new BO_LetterOfIntentPrimaryKey(loiID);
                    BO_LetterOfIntent selLetter = BO_LetterOfIntent.SelectOne(bopk);

                    if (btnLink.Text != _genUserNamePwButtonText)
                    {
                        BO_Provider newProv = new BO_Provider();
                        newProv.StateID = _stateId.ToUpper();
                        newProv.AspenIntID = null;
                        newProv.StateCode = selLetter.StateCode;
                        newProv.ParishCode = selLetter.ParishCode;
                        newProv.FacilityName = selLetter.Name;
                        newProv.GeographicalStreet = selLetter.GeographicAddress;
                        newProv.GeographicalCity = selLetter.GeographicCity;
                        newProv.GeographicalZip = selLetter.GeographicZip;
                        newProv.GeographicalState = selLetter.StateCode;
                        newProv.TelephoneNumber = selLetter.Phone;
                        newProv.FaxPhoneNumber = selLetter.Fax;
                        newProv.EmailAddress = selLetter.Email;
                        newProv.MailStreet = selLetter.MailAddress;
                        newProv.MailCity = selLetter.MailCity;
                        newProv.MailState = selLetter.MailState;
                        newProv.MailZip = selLetter.MailZip;
                        newProv.ProgramID = selLetter.FacilityType;
                        newProv.Administrator = selLetter.AuthAdminName;
                        newProv.NoOfAirAmbulances = 0;
                        newProv.NoOfAmbulatoryVehicles = 0;
                        newProv.NoOfGroundAmbulances = 0;
                        newProv.NoOfHandicappedVehicles = 0;
                        newProv.NoOfSprintVehicles = 0;
                        //aco sync replacedment functionality - ST - 11012019
                        newProv.StatusCode = "00";
                        newProv.StatusDate = DateTime.Now;

                        newProv.InsertWithDefaultValues(true);

                        BO_Application newApp = new BO_Application();
                        newApp.PopsIntID = newProv.PopsIntID;
                        newApp.StateID = _stateId.ToUpper();
                        newApp.DateStarted = DateTime.Now;
                        newApp.BusinessProcessID = "2"; //Initial License
                        newApp.ProgramID = selLetter.FacilityType;
                        newApp.ApplicationStatus = "1"; //Incomplete
                        newApp.StateCode = selLetter.StateCode;
                        newApp.ParishCode = selLetter.ParishCode;
                        newApp.FacilityName = selLetter.Name;
                        newApp.TelephoneNumber = selLetter.Phone;
                        newApp.FaxPhoneNumber = selLetter.Fax;
                        newApp.EmailAddress = selLetter.Email;
                        newApp.ProposedEffectiveDate = selLetter.PlanToOpenDate;
                        newApp.NoOfAirAmbulances = "0";
                        newApp.NoOfAmbulatoryVehicles = "0";
                        newApp.NoOfGroundAmbulances = "0";
                        newApp.NoOfHandicappedVehicles = "0";
                        newApp.NoOfSprintVehicles = "0";
                        //aco sync replacedment functionality - ST - 11012019
                        newApp.StatusCode = "00";
                        newApp.StatusDate = DateTime.Now;

                        newApp.InsertWithDefaultValues(false);

                        newApp = BO_Application.SelectCurAppByForeignKeyPopsIntID(new BO_ProviderPrimaryKey(newProv.PopsIntID));//only one application exists, initial licensing

                        //create application support table - foreign key application_id
                        BO_ApplicationSupport applicationSupport = new BO_ApplicationSupport();
                        applicationSupport.ApplicationID = newApp.ApplicationID;
                        applicationSupport.FnrApprovalDate = selLetter.FnrApprovalDate;
                        applicationSupport.Insert();

                        // Create new Application_Items records for this new application
                        newApp.InsertAppItemsFromChecklistItemsByBusinessProcessID();

                        selLetter.PopsIntID = newProv.PopsIntID;
                        selLetter.ApplicationID = newApp.ApplicationID;
                        selLetter.StateID = _stateId.ToUpper();
                        selLetter.Confirmed = 1;
                        selLetter.ConfirmedDate = System.DateTime.Today;
                        selLetter.Update();

                        BO_Address newAddr = new BO_Address();
                        newAddr.PopsIntID = newProv.PopsIntID;
                        newAddr.ApplicationID = newApp.ApplicationID;
                        newAddr.AddressType = 1;
                        newAddr.Street = selLetter.GeographicAddress;
                        newAddr.City = selLetter.GeographicCity;
                        newAddr.ZipCode = selLetter.GeographicZip;
                        newAddr.StateCode = selLetter.StateCode;
                        newAddr.ParishCode = selLetter.ParishCode;
                        newAddr.Insert();


                        BO_Address newAddr2 = new BO_Address();
                        newAddr2.PopsIntID = newProv.PopsIntID;
                        newAddr2.ApplicationID = newApp.ApplicationID;
                        newAddr2.AddressType = 2;
                        newAddr2.Street = selLetter.MailAddress;
                        newAddr2.City = selLetter.MailCity;
                        newAddr2.ZipCode = selLetter.MailZip;
                        newAddr2.State = selLetter.MailState;
                        newAddr2.Insert();

                        //add primary ownership record with legal entity and legal entity address info

                        BO_Ownership ownership = new BO_Ownership();
                        BO_LegalEntity legalentity = new BO_LegalEntity();
                        BO_Address address = new BO_Address();

                        address.AddressType = 1;
                        address.Street = selLetter.GeographicAddress;
                        address.City = selLetter.GeographicCity;
                        address.ZipCode = selLetter.GeographicZip;
                        address.StateCode = selLetter.StateCode;
                        address.ParishCode = selLetter.ParishCode;

                        legalentity.EntityName = selLetter.Name;
                        legalentity.EntityPhone = selLetter.Phone;
                        legalentity.EntityFax = selLetter.Fax;
                        legalentity.EntityEin = selLetter.OwnerEin;
                        legalentity.BO_AddressDetail = address;
                        legalentity.BO_AddressDetail.InsertWithDefaultValues(true);
                        legalentity.AddressID = legalentity.BO_AddressDetail.AddressID;

                        ownership.IsPrimary = "1";
                        ownership.PopsIntID = newProv.PopsIntID;
                        ownership.ApplicationID = newApp.ApplicationID;
                        ownership.EffectiveDate = selLetter.ConfirmedDate;
                        ownership.BO_LegalEntityDetail = legalentity;
                        ownership.BO_LegalEntityDetail.InsertWithDefaultValues(true);
                        ownership.LegalEntityID = ownership.BO_LegalEntityDetail.LegalEntityID;
                        ownership.Insert();


                        BO_AppSetups _boas = BO_AppSetup.SelectByField("Setting", "NextID");
                        if (null != _boas)
                        {
                            Int32 isettingval = 0;
                            isettingval = Convert.ToInt32(_boas[0].SettingVal) + 1;
                            _boas[0].SettingVal = Convert.ToString(isettingval);
                            _boas[0].Update();
                        }

                        PopsIntID = newProv.PopsIntID;
                        BO_Billing.NewBillingRecordByForeignKeyApplicationID(new BO_ApplicationPrimaryKey(newApp.ApplicationID));

                    }
                    else
                    {
                        //get pops int id
                        BO_Providers bopvs = BO_Provider.SelectByField("STATE_ID", _stateId.ToUpper());
                        if (bopvs != null)
                        {
                            PopsIntID = bopvs[0].PopsIntID;

                            selLetter.Confirmed = 1;
                            selLetter.Update();
                        }
                    }

                    if (PopsIntID != null)
                    {
                        /*
                        if (_m_bConfirmed)
                        {
                            //Delete existing password for confirmed providers before generating a new one.
                            BO_ProviderLoginPrimaryKey bolipk = new BO_ProviderLoginPrimaryKey(PopsIntID, _stateId.ToUpper());
                            BO_ProviderLogin boli = BO_ProviderLogin.SelectOne(bolipk);
                            if (boli != null)
                                boli.Delete();
                        }

                        //Generate username and password for the new facility and save it to the database
                        //and allow user to print the letter.
                        string un = _stateId.ToUpper();
                        //string pwd = System.Web.Security.Membership.GeneratePassword(10, 0);
                        //string akey = System.Web.Security.Membership.GeneratePassword(10, 0);
                        string pwd = ATG.Utilities.PasswordGenerator.GeneratePassword(6, 7, 1);
                        string akey = ATG.Utilities.PasswordGenerator.GeneratePassword(6, 7, 1);

                        // encrypt password and auth key
                        byte[] encryptedPwd = ATG.Utilities.Crypto.AES.EncryptStringToBytes(pwd);
                        byte[] encryptedAuthKey = ATG.Utilities.Crypto.AES.EncryptStringToBytes(akey);

                        BO_ProviderLogin tmpbopli = new BO_ProviderLogin();
                        //tmpbopli.AuthKey = akey;
                        tmpbopli.AuthKey = encryptedAuthKey;
                        tmpbopli.LoginID = un;
                        //tmpbopli.PassStaff = pwd;
                        tmpbopli.PassStaff = encryptedPwd;
                        tmpbopli.PopsIntID = PopsIntID;
                        tmpbopli.StateID = _stateId.ToUpper();
                        tmpbopli.IsConfirmed = 1;
                        tmpbopli.IsCurrent = 1;
                        tmpbopli.EffectiveDate = System.DateTime.Now;
                        tmpbopli.InsertWithDefaultValues(true);
                        bopli = tmpbopli;

                        btnPrntUN.Enabled = true;
                         * */
                        if (btnLink.Text != _genUserNamePwButtonText)
                        {
                            lblFinalMsg.Text = "The selected letter has been linked to the facility.";
                        }
                       // else
                        //{
                          //  lblFinalMsg.Text = "The Username and Password has been generated.";
                       // }
                        btnLink.Enabled = false;
                        //txtStateID.Enabled = false;
                        //btnGen.Enabled = false;

                        //Reload grid to reset Confirmed Status?
                        //ListLetterOfIntentControl LLOIControl = (ListLetterOfIntentControl)Page.FindControlRecursive("ListLetterOfIntentControl");
                        //LLOIControl.ConfirmSelected();
                    }
                    else
                    {
                        lblFinalMsg.Text = "Error:  Provider could not be found or created.";
                    }
                }
                else
                {
                    lblFinalMsg.Text = "State ID must be generated and Facility found prior to linking.";
                }
            }
        }

        protected void PrintUNButton_Click(object sender, EventArgs e)
        {
            RadWindow newwindow = new RadWindow();
            newwindow.ID = "RadWindow1";
            newwindow.NavigateUrl = "~/DHH/LoginLetterPrint.aspx?LOGINID=" + bopli.LoginID.ToString() + "&LOIID=" + loiID.ToString();
            newwindow.VisibleOnPageLoad = true;
            newwindow.Height = 500;
            newwindow.Width = 700;
            RadWindowManager1.Windows.Add(newwindow);
        }

        /*public void ClearFields(bool bConfirmed)
        {
            _m_bConfirmed = bConfirmed;

            lblErrMsg.Text = "&nbsp;";
            //txtStateID.Text = "";
            string blank = "";
            lblFinalMsg.Text = blank;
            btnPrntUN.Enabled = false;
            //btnLink.Enabled = false;
            if (loiType == "RFA" || bConfirmed)
            {
                BO_LetterOfIntentPrimaryKey bopk = new BO_LetterOfIntentPrimaryKey(loiID);
                BO_LetterOfIntent selLetter = BO_LetterOfIntent.SelectOne(bopk);
                if (selLetter != null)
                {
                    //txtStateID.Text = selLetter.StateID.ToUpper();
                    //txtStateID.Enabled = false;
                    //btnGen.Enabled = false;
                    btnLink.Text = _genUserNamePwButtonText;
                    lblInstructions.Text = "Generate Username and Password for Selected Letter of Intent:";
                    lblInstructions2.Text = "To generate the username and password for the selected Letter of Intent:";
                }
            }
            else
            {
                //txtStateID.Enabled = true;
                //btnGen.Enabled = true;
                btnLink.Text = "Link the Facility to this Letter Of Intent";
                lblInstructions.Text = "Match Selected Letter of Intent:";
                lblInstructions2.Text = "To match the selected Letter of Intent:";
            }
        }
         * */

        public decimal loiID
        {
            get
            {
                if (null == ViewState["loiID"])
                    return 0;
                else
                    return (decimal)ViewState["loiID"];
            }
            set
            {
                ViewState["loiID"] = value;
                lblTrackID.Text = loiID.ToString();
            }
        }

        public string facType
        {
            get
            {
                return (string)ViewState["facType"];
            }
            set
            {
                ViewState["facType"] = value;
            }
        }


        public string loiType
        {
            get
            {
                return (string)ViewState["loiType"];
            }
            set
            {
                ViewState["loiType"] = value;
            }
        }

        public BO_ProviderLogin bopli
        {
            get
            {
                return (BO_ProviderLogin)ViewState["bopli"];
            }
            set
            {
                ViewState["bopli"] = value;
            }
        }

        private bool _m_bConfirmed
        {
            get
            {
                return (bool)ViewState["Confirmed"];
            }
            set
            {
                ViewState["Confirmed"] = value;
            }
        }
    }
}