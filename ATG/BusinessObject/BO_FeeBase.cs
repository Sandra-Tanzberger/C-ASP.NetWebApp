//
// Class	:	BO_FeeBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	04/25/2012 1:49:43 PM
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
	public class BO_FeeFields
	{
		public const string FeeID                     = "FEE_ID";
		public const string PriceModelID              = "PRICE_MODEL_ID";
		public const string ProgramID                 = "PROGRAM_ID";
		public const string Licensed                  = "LICENSED";
		public const string Certified                 = "CERTIFIED";
		public const string InitialFee                = "INITIAL_FEE";
		public const string RenewalFee                = "RENEWAL_FEE";
		public const string PerUnitRoomFee            = "PER_UNIT_ROOM_FEE";
		public const string PerOffsiteFee             = "PER_OFFSITE_FEE";
		public const string ChowFee                   = "CHOW_FEE";
		public const string DelinquentFee             = "DELINQUENT_FEE";
		public const string NameChangeFee             = "NAME_CHANGE_FEE";
		public const string AddressChangeMainFee      = "ADDRESS_CHANGE_MAIN_FEE";
		public const string AddressChangeOffsiteFee   = "ADDRESS_CHANGE_OFFSITE_FEE";
		public const string ServiceChangeFee          = "SERVICE_CHANGE_FEE";
		public const string BedChangeFee              = "BED_CHANGE_FEE";
		public const string Comments                  = "COMMENTS";
		public const string Extra                     = "EXTRA";
		public const string MainAdcFee                = "MAIN_ADC_FEE";
		public const string MainRespiteCbFee          = "MAIN_RESPITE_CB_FEE";
		public const string PerBranchFee              = "PER_BRANCH_FEE";
		public const string PerSatelliteFee           = "PER_SATELLITE_FEE";
		public const string PerBranchInpatient        = "PER_BRANCH_INPATIENT";
		public const string PerBranchOutpatient       = "PER_BRANCH_OUTPATIENT";
	}
	
	/// <summary>
	/// Data access class for the "FEES" table.
	/// </summary>
	[Serializable]
	public class BO_FeeBase
	{
		
		#region Class Level Variables
		
		//private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private decimal?       	_feeIDNonDefault         	= null;
		private decimal?       	_priceModelIDNonDefault  	= null;
		private string         	_programIDNonDefault     	= null;
		private string         	_licensedNonDefault      	= null;
		private string         	_certifiedNonDefault     	= null;
		private decimal?       	_initialFeeNonDefault    	= null;
		private decimal?       	_renewalFeeNonDefault    	= null;
		private decimal?       	_perUnitRoomFeeNonDefault	= null;
		private decimal?       	_perOffsiteFeeNonDefault 	= null;
		private decimal?       	_chowFeeNonDefault       	= null;
		private decimal?       	_delinquentFeeNonDefault 	= null;
		private decimal?       	_nameChangeFeeNonDefault 	= null;
		private int?           	_addressChangeMainFeeNonDefault	= null;
		private decimal?       	_addressChangeOffsiteFeeNonDefault	= null;
		private decimal?       	_serviceChangeFeeNonDefault	= null;
		private decimal?       	_bedChangeFeeNonDefault  	= null;
		private string         	_commentsNonDefault      	= null;
		private string         	_extraNonDefault         	= null;
		private decimal?       	_mainAdcFeeNonDefault    	= null;
		private decimal?       	_mainRespiteCbFeeNonDefault	= null;
		private decimal?       	_perBranchFeeNonDefault  	= null;
		private decimal?       	_perSatelliteFeeNonDefault	= null;
		private decimal?       	_perBranchInpatientNonDefault	= null;
		private decimal?       	_perBranchOutpatientNonDefault	= null;
		
		#endregion
		
		#region Constants
		
		#endregion
    
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_FeeBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// Returns the identifier of the persistent object. Don't set it manually!
		/// </summary>
		public decimal? FeeID
		{
			get 
			{ 
                return _feeIDNonDefault;
			}
			set 
			{
            
                _feeIDNonDefault = value; 
			}
		}

		/// <summary>
		/// Returns the identifier of the persistent object. Mandatory.
		/// </summary>
		public decimal? PriceModelID
		{
			get 
			{ 
                return _priceModelIDNonDefault;
			}
			set 
			{
            
                _priceModelIDNonDefault = value; 
			}
		}

		/// <summary>
		/// The foreign key connected with another persistent object.
		/// </summary>
		public string ProgramID
		{
			get 
			{ 
                if(_programIDNonDefault==null)return _programIDNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _programIDNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 3)
					throw new ArgumentException("ProgramID length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _programIDNonDefault =null;//null value 
                }
                else
                {		           
		            _programIDNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "LICENSED" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string Licensed
		{
			get 
			{ 
                if(_licensedNonDefault==null)return _licensedNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _licensedNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("Licensed length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _licensedNonDefault =null;//null value 
                }
                else
                {		           
		            _licensedNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CERTIFIED" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string Certified
		{
			get 
			{ 
                if(_certifiedNonDefault==null)return _certifiedNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _certifiedNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("Certified length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _certifiedNonDefault =null;//null value 
                }
                else
                {		           
		            _certifiedNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "INITIAL_FEE" field.  
		/// </summary>
		public decimal? InitialFee
		{
			get 
			{ 
                return _initialFeeNonDefault;
			}
			set 
			{
            
                _initialFeeNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "RENEWAL_FEE" field.  
		/// </summary>
		public decimal? RenewalFee
		{
			get 
			{ 
                return _renewalFeeNonDefault;
			}
			set 
			{
            
                _renewalFeeNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "PER_UNIT_ROOM_FEE" field.  
		/// </summary>
		public decimal? PerUnitRoomFee
		{
			get 
			{ 
                return _perUnitRoomFeeNonDefault;
			}
			set 
			{
            
                _perUnitRoomFeeNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "PER_OFFSITE_FEE" field.  
		/// </summary>
		public decimal? PerOffsiteFee
		{
			get 
			{ 
                return _perOffsiteFeeNonDefault;
			}
			set 
			{
            
                _perOffsiteFeeNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "CHOW_FEE" field.  
		/// </summary>
		public decimal? ChowFee
		{
			get 
			{ 
                return _chowFeeNonDefault;
			}
			set 
			{
            
                _chowFeeNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "DELINQUENT_FEE" field.  
		/// </summary>
		public decimal? DelinquentFee
		{
			get 
			{ 
                return _delinquentFeeNonDefault;
			}
			set 
			{
            
                _delinquentFeeNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "NAME_CHANGE_FEE" field.  
		/// </summary>
		public decimal? NameChangeFee
		{
			get 
			{ 
                return _nameChangeFeeNonDefault;
			}
			set 
			{
            
                _nameChangeFeeNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "ADDRESS_CHANGE_MAIN_FEE" field.  
		/// </summary>
		public int? AddressChangeMainFee
		{
			get 
			{ 
                return _addressChangeMainFeeNonDefault;
			}
			set 
			{
            
                _addressChangeMainFeeNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "ADDRESS_CHANGE_OFFSITE_FEE" field.  
		/// </summary>
		public decimal? AddressChangeOffsiteFee
		{
			get 
			{ 
                return _addressChangeOffsiteFeeNonDefault;
			}
			set 
			{
            
                _addressChangeOffsiteFeeNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "SERVICE_CHANGE_FEE" field.  
		/// </summary>
		public decimal? ServiceChangeFee
		{
			get 
			{ 
                return _serviceChangeFeeNonDefault;
			}
			set 
			{
            
                _serviceChangeFeeNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "BED_CHANGE_FEE" field.  
		/// </summary>
		public decimal? BedChangeFee
		{
			get 
			{ 
                return _bedChangeFeeNonDefault;
			}
			set 
			{
            
                _bedChangeFeeNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "COMMENTS" field. Length must be between 0 and 500 characters. 
		/// </summary>
		public string Comments
		{
			get 
			{ 
                if(_commentsNonDefault==null)return _commentsNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _commentsNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 500)
					throw new ArgumentException("Comments length must be between 0 and 500 characters.");

				
                if(value ==null)
                {
                    _commentsNonDefault =null;//null value 
                }
                else
                {		           
		            _commentsNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "EXTRA" field. Length must be between 0 and 5 characters. 
		/// </summary>
		public string Extra
		{
			get 
			{ 
                if(_extraNonDefault==null)return _extraNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _extraNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 5)
					throw new ArgumentException("Extra length must be between 0 and 5 characters.");

				
                if(value ==null)
                {
                    _extraNonDefault =null;//null value 
                }
                else
                {		           
		            _extraNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "MAIN_ADC_FEE" field.  
		/// </summary>
		public decimal? MainAdcFee
		{
			get 
			{ 
                return _mainAdcFeeNonDefault;
			}
			set 
			{
            
                _mainAdcFeeNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "MAIN_RESPITE_CB_FEE" field.  
		/// </summary>
		public decimal? MainRespiteCbFee
		{
			get 
			{ 
                return _mainRespiteCbFeeNonDefault;
			}
			set 
			{
            
                _mainRespiteCbFeeNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "PER_BRANCH_FEE" field.  
		/// </summary>
		public decimal? PerBranchFee
		{
			get 
			{ 
                return _perBranchFeeNonDefault;
			}
			set 
			{
            
                _perBranchFeeNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "PER_SATELLITE_FEE" field.  
		/// </summary>
		public decimal? PerSatelliteFee
		{
			get 
			{ 
                return _perSatelliteFeeNonDefault;
			}
			set 
			{
            
                _perSatelliteFeeNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "PER_BRANCH_INPATIENT" field.  
		/// </summary>
		public decimal? PerBranchInpatient
		{
			get 
			{ 
                return _perBranchInpatientNonDefault;
			}
			set 
			{
            
                _perBranchInpatientNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "PER_BRANCH_OUTPATIENT" field.  
		/// </summary>
		public decimal? PerBranchOutpatient
		{
			get 
			{ 
                return _perBranchOutpatientNonDefault;
			}
			set 
			{
            
                _perBranchOutpatientNonDefault = value; 
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
		/// DLGenerator			04/25/2012 1:49:43 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool InsertWithDefaultValues(bool getBackValues) 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_priceModelID' as parameter 'PriceModelID' of the stored procedure.
			if(_priceModelIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@PriceModelID", _priceModelIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@PriceModelID", DBNull.Value );
              
			// Pass the value of '_programID' as parameter 'ProgramID' of the stored procedure.
			if(_programIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ProgramID", _programIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ProgramID", DBNull.Value );
              
			// Pass the value of '_licensed' as parameter 'Licensed' of the stored procedure.
			if(_licensedNonDefault!=null)
              oDatabaseHelper.AddParameter("@Licensed", _licensedNonDefault);
            else
              oDatabaseHelper.AddParameter("@Licensed", DBNull.Value );
              
			// Pass the value of '_certified' as parameter 'Certified' of the stored procedure.
			if(_certifiedNonDefault!=null)
              oDatabaseHelper.AddParameter("@Certified", _certifiedNonDefault);
            else
              oDatabaseHelper.AddParameter("@Certified", DBNull.Value );
              
			// Pass the value of '_initialFee' as parameter 'InitialFee' of the stored procedure.
			if(_initialFeeNonDefault!=null)
              oDatabaseHelper.AddParameter("@InitialFee", _initialFeeNonDefault);
            else
              oDatabaseHelper.AddParameter("@InitialFee", DBNull.Value );
              
			// Pass the value of '_renewalFee' as parameter 'RenewalFee' of the stored procedure.
			if(_renewalFeeNonDefault!=null)
              oDatabaseHelper.AddParameter("@RenewalFee", _renewalFeeNonDefault);
            else
              oDatabaseHelper.AddParameter("@RenewalFee", DBNull.Value );
              
			// Pass the value of '_perUnitRoomFee' as parameter 'PerUnitRoomFee' of the stored procedure.
			if(_perUnitRoomFeeNonDefault!=null)
              oDatabaseHelper.AddParameter("@PerUnitRoomFee", _perUnitRoomFeeNonDefault);
            else
              oDatabaseHelper.AddParameter("@PerUnitRoomFee", DBNull.Value );
              
			// Pass the value of '_perOffsiteFee' as parameter 'PerOffsiteFee' of the stored procedure.
			if(_perOffsiteFeeNonDefault!=null)
              oDatabaseHelper.AddParameter("@PerOffsiteFee", _perOffsiteFeeNonDefault);
            else
              oDatabaseHelper.AddParameter("@PerOffsiteFee", DBNull.Value );
              
			// Pass the value of '_chowFee' as parameter 'ChowFee' of the stored procedure.
			if(_chowFeeNonDefault!=null)
              oDatabaseHelper.AddParameter("@ChowFee", _chowFeeNonDefault);
            else
              oDatabaseHelper.AddParameter("@ChowFee", DBNull.Value );
              
			// Pass the value of '_delinquentFee' as parameter 'DelinquentFee' of the stored procedure.
			if(_delinquentFeeNonDefault!=null)
              oDatabaseHelper.AddParameter("@DelinquentFee", _delinquentFeeNonDefault);
            else
              oDatabaseHelper.AddParameter("@DelinquentFee", DBNull.Value );
              
			// Pass the value of '_nameChangeFee' as parameter 'NameChangeFee' of the stored procedure.
			if(_nameChangeFeeNonDefault!=null)
              oDatabaseHelper.AddParameter("@NameChangeFee", _nameChangeFeeNonDefault);
            else
              oDatabaseHelper.AddParameter("@NameChangeFee", DBNull.Value );
              
			// Pass the value of '_addressChangeMainFee' as parameter 'AddressChangeMainFee' of the stored procedure.
			if(_addressChangeMainFeeNonDefault!=null)
              oDatabaseHelper.AddParameter("@AddressChangeMainFee", _addressChangeMainFeeNonDefault);
            else
              oDatabaseHelper.AddParameter("@AddressChangeMainFee", DBNull.Value );
              
			// Pass the value of '_addressChangeOffsiteFee' as parameter 'AddressChangeOffsiteFee' of the stored procedure.
			if(_addressChangeOffsiteFeeNonDefault!=null)
              oDatabaseHelper.AddParameter("@AddressChangeOffsiteFee", _addressChangeOffsiteFeeNonDefault);
            else
              oDatabaseHelper.AddParameter("@AddressChangeOffsiteFee", DBNull.Value );
              
			// Pass the value of '_serviceChangeFee' as parameter 'ServiceChangeFee' of the stored procedure.
			if(_serviceChangeFeeNonDefault!=null)
              oDatabaseHelper.AddParameter("@ServiceChangeFee", _serviceChangeFeeNonDefault);
            else
              oDatabaseHelper.AddParameter("@ServiceChangeFee", DBNull.Value );
              
			// Pass the value of '_bedChangeFee' as parameter 'BedChangeFee' of the stored procedure.
			if(_bedChangeFeeNonDefault!=null)
              oDatabaseHelper.AddParameter("@BedChangeFee", _bedChangeFeeNonDefault);
            else
              oDatabaseHelper.AddParameter("@BedChangeFee", DBNull.Value );
              
			// Pass the value of '_comments' as parameter 'Comments' of the stored procedure.
			if(_commentsNonDefault!=null)
              oDatabaseHelper.AddParameter("@Comments", _commentsNonDefault);
            else
              oDatabaseHelper.AddParameter("@Comments", DBNull.Value );
              
			// Pass the value of '_extra' as parameter 'Extra' of the stored procedure.
			if(_extraNonDefault!=null)
              oDatabaseHelper.AddParameter("@Extra", _extraNonDefault);
            else
              oDatabaseHelper.AddParameter("@Extra", DBNull.Value );
              
			// Pass the value of '_mainAdcFee' as parameter 'MainAdcFee' of the stored procedure.
			if(_mainAdcFeeNonDefault!=null)
              oDatabaseHelper.AddParameter("@MainAdcFee", _mainAdcFeeNonDefault);
            else
              oDatabaseHelper.AddParameter("@MainAdcFee", DBNull.Value );
              
			// Pass the value of '_mainRespiteCbFee' as parameter 'MainRespiteCbFee' of the stored procedure.
			if(_mainRespiteCbFeeNonDefault!=null)
              oDatabaseHelper.AddParameter("@MainRespiteCbFee", _mainRespiteCbFeeNonDefault);
            else
              oDatabaseHelper.AddParameter("@MainRespiteCbFee", DBNull.Value );
              
			// Pass the value of '_perBranchFee' as parameter 'PerBranchFee' of the stored procedure.
			if(_perBranchFeeNonDefault!=null)
              oDatabaseHelper.AddParameter("@PerBranchFee", _perBranchFeeNonDefault);
            else
              oDatabaseHelper.AddParameter("@PerBranchFee", DBNull.Value );
              
			// Pass the value of '_perSatelliteFee' as parameter 'PerSatelliteFee' of the stored procedure.
			if(_perSatelliteFeeNonDefault!=null)
              oDatabaseHelper.AddParameter("@PerSatelliteFee", _perSatelliteFeeNonDefault);
            else
              oDatabaseHelper.AddParameter("@PerSatelliteFee", DBNull.Value );
              
			// Pass the value of '_perBranchInpatient' as parameter 'PerBranchInpatient' of the stored procedure.
			if(_perBranchInpatientNonDefault!=null)
              oDatabaseHelper.AddParameter("@PerBranchInpatient", _perBranchInpatientNonDefault);
            else
              oDatabaseHelper.AddParameter("@PerBranchInpatient", DBNull.Value );
              
			// Pass the value of '_perBranchOutpatient' as parameter 'PerBranchOutpatient' of the stored procedure.
			if(_perBranchOutpatientNonDefault!=null)
              oDatabaseHelper.AddParameter("@PerBranchOutpatient", _perBranchOutpatientNonDefault);
            else
              oDatabaseHelper.AddParameter("@PerBranchOutpatient", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_FEES_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_FEES_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
		/// DLGenerator			04/25/2012 1:49:43 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Insert() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_priceModelID' as parameter 'PriceModelID' of the stored procedure.
			if(_priceModelIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@PriceModelID", _priceModelIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@PriceModelID", DBNull.Value );
			// Pass the value of '_programID' as parameter 'ProgramID' of the stored procedure.
			if(_programIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ProgramID", _programIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ProgramID", DBNull.Value );
			// Pass the value of '_licensed' as parameter 'Licensed' of the stored procedure.
			if(_licensedNonDefault!=null)
              oDatabaseHelper.AddParameter("@Licensed", _licensedNonDefault);
            else
              oDatabaseHelper.AddParameter("@Licensed", DBNull.Value );
			// Pass the value of '_certified' as parameter 'Certified' of the stored procedure.
			if(_certifiedNonDefault!=null)
              oDatabaseHelper.AddParameter("@Certified", _certifiedNonDefault);
            else
              oDatabaseHelper.AddParameter("@Certified", DBNull.Value );
			// Pass the value of '_initialFee' as parameter 'InitialFee' of the stored procedure.
			if(_initialFeeNonDefault!=null)
              oDatabaseHelper.AddParameter("@InitialFee", _initialFeeNonDefault);
            else
              oDatabaseHelper.AddParameter("@InitialFee", DBNull.Value );
			// Pass the value of '_renewalFee' as parameter 'RenewalFee' of the stored procedure.
			if(_renewalFeeNonDefault!=null)
              oDatabaseHelper.AddParameter("@RenewalFee", _renewalFeeNonDefault);
            else
              oDatabaseHelper.AddParameter("@RenewalFee", DBNull.Value );
			// Pass the value of '_perUnitRoomFee' as parameter 'PerUnitRoomFee' of the stored procedure.
			if(_perUnitRoomFeeNonDefault!=null)
              oDatabaseHelper.AddParameter("@PerUnitRoomFee", _perUnitRoomFeeNonDefault);
            else
              oDatabaseHelper.AddParameter("@PerUnitRoomFee", DBNull.Value );
			// Pass the value of '_perOffsiteFee' as parameter 'PerOffsiteFee' of the stored procedure.
			if(_perOffsiteFeeNonDefault!=null)
              oDatabaseHelper.AddParameter("@PerOffsiteFee", _perOffsiteFeeNonDefault);
            else
              oDatabaseHelper.AddParameter("@PerOffsiteFee", DBNull.Value );
			// Pass the value of '_chowFee' as parameter 'ChowFee' of the stored procedure.
			if(_chowFeeNonDefault!=null)
              oDatabaseHelper.AddParameter("@ChowFee", _chowFeeNonDefault);
            else
              oDatabaseHelper.AddParameter("@ChowFee", DBNull.Value );
			// Pass the value of '_delinquentFee' as parameter 'DelinquentFee' of the stored procedure.
			if(_delinquentFeeNonDefault!=null)
              oDatabaseHelper.AddParameter("@DelinquentFee", _delinquentFeeNonDefault);
            else
              oDatabaseHelper.AddParameter("@DelinquentFee", DBNull.Value );
			// Pass the value of '_nameChangeFee' as parameter 'NameChangeFee' of the stored procedure.
			if(_nameChangeFeeNonDefault!=null)
              oDatabaseHelper.AddParameter("@NameChangeFee", _nameChangeFeeNonDefault);
            else
              oDatabaseHelper.AddParameter("@NameChangeFee", DBNull.Value );
			// Pass the value of '_addressChangeMainFee' as parameter 'AddressChangeMainFee' of the stored procedure.
			if(_addressChangeMainFeeNonDefault!=null)
              oDatabaseHelper.AddParameter("@AddressChangeMainFee", _addressChangeMainFeeNonDefault);
            else
              oDatabaseHelper.AddParameter("@AddressChangeMainFee", DBNull.Value );
			// Pass the value of '_addressChangeOffsiteFee' as parameter 'AddressChangeOffsiteFee' of the stored procedure.
			if(_addressChangeOffsiteFeeNonDefault!=null)
              oDatabaseHelper.AddParameter("@AddressChangeOffsiteFee", _addressChangeOffsiteFeeNonDefault);
            else
              oDatabaseHelper.AddParameter("@AddressChangeOffsiteFee", DBNull.Value );
			// Pass the value of '_serviceChangeFee' as parameter 'ServiceChangeFee' of the stored procedure.
			if(_serviceChangeFeeNonDefault!=null)
              oDatabaseHelper.AddParameter("@ServiceChangeFee", _serviceChangeFeeNonDefault);
            else
              oDatabaseHelper.AddParameter("@ServiceChangeFee", DBNull.Value );
			// Pass the value of '_bedChangeFee' as parameter 'BedChangeFee' of the stored procedure.
			if(_bedChangeFeeNonDefault!=null)
              oDatabaseHelper.AddParameter("@BedChangeFee", _bedChangeFeeNonDefault);
            else
              oDatabaseHelper.AddParameter("@BedChangeFee", DBNull.Value );
			// Pass the value of '_comments' as parameter 'Comments' of the stored procedure.
			if(_commentsNonDefault!=null)
              oDatabaseHelper.AddParameter("@Comments", _commentsNonDefault);
            else
              oDatabaseHelper.AddParameter("@Comments", DBNull.Value );
			// Pass the value of '_extra' as parameter 'Extra' of the stored procedure.
			if(_extraNonDefault!=null)
              oDatabaseHelper.AddParameter("@Extra", _extraNonDefault);
            else
              oDatabaseHelper.AddParameter("@Extra", DBNull.Value );
			// Pass the value of '_mainAdcFee' as parameter 'MainAdcFee' of the stored procedure.
			if(_mainAdcFeeNonDefault!=null)
              oDatabaseHelper.AddParameter("@MainAdcFee", _mainAdcFeeNonDefault);
            else
              oDatabaseHelper.AddParameter("@MainAdcFee", DBNull.Value );
			// Pass the value of '_mainRespiteCbFee' as parameter 'MainRespiteCbFee' of the stored procedure.
			if(_mainRespiteCbFeeNonDefault!=null)
              oDatabaseHelper.AddParameter("@MainRespiteCbFee", _mainRespiteCbFeeNonDefault);
            else
              oDatabaseHelper.AddParameter("@MainRespiteCbFee", DBNull.Value );
			// Pass the value of '_perBranchFee' as parameter 'PerBranchFee' of the stored procedure.
			if(_perBranchFeeNonDefault!=null)
              oDatabaseHelper.AddParameter("@PerBranchFee", _perBranchFeeNonDefault);
            else
              oDatabaseHelper.AddParameter("@PerBranchFee", DBNull.Value );
			// Pass the value of '_perSatelliteFee' as parameter 'PerSatelliteFee' of the stored procedure.
			if(_perSatelliteFeeNonDefault!=null)
              oDatabaseHelper.AddParameter("@PerSatelliteFee", _perSatelliteFeeNonDefault);
            else
              oDatabaseHelper.AddParameter("@PerSatelliteFee", DBNull.Value );
			// Pass the value of '_perBranchInpatient' as parameter 'PerBranchInpatient' of the stored procedure.
			if(_perBranchInpatientNonDefault!=null)
              oDatabaseHelper.AddParameter("@PerBranchInpatient", _perBranchInpatientNonDefault);
            else
              oDatabaseHelper.AddParameter("@PerBranchInpatient", DBNull.Value );
			// Pass the value of '_perBranchOutpatient' as parameter 'PerBranchOutpatient' of the stored procedure.
			if(_perBranchOutpatientNonDefault!=null)
              oDatabaseHelper.AddParameter("@PerBranchOutpatient", _perBranchOutpatientNonDefault);
            else
              oDatabaseHelper.AddParameter("@PerBranchOutpatient", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_FEES_Insert", ref ExecutionState);
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
		/// DLGenerator			04/25/2012 1:49:43 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Update() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_feeID' as parameter 'FeeID' of the stored procedure.
			oDatabaseHelper.AddParameter("@FeeID", _feeIDNonDefault );
            
			// Pass the value of '_priceModelID' as parameter 'PriceModelID' of the stored procedure.
			oDatabaseHelper.AddParameter("@PriceModelID", _priceModelIDNonDefault );
            
			// Pass the value of '_programID' as parameter 'ProgramID' of the stored procedure.
			oDatabaseHelper.AddParameter("@ProgramID", _programIDNonDefault );
            
			// Pass the value of '_licensed' as parameter 'Licensed' of the stored procedure.
			oDatabaseHelper.AddParameter("@Licensed", _licensedNonDefault );
            
			// Pass the value of '_certified' as parameter 'Certified' of the stored procedure.
			oDatabaseHelper.AddParameter("@Certified", _certifiedNonDefault );
            
			// Pass the value of '_initialFee' as parameter 'InitialFee' of the stored procedure.
			oDatabaseHelper.AddParameter("@InitialFee", _initialFeeNonDefault );
            
			// Pass the value of '_renewalFee' as parameter 'RenewalFee' of the stored procedure.
			oDatabaseHelper.AddParameter("@RenewalFee", _renewalFeeNonDefault );
            
			// Pass the value of '_perUnitRoomFee' as parameter 'PerUnitRoomFee' of the stored procedure.
			oDatabaseHelper.AddParameter("@PerUnitRoomFee", _perUnitRoomFeeNonDefault );
            
			// Pass the value of '_perOffsiteFee' as parameter 'PerOffsiteFee' of the stored procedure.
			oDatabaseHelper.AddParameter("@PerOffsiteFee", _perOffsiteFeeNonDefault );
            
			// Pass the value of '_chowFee' as parameter 'ChowFee' of the stored procedure.
			oDatabaseHelper.AddParameter("@ChowFee", _chowFeeNonDefault );
            
			// Pass the value of '_delinquentFee' as parameter 'DelinquentFee' of the stored procedure.
			oDatabaseHelper.AddParameter("@DelinquentFee", _delinquentFeeNonDefault );
            
			// Pass the value of '_nameChangeFee' as parameter 'NameChangeFee' of the stored procedure.
			oDatabaseHelper.AddParameter("@NameChangeFee", _nameChangeFeeNonDefault );
            
			// Pass the value of '_addressChangeMainFee' as parameter 'AddressChangeMainFee' of the stored procedure.
			oDatabaseHelper.AddParameter("@AddressChangeMainFee", _addressChangeMainFeeNonDefault );
            
			// Pass the value of '_addressChangeOffsiteFee' as parameter 'AddressChangeOffsiteFee' of the stored procedure.
			oDatabaseHelper.AddParameter("@AddressChangeOffsiteFee", _addressChangeOffsiteFeeNonDefault );
            
			// Pass the value of '_serviceChangeFee' as parameter 'ServiceChangeFee' of the stored procedure.
			oDatabaseHelper.AddParameter("@ServiceChangeFee", _serviceChangeFeeNonDefault );
            
			// Pass the value of '_bedChangeFee' as parameter 'BedChangeFee' of the stored procedure.
			oDatabaseHelper.AddParameter("@BedChangeFee", _bedChangeFeeNonDefault );
            
			// Pass the value of '_comments' as parameter 'Comments' of the stored procedure.
			oDatabaseHelper.AddParameter("@Comments", _commentsNonDefault );
            
			// Pass the value of '_extra' as parameter 'Extra' of the stored procedure.
			oDatabaseHelper.AddParameter("@Extra", _extraNonDefault );
            
			// Pass the value of '_mainAdcFee' as parameter 'MainAdcFee' of the stored procedure.
			oDatabaseHelper.AddParameter("@MainAdcFee", _mainAdcFeeNonDefault );
            
			// Pass the value of '_mainRespiteCbFee' as parameter 'MainRespiteCbFee' of the stored procedure.
			oDatabaseHelper.AddParameter("@MainRespiteCbFee", _mainRespiteCbFeeNonDefault );
            
			// Pass the value of '_perBranchFee' as parameter 'PerBranchFee' of the stored procedure.
			oDatabaseHelper.AddParameter("@PerBranchFee", _perBranchFeeNonDefault );
            
			// Pass the value of '_perSatelliteFee' as parameter 'PerSatelliteFee' of the stored procedure.
			oDatabaseHelper.AddParameter("@PerSatelliteFee", _perSatelliteFeeNonDefault );
            
			// Pass the value of '_perBranchInpatient' as parameter 'PerBranchInpatient' of the stored procedure.
			oDatabaseHelper.AddParameter("@PerBranchInpatient", _perBranchInpatientNonDefault );
            
			// Pass the value of '_perBranchOutpatient' as parameter 'PerBranchOutpatient' of the stored procedure.
			oDatabaseHelper.AddParameter("@PerBranchOutpatient", _perBranchOutpatientNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_FEES_Update", ref ExecutionState);
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
		/// DLGenerator			04/25/2012 1:49:43 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Delete() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_feeID' as parameter 'FeeID' of the stored procedure.
			if(_feeIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@FeeID", _feeIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@FeeID", DBNull.Value );
			// Pass the value of '_priceModelID' as parameter 'PriceModelID' of the stored procedure.
			if(_priceModelIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@PriceModelID", _priceModelIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@PriceModelID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_FEES_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_FeePrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			04/25/2012 1:49:43 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool Delete(BO_FeePrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_FEES_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_FeeFields">Field of the class BO_Fee</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			04/25/2012 1:49:43 PM		Created function
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
			
			oDatabaseHelper.ExecuteScalar("GEN_FEES_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_FeePrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_Fee</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			04/25/2012 1:49:43 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Fee SelectOne(BO_FeePrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_FEES_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_Fee obj=new BO_Fee();	
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
		/// <returns>list of objects of class BO_Fee in the form of object of BO_Fees </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			04/25/2012 1:49:43 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Fees SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_FEES_SelectAll", ref ExecutionState);
			BO_Fees BO_Fees = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Fees;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_Fee</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_Fee in the form of an object of class BO_Fees</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			04/25/2012 1:49:43 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Fees SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_FEES_SelectByField", ref ExecutionState);
			BO_Fees BO_Fees = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Fees;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="FEE_MODELPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_Fees</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			04/25/2012 1:49:43 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Fees SelectAllByForeignKeyPriceModelID(BO_FeeModelPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Fees obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_FEES_SelectAllByForeignKeyPriceModelID", ref ExecutionState);
			obj = new BO_Fees();
			obj = BO_Fee.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will delete row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="FEE_MODELPrimaryKey">Primary Key information based on which data is to be deleted.</param>
		///
		/// <returns>object of boolean type as an indicator for operation success .</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			04/25/2012 1:49:43 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool DeleteAllByForeignKeyPriceModelID(BO_FeeModelPrimaryKey pk)
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_FEES_DeleteAllByForeignKeyPriceModelID", ref ExecutionState);
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
		/// <returns>object of class BO_Fees</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			04/25/2012 1:49:43 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Fees SelectAllByForeignKeyProgramID(BO_ProgramPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Fees obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_FEES_SelectAllByForeignKeyProgramID", ref ExecutionState);
			obj = new BO_Fees();
			obj = BO_Fee.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
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
		/// DLGenerator			04/25/2012 1:49:43 PM				Created function
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_FEES_DeleteAllByForeignKeyProgramID", ref ExecutionState);
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
	    /// DLGenerator			04/25/2012 1:49:43 PM		Created function
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
		/// <param name="obj" type="FEES">Object of FEES to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			04/25/2012 1:49:43 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_FeeBase obj,IDataReader rdr) 
		{

			obj.FeeID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_FeeFields.FeeID)));
			obj.PriceModelID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_FeeFields.PriceModelID)));
			obj.ProgramID = rdr.GetString(rdr.GetOrdinal(BO_FeeFields.ProgramID));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_FeeFields.Licensed)))
			{
				obj.Licensed = rdr.GetString(rdr.GetOrdinal(BO_FeeFields.Licensed));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_FeeFields.Certified)))
			{
				obj.Certified = rdr.GetString(rdr.GetOrdinal(BO_FeeFields.Certified));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_FeeFields.InitialFee)))
			{
				obj.InitialFee = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_FeeFields.InitialFee)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_FeeFields.RenewalFee)))
			{
				obj.RenewalFee = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_FeeFields.RenewalFee)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_FeeFields.PerUnitRoomFee)))
			{
				obj.PerUnitRoomFee = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_FeeFields.PerUnitRoomFee)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_FeeFields.PerOffsiteFee)))
			{
				obj.PerOffsiteFee = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_FeeFields.PerOffsiteFee)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_FeeFields.ChowFee)))
			{
				obj.ChowFee = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_FeeFields.ChowFee)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_FeeFields.DelinquentFee)))
			{
				obj.DelinquentFee = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_FeeFields.DelinquentFee)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_FeeFields.NameChangeFee)))
			{
				obj.NameChangeFee = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_FeeFields.NameChangeFee)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_FeeFields.AddressChangeMainFee)))
			{
				obj.AddressChangeMainFee = rdr.GetInt32(rdr.GetOrdinal(BO_FeeFields.AddressChangeMainFee));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_FeeFields.AddressChangeOffsiteFee)))
			{
				obj.AddressChangeOffsiteFee = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_FeeFields.AddressChangeOffsiteFee)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_FeeFields.ServiceChangeFee)))
			{
				obj.ServiceChangeFee = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_FeeFields.ServiceChangeFee)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_FeeFields.BedChangeFee)))
			{
				obj.BedChangeFee = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_FeeFields.BedChangeFee)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_FeeFields.Comments)))
			{
				obj.Comments = rdr.GetString(rdr.GetOrdinal(BO_FeeFields.Comments));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_FeeFields.Extra)))
			{
				obj.Extra = rdr.GetString(rdr.GetOrdinal(BO_FeeFields.Extra));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_FeeFields.MainAdcFee)))
			{
				obj.MainAdcFee = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_FeeFields.MainAdcFee)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_FeeFields.MainRespiteCbFee)))
			{
				obj.MainRespiteCbFee = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_FeeFields.MainRespiteCbFee)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_FeeFields.PerBranchFee)))
			{
				obj.PerBranchFee = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_FeeFields.PerBranchFee)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_FeeFields.PerSatelliteFee)))
			{
				obj.PerSatelliteFee = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_FeeFields.PerSatelliteFee)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_FeeFields.PerBranchInpatient)))
			{
				obj.PerBranchInpatient = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_FeeFields.PerBranchInpatient)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_FeeFields.PerBranchOutpatient)))
			{
				obj.PerBranchOutpatient = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_FeeFields.PerBranchOutpatient)));
			}
			

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_Fees</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			04/25/2012 1:49:43 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_Fees PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_Fees list = new BO_Fees();
			
			while (rdr.Read())
			{
				BO_Fee obj = new BO_Fee();
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
		/// <returns>Object of BO_Fees</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			04/25/2012 1:49:43 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_Fees PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_Fees list = new BO_Fees();
			
            if (rdr.Read())
            {
                BO_Fee obj = new BO_Fee();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_Fee();
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
