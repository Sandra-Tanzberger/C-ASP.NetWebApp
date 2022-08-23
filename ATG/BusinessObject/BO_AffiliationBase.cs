//
// Class	:	BO_AffiliationBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	06/23/2015 12:29:52 PM
//

using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Collections;
using System.Data.Common;
using System.IO;
using System.Xml;
using ATG.Database;

namespace ATG.BusinessObject
{

	/// <summary>
	/// Class for the properties of the object
	/// </summary>
	public class BO_AffiliationFields
	{
		public const string PopsIntID                 = "POPS_INT_ID";
		public const string AffiliationID             = "AFFILIATION_ID";
		public const string TypeAffiliation           = "TYPE_AFFILIATION";
		public const string ApplicationID             = "APPLICATION_ID";
		public const string AddressID                 = "ADDRESS_ID";
		public const string Active                    = "ACTIVE";
		public const string BranchID                  = "BRANCH_ID";
		public const string MedicareBranchID          = "MEDICARE_BRANCH_ID";
		public const string ClosedDate                = "CLOSED_DATE";
		public const string FacilityName              = "FACILITY_NAME";
		public const string OpenedDate                = "OPENED_DATE";
		public const string OperStatCode              = "OPER_STAT_CODE";
		public const string LicensureNum              = "LICENSURE_NUM";
		public const string OriginalLicensureDate     = "ORIGINAL_LICENSURE_DATE";
		public const string TelephoneNumber           = "TELEPHONE_NUMBER";
		public const string FaxPhoneNumber            = "FAX_PHONE_NUMBER";
		public const string NumberOfBeds              = "NUMBER_OF_BEDS";
		public const string TotalLicBeds              = "TOTAL_LIC_BEDS";
		public const string PsychiatricBeds           = "PSYCHIATRIC_BEDS";
		public const string RehabilitationBeds        = "REHABILITATION_BEDS";
		public const string SnfBeds                   = "SNF_BEDS";
		public const string OtherBeds                 = "OTHER_BEDS";
		public const string Unit                      = "UNIT";
		public const string TypeFacility              = "TYPE_FACILITY";
		public const string Ccn                       = "CCN";
		public const string OnMainCampus              = "ON_MAIN_CAMPUS";
		public const string TypeOfClients             = "TYPE_OF_CLIENTS";
		public const string AgeRangeFrom              = "AGE_RANGE_FROM";
		public const string AgeRangeTO                = "AGE_RANGE_TO";
		public const string CurrentLicIssueDate       = "CURRENT_LIC_ISSUE_DATE";
		public const string OriginalApplicationID     = "ORIGINAL_APPLICATION_ID";
		public const string TypeFacility1             = "TYPE_FACILITY_1";
		public const string TypeFacility2             = "TYPE_FACILITY_2";
		public const string TypeFacility3             = "TYPE_FACILITY_3";
		public const string TypeFacility4             = "TYPE_FACILITY_4";
		public const string TypeFacility5             = "TYPE_FACILITY_5";
		public const string TypeFacility6             = "TYPE_FACILITY_6";
		public const string Capacity                  = "CAPACITY";
		public const string FederalID                 = "FEDERAL_ID";
		public const string MedicaidVendorNumber      = "MEDICAID_VENDOR_NUMBER";
		public const string NumActivePatients         = "NUM_ACTIVE_PATIENTS";
		public const string FacilityTypeCode          = "FACILITY_TYPE_CODE";
		public const string TypeTreatment             = "TYPE_TREATMENT";
		public const string OffsiteOrigLicensureDate  = "OFFSITE_ORIG_LICENSURE_DATE";
		public const string OffsiteCurrentLicIssueDate = "OFFSITE_CURRENT_LIC_ISSUE_DATE";
		public const string OffsiteLicEffectiveDate   = "OFFSITE_LIC_EFFECTIVE_DATE";
	}
	
	/// <summary>
	/// Data access class for the "AFFILIATION" table.
	/// </summary>
	[Serializable]
	public class BO_AffiliationBase
	{
		
		#region Class Level Variables
		
		private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private decimal?       	_popsIntIDNonDefault     	= null;
		private decimal?       	_affiliationIDNonDefault 	= null;
		private string         	_typeAffiliationNonDefault	= null;
		private decimal?       	_applicationIDNonDefault 	= null;
		private decimal?       	_addressIDNonDefault     	= null;
		private string         	_activeNonDefault        	= null;
		private decimal?       	_branchIDNonDefault      	= null;
		private string         	_medicareBranchIDNonDefault	= null;
		private DateTime?      	_closedDateNonDefault    	= null;
		private string         	_facilityNameNonDefault  	= null;
		private DateTime?      	_openedDateNonDefault    	= null;
		private string         	_operStatCodeNonDefault  	= null;
		private string         	_licensureNumNonDefault  	= null;
		private DateTime?      	_originalLicensureDateNonDefault	= null;
		private string         	_telephoneNumberNonDefault	= null;
		private string         	_faxPhoneNumberNonDefault	= null;
		private int?           	_numberOfBedsNonDefault  	= null;
		private int?           	_totalLicBedsNonDefault  	= null;
		private int?           	_psychiatricBedsNonDefault	= null;
		private int?           	_rehabilitationBedsNonDefault	= null;
		private int?           	_snfBedsNonDefault       	= null;
		private int?           	_otherBedsNonDefault     	= null;
		private int?           	_unitNonDefault          	= null;
		private string         	_typeFacilityNonDefault  	= null;
		private string         	_ccnNonDefault           	= null;
		private string         	_onMainCampusNonDefault  	= null;
		private string         	_typeOfClientsNonDefault 	= null;
		private int?           	_ageRangeFromNonDefault  	= null;
		private int?           	_ageRangeTONonDefault    	= null;
		private DateTime?      	_currentLicIssueDateNonDefault	= null;
		private decimal?       	_originalApplicationIDNonDefault	= null;
		private string         	_typeFacility1NonDefault 	= null;
		private string         	_typeFacility2NonDefault 	= null;
		private string         	_typeFacility3NonDefault 	= null;
		private string         	_typeFacility4NonDefault 	= null;
		private string         	_typeFacility5NonDefault 	= null;
		private string         	_typeFacility6NonDefault 	= null;
		private int?           	_capacityNonDefault      	= null;
		private string         	_federalIDNonDefault     	= null;
		private string         	_medicaidVendorNumberNonDefault	= null;
		private int?           	_numActivePatientsNonDefault	= null;
		private string         	_facilityTypeCodeNonDefault	= null;
		private string         	_typeTreatmentNonDefault 	= null;
		private DateTime?      	_offsiteOrigLicensureDateNonDefault	= null;
		private DateTime?      	_offsiteCurrentLicIssueDateNonDefault	= null;
		private DateTime?      	_offsiteLicEffectiveDateNonDefault	= null;

		private BO_Capacities _bO_CapacitiesAffiliationID = null;
		private BO_Services _bO_ServicesAffiliationID = null;
		private BO_SpecialtyUnits _bO_SpecialtyUnitsAffiliationID = null;
		
		#endregion
		
		#region Constants
		
		#endregion
		
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_AffiliationBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// Returns the identifier of the persistent object. Mandatory.
		/// </summary>
		public decimal? PopsIntID
		{
			get 
			{ 
                return _popsIntIDNonDefault;
			}
			set 
			{
            
                _popsIntIDNonDefault = value; 
			}
		}

