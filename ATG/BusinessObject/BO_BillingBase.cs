//
// Class	:	BO_BillingBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	06/06/2012 12:32:29 PM
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
	public class BO_BillingFields
	{
		public const string PopsIntID                 = "POPS_INT_ID";
		public const string BillingID                 = "BILLING_ID";
		public const string ApplicationID             = "APPLICATION_ID";
		public const string PriceModelID              = "PRICE_MODEL_ID";
		public const string LicensureNum              = "LICENSURE_NUM";
		public const string OnlineTransactionFeePaid  = "ONLINE_TRANSACTION_FEE_PAID";
		public const string Balance                   = "BALANCE";
		public const string TotalCharges              = "TOTAL_CHARGES";
		public const string TotalPayments             = "TOTAL_PAYMENTS";
		public const string TotalRefunds              = "TOTAL_REFUNDS";
		public const string LicenseFeePaid            = "LICENSE_FEE_PAID";
		public const string IsDelinquent              = "IS_DELINQUENT";
		public const string BillToName                = "BILL_TO_NAME";
		public const string CheckLogPrefix            = "CHECK_LOG_PREFIX";
		public const string ProgramID                 = "PROGRAM_ID";
		public const string TotalAdjustments          = "TOTAL_ADJUSTMENTS";
	}
	
	/// <summary>
	/// Data access class for the "BILLING" table.
	/// </summary>
	[Serializable]
	public class BO_BillingBase
	{
		
		#region Class Level Variables
		
		//private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private decimal?       	_popsIntIDNonDefault     	= null;
		private decimal?       	_billingIDNonDefault     	= null;
		private decimal?       	_applicationIDNonDefault 	= null;
		private decimal?       	_priceModelIDNonDefault  	= null;
		private string         	_licensureNumNonDefault  	= null;
		private string         	_onlineTransactionFeePaidNonDefault	= null;
		private decimal?       	_balanceNonDefault       	= null;
		private decimal?       	_totalChargesNonDefault  	= null;
		private decimal?       	_totalPaymentsNonDefault 	= null;
		private decimal?       	_totalRefundsNonDefault  	= null;
		private string         	_licenseFeePaidNonDefault	= null;
		private string         	_isDelinquentNonDefault  	= "0";
		private string         	_billToNameNonDefault    	= null;
		private string         	_checkLogPrefixNonDefault	= null;
		private string         	_programIDNonDefault     	= null;
		private decimal?       	_totalAdjustmentsNonDefault	= null;

		private BO_BillingDetails _bO_BillingDetailsBillingID = null;
		
		#endregion
		
		#region Constants
		
		#endregion
    
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_BillingBase() { }
					
		#endregion
		
		#region Properties

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
		/// Returns the identifier of the persistent object. Don't set it manually!
		/// </summary>
		public decimal? BillingID
		{
			get 
			{ 
                return _billingIDNonDefault;
			}
			set 
			{
            
                _billingIDNonDefault = value; 
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
		/// The foreign key connected with another persistent object.
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
		/// This property is mapped to the "LICENSURE_NUM" field. Length must be between 0 and 20 characters. 
		/// </summary>
		public string LicensureNum
		{
			get 
			{ 
                if(_licensureNumNonDefault==null)return _licensureNumNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _licensureNumNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
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
		            _licensureNumNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ONLINE_TRANSACTION_FEE_PAID" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string OnlineTransactionFeePaid
		{
			get 
			{ 
                if(_onlineTransactionFeePaidNonDefault==null)return _onlineTransactionFeePaidNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _onlineTransactionFeePaidNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("OnlineTransactionFeePaid length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _onlineTransactionFeePaidNonDefault =null;//null value 
                }
                else
                {		           
		            _onlineTransactionFeePaidNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "BALANCE" field.  
		/// </summary>
		public decimal? Balance
		{
			get 
			{ 
                return _balanceNonDefault;
			}
			set 
			{
            
                _balanceNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "TOTAL_CHARGES" field.  
		/// </summary>
		public decimal? TotalCharges
		{
			get 
			{ 
                return _totalChargesNonDefault;
			}
			set 
			{
            
                _totalChargesNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "TOTAL_PAYMENTS" field.  
		/// </summary>
		public decimal? TotalPayments
		{
			get 
			{ 
                return _totalPaymentsNonDefault;
			}
			set 
			{
            
                _totalPaymentsNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "TOTAL_REFUNDS" field.  
		/// </summary>
		public decimal? TotalRefunds
		{
			get 
			{ 
                return _totalRefundsNonDefault;
			}
			set 
			{
            
                _totalRefundsNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "LICENSE_FEE_PAID" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string LicenseFeePaid
		{
			get 
			{ 
                if(_licenseFeePaidNonDefault==null)return _licenseFeePaidNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _licenseFeePaidNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("LicenseFeePaid length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _licenseFeePaidNonDefault =null;//null value 
                }
                else
                {		           
		            _licenseFeePaidNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "IS_DELINQUENT" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string IsDelinquent
		{
			get 
			{ 
                if(_isDelinquentNonDefault==null)return _isDelinquentNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _isDelinquentNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("IsDelinquent length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _isDelinquentNonDefault =null;//null value 
                }
                else
                {		           
		            _isDelinquentNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "BILL_TO_NAME" field. Length must be between 0 and 60 characters. 
		/// </summary>
		public string BillToName
		{
			get 
			{ 
                if(_billToNameNonDefault==null)return _billToNameNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _billToNameNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 60)
					throw new ArgumentException("BillToName length must be between 0 and 60 characters.");

				
                if(value ==null)
                {
                    _billToNameNonDefault =null;//null value 
                }
                else
                {		           
		            _billToNameNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CHECK_LOG_PREFIX" field. Length must be between 0 and 4 characters. 
		/// </summary>
		public string CheckLogPrefix
		{
			get 
			{ 
                if(_checkLogPrefixNonDefault==null)return _checkLogPrefixNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _checkLogPrefixNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 4)
					throw new ArgumentException("CheckLogPrefix length must be between 0 and 4 characters.");

				
                if(value ==null)
                {
                    _checkLogPrefixNonDefault =null;//null value 
                }
                else
                {		           
		            _checkLogPrefixNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "PROGRAM_ID" field. Length must be between 0 and 3 characters. 
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
		/// This property is mapped to the "TOTAL_ADJUSTMENTS" field.  
		/// </summary>
		public decimal? TotalAdjustments
		{
			get 
			{ 
                return _totalAdjustmentsNonDefault;
			}
			set 
			{
            
                _totalAdjustmentsNonDefault = value; 
			}
		}

		/// <summary>
		/// Provides access to the related table 'BILLING_DETAILS'
		/// </summary>
		public BO_BillingDetails BO_BillingDetailsBillingID
		{
			get 
			{
                if (_bO_BillingDetailsBillingID == null)
                {
                    _bO_BillingDetailsBillingID = new BO_BillingDetails();
                    _bO_BillingDetailsBillingID = BO_BillingDetail.SelectByField("BILLING_ID",BillingID);
                }                
				return _bO_BillingDetailsBillingID; 
			}
			set 
			{
				  _bO_BillingDetailsBillingID = value;
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
		/// DLGenerator			06/06/2012 12:32:29 PM		Created function
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
              
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			if(_applicationIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ApplicationID", DBNull.Value );
              
			// Pass the value of '_priceModelID' as parameter 'PriceModelID' of the stored procedure.
			if(_priceModelIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@PriceModelID", _priceModelIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@PriceModelID", DBNull.Value );
              
			// Pass the value of '_licensureNum' as parameter 'LicensureNum' of the stored procedure.
			if(_licensureNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@LicensureNum", _licensureNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@LicensureNum", DBNull.Value );
              
			// Pass the value of '_onlineTransactionFeePaid' as parameter 'OnlineTransactionFeePaid' of the stored procedure.
			if(_onlineTransactionFeePaidNonDefault!=null)
              oDatabaseHelper.AddParameter("@OnlineTransactionFeePaid", _onlineTransactionFeePaidNonDefault);
            else
              oDatabaseHelper.AddParameter("@OnlineTransactionFeePaid", DBNull.Value );
              
			// Pass the value of '_balance' as parameter 'Balance' of the stored procedure.
			if(_balanceNonDefault!=null)
              oDatabaseHelper.AddParameter("@Balance", _balanceNonDefault);
            else
              oDatabaseHelper.AddParameter("@Balance", DBNull.Value );
              
			// Pass the value of '_totalCharges' as parameter 'TotalCharges' of the stored procedure.
			if(_totalChargesNonDefault!=null)
              oDatabaseHelper.AddParameter("@TotalCharges", _totalChargesNonDefault);
            else
              oDatabaseHelper.AddParameter("@TotalCharges", DBNull.Value );
              
			// Pass the value of '_totalPayments' as parameter 'TotalPayments' of the stored procedure.
			if(_totalPaymentsNonDefault!=null)
              oDatabaseHelper.AddParameter("@TotalPayments", _totalPaymentsNonDefault);
            else
              oDatabaseHelper.AddParameter("@TotalPayments", DBNull.Value );
              
			// Pass the value of '_totalRefunds' as parameter 'TotalRefunds' of the stored procedure.
			if(_totalRefundsNonDefault!=null)
              oDatabaseHelper.AddParameter("@TotalRefunds", _totalRefundsNonDefault);
            else
              oDatabaseHelper.AddParameter("@TotalRefunds", DBNull.Value );
              
			// Pass the value of '_licenseFeePaid' as parameter 'LicenseFeePaid' of the stored procedure.
			if(_licenseFeePaidNonDefault!=null)
              oDatabaseHelper.AddParameter("@LicenseFeePaid", _licenseFeePaidNonDefault);
            else
              oDatabaseHelper.AddParameter("@LicenseFeePaid", DBNull.Value );
              
			// Pass the value of '_isDelinquent' as parameter 'IsDelinquent' of the stored procedure.
			if(_isDelinquentNonDefault!=null)
              oDatabaseHelper.AddParameter("@IsDelinquent", _isDelinquentNonDefault);
            else
              oDatabaseHelper.AddParameter("@IsDelinquent", DBNull.Value );
              
			// Pass the value of '_billToName' as parameter 'BillToName' of the stored procedure.
			if(_billToNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@BillToName", _billToNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@BillToName", DBNull.Value );
              
			// Pass the value of '_checkLogPrefix' as parameter 'CheckLogPrefix' of the stored procedure.
			if(_checkLogPrefixNonDefault!=null)
              oDatabaseHelper.AddParameter("@CheckLogPrefix", _checkLogPrefixNonDefault);
            else
              oDatabaseHelper.AddParameter("@CheckLogPrefix", DBNull.Value );
              
			// Pass the value of '_programID' as parameter 'ProgramID' of the stored procedure.
			if(_programIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ProgramID", _programIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ProgramID", DBNull.Value );
              
			// Pass the value of '_totalAdjustments' as parameter 'TotalAdjustments' of the stored procedure.
			if(_totalAdjustmentsNonDefault!=null)
              oDatabaseHelper.AddParameter("@TotalAdjustments", _totalAdjustmentsNonDefault);
            else
              oDatabaseHelper.AddParameter("@TotalAdjustments", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_BILLING_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BILLING_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
		/// DLGenerator			06/06/2012 12:32:29 PM		Created function
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
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			if(_applicationIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ApplicationID", DBNull.Value );
			// Pass the value of '_priceModelID' as parameter 'PriceModelID' of the stored procedure.
			if(_priceModelIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@PriceModelID", _priceModelIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@PriceModelID", DBNull.Value );
			// Pass the value of '_licensureNum' as parameter 'LicensureNum' of the stored procedure.
			if(_licensureNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@LicensureNum", _licensureNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@LicensureNum", DBNull.Value );
			// Pass the value of '_onlineTransactionFeePaid' as parameter 'OnlineTransactionFeePaid' of the stored procedure.
			if(_onlineTransactionFeePaidNonDefault!=null)
              oDatabaseHelper.AddParameter("@OnlineTransactionFeePaid", _onlineTransactionFeePaidNonDefault);
            else
              oDatabaseHelper.AddParameter("@OnlineTransactionFeePaid", DBNull.Value );
			// Pass the value of '_balance' as parameter 'Balance' of the stored procedure.
			if(_balanceNonDefault!=null)
              oDatabaseHelper.AddParameter("@Balance", _balanceNonDefault);
            else
              oDatabaseHelper.AddParameter("@Balance", DBNull.Value );
			// Pass the value of '_totalCharges' as parameter 'TotalCharges' of the stored procedure.
			if(_totalChargesNonDefault!=null)
              oDatabaseHelper.AddParameter("@TotalCharges", _totalChargesNonDefault);
            else
              oDatabaseHelper.AddParameter("@TotalCharges", DBNull.Value );
			// Pass the value of '_totalPayments' as parameter 'TotalPayments' of the stored procedure.
			if(_totalPaymentsNonDefault!=null)
              oDatabaseHelper.AddParameter("@TotalPayments", _totalPaymentsNonDefault);
            else
              oDatabaseHelper.AddParameter("@TotalPayments", DBNull.Value );
			// Pass the value of '_totalRefunds' as parameter 'TotalRefunds' of the stored procedure.
			if(_totalRefundsNonDefault!=null)
              oDatabaseHelper.AddParameter("@TotalRefunds", _totalRefundsNonDefault);
            else
              oDatabaseHelper.AddParameter("@TotalRefunds", DBNull.Value );
			// Pass the value of '_licenseFeePaid' as parameter 'LicenseFeePaid' of the stored procedure.
			if(_licenseFeePaidNonDefault!=null)
              oDatabaseHelper.AddParameter("@LicenseFeePaid", _licenseFeePaidNonDefault);
            else
              oDatabaseHelper.AddParameter("@LicenseFeePaid", DBNull.Value );
			// Pass the value of '_isDelinquent' as parameter 'IsDelinquent' of the stored procedure.
			if(_isDelinquentNonDefault!=null)
              oDatabaseHelper.AddParameter("@IsDelinquent", _isDelinquentNonDefault);
            else
              oDatabaseHelper.AddParameter("@IsDelinquent", DBNull.Value );
			// Pass the value of '_billToName' as parameter 'BillToName' of the stored procedure.
			if(_billToNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@BillToName", _billToNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@BillToName", DBNull.Value );
			// Pass the value of '_checkLogPrefix' as parameter 'CheckLogPrefix' of the stored procedure.
			if(_checkLogPrefixNonDefault!=null)
              oDatabaseHelper.AddParameter("@CheckLogPrefix", _checkLogPrefixNonDefault);
            else
              oDatabaseHelper.AddParameter("@CheckLogPrefix", DBNull.Value );
			// Pass the value of '_programID' as parameter 'ProgramID' of the stored procedure.
			if(_programIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ProgramID", _programIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ProgramID", DBNull.Value );
			// Pass the value of '_totalAdjustments' as parameter 'TotalAdjustments' of the stored procedure.
			if(_totalAdjustmentsNonDefault!=null)
              oDatabaseHelper.AddParameter("@TotalAdjustments", _totalAdjustmentsNonDefault);
            else
              oDatabaseHelper.AddParameter("@TotalAdjustments", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_BILLING_Insert", ref ExecutionState);
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
		/// DLGenerator			06/06/2012 12:32:29 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Update() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_popsIntID' as parameter 'PopsIntID' of the stored procedure.
			oDatabaseHelper.AddParameter("@PopsIntID", _popsIntIDNonDefault );
            
			// Pass the value of '_billingID' as parameter 'BillingID' of the stored procedure.
			oDatabaseHelper.AddParameter("@BillingID", _billingIDNonDefault );
            
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault );
            
			// Pass the value of '_priceModelID' as parameter 'PriceModelID' of the stored procedure.
			oDatabaseHelper.AddParameter("@PriceModelID", _priceModelIDNonDefault );
            
			// Pass the value of '_licensureNum' as parameter 'LicensureNum' of the stored procedure.
			oDatabaseHelper.AddParameter("@LicensureNum", _licensureNumNonDefault );
            
			// Pass the value of '_onlineTransactionFeePaid' as parameter 'OnlineTransactionFeePaid' of the stored procedure.
			oDatabaseHelper.AddParameter("@OnlineTransactionFeePaid", _onlineTransactionFeePaidNonDefault );
            
			// Pass the value of '_balance' as parameter 'Balance' of the stored procedure.
			oDatabaseHelper.AddParameter("@Balance", _balanceNonDefault );
            
			// Pass the value of '_totalCharges' as parameter 'TotalCharges' of the stored procedure.
			oDatabaseHelper.AddParameter("@TotalCharges", _totalChargesNonDefault );
            
			// Pass the value of '_totalPayments' as parameter 'TotalPayments' of the stored procedure.
			oDatabaseHelper.AddParameter("@TotalPayments", _totalPaymentsNonDefault );
            
			// Pass the value of '_totalRefunds' as parameter 'TotalRefunds' of the stored procedure.
			oDatabaseHelper.AddParameter("@TotalRefunds", _totalRefundsNonDefault );
            
			// Pass the value of '_licenseFeePaid' as parameter 'LicenseFeePaid' of the stored procedure.
			oDatabaseHelper.AddParameter("@LicenseFeePaid", _licenseFeePaidNonDefault );
            
			// Pass the value of '_isDelinquent' as parameter 'IsDelinquent' of the stored procedure.
			oDatabaseHelper.AddParameter("@IsDelinquent", _isDelinquentNonDefault );
            
			// Pass the value of '_billToName' as parameter 'BillToName' of the stored procedure.
			oDatabaseHelper.AddParameter("@BillToName", _billToNameNonDefault );
            
			// Pass the value of '_checkLogPrefix' as parameter 'CheckLogPrefix' of the stored procedure.
			oDatabaseHelper.AddParameter("@CheckLogPrefix", _checkLogPrefixNonDefault );
            
			// Pass the value of '_programID' as parameter 'ProgramID' of the stored procedure.
			oDatabaseHelper.AddParameter("@ProgramID", _programIDNonDefault );
            
			// Pass the value of '_totalAdjustments' as parameter 'TotalAdjustments' of the stored procedure.
			oDatabaseHelper.AddParameter("@TotalAdjustments", _totalAdjustmentsNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_BILLING_Update", ref ExecutionState);
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
		/// DLGenerator			06/06/2012 12:32:29 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Delete() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_billingID' as parameter 'BillingID' of the stored procedure.
			if(_billingIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@BillingID", _billingIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@BillingID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_BILLING_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_BillingPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/06/2012 12:32:29 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool Delete(BO_BillingPrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_BILLING_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_BillingFields">Field of the class BO_Billing</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/06/2012 12:32:29 PM		Created function
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
			
			oDatabaseHelper.ExecuteScalar("GEN_BILLING_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_BillingPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_Billing</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/06/2012 12:32:29 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Billing SelectOne(BO_BillingPrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BILLING_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_Billing obj=new BO_Billing();	
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
		/// <returns>list of objects of class BO_Billing in the form of object of BO_Billings </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/06/2012 12:32:29 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Billings SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BILLING_SelectAll", ref ExecutionState);
			BO_Billings BO_Billings = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Billings;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_Billing</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_Billing in the form of an object of class BO_Billings</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/06/2012 12:32:29 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Billings SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BILLING_SelectByField", ref ExecutionState);
			BO_Billings BO_Billings = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Billings;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="BILLINGPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BILLING</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/06/2012 12:32:29 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Billing SelectOneWithBILLING_DETAILSUsingBillingID(BO_BillingPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Billing obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BILLING_SelectOneWithBILLING_DETAILSUsingBillingID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Billing();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_BillingDetailsBillingID=BO_BillingDetail.PopulateObjectsFromReader(dr);
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
		/// <returns>object of class BO_Billings</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/06/2012 12:32:29 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Billings SelectAllByForeignKeyApplicationID(BO_ApplicationPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Billings obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BILLING_SelectAllByForeignKeyApplicationID", ref ExecutionState);
			obj = new BO_Billings();
			obj = BO_Billing.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
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
		/// DLGenerator			06/06/2012 12:32:29 PM				Created function
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_BILLING_DeleteAllByForeignKeyApplicationID", ref ExecutionState);
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
		/// <returns>object of class BO_Billings</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/06/2012 12:32:29 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Billings SelectAllByForeignKeyPopsIntID(BO_ProviderPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Billings obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BILLING_SelectAllByForeignKeyPopsIntID", ref ExecutionState);
			obj = new BO_Billings();
			obj = BO_Billing.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
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
		/// DLGenerator			06/06/2012 12:32:29 PM				Created function
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_BILLING_DeleteAllByForeignKeyPopsIntID", ref ExecutionState);
			oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}



		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="FEE_MODELPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_Billings</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/06/2012 12:32:29 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Billings SelectAllByForeignKeyPriceModelID(BO_FeeModelPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Billings obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BILLING_SelectAllByForeignKeyPriceModelID", ref ExecutionState);
			obj = new BO_Billings();
			obj = BO_Billing.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
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
		/// DLGenerator			06/06/2012 12:32:29 PM				Created function
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_BILLING_DeleteAllByForeignKeyPriceModelID", ref ExecutionState);
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
	    /// DLGenerator			06/06/2012 12:32:29 PM		Created function
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
		/// <param name="obj" type="BILLING">Object of BILLING to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/06/2012 12:32:29 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_BillingBase obj,IDataReader rdr) 
		{

			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingFields.PopsIntID)))
			{
				obj.PopsIntID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_BillingFields.PopsIntID)));
			}
			
			obj.BillingID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_BillingFields.BillingID)));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingFields.ApplicationID)))
			{
				obj.ApplicationID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_BillingFields.ApplicationID)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingFields.PriceModelID)))
			{
				obj.PriceModelID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_BillingFields.PriceModelID)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingFields.LicensureNum)))
			{
				obj.LicensureNum = rdr.GetString(rdr.GetOrdinal(BO_BillingFields.LicensureNum));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingFields.OnlineTransactionFeePaid)))
			{
				obj.OnlineTransactionFeePaid = rdr.GetString(rdr.GetOrdinal(BO_BillingFields.OnlineTransactionFeePaid));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingFields.Balance)))
			{
				obj.Balance = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_BillingFields.Balance)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingFields.TotalCharges)))
			{
				obj.TotalCharges = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_BillingFields.TotalCharges)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingFields.TotalPayments)))
			{
				obj.TotalPayments = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_BillingFields.TotalPayments)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingFields.TotalRefunds)))
			{
				obj.TotalRefunds = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_BillingFields.TotalRefunds)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingFields.LicenseFeePaid)))
			{
				obj.LicenseFeePaid = rdr.GetString(rdr.GetOrdinal(BO_BillingFields.LicenseFeePaid));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingFields.IsDelinquent)))
			{
				obj.IsDelinquent = rdr.GetString(rdr.GetOrdinal(BO_BillingFields.IsDelinquent));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingFields.BillToName)))
			{
				obj.BillToName = rdr.GetString(rdr.GetOrdinal(BO_BillingFields.BillToName));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingFields.CheckLogPrefix)))
			{
				obj.CheckLogPrefix = rdr.GetString(rdr.GetOrdinal(BO_BillingFields.CheckLogPrefix));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingFields.ProgramID)))
			{
				obj.ProgramID = rdr.GetString(rdr.GetOrdinal(BO_BillingFields.ProgramID));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingFields.TotalAdjustments)))
			{
				obj.TotalAdjustments = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_BillingFields.TotalAdjustments)));
			}
			

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_Billings</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/06/2012 12:32:29 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_Billings PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_Billings list = new BO_Billings();
			
			while (rdr.Read())
			{
				BO_Billing obj = new BO_Billing();
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
		/// <returns>Object of BO_Billings</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/06/2012 12:32:29 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_Billings PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_Billings list = new BO_Billings();
			
            if (rdr.Read())
            {
                BO_Billing obj = new BO_Billing();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_Billing();
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
