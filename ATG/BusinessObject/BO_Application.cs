//
// Class	:	BO_Application.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	09/21/2010 11:54:40 AM
//

using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Collections;
using System.Data.Common;
using ATG.Database;

namespace ATG.BusinessObject
{
    public class BO_ApplicationGridFields
    {
        public const string BusinessProcessName = "BUSINESS_PROCESS_NAME";
        public const string StatusValdesc = "STATUS_VALDESC";
        public const string ActionValdesc = "ACTION_VALDESC";
        public const string AspenIntID = "ASPEN_INT_ID";
        public const string ApplicationStatusDesc = "APPLICATION_STATUS_DESC";

    }

	/// <summary>
	/// Data access class for the "APPLICATIONS" table.
	/// </summary>
	[Serializable]
	public class BO_Application : BO_ApplicationBase
	{
	
		#region Class Level Variables
        private string _businessProcessName = null;
        private string _statusValdesc = null;
        private string _actionValdesc = null;
        private string _gridDateStarted = null;
        private BO_FileAttaches _Attachments = null;
        private BO_ChecklistItems _CheckListItems = null;
        private int? _aspenIntIDNonDefault = null;
        private string _applicationStatusDesc = null;
        private BO_Affiliations _bO_AffiliationsApplicationID = null;
        private BO_ApplicationSupport _bo_ApplicationSupport = null;

        #endregion
		
		#region Constants
		
		#endregion

        #region Constructors / Destructors 
        
        public BO_Application() : base()
        {
        }

        #endregion

        #region Properties

        //application data business object added to support additional application fields
        public BO_ApplicationSupport Application_Support
        {
         get
            {
                if (_bo_ApplicationSupport == null)
                {
                    _bo_ApplicationSupport = new BO_ApplicationSupport();
                    BO_ApplicationSupports _bo_ApplicationSupports = new BO_ApplicationSupports();
                    _bo_ApplicationSupports = BO_ApplicationSupport.SelectByField("APPLICATION_ID", ApplicationID);
                    foreach(BO_ApplicationSupport boApplicationSupport in _bo_ApplicationSupports)//application_support is a one to one to the application table, there will not be more than one record
                    {
                        _bo_ApplicationSupport = boApplicationSupport;
                        break;
                    }
                }
                return _bo_ApplicationSupport;
            }
        }

		//Apllication business process ( Initial, Renewal, CHOW...)
        public string BusinessProcessName
		{
			get 
			{ 
                return _businessProcessName;
			}
			set 
			{
            
                _businessProcessName = value; 
			}
		}

		public string StatusValdesc
		{
			get 
			{
                return _statusValdesc;
			}
			set 
			{
                _statusValdesc = value; 
			}
		}

        public string ActionValdesc
        {
            get
            {
                return _actionValdesc;
            }
            set
            {
                _actionValdesc = value;
            }
        }

        //Returns formatted date for grid
		public string GridDateStarted
		{
			get 
			{
                return _gridDateStarted;
			}
			set 
			{

                _gridDateStarted = value; 
			}
		}

        //The actual attachment field is not loaded all other fields are
        public BO_FileAttaches Attachments
        {
            get
            {
                return _Attachments;
            }
            set
            {
                _Attachments = value;
            }
        }

        //Master List for current application type.
        public BO_ChecklistItems CheckListItems
        {
            get
            {
                return _CheckListItems;
            }
            set
            {
                _CheckListItems = value;
            }
        }

        public int? AspenIntID
        {
            get { return _aspenIntIDNonDefault; }
            set { _aspenIntIDNonDefault = value; }
        }

        public string ApplicationStatusDesc
        {
            get { return _applicationStatusDesc; }
            set { _applicationStatusDesc = value; }
        }

        /// <summary>
        /// Provides access to the related table 'AFFILIATION'
        /// </summary>
        public BO_Affiliations BO_AffiliationsApplicationIDFilteredByClosedDate
        {
            get
            {
                if (_bO_AffiliationsApplicationID == null)
                {
                    _bO_AffiliationsApplicationID = new BO_Affiliations();
                    _bO_AffiliationsApplicationID = BO_Affiliation.SelectByField("APPLICATION_ID", ApplicationID);
                }
                return FilterByClosedDate(_bO_AffiliationsApplicationID);
            }
        }

        #endregion

        #region Methods (Public)
        //Main control method for loading an entire application record
        public void LoadFullApplication( decimal inApplicationID )
        {
            SelectOneWithAllChildrenUsingApplicationID( new BO_ApplicationPrimaryKey( inApplicationID ) );
        }

        //Main control method for saving an entire application record
        public void SaveFullApplication()
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            
            oDatabaseHelper.BeginTransaction();
            //this.Update();
            //Save Child Collection values
            //Primary physical and mailing address for the provider
            #region Main Provider Address
            if ( null != this.BO_AddressesApplicationID )
            {
                foreach ( BO_Address boAddr in this.BO_AddressesApplicationID )
                {
                    if ( null == boAddr.AddressID || boAddr.AddressID == 0 )
                    {
                        boAddr.InsertWithDefaultValues( true );
                    }
                    else
                    {
                        boAddr.Update();
                    }
                }
            }
            #endregion Main Provider Address

