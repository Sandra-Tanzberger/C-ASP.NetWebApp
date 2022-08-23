//
// Class	:	BO_PersonBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	01/19/2012 12:30:33 PM
//

using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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
	public class BO_PersonFields
	{
		public const string PersonID                  = "PERSON_ID";
		public const string Title                     = "TITLE";
		public const string AddressID                 = "ADDRESS_ID";
		public const string FirstName                 = "FIRST_NAME";
		public const string MiddleInitial             = "MIDDLE_INITIAL";
		public const string LastName                  = "LAST_NAME";
		public const string PhoneNumber               = "PHONE_NUMBER";
		public const string FaxNumber                 = "FAX_NUMBER";
		public const string EmailAddress              = "EMAIL_ADDRESS";
		public const string DriversLicenseClassCode   = "DRIVERS_LICENSE_CLASS_CODE";
		public const string DriversLicenseNum         = "DRIVERS_LICENSE_NUM";
		public const string DriversLicenseState       = "DRIVERS_LICENSE_STATE";
		public const string CurrentResumeID           = "CURRENT_RESUME_ID";
	}
	
	/// <summary>
	/// Data access class for the "PERSON" table.
	/// </summary>
	[Serializable]
	public class BO_PersonBase
	{
		
		#region Class Level Variables
		
		//private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private decimal?       	_personIDNonDefault      	= null;
		private string         	_titleNonDefault         	= null;
		private decimal?       	_addressIDNonDefault     	= null;
		private string         	_firstNameNonDefault     	= null;
		private string         	_middleInitialNonDefault 	= null;
		private string         	_lastNameNonDefault      	= null;
		private string         	_phoneNumberNonDefault   	= null;
		private string         	_faxNumberNonDefault     	= null;
		private string         	_emailAddressNonDefault  	= null;
		private string         	_driversLicenseClassCodeNonDefault	= null;
		private string         	_driversLicenseNumNonDefault	= null;
		private string         	_driversLicenseStateNonDefault	= null;
		private int?           	_currentResumeIDNonDefault	= null;

		private BO_Educations _bO_EducationsPersonID = null;
		private BO_Employments _bO_EmploymentsPersonID = null;
		private BO_OwnerPeople _bO_OwnerPeoplePersonID = null;
		private BO_ProviderPeople _bO_ProviderPeoplePersonID = null;
		
		#endregion
		
		#region Constants
		
		#endregion
    
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_PersonBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// Returns the identifier of the persistent object. Don't set it manually!
		/// </summary>
		public decimal? PersonID
		{
			get 
			{ 
                return _personIDNonDefault;
			}
			set 
			{
            
                _personIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "TITLE" field. Length must be between 0 and 5 characters. 
		/// </summary>
		public string Title
		{
			get 
			{ 
                if(_titleNonDefault==null)return _titleNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _titleNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 5)
					throw new ArgumentException("Title length must be between 0 and 5 characters.");

				
                if(value ==null)
                {
                    _titleNonDefault =null;//null value 
                }
                else
                {		           
		            _titleNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
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
		/// This property is mapped to the "FIRST_NAME" field. Length must be between 0 and 15 characters. 
		/// </summary>
		public string FirstName
		{
			get 
			{ 
                if(_firstNameNonDefault==null)return _firstNameNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _firstNameNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 15)
					throw new ArgumentException("FirstName length must be between 0 and 15 characters.");

				
                if(value ==null)
                {
                    _firstNameNonDefault =null;//null value 
                }
                else
                {		           
		            _firstNameNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "MIDDLE_INITIAL" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string MiddleInitial
		{
			get 
			{ 
                if(_middleInitialNonDefault==null)return _middleInitialNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _middleInitialNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("MiddleInitial length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _middleInitialNonDefault =null;//null value 
                }
                else
                {		           
		            _middleInitialNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "LAST_NAME" field. Length must be between 0 and 20 characters. 
		/// </summary>
		public string LastName
		{
			get 
			{ 
                if(_lastNameNonDefault==null)return _lastNameNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _lastNameNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 20)
					throw new ArgumentException("LastName length must be between 0 and 20 characters.");

				
                if(value ==null)
                {
                    _lastNameNonDefault =null;//null value 
                }
                else
                {		           
		            _lastNameNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "PHONE_NUMBER" field. Length must be between 0 and 10 characters. 
		/// </summary>
		public string PhoneNumber
		{
			get 
			{ 
                if(_phoneNumberNonDefault==null)return _phoneNumberNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _phoneNumberNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 10)
					throw new ArgumentException("PhoneNumber length must be between 0 and 10 characters.");

				
                if(value ==null)
                {
                    _phoneNumberNonDefault =null;//null value 
                }
                else
                {		           
		            _phoneNumberNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "FAX_NUMBER" field. Length must be between 0 and 10 characters. 
		/// </summary>
		public string FaxNumber
		{
			get 
			{ 
                if(_faxNumberNonDefault==null)return _faxNumberNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _faxNumberNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 10)
					throw new ArgumentException("FaxNumber length must be between 0 and 10 characters.");

				
                if(value ==null)
                {
                    _faxNumberNonDefault =null;//null value 
                }
                else
                {		           
		            _faxNumberNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "EMAIL_ADDRESS" field. Length must be between 0 and 40 characters. 
		/// </summary>
		public string EmailAddress
		{
			get 
			{ 
                if(_emailAddressNonDefault==null)return _emailAddressNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _emailAddressNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 40)
					throw new ArgumentException("EmailAddress length must be between 0 and 40 characters.");

				
                if(value ==null)
                {
                    _emailAddressNonDefault =null;//null value 
                }
                else
                {		           
		            _emailAddressNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "DRIVERS_LICENSE_CLASS_CODE" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string DriversLicenseClassCode
		{
			get 
			{ 
                if(_driversLicenseClassCodeNonDefault==null)return _driversLicenseClassCodeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _driversLicenseClassCodeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("DriversLicenseClassCode length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _driversLicenseClassCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _driversLicenseClassCodeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "DRIVERS_LICENSE_NUM" field. Length must be between 0 and 11 characters. 
		/// </summary>
		public string DriversLicenseNum
		{
			get 
			{ 
                if(_driversLicenseNumNonDefault==null)return _driversLicenseNumNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _driversLicenseNumNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 11)
					throw new ArgumentException("DriversLicenseNum length must be between 0 and 11 characters.");

				
                if(value ==null)
                {
                    _driversLicenseNumNonDefault =null;//null value 
                }
                else
                {		           
		            _driversLicenseNumNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "DRIVERS_LICENSE_STATE" field. Length must be between 0 and 2 characters. 
		/// </summary>
		public string DriversLicenseState
		{
			get 
			{ 
                if(_driversLicenseStateNonDefault==null)return _driversLicenseStateNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _driversLicenseStateNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 2)
					throw new ArgumentException("DriversLicenseState length must be between 0 and 2 characters.");

				
                if(value ==null)
                {
                    _driversLicenseStateNonDefault =null;//null value 
                }
                else
                {		           
		            _driversLicenseStateNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CURRENT_RESUME_ID" field.  
		/// </summary>
		public int? CurrentResumeID
		{
			get 
			{ 
                return _currentResumeIDNonDefault;
			}
			set 
			{
            
                _currentResumeIDNonDefault = value; 
			}
		}

		/// <summary>
		/// Provides access to the related table 'EDUCATION'
		/// </summary>
		public BO_Educations BO_EducationsPersonID
		{
			get 
			{
                if (_bO_EducationsPersonID == null)
                {
                    _bO_EducationsPersonID = new BO_Educations();
                    _bO_EducationsPersonID = BO_Education.SelectByField("PERSON_ID",PersonID);
                }                
				return _bO_EducationsPersonID; 
			}
			set 
			{
				  _bO_EducationsPersonID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'EMPLOYMENT'
		/// </summary>
		public BO_Employments BO_EmploymentsPersonID
		{
			get 
			{
                if (_bO_EmploymentsPersonID == null)
                {
                    _bO_EmploymentsPersonID = new BO_Employments();
                    _bO_EmploymentsPersonID = BO_Employment.SelectByField("PERSON_ID",PersonID);
                }                
				return _bO_EmploymentsPersonID; 
			}
			set 
			{
				  _bO_EmploymentsPersonID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'OWNER_PERSON'
		/// </summary>
		public BO_OwnerPeople BO_OwnerPeoplePersonID
		{
			get 
			{
                if (_bO_OwnerPeoplePersonID == null)
                {
                    _bO_OwnerPeoplePersonID = new BO_OwnerPeople();
                    _bO_OwnerPeoplePersonID = BO_OwnerPerson.SelectByField("PERSON_ID",PersonID);
                }                
				return _bO_OwnerPeoplePersonID; 
			}
			set 
			{
				  _bO_OwnerPeoplePersonID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'PROVIDER_PERSON'
		/// </summary>
		public BO_ProviderPeople BO_ProviderPeoplePersonID
		{
			get 
			{
                if (_bO_ProviderPeoplePersonID == null)
                {
                    _bO_ProviderPeoplePersonID = new BO_ProviderPeople();
                    _bO_ProviderPeoplePersonID = BO_ProviderPerson.SelectByField("PERSON_ID",PersonID);
                }                
				return _bO_ProviderPeoplePersonID; 
			}
			set 
			{
				  _bO_ProviderPeoplePersonID = value;
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
		/// DLGenerator			01/19/2012 12:30:33 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool InsertWithDefaultValues(bool getBackValues) 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_title' as parameter 'Title' of the stored procedure.
			if(_titleNonDefault!=null)
              oDatabaseHelper.AddParameter("@Title", _titleNonDefault);
            else
              oDatabaseHelper.AddParameter("@Title", DBNull.Value );
              
			// Pass the value of '_addressID' as parameter 'AddressID' of the stored procedure.
			if(_addressIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@AddressID", _addressIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@AddressID", DBNull.Value );
              
			// Pass the value of '_firstName' as parameter 'FirstName' of the stored procedure.
			if(_firstNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@FirstName", _firstNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@FirstName", DBNull.Value );
              
			// Pass the value of '_middleInitial' as parameter 'MiddleInitial' of the stored procedure.
			if(_middleInitialNonDefault!=null)
              oDatabaseHelper.AddParameter("@MiddleInitial", _middleInitialNonDefault);
            else
              oDatabaseHelper.AddParameter("@MiddleInitial", DBNull.Value );
              
			// Pass the value of '_lastName' as parameter 'LastName' of the stored procedure.
			if(_lastNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@LastName", _lastNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@LastName", DBNull.Value );
              
			// Pass the value of '_phoneNumber' as parameter 'PhoneNumber' of the stored procedure.
			if(_phoneNumberNonDefault!=null)
              oDatabaseHelper.AddParameter("@PhoneNumber", _phoneNumberNonDefault);
            else
              oDatabaseHelper.AddParameter("@PhoneNumber", DBNull.Value );
              
			// Pass the value of '_faxNumber' as parameter 'FaxNumber' of the stored procedure.
			if(_faxNumberNonDefault!=null)
              oDatabaseHelper.AddParameter("@FaxNumber", _faxNumberNonDefault);
            else
              oDatabaseHelper.AddParameter("@FaxNumber", DBNull.Value );
              
			// Pass the value of '_emailAddress' as parameter 'EmailAddress' of the stored procedure.
			if(_emailAddressNonDefault!=null)
              oDatabaseHelper.AddParameter("@EmailAddress", _emailAddressNonDefault);
            else
              oDatabaseHelper.AddParameter("@EmailAddress", DBNull.Value );
              
			// Pass the value of '_driversLicenseClassCode' as parameter 'DriversLicenseClassCode' of the stored procedure.
			if(_driversLicenseClassCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@DriversLicenseClassCode", _driversLicenseClassCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@DriversLicenseClassCode", DBNull.Value );
              
			// Pass the value of '_driversLicenseNum' as parameter 'DriversLicenseNum' of the stored procedure.
			if(_driversLicenseNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@DriversLicenseNum", _driversLicenseNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@DriversLicenseNum", DBNull.Value );
              
			// Pass the value of '_driversLicenseState' as parameter 'DriversLicenseState' of the stored procedure.
			if(_driversLicenseStateNonDefault!=null)
              oDatabaseHelper.AddParameter("@DriversLicenseState", _driversLicenseStateNonDefault);
            else
              oDatabaseHelper.AddParameter("@DriversLicenseState", DBNull.Value );
              
			// Pass the value of '_currentResumeID' as parameter 'CurrentResumeID' of the stored procedure.
			if(_currentResumeIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@CurrentResumeID", _currentResumeIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@CurrentResumeID", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_PERSON_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PERSON_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:33 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Insert() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_title' as parameter 'Title' of the stored procedure.
			if(_titleNonDefault!=null)
              oDatabaseHelper.AddParameter("@Title", _titleNonDefault);
            else
              oDatabaseHelper.AddParameter("@Title", DBNull.Value );
			// Pass the value of '_addressID' as parameter 'AddressID' of the stored procedure.
			if(_addressIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@AddressID", _addressIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@AddressID", DBNull.Value );
			// Pass the value of '_firstName' as parameter 'FirstName' of the stored procedure.
			if(_firstNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@FirstName", _firstNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@FirstName", DBNull.Value );
			// Pass the value of '_middleInitial' as parameter 'MiddleInitial' of the stored procedure.
			if(_middleInitialNonDefault!=null)
              oDatabaseHelper.AddParameter("@MiddleInitial", _middleInitialNonDefault);
            else
              oDatabaseHelper.AddParameter("@MiddleInitial", DBNull.Value );
			// Pass the value of '_lastName' as parameter 'LastName' of the stored procedure.
			if(_lastNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@LastName", _lastNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@LastName", DBNull.Value );
			// Pass the value of '_phoneNumber' as parameter 'PhoneNumber' of the stored procedure.
			if(_phoneNumberNonDefault!=null)
              oDatabaseHelper.AddParameter("@PhoneNumber", _phoneNumberNonDefault);
            else
              oDatabaseHelper.AddParameter("@PhoneNumber", DBNull.Value );
			// Pass the value of '_faxNumber' as parameter 'FaxNumber' of the stored procedure.
			if(_faxNumberNonDefault!=null)
              oDatabaseHelper.AddParameter("@FaxNumber", _faxNumberNonDefault);
            else
              oDatabaseHelper.AddParameter("@FaxNumber", DBNull.Value );
			// Pass the value of '_emailAddress' as parameter 'EmailAddress' of the stored procedure.
			if(_emailAddressNonDefault!=null)
              oDatabaseHelper.AddParameter("@EmailAddress", _emailAddressNonDefault);
            else
              oDatabaseHelper.AddParameter("@EmailAddress", DBNull.Value );
			// Pass the value of '_driversLicenseClassCode' as parameter 'DriversLicenseClassCode' of the stored procedure.
			if(_driversLicenseClassCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@DriversLicenseClassCode", _driversLicenseClassCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@DriversLicenseClassCode", DBNull.Value );
			// Pass the value of '_driversLicenseNum' as parameter 'DriversLicenseNum' of the stored procedure.
			if(_driversLicenseNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@DriversLicenseNum", _driversLicenseNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@DriversLicenseNum", DBNull.Value );
			// Pass the value of '_driversLicenseState' as parameter 'DriversLicenseState' of the stored procedure.
			if(_driversLicenseStateNonDefault!=null)
              oDatabaseHelper.AddParameter("@DriversLicenseState", _driversLicenseStateNonDefault);
            else
              oDatabaseHelper.AddParameter("@DriversLicenseState", DBNull.Value );
			// Pass the value of '_currentResumeID' as parameter 'CurrentResumeID' of the stored procedure.
			if(_currentResumeIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@CurrentResumeID", _currentResumeIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@CurrentResumeID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_PERSON_Insert", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:33 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Update() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_personID' as parameter 'PersonID' of the stored procedure.
			oDatabaseHelper.AddParameter("@PersonID", _personIDNonDefault );
            
			// Pass the value of '_title' as parameter 'Title' of the stored procedure.
			oDatabaseHelper.AddParameter("@Title", _titleNonDefault );
            
			// Pass the value of '_addressID' as parameter 'AddressID' of the stored procedure.
			oDatabaseHelper.AddParameter("@AddressID", _addressIDNonDefault );
            
			// Pass the value of '_firstName' as parameter 'FirstName' of the stored procedure.
			oDatabaseHelper.AddParameter("@FirstName", _firstNameNonDefault );
            
			// Pass the value of '_middleInitial' as parameter 'MiddleInitial' of the stored procedure.
			oDatabaseHelper.AddParameter("@MiddleInitial", _middleInitialNonDefault );
            
			// Pass the value of '_lastName' as parameter 'LastName' of the stored procedure.
			oDatabaseHelper.AddParameter("@LastName", _lastNameNonDefault );
            
			// Pass the value of '_phoneNumber' as parameter 'PhoneNumber' of the stored procedure.
			oDatabaseHelper.AddParameter("@PhoneNumber", _phoneNumberNonDefault );
            
			// Pass the value of '_faxNumber' as parameter 'FaxNumber' of the stored procedure.
			oDatabaseHelper.AddParameter("@FaxNumber", _faxNumberNonDefault );
            
			// Pass the value of '_emailAddress' as parameter 'EmailAddress' of the stored procedure.
			oDatabaseHelper.AddParameter("@EmailAddress", _emailAddressNonDefault );
            
			// Pass the value of '_driversLicenseClassCode' as parameter 'DriversLicenseClassCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@DriversLicenseClassCode", _driversLicenseClassCodeNonDefault );
            
			// Pass the value of '_driversLicenseNum' as parameter 'DriversLicenseNum' of the stored procedure.
			oDatabaseHelper.AddParameter("@DriversLicenseNum", _driversLicenseNumNonDefault );
            
			// Pass the value of '_driversLicenseState' as parameter 'DriversLicenseState' of the stored procedure.
			oDatabaseHelper.AddParameter("@DriversLicenseState", _driversLicenseStateNonDefault );
            
			// Pass the value of '_currentResumeID' as parameter 'CurrentResumeID' of the stored procedure.
			oDatabaseHelper.AddParameter("@CurrentResumeID", _currentResumeIDNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_PERSON_Update", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:33 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Delete() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_personID' as parameter 'PersonID' of the stored procedure.
			if(_personIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@PersonID", _personIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@PersonID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_PERSON_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_PersonPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:33 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool Delete(BO_PersonPrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_PERSON_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_PersonFields">Field of the class BO_Person</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:33 PM		Created function
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
			
			oDatabaseHelper.ExecuteScalar("GEN_PERSON_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_PersonPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_Person</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:33 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Person SelectOne(BO_PersonPrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PERSON_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_Person obj=new BO_Person();	
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
		/// <returns>list of objects of class BO_Person in the form of object of BO_People </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:33 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_People SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PERSON_SelectAll", ref ExecutionState);
			BO_People BO_People = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_People;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_Person</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_Person in the form of an object of class BO_People</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:33 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_People SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PERSON_SelectByField", ref ExecutionState);
			BO_People BO_People = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_People;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PERSONPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class PERSON</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:33 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Person SelectOneWithEDUCATIONUsingPersonID(BO_PersonPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Person obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PERSON_SelectOneWithEDUCATIONUsingPersonID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Person();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_EducationsPersonID=BO_Education.PopulateObjectsFromReader(dr);
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
		/// <param name="pk" type="PERSONPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class PERSON</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:33 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Person SelectOneWithEMPLOYMENTUsingPersonID(BO_PersonPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Person obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PERSON_SelectOneWithEMPLOYMENTUsingPersonID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Person();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_EmploymentsPersonID=BO_Employment.PopulateObjectsFromReader(dr);
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
		/// <param name="pk" type="PERSONPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class PERSON</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:33 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Person SelectOneWithOWNER_PERSONUsingPersonID(BO_PersonPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Person obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PERSON_SelectOneWithOWNER_PERSONUsingPersonID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Person();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_OwnerPeoplePersonID=BO_OwnerPerson.PopulateObjectsFromReader(dr);
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
		/// <param name="pk" type="PERSONPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class PERSON</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:33 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Person SelectOneWithPROVIDER_PERSONUsingPersonID(BO_PersonPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Person obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PERSON_SelectOneWithPROVIDER_PERSONUsingPersonID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Person();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_ProviderPeoplePersonID=BO_ProviderPerson.PopulateObjectsFromReader(dr);
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
		/// <returns>object of class BO_People</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:33 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_People SelectAllByForeignKeyAddressID(BO_AddressPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_People obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PERSON_SelectAllByForeignKeyAddressID", ref ExecutionState);
			obj = new BO_People();
			obj = BO_Person.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
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
		/// DLGenerator			01/19/2012 12:30:33 PM				Created function
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_PERSON_DeleteAllByForeignKeyAddressID", ref ExecutionState);
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
	    /// DLGenerator			01/19/2012 12:30:33 PM		Created function
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
		/// <param name="obj" type="PERSON">Object of PERSON to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:33 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_PersonBase obj,IDataReader rdr) 
		{

			obj.PersonID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_PersonFields.PersonID)));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_PersonFields.Title)))
			{
				obj.Title = rdr.GetString(rdr.GetOrdinal(BO_PersonFields.Title));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_PersonFields.AddressID)))
			{
				obj.AddressID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_PersonFields.AddressID)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_PersonFields.FirstName)))
			{
				obj.FirstName = rdr.GetString(rdr.GetOrdinal(BO_PersonFields.FirstName));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_PersonFields.MiddleInitial)))
			{
				obj.MiddleInitial = rdr.GetString(rdr.GetOrdinal(BO_PersonFields.MiddleInitial));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_PersonFields.LastName)))
			{
				obj.LastName = rdr.GetString(rdr.GetOrdinal(BO_PersonFields.LastName));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_PersonFields.PhoneNumber)))
			{
				obj.PhoneNumber = rdr.GetString(rdr.GetOrdinal(BO_PersonFields.PhoneNumber));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_PersonFields.FaxNumber)))
			{
				obj.FaxNumber = rdr.GetString(rdr.GetOrdinal(BO_PersonFields.FaxNumber));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_PersonFields.EmailAddress)))
			{
				obj.EmailAddress = rdr.GetString(rdr.GetOrdinal(BO_PersonFields.EmailAddress));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_PersonFields.DriversLicenseClassCode)))
			{
				obj.DriversLicenseClassCode = rdr.GetString(rdr.GetOrdinal(BO_PersonFields.DriversLicenseClassCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_PersonFields.DriversLicenseNum)))
			{
				obj.DriversLicenseNum = rdr.GetString(rdr.GetOrdinal(BO_PersonFields.DriversLicenseNum));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_PersonFields.DriversLicenseState)))
			{
				obj.DriversLicenseState = rdr.GetString(rdr.GetOrdinal(BO_PersonFields.DriversLicenseState));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_PersonFields.CurrentResumeID)))
			{
				obj.CurrentResumeID = rdr.GetInt32(rdr.GetOrdinal(BO_PersonFields.CurrentResumeID));
			}
			

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_People</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:33 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_People PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_People list = new BO_People();
			
			while (rdr.Read())
			{
				BO_Person obj = new BO_Person();
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
		/// <returns>Object of BO_People</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:33 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_People PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_People list = new BO_People();
			
            if (rdr.Read())
            {
                BO_Person obj = new BO_Person();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_Person();
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
