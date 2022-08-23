//
// Class	:	BO_BillingDetailBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	12/30/2014 3:52:03 PM
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
	public class BO_BillingDetailFields
	{
		public const string BillingDetailID           = "BILLING_DETAIL_ID";
		public const string BillingID                 = "BILLING_ID";
		public const string TypeFee                   = "TYPE_FEE";
		public const string BatchID                   = "BATCH_ID";
		public const string TypeBilling               = "TYPE_BILLING";
		public const string PivNum                    = "PIV_NUM";
		public const string Amount                    = "AMOUNT";
		public const string PayMode                   = "PAY_MODE";
		public const string Comment                   = "COMMENT";
		public const string TransactionID             = "TRANSACTION_ID";
		public const string TransactionDate           = "TRANSACTION_DATE";
		public const string TransactionStatus         = "TRANSACTION_STATUS";
		public const string ProcessedDate             = "PROCESSED_DATE";
		public const string Revised                   = "REVISED";
		public const string CheckDate                 = "CHECK_DATE";
		public const string ProcessedBY               = "PROCESSED_BY";
		public const string DepositDate               = "DEPOSIT_DATE";
	}
	
	/// <summary>
	/// Data access class for the "BILLING_DETAILS" table.
	/// </summary>
	[Serializable]
	public class BO_BillingDetailBase
	{
		
		#region Class Level Variables
		
		private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private decimal?       	_billingDetailIDNonDefault	= null;
		private decimal?       	_billingIDNonDefault     	= null;
		private string         	_typeFeeNonDefault       	= null;
		private decimal?       	_batchIDNonDefault       	= null;
		private string         	_typeBillingNonDefault   	= null;
		private string         	_pivNumNonDefault        	= null;
		private decimal?       	_amountNonDefault        	= null;
		private string         	_payModeNonDefault       	= null;
		private string         	_commentNonDefault       	= null;
		private string         	_transactionIDNonDefault 	= null;
		private DateTime?      	_transactionDateNonDefault	= null;
		private string         	_transactionStatusNonDefault	= null;
		private DateTime?      	_processedDateNonDefault 	= null;
		private string         	_revisedNonDefault       	= "0";
		private DateTime?      	_checkDateNonDefault     	= null;
		private string         	_processedBYNonDefault   	= null;
		private DateTime?      	_depositDateNonDefault   	= null;
		
		#endregion
		
		#region Constants
		
		#endregion
		
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_BillingDetailBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// Returns the identifier of the persistent object. Don't set it manually!
		/// </summary>
		public decimal? BillingDetailID
		{
			get 
			{ 
                return _billingDetailIDNonDefault;
			}
			set 
			{
            
                _billingDetailIDNonDefault = value; 
			}
		}

		/// <summary>
		/// The foreign key connected with another persistent object.
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
		/// This property is mapped to the "TYPE_FEE" field. Length must be between 0 and 2 characters. 
		/// </summary>
		public string TypeFee
		{
			get 
			{ 
                if(_typeFeeNonDefault==null)return _typeFeeNonDefault;
				else return _typeFeeNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 2)
					throw new ArgumentException("TypeFee length must be between 0 and 2 characters.");

				
                if(value ==null)
                {
                    _typeFeeNonDefault =null;//null value 
                }
                else
                {		           
		            _typeFeeNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// The foreign key connected with another persistent object.
		/// </summary>
		public decimal? BatchID
		{
			get 
			{ 
                return _batchIDNonDefault;
			}
			set 
			{
            
                _batchIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_BILLING" field. Length must be between 0 and 5 characters. Mandatory.
		/// </summary>
		public string TypeBilling
		{
			get 
			{ 
                if(_typeBillingNonDefault==null)return _typeBillingNonDefault;
				else return _typeBillingNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 5)
					throw new ArgumentException("TypeBilling length must be between 0 and 5 characters.");

				
                if(value ==null)
                {
                    _typeBillingNonDefault =null;//null value 
                }
                else
                {		           
		            _typeBillingNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "PIV_NUM" field. Length must be between 0 and 6 characters. 
		/// </summary>
		public string PivNum
		{
			get 
			{ 
                if(_pivNumNonDefault==null)return _pivNumNonDefault;
				else return _pivNumNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 6)
					throw new ArgumentException("PivNum length must be between 0 and 6 characters.");

				
                if(value ==null)
                {
                    _pivNumNonDefault =null;//null value 
                }
                else
                {		           
		            _pivNumNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "AMOUNT" field.  
		/// </summary>
		public decimal? Amount
		{
			get 
			{ 
                return _amountNonDefault;
			}
			set 
			{
            
                _amountNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "PAY_MODE" field. Length must be between 0 and 5 characters. 
		/// </summary>
		public string PayMode
		{
			get 
			{ 
                if(_payModeNonDefault==null)return _payModeNonDefault;
				else return _payModeNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 5)
					throw new ArgumentException("PayMode length must be between 0 and 5 characters.");

				
                if(value ==null)
                {
                    _payModeNonDefault =null;//null value 
                }
                else
                {		           
		            _payModeNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "COMMENT" field. Length must be between 0 and 255 characters. 
		/// </summary>
		public string Comment
		{
			get 
			{ 
                if(_commentNonDefault==null)return _commentNonDefault;
				else return _commentNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 255)
					throw new ArgumentException("Comment length must be between 0 and 255 characters.");

				
                if(value ==null)
                {
                    _commentNonDefault =null;//null value 
                }
                else
                {		           
		            _commentNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TRANSACTION_ID" field. Length must be between 0 and 40 characters. 
		/// </summary>
		public string TransactionID
		{
			get 
			{ 
                if(_transactionIDNonDefault==null)return _transactionIDNonDefault;
				else return _transactionIDNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 40)
					throw new ArgumentException("TransactionID length must be between 0 and 40 characters.");

				
                if(value ==null)
                {
                    _transactionIDNonDefault =null;//null value 
                }
                else
                {		           
		            _transactionIDNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TRANSACTION_DATE" field.  
		/// </summary>
		public DateTime? TransactionDate
		{
			get 
			{ 
                return _transactionDateNonDefault;
			}
			set 
			{
            
                _transactionDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "TRANSACTION_STATUS" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string TransactionStatus
		{
			get 
			{ 
                if(_transactionStatusNonDefault==null)return _transactionStatusNonDefault;
				else return _transactionStatusNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("TransactionStatus length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _transactionStatusNonDefault =null;//null value 
                }
                else
                {		           
		            _transactionStatusNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "PROCESSED_DATE" field.  
		/// </summary>
		public DateTime? ProcessedDate
		{
			get 
			{ 
                return _processedDateNonDefault;
			}
			set 
			{
            
                _processedDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "REVISED" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string Revised
		{
			get 
			{ 
                if(_revisedNonDefault==null)return _revisedNonDefault;
				else return _revisedNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("Revised length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _revisedNonDefault =null;//null value 
                }
                else
                {		           
		            _revisedNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CHECK_DATE" field.  
		/// </summary>
		public DateTime? CheckDate
		{
			get 
			{ 
                return _checkDateNonDefault;
			}
			set 
			{
            
                _checkDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "PROCESSED_BY" field. Length must be between 0 and 5 characters. 
		/// </summary>
		public string ProcessedBY
		{
			get 
			{ 
                if(_processedBYNonDefault==null)return _processedBYNonDefault;
				else return _processedBYNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 5)
					throw new ArgumentException("ProcessedBY length must be between 0 and 5 characters.");

				
                if(value ==null)
                {
                    _processedBYNonDefault =null;//null value 
                }
                else
                {		           
		            _processedBYNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "DEPOSIT_DATE" field.  
		/// </summary>
		public DateTime? DepositDate
		{
			get 
			{ 
                return _depositDateNonDefault;
			}
			set 
			{
            
                _depositDateNonDefault = value; 
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
		/// DLGenerator			12/30/2014 3:52:03 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool InsertWithDefaultValues(bool getBackValues) 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_billingID' as parameter 'BillingID' of the stored procedure.
			if(_billingIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@BillingID", _billingIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@BillingID", DBNull.Value );
              
			// Pass the value of '_typeFee' as parameter 'TypeFee' of the stored procedure.
			if(_typeFeeNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFee", _typeFeeNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFee", DBNull.Value );
              
			// Pass the value of '_batchID' as parameter 'BatchID' of the stored procedure.
			if(_batchIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@BatchID", _batchIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@BatchID", DBNull.Value );
              
			// Pass the value of '_typeBilling' as parameter 'TypeBilling' of the stored procedure.
			if(_typeBillingNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeBilling", _typeBillingNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeBilling", DBNull.Value );
              
			// Pass the value of '_pivNum' as parameter 'PivNum' of the stored procedure.
			if(_pivNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@PivNum", _pivNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@PivNum", DBNull.Value );
              
			// Pass the value of '_amount' as parameter 'Amount' of the stored procedure.
			if(_amountNonDefault!=null)
              oDatabaseHelper.AddParameter("@Amount", _amountNonDefault);
            else
              oDatabaseHelper.AddParameter("@Amount", DBNull.Value );
              
			// Pass the value of '_payMode' as parameter 'PayMode' of the stored procedure.
			if(_payModeNonDefault!=null)
              oDatabaseHelper.AddParameter("@PayMode", _payModeNonDefault);
            else
              oDatabaseHelper.AddParameter("@PayMode", DBNull.Value );
              
			// Pass the value of '_comment' as parameter 'Comment' of the stored procedure.
			if(_commentNonDefault!=null)
              oDatabaseHelper.AddParameter("@Comment", _commentNonDefault);
            else
              oDatabaseHelper.AddParameter("@Comment", DBNull.Value );
              
			// Pass the value of '_transactionID' as parameter 'TransactionID' of the stored procedure.
			if(_transactionIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@TransactionID", _transactionIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@TransactionID", DBNull.Value );
              
			// Pass the value of '_transactionDate' as parameter 'TransactionDate' of the stored procedure.
			if(_transactionDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@TransactionDate", _transactionDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@TransactionDate", DBNull.Value );
              
			// Pass the value of '_transactionStatus' as parameter 'TransactionStatus' of the stored procedure.
			if(_transactionStatusNonDefault!=null)
              oDatabaseHelper.AddParameter("@TransactionStatus", _transactionStatusNonDefault);
            else
              oDatabaseHelper.AddParameter("@TransactionStatus", DBNull.Value );
              
			// Pass the value of '_processedDate' as parameter 'ProcessedDate' of the stored procedure.
			if(_processedDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@ProcessedDate", _processedDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@ProcessedDate", DBNull.Value );
              
			// Pass the value of '_revised' as parameter 'Revised' of the stored procedure.
			if(_revisedNonDefault!=null)
              oDatabaseHelper.AddParameter("@Revised", _revisedNonDefault);
            else
              oDatabaseHelper.AddParameter("@Revised", DBNull.Value );
              
			// Pass the value of '_checkDate' as parameter 'CheckDate' of the stored procedure.
			if(_checkDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@CheckDate", _checkDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@CheckDate", DBNull.Value );
              
			// Pass the value of '_processedBY' as parameter 'ProcessedBY' of the stored procedure.
			if(_processedBYNonDefault!=null)
              oDatabaseHelper.AddParameter("@ProcessedBY", _processedBYNonDefault);
            else
              oDatabaseHelper.AddParameter("@ProcessedBY", DBNull.Value );
              
			// Pass the value of '_depositDate' as parameter 'DepositDate' of the stored procedure.
			if(_depositDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@DepositDate", _depositDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@DepositDate", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_BILLING_DETAILS_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BILLING_DETAILS_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
		/// DLGenerator			12/30/2014 3:52:03 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Insert() 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_billingID' as parameter 'BillingID' of the stored procedure.
			if(_billingIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@BillingID", _billingIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@BillingID", DBNull.Value );
			// Pass the value of '_typeFee' as parameter 'TypeFee' of the stored procedure.
			if(_typeFeeNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFee", _typeFeeNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFee", DBNull.Value );
			// Pass the value of '_batchID' as parameter 'BatchID' of the stored procedure.
			if(_batchIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@BatchID", _batchIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@BatchID", DBNull.Value );
			// Pass the value of '_typeBilling' as parameter 'TypeBilling' of the stored procedure.
			if(_typeBillingNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeBilling", _typeBillingNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeBilling", DBNull.Value );
			// Pass the value of '_pivNum' as parameter 'PivNum' of the stored procedure.
			if(_pivNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@PivNum", _pivNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@PivNum", DBNull.Value );
			// Pass the value of '_amount' as parameter 'Amount' of the stored procedure.
			if(_amountNonDefault!=null)
              oDatabaseHelper.AddParameter("@Amount", _amountNonDefault);
            else
              oDatabaseHelper.AddParameter("@Amount", DBNull.Value );
			// Pass the value of '_payMode' as parameter 'PayMode' of the stored procedure.
			if(_payModeNonDefault!=null)
              oDatabaseHelper.AddParameter("@PayMode", _payModeNonDefault);
            else
              oDatabaseHelper.AddParameter("@PayMode", DBNull.Value );
			// Pass the value of '_comment' as parameter 'Comment' of the stored procedure.
			if(_commentNonDefault!=null)
              oDatabaseHelper.AddParameter("@Comment", _commentNonDefault);
            else
              oDatabaseHelper.AddParameter("@Comment", DBNull.Value );
			// Pass the value of '_transactionID' as parameter 'TransactionID' of the stored procedure.
			if(_transactionIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@TransactionID", _transactionIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@TransactionID", DBNull.Value );
			// Pass the value of '_transactionDate' as parameter 'TransactionDate' of the stored procedure.
			if(_transactionDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@TransactionDate", _transactionDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@TransactionDate", DBNull.Value );
			// Pass the value of '_transactionStatus' as parameter 'TransactionStatus' of the stored procedure.
			if(_transactionStatusNonDefault!=null)
              oDatabaseHelper.AddParameter("@TransactionStatus", _transactionStatusNonDefault);
            else
              oDatabaseHelper.AddParameter("@TransactionStatus", DBNull.Value );
			// Pass the value of '_processedDate' as parameter 'ProcessedDate' of the stored procedure.
			if(_processedDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@ProcessedDate", _processedDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@ProcessedDate", DBNull.Value );
			// Pass the value of '_revised' as parameter 'Revised' of the stored procedure.
			if(_revisedNonDefault!=null)
              oDatabaseHelper.AddParameter("@Revised", _revisedNonDefault);
            else
              oDatabaseHelper.AddParameter("@Revised", DBNull.Value );
			// Pass the value of '_checkDate' as parameter 'CheckDate' of the stored procedure.
			if(_checkDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@CheckDate", _checkDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@CheckDate", DBNull.Value );
			// Pass the value of '_processedBY' as parameter 'ProcessedBY' of the stored procedure.
			if(_processedBYNonDefault!=null)
              oDatabaseHelper.AddParameter("@ProcessedBY", _processedBYNonDefault);
            else
              oDatabaseHelper.AddParameter("@ProcessedBY", DBNull.Value );
			// Pass the value of '_depositDate' as parameter 'DepositDate' of the stored procedure.
			if(_depositDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@DepositDate", _depositDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@DepositDate", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_BILLING_DETAILS_Insert", ref ExecutionState);
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
		/// DLGenerator			12/30/2014 3:52:03 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Update() 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_billingDetailID' as parameter 'BillingDetailID' of the stored procedure.
			oDatabaseHelper.AddParameter("@BillingDetailID", _billingDetailIDNonDefault );
            
			// Pass the value of '_billingID' as parameter 'BillingID' of the stored procedure.
			oDatabaseHelper.AddParameter("@BillingID", _billingIDNonDefault );
            
			// Pass the value of '_typeFee' as parameter 'TypeFee' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeFee", _typeFeeNonDefault );
            
			// Pass the value of '_batchID' as parameter 'BatchID' of the stored procedure.
			oDatabaseHelper.AddParameter("@BatchID", _batchIDNonDefault );
            
			// Pass the value of '_typeBilling' as parameter 'TypeBilling' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeBilling", _typeBillingNonDefault );
            
			// Pass the value of '_pivNum' as parameter 'PivNum' of the stored procedure.
			oDatabaseHelper.AddParameter("@PivNum", _pivNumNonDefault );
            
			// Pass the value of '_amount' as parameter 'Amount' of the stored procedure.
			oDatabaseHelper.AddParameter("@Amount", _amountNonDefault );
            
			// Pass the value of '_payMode' as parameter 'PayMode' of the stored procedure.
			oDatabaseHelper.AddParameter("@PayMode", _payModeNonDefault );
            
			// Pass the value of '_comment' as parameter 'Comment' of the stored procedure.
			oDatabaseHelper.AddParameter("@Comment", _commentNonDefault );
            
			// Pass the value of '_transactionID' as parameter 'TransactionID' of the stored procedure.
			oDatabaseHelper.AddParameter("@TransactionID", _transactionIDNonDefault );
            
			// Pass the value of '_transactionDate' as parameter 'TransactionDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@TransactionDate", _transactionDateNonDefault );
            
			// Pass the value of '_transactionStatus' as parameter 'TransactionStatus' of the stored procedure.
			oDatabaseHelper.AddParameter("@TransactionStatus", _transactionStatusNonDefault );
            
			// Pass the value of '_processedDate' as parameter 'ProcessedDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@ProcessedDate", _processedDateNonDefault );
            
			// Pass the value of '_revised' as parameter 'Revised' of the stored procedure.
			oDatabaseHelper.AddParameter("@Revised", _revisedNonDefault );
            
			// Pass the value of '_checkDate' as parameter 'CheckDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@CheckDate", _checkDateNonDefault );
            
			// Pass the value of '_processedBY' as parameter 'ProcessedBY' of the stored procedure.
			oDatabaseHelper.AddParameter("@ProcessedBY", _processedBYNonDefault );
            
			// Pass the value of '_depositDate' as parameter 'DepositDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@DepositDate", _depositDateNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_BILLING_DETAILS_Update", ref ExecutionState);
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
		/// DLGenerator			12/30/2014 3:52:03 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Delete() 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_billingDetailID' as parameter 'BillingDetailID' of the stored procedure.
			if(_billingDetailIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@BillingDetailID", _billingDetailIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@BillingDetailID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_BILLING_DETAILS_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_BillingDetailPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/30/2014 3:52:03 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool Delete(BO_BillingDetailPrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_BILLING_DETAILS_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_BillingDetailFields">Field of the class BO_BillingDetail</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/30/2014 3:52:03 PM		Created function
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
			
			oDatabaseHelper.ExecuteScalar("GEN_BILLING_DETAILS_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_BillingDetailPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_BillingDetail</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/30/2014 3:52:03 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_BillingDetail SelectOne(BO_BillingDetailPrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BILLING_DETAILS_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_BillingDetail obj=new BO_BillingDetail();	
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
		/// <returns>list of objects of class BO_BillingDetail in the form of object of BO_BillingDetails </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/30/2014 3:52:03 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_BillingDetails SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BILLING_DETAILS_SelectAll", ref ExecutionState);
			BO_BillingDetails BO_BillingDetails = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_BillingDetails;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_BillingDetail</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_BillingDetail in the form of an object of class BO_BillingDetails</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/30/2014 3:52:03 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_BillingDetails SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BILLING_DETAILS_SelectByField", ref ExecutionState);
			BO_BillingDetails BO_BillingDetails = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_BillingDetails;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="BATCH_PROCESSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_BillingDetails</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/30/2014 3:52:03 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_BillingDetails SelectAllByForeignKeyBatchID(BO_BatchProcessPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_BillingDetails obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BILLING_DETAILS_SelectAllByForeignKeyBatchID", ref ExecutionState);
			obj = new BO_BillingDetails();
			obj = BO_BillingDetail.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will delete row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="BATCH_PROCESSPrimaryKey">Primary Key information based on which data is to be deleted.</param>
		///
		/// <returns>object of boolean type as an indicator for operation success .</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/30/2014 3:52:03 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool DeleteAllByForeignKeyBatchID(BO_BatchProcessPrimaryKey pk)
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_BILLING_DETAILS_DeleteAllByForeignKeyBatchID", ref ExecutionState);
			oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}



		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="BILLINGPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_BillingDetails</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/30/2014 3:52:03 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_BillingDetails SelectAllByForeignKeyBillingID(BO_BillingPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_BillingDetails obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BILLING_DETAILS_SelectAllByForeignKeyBillingID", ref ExecutionState);
			obj = new BO_BillingDetails();
			obj = BO_BillingDetail.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will delete row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="BILLINGPrimaryKey">Primary Key information based on which data is to be deleted.</param>
		///
		/// <returns>object of boolean type as an indicator for operation success .</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/30/2014 3:52:03 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool DeleteAllByForeignKeyBillingID(BO_BillingPrimaryKey pk)
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_BILLING_DETAILS_DeleteAllByForeignKeyBillingID", ref ExecutionState);
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
	    /// DLGenerator			12/30/2014 3:52:03 PM		Created function
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
		/// <param name="obj" type="BILLING_DETAILS">Object of BILLING_DETAILS to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/30/2014 3:52:03 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_BillingDetailBase obj,IDataReader rdr) 
		{

			obj.BillingDetailID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_BillingDetailFields.BillingDetailID)));
			obj.BillingID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_BillingDetailFields.BillingID)));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingDetailFields.TypeFee)))
			{
				obj.TypeFee = rdr.GetString(rdr.GetOrdinal(BO_BillingDetailFields.TypeFee));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingDetailFields.BatchID)))
			{
				obj.BatchID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_BillingDetailFields.BatchID)));
			}
			
			obj.TypeBilling = rdr.GetString(rdr.GetOrdinal(BO_BillingDetailFields.TypeBilling));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingDetailFields.PivNum)))
			{
				obj.PivNum = rdr.GetString(rdr.GetOrdinal(BO_BillingDetailFields.PivNum));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingDetailFields.Amount)))
			{
				obj.Amount = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_BillingDetailFields.Amount)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingDetailFields.PayMode)))
			{
				obj.PayMode = rdr.GetString(rdr.GetOrdinal(BO_BillingDetailFields.PayMode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingDetailFields.Comment)))
			{
				obj.Comment = rdr.GetString(rdr.GetOrdinal(BO_BillingDetailFields.Comment));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingDetailFields.TransactionID)))
			{
				obj.TransactionID = rdr.GetString(rdr.GetOrdinal(BO_BillingDetailFields.TransactionID));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingDetailFields.TransactionDate)))
			{
				obj.TransactionDate = rdr.GetDateTime(rdr.GetOrdinal(BO_BillingDetailFields.TransactionDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingDetailFields.TransactionStatus)))
			{
				obj.TransactionStatus = rdr.GetString(rdr.GetOrdinal(BO_BillingDetailFields.TransactionStatus));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingDetailFields.ProcessedDate)))
			{
				obj.ProcessedDate = rdr.GetDateTime(rdr.GetOrdinal(BO_BillingDetailFields.ProcessedDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingDetailFields.Revised)))
			{
				obj.Revised = rdr.GetString(rdr.GetOrdinal(BO_BillingDetailFields.Revised));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingDetailFields.CheckDate)))
			{
				obj.CheckDate = rdr.GetDateTime(rdr.GetOrdinal(BO_BillingDetailFields.CheckDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingDetailFields.ProcessedBY)))
			{
				obj.ProcessedBY = rdr.GetString(rdr.GetOrdinal(BO_BillingDetailFields.ProcessedBY));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingDetailFields.DepositDate)))
			{
				obj.DepositDate = rdr.GetDateTime(rdr.GetOrdinal(BO_BillingDetailFields.DepositDate));
			}
			

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_BillingDetails</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/30/2014 3:52:03 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_BillingDetails PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_BillingDetails list = new BO_BillingDetails();
			
			while (rdr.Read())
			{
				BO_BillingDetail obj = new BO_BillingDetail();
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
		/// <returns>Object of BO_BillingDetails</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/30/2014 3:52:03 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_BillingDetails PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_BillingDetails list = new BO_BillingDetails();
			
            if (rdr.Read())
            {
                BO_BillingDetail obj = new BO_BillingDetail();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_BillingDetail();
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