            //Offsites/Affiliations
            #region Offsite/Affiliation
            if ( null != this.BO_AffiliationsApplicationID )
            {
                int RecCnt = this.BO_AffiliationsApplicationID.Count;
                //Do deletes first
                for ( int delCnt = 0; delCnt < RecCnt; delCnt++ )
                {
                    if ( this.BO_AffiliationsApplicationID[delCnt].Removed )
                        this.BO_AffiliationsApplicationID[delCnt].DeleteCascadeChildren();
                }

                //If there are any left then process them
                if ( null != this.BO_AffiliationsApplicationID )
                {
                    foreach ( BO_Affiliation boAAffil in this.BO_AffiliationsApplicationID )
                    {
                        if ( ( !boAAffil.IsNewRec ) ||
                             ( boAAffil.IsNewRec && boAAffil.NewRecCommitToDB )
                           )
                        {
                            if ( null != boAAffil.BO_AddressAffiliationID )
                            {
                                if ( null == boAAffil.BO_AddressAffiliationID.AddressID
                                    || boAAffil.BO_AddressAffiliationID.AddressID == 0 )
                                {
                                    boAAffil.BO_AddressAffiliationID.InsertWithDefaultValues( true );
                                }
                                else
                                {
                                    boAAffil.BO_AddressAffiliationID.Update();
                                }

                                boAAffil.AddressID = boAAffil.BO_AddressAffiliationID.AddressID;
                            }

                            if ( boAAffil.IsNewRec )
                            {
                                boAAffil.InsertWithDefaultValues( true );
                                boAAffil.IsNewRec = false;
                            }
                            else
                            {
                                boAAffil.Update();
                            }

                            if ( null != boAAffil.BO_CapacitiesAffiliationID )
                            {
                                RecCnt = boAAffil.BO_CapacitiesAffiliationID.Count;

                                for ( int delCnt = 0; delCnt < RecCnt; delCnt++ )
                                {
                                    if ( boAAffil.BO_CapacitiesAffiliationID[delCnt].Removed )
                                        boAAffil.BO_CapacitiesAffiliationID[delCnt].Delete();
                                }

                                if ( null != boAAffil.BO_CapacitiesAffiliationID )
                                {
                                    foreach ( BO_Capacity boCap in boAAffil.BO_CapacitiesAffiliationID )
                                    {
                                        if ( boCap.IsNewRec )
                                        {
                                            boCap.ApplicationID = boAAffil.ApplicationID;
                                            boCap.AffiliationID = boAAffil.AffiliationID;
                                            boCap.InsertWithDefaultValues( true );
                                            boCap.IsNewRec = false;
                                        }
                                        else
                                        {
                                            boCap.Update();
                                        }
                                    }
                                }
                            }

                            if ( null != boAAffil.BO_SpecialtyUnitsAffiliationID )
                            {
                                RecCnt = boAAffil.BO_SpecialtyUnitsAffiliationID.Count;

                                for ( int delCnt = 0; delCnt < RecCnt; delCnt++ )
                                {
                                    if ( boAAffil.BO_SpecialtyUnitsAffiliationID[delCnt].Removed )
                                        boAAffil.BO_SpecialtyUnitsAffiliationID[delCnt].Delete();
                                }

                                if ( null != boAAffil.BO_SpecialtyUnitsAffiliationID )
                                {
                                    foreach ( BO_SpecialtyUnit boSU in boAAffil.BO_SpecialtyUnitsAffiliationID )
                                    {
                                        if ( boSU.IsNewRec )
                                        {
                                            boSU.ApplicationID = boAAffil.ApplicationID;
                                            boSU.InsertWithDefaultValues( true );
                                            boSU.IsNewRec = false;
                                        }
                                        else
                                        {
                                            boSU.Update();
                                        }
                                    }
                                }
                            }

                            if ( null != boAAffil.BO_ServicesAffiliationID )
                            {
                                RecCnt = boAAffil.BO_ServicesAffiliationID.Count;

                                for ( int delCnt = 0; delCnt < RecCnt; delCnt++ )
                                {
                                    if ( boAAffil.BO_ServicesAffiliationID[delCnt].Removed )
                                        boAAffil.BO_ServicesAffiliationID[delCnt].Delete();
                                }

                                if ( null != boAAffil.BO_ServicesAffiliationID )
                                {
                                    foreach ( BO_Service boSvc in boAAffil.BO_ServicesAffiliationID )
                                    {
                                        if ( boSvc.IsNewRec )
                                        {
                                            boSvc.ApplicationID = boAAffil.ApplicationID;
                                            boSvc.AffiliationID = boAAffil.AffiliationID;
                                            boSvc.InsertWithDefaultValues( true );
                                            boSvc.IsNewRec = false;
                                        }
                                        else
                                        {
                                            boSvc.Update();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            #endregion Offsite/Affiliation
            /* removed till 12.5
            //application_support
            #region Application Support
            BO_ApplicationSupport tmpbo_applicationSupport = null;
            BO_ApplicationSupports tpmbo_applicationSupports = BO_ApplicationSupport.SelectByField("APPLICATION_ID", this.ApplicationID);
            foreach (BO_ApplicationSupport boApplicationSupport in tpmbo_applicationSupports)
            {
                tmpbo_applicationSupport = boApplicationSupport;
                break;
            }

            if(tmpbo_applicationSupport == null)
            {
                this.Application_Support.ApplicationID = this.ApplicationID;
                this.Application_Support.Insert();
            }
            else
            {
                this.Application_Support.Update();
            }
            */
            #endregion

            //application Items (Attachments)
            #region Application Items
            if (null != this.Attachments)
            {
                // Check if the Attachments records have been added/updated/removed 
                // and take the appropriate actions with the BO_FileAttach ObjectsC:\LousianaVS2012\State\ATG\BusinessRule\
                foreach (BO_FileAttach tmpFileAttach in this.Attachments)
                {
                    if (tmpFileAttach.IsNewRec)
                    {
                        tmpFileAttach.AttachSaved = "Y";
                        tmpFileAttach.InsertWithDefaultValues(true);
                        tmpFileAttach.IsNewRec = false;
                    }
                    else if (tmpFileAttach.Removed == true)
                    {
                        tmpFileAttach.Delete();
                    }
                    else
                    {
                        tmpFileAttach.AttachSaved = "Y";
                        tmpFileAttach.Update();
                    }
                }
            }

            if ( null != this.BO_ApplicationItemsApplicationID )
            {
                // Update the BO_ApplicationItem objects since the FileAttachID column may have changed
                foreach (BO_ApplicationItem tmpAI in this.BO_ApplicationItemsApplicationID)
                {
                    tmpAI.Update();
                }
            }
            #endregion Application Items

            //Capacity Information for main provider only. See Affiliation processing for 
            //related capacitiy details
            #region Capacity Main Campus
            if ( null != this.BO_CapacitiesApplicationID )
            {
                int RecCnt = this.BO_CapacitiesApplicationID.Count;

                for ( int delCnt = 0; delCnt < RecCnt; delCnt++ )
                {
                    if ( this.BO_CapacitiesApplicationID[delCnt].Removed )
                        this.BO_CapacitiesApplicationID[delCnt].Delete();
                }

                foreach ( BO_Capacity boCap in this.BO_CapacitiesApplicationID )
                {
                    if ( null == boCap.AffiliationID )
                    {
                        if ( boCap.IsNewRec )
                        {
                            boCap.InsertWithDefaultValues( true );
                            boCap.IsNewRec = false;
                        }
                        else
                        {
                            boCap.Update();
                        }
                    }
                }
            }
            #endregion Capacity Main Campus

            //Ownership Information
            #region Ownership
            if ( null != this.BO_OwnershipsApplicationID )
            {
                //First remove Deleted Ownership Records, Detail records are kept as they may
                //be part of a previous application
                int RecCnt = this.BO_OwnershipsApplicationID.Count;

                for ( int delCnt = 0; delCnt < RecCnt; delCnt++ )
                {
                    if ( this.BO_OwnershipsApplicationID[delCnt].Removed )
                        this.BO_OwnershipsApplicationID[delCnt].Delete();
                }

                //Now if there are any left add or update them along with thier details
                if ( null != this.BO_OwnershipsApplicationID )
                {
                    foreach ( BO_Ownership boOwn in this.BO_OwnershipsApplicationID )
                    {
                        if ( !boOwn.Removed )
                        {
                            //Work Backwords through collections to obtain needed ID's for parent child relationships
                            //for new records.
                            //First is Address record
                            if ( null != boOwn.BO_LegalEntityDetail.BO_AddressDetail )
                            {
                                if ( null == boOwn.BO_LegalEntityDetail.BO_AddressDetail.AddressID
                                    || boOwn.BO_LegalEntityDetail.BO_AddressDetail.AddressID == 0 )
                                {
                                    boOwn.BO_LegalEntityDetail.BO_AddressDetail.InsertWithDefaultValues( true );
                                    boOwn.BO_LegalEntityDetail.AddressID = boOwn.BO_LegalEntityDetail.BO_AddressDetail.AddressID;
                                }
                                else
                                {
                                    boOwn.BO_LegalEntityDetail.BO_AddressDetail.Update();
                                }
                            }

                            //Next is Legal Entity
                            if ( boOwn.BO_LegalEntityDetail.IsNewRec )
                            {
                                if ( null != boOwn.BO_LegalEntityDetail.BO_AddressDetail )
                                    boOwn.BO_LegalEntityDetail.AddressID = boOwn.BO_LegalEntityDetail.BO_AddressDetail.AddressID;

                                boOwn.BO_LegalEntityDetail.InsertWithDefaultValues( true );
                                boOwn.LegalEntityID = boOwn.BO_LegalEntityDetail.LegalEntityID;
                                //Reset new record flag for subsequent saves
                                boOwn.BO_LegalEntityDetail.IsNewRec = false;

                                foreach ( BO_OwnerOtherProvider boOOP in boOwn.BO_LegalEntityDetail.BO_OwnerOtherProvidersLegalEntityID )
                                {
                                    if ( boOOP.IsNewRec )
                                    {
                                        boOOP.LegalEntityID = boOwn.BO_LegalEntityDetail.LegalEntityID;
                                        boOOP.InsertWithDefaultValues( true );
                                        //Reset new record flag for subsequent saves
                                        boOwn.BO_LegalEntityDetail.IsNewRec = false;
                                    }
                                    else
                                    {
                                        boOOP.Update();
                                    }
                                }
                            }
                            else
                            {
                                boOwn.BO_LegalEntityDetail.Update();

                                int OOPRecCnt = boOwn.BO_LegalEntityDetail.BO_OwnerOtherProvidersLegalEntityID.Count;

                                for ( int delCnt = 0; delCnt < OOPRecCnt; delCnt++ )
                                {
                                    if ( boOwn.BO_LegalEntityDetail.BO_OwnerOtherProvidersLegalEntityID[delCnt].Removed )
                                        boOwn.BO_LegalEntityDetail.BO_OwnerOtherProvidersLegalEntityID[delCnt].Delete();
                                }

                                foreach ( BO_OwnerOtherProvider boOOP in boOwn.BO_LegalEntityDetail.BO_OwnerOtherProvidersLegalEntityID )
                                {
                                    if ( !boOOP.Removed )
                                    {
                                        boOOP.LegalEntityID = boOwn.BO_LegalEntityDetail.LegalEntityID;

                                        if ( boOOP.IsNewRec )
                                        {
                                            boOOP.InsertWithDefaultValues( true );
                                            //Reset new record flag for subsequent saves
                                            boOwn.BO_LegalEntityDetail.IsNewRec = false;
                                        }
                                        else
                                        {
                                            if ( boOOP.OrigLegalEntityID != boOOP.LegalEntityID )
                                            {
                                                boOOP.UpdateWithNewLegalEntityID();
                                            }
                                            else
                                            {
                                                boOOP.Update();
                                            }
                                        }
                                    }
                                }
                            }

                            //Last is Ownership
                            if ( boOwn.IsNewRec )
                            {
                                boOwn.LegalEntityID = boOwn.BO_LegalEntityDetail.LegalEntityID;
                                boOwn.InsertWithDefaultValues( true );
                                //Reset new record flag for subsequent saves
                                boOwn.IsNewRec = false;
                            }
                            else
                            {
                                boOwn.Update();
                            }
                        }
                    }
                }
            }
            #endregion Ownership

            //Provider Person(Key Personnel) information
            //removed from application save event 10-11-2018 - personnel records, person, education, employment saved directly to db.  
            /*
            #region Provider Person
            if ( null != this.BO_ProviderPeopleApplicationID )
            {
                int RecCnt = this.BO_ProviderPeopleApplicationID.Count;

                for ( int delCnt = 0; delCnt < RecCnt; delCnt++ )
                {
                    if ( this.BO_ProviderPeopleApplicationID[delCnt].Removed )
                        this.BO_ProviderPeopleApplicationID[delCnt].Delete();
                }

                foreach ( BO_ProviderPerson boPP in this.BO_ProviderPeopleApplicationID )
                {
                    if ( null != boPP.BO_PersonDetail.FirstName && null != boPP.BO_PersonDetail.LastName )
                    {
                        //Person record First
                        if ( boPP.BO_PersonDetail.IsNewRec )
                        {
                            boPP.BO_PersonDetail.InsertWithDefaultValues( true );
                            boPP.BO_PersonDetail.IsNewRec = false;
                        }
                        else
                        {
                            boPP.BO_PersonDetail.Update();
                        }

                        //Next education records
                        if ( null != boPP.BO_PersonDetail.BO_EducationsPersonID )
                        {
                            foreach ( BO_Education boEd in boPP.BO_PersonDetail.BO_EducationsPersonID )
                            {
                                if ( boEd.IsNewRec )
                                {
                                    boEd.PersonID = boPP.BO_PersonDetail.PersonID;
                                    boEd.InsertWithDefaultValues( true );
                                    boEd.IsNewRec = false;
                                }
                                else if ( boEd.Removed )
                                {
                                    boEd.Delete();
                                }
                                else
                                {
                                    boEd.Update();
                                }
                            }
                        }

                        //next employment records
                        if ( null != boPP.BO_PersonDetail.BO_EmploymentsPersonID )
                        {
                            foreach ( BO_Employment boEmp in boPP.BO_PersonDetail.BO_EmploymentsPersonID )
                            {
                                if ( boEmp.IsNewRec )
                                {
                                    boEmp.PersonID = boPP.BO_PersonDetail.PersonID;
                                    boEmp.InsertWithDefaultValues( true );
                                    boEmp.IsNewRec = false;
                                }
                                else if ( boEmp.Removed )
                                {
                                    boEmp.Delete();
                                }
                                else
                                {
                                    boEmp.Update();
                                }
                            }
                        }

                        //Last Provider Person Record
                        if ( boPP.IsNewRec )
                        {
                            boPP.PersonID = boPP.BO_PersonDetail.PersonID;
                            boPP.PopsIntID = this.PopsIntID;
                            boPP.ApplicationID = this.ApplicationID;
                            boPP.InsertWithDefaultValues( true );
                            boPP.IsNewRec = false;
                        }
                        else
                        {
                            boPP.Update();
                        }
                    }
                }
            }
            #endregion Provider Person
            */

            //Main Provider Speciatly Units
            #region Main Provider Spicialty Units
            if ( null != this.BO_SpecialtyUnitsApplicationID )
            {
                int RecCnt = this.BO_SpecialtyUnitsApplicationID.Count;

                for ( int delCnt = 0; delCnt < RecCnt; delCnt++ )
                {
                    if ( this.BO_SpecialtyUnitsApplicationID[delCnt].Removed )
                        this.BO_SpecialtyUnitsApplicationID[delCnt].Delete();
                }

                foreach ( BO_SpecialtyUnit boSU in this.BO_SpecialtyUnitsApplicationID )
                {
                    if ( boSU.IsNewRec )
                    {
                        boSU.InsertWithDefaultValues( true );
                        boSU.IsNewRec = false;
                    }
                    else
                    {
                        boSU.Update();
                    }
                }

            }
            #endregion Main Provider Spicialty Units

            //Application Status History
            //Left as stub, but handled as trigger on Application Table
            #region Status History
            if ( null != this.BO_StatusHistoriesApplicationID )
            {
            }
            #endregion Status History

            // Services Information
            #region Services
            if ( null != this.BO_ServicesApplicationID )
            {
                int RecCnt = this.BO_ServicesApplicationID.Count;

                for ( int delCnt = 0; delCnt < RecCnt; delCnt++ )
                {
                    if ( this.BO_ServicesApplicationID[delCnt].Removed )
                        this.BO_ServicesApplicationID[delCnt].Delete();
                }

                foreach ( BO_Service boSvc in this.BO_ServicesApplicationID )
                {
                    if ( null == boSvc.AffiliationID )
                    {
                        if ( boSvc.IsNewRec )
                        {
                            boSvc.InsertWithDefaultValues( true );
                            boSvc.IsNewRec = false;
                        }
                        else
                        {
                            boSvc.Update();
                        }
                    }
                }
            }

            //if (null != this.BO_ServicesApplicationID)
            //{
            //    foreach (BO_Service boService in this.BO_ServicesApplicationID)
            //    {
            //        if (null == boService.ServiceID || boService.ServiceID == 0)
            //        {
            //            boService.InsertWithDefaultValues(true);
            //            boService.IsNewRec = false;
            //        }
            //        else if(boService.Removed == true)
            //        {
            //            boService.Delete();
            //        }
            //        else
            //        {
            //            boService.Update();
            //        }
            //    }
            //}

            //if ( null != this.BO_AffiliationsApplicationID )
            //{
            //    foreach ( BO_Affiliation boAffil in this.BO_AffiliationsApplicationID )
            //    {
            //        if ( null != boAffil.BO_ServicesAffiliationID )
            //        {
            //            foreach ( BO_Service boService in boAffil.BO_ServicesAffiliationID )
            //            {
            //                if ( boService.IsNewRec )
            //                {
            //                    boService.AffiliationID = boAffil.AffiliationID;
            //                    boService.InsertWithDefaultValues( true );
            //                    boService.IsNewRec = false;
            //                }
            //                else if ( boService.Removed == true )
            //                {
            //                    boService.Delete();
            //                }
            //                else
            //                {
            //                    boService.Update();
            //                }
            //            }
            //        }
            //    }
            //}
            #endregion Services

            //effective date writeable on initial license application only, if initial license is approved without a date, set from effective date. per issue #767

            if(BusinessProcessID.Equals("2") & ApplicationStatus.Equals("4"))
            {
                if(OriginalLicensureDate.Equals(null))
                {
                    OriginalLicensureDate = LicensureEffectiveDate;
                }
            }

            this.Update();
            oDatabaseHelper.CommitTransaction();

            //Status history is maintained via a trigger on the application table, so update the values in the
            //local collection.
            this.BO_StatusHistoriesApplicationID =
                BO_StatusHistory.SelectAllByForeignKeyApplicationID( new BO_ApplicationPrimaryKey( this.ApplicationID ) );
            
            if ( !this.ApplicationStatus.Equals("4"))
                BO_Billing.NewBillingRecordByForeignKeyApplicationID( new BO_ApplicationPrimaryKey( this.ApplicationID ) );
        }

        public void GenerateLicensureNum( decimal? inAppID, bool inReplaceExisting )
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;

            oDatabaseHelper.AddParameter( "@ApplicationID", inAppID );

            if ( inReplaceExisting )
                oDatabaseHelper.AddParameter( "@ReplaceExisting", "Y" );
            else
                oDatabaseHelper.AddParameter( "@ReplaceExisting", "N" );

            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter( "@ErrorCode", -1, System.Data.ParameterDirection.Output );

            IDataReader dr = oDatabaseHelper.ExecuteReader( "ATG_LICENSE_GenerateLicensureNumber", ref ExecutionState );

            if ( dr.Read() )
            {
                this.LicensureNum = dr.GetString( 0 );
            }

            dr.Close();
            oDatabaseHelper.Dispose();
        }
        
        /// <summary>
        /// This method will get row(s) from the database using the value of the field specified 
        /// along with the details of the child table.
        /// </summary>
        ///
        /// <param name="pk" type="APPLICATIONSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
        ///
        /// <returns>object of class APPLICATIONS</returns>
        ///
        /// <remarks>
        ///
        /// <RevisionHistory>
        /// Author				Date			Description
        /// DLGenerator			12/13/2010 9:44:38 AM				Created function
        /// 
        /// </RevisionHistory>
        ///
        /// </remarks>
        ///
        private void SelectOneWithAllChildrenUsingApplicationID( BO_ApplicationPrimaryKey pk )
        {

            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
            //BO_Application obj = null;
            
            // Pass the values of all key parameters to the stored procedure.
            System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
            foreach ( string key in nvc.Keys )
            {
                oDatabaseHelper.AddParameter( "@" + key, nvc[key] );
            }

            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter( "@ErrorCode", -1, System.Data.ParameterDirection.Output );

            IDataReader dr = oDatabaseHelper.ExecuteReader( "ATG_APPLICATIONS_SelectOneWithAllChildrenUsingApplicationID", ref ExecutionState );
            if ( dr.Read() )
            {
                //obj = new BO_Application();
                //PopulateObjectFromReader( obj, dr );
                PopulateObjectFromReader( this, dr );

                dr.NextResult();

                //Fill Child Collections
                this.BO_AddressesApplicationID = BO_Address.PopulateObjectsFromReader( dr );
                dr.NextResult();
                this.BO_AffiliationsApplicationID = BO_Affiliation.PopulateObjectsFromReaderWithAllChildrenApplicationID( dr, pk );
                dr.NextResult();
                this.BO_ApplicationItemsApplicationID = BO_ApplicationItem.PopulateObjectsFromReader( dr );
                dr.NextResult();
                //this.BO_BillingsApplicationID = BO_Billing.PopulateObjectsFromReader( dr );
                this.BO_BillingsApplicationID = BO_Billing.PopulateObjectsFromReaderWithAllChildrenApplicationID( dr );
                dr.NextResult();
                this.BO_CapacitiesApplicationID = BO_Capacity.PopulateObjectsFromReader( dr );
                dr.NextResult();
                this.BO_LetterOfIntentsApplicationID = BO_LetterOfIntent.PopulateObjectsFromReader( dr );
                dr.NextResult();
                //this.BO_OwnershipsApplicationID = BO_Ownership.PopulateObjectsFromReader( dr );
                this.BO_OwnershipsApplicationID = BO_Ownership.PopulateObjectsFromReaderWithAllChildrenApplicationID( dr, pk );
                dr.NextResult();
                //this.BO_ProviderPeopleApplicationID = BO_ProviderPerson.PopulateObjectsFromReader( dr );
                this.BO_ProviderPeopleApplicationID = BO_ProviderPerson.PopulateObjectsFromReaderWithAllChildrenApplicationID( dr, pk );
                dr.NextResult();
                this.BO_ServicesApplicationID = BO_Service.PopulateObjectsFromReader( dr );
                dr.NextResult();
                this.BO_SpecialtyUnitsApplicationID = BO_SpecialtyUnit.PopulateObjectsFromReader( dr );
                dr.NextResult();
                this.BO_StaffingsApplicationID = BO_Staffing.PopulateObjectsFromReader( dr );
                dr.NextResult();
                //this.BO_SubstationsApplicationID = BO_Substation.PopulateObjectsFromReader( dr );
                //dr.NextResult();
                //this.BO_VehiclesApplicationID = BO_Vehicle.PopulateObjectsFromReader( dr );
                //dr.NextResult();
                this.Attachments = BO_FileAttach.PopulateObjectsFromReaderSummary( dr );
                dr.NextResult();
                this.BO_StatusHistoriesApplicationID = BO_StatusHistory.PopulateObjectsFromReader( dr );
            }
            dr.Close();
            oDatabaseHelper.Dispose();

        }
        
        /// <summary>
        /// This method will create an Application record along with all child records for the given provider
        /// and business process
        /// </summary>
        ///
        /// <param name="pk" type="PROVIDERSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
        ///
        /// <returns>object of class BO_Applications</returns>
        ///
        /// <remarks>
        ///
        /// <RevisionHistory>
        /// Author				Date			Description
        /// Shawn Martin		01/18/2011		Created function
        /// 
        /// </RevisionHistory>
        ///
        /// </remarks>
        ///
        public static void CreateApplicationByForeignKeyPopsIntID( BO_ProviderPrimaryKey pk, string inBusinesssProcessID )
        {

            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
            //BO_Application obj = null;

            // Pass the values of all key parameters to the stored procedure.
            System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
            foreach ( string key in nvc.Keys )
            {
                oDatabaseHelper.AddParameter( "@" + key, nvc[key] );
            }

            oDatabaseHelper.AddParameter( "@BusinessProcessID", inBusinesssProcessID );
            oDatabaseHelper.AddParameter( "@ApplicationID", System.Data.ParameterDirection.Output );
            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter( "@ErrorCode", -1, System.Data.ParameterDirection.Output );

            IDataReader dr = oDatabaseHelper.ExecuteReader( "ATG_APPLICATIONS_CreateNewApplication", ref ExecutionState );
            dr.Close();
            oDatabaseHelper.Dispose();
        }

        /// <summary>
        /// This method will Delete an application and all associated child table records using the primary key information
        /// </summary>
        ///
        /// <param name="pk" type="BO_ApplicationPrimaryKey">Primary Key information based on which data is to be fetched.</param>
        ///
        /// <returns>True if succeeded</returns>
        ///
        /// <remarks>
        ///
        /// <RevisionHistory>
        /// Author				Date			Description
        /// Shawn Martin		01/18/2011		Created function
        /// 
        /// </RevisionHistory>
        ///
        /// </remarks>
        ///
        public static bool DeleteOneWithAllChildrenUsingApplicationID( BO_ApplicationPrimaryKey pk )
        {

            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;

            // Pass the values of all key parameters to the stored procedure.
            System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
            foreach ( string key in nvc.Keys )
            {
                oDatabaseHelper.AddParameter( "@" + key, nvc[key] );
            }
            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter( "@ErrorCode", -1, System.Data.ParameterDirection.Output );

            oDatabaseHelper.ExecuteScalar( "ATG_APPLICATIONS_DeleteApplication", ref ExecutionState );
            oDatabaseHelper.Dispose();
            return ExecutionState;

        }

        /// <summary>
        /// This method will get row(s) from the database using the value of the field specified 
        /// along with the details of the child table.
        /// </summary>
        ///
        /// <param name="pk" type="PROVIDERSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
        ///
        /// <returns>object of class BO_Applications</returns>
        ///
        /// <remarks>
        ///
        /// <RevisionHistory>
        /// Author				Date			Description
        /// DLGenerator			09/21/2010 11:54:39 AM				Created function
        /// 
        /// </RevisionHistory>
        ///
        /// </remarks>
        ///
        public static BO_Applications SelectForGridByForeignKeyPopsIntID( BO_ProviderPrimaryKey pk )
        {

            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;

            // Pass the values of all key parameters to the stored procedure.
            System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
            foreach ( string key in nvc.Keys )
            {
                oDatabaseHelper.AddParameter( "@" + key, nvc[key] );
            }

            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter( "@ErrorCode", -1, System.Data.ParameterDirection.Output );

            IDataReader dr = oDatabaseHelper.ExecuteReader( "ATG_APPLICATIONS_SelectForGridByForeignKeyPopsIntID", ref ExecutionState );
            BO_Applications BO_Applications = BO_Application.PopulateObjectsFromReaderWithCheckingReaderForGrid(dr, oDatabaseHelper);

            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Applications;
        }

        /// <summary>
        /// Returns all approved Applications for a given Provider
        /// </summary>
        /// <param name="pk"></param>
        /// <returns></returns>
        public static BO_Applications SelectApprovedApplicationsByPopsIntId(BO_ProviderPrimaryKey pk)
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;

            // Pass the values of all key parameters to the stored procedure.
            System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
            foreach (string key in nvc.Keys)
            {
                oDatabaseHelper.AddParameter("@" + key, nvc[key]);
            }

            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            IDataReader dr = oDatabaseHelper.ExecuteReader("ATG_APPLICATIONS_SelectApprovedApplicationsByPopsIntId", ref ExecutionState);
            BO_Applications BO_Applications = BO_Application.PopulateObjectsFromReaderWithCheckingReaderForApprovedApps(dr, oDatabaseHelper);

            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Applications;
        }

        /// <summary>
        /// Returns current approved Application for a given Provider
        /// </summary>
        /// <param name="pk"></param>
        /// <returns></returns>
        public static BO_Applications SelectCurrentApprovedApplicationsByPopsIntId(BO_ProviderPrimaryKey pk)
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;

            // Pass the values of all key parameters to the stored procedure.
            System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
            foreach (string key in nvc.Keys)
            {
                oDatabaseHelper.AddParameter("@" + key, nvc[key]);
            }

            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            IDataReader dr = oDatabaseHelper.ExecuteReader("ATG_APPLICATIONS_SelectCurrentApprovedApplicationsByPopsIntId", ref ExecutionState);
            BO_Applications BO_Applications = BO_Application.PopulateObjectsFromReaderWithCheckingReaderForCurrentApprovedApps(dr, oDatabaseHelper);

            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Applications;
        }

        /// <summary>
        /// This method will return an object representing the record matching the primary key information specified.
        /// </summary>
        ///
        /// <param name="pk" type="BO_ApplicationPrimaryKey">Primary Key information based on which data is to be fetched.</param>
        ///
        /// <returns>object of class BO_Application</returns>
        ///
        /// <remarks>
        ///
        /// <RevisionHistory>
        /// Author				Date			Description
        /// DLGenerator			05/10/2012 10:10:42 PM		Created function
        /// 
        /// </RevisionHistory>
        ///
        /// </remarks>
        ///
        public static BO_Application SelectCurAppByForeignKeyPopsIntID( BO_ProviderPrimaryKey pk )
        {

            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;

            // Pass the values of all key parameters to the stored procedure.
            System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
            foreach ( string key in nvc.Keys )
            {
                oDatabaseHelper.AddParameter( "@" + key, nvc[key] );
            }
            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter( "@ErrorCode", -1, System.Data.ParameterDirection.Output );

            IDataReader dr = oDatabaseHelper.ExecuteReader( "ATG_APPLICATIONS_SelectCurAppByForeignKeyPopsIntID", ref ExecutionState );
            if ( dr.Read() )
            {
                BO_Application obj = new BO_Application();
                PopulateObjectFromReader( obj, dr );
                dr.Close();
                oDatabaseHelper.Dispose();
                return obj;
            }
            else
            {
                dr.Close();
                oDatabaseHelper.Dispose();
                return null;
            }

        }
        
        /// <summary>
        /// Used for populating the Process grid with all providers with
        /// 'Open' applications
        /// </summary>
        /// <returns></returns>
        public static BO_Applications SelectAllProvidersInProcessForGrid()
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;

            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            IDataReader dr = oDatabaseHelper.ExecuteReader("ATG_APPLICATIONS_SelectAllProvidersInProcessForGrid", ref ExecutionState);
            BO_Applications BO_Applications = BO_Application.PopulateObjectsFromReaderWithCheckingReaderForProcessGrid(dr, oDatabaseHelper);

            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Applications;
        }

        public static BO_Applications SelectProvidersByProcessForGrid(BO_BusinessProcessePrimaryKey pk)
        {

            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;

            // Pass the values of all key parameters to the stored procedure.
            System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
            foreach (string key in nvc.Keys)
            {
                oDatabaseHelper.AddParameter("@" + key, nvc[key]);
            }

            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            IDataReader dr = oDatabaseHelper.ExecuteReader("ATG_APPLICATIONS_SelectProvidersByProcessForGrid", ref ExecutionState);
            BO_Applications BO_Applications = BO_Application.PopulateObjectsFromReaderWithCheckingReaderForProcessGrid(dr, oDatabaseHelper);

            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Applications;
        }

        public static BO_Application SelectMostRecentlyApprovedAppByPopsIntID(BO_ProviderPrimaryKey pk)
        {
            object appID = null;
            BO_Application boApplication = null;

            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;

            oDatabaseHelper.AddParameter("@PopsIntID", pk.PopsIntID, ParameterDirection.Input);
            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            appID = oDatabaseHelper.ExecuteScalar("ATG_APPLICATIONS_SelectMostRecentlyApprovedAppByPopsIntId", ref ExecutionState);

            if (appID != null)
                boApplication = BO_Application.SelectOne(new BO_ApplicationPrimaryKey(Convert.ToDecimal(appID)));

            oDatabaseHelper.Dispose();
            return boApplication;
        }

        public static BO_Applications SelectAllProvidersInProcessForFacGrid(decimal PopsIntID)
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;

            oDatabaseHelper.AddParameter("@PopsIntID", PopsIntID);
            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            IDataReader dr = oDatabaseHelper.ExecuteReader("ATG_APPLICATIONS_SelectAllProvidersInProcessForFacGrid", ref ExecutionState);
            BO_Applications BO_Applications = BO_Application.PopulateObjectsFromReaderWithCheckingReaderForProcessGrid(dr, oDatabaseHelper);

            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Applications;
        }
        
        public static BO_Applications SelectProvidersByProcessForFacGrid(BO_BusinessProcessePrimaryKey pk, decimal PopsIntID)
        {

            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;

            // Pass the values of all key parameters to the stored procedure.
            System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
            foreach (string key in nvc.Keys)
            {
                oDatabaseHelper.AddParameter("@" + key, nvc[key]);
            }
            oDatabaseHelper.AddParameter("@PopsIntID", PopsIntID);
           

            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            IDataReader dr = oDatabaseHelper.ExecuteReader("ATG_APPLICATIONS_SelectProvidersByProcessForFacGrid", ref ExecutionState);
            BO_Applications BO_Applications = BO_Application.PopulateObjectsFromReaderWithCheckingReaderForProcessGrid(dr, oDatabaseHelper);

            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Applications;
        }

        /// <summary>
        /// Copies checklist items for the current business process to the APPLICATION_ITEMS table
        /// for a given Application
        /// </summary>
        public bool InsertAppItemsFromChecklistItemsByBusinessProcessID()
        {
            bool ExecutionState = false;
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();

            // Pass the value of parameter 'BusinessProcessID' of the stored procedure.
            if (BusinessProcessID != null)
                oDatabaseHelper.AddParameter("@BusinessProcessID", BusinessProcessID);
            else
                oDatabaseHelper.AddParameter("@BusinessProcessID", DBNull.Value);

            // Pass the value of parameter 'ApplicationID' of the stored procedure.
            if (ApplicationID != null)
                oDatabaseHelper.AddParameter("@ApplicationID", ApplicationID);
            else
                oDatabaseHelper.AddParameter("@ApplicationID", DBNull.Value);

            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            oDatabaseHelper.ExecuteScalar("ATG_APPLICATION_ITEMS_InsertFromChecklistItemsByBusinessProcessID", ref ExecutionState);
            
            oDatabaseHelper.Dispose();

            return ExecutionState;
        }

		
		#region Methods (Private)

        /// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
        ///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
        ///
        /// <returns>Object of BO_Applications</returns>
        ///
        /// <remarks>
        ///
        /// <RevisionHistory>
        /// Author				Date			Description
        /// DLGenerator			11/03/2010 2:24:19 PM		Created function
        /// 
        /// </RevisionHistory>
        ///
        /// </remarks>
        ///
        private BO_Affiliations FilterByClosedDate(BO_Affiliations affiliations)
        {
            BO_Affiliations tempAffiliations = new BO_Affiliations();
            foreach (BO_Affiliation affiliation in affiliations)
            {
                if (affiliation.ClosedDate.HasValue )
                    tempAffiliations.Add(affiliation);

            }
            foreach (BO_Affiliation tempAffiliation in tempAffiliations)
            {
                affiliations.Remove(tempAffiliation);
            }
            return affiliations;
        }

        internal static BO_Applications PopulateObjectsFromReaderWithCheckingReaderForGrid( IDataReader rdr, DatabaseHelper oDatabaseHelper )
        {

            BO_Applications list = new BO_Applications();

            if ( rdr.Read() )
            {
                BO_Application obj = new BO_Application();
                PopulateObjectFromReaderForGrid( obj, rdr );
                list.Add( obj );
                while ( rdr.Read() )
                {
                    obj = new BO_Application();
                    PopulateObjectFromReaderForGrid( obj, rdr );
                    list.Add( obj );
                }
                oDatabaseHelper.Dispose();
                return list;
            }
            else
            {
                oDatabaseHelper.Dispose();
                return null;
            }
        }

        internal static BO_Applications PopulateObjectsFromReaderWithCheckingReaderForProcessGrid(IDataReader rdr, DatabaseHelper oDatabaseHelper)
        {

            BO_Applications list = new BO_Applications();

            if (rdr.Read())
            {
                BO_Application obj = new BO_Application();
                PopulateObjectFromReaderForProcessGrid(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_Application();
                    PopulateObjectFromReaderForProcessGrid(obj, rdr);
                    list.Add(obj);
                }
                oDatabaseHelper.Dispose();
                return list;
            }
            else
            {
                oDatabaseHelper.Dispose();
                return null;
            }
        }

        /// <summary>
        /// Called by SelectApprovedApplicationsByPopsIntId
        /// </summary>
        /// <param name="rdr"></param>
        /// <param name="oDatabaseHelper"></param>
        /// <returns></returns>
        internal static BO_Applications PopulateObjectsFromReaderWithCheckingReaderForApprovedApps(IDataReader rdr, DatabaseHelper oDatabaseHelper)
        {

            BO_Applications list = new BO_Applications();

            if (rdr.Read())
            {
                BO_Application obj = new BO_Application();
                PopulateObjectFromReaderForApprovedApps(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_Application();
                    PopulateObjectFromReaderForApprovedApps(obj, rdr);
                    list.Add(obj);
                }
                oDatabaseHelper.Dispose();
                return list;
            }
            else
            {
                oDatabaseHelper.Dispose();
                return null;
            }
        }
        
        internal static void PopulateObjectFromReaderForGrid( BO_Application obj, IDataReader rdr )
        {

            obj.ApplicationID = Convert.ToDecimal( rdr.GetValue( rdr.GetOrdinal( BO_ApplicationFields.ApplicationID ) ) );
            obj.PopsIntID = Convert.ToDecimal( rdr.GetValue( rdr.GetOrdinal( BO_ApplicationFields.PopsIntID ) ) );
            obj.BusinessProcessID = rdr.GetString( rdr.GetOrdinal( BO_ApplicationFields.BusinessProcessID ) );
            
            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.FederalID)))
            {
                obj.FederalID = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.FederalID));
            }

            if ( !rdr.IsDBNull( rdr.GetOrdinal( BO_ApplicationGridFields.BusinessProcessName ) ) )
            {
                obj.BusinessProcessName = rdr.GetString( rdr.GetOrdinal( BO_ApplicationGridFields.BusinessProcessName ) );
            }

            if ( !rdr.IsDBNull( rdr.GetOrdinal( BO_ApplicationFields.StateID ) ) )
            {
                obj.StateID = rdr.GetString( rdr.GetOrdinal( BO_ApplicationFields.StateID ) );
            }

            if ( !rdr.IsDBNull( rdr.GetOrdinal( BO_ApplicationFields.ApplicationStatus ) ) )
            {
                obj.ApplicationStatus = rdr.GetString( rdr.GetOrdinal( BO_ApplicationFields.ApplicationStatus ) );
            }
            
            if ( !rdr.IsDBNull( rdr.GetOrdinal( BO_ApplicationFields.ApplicationAction ) ) )
            {
                obj.ApplicationAction = rdr.GetString( rdr.GetOrdinal( BO_ApplicationFields.ApplicationAction ) );
            }

            if ( !rdr.IsDBNull( rdr.GetOrdinal( BO_ApplicationFields.ProgramID ) ) )
            {
                obj.ProgramID = rdr.GetString( rdr.GetOrdinal( BO_ApplicationFields.ProgramID ) );
            }

            if ( !rdr.IsDBNull( rdr.GetOrdinal( BO_ApplicationFields.DateStarted ) ) )
            {
                obj.GridDateStarted = rdr.GetDateTime( rdr.GetOrdinal( BO_ApplicationFields.DateStarted ) ).ToShortDateString();
            }

            if ( !rdr.IsDBNull( rdr.GetOrdinal( BO_ApplicationFields.DateCompleted ) ) )
            {
                obj.DateCompleted = rdr.GetDateTime( rdr.GetOrdinal( BO_ApplicationFields.DateCompleted ) );
            }

            if ( !rdr.IsDBNull( rdr.GetOrdinal( BO_ApplicationFields.ApplicationStatus ) ) )
            {
                obj.ApplicationStatus = rdr.GetString( rdr.GetOrdinal( BO_ApplicationFields.ApplicationStatus ) );
            }

            if ( !rdr.IsDBNull( rdr.GetOrdinal( BO_ApplicationGridFields.StatusValdesc ) ) )
            {
                obj.StatusValdesc = rdr.GetString( rdr.GetOrdinal( BO_ApplicationGridFields.StatusValdesc ) );
            }

            if ( !rdr.IsDBNull( rdr.GetOrdinal( BO_ApplicationGridFields.ActionValdesc ) ) )
            {
                obj.ActionValdesc = rdr.GetString( rdr.GetOrdinal( BO_ApplicationGridFields.ActionValdesc ) );
            }

            if ( !rdr.IsDBNull( rdr.GetOrdinal( BO_ApplicationFields.LicensureExpirationDate ) ) )
            {
                obj.LicensureExpirationDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ApplicationFields.LicensureExpirationDate));
            }
        }

        internal static void PopulateObjectFromReaderForProcessGrid(BO_Application obj, IDataReader rdr)
        {
            obj.ApplicationID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_ApplicationFields.ApplicationID)));
            obj.PopsIntID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_ApplicationFields.PopsIntID)));

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationGridFields.BusinessProcessName)))
            {
                obj.BusinessProcessName = rdr.GetString(rdr.GetOrdinal(BO_ApplicationGridFields.BusinessProcessName));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.StateID)))
            {
                obj.StateID = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.StateID));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.ProgramID)))
            {
                obj.ProgramID = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.ProgramID));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.FacilityName)))
            {
                obj.FacilityName = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.FacilityName));
            }

            if ( !rdr.IsDBNull( rdr.GetOrdinal( BO_ApplicationFields.LicensureExpirationDate ) ) )
            {
                obj.LicensureExpirationDate = rdr.GetDateTime( rdr.GetOrdinal( BO_ApplicationFields.LicensureExpirationDate ) );
            }

            // custom field for Process grid
            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationGridFields.AspenIntID)))
            {
                obj.AspenIntID = rdr.GetInt32(rdr.GetOrdinal(BO_ApplicationGridFields.AspenIntID));
            }

            // custom field for status description
            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationGridFields.ApplicationStatusDesc)))
            {
                obj.ApplicationStatusDesc = rdr.GetString(rdr.GetOrdinal(BO_ApplicationGridFields.ApplicationStatusDesc));
            }
        }

        /// <summary>
        /// Called by PopulateObjectsFromReaderWithCheckingReaderForApprovedApps
        /// This is used while getting a list of Approved Applications
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="rdr"></param>
        internal static void PopulateObjectFromReaderForApprovedApps(BO_Application obj, IDataReader rdr)
        {
            obj.ApplicationID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_ApplicationFields.ApplicationID)));
            obj.PopsIntID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_ApplicationFields.PopsIntID)));
        }

        /// <summary>
        /// Called by SelectCurrentApprovedApplicationsByPopsIntId
        /// </summary>
        /// <param name="rdr"></param>
        /// <param name="oDatabaseHelper"></param>
        /// <returns></returns>
        internal static BO_Applications PopulateObjectsFromReaderWithCheckingReaderForCurrentApprovedApps(IDataReader rdr, DatabaseHelper oDatabaseHelper)
        {
            BO_Applications list = new BO_Applications();

            if (rdr.Read())
            {
                BO_Application obj = new BO_Application();

                obj.ApplicationID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_ApplicationFields.ApplicationID)));

                list.Add(obj);
               
                oDatabaseHelper.Dispose();
                return list;
            }
            else
            {
                oDatabaseHelper.Dispose();
                return null;
            }
        }

        #endregion

	}
	
}
