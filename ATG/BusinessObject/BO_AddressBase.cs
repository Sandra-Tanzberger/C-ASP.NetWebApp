//
// Class	:	BO_AddressBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	01/19/2012 12:30:21 PM
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
	public class BO_AddressFields
	{
		public const string AddressID                 = "ADDRESS_ID";
		public const string PopsIntID                 = "POPS_INT_ID";
		public const string ParishCode                = "PARISH_CODE";
		public const string ApplicationID             = "APPLICATION_ID";
		public const string AddressType               = "ADDRESS_TYPE";
		public const string Street                    = "STREET";
		public const string StateCode                 = "STATE_CODE";
		public const string City                      = "CITY";
		public const string State                     = "STATE";
		public const string ZipCode                   = "ZIP_CODE";
		public const string IsHistorical              = "IS_HISTORICAL";
		public const string Country                   = "COUNTRY";
		public const string ZipCodeExtended           = "ZIP_CODE_EXTENDED";
		public const string IsUsaAddress              = "IS_USA_ADDRESS";
		public const string County                    = "COUNTY";
	}
	
	/// <summary>
	/// Data access class for the "ADDRESS" table.
	/// </summary>
	[Serializable]
	public class BO_AddressBase
	{
		
		#region Class Level Variables
		
		//private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private decimal?       	_addressIDNonDefault     	= null;
		private decimal?       	_popsIntIDNonDefault     	= null;
		private string         	_parishCodeNonDefault    	= null;
		private decimal?       	_applicationIDNonDefault 	= null;
		private int?           	_addressTypeNonDefault   	= null;
		private string         	_streetNonDefault        	= null;
		private string         	_stateCodeNonDefault     	= null;
		private string         	_cityNonDefault          	= null;
		private string         	_stateNonDefault         	= null;
		private string         	_zipCodeNonDefault       	= null;
		private int?           	_isHistoricalNonDefault  	= null;
		private string         	_countryNonDefault       	= null;
		private string         	_zipCodeExtendedNonDefault	= null;
		private string         	_isUsaAddressNonDefault  	= null;
		private string         	_countyNonDefault        	= null;

		private BO_Affiliations _bO_AffiliationsAddressID = null;
		private BO_LegalEntities _bO_LegalEntitiesAddressID = null;
		private BO_People _bO_PeopleAddressID = null;
		
		#endregion
		
		#region Constants
		
		#endregion
    
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_AddressBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// Returns the identifier of the persistent object. Don't set it manually!
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
		public string ParishCode
		{
			get 
			{ 
                if(_parishCodeNonDefault==null)return _parishCodeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _parishCodeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
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
		            _parishCodeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
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
		/// This property is mapped to the "ADDRESS_TYPE" field.  
		/// </summary>
		public int? AddressType
		{
			get 
			{ 
                return _addressTypeNonDefault;
			}
			set 
			{
            
                _addressTypeNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "STREET" field. Length must be between 0 and 100 characters. 
		/// </summary>
		public string Street
		{
			get 
			{ 
                if(_streetNonDefault==null)return _streetNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _streetNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 100)
					throw new ArgumentException("Street length must be between 0 and 100 characters.");

				
                if(value ==null)
                {
                    _streetNonDefault =null;//null value 
                }
                else
                {		           
		            _streetNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
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
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _stateCodeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
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
		            _stateCodeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CITY" field. Length must be between 0 and 25 characters. 
		/// </summary>
		public string City
		{
			get 
			{ 
                if(_cityNonDefault==null)return _cityNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _cityNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 25)
					throw new ArgumentException("City length must be between 0 and 25 characters.");

				
                if(value ==null)
                {
                    _cityNonDefault =null;//null value 
                }
                else
                {		           
		            _cityNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "STATE" field. Length must be between 0 and 20 characters. 
		/// </summary>
		public string State
		{
			get 
			{ 
                if(_stateNonDefault==null)return _stateNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _stateNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 20)
					throw new ArgumentException("State length must be between 0 and 20 characters.");

				
                if(value ==null)
                {
                    _stateNonDefault =null;//null value 
                }
                else
                {		           
		            _stateNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ZIP_CODE" field. Length must be between 0 and 10 characters. 
		/// </summary>
		public string ZipCode
		{
			get 
			{ 
                if(_zipCodeNonDefault==null)return _zipCodeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _zipCodeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 10)
					throw new ArgumentException("ZipCode length must be between 0 and 10 characters.");

				
                if(value ==null)
                {
                    _zipCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _zipCodeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "IS_HISTORICAL" field.  
		/// </summary>
		public int? IsHistorical
		{
			get 
			{ 
                return _isHistoricalNonDefault;
			}
			set 
			{
            
                _isHistoricalNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "COUNTRY" field. Length must be between 0 and 25 characters. 
		/// </summary>
		public string Country
		{
			get 
			{ 
                if(_countryNonDefault==null)return _countryNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _countryNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 25)
					throw new ArgumentException("Country length must be between 0 and 25 characters.");

				
                if(value ==null)
                {
                    _countryNonDefault =null;//null value 
                }
                else
                {		           
		            _countryNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ZIP_CODE_EXTENDED" field. Length must be between 0 and 4 characters. 
		/// </summary>
		public string ZipCodeExtended
		{
			get 
			{ 
                if(_zipCodeExtendedNonDefault==null)return _zipCodeExtendedNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _zipCodeExtendedNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 4)
					throw new ArgumentException("ZipCodeExtended length must be between 0 and 4 characters.");

				
                if(value ==null)
                {
                    _zipCodeExtendedNonDefault =null;//null value 
                }
                else
                {		           
		            _zipCodeExtendedNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "IS_USA_ADDRESS" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string IsUsaAddress
		{
			get 
			{ 
                if(_isUsaAddressNonDefault==null)return _isUsaAddressNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _isUsaAddressNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("IsUsaAddress length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _isUsaAddressNonDefault =null;//null value 
                }
                else
                {		           
		            _isUsaAddressNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "COUNTY" field. Length must be between 0 and 25 characters. 
		/// </summary>
		public string County
		{
			get 
			{ 
                if(_countyNonDefault==null)return _countyNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _countyNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 25)
					throw new ArgumentException("County length must be between 0 and 25 characters.");

				
                if(value ==null)
                {
                    _countyNonDefault =null;//null value 
                }
                else
                {		           
		            _countyNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// Provides access to the related table 'AFFILIATION'
		/// </summary>
		public BO_Affiliations BO_AffiliationsAddressID
		{
			get 
			{
                if (_bO_AffiliationsAddressID == null)
                {
                    _bO_AffiliationsAddressID = new BO_Affiliations();
                    _bO_AffiliationsAddressID = BO_Affiliation.SelectByField("ADDRESS_ID",AddressID);
                }                
				return _bO_AffiliationsAddressID; 
			}
			set 
			{
				  _bO_AffiliationsAddressID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'LEGAL_ENTITY'
		/// </summary>
		public BO_LegalEntities BO_LegalEntitiesAddressID
		{
			get 
			{
                if (_bO_LegalEntitiesAddressID == null)
                {
                    _bO_LegalEntitiesAddressID = new BO_LegalEntities();
                    _bO_LegalEntitiesAddressID = BO_LegalEntity.SelectByField("ADDRESS_ID",AddressID);
                }                
				return _bO_LegalEntitiesAddressID; 
			}
			set 
			{
				  _bO_LegalEntitiesAddressID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'PERSON'
		/// </summary>
		public BO_People BO_PeopleAddressID
		{
			get 
			{
                if (_bO_PeopleAddressID == null)
                {
                    _bO_PeopleAddressID = new BO_People();
                    _bO_PeopleAddressID = BO_Person.SelectByField("ADDRESS_ID",AddressID);
                }                
				return _bO_PeopleAddressID; 
			}
			set 
			{
				  _bO_PeopleAddressID = value;
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
		/// DLGenerator			01/19/2012 12:30:21 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool InsertWithDefaultValues(bool getBackValues) 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_popsIntID' as parameter 'PopsIntID' of the stored procedure.
			if(_popsIntIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@PopsIntID", _popsIntIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@PopsIntID", DBNull.Value );
              
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
              
			// Pass the value of '_addressType' as parameter 'AddressType' of the stored procedure.
			if(_addressTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@AddressType", _addressTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@AddressType", DBNull.Value );
              
			// Pass the value of '_street' as parameter 'Street' of the stored procedure.
			if(_streetNonDefault!=null)
              oDatabaseHelper.AddParameter("@Street", _streetNonDefault);
            else
              oDatabaseHelper.AddParameter("@Street", DBNull.Value );
              
			// Pass the value of '_stateCode' as parameter 'StateCode' of the stored procedure.
			if(_stateCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@StateCode", _stateCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@StateCode", DBNull.Value );
              
			// Pass the value of '_city' as parameter 'City' of the stored procedure.
			if(_cityNonDefault!=null)
              oDatabaseHelper.AddParameter("@City", _cityNonDefault);
            else
              oDatabaseHelper.AddParameter("@City", DBNull.Value );
              
			// Pass the value of '_state' as parameter 'State' of the stored procedure.
			if(_stateNonDefault!=null)
              oDatabaseHelper.AddParameter("@State", _stateNonDefault);
            else
              oDatabaseHelper.AddParameter("@State", DBNull.Value );
              
			// Pass the value of '_zipCode' as parameter 'ZipCode' of the stored procedure.
			if(_zipCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@ZipCode", _zipCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@ZipCode", DBNull.Value );
              
			// Pass the value of '_isHistorical' as parameter 'IsHistorical' of the stored procedure.
			if(_isHistoricalNonDefault!=null)
              oDatabaseHelper.AddParameter("@IsHistorical", _isHistoricalNonDefault);
            else
              oDatabaseHelper.AddParameter("@IsHistorical", DBNull.Value );
              
			// Pass the value of '_country' as parameter 'Country' of the stored procedure.
			if(_countryNonDefault!=null)
              oDatabaseHelper.AddParameter("@Country", _countryNonDefault);
            else
              oDatabaseHelper.AddParameter("@Country", DBNull.Value );
              
			// Pass the value of '_zipCodeExtended' as parameter 'ZipCodeExtended' of the stored procedure.
			if(_zipCodeExtendedNonDefault!=null)
              oDatabaseHelper.AddParameter("@ZipCodeExtended", _zipCodeExtendedNonDefault);
            else
              oDatabaseHelper.AddParameter("@ZipCodeExtended", DBNull.Value );
              
			// Pass the value of '_isUsaAddress' as parameter 'IsUsaAddress' of the stored procedure.
			if(_isUsaAddressNonDefault!=null)
              oDatabaseHelper.AddParameter("@IsUsaAddress", _isUsaAddressNonDefault);
            else
              oDatabaseHelper.AddParameter("@IsUsaAddress", DBNull.Value );
              
			// Pass the value of '_county' as parameter 'County' of the stored procedure.
			if(_countyNonDefault!=null)
              oDatabaseHelper.AddParameter("@County", _countyNonDefault);
            else
              oDatabaseHelper.AddParameter("@County", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_ADDRESS_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_ADDRESS_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:21 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Insert() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_popsIntID' as parameter 'PopsIntID' of the stored procedure.
			if(_popsIntIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@PopsIntID", _popsIntIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@PopsIntID", DBNull.Value );
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
			// Pass the value of '_addressType' as parameter 'AddressType' of the stored procedure.
			if(_addressTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@AddressType", _addressTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@AddressType", DBNull.Value );
			// Pass the value of '_street' as parameter 'Street' of the stored procedure.
			if(_streetNonDefault!=null)
              oDatabaseHelper.AddParameter("@Street", _streetNonDefault);
            else
              oDatabaseHelper.AddParameter("@Street", DBNull.Value );
			// Pass the value of '_stateCode' as parameter 'StateCode' of the stored procedure.
			if(_stateCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@StateCode", _stateCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@StateCode", DBNull.Value );
			// Pass the value of '_city' as parameter 'City' of the stored procedure.
			if(_cityNonDefault!=null)
              oDatabaseHelper.AddParameter("@City", _cityNonDefault);
            else
              oDatabaseHelper.AddParameter("@City", DBNull.Value );
			// Pass the value of '_state' as parameter 'State' of the stored procedure.
			if(_stateNonDefault!=null)
              oDatabaseHelper.AddParameter("@State", _stateNonDefault);
            else
              oDatabaseHelper.AddParameter("@State", DBNull.Value );
			// Pass the value of '_zipCode' as parameter 'ZipCode' of the stored procedure.
			if(_zipCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@ZipCode", _zipCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@ZipCode", DBNull.Value );
			// Pass the value of '_isHistorical' as parameter 'IsHistorical' of the stored procedure.
			if(_isHistoricalNonDefault!=null)
              oDatabaseHelper.AddParameter("@IsHistorical", _isHistoricalNonDefault);
            else
              oDatabaseHelper.AddParameter("@IsHistorical", DBNull.Value );
			// Pass the value of '_country' as parameter 'Country' of the stored procedure.
			if(_countryNonDefault!=null)
              oDatabaseHelper.AddParameter("@Country", _countryNonDefault);
            else
              oDatabaseHelper.AddParameter("@Country", DBNull.Value );
			// Pass the value of '_zipCodeExtended' as parameter 'ZipCodeExtended' of the stored procedure.
			if(_zipCodeExtendedNonDefault!=null)
              oDatabaseHelper.AddParameter("@ZipCodeExtended", _zipCodeExtendedNonDefault);
            else
              oDatabaseHelper.AddParameter("@ZipCodeExtended", DBNull.Value );
			// Pass the value of '_isUsaAddress' as parameter 'IsUsaAddress' of the stored procedure.
			if(_isUsaAddressNonDefault!=null)
              oDatabaseHelper.AddParameter("@IsUsaAddress", _isUsaAddressNonDefault);
            else
              oDatabaseHelper.AddParameter("@IsUsaAddress", DBNull.Value );
			// Pass the value of '_county' as parameter 'County' of the stored procedure.
			if(_countyNonDefault!=null)
              oDatabaseHelper.AddParameter("@County", _countyNonDefault);
            else
              oDatabaseHelper.AddParameter("@County", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_ADDRESS_Insert", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:21 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Update() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_addressID' as parameter 'AddressID' of the stored procedure.
			oDatabaseHelper.AddParameter("@AddressID", _addressIDNonDefault );
            
			// Pass the value of '_popsIntID' as parameter 'PopsIntID' of the stored procedure.
			oDatabaseHelper.AddParameter("@PopsIntID", _popsIntIDNonDefault );
            
			// Pass the value of '_parishCode' as parameter 'ParishCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@ParishCode", _parishCodeNonDefault );
            
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault );
            
			// Pass the value of '_addressType' as parameter 'AddressType' of the stored procedure.
			oDatabaseHelper.AddParameter("@AddressType", _addressTypeNonDefault );
            
			// Pass the value of '_street' as parameter 'Street' of the stored procedure.
			oDatabaseHelper.AddParameter("@Street", _streetNonDefault );
            
			// Pass the value of '_stateCode' as parameter 'StateCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@StateCode", _stateCodeNonDefault );
            
			// Pass the value of '_city' as parameter 'City' of the stored procedure.
			oDatabaseHelper.AddParameter("@City", _cityNonDefault );
            
			// Pass the value of '_state' as parameter 'State' of the stored procedure.
			oDatabaseHelper.AddParameter("@State", _stateNonDefault );
            
			// Pass the value of '_zipCode' as parameter 'ZipCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@ZipCode", _zipCodeNonDefault );
            
			// Pass the value of '_isHistorical' as parameter 'IsHistorical' of the stored procedure.
			oDatabaseHelper.AddParameter("@IsHistorical", _isHistoricalNonDefault );
            
			// Pass the value of '_country' as parameter 'Country' of the stored procedure.
			oDatabaseHelper.AddParameter("@Country", _countryNonDefault );
            
			// Pass the value of '_zipCodeExtended' as parameter 'ZipCodeExtended' of the stored procedure.
			oDatabaseHelper.AddParameter("@ZipCodeExtended", _zipCodeExtendedNonDefault );
            
			// Pass the value of '_isUsaAddress' as parameter 'IsUsaAddress' of the stored procedure.
			oDatabaseHelper.AddParameter("@IsUsaAddress", _isUsaAddressNonDefault );
            
			// Pass the value of '_county' as parameter 'County' of the stored procedure.
			oDatabaseHelper.AddParameter("@County", _countyNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_ADDRESS_Update", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:21 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Delete() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_addressID' as parameter 'AddressID' of the stored procedure.
			if(_addressIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@AddressID", _addressIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@AddressID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_ADDRESS_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_AddressPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:21 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool Delete(BO_AddressPrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_ADDRESS_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_AddressFields">Field of the class BO_Address</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:21 PM		Created function
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
			
			oDatabaseHelper.ExecuteScalar("GEN_ADDRESS_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_AddressPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_Address</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:21 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Address SelectOne(BO_AddressPrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_ADDRESS_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_Address obj=new BO_Address();	
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
		/// <returns>list of objects of class BO_Address in the form of object of BO_Addresses </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:21 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Addresses SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_ADDRESS_SelectAll", ref ExecutionState);
			BO_Addresses BO_Addresses = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Addresses;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_Address</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_Address in the form of an object of class BO_Addresses</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:21 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Addresses SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_ADDRESS_SelectByField", ref ExecutionState);
			BO_Addresses BO_Addresses = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Addresses;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="ADDRESSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class ADDRESS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:21 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Address SelectOneWithAFFILIATIONUsingAddressID(BO_AddressPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Address obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_ADDRESS_SelectOneWithAFFILIATIONUsingAddressID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Address();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_AffiliationsAddressID=BO_Affiliation.PopulateObjectsFromReader(dr);
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
		/// <returns>object of class ADDRESS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:21 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Address SelectOneWithLEGAL_ENTITYUsingAddressID(BO_AddressPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Address obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_ADDRESS_SelectOneWithLEGAL_ENTITYUsingAddressID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Address();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_LegalEntitiesAddressID=BO_LegalEntity.PopulateObjectsFromReader(dr);
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
		/// <returns>object of class ADDRESS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:21 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Address SelectOneWithPERSONUsingAddressID(BO_AddressPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Address obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_ADDRESS_SelectOneWithPERSONUsingAddressID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Address();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_PeopleAddressID=BO_Person.PopulateObjectsFromReader(dr);
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
		/// <param name="pk" type="APPLICATIONSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_Addresses</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:21 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Addresses SelectAllByForeignKeyApplicationID(BO_ApplicationPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Addresses obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_ADDRESS_SelectAllByForeignKeyApplicationID", ref ExecutionState);
			obj = new BO_Addresses();
			obj = BO_Address.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
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
		/// DLGenerator			01/19/2012 12:30:21 PM				Created function
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_ADDRESS_DeleteAllByForeignKeyApplicationID", ref ExecutionState);
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
		/// <returns>object of class BO_Addresses</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:21 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Addresses SelectAllByForeignKeyParishCode(BO_ParishePrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Addresses obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_ADDRESS_SelectAllByForeignKeyParishCode", ref ExecutionState);
			obj = new BO_Addresses();
			obj = BO_Address.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
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
		/// DLGenerator			01/19/2012 12:30:21 PM				Created function
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_ADDRESS_DeleteAllByForeignKeyParishCode", ref ExecutionState);
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
		/// <returns>object of class BO_Addresses</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:21 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Addresses SelectAllByForeignKeyPopsIntID(BO_ProviderPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Addresses obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_ADDRESS_SelectAllByForeignKeyPopsIntID", ref ExecutionState);
			obj = new BO_Addresses();
			obj = BO_Address.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
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
		/// DLGenerator			01/19/2012 12:30:21 PM				Created function
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_ADDRESS_DeleteAllByForeignKeyPopsIntID", ref ExecutionState);
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
		/// <returns>object of class BO_Addresses</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:21 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Addresses SelectAllByForeignKeyStateCode(BO_StatePrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Addresses obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_ADDRESS_SelectAllByForeignKeyStateCode", ref ExecutionState);
			obj = new BO_Addresses();
			obj = BO_Address.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
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
		/// DLGenerator			01/19/2012 12:30:21 PM				Created function
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_ADDRESS_DeleteAllByForeignKeyStateCode", ref ExecutionState);
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
	    /// DLGenerator			01/19/2012 12:30:21 PM		Created function
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
		/// <param name="obj" type="ADDRESS">Object of ADDRESS to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:21 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_AddressBase obj,IDataReader rdr) 
		{

			obj.AddressID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_AddressFields.AddressID)));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AddressFields.PopsIntID)))
			{
				obj.PopsIntID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_AddressFields.PopsIntID)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AddressFields.ParishCode)))
			{
				obj.ParishCode = rdr.GetString(rdr.GetOrdinal(BO_AddressFields.ParishCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AddressFields.ApplicationID)))
			{
				obj.ApplicationID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_AddressFields.ApplicationID)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AddressFields.AddressType)))
			{
				obj.AddressType = rdr.GetInt32(rdr.GetOrdinal(BO_AddressFields.AddressType));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AddressFields.Street)))
			{
				obj.Street = rdr.GetString(rdr.GetOrdinal(BO_AddressFields.Street));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AddressFields.StateCode)))
			{
				obj.StateCode = rdr.GetString(rdr.GetOrdinal(BO_AddressFields.StateCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AddressFields.City)))
			{
				obj.City = rdr.GetString(rdr.GetOrdinal(BO_AddressFields.City));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AddressFields.State)))
			{
				obj.State = rdr.GetString(rdr.GetOrdinal(BO_AddressFields.State));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AddressFields.ZipCode)))
			{
				obj.ZipCode = rdr.GetString(rdr.GetOrdinal(BO_AddressFields.ZipCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AddressFields.IsHistorical)))
			{
				obj.IsHistorical = rdr.GetInt32(rdr.GetOrdinal(BO_AddressFields.IsHistorical));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AddressFields.Country)))
			{
				obj.Country = rdr.GetString(rdr.GetOrdinal(BO_AddressFields.Country));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AddressFields.ZipCodeExtended)))
			{
				obj.ZipCodeExtended = rdr.GetString(rdr.GetOrdinal(BO_AddressFields.ZipCodeExtended));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AddressFields.IsUsaAddress)))
			{
				obj.IsUsaAddress = rdr.GetString(rdr.GetOrdinal(BO_AddressFields.IsUsaAddress));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AddressFields.County)))
			{
				obj.County = rdr.GetString(rdr.GetOrdinal(BO_AddressFields.County));
			}
			

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_Addresses</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:21 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_Addresses PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_Addresses list = new BO_Addresses();
			
			while (rdr.Read())
			{
				BO_Address obj = new BO_Address();
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
		/// <returns>Object of BO_Addresses</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:21 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_Addresses PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_Addresses list = new BO_Addresses();
			
            if (rdr.Read())
            {
                BO_Address obj = new BO_Address();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_Address();
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
