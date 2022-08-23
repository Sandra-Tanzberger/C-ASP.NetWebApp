//
// Class	:	BO_LetterOfIntentBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	12/27/2016 6:34:27 PM
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
	public class BO_LetterOfIntentFields
	{
		public const string ProgramID                 = "PROGRAM_ID";
		public const string PopsIntID                 = "POPS_INT_ID";
		public const string StateCode                 = "STATE_CODE";
		public const string LetterOfIntentID          = "LETTER_OF_INTENT_ID";
		public const string StateID                   = "STATE_ID";
		public const string ParishCode                = "PARISH_CODE";
		public const string ApplicationID             = "APPLICATION_ID";
		public const string FacilityType              = "FACILITY_TYPE";
		public const string Name                      = "NAME";
		public const string PlanToOpenDate            = "PLAN_TO_OPEN_DATE";
		public const string GeographicAddress         = "GEOGRAPHIC_ADDRESS";
		public const string GeographicCity            = "GEOGRAPHIC_CITY";
		public const string GeographicZip             = "GEOGRAPHIC_ZIP";
		public const string Phone                     = "PHONE";
		public const string Fax                       = "FAX";
		public const string Email                     = "EMAIL";
		public const string MailAddress               = "MAIL_ADDRESS";
		public const string MailCity                  = "MAIL_CITY";
		public const string MailState                 = "MAIL_STATE";
		public const string MailZip                   = "MAIL_ZIP";
		public const string OwnerLegalEntity          = "OWNER_LEGAL_ENTITY";
		public const string OwnerEin                  = "OWNER_EIN";
		public const string AuthAdminTitle            = "AUTH_ADMIN_TITLE";
		public const string AuthAdminName             = "AUTH_ADMIN_NAME";
		public const string AuthAdminEmail            = "AUTH_ADMIN_EMAIL";
		public const string AuthAdminPhone            = "AUTH_ADMIN_PHONE";
		public const string TypeServicesOffered       = "TYPE_SERVICES_OFFERED";
		public const string Confirmed                 = "CONFIRMED";
		public const string LetterOfIntentType        = "LETTER_OF_INTENT_TYPE";
		public const string ConfirmedDate             = "CONFIRMED_DATE";
		public const string FacilityInFacility        = "FACILITY_IN_FACILITY";
		public const string FacInFacName              = "FAC_IN_FAC_NAME";
		public const string FacInFacCcn               = "FAC_IN_FAC_CCN";
		public const string FnrApprovalDate           = "FNR_APPROVAL_DATE";
	}
	
	/// <summary>
	/// Data access class for the "LETTER_OF_INTENT" table.
	/// </summary>
	[Serializable]
	public class BO_LetterOfIntentBase
	{
		
		#region Class Level Variables
		
		private DatabaseHelper oDatabaseHelper;// = new DatabaseHelper();

		private string         	_programIDNonDefault     	= null;
		private decimal?       	_popsIntIDNonDefault     	= null;
		private string         	_stateCodeNonDefault     	= null;
		private decimal?       	_letterOfIntentIDNonDefault	= null;
		private string         	_stateIDNonDefault       	= null;
		private string         	_parishCodeNonDefault    	= null;
		private decimal?       	_applicationIDNonDefault 	= null;
		private string         	_facilityTypeNonDefault  	= null;
		private string         	_nameNonDefault          	= null;
		private DateTime?      	_planToOpenDateNonDefault	= null;
		private string         	_geographicAddressNonDefault	= null;
		private string         	_geographicCityNonDefault	= null;
		private string         	_geographicZipNonDefault 	= null;
		private string         	_phoneNonDefault         	= null;
		private string         	_faxNonDefault           	= null;
		private string         	_emailNonDefault         	= null;
		private string         	_mailAddressNonDefault   	= null;
		private string         	_mailCityNonDefault      	= null;
		private string         	_mailStateNonDefault     	= null;
		private string         	_mailZipNonDefault       	= null;
		private string         	_ownerLegalEntityNonDefault	= null;
		private string         	_ownerEinNonDefault      	= null;
		private string         	_authAdminTitleNonDefault	= null;
		private string         	_authAdminNameNonDefault 	= null;
		private string         	_authAdminEmailNonDefault	= null;
		private string         	_authAdminPhoneNonDefault	= null;
		private string         	_typeServicesOfferedNonDefault	= null;
		private int?           	_confirmedNonDefault     	= null;
		private string         	_letterOfIntentTypeNonDefault	= null;
		private DateTime?      	_confirmedDateNonDefault 	= null;
		private string         	_facilityInFacilityNonDefault	= null;
		private string         	_facInFacNameNonDefault  	= null;
		private string         	_facInFacCcnNonDefault   	= null;
		private DateTime?      	_fnrApprovalDateNonDefault	= null;
		
		#endregion
		
		#region Constants
		
		#endregion
		
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_LetterOfIntentBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// The foreign key connected with another persistent object.
		/// </summary>
		public string ProgramID
		{
			get 
			{ 
                if(_programIDNonDefault==null)return _programIDNonDefault;
				else return _programIDNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("ProgramID length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _programIDNonDefault =null;//null value 
                }
                else
                {		           
		            _programIDNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// The foreign key connected with another persistent object.
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
		/// The foreign key connected with another persistent object.
		/// </summary>
		public string StateCode
		{
			get 
			{ 
                if(_stateCodeNonDefault==null)return _stateCodeNonDefault;
				else return _stateCodeNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 2)
					throw new ArgumentException("StateCode length must be between 0 and 2 characters.");

				
                if(value ==null)
                {
                    _stateCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _stateCodeNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// Returns the identifier of the persistent object. Don't set it manually!
		/// </summary>
		public decimal? LetterOfIntentID
		{
			get 
			{ 
                return _letterOfIntentIDNonDefault;
			}
			set 
			{
            
                _letterOfIntentIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "STATE_ID" field. Length must be between 0 and 9 characters. 
		/// </summary>
		public string StateID
		{
			get 
			{ 
                if(_stateIDNonDefault==null)return _stateIDNonDefault;
				else return _stateIDNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 9)
					throw new ArgumentException("StateID length must be between 0 and 9 characters.");

				
                if(value ==null)
                {
                    _stateIDNonDefault =null;//null value 
                }
                else
                {		           
		            _stateIDNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// The foreign key connected with another persistent object.
		/// </summary>
		public string ParishCode
		{
			get 
			{ 
                if(_parishCodeNonDefault==null)return _parishCodeNonDefault;
				else return _parishCodeNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("ParishCode length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _parishCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _parishCodeNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// The foreign key connected with another persistent object.
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
		/// This property is mapped to the "FACILITY_TYPE" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string FacilityType
		{
			get 
			{ 
                if(_facilityTypeNonDefault==null)return _facilityTypeNonDefault;
				else return _facilityTypeNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("FacilityType length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _facilityTypeNonDefault =null;//null value 
                }
                else
                {		           
		            _facilityTypeNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "NAME" field. Length must be between 0 and 60 characters. 
		/// </summary>
		public string Name
		{
			get 
			{ 
                if(_nameNonDefault==null)return _nameNonDefault;
				else return _nameNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 60)
					throw new ArgumentException("Name length must be between 0 and 60 characters.");

				
                if(value ==null)
                {
                    _nameNonDefault =null;//null value 
                }
                else
                {		           
		            _nameNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "PLAN_TO_OPEN_DATE" field.  
		/// </summary>
		public DateTime? PlanToOpenDate
		{
			get 
			{ 
                return _planToOpenDateNonDefault;
			}
			set 
			{
            
                _planToOpenDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "GEOGRAPHIC_ADDRESS" field. Length must be between 0 and 100 characters. 
		/// </summary>
		public string GeographicAddress
		{
			get 
			{ 
                if(_geographicAddressNonDefault==null)return _geographicAddressNonDefault;
				else return _geographicAddressNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 100)
					throw new ArgumentException("GeographicAddress length must be between 0 and 100 characters.");

				
                if(value ==null)
                {
                    _geographicAddressNonDefault =null;//null value 
                }
                else
                {		           
		            _geographicAddressNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "GEOGRAPHIC_CITY" field. Length must be between 0 and 50 characters. 
		/// </summary>
		public string GeographicCity
		{
			get 
			{ 
                if(_geographicCityNonDefault==null)return _geographicCityNonDefault;
				else return _geographicCityNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 50)
					throw new ArgumentException("GeographicCity length must be between 0 and 50 characters.");

				
                if(value ==null)
                {
                    _geographicCityNonDefault =null;//null value 
                }
                else
                {		           
		            _geographicCityNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "GEOGRAPHIC_ZIP" field. Length must be between 0 and 9 characters. 
		/// </summary>
		public string GeographicZip
		{
			get 
			{ 
                if(_geographicZipNonDefault==null)return _geographicZipNonDefault;
				else return _geographicZipNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 9)
					throw new ArgumentException("GeographicZip length must be between 0 and 9 characters.");

				
                if(value ==null)
                {
                    _geographicZipNonDefault =null;//null value 
                }
                else
                {		           
		            _geographicZipNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "PHONE" field. Length must be between 0 and 13 characters. 
		/// </summary>
		public string Phone
		{
			get 
			{ 
                if(_phoneNonDefault==null)return _phoneNonDefault;
				else return _phoneNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 13)
					throw new ArgumentException("Phone length must be between 0 and 13 characters.");

				
                if(value ==null)
                {
                    _phoneNonDefault =null;//null value 
                }
                else
                {		           
		            _phoneNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "FAX" field. Length must be between 0 and 10 characters. 
		/// </summary>
		public string Fax
		{
			get 
			{ 
                if(_faxNonDefault==null)return _faxNonDefault;
				else return _faxNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 10)
					throw new ArgumentException("Fax length must be between 0 and 10 characters.");

				
                if(value ==null)
                {
                    _faxNonDefault =null;//null value 
                }
                else
                {		           
		            _faxNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "EMAIL" field. Length must be between 0 and 100 characters. 
		/// </summary>
		public string Email
		{
			get 
			{ 
                if(_emailNonDefault==null)return _emailNonDefault;
				else return _emailNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 100)
					throw new ArgumentException("Email length must be between 0 and 100 characters.");

				
                if(value ==null)
                {
                    _emailNonDefault =null;//null value 
                }
                else
                {		           
		            _emailNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "MAIL_ADDRESS" field. Length must be between 0 and 100 characters. 
		/// </summary>
		public string MailAddress
		{
			get 
			{ 
                if(_mailAddressNonDefault==null)return _mailAddressNonDefault;
				else return _mailAddressNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 100)
					throw new ArgumentException("MailAddress length must be between 0 and 100 characters.");

				
                if(value ==null)
                {
                    _mailAddressNonDefault =null;//null value 
                }
                else
                {		           
		            _mailAddressNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "MAIL_CITY" field. Length must be between 0 and 50 characters. 
		/// </summary>
		public string MailCity
		{
			get 
			{ 
                if(_mailCityNonDefault==null)return _mailCityNonDefault;
				else return _mailCityNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 50)
					throw new ArgumentException("MailCity length must be between 0 and 50 characters.");

				
                if(value ==null)
                {
                    _mailCityNonDefault =null;//null value 
                }
                else
                {		           
		            _mailCityNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "MAIL_STATE" field. Length must be between 0 and 50 characters. 
		/// </summary>
		public string MailState
		{
			get 
			{ 
                if(_mailStateNonDefault==null)return _mailStateNonDefault;
				else return _mailStateNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 50)
					throw new ArgumentException("MailState length must be between 0 and 50 characters.");

				
                if(value ==null)
                {
                    _mailStateNonDefault =null;//null value 
                }
                else
                {		           
		            _mailStateNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "MAIL_ZIP" field. Length must be between 0 and 10 characters. 
		/// </summary>
		public string MailZip
		{
			get 
			{ 
                if(_mailZipNonDefault==null)return _mailZipNonDefault;
				else return _mailZipNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 10)
					throw new ArgumentException("MailZip length must be between 0 and 10 characters.");

				
                if(value ==null)
                {
                    _mailZipNonDefault =null;//null value 
                }
                else
                {		           
		            _mailZipNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "OWNER_LEGAL_ENTITY" field. Length must be between 0 and 100 characters. 
		/// </summary>
		public string OwnerLegalEntity
		{
			get 
			{ 
                if(_ownerLegalEntityNonDefault==null)return _ownerLegalEntityNonDefault;
				else return _ownerLegalEntityNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 100)
					throw new ArgumentException("OwnerLegalEntity length must be between 0 and 100 characters.");

				
                if(value ==null)
                {
                    _ownerLegalEntityNonDefault =null;//null value 
                }
                else
                {		           
		            _ownerLegalEntityNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "OWNER_EIN" field. Length must be between 0 and 20 characters. 
		/// </summary>
		public string OwnerEin
		{
			get 
			{ 
                if(_ownerEinNonDefault==null)return _ownerEinNonDefault;
				else return _ownerEinNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 20)
					throw new ArgumentException("OwnerEin length must be between 0 and 20 characters.");

				
                if(value ==null)
                {
                    _ownerEinNonDefault =null;//null value 
                }
                else
                {		           
		            _ownerEinNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "AUTH_ADMIN_TITLE" field. Length must be between 0 and 50 characters. 
		/// </summary>
		public string AuthAdminTitle
		{
			get 
			{ 
                if(_authAdminTitleNonDefault==null)return _authAdminTitleNonDefault;
				else return _authAdminTitleNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 50)
					throw new ArgumentException("AuthAdminTitle length must be between 0 and 50 characters.");

				
                if(value ==null)
                {
                    _authAdminTitleNonDefault =null;//null value 
                }
                else
                {		           
		            _authAdminTitleNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "AUTH_ADMIN_NAME" field. Length must be between 0 and 50 characters. 
		/// </summary>
		public string AuthAdminName
		{
			get 
			{ 
                if(_authAdminNameNonDefault==null)return _authAdminNameNonDefault;
				else return _authAdminNameNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 50)
					throw new ArgumentException("AuthAdminName length must be between 0 and 50 characters.");

				
                if(value ==null)
                {
                    _authAdminNameNonDefault =null;//null value 
                }
                else
                {		           
		            _authAdminNameNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "AUTH_ADMIN_EMAIL" field. Length must be between 0 and 100 characters. 
		/// </summary>
		public string AuthAdminEmail
		{
			get 
			{ 
                if(_authAdminEmailNonDefault==null)return _authAdminEmailNonDefault;
				else return _authAdminEmailNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 100)
					throw new ArgumentException("AuthAdminEmail length must be between 0 and 100 characters.");

				
                if(value ==null)
                {
                    _authAdminEmailNonDefault =null;//null value 
                }
                else
                {		           
		            _authAdminEmailNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "AUTH_ADMIN_PHONE" field. Length must be between 0 and 13 characters. 
		/// </summary>
		public string AuthAdminPhone
		{
			get 
			{ 
                if(_authAdminPhoneNonDefault==null)return _authAdminPhoneNonDefault;
				else return _authAdminPhoneNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 13)
					throw new ArgumentException("AuthAdminPhone length must be between 0 and 13 characters.");

				
                if(value ==null)
                {
                    _authAdminPhoneNonDefault =null;//null value 
                }
                else
                {		           
		            _authAdminPhoneNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_SERVICES_OFFERED" field. Length must be between 0 and 500 characters. 
		/// </summary>
		public string TypeServicesOffered
		{
			get 
			{ 
                if(_typeServicesOfferedNonDefault==null)return _typeServicesOfferedNonDefault;
				else return _typeServicesOfferedNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 500)
					throw new ArgumentException("TypeServicesOffered length must be between 0 and 500 characters.");

				
                if(value ==null)
                {
                    _typeServicesOfferedNonDefault =null;//null value 
                }
                else
                {		           
		            _typeServicesOfferedNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CONFIRMED" field.  
		/// </summary>
		public int? Confirmed
		{
			get 
			{ 
                return _confirmedNonDefault;
			}
			set 
			{
            
                _confirmedNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "LETTER_OF_INTENT_TYPE" field. Length must be between 0 and 1 characters. Mandatory.
		/// </summary>
		public string LetterOfIntentType
		{
			get 
			{ 
                if(_letterOfIntentTypeNonDefault==null)return _letterOfIntentTypeNonDefault;
				else return _letterOfIntentTypeNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 1)
					throw new ArgumentException("LetterOfIntentType length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _letterOfIntentTypeNonDefault =null;//null value 
                }
                else
                {		           
		            _letterOfIntentTypeNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CONFIRMED_DATE" field.  
		/// </summary>
		public DateTime? ConfirmedDate
		{
			get 
			{ 
                return _confirmedDateNonDefault;
			}
			set 
			{
            
                _confirmedDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "FACILITY_IN_FACILITY" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string FacilityInFacility
		{
			get 
			{ 
                if(_facilityInFacilityNonDefault==null)return _facilityInFacilityNonDefault;
				else return _facilityInFacilityNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("FacilityInFacility length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _facilityInFacilityNonDefault =null;//null value 
                }
                else
                {		           
		            _facilityInFacilityNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "FAC_IN_FAC_NAME" field. Length must be between 0 and 50 characters. 
		/// </summary>
		public string FacInFacName
		{
			get 
			{ 
                if(_facInFacNameNonDefault==null)return _facInFacNameNonDefault;
				else return _facInFacNameNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 50)
					throw new ArgumentException("FacInFacName length must be between 0 and 50 characters.");

				
                if(value ==null)
                {
                    _facInFacNameNonDefault =null;//null value 
                }
                else
                {		           
		            _facInFacNameNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "FAC_IN_FAC_CCN" field. Length must be between 0 and 12 characters. 
		/// </summary>
		public string FacInFacCcn
		{
			get 
			{ 
                if(_facInFacCcnNonDefault==null)return _facInFacCcnNonDefault;
				else return _facInFacCcnNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 12)
					throw new ArgumentException("FacInFacCcn length must be between 0 and 12 characters.");

				
                if(value ==null)
                {
                    _facInFacCcnNonDefault =null;//null value 
                }
                else
                {		           
		            _facInFacCcnNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "FNR_APPROVAL_DATE" field.  
		/// </summary>
		public DateTime? FnrApprovalDate
		{
			get 
			{ 
                return _fnrApprovalDateNonDefault;
			}
			set 
			{
            
                _fnrApprovalDateNonDefault = value; 
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
		/// DLGenerator			12/27/2016 6:34:27 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool InsertWithDefaultValues(bool getBackValues) 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_programID' as parameter 'ProgramID' of the stored procedure.
			if(_programIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ProgramID", _programIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ProgramID", DBNull.Value );
              
			// Pass the value of '_popsIntID' as parameter 'PopsIntID' of the stored procedure.
			if(_popsIntIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@PopsIntID", _popsIntIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@PopsIntID", DBNull.Value );
              
			// Pass the value of '_stateCode' as parameter 'StateCode' of the stored procedure.
			if(_stateCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@StateCode", _stateCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@StateCode", DBNull.Value );
              
			// Pass the value of '_stateID' as parameter 'StateID' of the stored procedure.
			if(_stateIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@StateID", _stateIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@StateID", DBNull.Value );
              
			// Pass the value of '_parishCode' as parameter 'ParishCode' of the stored procedure.
			if(_parishCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@ParishCode", _parishCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@ParishCode", DBNull.Value );
              
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			if(_applicationIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ApplicationID", DBNull.Value );
              
			// Pass the value of '_facilityType' as parameter 'FacilityType' of the stored procedure.
			if(_facilityTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@FacilityType", _facilityTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@FacilityType", DBNull.Value );
              
			// Pass the value of '_name' as parameter 'Name' of the stored procedure.
			if(_nameNonDefault!=null)
              oDatabaseHelper.AddParameter("@Name", _nameNonDefault);
            else
              oDatabaseHelper.AddParameter("@Name", DBNull.Value );
              
			// Pass the value of '_planToOpenDate' as parameter 'PlanToOpenDate' of the stored procedure.
			if(_planToOpenDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@PlanToOpenDate", _planToOpenDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@PlanToOpenDate", DBNull.Value );
              
			// Pass the value of '_geographicAddress' as parameter 'GeographicAddress' of the stored procedure.
			if(_geographicAddressNonDefault!=null)
              oDatabaseHelper.AddParameter("@GeographicAddress", _geographicAddressNonDefault);
            else
              oDatabaseHelper.AddParameter("@GeographicAddress", DBNull.Value );
              
			// Pass the value of '_geographicCity' as parameter 'GeographicCity' of the stored procedure.
			if(_geographicCityNonDefault!=null)
              oDatabaseHelper.AddParameter("@GeographicCity", _geographicCityNonDefault);
            else
              oDatabaseHelper.AddParameter("@GeographicCity", DBNull.Value );
              
			// Pass the value of '_geographicZip' as parameter 'GeographicZip' of the stored procedure.
			if(_geographicZipNonDefault!=null)
              oDatabaseHelper.AddParameter("@GeographicZip", _geographicZipNonDefault);
            else
              oDatabaseHelper.AddParameter("@GeographicZip", DBNull.Value );
              
			// Pass the value of '_phone' as parameter 'Phone' of the stored procedure.
			if(_phoneNonDefault!=null)
              oDatabaseHelper.AddParameter("@Phone", _phoneNonDefault);
            else
              oDatabaseHelper.AddParameter("@Phone", DBNull.Value );
              
			// Pass the value of '_fax' as parameter 'Fax' of the stored procedure.
			if(_faxNonDefault!=null)
              oDatabaseHelper.AddParameter("@Fax", _faxNonDefault);
            else
              oDatabaseHelper.AddParameter("@Fax", DBNull.Value );
              
			// Pass the value of '_email' as parameter 'Email' of the stored procedure.
			if(_emailNonDefault!=null)
              oDatabaseHelper.AddParameter("@Email", _emailNonDefault);
            else
              oDatabaseHelper.AddParameter("@Email", DBNull.Value );
              
			// Pass the value of '_mailAddress' as parameter 'MailAddress' of the stored procedure.
			if(_mailAddressNonDefault!=null)
              oDatabaseHelper.AddParameter("@MailAddress", _mailAddressNonDefault);
            else
              oDatabaseHelper.AddParameter("@MailAddress", DBNull.Value );
              
			// Pass the value of '_mailCity' as parameter 'MailCity' of the stored procedure.
			if(_mailCityNonDefault!=null)
              oDatabaseHelper.AddParameter("@MailCity", _mailCityNonDefault);
            else
              oDatabaseHelper.AddParameter("@MailCity", DBNull.Value );
              
			// Pass the value of '_mailState' as parameter 'MailState' of the stored procedure.
			if(_mailStateNonDefault!=null)
              oDatabaseHelper.AddParameter("@MailState", _mailStateNonDefault);
            else
              oDatabaseHelper.AddParameter("@MailState", DBNull.Value );
              
			// Pass the value of '_mailZip' as parameter 'MailZip' of the stored procedure.
			if(_mailZipNonDefault!=null)
              oDatabaseHelper.AddParameter("@MailZip", _mailZipNonDefault);
            else
              oDatabaseHelper.AddParameter("@MailZip", DBNull.Value );
              
			// Pass the value of '_ownerLegalEntity' as parameter 'OwnerLegalEntity' of the stored procedure.
			if(_ownerLegalEntityNonDefault!=null)
              oDatabaseHelper.AddParameter("@OwnerLegalEntity", _ownerLegalEntityNonDefault);
            else
              oDatabaseHelper.AddParameter("@OwnerLegalEntity", DBNull.Value );
              
			// Pass the value of '_ownerEin' as parameter 'OwnerEin' of the stored procedure.
			if(_ownerEinNonDefault!=null)
              oDatabaseHelper.AddParameter("@OwnerEin", _ownerEinNonDefault);
            else
              oDatabaseHelper.AddParameter("@OwnerEin", DBNull.Value );
              
			// Pass the value of '_authAdminTitle' as parameter 'AuthAdminTitle' of the stored procedure.
			if(_authAdminTitleNonDefault!=null)
              oDatabaseHelper.AddParameter("@AuthAdminTitle", _authAdminTitleNonDefault);
            else
              oDatabaseHelper.AddParameter("@AuthAdminTitle", DBNull.Value );
              
			// Pass the value of '_authAdminName' as parameter 'AuthAdminName' of the stored procedure.
			if(_authAdminNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@AuthAdminName", _authAdminNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@AuthAdminName", DBNull.Value );
              
			// Pass the value of '_authAdminEmail' as parameter 'AuthAdminEmail' of the stored procedure.
			if(_authAdminEmailNonDefault!=null)
              oDatabaseHelper.AddParameter("@AuthAdminEmail", _authAdminEmailNonDefault);
            else
              oDatabaseHelper.AddParameter("@AuthAdminEmail", DBNull.Value );
              
			// Pass the value of '_authAdminPhone' as parameter 'AuthAdminPhone' of the stored procedure.
			if(_authAdminPhoneNonDefault!=null)
              oDatabaseHelper.AddParameter("@AuthAdminPhone", _authAdminPhoneNonDefault);
            else
              oDatabaseHelper.AddParameter("@AuthAdminPhone", DBNull.Value );
              
			// Pass the value of '_typeServicesOffered' as parameter 'TypeServicesOffered' of the stored procedure.
			if(_typeServicesOfferedNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeServicesOffered", _typeServicesOfferedNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeServicesOffered", DBNull.Value );
              
			// Pass the value of '_confirmed' as parameter 'Confirmed' of the stored procedure.
			if(_confirmedNonDefault!=null)
              oDatabaseHelper.AddParameter("@Confirmed", _confirmedNonDefault);
            else
              oDatabaseHelper.AddParameter("@Confirmed", DBNull.Value );
              
			// Pass the value of '_letterOfIntentType' as parameter 'LetterOfIntentType' of the stored procedure.
			if(_letterOfIntentTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@LetterOfIntentType", _letterOfIntentTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@LetterOfIntentType", DBNull.Value );
              
			// Pass the value of '_confirmedDate' as parameter 'ConfirmedDate' of the stored procedure.
			if(_confirmedDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@ConfirmedDate", _confirmedDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@ConfirmedDate", DBNull.Value );
              
			// Pass the value of '_facilityInFacility' as parameter 'FacilityInFacility' of the stored procedure.
			if(_facilityInFacilityNonDefault!=null)
              oDatabaseHelper.AddParameter("@FacilityInFacility", _facilityInFacilityNonDefault);
            else
              oDatabaseHelper.AddParameter("@FacilityInFacility", DBNull.Value );
              
			// Pass the value of '_facInFacName' as parameter 'FacInFacName' of the stored procedure.
			if(_facInFacNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@FacInFacName", _facInFacNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@FacInFacName", DBNull.Value );
              
			// Pass the value of '_facInFacCcn' as parameter 'FacInFacCcn' of the stored procedure.
			if(_facInFacCcnNonDefault!=null)
              oDatabaseHelper.AddParameter("@FacInFacCcn", _facInFacCcnNonDefault);
            else
              oDatabaseHelper.AddParameter("@FacInFacCcn", DBNull.Value );
              
			// Pass the value of '_fnrApprovalDate' as parameter 'FnrApprovalDate' of the stored procedure.
			if(_fnrApprovalDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@FnrApprovalDate", _fnrApprovalDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@FnrApprovalDate", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_LETTER_OF_INTENT_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_LETTER_OF_INTENT_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
		/// DLGenerator			12/27/2016 6:34:27 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Insert() 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_programID' as parameter 'ProgramID' of the stored procedure.
			if(_programIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ProgramID", _programIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ProgramID", DBNull.Value );
			// Pass the value of '_popsIntID' as parameter 'PopsIntID' of the stored procedure.
			if(_popsIntIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@PopsIntID", _popsIntIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@PopsIntID", DBNull.Value );
			// Pass the value of '_stateCode' as parameter 'StateCode' of the stored procedure.
			if(_stateCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@StateCode", _stateCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@StateCode", DBNull.Value );
			// Pass the value of '_stateID' as parameter 'StateID' of the stored procedure.
			if(_stateIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@StateID", _stateIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@StateID", DBNull.Value );
			// Pass the value of '_parishCode' as parameter 'ParishCode' of the stored procedure.
			if(_parishCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@ParishCode", _parishCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@ParishCode", DBNull.Value );
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			if(_applicationIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ApplicationID", DBNull.Value );
			// Pass the value of '_facilityType' as parameter 'FacilityType' of the stored procedure.
			if(_facilityTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@FacilityType", _facilityTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@FacilityType", DBNull.Value );
			// Pass the value of '_name' as parameter 'Name' of the stored procedure.
			if(_nameNonDefault!=null)
              oDatabaseHelper.AddParameter("@Name", _nameNonDefault);
            else
              oDatabaseHelper.AddParameter("@Name", DBNull.Value );
			// Pass the value of '_planToOpenDate' as parameter 'PlanToOpenDate' of the stored procedure.
			if(_planToOpenDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@PlanToOpenDate", _planToOpenDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@PlanToOpenDate", DBNull.Value );
			// Pass the value of '_geographicAddress' as parameter 'GeographicAddress' of the stored procedure.
			if(_geographicAddressNonDefault!=null)
              oDatabaseHelper.AddParameter("@GeographicAddress", _geographicAddressNonDefault);
            else
              oDatabaseHelper.AddParameter("@GeographicAddress", DBNull.Value );
			// Pass the value of '_geographicCity' as parameter 'GeographicCity' of the stored procedure.
			if(_geographicCityNonDefault!=null)
              oDatabaseHelper.AddParameter("@GeographicCity", _geographicCityNonDefault);
            else
              oDatabaseHelper.AddParameter("@GeographicCity", DBNull.Value );
			// Pass the value of '_geographicZip' as parameter 'GeographicZip' of the stored procedure.
			if(_geographicZipNonDefault!=null)
              oDatabaseHelper.AddParameter("@GeographicZip", _geographicZipNonDefault);
            else
              oDatabaseHelper.AddParameter("@GeographicZip", DBNull.Value );
			// Pass the value of '_phone' as parameter 'Phone' of the stored procedure.
			if(_phoneNonDefault!=null)
              oDatabaseHelper.AddParameter("@Phone", _phoneNonDefault);
            else
              oDatabaseHelper.AddParameter("@Phone", DBNull.Value );
			// Pass the value of '_fax' as parameter 'Fax' of the stored procedure.
			if(_faxNonDefault!=null)
              oDatabaseHelper.AddParameter("@Fax", _faxNonDefault);
            else
              oDatabaseHelper.AddParameter("@Fax", DBNull.Value );
			// Pass the value of '_email' as parameter 'Email' of the stored procedure.
			if(_emailNonDefault!=null)
              oDatabaseHelper.AddParameter("@Email", _emailNonDefault);
            else
              oDatabaseHelper.AddParameter("@Email", DBNull.Value );
			// Pass the value of '_mailAddress' as parameter 'MailAddress' of the stored procedure.
			if(_mailAddressNonDefault!=null)
              oDatabaseHelper.AddParameter("@MailAddress", _mailAddressNonDefault);
            else
              oDatabaseHelper.AddParameter("@MailAddress", DBNull.Value );
			// Pass the value of '_mailCity' as parameter 'MailCity' of the stored procedure.
			if(_mailCityNonDefault!=null)
              oDatabaseHelper.AddParameter("@MailCity", _mailCityNonDefault);
            else
              oDatabaseHelper.AddParameter("@MailCity", DBNull.Value );
			// Pass the value of '_mailState' as parameter 'MailState' of the stored procedure.
			if(_mailStateNonDefault!=null)
              oDatabaseHelper.AddParameter("@MailState", _mailStateNonDefault);
            else
              oDatabaseHelper.AddParameter("@MailState", DBNull.Value );
			// Pass the value of '_mailZip' as parameter 'MailZip' of the stored procedure.
			if(_mailZipNonDefault!=null)
              oDatabaseHelper.AddParameter("@MailZip", _mailZipNonDefault);
            else
              oDatabaseHelper.AddParameter("@MailZip", DBNull.Value );
			// Pass the value of '_ownerLegalEntity' as parameter 'OwnerLegalEntity' of the stored procedure.
			if(_ownerLegalEntityNonDefault!=null)
              oDatabaseHelper.AddParameter("@OwnerLegalEntity", _ownerLegalEntityNonDefault);
            else
              oDatabaseHelper.AddParameter("@OwnerLegalEntity", DBNull.Value );
			// Pass the value of '_ownerEin' as parameter 'OwnerEin' of the stored procedure.
			if(_ownerEinNonDefault!=null)
              oDatabaseHelper.AddParameter("@OwnerEin", _ownerEinNonDefault);
            else
              oDatabaseHelper.AddParameter("@OwnerEin", DBNull.Value );
			// Pass the value of '_authAdminTitle' as parameter 'AuthAdminTitle' of the stored procedure.
			if(_authAdminTitleNonDefault!=null)
              oDatabaseHelper.AddParameter("@AuthAdminTitle", _authAdminTitleNonDefault);
            else
              oDatabaseHelper.AddParameter("@AuthAdminTitle", DBNull.Value );
			// Pass the value of '_authAdminName' as parameter 'AuthAdminName' of the stored procedure.
			if(_authAdminNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@AuthAdminName", _authAdminNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@AuthAdminName", DBNull.Value );
			// Pass the value of '_authAdminEmail' as parameter 'AuthAdminEmail' of the stored procedure.
			if(_authAdminEmailNonDefault!=null)
              oDatabaseHelper.AddParameter("@AuthAdminEmail", _authAdminEmailNonDefault);
            else
              oDatabaseHelper.AddParameter("@AuthAdminEmail", DBNull.Value );
			// Pass the value of '_authAdminPhone' as parameter 'AuthAdminPhone' of the stored procedure.
			if(_authAdminPhoneNonDefault!=null)
              oDatabaseHelper.AddParameter("@AuthAdminPhone", _authAdminPhoneNonDefault);
            else
              oDatabaseHelper.AddParameter("@AuthAdminPhone", DBNull.Value );
			// Pass the value of '_typeServicesOffered' as parameter 'TypeServicesOffered' of the stored procedure.
			if(_typeServicesOfferedNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeServicesOffered", _typeServicesOfferedNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeServicesOffered", DBNull.Value );
			// Pass the value of '_confirmed' as parameter 'Confirmed' of the stored procedure.
			if(_confirmedNonDefault!=null)
              oDatabaseHelper.AddParameter("@Confirmed", _confirmedNonDefault);
            else
              oDatabaseHelper.AddParameter("@Confirmed", DBNull.Value );
			// Pass the value of '_letterOfIntentType' as parameter 'LetterOfIntentType' of the stored procedure.
			if(_letterOfIntentTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@LetterOfIntentType", _letterOfIntentTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@LetterOfIntentType", DBNull.Value );
			// Pass the value of '_confirmedDate' as parameter 'ConfirmedDate' of the stored procedure.
			if(_confirmedDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@ConfirmedDate", _confirmedDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@ConfirmedDate", DBNull.Value );
			// Pass the value of '_facilityInFacility' as parameter 'FacilityInFacility' of the stored procedure.
			if(_facilityInFacilityNonDefault!=null)
              oDatabaseHelper.AddParameter("@FacilityInFacility", _facilityInFacilityNonDefault);
            else
              oDatabaseHelper.AddParameter("@FacilityInFacility", DBNull.Value );
			// Pass the value of '_facInFacName' as parameter 'FacInFacName' of the stored procedure.
			if(_facInFacNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@FacInFacName", _facInFacNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@FacInFacName", DBNull.Value );
			// Pass the value of '_facInFacCcn' as parameter 'FacInFacCcn' of the stored procedure.
			if(_facInFacCcnNonDefault!=null)
              oDatabaseHelper.AddParameter("@FacInFacCcn", _facInFacCcnNonDefault);
            else
              oDatabaseHelper.AddParameter("@FacInFacCcn", DBNull.Value );
			// Pass the value of '_fnrApprovalDate' as parameter 'FnrApprovalDate' of the stored procedure.
			if(_fnrApprovalDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@FnrApprovalDate", _fnrApprovalDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@FnrApprovalDate", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_LETTER_OF_INTENT_Insert", ref ExecutionState);
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
		/// DLGenerator			12/27/2016 6:34:27 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Update() 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_programID' as parameter 'ProgramID' of the stored procedure.
			oDatabaseHelper.AddParameter("@ProgramID", _programIDNonDefault );
            
			// Pass the value of '_popsIntID' as parameter 'PopsIntID' of the stored procedure.
			oDatabaseHelper.AddParameter("@PopsIntID", _popsIntIDNonDefault );
            
			// Pass the value of '_stateCode' as parameter 'StateCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@StateCode", _stateCodeNonDefault );
            
			// Pass the value of '_letterOfIntentID' as parameter 'LetterOfIntentID' of the stored procedure.
			oDatabaseHelper.AddParameter("@LetterOfIntentID", _letterOfIntentIDNonDefault );
            
			// Pass the value of '_stateID' as parameter 'StateID' of the stored procedure.
			oDatabaseHelper.AddParameter("@StateID", _stateIDNonDefault );
            
			// Pass the value of '_parishCode' as parameter 'ParishCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@ParishCode", _parishCodeNonDefault );
            
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault );
            
			// Pass the value of '_facilityType' as parameter 'FacilityType' of the stored procedure.
			oDatabaseHelper.AddParameter("@FacilityType", _facilityTypeNonDefault );
            
			// Pass the value of '_name' as parameter 'Name' of the stored procedure.
			oDatabaseHelper.AddParameter("@Name", _nameNonDefault );
            
			// Pass the value of '_planToOpenDate' as parameter 'PlanToOpenDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@PlanToOpenDate", _planToOpenDateNonDefault );
            
			// Pass the value of '_geographicAddress' as parameter 'GeographicAddress' of the stored procedure.
			oDatabaseHelper.AddParameter("@GeographicAddress", _geographicAddressNonDefault );
            
			// Pass the value of '_geographicCity' as parameter 'GeographicCity' of the stored procedure.
			oDatabaseHelper.AddParameter("@GeographicCity", _geographicCityNonDefault );
            
			// Pass the value of '_geographicZip' as parameter 'GeographicZip' of the stored procedure.
			oDatabaseHelper.AddParameter("@GeographicZip", _geographicZipNonDefault );
            
			// Pass the value of '_phone' as parameter 'Phone' of the stored procedure.
			oDatabaseHelper.AddParameter("@Phone", _phoneNonDefault );
            
			// Pass the value of '_fax' as parameter 'Fax' of the stored procedure.
			oDatabaseHelper.AddParameter("@Fax", _faxNonDefault );
            
			// Pass the value of '_email' as parameter 'Email' of the stored procedure.
			oDatabaseHelper.AddParameter("@Email", _emailNonDefault );
            
			// Pass the value of '_mailAddress' as parameter 'MailAddress' of the stored procedure.
			oDatabaseHelper.AddParameter("@MailAddress", _mailAddressNonDefault );
            
			// Pass the value of '_mailCity' as parameter 'MailCity' of the stored procedure.
			oDatabaseHelper.AddParameter("@MailCity", _mailCityNonDefault );
            
			// Pass the value of '_mailState' as parameter 'MailState' of the stored procedure.
			oDatabaseHelper.AddParameter("@MailState", _mailStateNonDefault );
            
			// Pass the value of '_mailZip' as parameter 'MailZip' of the stored procedure.
			oDatabaseHelper.AddParameter("@MailZip", _mailZipNonDefault );
            
			// Pass the value of '_ownerLegalEntity' as parameter 'OwnerLegalEntity' of the stored procedure.
			oDatabaseHelper.AddParameter("@OwnerLegalEntity", _ownerLegalEntityNonDefault );
            
			// Pass the value of '_ownerEin' as parameter 'OwnerEin' of the stored procedure.
			oDatabaseHelper.AddParameter("@OwnerEin", _ownerEinNonDefault );
            
			// Pass the value of '_authAdminTitle' as parameter 'AuthAdminTitle' of the stored procedure.
			oDatabaseHelper.AddParameter("@AuthAdminTitle", _authAdminTitleNonDefault );
            
			// Pass the value of '_authAdminName' as parameter 'AuthAdminName' of the stored procedure.
			oDatabaseHelper.AddParameter("@AuthAdminName", _authAdminNameNonDefault );
            
			// Pass the value of '_authAdminEmail' as parameter 'AuthAdminEmail' of the stored procedure.
			oDatabaseHelper.AddParameter("@AuthAdminEmail", _authAdminEmailNonDefault );
            
			// Pass the value of '_authAdminPhone' as parameter 'AuthAdminPhone' of the stored procedure.
			oDatabaseHelper.AddParameter("@AuthAdminPhone", _authAdminPhoneNonDefault );
            
			// Pass the value of '_typeServicesOffered' as parameter 'TypeServicesOffered' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeServicesOffered", _typeServicesOfferedNonDefault );
            
			// Pass the value of '_confirmed' as parameter 'Confirmed' of the stored procedure.
			oDatabaseHelper.AddParameter("@Confirmed", _confirmedNonDefault );
            
			// Pass the value of '_letterOfIntentType' as parameter 'LetterOfIntentType' of the stored procedure.
			oDatabaseHelper.AddParameter("@LetterOfIntentType", _letterOfIntentTypeNonDefault );
            
			// Pass the value of '_confirmedDate' as parameter 'ConfirmedDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@ConfirmedDate", _confirmedDateNonDefault );
            
			// Pass the value of '_facilityInFacility' as parameter 'FacilityInFacility' of the stored procedure.
			oDatabaseHelper.AddParameter("@FacilityInFacility", _facilityInFacilityNonDefault );
            
			// Pass the value of '_facInFacName' as parameter 'FacInFacName' of the stored procedure.
			oDatabaseHelper.AddParameter("@FacInFacName", _facInFacNameNonDefault );
            
			// Pass the value of '_facInFacCcn' as parameter 'FacInFacCcn' of the stored procedure.
			oDatabaseHelper.AddParameter("@FacInFacCcn", _facInFacCcnNonDefault );
            
			// Pass the value of '_fnrApprovalDate' as parameter 'FnrApprovalDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@FnrApprovalDate", _fnrApprovalDateNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_LETTER_OF_INTENT_Update", ref ExecutionState);
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
		/// DLGenerator			12/27/2016 6:34:27 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Delete() 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_letterOfIntentID' as parameter 'LetterOfIntentID' of the stored procedure.
			if(_letterOfIntentIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@LetterOfIntentID", _letterOfIntentIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@LetterOfIntentID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_LETTER_OF_INTENT_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_LetterOfIntentPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/27/2016 6:34:27 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool Delete(BO_LetterOfIntentPrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_LETTER_OF_INTENT_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_LetterOfIntentFields">Field of the class BO_LetterOfIntent</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/27/2016 6:34:27 PM		Created function
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
			
			oDatabaseHelper.ExecuteScalar("GEN_LETTER_OF_INTENT_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_LetterOfIntentPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_LetterOfIntent</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/27/2016 6:34:27 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_LetterOfIntent SelectOne(BO_LetterOfIntentPrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_LETTER_OF_INTENT_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_LetterOfIntent obj=new BO_LetterOfIntent();	
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
		/// <returns>list of objects of class BO_LetterOfIntent in the form of object of BO_LetterOfIntents </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/27/2016 6:34:27 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_LetterOfIntents SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_LETTER_OF_INTENT_SelectAll", ref ExecutionState);
			BO_LetterOfIntents BO_LetterOfIntents = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_LetterOfIntents;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_LetterOfIntent</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_LetterOfIntent in the form of an object of class BO_LetterOfIntents</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/27/2016 6:34:27 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_LetterOfIntents SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_LETTER_OF_INTENT_SelectByField", ref ExecutionState);
			BO_LetterOfIntents BO_LetterOfIntents = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_LetterOfIntents;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="APPLICATIONSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_LetterOfIntents</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/27/2016 6:34:27 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_LetterOfIntents SelectAllByForeignKeyApplicationID(BO_ApplicationPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_LetterOfIntents obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_LETTER_OF_INTENT_SelectAllByForeignKeyApplicationID", ref ExecutionState);
			obj = new BO_LetterOfIntents();
			obj = BO_LetterOfIntent.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
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
		/// DLGenerator			12/27/2016 6:34:27 PM				Created function
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_LETTER_OF_INTENT_DeleteAllByForeignKeyApplicationID", ref ExecutionState);
			oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}



		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PARISHESPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_LetterOfIntents</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/27/2016 6:34:27 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_LetterOfIntents SelectAllByForeignKeyParishCode(BO_ParishePrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_LetterOfIntents obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_LETTER_OF_INTENT_SelectAllByForeignKeyParishCode", ref ExecutionState);
			obj = new BO_LetterOfIntents();
			obj = BO_LetterOfIntent.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will delete row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PARISHESPrimaryKey">Primary Key information based on which data is to be deleted.</param>
		///
		/// <returns>object of boolean type as an indicator for operation success .</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/27/2016 6:34:27 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool DeleteAllByForeignKeyParishCode(BO_ParishePrimaryKey pk)
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_LETTER_OF_INTENT_DeleteAllByForeignKeyParishCode", ref ExecutionState);
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
		/// <returns>object of class BO_LetterOfIntents</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/27/2016 6:34:27 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_LetterOfIntents SelectAllByForeignKeyPopsIntID(BO_ProviderPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_LetterOfIntents obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_LETTER_OF_INTENT_SelectAllByForeignKeyPopsIntID", ref ExecutionState);
			obj = new BO_LetterOfIntents();
			obj = BO_LetterOfIntent.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
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
		/// DLGenerator			12/27/2016 6:34:27 PM				Created function
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_LETTER_OF_INTENT_DeleteAllByForeignKeyPopsIntID", ref ExecutionState);
			oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}



		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PROGRAMSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_LetterOfIntents</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/27/2016 6:34:27 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_LetterOfIntents SelectAllByForeignKeyProgramID(BO_ProgramPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_LetterOfIntents obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_LETTER_OF_INTENT_SelectAllByForeignKeyProgramID", ref ExecutionState);
			obj = new BO_LetterOfIntents();
			obj = BO_LetterOfIntent.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will delete row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PROGRAMSPrimaryKey">Primary Key information based on which data is to be deleted.</param>
		///
		/// <returns>object of boolean type as an indicator for operation success .</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/27/2016 6:34:27 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool DeleteAllByForeignKeyProgramID(BO_ProgramPrimaryKey pk)
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_LETTER_OF_INTENT_DeleteAllByForeignKeyProgramID", ref ExecutionState);
			oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}



		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="STATESPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_LetterOfIntents</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/27/2016 6:34:27 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_LetterOfIntents SelectAllByForeignKeyStateCode(BO_StatePrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_LetterOfIntents obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_LETTER_OF_INTENT_SelectAllByForeignKeyStateCode", ref ExecutionState);
			obj = new BO_LetterOfIntents();
			obj = BO_LetterOfIntent.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will delete row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="STATESPrimaryKey">Primary Key information based on which data is to be deleted.</param>
		///
		/// <returns>object of boolean type as an indicator for operation success .</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/27/2016 6:34:27 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool DeleteAllByForeignKeyStateCode(BO_StatePrimaryKey pk)
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_LETTER_OF_INTENT_DeleteAllByForeignKeyStateCode", ref ExecutionState);
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
	    /// DLGenerator			12/27/2016 6:34:27 PM		Created function
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
		/// <param name="obj" type="LETTER_OF_INTENT">Object of LETTER_OF_INTENT to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/27/2016 6:34:27 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_LetterOfIntentBase obj,IDataReader rdr) 
		{

			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LetterOfIntentFields.ProgramID)))
			{
				obj.ProgramID = rdr.GetString(rdr.GetOrdinal(BO_LetterOfIntentFields.ProgramID));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LetterOfIntentFields.PopsIntID)))
			{
				obj.PopsIntID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_LetterOfIntentFields.PopsIntID)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LetterOfIntentFields.StateCode)))
			{
				obj.StateCode = rdr.GetString(rdr.GetOrdinal(BO_LetterOfIntentFields.StateCode));
			}
			
			obj.LetterOfIntentID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_LetterOfIntentFields.LetterOfIntentID)));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LetterOfIntentFields.StateID)))
			{
				obj.StateID = rdr.GetString(rdr.GetOrdinal(BO_LetterOfIntentFields.StateID));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LetterOfIntentFields.ParishCode)))
			{
				obj.ParishCode = rdr.GetString(rdr.GetOrdinal(BO_LetterOfIntentFields.ParishCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LetterOfIntentFields.ApplicationID)))
			{
				obj.ApplicationID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_LetterOfIntentFields.ApplicationID)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LetterOfIntentFields.FacilityType)))
			{
				obj.FacilityType = rdr.GetString(rdr.GetOrdinal(BO_LetterOfIntentFields.FacilityType));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LetterOfIntentFields.Name)))
			{
				obj.Name = rdr.GetString(rdr.GetOrdinal(BO_LetterOfIntentFields.Name));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LetterOfIntentFields.PlanToOpenDate)))
			{
				obj.PlanToOpenDate = rdr.GetDateTime(rdr.GetOrdinal(BO_LetterOfIntentFields.PlanToOpenDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LetterOfIntentFields.GeographicAddress)))
			{
				obj.GeographicAddress = rdr.GetString(rdr.GetOrdinal(BO_LetterOfIntentFields.GeographicAddress));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LetterOfIntentFields.GeographicCity)))
			{
				obj.GeographicCity = rdr.GetString(rdr.GetOrdinal(BO_LetterOfIntentFields.GeographicCity));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LetterOfIntentFields.GeographicZip)))
			{
				obj.GeographicZip = rdr.GetString(rdr.GetOrdinal(BO_LetterOfIntentFields.GeographicZip));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LetterOfIntentFields.Phone)))
			{
				obj.Phone = rdr.GetString(rdr.GetOrdinal(BO_LetterOfIntentFields.Phone));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LetterOfIntentFields.Fax)))
			{
				obj.Fax = rdr.GetString(rdr.GetOrdinal(BO_LetterOfIntentFields.Fax));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LetterOfIntentFields.Email)))
			{
				obj.Email = rdr.GetString(rdr.GetOrdinal(BO_LetterOfIntentFields.Email));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LetterOfIntentFields.MailAddress)))
			{
				obj.MailAddress = rdr.GetString(rdr.GetOrdinal(BO_LetterOfIntentFields.MailAddress));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LetterOfIntentFields.MailCity)))
			{
				obj.MailCity = rdr.GetString(rdr.GetOrdinal(BO_LetterOfIntentFields.MailCity));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LetterOfIntentFields.MailState)))
			{
				obj.MailState = rdr.GetString(rdr.GetOrdinal(BO_LetterOfIntentFields.MailState));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LetterOfIntentFields.MailZip)))
			{
				obj.MailZip = rdr.GetString(rdr.GetOrdinal(BO_LetterOfIntentFields.MailZip));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LetterOfIntentFields.OwnerLegalEntity)))
			{
				obj.OwnerLegalEntity = rdr.GetString(rdr.GetOrdinal(BO_LetterOfIntentFields.OwnerLegalEntity));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LetterOfIntentFields.OwnerEin)))
			{
				obj.OwnerEin = rdr.GetString(rdr.GetOrdinal(BO_LetterOfIntentFields.OwnerEin));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LetterOfIntentFields.AuthAdminTitle)))
			{
				obj.AuthAdminTitle = rdr.GetString(rdr.GetOrdinal(BO_LetterOfIntentFields.AuthAdminTitle));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LetterOfIntentFields.AuthAdminName)))
			{
				obj.AuthAdminName = rdr.GetString(rdr.GetOrdinal(BO_LetterOfIntentFields.AuthAdminName));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LetterOfIntentFields.AuthAdminEmail)))
			{
				obj.AuthAdminEmail = rdr.GetString(rdr.GetOrdinal(BO_LetterOfIntentFields.AuthAdminEmail));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LetterOfIntentFields.AuthAdminPhone)))
			{
				obj.AuthAdminPhone = rdr.GetString(rdr.GetOrdinal(BO_LetterOfIntentFields.AuthAdminPhone));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LetterOfIntentFields.TypeServicesOffered)))
			{
				obj.TypeServicesOffered = rdr.GetString(rdr.GetOrdinal(BO_LetterOfIntentFields.TypeServicesOffered));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LetterOfIntentFields.Confirmed)))
			{
				obj.Confirmed = rdr.GetInt32(rdr.GetOrdinal(BO_LetterOfIntentFields.Confirmed));
			}
			
			obj.LetterOfIntentType = rdr.GetString(rdr.GetOrdinal(BO_LetterOfIntentFields.LetterOfIntentType));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LetterOfIntentFields.ConfirmedDate)))
			{
				obj.ConfirmedDate = rdr.GetDateTime(rdr.GetOrdinal(BO_LetterOfIntentFields.ConfirmedDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LetterOfIntentFields.FacilityInFacility)))
			{
				obj.FacilityInFacility = rdr.GetString(rdr.GetOrdinal(BO_LetterOfIntentFields.FacilityInFacility));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LetterOfIntentFields.FacInFacName)))
			{
				obj.FacInFacName = rdr.GetString(rdr.GetOrdinal(BO_LetterOfIntentFields.FacInFacName));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LetterOfIntentFields.FacInFacCcn)))
			{
				obj.FacInFacCcn = rdr.GetString(rdr.GetOrdinal(BO_LetterOfIntentFields.FacInFacCcn));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LetterOfIntentFields.FnrApprovalDate)))
			{
				obj.FnrApprovalDate = rdr.GetDateTime(rdr.GetOrdinal(BO_LetterOfIntentFields.FnrApprovalDate));
			}
			

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_LetterOfIntents</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/27/2016 6:34:27 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_LetterOfIntents PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_LetterOfIntents list = new BO_LetterOfIntents();
			
			while (rdr.Read())
			{
				BO_LetterOfIntent obj = new BO_LetterOfIntent();
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
		/// <returns>Object of BO_LetterOfIntents</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/27/2016 6:34:27 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_LetterOfIntents PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_LetterOfIntents list = new BO_LetterOfIntents();
			
            if (rdr.Read())
            {
                BO_LetterOfIntent obj = new BO_LetterOfIntent();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_LetterOfIntent();
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