		/// <summary>
		/// Returns the identifier of the persistent object. Don't set it manually!
		/// </summary>
		public decimal? AffiliationID
		{
			get 
			{ 
                return _affiliationIDNonDefault;
			}
			set 
			{
            
                _affiliationIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_AFFILIATION" field. Length must be between 0 and 2 characters. 
		/// </summary>
		public string TypeAffiliation
		{
			get 
			{ 
                if(_typeAffiliationNonDefault==null)return _typeAffiliationNonDefault;
				else return _typeAffiliationNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 2)
					throw new ArgumentException("TypeAffiliation length must be between 0 and 2 characters.");

				
                if(value ==null)
                {
                    _typeAffiliationNonDefault =null;//null value 
                }
                else
                {		           
		            _typeAffiliationNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// Returns the identifier of the persistent object. Mandatory.
		/// </summary>
		public decimal? ApplicationID
		{
			get 
			{ 
                return _applicationIDNonDefault;
			}
			set 
			{
            
                _applicationIDNonDefault = value; 
			}
		}

		/// <summary>
		/// The foreign key connected with another persistent object.
		/// </summary>
		public decimal? AddressID
		{
			get 
			{ 
                return _addressIDNonDefault;
			}
			set 
			{
            
                _addressIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "ACTIVE" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string Active
		{
			get 
			{ 
                if(_activeNonDefault==null)return _activeNonDefault;
				else return _activeNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("Active length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _activeNonDefault =null;//null value 
                }
                else
                {		           
		            _activeNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "BRANCH_ID" field.  
		/// </summary>
		public decimal? BranchID
		{
			get 
			{ 
                return _branchIDNonDefault;
			}
			set 
			{
            
                _branchIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "MEDICARE_BRANCH_ID" field. Length must be between 0 and 10 characters. 
		/// </summary>
		public string MedicareBranchID
		{
			get 
			{ 
                if(_medicareBranchIDNonDefault==null)return _medicareBranchIDNonDefault;
				else return _medicareBranchIDNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 10)
					throw new ArgumentException("MedicareBranchID length must be between 0 and 10 characters.");

				
                if(value ==null)
                {
                    _medicareBranchIDNonDefault =null;//null value 
                }
                else
                {		           
		            _medicareBranchIDNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CLOSED_DATE" field.  
		/// </summary>
		public DateTime? ClosedDate
		{
			get 
			{ 
                return _closedDateNonDefault;
			}
			set 
			{
            
                _closedDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "FACILITY_NAME" field. Length must be between 0 and 60 characters. 
		/// </summary>
		public string FacilityName
		{
			get 
			{ 
                if(_facilityNameNonDefault==null)return _facilityNameNonDefault;
				else return _facilityNameNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 60)
					throw new ArgumentException("FacilityName length must be between 0 and 60 characters.");

				
                if(value ==null)
                {
                    _facilityNameNonDefault =null;//null value 
                }
                else
                {		           
		            _facilityNameNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "OPENED_DATE" field.  
		/// </summary>
		public DateTime? OpenedDate
		{
			get 
			{ 
                return _openedDateNonDefault;
			}
			set 
			{
            
                _openedDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "OPER_STAT_CODE" field. Length must be between 0 and 2 characters. 
		/// </summary>
		public string OperStatCode
		{
			get 
			{ 
                if(_operStatCodeNonDefault==null)return _operStatCodeNonDefault;
				else return _operStatCodeNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 2)
					throw new ArgumentException("OperStatCode length must be between 0 and 2 characters.");

				
                if(value ==null)
                {
                    _operStatCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _operStatCodeNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "LICENSURE_NUM" field. Length must be between 0 and 20 characters. 
		/// </summary>
		public string LicensureNum
		{
			get 
			{ 
                if(_licensureNumNonDefault==null)return _licensureNumNonDefault;
				else return _licensureNumNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 20)
					throw new ArgumentException("LicensureNum length must be between 0 and 20 characters.");

				
                if(value ==null)
                {
                    _licensureNumNonDefault =null;//null value 
                }
                else
                {		           
		            _licensureNumNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ORIGINAL_LICENSURE_DATE" field.  
		/// </summary>
		public DateTime? OriginalLicensureDate
		{
			get 
			{ 
                return _originalLicensureDateNonDefault;
			}
			set 
			{
            
                _originalLicensureDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "TELEPHONE_NUMBER" field. Length must be between 0 and 10 characters. 
		/// </summary>
		public string TelephoneNumber
		{
			get 
			{ 
                if(_telephoneNumberNonDefault==null)return _telephoneNumberNonDefault;
				else return _telephoneNumberNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 10)
					throw new ArgumentException("TelephoneNumber length must be between 0 and 10 characters.");

				
                if(value ==null)
                {
                    _telephoneNumberNonDefault =null;//null value 
                }
                else
                {		           
		            _telephoneNumberNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "FAX_PHONE_NUMBER" field. Length must be between 0 and 10 characters. 
		/// </summary>
		public string FaxPhoneNumber
		{
			get 
			{ 
                if(_faxPhoneNumberNonDefault==null)return _faxPhoneNumberNonDefault;
				else return _faxPhoneNumberNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 10)
					throw new ArgumentException("FaxPhoneNumber length must be between 0 and 10 characters.");

				
                if(value ==null)
                {
                    _faxPhoneNumberNonDefault =null;//null value 
                }
                else
                {		           
		            _faxPhoneNumberNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "NUMBER_OF_BEDS" field.  
		/// </summary>
		public int? NumberOfBeds
		{
			get 
			{ 
                return _numberOfBedsNonDefault;
			}
			set 
			{
            
                _numberOfBedsNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "TOTAL_LIC_BEDS" field.  
		/// </summary>
		public int? TotalLicBeds
		{
			get 
			{ 
                return _totalLicBedsNonDefault;
			}
			set 
			{
            
                _totalLicBedsNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "PSYCHIATRIC_BEDS" field.  
		/// </summary>
		public int? PsychiatricBeds
		{
			get 
			{ 
                return _psychiatricBedsNonDefault;
			}
			set 
			{
            
                _psychiatricBedsNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "REHABILITATION_BEDS" field.  
		/// </summary>
		public int? RehabilitationBeds
		{
			get 
			{ 
                return _rehabilitationBedsNonDefault;
			}
			set 
			{
            
                _rehabilitationBedsNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "SNF_BEDS" field.  
		/// </summary>
		public int? SnfBeds
		{
			get 
			{ 
                return _snfBedsNonDefault;
			}
			set 
			{
            
                _snfBedsNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "OTHER_BEDS" field.  
		/// </summary>
		public int? OtherBeds
		{
			get 
			{ 
                return _otherBedsNonDefault;
			}
			set 
			{
            
                _otherBedsNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "UNIT" field.  
		/// </summary>
		public int? Unit
		{
			get 
			{ 
                return _unitNonDefault;
			}
			set 
			{
            
                _unitNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_FACILITY" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string TypeFacility
		{
			get 
			{ 
                if(_typeFacilityNonDefault==null)return _typeFacilityNonDefault;
				else return _typeFacilityNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("TypeFacility length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _typeFacilityNonDefault =null;//null value 
                }
                else
                {		           
		            _typeFacilityNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CCN" field. Length must be between 0 and 12 characters. 
		/// </summary>
		public string Ccn
		{
			get 
			{ 
                if(_ccnNonDefault==null)return _ccnNonDefault;
				else return _ccnNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 12)
					throw new ArgumentException("Ccn length must be between 0 and 12 characters.");

				
                if(value ==null)
                {
                    _ccnNonDefault =null;//null value 
                }
                else
                {		           
		            _ccnNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ON_MAIN_CAMPUS" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string OnMainCampus
		{
			get 
			{ 
                if(_onMainCampusNonDefault==null)return _onMainCampusNonDefault;
				else return _onMainCampusNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("OnMainCampus length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _onMainCampusNonDefault =null;//null value 
                }
                else
                {		           
		            _onMainCampusNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_OF_CLIENTS" field. Length must be between 0 and 5 characters. 
		/// </summary>
		public string TypeOfClients
		{
			get 
			{ 
                if(_typeOfClientsNonDefault==null)return _typeOfClientsNonDefault;
				else return _typeOfClientsNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 5)
					throw new ArgumentException("TypeOfClients length must be between 0 and 5 characters.");

				
                if(value ==null)
                {
                    _typeOfClientsNonDefault =null;//null value 
                }
                else
                {		           
		            _typeOfClientsNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "AGE_RANGE_FROM" field.  
		/// </summary>
		public int? AgeRangeFrom
		{
			get 
			{ 
                return _ageRangeFromNonDefault;
			}
			set 
			{
            
                _ageRangeFromNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "AGE_RANGE_TO" field.  
		/// </summary>
		public int? AgeRangeTO
		{
			get 
			{ 
                return _ageRangeTONonDefault;
			}
			set 
			{
            
                _ageRangeTONonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "CURRENT_LIC_ISSUE_DATE" field.  
		/// </summary>
		public DateTime? CurrentLicIssueDate
		{
			get 
			{ 
                return _currentLicIssueDateNonDefault;
			}
			set 
			{
            
                _currentLicIssueDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "ORIGINAL_APPLICATION_ID" field.  
		/// </summary>
		public decimal? OriginalApplicationID
		{
			get 
			{ 
                return _originalApplicationIDNonDefault;
			}
			set 
			{
            
                _originalApplicationIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_FACILITY_1" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string TypeFacility1
		{
			get 
			{ 
                if(_typeFacility1NonDefault==null)return _typeFacility1NonDefault;
				else return _typeFacility1NonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("TypeFacility1 length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _typeFacility1NonDefault =null;//null value 
                }
                else
                {		           
		            _typeFacility1NonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_FACILITY_2" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string TypeFacility2
		{
			get 
			{ 
                if(_typeFacility2NonDefault==null)return _typeFacility2NonDefault;
				else return _typeFacility2NonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("TypeFacility2 length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _typeFacility2NonDefault =null;//null value 
                }
                else
                {		           
		            _typeFacility2NonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_FACILITY_3" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string TypeFacility3
		{
			get 
			{ 
                if(_typeFacility3NonDefault==null)return _typeFacility3NonDefault;
				else return _typeFacility3NonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("TypeFacility3 length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _typeFacility3NonDefault =null;//null value 
                }
                else
                {		           
		            _typeFacility3NonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_FACILITY_4" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string TypeFacility4
		{
			get 
			{ 
                if(_typeFacility4NonDefault==null)return _typeFacility4NonDefault;
				else return _typeFacility4NonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("TypeFacility4 length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _typeFacility4NonDefault =null;//null value 
                }
                else
                {		           
		            _typeFacility4NonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_FACILITY_5" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string TypeFacility5
		{
			get 
			{ 
                if(_typeFacility5NonDefault==null)return _typeFacility5NonDefault;
				else return _typeFacility5NonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("TypeFacility5 length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _typeFacility5NonDefault =null;//null value 
                }
                else
                {		           
		            _typeFacility5NonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_FACILITY_6" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string TypeFacility6
		{
			get 
			{ 
                if(_typeFacility6NonDefault==null)return _typeFacility6NonDefault;
				else return _typeFacility6NonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("TypeFacility6 length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _typeFacility6NonDefault =null;//null value 
                }
                else
                {		           
		            _typeFacility6NonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CAPACITY" field.  
		/// </summary>
		public int? Capacity
		{
			get 
			{ 
                return _capacityNonDefault;
			}
			set 
			{
            
                _capacityNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "FEDERAL_ID" field. Length must be between 0 and 12 characters. 
		/// </summary>
		public string FederalID
		{
			get 
			{ 
                if(_federalIDNonDefault==null)return _federalIDNonDefault;
				else return _federalIDNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 12)
					throw new ArgumentException("FederalID length must be between 0 and 12 characters.");

				
                if(value ==null)
                {
                    _federalIDNonDefault =null;//null value 
                }
                else
                {		           
		            _federalIDNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "MEDICAID_VENDOR_NUMBER" field. Length must be between 0 and 15 characters. 
		/// </summary>
		public string MedicaidVendorNumber
		{
			get 
			{ 
                if(_medicaidVendorNumberNonDefault==null)return _medicaidVendorNumberNonDefault;
				else return _medicaidVendorNumberNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 15)
					throw new ArgumentException("MedicaidVendorNumber length must be between 0 and 15 characters.");

				
                if(value ==null)
                {
                    _medicaidVendorNumberNonDefault =null;//null value 
                }
                else
                {		           
		            _medicaidVendorNumberNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "NUM_ACTIVE_PATIENTS" field.  
		/// </summary>
		public int? NumActivePatients
		{
			get 
			{ 
                return _numActivePatientsNonDefault;
			}
			set 
			{
            
                _numActivePatientsNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "FACILITY_TYPE_CODE" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string FacilityTypeCode
		{
			get 
			{ 
                if(_facilityTypeCodeNonDefault==null)return _facilityTypeCodeNonDefault;
				else return _facilityTypeCodeNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("FacilityTypeCode length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _facilityTypeCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _facilityTypeCodeNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_TREATMENT" field. Length must be between 0 and 10 characters. 
		/// </summary>
		public string TypeTreatment
		{
			get 
			{ 
                if(_typeTreatmentNonDefault==null)return _typeTreatmentNonDefault;
				else return _typeTreatmentNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 10)
					throw new ArgumentException("TypeTreatment length must be between 0 and 10 characters.");

				
                if(value ==null)
                {
                    _typeTreatmentNonDefault =null;//null value 
                }
                else
                {		           
		            _typeTreatmentNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "OFFSITE_ORIG_LICENSURE_DATE" field.  
		/// </summary>
		public DateTime? OffsiteOrigLicensureDate
		{
			get 
			{ 
                return _offsiteOrigLicensureDateNonDefault;
			}
			set 
			{
            
                _offsiteOrigLicensureDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "OFFSITE_CURRENT_LIC_ISSUE_DATE" field.  
		/// </summary>
		public DateTime? OffsiteCurrentLicIssueDate
		{
			get 
			{ 
                return _offsiteCurrentLicIssueDateNonDefault;
			}
			set 
			{
            
                _offsiteCurrentLicIssueDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "OFFSITE_LIC_EFFECTIVE_DATE" field.  
		/// </summary>
		public DateTime? OffsiteLicEffectiveDate
		{
			get 
			{ 
                return _offsiteLicEffectiveDateNonDefault;
			}
			set 
			{
            
                _offsiteLicEffectiveDateNonDefault = value; 
			}
		}

		/// <summary>
		/// Provides access to the related table 'CAPACITIES'
		/// </summary>
		public BO_Capacities BO_CapacitiesAffiliationID
		{
			get 
			{
                if (_bO_CapacitiesAffiliationID == null)
                {
                    _bO_CapacitiesAffiliationID = new BO_Capacities();
                    _bO_CapacitiesAffiliationID = BO_Capacity.SelectByField("Affiliation_ID",AffiliationID);
                }                
				return _bO_CapacitiesAffiliationID; 
			}
			set 
			{
				  _bO_CapacitiesAffiliationID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'SERVICE'
		/// </summary>
		public BO_Services BO_ServicesAffiliationID
		{
			get 
			{
                if (_bO_ServicesAffiliationID == null)
                {
                    _bO_ServicesAffiliationID = new BO_Services();
                    _bO_ServicesAffiliationID = BO_Service.SelectByField("Affiliation_ID",AffiliationID);
                }                
				return _bO_ServicesAffiliationID; 
			}
			set 
			{
				  _bO_ServicesAffiliationID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'SPECIALTY_UNIT'
		/// </summary>
		public BO_SpecialtyUnits BO_SpecialtyUnitsAffiliationID
		{
			get 
			{
                if (_bO_SpecialtyUnitsAffiliationID == null)
                {
                    _bO_SpecialtyUnitsAffiliationID = new BO_SpecialtyUnits();
                    _bO_SpecialtyUnitsAffiliationID = BO_SpecialtyUnit.SelectByField("Affiliation_ID",AffiliationID);
                }                
				return _bO_SpecialtyUnitsAffiliationID; 
			}
			set 
			{
				  _bO_SpecialtyUnitsAffiliationID = value;
			}
		}

		#endregion
		
		#region Methods (Public)

		/// <summary>
		/// This method will insert one new row into the database using the property Information
		/// </summary>
        /// <param name="getBackValues" type="bool">Whether to get the default values inserted, from the database</param>
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/23/2015 12:29:52 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool InsertWithDefaultValues(bool getBackValues) 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_popsIntID' as parameter 'PopsIntID' of the stored procedure.
			if(_popsIntIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@PopsIntID", _popsIntIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@PopsIntID", DBNull.Value );
              
			// Pass the value of '_typeAffiliation' as parameter 'TypeAffiliation' of the stored procedure.
			if(_typeAffiliationNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeAffiliation", _typeAffiliationNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeAffiliation", DBNull.Value );
              
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			if(_applicationIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ApplicationID", DBNull.Value );
              
			// Pass the value of '_addressID' as parameter 'AddressID' of the stored procedure.
			if(_addressIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@AddressID", _addressIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@AddressID", DBNull.Value );
              
			// Pass the value of '_active' as parameter 'Active' of the stored procedure.
			if(_activeNonDefault!=null)
              oDatabaseHelper.AddParameter("@Active", _activeNonDefault);
            else
              oDatabaseHelper.AddParameter("@Active", DBNull.Value );
              
			// Pass the value of '_branchID' as parameter 'BranchID' of the stored procedure.
			if(_branchIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@BranchID", _branchIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@BranchID", DBNull.Value );
              
			// Pass the value of '_medicareBranchID' as parameter 'MedicareBranchID' of the stored procedure.
			if(_medicareBranchIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@MedicareBranchID", _medicareBranchIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@MedicareBranchID", DBNull.Value );
              
			// Pass the value of '_closedDate' as parameter 'ClosedDate' of the stored procedure.
			if(_closedDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@ClosedDate", _closedDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@ClosedDate", DBNull.Value );
              
			// Pass the value of '_facilityName' as parameter 'FacilityName' of the stored procedure.
			if(_facilityNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@FacilityName", _facilityNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@FacilityName", DBNull.Value );
              
			// Pass the value of '_openedDate' as parameter 'OpenedDate' of the stored procedure.
			if(_openedDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@OpenedDate", _openedDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@OpenedDate", DBNull.Value );
              
			// Pass the value of '_operStatCode' as parameter 'OperStatCode' of the stored procedure.
			if(_operStatCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@OperStatCode", _operStatCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@OperStatCode", DBNull.Value );
              
			// Pass the value of '_licensureNum' as parameter 'LicensureNum' of the stored procedure.
			if(_licensureNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@LicensureNum", _licensureNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@LicensureNum", DBNull.Value );
              
			// Pass the value of '_originalLicensureDate' as parameter 'OriginalLicensureDate' of the stored procedure.
			if(_originalLicensureDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@OriginalLicensureDate", _originalLicensureDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@OriginalLicensureDate", DBNull.Value );
              
			// Pass the value of '_telephoneNumber' as parameter 'TelephoneNumber' of the stored procedure.
			if(_telephoneNumberNonDefault!=null)
              oDatabaseHelper.AddParameter("@TelephoneNumber", _telephoneNumberNonDefault);
            else
              oDatabaseHelper.AddParameter("@TelephoneNumber", DBNull.Value );
              
			// Pass the value of '_faxPhoneNumber' as parameter 'FaxPhoneNumber' of the stored procedure.
			if(_faxPhoneNumberNonDefault!=null)
              oDatabaseHelper.AddParameter("@FaxPhoneNumber", _faxPhoneNumberNonDefault);
            else
              oDatabaseHelper.AddParameter("@FaxPhoneNumber", DBNull.Value );
              
			// Pass the value of '_numberOfBeds' as parameter 'NumberOfBeds' of the stored procedure.
			if(_numberOfBedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@NumberOfBeds", _numberOfBedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@NumberOfBeds", DBNull.Value );
              
			// Pass the value of '_totalLicBeds' as parameter 'TotalLicBeds' of the stored procedure.
			if(_totalLicBedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@TotalLicBeds", _totalLicBedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@TotalLicBeds", DBNull.Value );
              
			// Pass the value of '_psychiatricBeds' as parameter 'PsychiatricBeds' of the stored procedure.
			if(_psychiatricBedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@PsychiatricBeds", _psychiatricBedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@PsychiatricBeds", DBNull.Value );
              
			// Pass the value of '_rehabilitationBeds' as parameter 'RehabilitationBeds' of the stored procedure.
			if(_rehabilitationBedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@RehabilitationBeds", _rehabilitationBedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@RehabilitationBeds", DBNull.Value );
              
			// Pass the value of '_snfBeds' as parameter 'SnfBeds' of the stored procedure.
			if(_snfBedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@SnfBeds", _snfBedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@SnfBeds", DBNull.Value );
              
			// Pass the value of '_otherBeds' as parameter 'OtherBeds' of the stored procedure.
			if(_otherBedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@OtherBeds", _otherBedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@OtherBeds", DBNull.Value );
              
			// Pass the value of '_unit' as parameter 'Unit' of the stored procedure.
			if(_unitNonDefault!=null)
              oDatabaseHelper.AddParameter("@Unit", _unitNonDefault);
            else
              oDatabaseHelper.AddParameter("@Unit", DBNull.Value );
              
			// Pass the value of '_typeFacility' as parameter 'TypeFacility' of the stored procedure.
			if(_typeFacilityNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacility", _typeFacilityNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacility", DBNull.Value );
              
			// Pass the value of '_ccn' as parameter 'Ccn' of the stored procedure.
			if(_ccnNonDefault!=null)
              oDatabaseHelper.AddParameter("@Ccn", _ccnNonDefault);
            else
              oDatabaseHelper.AddParameter("@Ccn", DBNull.Value );
              
			// Pass the value of '_onMainCampus' as parameter 'OnMainCampus' of the stored procedure.
			if(_onMainCampusNonDefault!=null)
              oDatabaseHelper.AddParameter("@OnMainCampus", _onMainCampusNonDefault);
            else
              oDatabaseHelper.AddParameter("@OnMainCampus", DBNull.Value );
              
			// Pass the value of '_typeOfClients' as parameter 'TypeOfClients' of the stored procedure.
			if(_typeOfClientsNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeOfClients", _typeOfClientsNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeOfClients", DBNull.Value );
              
			// Pass the value of '_ageRangeFrom' as parameter 'AgeRangeFrom' of the stored procedure.
			if(_ageRangeFromNonDefault!=null)
              oDatabaseHelper.AddParameter("@AgeRangeFrom", _ageRangeFromNonDefault);
            else
              oDatabaseHelper.AddParameter("@AgeRangeFrom", DBNull.Value );
              
			// Pass the value of '_ageRangeTO' as parameter 'AgeRangeTO' of the stored procedure.
			if(_ageRangeTONonDefault!=null)
              oDatabaseHelper.AddParameter("@AgeRangeTO", _ageRangeTONonDefault);
            else
              oDatabaseHelper.AddParameter("@AgeRangeTO", DBNull.Value );
              
			// Pass the value of '_currentLicIssueDate' as parameter 'CurrentLicIssueDate' of the stored procedure.
			if(_currentLicIssueDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@CurrentLicIssueDate", _currentLicIssueDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@CurrentLicIssueDate", DBNull.Value );
              
			// Pass the value of '_originalApplicationID' as parameter 'OriginalApplicationID' of the stored procedure.
			if(_originalApplicationIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@OriginalApplicationID", _originalApplicationIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@OriginalApplicationID", DBNull.Value );
              
			// Pass the value of '_typeFacility1' as parameter 'TypeFacility1' of the stored procedure.
			if(_typeFacility1NonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacility1", _typeFacility1NonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacility1", DBNull.Value );
              
			// Pass the value of '_typeFacility2' as parameter 'TypeFacility2' of the stored procedure.
			if(_typeFacility2NonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacility2", _typeFacility2NonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacility2", DBNull.Value );
              
			// Pass the value of '_typeFacility3' as parameter 'TypeFacility3' of the stored procedure.
			if(_typeFacility3NonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacility3", _typeFacility3NonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacility3", DBNull.Value );
              
			// Pass the value of '_typeFacility4' as parameter 'TypeFacility4' of the stored procedure.
			if(_typeFacility4NonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacility4", _typeFacility4NonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacility4", DBNull.Value );
              
			// Pass the value of '_typeFacility5' as parameter 'TypeFacility5' of the stored procedure.
			if(_typeFacility5NonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacility5", _typeFacility5NonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacility5", DBNull.Value );
              
			// Pass the value of '_typeFacility6' as parameter 'TypeFacility6' of the stored procedure.
			if(_typeFacility6NonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacility6", _typeFacility6NonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacility6", DBNull.Value );
              
			// Pass the value of '_capacity' as parameter 'Capacity' of the stored procedure.
			if(_capacityNonDefault!=null)
              oDatabaseHelper.AddParameter("@Capacity", _capacityNonDefault);
            else
              oDatabaseHelper.AddParameter("@Capacity", DBNull.Value );
              
			// Pass the value of '_federalID' as parameter 'FederalID' of the stored procedure.
			if(_federalIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@FederalID", _federalIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@FederalID", DBNull.Value );
              
			// Pass the value of '_medicaidVendorNumber' as parameter 'MedicaidVendorNumber' of the stored procedure.
			if(_medicaidVendorNumberNonDefault!=null)
              oDatabaseHelper.AddParameter("@MedicaidVendorNumber", _medicaidVendorNumberNonDefault);
            else
              oDatabaseHelper.AddParameter("@MedicaidVendorNumber", DBNull.Value );
              
			// Pass the value of '_numActivePatients' as parameter 'NumActivePatients' of the stored procedure.
			if(_numActivePatientsNonDefault!=null)
              oDatabaseHelper.AddParameter("@NumActivePatients", _numActivePatientsNonDefault);
            else
              oDatabaseHelper.AddParameter("@NumActivePatients", DBNull.Value );
              
			// Pass the value of '_facilityTypeCode' as parameter 'FacilityTypeCode' of the stored procedure.
			if(_facilityTypeCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@FacilityTypeCode", _facilityTypeCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@FacilityTypeCode", DBNull.Value );
              
			// Pass the value of '_typeTreatment' as parameter 'TypeTreatment' of the stored procedure.
			if(_typeTreatmentNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeTreatment", _typeTreatmentNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeTreatment", DBNull.Value );
              
			// Pass the value of '_offsiteOrigLicensureDate' as parameter 'OffsiteOrigLicensureDate' of the stored procedure.
			if(_offsiteOrigLicensureDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@OffsiteOrigLicensureDate", _offsiteOrigLicensureDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@OffsiteOrigLicensureDate", DBNull.Value );
              
			// Pass the value of '_offsiteCurrentLicIssueDate' as parameter 'OffsiteCurrentLicIssueDate' of the stored procedure.
			if(_offsiteCurrentLicIssueDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@OffsiteCurrentLicIssueDate", _offsiteCurrentLicIssueDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@OffsiteCurrentLicIssueDate", DBNull.Value );
              
			// Pass the value of '_offsiteLicEffectiveDate' as parameter 'OffsiteLicEffectiveDate' of the stored procedure.
			if(_offsiteLicEffectiveDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@OffsiteLicEffectiveDate", _offsiteLicEffectiveDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@OffsiteLicEffectiveDate", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_AFFILIATION_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_AFFILIATION_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
				if (dr.Read())
				{
					PopulateObjectFromReader(this,dr);
				}
				dr.Close();
			}
			oDatabaseHelper.Dispose();	
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will insert one new row into the database using the property Information
		/// </summary>
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/23/2015 12:29:52 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Insert() 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_popsIntID' as parameter 'PopsIntID' of the stored procedure.
			if(_popsIntIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@PopsIntID", _popsIntIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@PopsIntID", DBNull.Value );
			// Pass the value of '_typeAffiliation' as parameter 'TypeAffiliation' of the stored procedure.
			if(_typeAffiliationNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeAffiliation", _typeAffiliationNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeAffiliation", DBNull.Value );
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			if(_applicationIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ApplicationID", DBNull.Value );
			// Pass the value of '_addressID' as parameter 'AddressID' of the stored procedure.
			if(_addressIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@AddressID", _addressIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@AddressID", DBNull.Value );
			// Pass the value of '_active' as parameter 'Active' of the stored procedure.
			if(_activeNonDefault!=null)
              oDatabaseHelper.AddParameter("@Active", _activeNonDefault);
            else
              oDatabaseHelper.AddParameter("@Active", DBNull.Value );
			// Pass the value of '_branchID' as parameter 'BranchID' of the stored procedure.
			if(_branchIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@BranchID", _branchIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@BranchID", DBNull.Value );
			// Pass the value of '_medicareBranchID' as parameter 'MedicareBranchID' of the stored procedure.
			if(_medicareBranchIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@MedicareBranchID", _medicareBranchIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@MedicareBranchID", DBNull.Value );
			// Pass the value of '_closedDate' as parameter 'ClosedDate' of the stored procedure.
			if(_closedDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@ClosedDate", _closedDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@ClosedDate", DBNull.Value );
			// Pass the value of '_facilityName' as parameter 'FacilityName' of the stored procedure.
			if(_facilityNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@FacilityName", _facilityNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@FacilityName", DBNull.Value );
			// Pass the value of '_openedDate' as parameter 'OpenedDate' of the stored procedure.
			if(_openedDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@OpenedDate", _openedDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@OpenedDate", DBNull.Value );
			// Pass the value of '_operStatCode' as parameter 'OperStatCode' of the stored procedure.
			if(_operStatCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@OperStatCode", _operStatCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@OperStatCode", DBNull.Value );
			// Pass the value of '_licensureNum' as parameter 'LicensureNum' of the stored procedure.
			if(_licensureNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@LicensureNum", _licensureNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@LicensureNum", DBNull.Value );
			// Pass the value of '_originalLicensureDate' as parameter 'OriginalLicensureDate' of the stored procedure.
			if(_originalLicensureDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@OriginalLicensureDate", _originalLicensureDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@OriginalLicensureDate", DBNull.Value );
			// Pass the value of '_telephoneNumber' as parameter 'TelephoneNumber' of the stored procedure.
			if(_telephoneNumberNonDefault!=null)
              oDatabaseHelper.AddParameter("@TelephoneNumber", _telephoneNumberNonDefault);
            else
              oDatabaseHelper.AddParameter("@TelephoneNumber", DBNull.Value );
			// Pass the value of '_faxPhoneNumber' as parameter 'FaxPhoneNumber' of the stored procedure.
			if(_faxPhoneNumberNonDefault!=null)
              oDatabaseHelper.AddParameter("@FaxPhoneNumber", _faxPhoneNumberNonDefault);
            else
              oDatabaseHelper.AddParameter("@FaxPhoneNumber", DBNull.Value );
			// Pass the value of '_numberOfBeds' as parameter 'NumberOfBeds' of the stored procedure.
			if(_numberOfBedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@NumberOfBeds", _numberOfBedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@NumberOfBeds", DBNull.Value );
			// Pass the value of '_totalLicBeds' as parameter 'TotalLicBeds' of the stored procedure.
			if(_totalLicBedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@TotalLicBeds", _totalLicBedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@TotalLicBeds", DBNull.Value );
			// Pass the value of '_psychiatricBeds' as parameter 'PsychiatricBeds' of the stored procedure.
			if(_psychiatricBedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@PsychiatricBeds", _psychiatricBedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@PsychiatricBeds", DBNull.Value );
			// Pass the value of '_rehabilitationBeds' as parameter 'RehabilitationBeds' of the stored procedure.
			if(_rehabilitationBedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@RehabilitationBeds", _rehabilitationBedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@RehabilitationBeds", DBNull.Value );
			// Pass the value of '_snfBeds' as parameter 'SnfBeds' of the stored procedure.
			if(_snfBedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@SnfBeds", _snfBedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@SnfBeds", DBNull.Value );
			// Pass the value of '_otherBeds' as parameter 'OtherBeds' of the stored procedure.
			if(_otherBedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@OtherBeds", _otherBedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@OtherBeds", DBNull.Value );
			// Pass the value of '_unit' as parameter 'Unit' of the stored procedure.
			if(_unitNonDefault!=null)
              oDatabaseHelper.AddParameter("@Unit", _unitNonDefault);
            else
              oDatabaseHelper.AddParameter("@Unit", DBNull.Value );
			// Pass the value of '_typeFacility' as parameter 'TypeFacility' of the stored procedure.
			if(_typeFacilityNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacility", _typeFacilityNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacility", DBNull.Value );
			// Pass the value of '_ccn' as parameter 'Ccn' of the stored procedure.
			if(_ccnNonDefault!=null)
              oDatabaseHelper.AddParameter("@Ccn", _ccnNonDefault);
            else
              oDatabaseHelper.AddParameter("@Ccn", DBNull.Value );
			// Pass the value of '_onMainCampus' as parameter 'OnMainCampus' of the stored procedure.
			if(_onMainCampusNonDefault!=null)
              oDatabaseHelper.AddParameter("@OnMainCampus", _onMainCampusNonDefault);
            else
              oDatabaseHelper.AddParameter("@OnMainCampus", DBNull.Value );
			// Pass the value of '_typeOfClients' as parameter 'TypeOfClients' of the stored procedure.
			if(_typeOfClientsNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeOfClients", _typeOfClientsNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeOfClients", DBNull.Value );
			// Pass the value of '_ageRangeFrom' as parameter 'AgeRangeFrom' of the stored procedure.
			if(_ageRangeFromNonDefault!=null)
              oDatabaseHelper.AddParameter("@AgeRangeFrom", _ageRangeFromNonDefault);
            else
              oDatabaseHelper.AddParameter("@AgeRangeFrom", DBNull.Value );
			// Pass the value of '_ageRangeTO' as parameter 'AgeRangeTO' of the stored procedure.
			if(_ageRangeTONonDefault!=null)
              oDatabaseHelper.AddParameter("@AgeRangeTO", _ageRangeTONonDefault);
            else
              oDatabaseHelper.AddParameter("@AgeRangeTO", DBNull.Value );
			// Pass the value of '_currentLicIssueDate' as parameter 'CurrentLicIssueDate' of the stored procedure.
			if(_currentLicIssueDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@CurrentLicIssueDate", _currentLicIssueDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@CurrentLicIssueDate", DBNull.Value );
			// Pass the value of '_originalApplicationID' as parameter 'OriginalApplicationID' of the stored procedure.
			if(_originalApplicationIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@OriginalApplicationID", _originalApplicationIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@OriginalApplicationID", DBNull.Value );
			// Pass the value of '_typeFacility1' as parameter 'TypeFacility1' of the stored procedure.
			if(_typeFacility1NonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacility1", _typeFacility1NonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacility1", DBNull.Value );
			// Pass the value of '_typeFacility2' as parameter 'TypeFacility2' of the stored procedure.
			if(_typeFacility2NonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacility2", _typeFacility2NonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacility2", DBNull.Value );
			// Pass the value of '_typeFacility3' as parameter 'TypeFacility3' of the stored procedure.
			if(_typeFacility3NonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacility3", _typeFacility3NonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacility3", DBNull.Value );
			// Pass the value of '_typeFacility4' as parameter 'TypeFacility4' of the stored procedure.
			if(_typeFacility4NonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacility4", _typeFacility4NonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacility4", DBNull.Value );
			// Pass the value of '_typeFacility5' as parameter 'TypeFacility5' of the stored procedure.
			if(_typeFacility5NonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacility5", _typeFacility5NonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacility5", DBNull.Value );
			// Pass the value of '_typeFacility6' as parameter 'TypeFacility6' of the stored procedure.
			if(_typeFacility6NonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacility6", _typeFacility6NonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacility6", DBNull.Value );
			// Pass the value of '_capacity' as parameter 'Capacity' of the stored procedure.
			if(_capacityNonDefault!=null)
              oDatabaseHelper.AddParameter("@Capacity", _capacityNonDefault);
            else
              oDatabaseHelper.AddParameter("@Capacity", DBNull.Value );
			// Pass the value of '_federalID' as parameter 'FederalID' of the stored procedure.
			if(_federalIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@FederalID", _federalIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@FederalID", DBNull.Value );
			// Pass the value of '_medicaidVendorNumber' as parameter 'MedicaidVendorNumber' of the stored procedure.
			if(_medicaidVendorNumberNonDefault!=null)
              oDatabaseHelper.AddParameter("@MedicaidVendorNumber", _medicaidVendorNumberNonDefault);
            else
              oDatabaseHelper.AddParameter("@MedicaidVendorNumber", DBNull.Value );
			// Pass the value of '_numActivePatients' as parameter 'NumActivePatients' of the stored procedure.
			if(_numActivePatientsNonDefault!=null)
              oDatabaseHelper.AddParameter("@NumActivePatients", _numActivePatientsNonDefault);
            else
              oDatabaseHelper.AddParameter("@NumActivePatients", DBNull.Value );
			// Pass the value of '_facilityTypeCode' as parameter 'FacilityTypeCode' of the stored procedure.
			if(_facilityTypeCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@FacilityTypeCode", _facilityTypeCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@FacilityTypeCode", DBNull.Value );
			// Pass the value of '_typeTreatment' as parameter 'TypeTreatment' of the stored procedure.
			if(_typeTreatmentNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeTreatment", _typeTreatmentNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeTreatment", DBNull.Value );
			// Pass the value of '_offsiteOrigLicensureDate' as parameter 'OffsiteOrigLicensureDate' of the stored procedure.
			if(_offsiteOrigLicensureDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@OffsiteOrigLicensureDate", _offsiteOrigLicensureDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@OffsiteOrigLicensureDate", DBNull.Value );
			// Pass the value of '_offsiteCurrentLicIssueDate' as parameter 'OffsiteCurrentLicIssueDate' of the stored procedure.
			if(_offsiteCurrentLicIssueDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@OffsiteCurrentLicIssueDate", _offsiteCurrentLicIssueDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@OffsiteCurrentLicIssueDate", DBNull.Value );
			// Pass the value of '_offsiteLicEffectiveDate' as parameter 'OffsiteLicEffectiveDate' of the stored procedure.
			if(_offsiteLicEffectiveDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@OffsiteLicEffectiveDate", _offsiteLicEffectiveDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@OffsiteLicEffectiveDate", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_AFFILIATION_Insert", ref ExecutionState);
			oDatabaseHelper.Dispose();	
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Update one new row into the database using the property Information
		/// </summary>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/23/2015 12:29:52 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Update() 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_popsIntID' as parameter 'PopsIntID' of the stored procedure.
			oDatabaseHelper.AddParameter("@PopsIntID", _popsIntIDNonDefault );
            
			// Pass the value of '_affiliationID' as parameter 'AffiliationID' of the stored procedure.
			oDatabaseHelper.AddParameter("@AffiliationID", _affiliationIDNonDefault );
            
			// Pass the value of '_typeAffiliation' as parameter 'TypeAffiliation' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeAffiliation", _typeAffiliationNonDefault );
            
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault );
            
			// Pass the value of '_addressID' as parameter 'AddressID' of the stored procedure.
			oDatabaseHelper.AddParameter("@AddressID", _addressIDNonDefault );
            
			// Pass the value of '_active' as parameter 'Active' of the stored procedure.
			oDatabaseHelper.AddParameter("@Active", _activeNonDefault );
            
			// Pass the value of '_branchID' as parameter 'BranchID' of the stored procedure.
			oDatabaseHelper.AddParameter("@BranchID", _branchIDNonDefault );
            
			// Pass the value of '_medicareBranchID' as parameter 'MedicareBranchID' of the stored procedure.
			oDatabaseHelper.AddParameter("@MedicareBranchID", _medicareBranchIDNonDefault );
            
			// Pass the value of '_closedDate' as parameter 'ClosedDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@ClosedDate", _closedDateNonDefault );
            
			// Pass the value of '_facilityName' as parameter 'FacilityName' of the stored procedure.
			oDatabaseHelper.AddParameter("@FacilityName", _facilityNameNonDefault );
            
			// Pass the value of '_openedDate' as parameter 'OpenedDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@OpenedDate", _openedDateNonDefault );
            
			// Pass the value of '_operStatCode' as parameter 'OperStatCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@OperStatCode", _operStatCodeNonDefault );
            
			// Pass the value of '_licensureNum' as parameter 'LicensureNum' of the stored procedure.
			oDatabaseHelper.AddParameter("@LicensureNum", _licensureNumNonDefault );
            
			// Pass the value of '_originalLicensureDate' as parameter 'OriginalLicensureDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@OriginalLicensureDate", _originalLicensureDateNonDefault );
            
			// Pass the value of '_telephoneNumber' as parameter 'TelephoneNumber' of the stored procedure.
			oDatabaseHelper.AddParameter("@TelephoneNumber", _telephoneNumberNonDefault );
            
			// Pass the value of '_faxPhoneNumber' as parameter 'FaxPhoneNumber' of the stored procedure.
			oDatabaseHelper.AddParameter("@FaxPhoneNumber", _faxPhoneNumberNonDefault );
            
			// Pass the value of '_numberOfBeds' as parameter 'NumberOfBeds' of the stored procedure.
			oDatabaseHelper.AddParameter("@NumberOfBeds", _numberOfBedsNonDefault );
            
			// Pass the value of '_totalLicBeds' as parameter 'TotalLicBeds' of the stored procedure.
			oDatabaseHelper.AddParameter("@TotalLicBeds", _totalLicBedsNonDefault );
            
			// Pass the value of '_psychiatricBeds' as parameter 'PsychiatricBeds' of the stored procedure.
			oDatabaseHelper.AddParameter("@PsychiatricBeds", _psychiatricBedsNonDefault );
            
			// Pass the value of '_rehabilitationBeds' as parameter 'RehabilitationBeds' of the stored procedure.
			oDatabaseHelper.AddParameter("@RehabilitationBeds", _rehabilitationBedsNonDefault );
            
			// Pass the value of '_snfBeds' as parameter 'SnfBeds' of the stored procedure.
			oDatabaseHelper.AddParameter("@SnfBeds", _snfBedsNonDefault );
            
			// Pass the value of '_otherBeds' as parameter 'OtherBeds' of the stored procedure.
			oDatabaseHelper.AddParameter("@OtherBeds", _otherBedsNonDefault );
            
			// Pass the value of '_unit' as parameter 'Unit' of the stored procedure.
			oDatabaseHelper.AddParameter("@Unit", _unitNonDefault );
            
			// Pass the value of '_typeFacility' as parameter 'TypeFacility' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeFacility", _typeFacilityNonDefault );
            
			// Pass the value of '_ccn' as parameter 'Ccn' of the stored procedure.
			oDatabaseHelper.AddParameter("@Ccn", _ccnNonDefault );
            
			// Pass the value of '_onMainCampus' as parameter 'OnMainCampus' of the stored procedure.
			oDatabaseHelper.AddParameter("@OnMainCampus", _onMainCampusNonDefault );
            
			// Pass the value of '_typeOfClients' as parameter 'TypeOfClients' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeOfClients", _typeOfClientsNonDefault );
            
			// Pass the value of '_ageRangeFrom' as parameter 'AgeRangeFrom' of the stored procedure.
			oDatabaseHelper.AddParameter("@AgeRangeFrom", _ageRangeFromNonDefault );
            
			// Pass the value of '_ageRangeTO' as parameter 'AgeRangeTO' of the stored procedure.
			oDatabaseHelper.AddParameter("@AgeRangeTO", _ageRangeTONonDefault );
            
			// Pass the value of '_currentLicIssueDate' as parameter 'CurrentLicIssueDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@CurrentLicIssueDate", _currentLicIssueDateNonDefault );
            
			// Pass the value of '_originalApplicationID' as parameter 'OriginalApplicationID' of the stored procedure.
			oDatabaseHelper.AddParameter("@OriginalApplicationID", _originalApplicationIDNonDefault );
            
			// Pass the value of '_typeFacility1' as parameter 'TypeFacility1' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeFacility1", _typeFacility1NonDefault );
            
			// Pass the value of '_typeFacility2' as parameter 'TypeFacility2' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeFacility2", _typeFacility2NonDefault );
            
			// Pass the value of '_typeFacility3' as parameter 'TypeFacility3' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeFacility3", _typeFacility3NonDefault );
            
			// Pass the value of '_typeFacility4' as parameter 'TypeFacility4' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeFacility4", _typeFacility4NonDefault );
            
			// Pass the value of '_typeFacility5' as parameter 'TypeFacility5' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeFacility5", _typeFacility5NonDefault );
            
			// Pass the value of '_typeFacility6' as parameter 'TypeFacility6' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeFacility6", _typeFacility6NonDefault );
            
			// Pass the value of '_capacity' as parameter 'Capacity' of the stored procedure.
			oDatabaseHelper.AddParameter("@Capacity", _capacityNonDefault );
            
			// Pass the value of '_federalID' as parameter 'FederalID' of the stored procedure.
			oDatabaseHelper.AddParameter("@FederalID", _federalIDNonDefault );
            
			// Pass the value of '_medicaidVendorNumber' as parameter 'MedicaidVendorNumber' of the stored procedure.
			oDatabaseHelper.AddParameter("@MedicaidVendorNumber", _medicaidVendorNumberNonDefault );
            
			// Pass the value of '_numActivePatients' as parameter 'NumActivePatients' of the stored procedure.
			oDatabaseHelper.AddParameter("@NumActivePatients", _numActivePatientsNonDefault );
            
			// Pass the value of '_facilityTypeCode' as parameter 'FacilityTypeCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@FacilityTypeCode", _facilityTypeCodeNonDefault );
            
			// Pass the value of '_typeTreatment' as parameter 'TypeTreatment' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeTreatment", _typeTreatmentNonDefault );
            
			// Pass the value of '_offsiteOrigLicensureDate' as parameter 'OffsiteOrigLicensureDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@OffsiteOrigLicensureDate", _offsiteOrigLicensureDateNonDefault );
            
			// Pass the value of '_offsiteCurrentLicIssueDate' as parameter 'OffsiteCurrentLicIssueDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@OffsiteCurrentLicIssueDate", _offsiteCurrentLicIssueDateNonDefault );
            
			// Pass the value of '_offsiteLicEffectiveDate' as parameter 'OffsiteLicEffectiveDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@OffsiteLicEffectiveDate", _offsiteLicEffectiveDateNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_AFFILIATION_Update", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the property Information
		/// </summary>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/23/2015 12:29:52 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Delete() 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_popsIntID' as parameter 'PopsIntID' of the stored procedure.
			if(_popsIntIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@PopsIntID", _popsIntIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@PopsIntID", DBNull.Value );
			// Pass the value of '_affiliationID' as parameter 'AffiliationID' of the stored procedure.
			if(_affiliationIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@AffiliationID", _affiliationIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@AffiliationID", DBNull.Value );
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			if(_applicationIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@ApplicationID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_AFFILIATION_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_AffiliationPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/23/2015 12:29:52 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool Delete(BO_AffiliationPrimaryKey pk) 
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_AFFILIATION_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_AffiliationFields">Field of the class BO_Affiliation</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/23/2015 12:29:52 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool DeleteByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_AFFILIATION_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_AffiliationPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_Affiliation</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/23/2015 12:29:52 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Affiliation SelectOne(BO_AffiliationPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_AFFILIATION_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_Affiliation obj=new BO_Affiliation();	
				PopulateObjectFromReader(obj,dr);
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
		/// This method will return a list of objects representing all records in the table.
		/// </summary>
		///
		/// <returns>list of objects of class BO_Affiliation in the form of object of BO_Affiliations </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/23/2015 12:29:52 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Affiliations SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_AFFILIATION_SelectAll", ref ExecutionState);
			BO_Affiliations BO_Affiliations = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Affiliations;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_Affiliation</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_Affiliation in the form of an object of class BO_Affiliations</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/23/2015 12:29:52 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Affiliations SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_AFFILIATION_SelectByField", ref ExecutionState);
			BO_Affiliations BO_Affiliations = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Affiliations;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="AFFILIATIONPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class AFFILIATION</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/23/2015 12:29:52 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Affiliation SelectOneWithCAPACITIESUsingAffiliationID(BO_AffiliationPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Affiliation obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_AFFILIATION_SelectOneWithCAPACITIESUsingAffiliationID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Affiliation();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_CapacitiesAffiliationID=BO_Capacity.PopulateObjectsFromReader(dr);
			}
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="AFFILIATIONPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class AFFILIATION</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/23/2015 12:29:52 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Affiliation SelectOneWithSERVICEUsingAffiliationID(BO_AffiliationPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Affiliation obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_AFFILIATION_SelectOneWithSERVICEUsingAffiliationID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Affiliation();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_ServicesAffiliationID=BO_Service.PopulateObjectsFromReader(dr);
			}
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="AFFILIATIONPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class AFFILIATION</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/23/2015 12:29:52 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Affiliation SelectOneWithSPECIALTY_UNITUsingAffiliationID(BO_AffiliationPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Affiliation obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_AFFILIATION_SelectOneWithSPECIALTY_UNITUsingAffiliationID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Affiliation();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_SpecialtyUnitsAffiliationID=BO_SpecialtyUnit.PopulateObjectsFromReader(dr);
			}
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="ADDRESSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_Affiliations</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/23/2015 12:29:52 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Affiliations SelectAllByForeignKeyAddressID(BO_AddressPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Affiliations obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_AFFILIATION_SelectAllByForeignKeyAddressID", ref ExecutionState);
			obj = new BO_Affiliations();
			obj = BO_Affiliation.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will delete row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="ADDRESSPrimaryKey">Primary Key information based on which data is to be deleted.</param>
		///
		/// <returns>object of boolean type as an indicator for operation success .</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/23/2015 12:29:52 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool DeleteAllByForeignKeyAddressID(BO_AddressPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteNonQuery("GEN_AFFILIATION_DeleteAllByForeignKeyAddressID", ref ExecutionState);
			oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}



		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="APPLICATIONSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_Affiliations</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/23/2015 12:29:52 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Affiliations SelectAllByForeignKeyApplicationID(BO_ApplicationPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Affiliations obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_AFFILIATION_SelectAllByForeignKeyApplicationID", ref ExecutionState);
			obj = new BO_Affiliations();
			obj = BO_Affiliation.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will delete row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="APPLICATIONSPrimaryKey">Primary Key information based on which data is to be deleted.</param>
		///
		/// <returns>object of boolean type as an indicator for operation success .</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/23/2015 12:29:52 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool DeleteAllByForeignKeyApplicationID(BO_ApplicationPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteNonQuery("GEN_AFFILIATION_DeleteAllByForeignKeyApplicationID", ref ExecutionState);
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
		/// <returns>object of class BO_Affiliations</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/23/2015 12:29:52 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Affiliations SelectAllByForeignKeyPopsIntID(BO_ProviderPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Affiliations obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_AFFILIATION_SelectAllByForeignKeyPopsIntID", ref ExecutionState);
			obj = new BO_Affiliations();
			obj = BO_Affiliation.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will delete row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PROVIDERSPrimaryKey">Primary Key information based on which data is to be deleted.</param>
		///
		/// <returns>object of boolean type as an indicator for operation success .</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/23/2015 12:29:52 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool DeleteAllByForeignKeyPopsIntID(BO_ProviderPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteNonQuery("GEN_AFFILIATION_DeleteAllByForeignKeyPopsIntID", ref ExecutionState);
			oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		#endregion	
		
        #region Methods (Private)

        /// <summary>
	    /// tests a string to be a well formed xml or not,
	    /// it throws ArgumentException when string text is not well formed.otherwise this 
        /// method is executed silently .
	    /// </summary>
	    /// <param name="text" type="string">xml string to validate.</param>
        /// <param name="fieldName" type="string">field Name to validate.</param>
	    /// <exception > throws ArgumentException when text is not well formed parameter.otherwise this 
        /// method is executed silently .</exception>
	    /// <remarks>
	    ///
	    /// <RevisionHistory>
	    /// Author				Date			Description
	    /// DLGenerator			06/23/2015 12:29:52 PM		Created function
	    /// 
	    /// </RevisionHistory>
	    ///
	    /// </remarks>
	    ///
	    internal static void IsValidXmlString(string text,string fieldName)
	    {
		    XmlTextReader r = new XmlTextReader(new StringReader(text));
		    try
		    {
			    while (r.Read())
			    {
                  /*do nothing ,just continue as long as xml is valid*/ 
                }
		    }
		    catch(Exception)
		    {
			    throw new ArgumentException ("Field ("+fieldName+") xml text argument isn't well formed");				
		    }
		    finally
		    {
			    r.Close();
  			
		    }
          //end silently(well formed xml)
	    }    
		/// <summary>
        /// Populates the fields of a single objects from the columns found in an open reader.
        /// </summary>
		/// <param name="obj" type="AFFILIATION">Object of AFFILIATION to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/23/2015 12:29:52 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_AffiliationBase obj,IDataReader rdr) 
		{

			obj.PopsIntID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_AffiliationFields.PopsIntID)));
			obj.AffiliationID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_AffiliationFields.AffiliationID)));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.TypeAffiliation)))
			{
				obj.TypeAffiliation = rdr.GetString(rdr.GetOrdinal(BO_AffiliationFields.TypeAffiliation));
			}
			
			obj.ApplicationID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_AffiliationFields.ApplicationID)));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.AddressID)))
			{
				obj.AddressID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_AffiliationFields.AddressID)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.Active)))
			{
				obj.Active = rdr.GetString(rdr.GetOrdinal(BO_AffiliationFields.Active));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.BranchID)))
			{
				obj.BranchID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_AffiliationFields.BranchID)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.MedicareBranchID)))
			{
				obj.MedicareBranchID = rdr.GetString(rdr.GetOrdinal(BO_AffiliationFields.MedicareBranchID));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.ClosedDate)))
			{
				obj.ClosedDate = rdr.GetDateTime(rdr.GetOrdinal(BO_AffiliationFields.ClosedDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.FacilityName)))
			{
				obj.FacilityName = rdr.GetString(rdr.GetOrdinal(BO_AffiliationFields.FacilityName));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.OpenedDate)))
			{
				obj.OpenedDate = rdr.GetDateTime(rdr.GetOrdinal(BO_AffiliationFields.OpenedDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.OperStatCode)))
			{
				obj.OperStatCode = rdr.GetString(rdr.GetOrdinal(BO_AffiliationFields.OperStatCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.LicensureNum)))
			{
				obj.LicensureNum = rdr.GetString(rdr.GetOrdinal(BO_AffiliationFields.LicensureNum));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.OriginalLicensureDate)))
			{
				obj.OriginalLicensureDate = rdr.GetDateTime(rdr.GetOrdinal(BO_AffiliationFields.OriginalLicensureDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.TelephoneNumber)))
			{
				obj.TelephoneNumber = rdr.GetString(rdr.GetOrdinal(BO_AffiliationFields.TelephoneNumber));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.FaxPhoneNumber)))
			{
				obj.FaxPhoneNumber = rdr.GetString(rdr.GetOrdinal(BO_AffiliationFields.FaxPhoneNumber));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.NumberOfBeds)))
			{
				obj.NumberOfBeds = rdr.GetInt32(rdr.GetOrdinal(BO_AffiliationFields.NumberOfBeds));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.TotalLicBeds)))
			{
				obj.TotalLicBeds = rdr.GetInt32(rdr.GetOrdinal(BO_AffiliationFields.TotalLicBeds));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.PsychiatricBeds)))
			{
				obj.PsychiatricBeds = rdr.GetInt32(rdr.GetOrdinal(BO_AffiliationFields.PsychiatricBeds));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.RehabilitationBeds)))
			{
				obj.RehabilitationBeds = rdr.GetInt32(rdr.GetOrdinal(BO_AffiliationFields.RehabilitationBeds));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.SnfBeds)))
			{
				obj.SnfBeds = rdr.GetInt32(rdr.GetOrdinal(BO_AffiliationFields.SnfBeds));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.OtherBeds)))
			{
				obj.OtherBeds = rdr.GetInt32(rdr.GetOrdinal(BO_AffiliationFields.OtherBeds));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.Unit)))
			{
				obj.Unit = rdr.GetInt32(rdr.GetOrdinal(BO_AffiliationFields.Unit));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.TypeFacility)))
			{
				obj.TypeFacility = rdr.GetString(rdr.GetOrdinal(BO_AffiliationFields.TypeFacility));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.Ccn)))
			{
				obj.Ccn = rdr.GetString(rdr.GetOrdinal(BO_AffiliationFields.Ccn));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.OnMainCampus)))
			{
				obj.OnMainCampus = rdr.GetString(rdr.GetOrdinal(BO_AffiliationFields.OnMainCampus));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.TypeOfClients)))
			{
				obj.TypeOfClients = rdr.GetString(rdr.GetOrdinal(BO_AffiliationFields.TypeOfClients));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.AgeRangeFrom)))
			{
				obj.AgeRangeFrom = rdr.GetInt32(rdr.GetOrdinal(BO_AffiliationFields.AgeRangeFrom));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.AgeRangeTO)))
			{
				obj.AgeRangeTO = rdr.GetInt32(rdr.GetOrdinal(BO_AffiliationFields.AgeRangeTO));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.CurrentLicIssueDate)))
			{
				obj.CurrentLicIssueDate = rdr.GetDateTime(rdr.GetOrdinal(BO_AffiliationFields.CurrentLicIssueDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.OriginalApplicationID)))
			{
				obj.OriginalApplicationID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_AffiliationFields.OriginalApplicationID)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.TypeFacility1)))
			{
				obj.TypeFacility1 = rdr.GetString(rdr.GetOrdinal(BO_AffiliationFields.TypeFacility1));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.TypeFacility2)))
			{
				obj.TypeFacility2 = rdr.GetString(rdr.GetOrdinal(BO_AffiliationFields.TypeFacility2));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.TypeFacility3)))
			{
				obj.TypeFacility3 = rdr.GetString(rdr.GetOrdinal(BO_AffiliationFields.TypeFacility3));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.TypeFacility4)))
			{
				obj.TypeFacility4 = rdr.GetString(rdr.GetOrdinal(BO_AffiliationFields.TypeFacility4));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.TypeFacility5)))
			{
				obj.TypeFacility5 = rdr.GetString(rdr.GetOrdinal(BO_AffiliationFields.TypeFacility5));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.TypeFacility6)))
			{
				obj.TypeFacility6 = rdr.GetString(rdr.GetOrdinal(BO_AffiliationFields.TypeFacility6));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.Capacity)))
			{
				obj.Capacity = rdr.GetInt32(rdr.GetOrdinal(BO_AffiliationFields.Capacity));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.FederalID)))
			{
				obj.FederalID = rdr.GetString(rdr.GetOrdinal(BO_AffiliationFields.FederalID));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.MedicaidVendorNumber)))
			{
				obj.MedicaidVendorNumber = rdr.GetString(rdr.GetOrdinal(BO_AffiliationFields.MedicaidVendorNumber));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.NumActivePatients)))
			{
				obj.NumActivePatients = rdr.GetInt32(rdr.GetOrdinal(BO_AffiliationFields.NumActivePatients));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.FacilityTypeCode)))
			{
				obj.FacilityTypeCode = rdr.GetString(rdr.GetOrdinal(BO_AffiliationFields.FacilityTypeCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.TypeTreatment)))
			{
				obj.TypeTreatment = rdr.GetString(rdr.GetOrdinal(BO_AffiliationFields.TypeTreatment));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.OffsiteOrigLicensureDate)))
			{
				obj.OffsiteOrigLicensureDate = rdr.GetDateTime(rdr.GetOrdinal(BO_AffiliationFields.OffsiteOrigLicensureDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.OffsiteCurrentLicIssueDate)))
			{
				obj.OffsiteCurrentLicIssueDate = rdr.GetDateTime(rdr.GetOrdinal(BO_AffiliationFields.OffsiteCurrentLicIssueDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.OffsiteLicEffectiveDate)))
			{
				obj.OffsiteLicEffectiveDate = rdr.GetDateTime(rdr.GetOrdinal(BO_AffiliationFields.OffsiteLicEffectiveDate));
			}
			

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_Affiliations</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/23/2015 12:29:52 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_Affiliations PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_Affiliations list = new BO_Affiliations();
			
			while (rdr.Read())
			{
				BO_Affiliation obj = new BO_Affiliation();
				PopulateObjectFromReader(obj,rdr);
				list.Add(obj);
			}
			return list;
			
		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_Affiliations</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/23/2015 12:29:52 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_Affiliations PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_Affiliations list = new BO_Affiliations();
			
            if (rdr.Read())
            {
                BO_Affiliation obj = new BO_Affiliation();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_Affiliation();
                    PopulateObjectFromReader(obj, rdr);
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

	
    #endregion

	}
}
